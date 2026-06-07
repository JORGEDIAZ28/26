Imports capaDatos

Public Class clsDevolucion
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable


    Public Function buscarVentaPorComprobante(nroComprobante As String) As DataTable
        ' Buscamos primero en COMPROBANTEVENTA y traemos la información de la VENTA
        strConsulta = "SELECT V.IDPEDIDO, V.FECHAHORA, V.ESTADO, " &
                      "ISNULL(C.NOMBRES + ' ' + C.APELLIDOPATERNO, C.RAZONSOCIAL) AS CLIENTE, " &
                      "DATEDIFF(HOUR, V.FECHAHORA, GETDATE()) AS HORAS_TRANSCURRIDAS, " &
                      "(48 - DATEDIFF(HOUR, V.FECHAHORA, GETDATE())) AS HORAS_RESTANTES " &
                      "FROM VENTA V " &
                      "INNER JOIN CLIENTE C ON V.IDCLIENTE = C.IDCLIENTE " &
                      "INNER JOIN COMPROBANTEVENTA CV ON V.IDPEDIDO = CV.IDPEDIDO " &
                      "WHERE CV.NROCOMPROBANTE = '" & nroComprobante.Replace("'", "''") & "'"

        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al buscar el comprobante.")
        End Try
    End Function

    '=========================================
    ' BUSCAR VENTA Y VALIDAR TIEMPO
    '=========================================
    Public Function buscarVentaParaDevolucion(idPedido As Integer) As DataTable
        ' Usamos 48 - DATEDIFF para saber cuánto le queda
        strConsulta = "SELECT V.IDPEDIDO, V.FECHAHORA, V.ESTADO, " &
                      "ISNULL(C.NOMBRES + ' ' + C.APELLIDOPATERNO, C.RAZONSOCIAL) AS CLIENTE, " &
                      "DATEDIFF(HOUR, V.FECHAHORA, GETDATE()) AS HORAS_TRANSCURRIDAS, " &
                      "(48 - DATEDIFF(HOUR, V.FECHAHORA, GETDATE())) AS HORAS_RESTANTES " &
                      "FROM VENTA V " &
                      "INNER JOIN CLIENTE C ON V.IDCLIENTE = C.IDCLIENTE " &
                      "WHERE V.IDPEDIDO = " & idPedido
        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al buscar la Venta.")
        End Try
    End Function

    '=========================================
    ' CARGAR PRODUCTOS DE ESA VENTA
    '=========================================
    Public Function listarDetallesVenta(idPedido As Integer) As DataTable
        strConsulta = "SELECT P.NOMBRE, M.NOMBREMARCA, DV.CANTIDAD, DV.PRECIO, (DV.CANTIDAD * DV.PRECIO) AS SUBTOTAL " &
                      "FROM DETALLE_VENTA DV " &
                      "INNER JOIN DETALLE_PRODUCTO DP ON DV.IDDETALLEPRODUCTO = DP.IDDETALLEPRODUCTO " &
                      "INNER JOIN PRODUCTO P ON DP.IDPRODUCTO = P.IDPRODUCTO " &
                      "INNER JOIN MARCA M ON DP.IDMARCA = M.IDMARCA " &
                      "WHERE DV.IDPEDIDO = " & idPedido
        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al listar los detalles de la venta.")
        End Try
    End Function

    '=========================================
    ' VERIFICAR SI YA EXISTE DEVOLUCIÓN (Tu regla UNIQUE)
    '=========================================
    Public Function existeDevolucionPrevia(idPedido As Integer) As Boolean
        strConsulta = "SELECT COUNT(*) FROM DEVOLUCION WHERE IDPEDIDO = " & idPedido
        Try
            dt = objMan.listarComando(strConsulta)
            If CInt(dt.Rows(0).Item(0)) > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception("Error al verificar devoluciones previas.")
        End Try
    End Function

    '=========================================
    ' GUARDAR SOLICITUD DE DEVOLUCIÓN
    '=========================================
    Public Sub guardarDevolucion(idPedido As Integer, motivo As String, observacion As String, idUsuario As Integer)
        ' No enviamos RESULTADO ni FECHA porque SQL tiene valores DEFAULT ('Pendiente' y GETDATE())
        strConsulta = "INSERT INTO DEVOLUCION (IDPEDIDO, MOTIVO, OBSERVACION, IDUSUARIO) " &
                      "VALUES (" & idPedido & ", '" & motivo & "', '" & observacion.Replace("'", "''") & "', " & idUsuario & ")"
        Try
            objMan.ejecutarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al registrar la devolución: " & ex.Message)
        End Try
    End Sub

End Class