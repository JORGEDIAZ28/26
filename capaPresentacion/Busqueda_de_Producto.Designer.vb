<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Busqueda_de_Producto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Busqueda_de_Producto))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxLaboratorio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxPresentacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxMarca = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.ComboBoxProducto = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tblProducto = New System.Windows.Forms.DataGridView()
        Me.GroupBox4.SuspendLayout()
        CType(Me.tblProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GroupBox4.Controls.Add(Me.tblProducto)
        Me.GroupBox4.Controls.Add(Me.ComboBoxLaboratorio)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.ComboBoxPresentacion)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.ComboBoxMarca)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.ComboBoxProducto)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 11)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(831, 597)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "BUSQUEDA"
        '
        'ComboBoxLaboratorio
        '
        Me.ComboBoxLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxLaboratorio.FormattingEnabled = True
        Me.ComboBoxLaboratorio.Location = New System.Drawing.Point(551, 88)
        Me.ComboBoxLaboratorio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxLaboratorio.Name = "ComboBoxLaboratorio"
        Me.ComboBoxLaboratorio.Size = New System.Drawing.Size(245, 24)
        Me.ComboBoxLaboratorio.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(434, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Laboratorio:"
        '
        'ComboBoxPresentacion
        '
        Me.ComboBoxPresentacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPresentacion.FormattingEnabled = True
        Me.ComboBoxPresentacion.Location = New System.Drawing.Point(551, 44)
        Me.ComboBoxPresentacion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxPresentacion.Name = "ComboBoxPresentacion"
        Me.ComboBoxPresentacion.Size = New System.Drawing.Size(245, 24)
        Me.ComboBoxPresentacion.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(421, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Presentación:"
        '
        'ComboBoxMarca
        '
        Me.ComboBoxMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxMarca.FormattingEnabled = True
        Me.ComboBoxMarca.Location = New System.Drawing.Point(136, 88)
        Me.ComboBoxMarca.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxMarca.Name = "ComboBoxMarca"
        Me.ComboBoxMarca.Size = New System.Drawing.Size(245, 24)
        Me.ComboBoxMarca.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Marca:"
        '
        'Button7
        '
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(488, -414)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(64, 61)
        Me.Button7.TabIndex = 3
        Me.Button7.UseVisualStyleBackColor = True
        '
        'ComboBoxProducto
        '
        Me.ComboBoxProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxProducto.FormattingEnabled = True
        Me.ComboBoxProducto.Location = New System.Drawing.Point(136, 44)
        Me.ComboBoxProducto.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxProducto.Name = "ComboBoxProducto"
        Me.ComboBoxProducto.Size = New System.Drawing.Size(245, 24)
        Me.ComboBoxProducto.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Producto:"
        '
        'tblProducto
        '
        Me.tblProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblProducto.Location = New System.Drawing.Point(23, 133)
        Me.tblProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tblProducto.Name = "tblProducto"
        Me.tblProducto.RowHeadersWidth = 51
        Me.tblProducto.RowTemplate.Height = 24
        Me.tblProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.tblProducto.Size = New System.Drawing.Size(773, 447)
        Me.tblProducto.TabIndex = 15
        '
        'Busqueda_de_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 619)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "Busqueda_de_Producto"
        Me.Text = "Busqueda de Producto"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.tblProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents ComboBoxProducto As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxLaboratorio As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxPresentacion As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBoxMarca As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tblProducto As DataGridView
End Class
