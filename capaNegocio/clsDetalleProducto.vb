Imports capaDatos

Public Class clsDetalleProducto
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    Public Function obtenerIDDetalleProducto() As Integer

        strConsulta = "select isnull(max(IDDETALLEPRODUCTO),0)+1 from DETALLE_PRODUCTO"

        Try

            dt = objMan.listarComando(strConsulta)
            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Detalle de Producto!")

        End Try

    End Function

    Public Function listarDetalleProductos() As DataTable

        strConsulta = "select * from DETALLE_PRODUCTO"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Detalles de Productos!")

        End Try

    End Function
    Public Function buscarDetalleProducto(id As Integer) As DataTable

        strConsulta = "select * from DETALLE_PRODUCTO where IDDETALLEPRODUCTO=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Detalle de Producto!")

        End Try

    End Function

    Public Sub guardarDetalleProducto(
            sku As String,
            precio As Decimal,
            estado As Boolean,
            stock As Integer,
            cantidad As Integer,
            unidad As String,
            idMarca As Integer,
            idPresentacion As Integer,
            idProducto As Integer)

        Dim strPrecio As String = precio.ToString().Replace(",", ".")

        strConsulta = "insert into DETALLE_PRODUCTO (SKU, PRECIO, ESTADO, STOCK, CANTIDAD, UNIDAD, IDMARCA, IDPRESENTACION, IDPRODUCTO) values('" &
                        sku.Replace("'", "''") & "'," &
                        strPrecio & "," &
                        IIf(estado, 1, 0) & "," &
                        stock & "," &
                        cantidad & ",'" &
                        unidad.Replace("'", "''") & "'," &
                        idMarca & "," &
                        idPresentacion & "," &
                        idProducto & ")"

        Try
            objMan.ejecutarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al registrar Detalle de Producto! Detalle: " & ex.Message)
        End Try
    End Sub

    Public Sub modificarDetalleProducto(
            id As Integer,
            sku As String,
            precio As Decimal,
            estado As Boolean,
            stock As Integer,
            cantidad As Integer,
            unidad As String,
            idMarca As Integer,
            idPresentacion As Integer,
            idProducto As Integer)

        Dim strPrecio As String = precio.ToString().Replace(",", ".")

        strConsulta = "update DETALLE_PRODUCTO set " &
                        "SKU='" & sku.Replace("'", "''") & "'," &
                        "PRECIO=" & strPrecio & "," &
                        "ESTADO=" & IIf(estado, 1, 0) & "," &
                        "STOCK=" & stock & "," &
                        "CANTIDAD=" & cantidad & "," &
                        "UNIDAD='" & unidad.Replace("'", "''") & "'," &
                        "IDMARCA=" & idMarca & "," &
                        "IDPRESENTACION=" & idPresentacion & "," &
                        "IDPRODUCTO=" & idProducto &
                        " where IDDETALLEPRODUCTO=" & id

        Try
            objMan.ejecutarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al modificar Detalle de Producto! Detalle: " & ex.Message)
        End Try
    End Sub

    Public Sub eliminarDetalleProducto(id As Integer)

        strConsulta = "delete from DETALLE_PRODUCTO where IDDETALLEPRODUCTO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Detalle de Producto!")

        End Try

    End Sub

    Public Sub darBajaDetalleProducto(id As Integer)

        strConsulta = "update DETALLE_PRODUCTO set ESTADO=0 where IDDETALLEPRODUCTO=" & id

        Try
            objMan.ejecutarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al dar de baja Detalle de Producto!")
        End Try
    End Sub
End Class
