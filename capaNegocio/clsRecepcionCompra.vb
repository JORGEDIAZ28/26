Imports System.Text
Imports capaDatos

Public Class clsRecepcionCompra
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' GENERAR NRO DE RECEPCIÓN
    '=========================================
    Public Function obtenerNroRecepcion() As String
        strConsulta = "SELECT ISNULL(MAX(IDRECEPCION), 0) + 1 FROM RECEPCION_COMPRA"
        Try
            dt = objMan.listarComando(strConsulta)
            Dim siguienteID As Integer = CInt(dt.Rows(0).Item(0))
            Return "RC-" & Now.Year.ToString() & "-" & siguienteID.ToString("D3")
        Catch ex As Exception
            Throw New Exception("Error al generar el número de Recepción.")
        End Try
    End Function

    '=========================================
    ' BUSCAR DETALLES DE LA ORDEN PENDIENTE (POR TEXTO)
    '=========================================
    Public Function listarDetallesPorOrden(nroOrden As String) As DataTable
        ' Ahora busca por el texto NROORDEN y también devuelve el IDORDEN oculto
        strConsulta = "SELECT DOC.IDORDEN, DOC.IDDETALLEORDEN, DP.IDDETALLEPRODUCTO, P.NOMBRE + ' - ' + M.NOMBREMARCA AS PRODUCTO, " &
                      "PR.TIPOPRESENTACION + ' x ' + CAST(DP.CANTIDAD AS VARCHAR) + ' ' + DP.UNIDAD AS EMPAQUE, " &
                      "DOC.CANTIDADPEDIDA - DOC.CANTIDADRECIBIDA AS PENDIENTE, DOC.PRECIOUNITARIO " &
                      "FROM DETALLE_ORDEN_COMPRA DOC " &
                      "INNER JOIN ORDEN_COMPRA OC ON DOC.IDORDEN = OC.IDORDEN " &
                      "INNER JOIN DETALLE_PRODUCTO DP ON DOC.IDDETALLEPRODUCTO = DP.IDDETALLEPRODUCTO " &
                      "INNER JOIN PRODUCTO P ON DP.IDPRODUCTO = P.IDPRODUCTO " &
                      "INNER JOIN MARCA M ON DP.IDMARCA = M.IDMARCA " &
                      "INNER JOIN PRESENTACION PR ON DP.IDPRESENTACION = PR.IDPRESENTACION " &
                      "WHERE OC.NROORDEN = '" & nroOrden.Trim() & "' AND (DOC.CANTIDADPEDIDA - DOC.CANTIDADRECIBIDA) > 0"
        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al buscar detalles de la orden.")
        End Try
    End Function

    '=========================================
    ' GUARDAR RECEPCIÓN COMPLETA (TRANSACCIÓN)
    '=========================================
    Public Sub guardarRecepcionCompleta(
            idOrden As Integer,
            nroRecepcion As String,
            nroFactura As String,
            observacion As String,
            estadoRecepcion As String,
            idUsuario As Integer,
            dtDetalles As DataTable)

        Dim sqlBatch As New StringBuilder()

        sqlBatch.AppendLine("BEGIN TRY")
        sqlBatch.AppendLine("BEGIN TRANSACTION;")

        ' 1. Guardar Cabecera
        sqlBatch.AppendLine("DECLARE @idRecepcion INT;")
        sqlBatch.AppendLine("INSERT INTO RECEPCION_COMPRA (IDORDEN, NRORECEPCION, NROFACTURA, OBSERVACION, ESTADO, IDUSUARIO)")
        sqlBatch.AppendLine("VALUES (" & idOrden & ", '" & nroRecepcion & "', '" & nroFactura.Replace("'", "''") & "', '" & observacion.Replace("'", "''") & "', '" & estadoRecepcion & "', " & idUsuario & ");")
        sqlBatch.AppendLine("SET @idRecepcion = SCOPE_IDENTITY();")

        ' 2. Recorrer Lotes y Detalles
        Dim i As Integer = 0
        For Each fila As DataRow In dtDetalles.Rows
            Dim idDetalleOrden As Integer = CInt(fila("IDDETALLEORDEN"))
            Dim idDetalleProducto As Integer = CInt(fila("IDDETALLEPRODUCTO"))
            Dim cant As Integer = CInt(fila("CANTIDADRECIBIDA"))
            Dim precio As String = CDec(fila("PRECIOCOMPRA")).ToString().Replace(",", ".")
            Dim nroLote As String = fila("NROLOTE").ToString().Replace("'", "''")
            Dim fechaFab As String = CDate(fila("FECHAFABRICACION")).ToString("yyyy-MM-dd")
            Dim fechaVenc As String = CDate(fila("FECHAVENCIMIENTO")).ToString("yyyy-MM-dd")

            Dim varLote As String = "@idLote_" & i

            sqlBatch.AppendLine("DECLARE " & varLote & " INT;")
            sqlBatch.AppendLine("SELECT " & varLote & " = IDLOTE FROM LOTE WHERE NROLOTE = '" & nroLote & "' AND IDDETALLEPRODUCTO = " & idDetalleProducto & ";")

            sqlBatch.AppendLine("IF " & varLote & " IS NULL")
            sqlBatch.AppendLine("BEGIN")
            sqlBatch.AppendLine("   INSERT INTO LOTE (NROLOTE, FECHAFABRICACION, FECHAVENCIMIENTO, STOCK_INICIAL, STOCK_ACTUAL, IDDETALLEPRODUCTO, IDUSUARIO, VIGENCIA)")
            sqlBatch.AppendLine("   VALUES ('" & nroLote & "', '" & fechaFab & "', '" & fechaVenc & "', " & cant & ", " & cant & ", " & idDetalleProducto & ", " & idUsuario & ", 1);")
            sqlBatch.AppendLine("   SET " & varLote & " = SCOPE_IDENTITY();")
            sqlBatch.AppendLine("END")
            sqlBatch.AppendLine("ELSE")
            sqlBatch.AppendLine("BEGIN")
            sqlBatch.AppendLine("   UPDATE LOTE SET STOCK_ACTUAL = STOCK_ACTUAL + " & cant & ", STOCK_INICIAL = STOCK_INICIAL + " & cant & " WHERE IDLOTE = " & varLote & ";")
            sqlBatch.AppendLine("END")

            sqlBatch.AppendLine("INSERT INTO DETALLE_RECEPCION (IDRECEPCION, IDDETALLEORDEN, CANTIDADRECIBIDA, PRECIOCOMPRA, IDLOTE)")
            sqlBatch.AppendLine("VALUES (@idRecepcion, " & idDetalleOrden & ", " & cant & ", " & precio & ", " & varLote & ");")

            i += 1
        Next

        ' 3. Actualizar Estado de la Orden
        sqlBatch.AppendLine("IF ('" & estadoRecepcion & "' = 'Completa')")
        sqlBatch.AppendLine("   UPDATE ORDEN_COMPRA SET ESTADO = 'Recibida' WHERE IDORDEN = " & idOrden & ";")
        sqlBatch.AppendLine("ELSE")
        sqlBatch.AppendLine("   UPDATE ORDEN_COMPRA SET ESTADO = 'Recibida parcial' WHERE IDORDEN = " & idOrden & ";")

        sqlBatch.AppendLine("COMMIT TRANSACTION;")
        sqlBatch.AppendLine("END TRY")
        sqlBatch.AppendLine("BEGIN CATCH")
        sqlBatch.AppendLine("   ROLLBACK TRANSACTION;")
        sqlBatch.AppendLine("   DECLARE @MsgError NVARCHAR(4000) = ERROR_MESSAGE();")
        sqlBatch.AppendLine("   THROW 50000, @MsgError, 1;")
        sqlBatch.AppendLine("END CATCH")

        Try
            objMan.ejecutarComando(sqlBatch.ToString())
        Catch ex As Exception
            Throw New Exception("Error al guardar la recepción: " & ex.Message)
        End Try
    End Sub

End Class

