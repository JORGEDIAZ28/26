Imports capaNegocio

Public Class frmCambiarContra
    Dim objUsuario As New clsUsuario
    Dim dtUsuario As DataTable

    Private Sub frmCambiarContra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Bloqueamos todo lo que requiere validación previa
        habilitarCamposContra(False)
        txtPregunta.Enabled = False
        CargarPreguntaSeguridad()
    End Sub

    Private Sub habilitarCamposContra(estado As Boolean)
        txtContraseña.Enabled = estado
        txtContraseña2.Enabled = estado
        Button1.Enabled = estado
        Button2.Enabled = estado
        btnCancelar.Enabled = estado
    End Sub

    Private Sub CargarPreguntaSeguridad()
        Try
            ' 1. Validamos que tengamos un usuario para buscar en la red [cite: 108, 1585]
            If txtPregunta.TextLength > 0 Then
                ' Buscamos en la base de datos distribuida [cite: 1545, 1546]
                dtUsuario = objUsuario.buscarPorLogin(txtPregunta.Text)

                If dtUsuario.Rows.Count > 0 Then
                    ' 2. IMPORTANTE: No borres el usuario, pon la pregunta en otro campo
                    ' Según tu captura, el cuadro de arriba es para la PREGUNTA
                    txtPregunta.Text = dtUsuario.Rows(0).Item("PREGUNTA").ToString()
                Else
                    txtPregunta.Text = "Pregunta no encontrada"
                End If
            End If
        Catch ex As Exception
            ' Manejo de fallos en el canal de comunicación [cite: 1594]
            MessageBox.Show("Error al conectar con el servidor: " & ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If dtUsuario IsNot Nothing AndAlso dtUsuario.Rows.Count > 0 Then
            Dim respuestaCorrecta As String = dtUsuario.Rows(0).Item("RESPUESTA").ToString().Trim().ToLower()
            Dim respuestaIngresada As String = TextBox1.Text.Trim().ToLower()

            If respuestaIngresada = respuestaCorrecta Then
                MessageBox.Show("Respuesta correcta. Proceda a cambiar su contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Habilitamos los campos para la nueva contraseña
                habilitarCamposContra(True)

                ' NUEVO: Deshabilitamos el campo de respuesta y el propio botón de validar
                ' para indicar que este paso ya fue completado con éxito
                TextBox1.Enabled = False
                btnAceptar.Enabled = False
            Else
                MessageBox.Show("Respuesta incorrecta. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                habilitarCamposContra(False)
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtContraseña.UseSystemPasswordChar = True Or txtContraseña.PasswordChar <> ControlChars.NullChar Then
            ' DESBLOQUEAR: Quitamos ambas máscaras para ver el texto real
            txtContraseña.UseSystemPasswordChar = False
            txtContraseña.PasswordChar = ControlChars.NullChar
        Else
            ' BLOQUEAR: Volvemos a activar el estilo de contraseña del sistema
            txtContraseña.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtContraseña2.UseSystemPasswordChar = True Or txtContraseña2.PasswordChar <> ControlChars.NullChar Then
            ' DESBLOQUEAR: Quitamos ambas máscaras para ver el texto real
            txtContraseña2.UseSystemPasswordChar = False
            txtContraseña2.PasswordChar = ControlChars.NullChar
        Else
            ' BLOQUEAR: Volvemos a activar el estilo de contraseña del sistema
            txtContraseña2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtPregunta.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña.TextChanged

    End Sub

    Private Sub txtContraseña2_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña2.TextChanged

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            ' 1. Validación de coincidencia en el cliente para ahorrar tráfico de red 
            If txtContraseña.Text = txtContraseña2.Text And txtContraseña.TextLength > 0 Then
                Dim id As Integer = CInt(dtUsuario.Rows(0).Item("IDUSUARIO"))

                ' 2. Invocamos el método modificar de tu clase clsUsuario (Capa de Negocio) [cite: 571, 727]
                objUsuario.modificarUsuario(id,
                dtUsuario.Rows(0).Item("DNI"), dtUsuario.Rows(0).Item("NOMBRE"),
                dtUsuario.Rows(0).Item("APELLIDOPATERNO"), dtUsuario.Rows(0).Item("APELLIDOMATERNO"),
                dtUsuario.Rows(0).Item("FECHANACIMIENTO"), dtUsuario.Rows(0).Item("CORREO"),
                dtUsuario.Rows(0).Item("TELEFONO"), dtUsuario.Rows(0).Item("DIRECCION"),
                dtUsuario.Rows(0).Item("SEXO"), dtUsuario.Rows(0).Item("CARGO"),
                dtUsuario.Rows(0).Item("USUARIO"), txtContraseña.Text, True,
                dtUsuario.Rows(0).Item("PREGUNTA"), dtUsuario.Rows(0).Item("RESPUESTA"))

                MessageBox.Show("Contraseña actualizada con éxito en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 3. Solo cerramos si la operación en la base de datos fue exitosa [cite: 1564, 1581]
                Me.Close()
            Else
                ' Si las claves no coinciden, avisamos y salimos del sub para NO cerrar la pantalla
                MessageBox.Show("Las contraseñas no coinciden o están vacías.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' Limpiamos solo la confirmación para que el usuario reintente
                txtContraseña2.Clear()
                txtContraseña2.Focus()

                Exit Sub ' <--- ESTO ES LO QUE FALTA: Detiene el proceso aquí
            End If
        Catch ex As Exception
            ' Manejo de fallos en el canal de comunicación o el servidor [cite: 1368, 1594]
            MessageBox.Show("Error al guardar en el servidor: " & ex.Message)
        End Try
    End Sub
End Class