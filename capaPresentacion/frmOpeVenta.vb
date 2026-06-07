Public Class frmOpeVenta

    Dim dtDetalle As New DataTable

    Private Sub frmOpeVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Estructuramos la tabla con el orden exacto de tu interfaz:
        ' nombre / cantidad / precio / total
        If dtDetalle.Columns.Count = 0 Then
            dtDetalle.Columns.Add("Producto", GetType(String))
            dtDetalle.Columns.Add("Presentacion", GetType(String)) ' <-- Nueva columna
            dtDetalle.Columns.Add("Cantidad", GetType(Integer))
            dtDetalle.Columns.Add("Precio", GetType(Decimal))
            dtDetalle.Columns.Add("Total", GetType(Decimal))
        End If

        ' Enlazamos la tabla visual con la tabla de datos
        tblProductoAgregado.DataSource = dtDetalle
    End Sub
    Public Sub AgregarProductoAlDetalle(nombre As String, precio As Decimal, cantidad As Integer)
        Try
            ' Escapamos ambos textos para evitar errores con comillas
            Dim nomE As String = nombre.Replace("'", "''")
            Dim preE As String = presentacion.Replace("'", "''")

            ' BUSQUEDA POR LLAVE COMPUESTA: Producto Y Presentacion
            Dim filaExistente As DataRow() = dtDetalle.Select("Producto = '" & nomE & "' AND Presentacion = '" & preE & "'")

            If filaExistente.Length > 0 Then
                Dim fila As DataRow = filaExistente(0)
                fila("Cantidad") = CInt(fila("Cantidad")) + cantidad
                fila("Total") = CDec(fila("Cantidad")) * CDec(fila("Precio"))
            Else
                Dim nuevaFila As DataRow = dtDetalle.NewRow()
                nuevaFila("Producto") = nombre
                nuevaFila("Presentacion") = presentacion
                nuevaFila("Cantidad") = cantidad
                nuevaFila("Precio") = precio
                nuevaFila("Total") = precio * cantidad
                dtDetalle.Rows.Add(nuevaFila)
            End If
            CalcularTotalesVenta()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub CalcularTotalesVenta()
        Dim totalGeneral As Decimal = 0

        Try
            ' 1. Recorremos el DataTable que contiene los productos agregados
            For Each row As DataRow In dtDetalle.Rows
                ' Sumamos la columna "Total" de cada fila
                totalGeneral += CDec(row("Total"))
            Next

            ' 2. Cálculos según la normativa contable peruana (7mo Ciclo de Ingeniería)
            ' El total ya incluye IGV, así que lo "desglosamos":
            ' Base Imponible = Total / 1.18
            ' IGV = Total - Base Imponible

            Dim subtotal As Decimal = totalGeneral / 1.18
            Dim igv As Decimal = totalGeneral - subtotal

            ' 3. Mostramos los resultados formateados en los TextBox de tu interfaz
            ' "N2" asegura que siempre se vean 2 decimales
            txtSubtotal.Text = subtotal.ToString("N2")
            txtIGV.Text = igv.ToString("N2")
            txtTotal.Text = totalGeneral.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error al calcular los totales: " & ex.Message)
        End Try
    End Sub

    Public Function ObtenerCantidadYaAgregada(nombreProducto As String) As Integer
        Dim totalAgregado As Integer = 0
        Try
            Dim nomE As String = nombreProducto.Replace("'", "''")
            Dim preE As String = presentacion.Replace("'", "''")
            Dim filas As DataRow() = dtDetalle.Select("Producto = '" & nomE & "' AND Presentacion = '" & preE & "'")

            If filas.Length > 0 Then
                totalAgregado = CInt(filas(0)("Cantidad"))
            End If
        Catch ex As Exception
        End Try
        Return totalAgregado
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles txtIGV.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles txtTotal.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtTipo.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtDocumento.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCliente.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim objBusqueda As New Busqueda_de_Producto

        ' ESTO ES LO QUE HACE QUE FUNCIONE Me.Owner
        objBusqueda.Owner = Me

        objBusqueda.StartPosition = FormStartPosition.CenterParent
        objBusqueda.ShowDialog()
    End Sub
End Class