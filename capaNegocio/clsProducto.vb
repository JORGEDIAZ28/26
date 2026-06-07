Imports capaDatos

Public Class clsProducto
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDProducto() As Integer

        strConsulta = "select isnull(max(IDPRODUCTO),0)+1 from PRODUCTO"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Producto!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarProductos() As DataTable

        strConsulta = "select * from PRODUCTO"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Productos!")

        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarProducto(id As Integer) As DataTable

        strConsulta = "select * from PRODUCTO where IDPRODUCTO=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Producto!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarProducto(
            nombre As String,
            descripcion As String,
            estado As Boolean)

        ' Especificamos las columnas y el orden exacto de tu tabla
        strConsulta = "insert into PRODUCTO (NOMBRE, ESTADO, DESCRIPCION) values('" &
                        nombre.Replace("'", "''") & "'," &
                        IIf(estado, 1, 0) & ",'" &
                        descripcion.Replace("'", "''") & "')"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Producto! Detalle: " & ex.Message)

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarProducto(
            id As Integer,
            nombre As String,
            descripcion As String,
            estado As Boolean)

        strConsulta = "update PRODUCTO set " &
                        "NOMBRE='" & nombre.Replace("'", "''") & "'," &
                        "ESTADO=" & IIf(estado, 1, 0) & "," &
                        "DESCRIPCION='" & descripcion.Replace("'", "''") & "'" &
                        " where IDPRODUCTO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Producto! Detalle: " & ex.Message)

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarProducto(id As Integer)

        strConsulta = "delete from PRODUCTO where IDPRODUCTO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Producto!")

        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaProducto(id As Integer)

        strConsulta = "update PRODUCTO set ESTADO=0 where IDPRODUCTO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al dar de baja Producto!")

        End Try

    End Sub
    Public Function listarBusquedaGeneral() As DataTable
        ' Esta consulta une las 5 tablas principales según tu script de BD
        strConsulta = "SELECT P.NOMBRE AS Producto, " &
                      "M.NOMBREMARCA AS Marca, " &
                      "L.NOMBRELABORATORIO AS Laboratorio, " &
                      "PR.TIPOPRESENTACION AS Presentacion, " &
                      "DP.PRECIO AS Precio, " &
                      "DP.STOCK AS Stock " &
                      "FROM DETALLE_PRODUCTO DP " &
                      "INNER JOIN PRODUCTO P ON DP.IDPRODUCTO = P.IDPRODUCTO " &
                      "INNER JOIN MARCA M ON DP.IDMARCA = M.IDMARCA " &
                      "INNER JOIN LABORATORIO L ON M.IDLABORATORIO = L.IDLABORATORIO " &
                      "INNER JOIN PRESENTACION PR ON DP.IDPRESENTACION = PR.IDPRESENTACION " &
                      "WHERE DP.ESTADO = 1"
        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al realizar la búsqueda cruzada: " & ex.Message)
        End Try
    End Function
End Class
