<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSesionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SToolStripSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuMantenimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedioDePagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaboratorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevolucionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEmpleado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCargo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrTiempo = New System.Windows.Forms.Timer(Me.components)
        Me.RecepcionOrdenCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem, Me.menuMantenimiento, Me.menuOperaciones})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip.Size = New System.Drawing.Size(1123, 28)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuInicio, Me.CerrarSesionToolStripMenuItem, Me.SToolStripSalir})
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(59, 24)
        Me.InicioToolStripMenuItem.Text = "Inicio"
        '
        'menuInicio
        '
        Me.menuInicio.Image = CType(resources.GetObject("menuInicio.Image"), System.Drawing.Image)
        Me.menuInicio.Name = "menuInicio"
        Me.menuInicio.Size = New System.Drawing.Size(177, 26)
        Me.menuInicio.Text = "Iniciar sesion"
        '
        'CerrarSesionToolStripMenuItem
        '
        Me.CerrarSesionToolStripMenuItem.Image = CType(resources.GetObject("CerrarSesionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CerrarSesionToolStripMenuItem.Name = "CerrarSesionToolStripMenuItem"
        Me.CerrarSesionToolStripMenuItem.Size = New System.Drawing.Size(177, 26)
        Me.CerrarSesionToolStripMenuItem.Text = "Cerrar sesion"
        '
        'SToolStripSalir
        '
        Me.SToolStripSalir.Image = CType(resources.GetObject("SToolStripSalir.Image"), System.Drawing.Image)
        Me.SToolStripSalir.Name = "SToolStripSalir"
        Me.SToolStripSalir.Size = New System.Drawing.Size(177, 26)
        Me.SToolStripSalir.Text = "Salir"
        '
        'menuMantenimiento
        '
        Me.menuMantenimiento.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioToolStripMenuItem, Me.MedioDePagoToolStripMenuItem, Me.ClienteToolStripMenuItem, Me.ProductoToolStripMenuItem, Me.LaboratorioToolStripMenuItem, Me.MarcaToolStripMenuItem, Me.DetalleProductoToolStripMenuItem})
        Me.menuMantenimiento.Name = "menuMantenimiento"
        Me.menuMantenimiento.Size = New System.Drawing.Size(130, 24)
        Me.menuMantenimiento.Text = "Mantenimientos"
        '
        'UsuarioToolStripMenuItem
        '
        Me.UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem"
        Me.UsuarioToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.UsuarioToolStripMenuItem.Text = "Usuario"
        '
        'MedioDePagoToolStripMenuItem
        '
        Me.MedioDePagoToolStripMenuItem.Name = "MedioDePagoToolStripMenuItem"
        Me.MedioDePagoToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.MedioDePagoToolStripMenuItem.Text = "Medio de pago"
        '
        'ClienteToolStripMenuItem
        '
        Me.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem"
        Me.ClienteToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.ClienteToolStripMenuItem.Text = "Cliente"
        '
        'ProductoToolStripMenuItem
        '
        Me.ProductoToolStripMenuItem.Name = "ProductoToolStripMenuItem"
        Me.ProductoToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.ProductoToolStripMenuItem.Text = "Producto"
        '
        'LaboratorioToolStripMenuItem
        '
        Me.LaboratorioToolStripMenuItem.Name = "LaboratorioToolStripMenuItem"
        Me.LaboratorioToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.LaboratorioToolStripMenuItem.Text = "Laboratorio"
        '
        'MarcaToolStripMenuItem
        '
        Me.MarcaToolStripMenuItem.Name = "MarcaToolStripMenuItem"
        Me.MarcaToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.MarcaToolStripMenuItem.Text = "Marca"
        '
        'DetalleProductoToolStripMenuItem
        '
        Me.DetalleProductoToolStripMenuItem.Name = "DetalleProductoToolStripMenuItem"
        Me.DetalleProductoToolStripMenuItem.Size = New System.Drawing.Size(205, 26)
        Me.DetalleProductoToolStripMenuItem.Text = "Detalle producto"
        '
        'menuOperaciones
        '
        Me.menuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentaToolStripMenuItem, Me.DevolucionesToolStripMenuItem, Me.RecepcionOrdenCompraToolStripMenuItem})
        Me.menuOperaciones.Name = "menuOperaciones"
        Me.menuOperaciones.Size = New System.Drawing.Size(106, 24)
        Me.menuOperaciones.Text = "Operaciones"
        '
        'VentaToolStripMenuItem
        '
        Me.VentaToolStripMenuItem.Name = "VentaToolStripMenuItem"
        Me.VentaToolStripMenuItem.Size = New System.Drawing.Size(259, 26)
        Me.VentaToolStripMenuItem.Text = "Venta"
        '
        'DevolucionesToolStripMenuItem
        '
        Me.DevolucionesToolStripMenuItem.Name = "DevolucionesToolStripMenuItem"
        Me.DevolucionesToolStripMenuItem.Size = New System.Drawing.Size(259, 26)
        Me.DevolucionesToolStripMenuItem.Text = "Cambios/Devoluciones"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1123, 25)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.lblUsuario, Me.ToolStripStatusLabel2, Me.lblEmpleado, Me.ToolStripStatusLabel1, Me.lblCargo, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.lblFecha, Me.ToolStripStatusLabel7, Me.lblHora})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(1123, 26)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(62, 20)
        Me.ToolStripStatusLabel.Text = "Usuario:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = False
        Me.lblUsuario.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(120, 20)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(80, 20)
        Me.ToolStripStatusLabel2.Text = "Empleado:"
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = False
        Me.lblEmpleado.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(250, 20)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(52, 20)
        Me.ToolStripStatusLabel1.Text = "Cargo:"
        '
        'lblCargo
        '
        Me.lblCargo.AutoSize = False
        Me.lblCargo.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblCargo.Name = "lblCargo"
        Me.lblCargo.Size = New System.Drawing.Size(153, 20)
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.Color.White
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(51, 20)
        Me.ToolStripStatusLabel4.Spring = True
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(50, 20)
        Me.ToolStripStatusLabel5.Text = "Fecha:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = False
        Me.lblFecha.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(120, 20)
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(45, 20)
        Me.ToolStripStatusLabel7.Text = "Hora:"
        '
        'lblHora
        '
        Me.lblHora.AutoSize = False
        Me.lblHora.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(120, 20)
        '
        'tmrTiempo
        '
        Me.tmrTiempo.Interval = 1000
        '
        'RecepcionOrdenCompraToolStripMenuItem
        '
        Me.RecepcionOrdenCompraToolStripMenuItem.Name = "RecepcionOrdenCompraToolStripMenuItem"
        Me.RecepcionOrdenCompraToolStripMenuItem.Size = New System.Drawing.Size(259, 26)
        Me.RecepcionOrdenCompraToolStripMenuItem.Text = "Recepcion orden compra"
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1123, 558)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMenuPrincipal"
        Me.Text = "MENU PRINCIPAL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents InicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSesionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuMantenimiento As ToolStripMenuItem
    Friend WithEvents UsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuOperaciones As ToolStripMenuItem
    Friend WithEvents VentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SToolStripSalir As ToolStripMenuItem
    Friend WithEvents lblUsuario As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lblEmpleado As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents lblFecha As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents lblHora As ToolStripStatusLabel
    Friend WithEvents tmrTiempo As Timer
    Friend WithEvents menuInicio As ToolStripMenuItem
    Friend WithEvents MedioDePagoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblCargo As ToolStripStatusLabel
    Friend WithEvents ProductoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LaboratorioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetalleProductoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecepcionOrdenCompraToolStripMenuItem As ToolStripMenuItem
End Class
