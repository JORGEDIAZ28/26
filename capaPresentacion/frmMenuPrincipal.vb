Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports capaNegocio

Public Class frmMenuPrincipal

    Private Sub frmmenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFecha.Text = DateString
        lblHora.Text = TimeString
        tmrTiempo.Enabled = True
        habilitarMenu(False)
    End Sub
    Private Sub habilitarMenu(est As Boolean)
        menuMantenimiento.Enabled = est
        menuOperaciones.Enabled = est
        menuInicio.Enabled = Not est
        CerrarSesionToolStripMenuItem.Enabled = est

        ' --- Lógica de Seguridad: Control de derechos de acceso [cite: 1323, 1329] ---
        ' Solo si hay una sesión activa (est = True) y el Principal es "admin" 
        If est AndAlso lblCargo.Text = "Administrador" Then
            UsuarioToolStripMenuItem.Enabled = True
        Else
            ' Si no es admin o no hay sesión, se bloquea el acceso al objeto [cite: 1321, 1322]
            UsuarioToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub tmrTiempo_Tick(sender As Object, e As EventArgs) Handles tmrTiempo.Tick
        lblHora.Text = TimeString
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(sender As Object, e As EventArgs) Handles SToolStripSalir.Click
        If MessageBox.Show("¿Desea salir del sistema?",
                       "MENSAJE",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub IniciarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuInicio.Click
        Dim objFrmInicio As New frmInicioSesion
        objFrmInicio.ShowDialog()
        If objFrmInicio.estado Then
            lblUsuario.Text = objFrmInicio.txtUsuario.Text
            lblEmpleado.Text = objFrmInicio.nomEmp
            lblCargo.Text = objFrmInicio.cargo
        End If
        habilitarMenu(objFrmInicio.estado)
    End Sub

    Private Sub lblEmpleado_Click(sender As Object, e As EventArgs) Handles lblEmpleado.Click

    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        Dim objManEmpleado As New frmMantUsuario
        objManEmpleado.MdiParent = Me
        objManEmpleado.StartPosition = 1
        objManEmpleado.Show()

    End Sub

    Private Sub MedioDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedioDePagoToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantMedioPago
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        If MessageBox.Show("¿Está seguro que desea cerrar la sesión actual?",
                       "Cerrar Sesión",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

            ' 2. Cerrar todos los formularios hijos (MDI Children)
            ' Esto es clave para la seguridad de los objetos en un sistema distribuido [cite: 1321, 1322]
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next

            ' 3. Limpiar las etiquetas de información del usuario
            lblUsuario.Text = "---"
            lblEmpleado.Text = "---"
            lblCargo.Text = "---"

            ' 4. Deshabilitar los menús de operaciones y mantenimiento
            ' Usamos el método que ya creaste para volver al estado inicial
            habilitarMenu(False)

            ' 5. Opcional: Mostrar mensaje de confirmación o volver a abrir el login
            MessageBox.Show("Sesión cerrada correctamente.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub InicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InicioToolStripMenuItem.Click

    End Sub

    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantCliente
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub VentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaToolStripMenuItem.Click
        Dim objManMedioPago As New frmOpeVenta
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub ProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantProducto
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub LaboratorioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaboratorioToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantLaboratorio
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub MarcaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcaToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantMarca
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Dim objManMedioPago As New frmDevoluciones
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub DetalleProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleProductoToolStripMenuItem.Click
        Dim objManMedioPago As New frmMantDetalleProducto
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub

    Private Sub RecepcionOrdenCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecepcionOrdenCompraToolStripMenuItem.Click
        Dim objManMedioPago As New frmOpeRecepcionCompra
        objManMedioPago.MdiParent = Me
        objManMedioPago.StartPosition = 1
        objManMedioPago.Show()
    End Sub
End Class
