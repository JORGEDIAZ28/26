Imports capaNegocio
Public Class frmInicioSesion
    Dim objUsuario As New clsUsuario
    Public estado As Boolean = False
    Public nomEmp As String
    Public cargo As String

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'Verificar usuario y contraseña
        Try
            If txtUsuario.TextLength > 0 And txtContraseña.TextLength > 0 Then
                If objUsuario.iniciarSesion(txtUsuario.Text, txtContraseña.Text) Then
                    nomEmp = objUsuario.obtenerNombreUsuario(txtUsuario.Text)
                    cargo = objUsuario.obtenerCargoUsuario(txtUsuario.Text)
                    MessageBox.Show("Bienvemido al Sistema: " & nomEmp, "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    estado = True
                    Me.Close()
                Else
                    MessageBox.Show("Datos incorectos, intente nuevamente!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Ingrese usuario y contraseña!", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        nomEmp = ""
        estado = False
    End Sub

    Private Sub frmInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' 1. Creamos una instancia del formulario que queremos abrir
        Dim objNuevaInterfaz As New frmCambiarContra
        objNuevaInterfaz.StartPosition = FormStartPosition.CenterParent

        ' PASO CLAVE: Le pasamos el texto del usuario que escribieron en el login
        objNuevaInterfaz.txtPregunta.Text = Me.txtUsuario.Text

        objNuevaInterfaz.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PasswordLabel_Click(sender As Object, e As EventArgs) Handles PasswordLabel.Click

    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged

    End Sub

    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs) Handles txtContraseña.TextChanged

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
End Class
