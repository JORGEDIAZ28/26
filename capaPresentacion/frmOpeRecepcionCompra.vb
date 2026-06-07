Imports capaNegocio

Public Class frmOpeRecepcionCompra
    Dim objRecepcion As New clsRecepcionCompra
    Dim dtTemporalDetalle As New DataTable
    Dim dtProductosOrden As New DataTable
    Dim idOrdenActual As Integer = 0

    Private Sub frmRecepcionCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cboEstadoRecepcion.Items.Clear()
            cboEstadoRecepcion.Items.Add("Completa")
            cboEstadoRecepcion.Items.Add("Parcial")
            cboEstadoRecepcion.Items.Add("Con observacion")

            ' CREAR LAS COLUMNAS POR CÓDIGO
            dtTemporalDetalle.Columns.Add("IDDETALLEORDEN", GetType(Integer))
            dtTemporalDetalle.Columns.Add("IDDETALLEPRODUCTO", GetType(Integer))
            dtTemporalDetalle.Columns.Add("PRODUCTO", GetType(String))
            dtTemporalDetalle.Columns.Add("CANTIDADRECIBIDA", GetType(Integer))
            dtTemporalDetalle.Columns.Add("PRECIOCOMPRA", GetType(Decimal))
            dtTemporalDetalle.Columns.Add("NROLOTE", GetType(String))
            dtTemporalDetalle.Columns.Add("FECHAFABRICACION", GetType(Date))
            dtTemporalDetalle.Columns.Add("FECHAVENCIMIENTO", GetType(Date))

            dgvDetalleRecepcion.AllowUserToAddRows = False
            dgvDetalleRecepcion.DataSource = dtTemporalDetalle

            dgvDetalleRecepcion.Columns("IDDETALLEORDEN").Visible = False
            dgvDetalleRecepcion.Columns("IDDETALLEPRODUCTO").Visible = False

            limpiarControles()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscarOrden_Click(sender As Object, e As EventArgs) Handles btnBuscarOrden.Click
        Try
            If txtNroOrden.TextLength > 0 Then
                ' Buscamos usando el texto tal cual (Ej: "OC-2026-002")
                dtProductosOrden = objRecepcion.listarDetallesPorOrden(txtNroOrden.Text)

                If dtProductosOrden.Rows.Count > 0 Then
                    ' Extraemos el ID interno para poder guardar después
                    idOrdenActual = CInt(dtProductosOrden.Rows(0).Item("IDORDEN"))

                    cboProductoOrden.DataSource = dtProductosOrden
                    cboProductoOrden.DisplayMember = "PRODUCTO"
                    cboProductoOrden.ValueMember = "IDDETALLEPRODUCTO"
                Else
                    MessageBox.Show("La orden no existe o ya fue recibida por completo",
                                    "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ingrese Nro de Orden (Ej: OC-2026-002)",
                                "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If cboProductoOrden.Text = "" Or txtCantRecibir.Text = "" Or txtNroLote.Text = "" Then
                MessageBox.Show("Faltan datos del producto, cantidad o lote",
                                "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim filaSeleccionada As DataRowView = DirectCast(cboProductoOrden.SelectedItem, DataRowView)

            Dim nuevaFila As DataRow = dtTemporalDetalle.NewRow()
            nuevaFila("IDDETALLEORDEN") = CInt(filaSeleccionada("IDDETALLEORDEN"))
            nuevaFila("IDDETALLEPRODUCTO") = CInt(filaSeleccionada("IDDETALLEPRODUCTO"))
            nuevaFila("PRODUCTO") = filaSeleccionada("PRODUCTO").ToString()
            nuevaFila("CANTIDADRECIBIDA") = CInt(txtCantRecibir.Text)
            nuevaFila("PRECIOCOMPRA") = CDec(filaSeleccionada("PRECIOUNITARIO"))
            nuevaFila("NROLOTE") = txtNroLote.Text.Trim()
            nuevaFila("FECHAFABRICACION") = dtpFabricacion.Value.Date
            nuevaFila("FECHAVENCIMIENTO") = dtpVencimiento.Value.Date

            dtTemporalDetalle.Rows.Add(nuevaFila)

            txtCantRecibir.Clear()
            txtNroLote.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                limpiarControles()
                txtNroRecepcion.Text = objRecepcion.obtenerNroRecepcion()
            Else
                If idOrdenActual = 0 Or dtTemporalDetalle.Rows.Count = 0 Or txtNroFactura.Text = "" Then
                    MessageBox.Show("Faltan cargar la orden, factura o productos",
                                    "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                btnNuevo.Text = "Nuevo"

                ' Usuario quemado para pruebas (En tu BD el ID 1 es "Juan Carlos Perez")
                Dim idUsuario As Integer = 1

                objRecepcion.guardarRecepcionCompleta(
                    idOrdenActual,
                    txtNroRecepcion.Text,
                    txtNroFactura.Text,
                    txtObservacion.Text,
                    cboEstadoRecepcion.Text,
                    idUsuario,
                    dtTemporalDetalle)

                MessageBox.Show("Recepción registrada correctamente",
                                "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                limpiarControles()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub limpiarControles()
        txtNroRecepcion.Clear()
        txtNroOrden.Clear()
        txtNroFactura.Clear()
        txtObservacion.Clear()
        txtCantRecibir.Clear()
        txtNroLote.Clear()
        dtTemporalDetalle.Rows.Clear()
        idOrdenActual = 0
        If cboEstadoRecepcion.Items.Count > 0 Then cboEstadoRecepcion.SelectedIndex = 0
        cboProductoOrden.DataSource = Nothing
        dtpFabricacion.Value = Date.Today
        dtpVencimiento.Value = Date.Today
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Desea salir del formulario?",
                       "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class