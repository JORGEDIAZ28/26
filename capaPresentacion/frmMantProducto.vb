Imports capaNegocio

Public Class frmMantProducto
    Dim objProducto As New clsProducto

    '=========================================
    ' NUEVO / GUARDAR
    '=========================================
    Private Sub btnNuevo_Click(sender As Object,
                           e As EventArgs) Handles btnNuevo.Click

        Try

            If btnNuevo.Text = "Nuevo" Then

                btnNuevo.Text = "Guardar"
                txtId.Text = objProducto.obtenerIDProducto()

            Else

                btnNuevo.Text = "Nuevo"

                ' El orden aquí coincide con los parámetros de la clase
                objProducto.guardarProducto(
                txtNombre.Text,
                txtDescripcion.Text,
                chkVigencia.Checked)

                dgvProducto.DataSource = objProducto.listarProductos()
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
    Private Sub frmMantProducto_Load(sender As Object,
                                  e As EventArgs) Handles MyBase.Load

        Try

            dgvProducto.AllowUserToAddRows = False
            dgvProducto.DataSource = objProducto.listarProductos()

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

                objProducto.modificarProducto(
                CInt(txtId.Text),
                txtNombre.Text,
                txtDescripcion.Text,
                chkVigencia.Checked)

                dgvProducto.DataSource = objProducto.listarProductos()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de producto a modificar",
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

                objProducto.eliminarProducto(CInt(txtId.Text))
                dgvProducto.DataSource = objProducto.listarProductos()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de producto a eliminar",
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

                objProducto.darBajaProducto(CInt(txtId.Text))
                dgvProducto.DataSource = objProducto.listarProductos()
                limpiarControles()

            Else

                MessageBox.Show("Ingrese ID de producto",
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

                dt = objProducto.buscarProducto(CInt(txtId.Text))

                If dt.Rows.Count > 0 Then

                    ' Extraemos los datos usando exactamente el nombre de las columnas SQL
                    txtNombre.Text = dt.Rows(0).Item("NOMBRE").ToString()
                    chkVigencia.Checked = CBool(dt.Rows(0).Item("ESTADO"))
                    txtDescripcion.Text = dt.Rows(0).Item("DESCRIPCION").ToString()

                Else

                    MessageBox.Show("ID de producto no existe",
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
    Private Sub dgvProducto_Click(sender As Object,
                               e As EventArgs) Handles dgvProducto.Click

        Try
            If dgvProducto.SelectedRows.Count > 0 Then
                txtId.Text = dgvProducto.SelectedRows(0).Cells(0).Value.ToString()
                btnBuscar_Click(sender, e)
            End If
        Catch ex As Exception
            ' Evita que el programa se caiga si hacen clic en un espacio vacío del grid
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

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub chkVigencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkVigencia.CheckedChanged

    End Sub

    Private Sub dgvProducto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellContentClick

    End Sub
End Class