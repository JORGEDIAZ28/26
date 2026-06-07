<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpeRecepcionCompra
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNroFactura = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNroOrden = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNroRecepcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarOrden = New System.Windows.Forms.Button()
        Me.cboEstadoRecepcion = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpFabricacion = New System.Windows.Forms.DateTimePicker()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNroLote = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCantRecibir = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboProductoOrden = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvDetalleRecepcion = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvDetalleRecepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNroFactura)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNroOrden)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNroRecepcion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBuscarOrden)
        Me.GroupBox1.Controls.Add(Me.cboEstadoRecepcion)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(931, 227)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recepcion"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(451, 37)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(210, 72)
        Me.txtObservacion.TabIndex = 29
        Me.txtObservacion.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(343, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 16)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Observaciones:"
        '
        'txtNroFactura
        '
        Me.txtNroFactura.Location = New System.Drawing.Point(127, 127)
        Me.txtNroFactura.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNroFactura.Name = "txtNroFactura"
        Me.txtNroFactura.Size = New System.Drawing.Size(196, 22)
        Me.txtNroFactura.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 130)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Nro Factura:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroOrden
        '
        Me.txtNroOrden.Location = New System.Drawing.Point(127, 63)
        Me.txtNroOrden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNroOrden.Name = "txtNroOrden"
        Me.txtNroOrden.Size = New System.Drawing.Size(118, 22)
        Me.txtNroOrden.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 66)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Nro orden:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroRecepcion
        '
        Me.txtNroRecepcion.Location = New System.Drawing.Point(127, 95)
        Me.txtNroRecepcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNroRecepcion.Name = "txtNroRecepcion"
        Me.txtNroRecepcion.Size = New System.Drawing.Size(196, 22)
        Me.txtNroRecepcion.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 98)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Nro Recepcion:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscarOrden
        '
        Me.btnBuscarOrden.Location = New System.Drawing.Point(253, 39)
        Me.btnBuscarOrden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscarOrden.Name = "btnBuscarOrden"
        Me.btnBuscarOrden.Size = New System.Drawing.Size(70, 46)
        Me.btnBuscarOrden.TabIndex = 19
        Me.btnBuscarOrden.Text = "..."
        Me.btnBuscarOrden.UseVisualStyleBackColor = True
        '
        'cboEstadoRecepcion
        '
        Me.cboEstadoRecepcion.FormattingEnabled = True
        Me.cboEstadoRecepcion.Location = New System.Drawing.Point(451, 127)
        Me.cboEstadoRecepcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboEstadoRecepcion.Name = "cboEstadoRecepcion"
        Me.cboEstadoRecepcion.Size = New System.Drawing.Size(210, 24)
        Me.cboEstadoRecepcion.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(392, 130)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 16)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Estado:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(705, 42)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Vigencia:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpVencimiento
        '
        Me.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVencimiento.Location = New System.Drawing.Point(545, 71)
        Me.dtpVencimiento.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpVencimiento.MinDate = New Date(2026, 10, 1, 0, 0, 0, 0)
        Me.dtpVencimiento.Name = "dtpVencimiento"
        Me.dtpVencimiento.Size = New System.Drawing.Size(210, 22)
        Me.dtpVencimiento.TabIndex = 30
        Me.dtpVencimiento.Value = New Date(2026, 10, 1, 0, 0, 0, 0)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpFabricacion)
        Me.GroupBox2.Controls.Add(Me.dtpVencimiento)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.txtNroLote)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCantRecibir)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboProductoOrden)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(931, 177)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(810, 55)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 35
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(810, 96)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnNuevo.TabIndex = 34
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(414, 76)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 16)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Fecha vencimiento:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(420, 39)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(117, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Fecha fabricacion:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFabricacion
        '
        Me.dtpFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFabricacion.Location = New System.Drawing.Point(545, 34)
        Me.dtpFabricacion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFabricacion.MinDate = New Date(2025, 1, 1, 0, 0, 0, 0)
        Me.dtpFabricacion.Name = "dtpFabricacion"
        Me.dtpFabricacion.Size = New System.Drawing.Size(210, 22)
        Me.dtpFabricacion.TabIndex = 31
        Me.dtpFabricacion.Value = New Date(2025, 1, 1, 14, 7, 0, 0)
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(810, 127)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(84, 27)
        Me.btnAgregar.TabIndex = 27
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNroLote
        '
        Me.txtNroLote.Location = New System.Drawing.Point(135, 132)
        Me.txtNroLote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNroLote.Name = "txtNroLote"
        Me.txtNroLote.Size = New System.Drawing.Size(210, 22)
        Me.txtNroLote.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(70, 135)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 16)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Nro lote:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(135, 100)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(210, 22)
        Me.TextBox5.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 103)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 16)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Precio de compra:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantRecibir
        '
        Me.txtCantRecibir.Location = New System.Drawing.Point(135, 68)
        Me.txtCantRecibir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCantRecibir.Name = "txtCantRecibir"
        Me.txtCantRecibir.Size = New System.Drawing.Size(210, 22)
        Me.txtCantRecibir.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 71)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Cantidad:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboProductoOrden
        '
        Me.cboProductoOrden.FormattingEnabled = True
        Me.cboProductoOrden.Location = New System.Drawing.Point(135, 34)
        Me.cboProductoOrden.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboProductoOrden.Name = "cboProductoOrden"
        Me.cboProductoOrden.Size = New System.Drawing.Size(210, 24)
        Me.cboProductoOrden.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 37)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Producto orden:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDetalleRecepcion
        '
        Me.dgvDetalleRecepcion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleRecepcion.Location = New System.Drawing.Point(13, 430)
        Me.dgvDetalleRecepcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvDetalleRecepcion.Name = "dgvDetalleRecepcion"
        Me.dgvDetalleRecepcion.RowHeadersWidth = 51
        Me.dgvDetalleRecepcion.RowTemplate.Height = 24
        Me.dgvDetalleRecepcion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleRecepcion.Size = New System.Drawing.Size(930, 192)
        Me.dgvDetalleRecepcion.TabIndex = 10
        '
        'frmOpeRecepcionCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 632)
        Me.Controls.Add(Me.dgvDetalleRecepcion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmOpeRecepcionCompra"
        Me.Text = "frmOpeRecepcionCompra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvDetalleRecepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvDetalleRecepcion As DataGridView
    Friend WithEvents cboEstadoRecepcion As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnBuscarOrden As Button
    Friend WithEvents txtNroRecepcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNroOrden As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNroFactura As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtObservacion As RichTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboProductoOrden As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCantRecibir As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtNroLote As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dtpVencimiento As DateTimePicker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents dtpFabricacion As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnSalir As Button
End Class
