Imports capaNegocio

Public Class frmMantMedioPago
    Dim objMedioPago As New clsMedioPago

    '=========================================
    ' NUEVO / GUARDAR
    '=========================================

    Private Sub btnNuevo_Click(sender As Object,
                               e As EventArgs) Handles btnNuevo.Click

        Try

            If btnNuevo.Text = "Nuevo" Then

                btnNuevo.Text = "Guardar"

                txtId.Text = objMedioPago.obtenerIDMedioPago

            Else

                btnNuevo.Text = "Nuevo"

                objMedioPago.guardarMedioPago(
                    txtNombre.Text,
                    chkVigencia.Checked)

                dgvMedioPago.DataSource = objMedioPago.listarMedioPago

                limpiarControles()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    '=========================================
    ' LOAD
    '=========================================

    Private Sub frmMantMedioPago_Load(sender As Object,
                                      e As EventArgs) Handles MyBase.Load

        Try

            dgvMedioPago.AllowUserToAddRows = False

            dgvMedioPago.DataSource = objMedioPago.listarMedioPago

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Private Sub btnModificar_Click(sender As Object,
                                   e As EventArgs) Handles btnModificar.Click

        Try

            If txtId.Text.Length > 0 Then

                objMedioPago.modificarMedioPago(
                    CInt(txtId.Text),
                    txtNombre.Text,
                    chkVigencia.Checked)

                dgvMedioPago.DataSource = objMedioPago.listarMedioPago

                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de medio de pago a modificar",
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

    '=========================================
    ' ELIMINAR
    '=========================================

    Private Sub btnEliminar_Click(sender As Object,
                                  e As EventArgs) Handles btnEliminar.Click

        Try

            If txtId.Text.Length > 0 Then

                objMedioPago.eliminarMedioPago(CInt(txtId.Text))

                dgvMedioPago.DataSource = objMedioPago.listarMedioPago

                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de medio de pago a eliminar",
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

    '=========================================
    ' DAR BAJA
    '=========================================

    Private Sub btnDarBaja_Click(sender As Object,
                                 e As EventArgs) Handles btnDarBaja.Click

        Try

            If txtId.Text.Length > 0 Then

                objMedioPago.darBajaMedioPago(CInt(txtId.Text))

                dgvMedioPago.DataSource = objMedioPago.listarMedioPago

                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de medio de pago",
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

    '=========================================
    ' BUSCAR
    '=========================================

    Private Sub btnBuscar_Click(sender As Object,
                                e As EventArgs) Handles btnBuscar.Click

        Dim dt As New DataTable

        Try

            If txtId.TextLength > 0 Then

                dt = objMedioPago.buscarMedioPago(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then

                    txtNombre.Text = dt.Rows(0).Item("NOMBRE")

                    chkVigencia.Checked = dt.Rows(0).Item("ESTADO")

                Else

                    MessageBox.Show("ID de medio de pago no existe",
                                    "MENSAJE",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error)

                End If

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    '=========================================
    ' CLICK DATAGRIDVIEW
    '=========================================

    Private Sub dgvMedioPago_Click(sender As Object,
                                   e As EventArgs) Handles dgvMedioPago.Click

        txtId.Text = dgvMedioPago.SelectedRows(0).Cells(0).Value

        btnBuscar_Click(sender, e)

    End Sub

    '=========================================
    ' LIMPIAR CONTROLES
    '=========================================

    Public Sub limpiarControles()

        txtId.Clear()

        txtNombre.Clear()

        chkVigencia.Checked = False

    End Sub

    '=========================================
    ' SALIR
    '=========================================

    Private Sub btnSalir_Click(sender As Object,
                               e As EventArgs) Handles btnSalir.Click

        If MessageBox.Show("¿Desea salir del formulario?",
                           "MENSAJE",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then

            Me.Close()

        End If

    End Sub
End Class