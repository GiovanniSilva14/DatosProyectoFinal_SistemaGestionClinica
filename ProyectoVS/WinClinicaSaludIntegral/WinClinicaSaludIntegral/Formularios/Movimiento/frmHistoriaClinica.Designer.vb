<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHistoriaClinica
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistoriaClinica))
        Me.Antecendentes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrupoSanguineo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtHistoriaClinicaAntecedentes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHistoriaClinicaObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.FechaApertura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpHistoriaClinicaFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.alergia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtHistoriaClinicaGrupoSanguineo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHistoriaClinicaAlergias = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPacientesCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvHistoriaClinicaRegistrados = New System.Windows.Forms.ListView()
        Me.Observaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Condiciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtHistoriaClinicaCodigo = New System.Windows.Forms.TextBox()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Antecendentes
        '
        Me.Antecendentes.Text = "Antecendentes"
        Me.Antecendentes.Width = 125
        '
        'GrupoSanguineo
        '
        Me.GrupoSanguineo.Text = "Grupo Sanguíneo"
        Me.GrupoSanguineo.Width = 145
        '
        'txtHistoriaClinicaAntecedentes
        '
        Me.txtHistoriaClinicaAntecedentes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHistoriaClinicaAntecedentes.Location = New System.Drawing.Point(218, 185)
        Me.txtHistoriaClinicaAntecedentes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaAntecedentes.MaxLength = 500
        Me.txtHistoriaClinicaAntecedentes.Name = "txtHistoriaClinicaAntecedentes"
        Me.txtHistoriaClinicaAntecedentes.Size = New System.Drawing.Size(427, 27)
        Me.txtHistoriaClinicaAntecedentes.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 235)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 20)
        Me.Label9.TabIndex = 14
        '
        'txtHistoriaClinicaObservaciones
        '
        Me.txtHistoriaClinicaObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHistoriaClinicaObservaciones.Location = New System.Drawing.Point(218, 216)
        Me.txtHistoriaClinicaObservaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaObservaciones.MaxLength = 500
        Me.txtHistoriaClinicaObservaciones.Name = "txtHistoriaClinicaObservaciones"
        Me.txtHistoriaClinicaObservaciones.Size = New System.Drawing.Size(427, 27)
        Me.txtHistoriaClinicaObservaciones.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 223)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Observaciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 192)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Antecedentes"
        '
        'FechaApertura
        '
        Me.FechaApertura.Text = "Fecha Apertura"
        Me.FechaApertura.Width = 133
        '
        'CodigoPaciente
        '
        Me.CodigoPaciente.Text = "Código Paciente"
        Me.CodigoPaciente.Width = 150
        '
        'dtpHistoriaClinicaFechaApertura
        '
        Me.dtpHistoriaClinicaFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHistoriaClinicaFechaApertura.Location = New System.Drawing.Point(219, 92)
        Me.dtpHistoriaClinicaFechaApertura.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpHistoriaClinicaFechaApertura.Name = "dtpHistoriaClinicaFechaApertura"
        Me.dtpHistoriaClinicaFechaApertura.Size = New System.Drawing.Size(167, 27)
        Me.dtpHistoriaClinicaFechaApertura.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 161)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Alergía"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 130)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Grupo Sanguíneo"
        '
        'alergia
        '
        Me.alergia.Text = "Alergía "
        Me.alergia.Width = 74
        '
        'Codigo
        '
        Me.Codigo.Text = "Código "
        Me.Codigo.Width = 73
        '
        'txtHistoriaClinicaGrupoSanguineo
        '
        Me.txtHistoriaClinicaGrupoSanguineo.Location = New System.Drawing.Point(219, 123)
        Me.txtHistoriaClinicaGrupoSanguineo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaGrupoSanguineo.MaxLength = 5
        Me.txtHistoriaClinicaGrupoSanguineo.Name = "txtHistoriaClinicaGrupoSanguineo"
        Me.txtHistoriaClinicaGrupoSanguineo.Size = New System.Drawing.Size(84, 27)
        Me.txtHistoriaClinicaGrupoSanguineo.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(20, 357)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(193, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Historias Registradas"
        '
        'txtHistoriaClinicaAlergias
        '
        Me.txtHistoriaClinicaAlergias.Location = New System.Drawing.Point(218, 154)
        Me.txtHistoriaClinicaAlergias.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaAlergias.MaxLength = 250
        Me.txtHistoriaClinicaAlergias.Name = "txtHistoriaClinicaAlergias"
        Me.txtHistoriaClinicaAlergias.Size = New System.Drawing.Size(427, 27)
        Me.txtHistoriaClinicaAlergias.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 99)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Fecha Apertura"
        '
        'txtPacientesCodigo
        '
        Me.txtPacientesCodigo.Location = New System.Drawing.Point(219, 61)
        Me.txtPacientesCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesCodigo.MaxLength = 7
        Me.txtPacientesCodigo.Name = "txtPacientesCodigo"
        Me.txtPacientesCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtPacientesCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 68)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código Paciente  "
        '
        'lvHistoriaClinicaRegistrados
        '
        Me.lvHistoriaClinicaRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvHistoriaClinicaRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Codigo, Me.CodigoPaciente, Me.FechaApertura, Me.GrupoSanguineo, Me.alergia, Me.Antecendentes, Me.Observaciones, Me.Condiciones})
        Me.lvHistoriaClinicaRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvHistoriaClinicaRegistrados.FullRowSelect = True
        Me.lvHistoriaClinicaRegistrados.GridLines = True
        Me.lvHistoriaClinicaRegistrados.HideSelection = False
        Me.lvHistoriaClinicaRegistrados.Location = New System.Drawing.Point(24, 398)
        Me.lvHistoriaClinicaRegistrados.Margin = New System.Windows.Forms.Padding(2)
        Me.lvHistoriaClinicaRegistrados.MinimumSize = New System.Drawing.Size(878, 182)
        Me.lvHistoriaClinicaRegistrados.Name = "lvHistoriaClinicaRegistrados"
        Me.lvHistoriaClinicaRegistrados.Size = New System.Drawing.Size(878, 182)
        Me.lvHistoriaClinicaRegistrados.TabIndex = 36
        Me.lvHistoriaClinicaRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvHistoriaClinicaRegistrados.View = System.Windows.Forms.View.Details
        '
        'Observaciones
        '
        Me.Observaciones.Text = "Observaciones"
        Me.Observaciones.Width = 129
        '
        'Condiciones
        '
        Me.Condiciones.Text = ""
        Me.Condiciones.Width = 0
        '
        'txtHistoriaClinicaCodigo
        '
        Me.txtHistoriaClinicaCodigo.Location = New System.Drawing.Point(219, 30)
        Me.txtHistoriaClinicaCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaCodigo.MaxLength = 7
        Me.txtHistoriaClinicaCodigo.Name = "txtHistoriaClinicaCodigo"
        Me.txtHistoriaClinicaCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtHistoriaClinicaCodigo.TabIndex = 1
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
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(16, 37)
        Me.txt.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(66, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código "
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(710, 331)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(173, 46)
        Me.cmdEliminados.TabIndex = 33
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(710, 276)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(173, 46)
        Me.cmdCerrar.TabIndex = 32
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(710, 55)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(173, 46)
        Me.cmdAgregar.TabIndex = 28
        Me.cmdAgregar.Text = "Agregar "
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(710, 111)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(173, 46)
        Me.cmdEditar.TabIndex = 29
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
        Me.cmdEliminar.Location = New System.Drawing.Point(710, 166)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(173, 46)
        Me.cmdEliminar.TabIndex = 30
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
        Me.cmdCancelar.Location = New System.Drawing.Point(710, 221)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(173, 46)
        Me.cmdCancelar.TabIndex = 31
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 466)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaAntecedentes)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpHistoriaClinicaFechaApertura)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaGrupoSanguineo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaAlergias)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 72)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(687, 273)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Historia Clínica"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(924, 53)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Historias Clínicas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmHistoriaClinica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 591)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lvHistoriaClinicaRegistrados)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(942, 638)
        Me.Name = "frmHistoriaClinica"
        Me.Text = "Historia Clínica"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Antecendentes As ColumnHeader
    Friend WithEvents GrupoSanguineo As ColumnHeader
    Friend WithEvents txtHistoriaClinicaAntecedentes As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHistoriaClinicaObservaciones As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents FechaApertura As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents dtpHistoriaClinicaFechaApertura As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents alergia As ColumnHeader
    Friend WithEvents Codigo As ColumnHeader
    Friend WithEvents txtHistoriaClinicaGrupoSanguineo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtHistoriaClinicaAlergias As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPacientesCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lvHistoriaClinicaRegistrados As ListView
    Friend WithEvents Observaciones As ColumnHeader
    Friend WithEvents Condiciones As ColumnHeader
    Friend WithEvents txtHistoriaClinicaCodigo As TextBox
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txt As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
End Class
