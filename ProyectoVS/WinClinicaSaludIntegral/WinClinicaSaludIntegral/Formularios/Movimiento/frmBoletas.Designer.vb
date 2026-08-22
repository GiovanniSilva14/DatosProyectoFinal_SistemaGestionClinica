<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoletas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoletas))
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtBoletaTotal = New System.Windows.Forms.TextBox()
        Me.txtBoletaIGV = New System.Windows.Forms.TextBox()
        Me.txtBoletaSubtotal = New System.Windows.Forms.TextBox()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtEmpleadosCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPacientesCodigo = New System.Windows.Forms.TextBox()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBoletasRegistradas = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBoletaCodigo = New System.Windows.Forms.TextBox()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpBoletaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(553, 222)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminar.TabIndex = 29
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'ListaImagenesBotones
        '
        Me.ListaImagenesBotones.ImageStream = CType(resources.GetObject("ListaImagenesBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenesBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenesBotones.Images.SetKeyName(0, "IconoEliminar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(1, "IconoAgregar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(2, "IconoCancelar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(3, "IconoCerrar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(4, "IconoEditar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(5, "IconoEliminados.gif")
        '
        'txtBoletaTotal
        '
        Me.txtBoletaTotal.Location = New System.Drawing.Point(185, 219)
        Me.txtBoletaTotal.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoletaTotal.MaxLength = 12
        Me.txtBoletaTotal.Name = "txtBoletaTotal"
        Me.txtBoletaTotal.Size = New System.Drawing.Size(117, 27)
        Me.txtBoletaTotal.TabIndex = 18
        '
        'txtBoletaIGV
        '
        Me.txtBoletaIGV.Location = New System.Drawing.Point(183, 185)
        Me.txtBoletaIGV.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoletaIGV.MaxLength = 12
        Me.txtBoletaIGV.Name = "txtBoletaIGV"
        Me.txtBoletaIGV.Size = New System.Drawing.Size(118, 27)
        Me.txtBoletaIGV.TabIndex = 17
        '
        'txtBoletaSubtotal
        '
        Me.txtBoletaSubtotal.Location = New System.Drawing.Point(184, 151)
        Me.txtBoletaSubtotal.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoletaSubtotal.MaxLength = 12
        Me.txtBoletaSubtotal.Name = "txtBoletaSubtotal"
        Me.txtBoletaSubtotal.Size = New System.Drawing.Size(118, 27)
        Me.txtBoletaSubtotal.TabIndex = 16
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(553, 78)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(179, 42)
        Me.cmdAgregar.TabIndex = 27
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 226)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 158)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Subtotal"
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(553, 150)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEditar.TabIndex = 28
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 192)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "IGV"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "IGV"
        Me.ColumnHeader6.Width = 85
        '
        'txtEmpleadosCodigo
        '
        Me.txtEmpleadosCodigo.Location = New System.Drawing.Point(184, 83)
        Me.txtEmpleadosCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEmpleadosCodigo.MaxLength = 7
        Me.txtEmpleadosCodigo.Name = "txtEmpleadosCodigo"
        Me.txtEmpleadosCodigo.Size = New System.Drawing.Size(117, 27)
        Me.txtEmpleadosCodigo.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Fecha"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 90)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Código Empleado"
        '
        'txtPacientesCodigo
        '
        Me.txtPacientesCodigo.Location = New System.Drawing.Point(184, 49)
        Me.txtPacientesCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesCodigo.MaxLength = 7
        Me.txtPacientesCodigo.Name = "txtPacientesCodigo"
        Me.txtPacientesCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtPacientesCodigo.TabIndex = 5
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Total"
        Me.ColumnHeader7.Width = 121
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(762, 78)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCancelar.TabIndex = 30
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código "
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(762, 222)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminados.TabIndex = 32
        Me.cmdEliminados.Text = "Eliminados"
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Código Paciente"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fecha"
        Me.ColumnHeader4.Width = 99
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Código Empleado"
        Me.ColumnHeader3.Width = 254
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Código Paciente"
        Me.ColumnHeader2.Width = 240
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 132
        '
        'lvBoletasRegistradas
        '
        Me.lvBoletasRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBoletasRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvBoletasRegistradas.FullRowSelect = True
        Me.lvBoletasRegistradas.GridLines = True
        Me.lvBoletasRegistradas.HideSelection = False
        Me.lvBoletasRegistradas.Location = New System.Drawing.Point(31, 375)
        Me.lvBoletasRegistradas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvBoletasRegistradas.MinimumSize = New System.Drawing.Size(920, 205)
        Me.lvBoletasRegistradas.Name = "lvBoletasRegistradas"
        Me.lvBoletasRegistradas.Size = New System.Drawing.Size(920, 205)
        Me.lvBoletasRegistradas.TabIndex = 26
        Me.lvBoletasRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvBoletasRegistradas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Subtotal"
        Me.ColumnHeader5.Width = 140
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(26, 346)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(180, 20)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Boletas Registradas"
        '
        'txtBoletaCodigo
        '
        Me.txtBoletaCodigo.Location = New System.Drawing.Point(184, 15)
        Me.txtBoletaCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtBoletaCodigo.MaxLength = 7
        Me.txtBoletaCodigo.Name = "txtBoletaCodigo"
        Me.txtBoletaCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtBoletaCodigo.TabIndex = 3
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(762, 150)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCerrar.TabIndex = 31
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpBoletaFecha)
        Me.GroupBox1.Controls.Add(Me.txtBoletaTotal)
        Me.GroupBox1.Controls.Add(Me.txtBoletaIGV)
        Me.GroupBox1.Controls.Add(Me.txtBoletaSubtotal)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtEmpleadosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBoletaCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 75)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(478, 255)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Boleta"
        '
        'dtpBoletaFecha
        '
        Me.dtpBoletaFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBoletaFecha.Location = New System.Drawing.Point(184, 117)
        Me.dtpBoletaFecha.Name = "dtpBoletaFecha"
        Me.dtpBoletaFecha.Size = New System.Drawing.Size(176, 27)
        Me.dtpBoletaFecha.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Boletas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmBoletas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.lvBoletasRegistradas)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmBoletas"
        Me.Text = "Boletas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdEliminar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txtBoletaTotal As TextBox
    Friend WithEvents txtBoletaIGV As TextBox
    Friend WithEvents txtBoletaSubtotal As TextBox
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdEditar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents txtEmpleadosCodigo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPacientesCodigo As TextBox
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lvBoletasRegistradas As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents txtBoletaCodigo As TextBox
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpBoletaFecha As DateTimePicker
End Class
