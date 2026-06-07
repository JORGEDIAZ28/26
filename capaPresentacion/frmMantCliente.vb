Imports capaNegocio

Public Class frmMantCliente
    Dim objCliente As New clsCliente

    '=========================================
    ' NUEVO / GUARDAR
    '=========================================

    Private Sub btnNuevo_Click(sender As Object,
                               e As EventArgs) Handles btnNuevo.Click

        Try

            If btnNuevo.Text = "Nuevo" Then

                btnNuevo.Text = "Guardar"

                txtId.Text = objCliente.obtenerIDCliente

            Else

                btnNuevo.Text = "Nuevo"

                objCliente.guardarCliente(
                    cboTipoDocumento.Text,
                    txtNroDocumento.Text,
                    cboTipoCliente.Text,
                    txtNombres.Text,
                    txtApePaterno.Text,
                    txtApeMaterno.Text,
                    txtRazonSocial.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text)

                dgvClientes.DataSource = objCliente.listarClientes

                limpiarControles()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                            "MENSAJE",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub cboTipoCliente_SelectedIndexChanged(sender As Object,
                                                 e As EventArgs) _
                                                 Handles cboTipoCliente.SelectedIndexChanged

        cboTipoDocumento.Items.Clear()

        If cboTipoCliente.Text = "Natural" Then

            'Habilitar controles
            txtNombres.Enabled = True
            txtApePaterno.Enabled = True
            txtApeMaterno.Enabled = True
            cboSexo.Enabled = True

            txtRazonSocial.Enabled = False
            txtRazonSocial.Clear()

            'Tipos de documento
            cboTipoDocumento.Items.Add("DNI")
            cboTipoDocumento.Items.Add("CE")
            cboTipoDocumento.Items.Add("Pasaporte")

        ElseIf cboTipoCliente.Text = "Juridico" Then

            'Habilitar controles
            txtRazonSocial.Enabled = True

            txtNombres.Enabled = False
            txtApePaterno.Enabled = False
            txtApeMaterno.Enabled = False
            cboSexo.Enabled = False

            txtNombres.Clear()
            txtApePaterno.Clear()
            txtApeMaterno.Clear()
            cboSexo.Text = ""

            'Tipos de documento
            cboTipoDocumento.Items.Add("RUC")

        End If

        cboTipoDocumento.SelectedIndex = 0

    End Sub

    '=========================================
    ' LOAD
    '=========================================

    Private Sub frmMantCliente_Load(sender As Object,
                                    e As EventArgs) Handles MyBase.Load

        Try

            dgvClientes.AllowUserToAddRows = False

            dgvClientes.DataSource = objCliente.listarClientes

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

                objCliente.modificarCliente(
                    CInt(txtId.Text),
                    cboTipoDocumento.Text,
                    txtNroDocumento.Text,
                    cboTipoCliente.Text,
                    txtNombres.Text,
                    txtApePaterno.Text,
                    txtApeMaterno.Text,
                    txtRazonSocial.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text)

                dgvClientes.DataSource = objCliente.listarClientes

                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de cliente",
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

                objCliente.eliminarCliente(CInt(txtId.Text))

                dgvClientes.DataSource = objCliente.listarClientes

                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de cliente",
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

                dt = objCliente.buscarClientes(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then

                    cboTipoDocumento.Text = dt.Rows(0).Item("TIPODOC")
                    txtNroDocumento.Text = dt.Rows(0).Item("NRODOC")
                    cboTipoCliente.Text = dt.Rows(0).Item("TIPO_CLIENTE")

                    txtNombres.Text = dt.Rows(0).Item("NOMBRES")
                    txtApePaterno.Text = dt.Rows(0).Item("APELLIDOPATERNO")
                    txtApeMaterno.Text = dt.Rows(0).Item("APELLIDOMATERNO")

                    txtRazonSocial.Text = dt.Rows(0).Item("RAZONSOCIAL")

                    txtDireccion.Text = dt.Rows(0).Item("DIRECCION")
                    txtTelefono.Text = dt.Rows(0).Item("TELEFONO")
                    txtCorreo.Text = dt.Rows(0).Item("CORREO")

                Else

                    MessageBox.Show("ID de cliente no existe",
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

    Private Sub dgvClientes_Click(sender As Object,
                                  e As EventArgs) Handles dgvClientes.Click

        txtId.Text = dgvClientes.SelectedRows(0).Cells(0).Value

        btnBuscar_Click(sender, e)

    End Sub

    '=========================================
    ' LIMPIAR
    '=========================================

    Public Sub limpiarControles()

        txtId.Clear()

        cboTipoDocumento.Text = ""
        txtNroDocumento.Clear()

        cboTipoCliente.Text = ""

        txtNombres.Clear()
        txtApePaterno.Clear()
        txtApeMaterno.Clear()

        txtRazonSocial.Clear()

        txtDireccion.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()

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

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub
End Class