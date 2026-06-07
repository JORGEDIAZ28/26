Imports capaNegocio

Public Class frmMantLaboratorio
    Dim objLaboratorio As New clsLaboratorio

    '=========================================
    ' NUEVO / GUARDAR
    '=========================================
    Private Sub btnNuevo_Click(sender As Object,
                               e As EventArgs) Handles btnNuevo.Click

        Try

            If btnNuevo.Text = "Nuevo" Then

                btnNuevo.Text = "Guardar"
                txtId.Text = objLaboratorio.obtenerIDLaboratorio()

            Else

                btnNuevo.Text = "Nuevo"

                objLaboratorio.guardarLaboratorio(
                    txtNombre.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    chkVigencia.Checked)

                dgvLaboratorio.DataSource = objLaboratorio.listarLaboratorios()
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
    Private Sub frmMantLaboratorio_Load(sender As Object,
                                      e As EventArgs) Handles MyBase.Load

        Try

            dgvLaboratorio.AllowUserToAddRows = False
            dgvLaboratorio.DataSource = objLaboratorio.listarLaboratorios()

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

                objLaboratorio.modificarLaboratorio(
                    CInt(txtId.Text),
                    txtNombre.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    chkVigencia.Checked)

                dgvLaboratorio.DataSource = objLaboratorio.listarLaboratorios()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de laboratorio a modificar",
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

                objLaboratorio.eliminarLaboratorio(CInt(txtId.Text))
                dgvLaboratorio.DataSource = objLaboratorio.listarLaboratorios()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de laboratorio a eliminar",
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

                objLaboratorio.darBajaLaboratorio(CInt(txtId.Text))
                dgvLaboratorio.DataSource = objLaboratorio.listarLaboratorios()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de laboratorio",
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

                dt = objLaboratorio.buscarLaboratorio(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then

                    txtNombre.Text = dt.Rows(0).Item("NOMBRELABORATORIO").ToString()
                    txtDireccion.Text = dt.Rows(0).Item("DIRECCION").ToString()
                    txtTelefono.Text = dt.Rows(0).Item("TELEFONO").ToString()
                    chkVigencia.Checked = CBool(dt.Rows(0).Item("VIGENCIA"))

                Else

                    MessageBox.Show("ID de laboratorio no existe",
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
    Private Sub dgvLaboratorio_Click(sender As Object,
                                   e As EventArgs) Handles dgvLaboratorio.Click

        Try
            If dgvLaboratorio.SelectedRows.Count > 0 Then
                txtId.Text = dgvLaboratorio.SelectedRows(0).Cells(0).Value.ToString()
                btnBuscar_Click(sender, e)
            End If
        Catch ex As Exception
        End Try

    End Sub

    '=========================================
    ' LIMPIAR CONTROLES
    '=========================================
    Public Sub limpiarControles()

        txtId.Clear()
        txtNombre.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
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