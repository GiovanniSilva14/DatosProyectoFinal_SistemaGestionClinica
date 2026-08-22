<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicos))
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtConsultoriosCodigo = New System.Windows.Forms.TextBox()
        Me.txtEspecialidadesCodigo = New System.Windows.Forms.TextBox()
        Me.txtMedicosCorreo = New System.Windows.Forms.TextBox()
        Me.txtMedicosTelefono = New System.Windows.Forms.TextBox()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtMedicosCMP = New System.Windows.Forms.TextBox()
        Me.txtMedicosApellidos = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMedicosNombres = New System.Windows.Forms.TextBox()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMedicosRegistrados = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMedicosCodigo = New System.Windows.Forms.TextBox()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(798, 159)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(168, 42)
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
        'txtConsultoriosCodigo
        '
        Me.txtConsultoriosCodigo.Location = New System.Drawing.Point(191, 241)
        Me.txtConsultoriosCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConsultoriosCodigo.MaxLength = 7
        Me.txtConsultoriosCodigo.Name = "txtConsultoriosCodigo"
        Me.txtConsultoriosCodigo.Size = New System.Drawing.Size(119, 27)
        Me.txtConsultoriosCodigo.TabIndex = 20
        '
        'txtEspecialidadesCodigo
        '
        Me.txtEspecialidadesCodigo.Location = New System.Drawing.Point(191, 210)
        Me.txtEspecialidadesCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEspecialidadesCodigo.MaxLength = 7
        Me.txtEspecialidadesCodigo.Name = "txtEspecialidadesCodigo"
        Me.txtEspecialidadesCodigo.Size = New System.Drawing.Size(119, 27)
        Me.txtEspecialidadesCodigo.TabIndex = 19
        '
        'txtMedicosCorreo
        '
        Me.txtMedicosCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicosCorreo.Location = New System.Drawing.Point(190, 179)
        Me.txtMedicosCorreo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosCorreo.MaxLength = 100
        Me.txtMedicosCorreo.Name = "txtMedicosCorreo"
        Me.txtMedicosCorreo.Size = New System.Drawing.Size(120, 27)
        Me.txtMedicosCorreo.TabIndex = 18
        '
        'txtMedicosTelefono
        '
        Me.txtMedicosTelefono.Location = New System.Drawing.Point(190, 148)
        Me.txtMedicosTelefono.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosTelefono.MaxLength = 9
        Me.txtMedicosTelefono.Name = "txtMedicosTelefono"
        Me.txtMedicosTelefono.Size = New System.Drawing.Size(120, 27)
        Me.txtMedicosTelefono.TabIndex = 16
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(798, 55)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(168, 42)
        Me.cmdAgregar.TabIndex = 27
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 248)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(151, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Código Consultorio"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 217)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Código Especialidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 186)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Correo "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 155)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Teléfono"
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(798, 107)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(168, 42)
        Me.cmdEditar.TabIndex = 28
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Código Consultorio"
        Me.ColumnHeader8.Width = 266
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Correo"
        Me.ColumnHeader6.Width = 94
        '
        'txtMedicosCMP
        '
        Me.txtMedicosCMP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicosCMP.Location = New System.Drawing.Point(191, 117)
        Me.txtMedicosCMP.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosCMP.MaxLength = 10
        Me.txtMedicosCMP.Name = "txtMedicosCMP"
        Me.txtMedicosCMP.Size = New System.Drawing.Size(244, 27)
        Me.txtMedicosCMP.TabIndex = 9
        '
        'txtMedicosApellidos
        '
        Me.txtMedicosApellidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicosApellidos.Location = New System.Drawing.Point(190, 86)
        Me.txtMedicosApellidos.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosApellidos.MaxLength = 100
        Me.txtMedicosApellidos.Name = "txtMedicosApellidos"
        Me.txtMedicosApellidos.Size = New System.Drawing.Size(550, 27)
        Me.txtMedicosApellidos.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "CMP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Apellidos"
        '
        'txtMedicosNombres
        '
        Me.txtMedicosNombres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicosNombres.Location = New System.Drawing.Point(191, 55)
        Me.txtMedicosNombres.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosNombres.MaxLength = 100
        Me.txtMedicosNombres.Name = "txtMedicosNombres"
        Me.txtMedicosNombres.Size = New System.Drawing.Size(549, 27)
        Me.txtMedicosNombres.TabIndex = 5
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Código Especialidad"
        Me.ColumnHeader7.Width = 175
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(798, 211)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(168, 42)
        Me.cmdCancelar.TabIndex = 30
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 31)
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
        Me.cmdEliminados.Location = New System.Drawing.Point(798, 315)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(168, 42)
        Me.cmdEliminados.TabIndex = 32
        Me.cmdEliminados.Text = "Eliminados"
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombres"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "CMP"
        Me.ColumnHeader4.Width = 102
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Apellidos"
        Me.ColumnHeader3.Width = 139
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombres"
        Me.ColumnHeader2.Width = 144
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 71
        '
        'lvMedicosRegistrados
        '
        Me.lvMedicosRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMedicosRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvMedicosRegistrados.FullRowSelect = True
        Me.lvMedicosRegistrados.GridLines = True
        Me.lvMedicosRegistrados.HideSelection = False
        Me.lvMedicosRegistrados.Location = New System.Drawing.Point(8, 390)
        Me.lvMedicosRegistrados.Margin = New System.Windows.Forms.Padding(2)
        Me.lvMedicosRegistrados.MinimumSize = New System.Drawing.Size(969, 190)
        Me.lvMedicosRegistrados.Name = "lvMedicosRegistrados"
        Me.lvMedicosRegistrados.Size = New System.Drawing.Size(969, 190)
        Me.lvMedicosRegistrados.TabIndex = 26
        Me.lvMedicosRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvMedicosRegistrados.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Teléfono"
        Me.ColumnHeader5.Width = 90
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 359)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(186, 20)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Médicos Registrados"
        '
        'txtMedicosCodigo
        '
        Me.txtMedicosCodigo.Location = New System.Drawing.Point(191, 24)
        Me.txtMedicosCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosCodigo.MaxLength = 7
        Me.txtMedicosCodigo.Name = "txtMedicosCodigo"
        Me.txtMedicosCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtMedicosCodigo.TabIndex = 3
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(798, 263)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(168, 42)
        Me.cmdCerrar.TabIndex = 31
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtConsultoriosCodigo)
        Me.GroupBox1.Controls.Add(Me.txtEspecialidadesCodigo)
        Me.GroupBox1.Controls.Add(Me.txtMedicosCorreo)
        Me.GroupBox1.Controls.Add(Me.txtMedicosTelefono)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMedicosCMP)
        Me.GroupBox1.Controls.Add(Me.txtMedicosApellidos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtMedicosNombres)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMedicosCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 55)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(744, 285)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paciente "
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 46)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Médicos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmMedicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.lvMedicosRegistrados)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmMedicos"
        Me.Text = "Médicos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdEliminar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txtConsultoriosCodigo As TextBox
    Friend WithEvents txtEspecialidadesCodigo As TextBox
    Friend WithEvents txtMedicosCorreo As TextBox
    Friend WithEvents txtMedicosTelefono As TextBox
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmdEditar As Button
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents txtMedicosCMP As TextBox
    Friend WithEvents txtMedicosApellidos As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMedicosNombres As TextBox
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lvMedicosRegistrados As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMedicosCodigo As TextBox
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
End Class
