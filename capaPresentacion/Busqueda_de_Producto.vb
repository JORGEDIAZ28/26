Imports capaNegocio
Public Class Busqueda_de_Producto
    Dim objP As New clsProducto
    Dim objM As New clsMarca
    Dim objL As New clsLaboratorio

    Private Sub Busqueda_de_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar, llenamos los combos y la tabla inicial
        CargarCombos()
        FiltrarProductos()
    End Sub

    Private Sub CargarCombos()
        Try
            ' 1. Llenar Productos (desde clsProducto)
            ComboBoxProducto.DataSource = objP.listarProductos()
            ComboBoxProducto.DisplayMember = "NOMBRE"
            ComboBoxProducto.ValueMember = "IDPRODUCTO"
            ComboBoxProducto.SelectedIndex = -1

            ' 2. Llenar Marcas (desde clsMarca)
            ComboBoxMarca.DataSource = objM.listarMarcas()
            ComboBoxMarca.DisplayMember = "NOMBREMARCA"
            ComboBoxMarca.ValueMember = "IDMARCA"
            ComboBoxMarca.SelectedIndex = -1

            ' 3. Llenar Laboratorios (desde clsLaboratorio)
            ComboBoxLaboratorio.DataSource = objL.listarLaboratorios()
            ComboBoxLaboratorio.DisplayMember = "NOMBRELABORATORIO"
            ComboBoxLaboratorio.ValueMember = "IDLABORATORIO"
            ComboBoxLaboratorio.SelectedIndex = -1

            tblProducto.AllowUserToAddRows = False

            ' 4. Llenar Presentaciones (puedes crear clsPresentacion o usar un método genérico)
            ' Por ahora lo dejamos manual o puedes implementar su clase similar a las anteriores
        Catch ex As Exception
            MessageBox.Show("Error al cargar catálogos: " & ex.Message)
        End Try
    End Sub

    ' Método centralizado para filtrar (Modelo de Interacción)
    Private Sub FiltrarProductos()
        Dim strFiltro As String = ""

        ' Construimos la consulta dinámica basada en lo que el usuario seleccionó
        ' Nota: En un entorno profesional, esto se enviaría a un procedimiento almacenado
        Try
            Dim dt As DataTable = objP.listarBusquedaGeneral() ' Este método debe tener los JOINs

            ' Aplicamos filtro en el DataView del cliente para mayor velocidad (Prestaciones)
            Dim dv As New DataView(dt)
            Dim filtros As New List(Of String)

            If ComboBoxProducto.SelectedIndex <> -1 Then
                filtros.Add("Producto = '" & ComboBoxProducto.Text & "'")
            End If

            If ComboBoxMarca.SelectedIndex <> -1 Then
                filtros.Add("Marca = '" & ComboBoxMarca.Text & "'")
            End If

            If ComboBoxLaboratorio.SelectedIndex <> -1 Then
                filtros.Add("Laboratorio = '" & ComboBoxLaboratorio.Text & "'")
            End If

            If filtros.Count > 0 Then
                dv.RowFilter = String.Join(" AND ", filtros)
            End If

            tblProducto.DataSource = dv
        Catch ex As Exception
            ' Manejo de fallos por omisión
        End Try
    End Sub
    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBoxProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxProducto.SelectedIndexChanged
        FiltrarProductos()
    End Sub

    Private Sub ComboBoxMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMarca.SelectedIndexChanged
        FiltrarProductos()
    End Sub

    Private Sub ComboBoxPresentacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPresentacion.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxLaboratorio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLaboratorio.SelectedIndexChanged
        FiltrarProductos()
    End Sub

    Private Sub tblProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        ComboBoxProducto.SelectedIndex = -1
        ComboBoxMarca.SelectedIndex = -1
        ComboBoxLaboratorio.SelectedIndex = -1
        ComboBoxPresentacion.SelectedIndex = -1
        FiltrarProductos()
    End Sub

    Private Sub dgvProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblProducto.CellContentClick
        If e.RowIndex >= 0 Then

            ' 1. Obtener datos básicos de la fila seleccionada
            Dim nombre As String = tblProducto.Rows(e.RowIndex).Cells("Producto").Value.ToString()
            Dim stockEnBD As Integer = CInt(tblProducto.Rows(e.RowIndex).Cells("Stock").Value)
            Dim precio As Decimal = CDec(tblProducto.Rows(e.RowIndex).Cells("Precio").Value)

            ' 2. Consultar cuánto ya se agregó en el formulario de ventas (Para no sobrepasar el stock)
            Dim cantidadYaAgregada As Integer = 0
            If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is frmOpeVenta Then
                Dim frmVenta As frmOpeVenta = CType(Me.Owner, frmOpeVenta)

                ' CAMBIO AQUÍ: Usa 'frmVenta' (la instancia), NO 'frmOpeVenta' (la clase)
                cantidadYaAgregada = frmVenta.ObtenerCantidadYaAgregada(nombre)
            End If

            ' 3. Calcular el stock real disponible para esta venta específica
            Dim stockDisponibleReal As Integer = stockEnBD - cantidadYaAgregada

            ' 4. Pedir cantidad al usuario
            Dim respuesta As String = InputBox("Stock en BD: " & stockEnBD & vbCrLf &
                                           "Ya en venta: " & cantidadYaAgregada & vbCrLf &
                                           "Disponible: " & stockDisponibleReal & vbCrLf & vbCrLf &
                                           "Ingrese cantidad para: " & nombre, "Agregar Producto", "1")

            ' 5. Procesar la respuesta
            If IsNumeric(respuesta) Then
                Dim cantidadAPedir As Integer = CInt(respuesta)

                If cantidadAPedir <= 0 Then
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf cantidadAPedir > stockDisponibleReal Then
                    ' Validación crítica de stock
                    MessageBox.Show("No puede agregar esa cantidad. Ya tiene " & cantidadYaAgregada &
                                " en la lista y el stock total es " & stockEnBD & ".",
                                "Validación de Stock Real", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    ' 6. ENVIAR DATOS AL FORMULARIO DE VENTA
                    Dim instanciaVenta As frmOpeVenta = CType(Me.Owner, frmOpeVenta)
                    instanciaVenta.AgregarProductoAlDetalle(nombre, precio, cantidadAPedir)

                    ' Actualizamos el stock visualmente en la fila actual para dar feedback inmediato
                    Dim filaSeleccionada As DataRowView = CType(tblProducto.Rows(e.RowIndex).DataBoundItem, DataRowView)
                    filaSeleccionada("Stock") = stockDisponibleReal - cantidadAPedir

                    ' Cerramos la ventana de búsqueda
                    Me.Close()
                End If
            End If
        End If
    End Sub
End Class