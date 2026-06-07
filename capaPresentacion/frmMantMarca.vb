Imports capaNegocio

Public Class frmMantMarca
    Dim objMarca As New clsMarca
    Dim objLaboratorio As New clsLaboratorio


    Private Sub llenarComboLaboratorios()
        Try
            ' Asignamos los datos al ComboBox
            cboLaboratorio.DataSource = objLaboratorio.listarLaboratorios()

            ' DisplayMember: Es la columna que verá el usuario en la pantalla
            cboLaboratorio.DisplayMember = "NOMBRELABORATORIO"

            ' ValueMember: Es la columna oculta con el ID que se guardará en la base de datos
            cboLaboratorio.ValueMember = "IDLABORATORIO"

            ' Lo dejamos en blanco por defecto
            cboLaboratorio.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar los laboratorios: " & ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=========================================
    ' NUEVO / GUARDAR
    '=========================================
    Private Sub btnNuevo_Click(sender As Object,
                           e As EventArgs) Handles btnNuevo.Click

        Try

            If btnNuevo.Text = "Nuevo" Then

                btnNuevo.Text = "Guardar"
                txtId.Text = objMarca.obtenerIDMarca()

            Else

                btnNuevo.Text = "Nuevo"

                objMarca.guardarMarca(
                txtNombre.Text,
                txtDescripcion.Text,
                chkVigencia.Checked,
                CInt(cboLaboratorio.SelectedValue))

                dgvMarca.DataSource = objMarca.listarMarcas()
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
    Private Sub frmMantMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Llenamos el combo primero
            llenarComboLaboratorios()

            dgvMarca.AllowUserToAddRows = False
            dgvMarca.DataSource = objMarca.listarMarcas()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================
    Private Sub btnModificar_Click(sender As Object,
                               e As EventArgs) Handles btnModificar.Click

        Try

            If txtId.Text.Length > 0 Then

                objMarca.modificarMarca(
                CInt(txtId.Text),
                txtNombre.Text,
                txtDescripcion.Text,
                chkVigencia.Checked,
                CInt(cboLaboratorio.SelectedValue))

                dgvMarca.DataSource = objMarca.listarMarcas()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de marca a modificar",
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

                objMarca.eliminarMarca(CInt(txtId.Text))
                dgvMarca.DataSource = objMarca.listarMarcas()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de marca a eliminar",
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

                objMarca.darBajaMarca(CInt(txtId.Text))
                dgvMarca.DataSource = objMarca.listarMarcas()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de marca",
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

                dt = objMarca.buscarMarca(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then

                    txtNombre.Text = dt.Rows(0).Item("NOMBREMARCA").ToString()
                    txtDescripcion.Text = dt.Rows(0).Item("DESCRIPCION").ToString()
                    chkVigencia.Checked = CBool(dt.Rows(0).Item("VIGENCIA"))
                    cboLaboratorio.SelectedValue = dt.Rows(0).Item("IDLABORATORIO")

                Else

                    MessageBox.Show("ID de marca no existe",
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
    Private Sub dgvMarca_Click(sender As Object,
                               e As EventArgs) Handles dgvMarca.Click

        Try
            If dgvMarca.SelectedRows.Count > 0 Then
                txtId.Text = dgvMarca.SelectedRows(0).Cells(0).Value.ToString()
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
        txtDescripcion.Clear()
        chkVigencia.Checked = False
        cboLaboratorio.Text = ""

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