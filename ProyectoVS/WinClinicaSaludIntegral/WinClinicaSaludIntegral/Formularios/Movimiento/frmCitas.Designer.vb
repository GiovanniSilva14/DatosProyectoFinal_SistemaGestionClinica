<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCitas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCitas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCitasHora = New System.Windows.Forms.TextBox()
        Me.txtCitasCondiciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCitasMotivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpCitasFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtConsultoriosCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMedicosCodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPacientesCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCitasCodigo = New System.Windows.Forms.TextBox()
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lvCitasRegistradas = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoMedico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoConsultorio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Hora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Motivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Condiciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1087, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Citas "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtCitasHora)
        Me.GroupBox1.Controls.Add(Me.txtCitasCondiciones)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCitasMotivo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpCitasFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtConsultoriosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtMedicosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCitasCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(23, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(877, 394)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cita"
        '
        'txtCitasHora
        '
        Me.txtCitasHora.Location = New System.Drawing.Point(215, 220)
        Me.txtCitasHora.MaxLength = 7
        Me.txtCitasHora.Name = "txtCitasHora"
        Me.txtCitasHora.Size = New System.Drawing.Size(100, 27)
        Me.txtCitasHora.TabIndex = 16
        '
        'txtCitasCondiciones
        '
        Me.txtCitasCondiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCitasCondiciones.Location = New System.Drawing.Point(215, 293)
        Me.txtCitasCondiciones.MaxLength = 300
        Me.txtCitasCondiciones.Name = "txtCitasCondiciones"
        Me.txtCitasCondiciones.Size = New System.Drawing.Size(646, 27)
        Me.txtCitasCondiciones.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Condiciones"
        '
        'txtCitasMotivo
        '
        Me.txtCitasMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCitasMotivo.Location = New System.Drawing.Point(215, 256)
        Me.txtCitasMotivo.MaxLength = 250
        Me.txtCitasMotivo.Name = "txtCitasMotivo"
        Me.txtCitasMotivo.Size = New System.Drawing.Size(646, 27)
        Me.txtCitasMotivo.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 256)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Motivo "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Hora"
        '
        'dtpCitasFecha
        '
        Me.dtpCitasFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCitasFecha.Location = New System.Drawing.Point(215, 183)
        Me.dtpCitasFecha.Name = "dtpCitasFecha"
        Me.dtpCitasFecha.Size = New System.Drawing.Size(200, 27)
        Me.dtpCitasFecha.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Fecha"
        '
        'txtConsultoriosCodigo
        '
        Me.txtConsultoriosCodigo.Location = New System.Drawing.Point(215, 147)
        Me.txtConsultoriosCodigo.MaxLength = 7
        Me.txtConsultoriosCodigo.Name = "txtConsultoriosCodigo"
        Me.txtConsultoriosCodigo.Size = New System.Drawing.Size(100, 27)
        Me.txtConsultoriosCodigo.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Código Consultorios"
        '
        'txtMedicosCodigo
        '
        Me.txtMedicosCodigo.Location = New System.Drawing.Point(215, 106)
        Me.txtMedicosCodigo.MaxLength = 7
        Me.txtMedicosCodigo.Name = "txtMedicosCodigo"
        Me.txtMedicosCodigo.Size = New System.Drawing.Size(100, 27)
        Me.txtMedicosCodigo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Código Medicos "
        '
        'txtPacientesCodigo
        '
        Me.txtPacientesCodigo.Location = New System.Drawing.Point(215, 68)
        Me.txtPacientesCodigo.MaxLength = 7
        Me.txtPacientesCodigo.Name = "txtPacientesCodigo"
        Me.txtPacientesCodigo.Size = New System.Drawing.Size(100, 27)
        Me.txtPacientesCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código Paciente  "
        '
        'txtCitasCodigo
        '
        Me.txtCitasCodigo.Location = New System.Drawing.Point(215, 26)
        Me.txtCitasCodigo.MaxLength = 7
        Me.txtCitasCodigo.Name = "txtCitasCodigo"
        Me.txtCitasCodigo.Size = New System.Drawing.Size(100, 27)
        Me.txtCitasCodigo.TabIndex = 1
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(19, 26)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(61, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(906, 63)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(165, 57)
        Me.cmdAgregar.TabIndex = 17
        Me.cmdAgregar.Text = "Agregar "
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'ListaImagenesBotones
        '
        Me.ListaImagenesBotones.ImageStream = CType(resources.GetObject("ListaImagenesBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenesBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenesBotones.Images.SetKeyName(0, "IconoAgregar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(1, "IconoCancelar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(2, "IconoCerrar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(3, "IconoEditar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(4, "IconoEliminados.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(5, "IconoEliminar.gif")
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(906, 140)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(165, 57)
        Me.cmdEditar.TabIndex = 18
        Me.cmdEditar.Text = "Editar "
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(906, 209)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(165, 57)
        Me.cmdEliminar.TabIndex = 19
        Me.cmdEliminar.Text = "Eliminar "
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(906, 278)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(165, 57)
        Me.cmdCancelar.TabIndex = 20
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(906, 347)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(165, 57)
        Me.cmdCerrar.TabIndex = 21
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(906, 416)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(165, 57)
        Me.cmdEliminados.TabIndex = 22
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 477)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 16)
        Me.Label2.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 483)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(160, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Citas Registradas"
        '
        'lvCitasRegistradas
        '
        Me.lvCitasRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCitasRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoPaciente, Me.CodigoMedico, Me.CodigoConsultorio, Me.Fecha, Me.Hora, Me.Motivo, Me.Condiciones})
        Me.lvCitasRegistradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCitasRegistradas.FullRowSelect = True
        Me.lvCitasRegistradas.GridLines = True
        Me.lvCitasRegistradas.HideSelection = False
        Me.lvCitasRegistradas.Location = New System.Drawing.Point(23, 522)
        Me.lvCitasRegistradas.MinimumSize = New System.Drawing.Size(932, 202)
        Me.lvCitasRegistradas.Name = "lvCitasRegistradas"
        Me.lvCitasRegistradas.Size = New System.Drawing.Size(997, 225)
        Me.lvCitasRegistradas.TabIndex = 25
        Me.lvCitasRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvCitasRegistradas.View = System.Windows.Forms.View.Details
        '
        'Código
        '
        Me.Código.Text = "Código "
        Me.Código.Width = 77
        '
        'CodigoPaciente
        '
        Me.CodigoPaciente.Text = "Código Paciente"
        Me.CodigoPaciente.Width = 139
        '
        'CodigoMedico
        '
        Me.CodigoMedico.Text = "Código Medico"
        Me.CodigoMedico.Width = 126
        '
        'CodigoConsultorio
        '
        Me.CodigoConsultorio.Text = "Código Consultorio"
        Me.CodigoConsultorio.Width = 162
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 66
        '
        'Hora
        '
        Me.Hora.Text = "Hora"
        Me.Hora.Width = 56
        '
        'Motivo
        '
        Me.Motivo.Text = "Motivo"
        Me.Motivo.Width = 74
        '
        'Condiciones
        '
        Me.Condiciones.Text = "Condiciones"
        Me.Condiciones.Width = 129
        '
        'frmCitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 703)
        Me.Controls.Add(Me.lvCitasRegistradas)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1105, 694)
        Me.Name = "frmCitas"
        Me.Text = "Citas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpCitasFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtConsultoriosCodigo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMedicosCodigo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPacientesCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCitasCodigo As TextBox
    Friend WithEvents txt As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCitasMotivo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCitasCondiciones As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCitasHora As TextBox
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lvCitasRegistradas As ListView
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents CodigoMedico As ColumnHeader
    Friend WithEvents CodigoConsultorio As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Hora As ColumnHeader
    Friend WithEvents Motivo As ColumnHeader
    Friend WithEvents Condiciones As ColumnHeader
    Friend WithEvents ListaImagenesBotones As ImageList
End Class
