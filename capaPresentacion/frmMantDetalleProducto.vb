Imports capaNegocio

Public Class frmMantDetalleProducto
    Dim objDetalle As New clsDetalleProducto
    Dim objProducto As New clsProducto
    Dim objMarca As New clsMarca
    Dim objPresentacion As New clsPresentacion

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"

                Dim nuevoID As Integer = objDetalle.obtenerIDDetalleProducto()
                txtId.Text = nuevoID
                txtSku.Text = "SKU-" & nuevoID.ToString("D5")
                txtStock.Text = "0"
                txtCantidad.Text = "1"
                cboUnidad.SelectedIndex = 0

            Else
                btnNuevo.Text = "Nuevo"

                objDetalle.guardarDetalleProducto(
                txtSku.Text,
                CDec(txtPrecio.Text),
                chkVigencia.Checked,
                CInt(txtStock.Text),
                CInt(txtCantidad.Text),
                cboUnidad.Text,
                CInt(cboMarca.SelectedValue),
                CInt(cboPresentacion.SelectedValue),
                CInt(cboProducto.SelectedValue))

                dgvDetalles.DataSource = objDetalle.listarDetalleProductos()
                limpiarControles()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMantDetalleProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cboUnidad.Items.Clear()
            cboUnidad.Items.Add("Tabletas")
            cboUnidad.Items.Add("Cápsulas")
            cboUnidad.Items.Add("ml")
            cboUnidad.Items.Add("Gotas")
            cboUnidad.Items.Add("Sobres")
            cboUnidad.Items.Add("Ampollas")
            cboUnidad.Items.Add("Gramos")
            cboUnidad.Items.Add("Unidad")
            cboUnidad.SelectedIndex = 0

            cboProducto.DataSource = objProducto.listarProductos()
            cboProducto.DisplayMember = "NOMBRE"
            cboProducto.ValueMember = "IDPRODUCTO"

            cboMarca.DataSource = objMarca.listarMarcas()
            cboMarca.DisplayMember = "NOMBREMARCA"
            cboMarca.ValueMember = "IDMARCA"

            cboPresentacion.DataSource = objPresentacion.listarPresentaciones()
            cboPresentacion.DisplayMember = "TIPOPRESENTACION"
            cboPresentacion.ValueMember = "IDPRESENTACION"

            dgvDetalles.AllowUserToAddRows = False
            dgvDetalles.DataSource = objDetalle.listarDetalleProductos()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtId.Text.Length > 0 Then

                objDetalle.modificarDetalleProducto(
                CInt(txtId.Text),
                txtSku.Text,
                CDec(txtPrecio.Text),
                chkVigencia.Checked,
                CInt(txtStock.Text),
                CInt(txtCantidad.Text),
                cboUnidad.Text,
                CInt(cboMarca.SelectedValue),
                CInt(cboPresentacion.SelectedValue),
                CInt(cboProducto.SelectedValue))

                dgvDetalles.DataSource = objDetalle.listarDetalleProductos()
                limpiarControles()
            Else
                MessageBox.Show("Ingrese ID de detalle a modificar", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Try

            If txtId.Text.Length > 0 Then

                objDetalle.eliminarDetalleProducto(CInt(txtId.Text))
                dgvDetalles.DataSource = objDetalle.listarDetalleProductos()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de detalle a eliminar",
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                        "MENSAJE",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click

        Try

            If txtId.Text.Length > 0 Then

                objDetalle.darBajaDetalleProducto(CInt(txtId.Text))
                dgvDetalles.DataSource = objDetalle.listarDetalleProductos()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de detalle",
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                        "MENSAJE",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dt As New DataTable
        Try
            If txtId.TextLength > 0 Then
                dt = objDetalle.buscarDetalleProducto(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then
                    txtSku.Text = dt.Rows(0).Item("SKU").ToString()
                    txtPrecio.Text = dt.Rows(0).Item("PRECIO").ToString()
                    txtStock.Text = dt.Rows(0).Item("STOCK").ToString()
                    txtCantidad.Text = dt.Rows(0).Item("CANTIDAD").ToString()
                    cboUnidad.Text = dt.Rows(0).Item("UNIDAD").ToString()
                    chkVigencia.Checked = CBool(dt.Rows(0).Item("ESTADO"))

                    cboMarca.SelectedValue = dt.Rows(0).Item("IDMARCA")
                    cboPresentacion.SelectedValue = dt.Rows(0).Item("IDPRESENTACION")
                    cboProducto.SelectedValue = dt.Rows(0).Item("IDPRODUCTO")
                Else
                    MessageBox.Show("ID de detalle de producto no existe", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetalles_Click(sender As Object, e As EventArgs) Handles dgvDetalles.Click

        Try
            If dgvDetalles.SelectedRows.Count > 0 Then
                txtId.Text = dgvDetalles.SelectedRows(0).Cells(0).Value.ToString()
                btnBuscar_Click(sender, e)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub limpiarControles()
        txtId.Clear()
        txtSku.Clear()
        txtPrecio.Clear()
        txtStock.Clear()
        txtCantidad.Clear()
        chkVigencia.Checked = False

        If cboUnidad.Items.Count > 0 Then cboUnidad.SelectedIndex = 0
        If cboProducto.Items.Count > 0 Then cboProducto.SelectedIndex = 0
        If cboMarca.Items.Count > 0 Then cboMarca.SelectedIndex = 0
        If cboPresentacion.Items.Count > 0 Then cboPresentacion.SelectedIndex = 0
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        If MessageBox.Show("¿Desea salir del formulario?",
                       "MENSAJE",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

            Me.Close()

        End If

    End Sub
End Class