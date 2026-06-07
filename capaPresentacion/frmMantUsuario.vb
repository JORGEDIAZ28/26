Imports capaNegocio

Public Class frmMantUsuario
    Dim objUsuario As New clsUsuario

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                txtId.Text = objUsuario.obtenerIDUsuario
            Else
                btnNuevo.Text = "Nuevo"
                objUsuario.guardarUsuario(
                    txtDni.Text,
                    txtNombres.Text,
                    txtApePaterno.Text,
                    txtApeMaterno.Text,
                    dtpFecha.Value,
                    txtCorreo.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    cboSexo.Text,
                    cboCargo.Text,
                    txtUsuario.Text,
                    txtContraseña.Text,
                    chkVigencia.Checked,
                    txtPregunta.Text,
                    txtRespuesta.Text)
                dgvUsuarios.DataSource = objUsuario.listarUsuarios
                limpiarControles()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMantUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvUsuarios.AllowUserToAddRows = False
            dgvUsuarios.DataSource = objUsuario.listarUsuarios
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If txtId.Text.Length > 0 Then
                objUsuario.modificarUsuario(
                    CInt(txtId.Text),
                    txtDni.Text,
                    txtNombres.Text,
                    txtApePaterno.Text,
                    txtApeMaterno.Text,
                    dtpFecha.Value,
                    txtCorreo.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    cboSexo.Text,
                    cboCargo.Text,
                    txtUsuario.Text,
                    txtContraseña.Text,
                    chkVigencia.Checked,
                    txtPregunta.Text,
                    txtRespuesta.Text)
                dgvUsuarios.DataSource = objUsuario.listarUsuarios
                limpiarControles()
            Else
                MessageBox.Show("Ingrese ID de usuario a modificar",
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If txtId.Text.Length > 0 Then
                objUsuario.eliminarUsuario(CInt(txtId.Text))
                dgvUsuarios.DataSource = objUsuario.listarUsuarios
                limpiarControles()
            Else
                MessageBox.Show("Ingrese ID de usuario a eliminar",
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

    Private Sub btnDarBaja_Click(sender As Object,
                                 e As EventArgs) Handles btnDarBaja.Click
        Try
            If txtId.Text.Length > 0 Then
                objUsuario.darBajaUsuario(CInt(txtId.Text))
                dgvUsuarios.DataSource = objUsuario.listarUsuarios
                limpiarControles()
            Else
                MessageBox.Show("Ingrese ID de usuario",
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
                dt = objUsuario.buscarUsuarios(CInt(txtId.Text))
                If dt.Rows.Count > 0 Then
                    txtDni.Text = dt.Rows(0).Item("DNI")
                    txtNombres.Text = dt.Rows(0).Item("NOMBRE")
                    txtApePaterno.Text = dt.Rows(0).Item("APELLIDOPATERNO")
                    txtApeMaterno.Text = dt.Rows(0).Item("APELLIDOMATERNO")
                    dtpFecha.Value = dt.Rows(0).Item("FECHANACIMIENTO")
                    txtCorreo.Text = dt.Rows(0).Item("CORREO")
                    txtTelefono.Text = dt.Rows(0).Item("TELEFONO")
                    txtDireccion.Text = dt.Rows(0).Item("DIRECCION")
                    cboSexo.Text = dt.Rows(0).Item("SEXO")
                    cboCargo.Text = dt.Rows(0).Item("CARGO")
                    txtUsuario.Text = dt.Rows(0).Item("USUARIO")
                    txtContraseña.Text = dt.Rows(0).Item("CLAVE")
                    chkVigencia.Checked = dt.Rows(0).Item("ESTADO")
                    txtPregunta.Text = dt.Rows(0).Item("PREGUNTA")
                    txtRespuesta.Text = dt.Rows(0).Item("RESPUESTA")
                Else
                    MessageBox.Show("ID de usuario no existe",
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

    Private Sub dgvUsuarios_Click(sender As Object,
                                  e As EventArgs) Handles dgvUsuarios.Click
        txtId.Text = dgvUsuarios.SelectedRows(0).Cells(0).Value
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Public Sub limpiarControles()
        txtId.Clear()
        txtUsuario.Clear()
        txtDni.Clear()
        txtNombres.Clear()
        txtApeMaterno.Clear()
        txtApePaterno.Clear()
        txtContraseña.Clear()
        txtDireccion.Clear()
        txtCorreo.Clear()
        txtTelefono.Clear()
        cboSexo.Text = ""
        cboCargo.Text = ""
        txtPregunta.Clear()
        txtRespuesta.Clear()
        chkVigencia.Checked = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Desea salir del formulario?",
                       "MENSAJE",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub txtPregunta_TextChanged(sender As Object, e As EventArgs) Handles txtPregunta.TextChanged

    End Sub
End Class