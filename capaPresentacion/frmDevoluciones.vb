Imports capaDatos
Imports capaNegocio

Public Class frmDevoluciones
    Dim objDevolucion As New clsDevolucion
    Dim idVentaValida As Integer = 0 ' Para asegurar que guarde la venta correcta

    Private Sub frmRegistroDevolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar motivos exactos según la restricción CHECK de tu base de datos
        cboMotivo.Items.Clear()
        cboMotivo.Items.Add("Error de despacho")
        cboMotivo.Items.Add("Producto defectuoso")
        cboMotivo.Items.Add("Producto vencido")
        cboMotivo.SelectedIndex = 0

        dgvDetalleVenta.AllowUserToAddRows = False
        dgvDetalleVenta.ReadOnly = True
    End Sub

    '=========================================
    ' BUSCAR LA VENTA
    '=========================================
    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        Try
            If txtNroComprobante.Text.Trim() = "" Then
                MessageBox.Show("Ingrese el número de comprobante (ej. B001-00000001).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim nroComp As String = txtNroComprobante.Text.Trim()
            Dim dtVenta As DataTable = objDevolucion.buscarVentaPorComprobante(nroComp)

            If dtVenta.Rows.Count > 0 Then
                ' (Aquí mantienes el resto de tu lógica de validación)
                ' ... igual que antes ...

                Dim idBuscar As Integer = CInt(dtVenta.Rows(0).Item("IDPEDIDO"))

                ' Validar que la venta no esté anulada
                If CBool(dtVenta.Rows(0).Item("ESTADO")) = False Then
                    MessageBox.Show("Este comprobante ya ha sido anulado.", "Rechazado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Cargar datos...
                lblCliente.Text = dtVenta.Rows(0).Item("CLIENTE").ToString()
                ' ...

                ' Importante: Cargamos los detalles usando el IDPEDIDO que obtuvimos
                dgvDetalleVenta.DataSource = objDevolucion.listarDetallesVenta(idBuscar)
                idVentaValida = idBuscar
            Else
                MessageBox.Show("Comprobante no encontrado.", "No existe", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=========================================
    ' GUARDAR DEVOLUCIÓN
    '=========================================
    Private Sub btnGuardarDevolucion_Click(sender As Object, e As EventArgs) Handles btnGuardarDevolucion.Click
        Try
            If idVentaValida = 0 Then
                MessageBox.Show("Debe buscar y cargar una Venta válida primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If txtObservacion.Text.Trim() = "" Then
                MessageBox.Show("Por favor, ingrese una observación detallando el problema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show("¿Registrar solicitud de devolución?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim idUsuarioActivo As Integer = 1 ' Reemplazar por la variable global del usuario logueado

                objDevolucion.guardarDevolucion(idVentaValida, cboMotivo.Text, txtObservacion.Text, idUsuarioActivo)

                MessageBox.Show("Solicitud registrada correctamente. Queda en estado 'Pendiente' para su evaluación.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Limpiamos
                txtNroComprobante.Clear()
                lblCliente.Text = ""
                lblFecha.Text = ""
                lblPlazo.Text = ""
                txtObservacion.Clear()
                dgvDetalleVenta.DataSource = Nothing
                idVentaValida = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class