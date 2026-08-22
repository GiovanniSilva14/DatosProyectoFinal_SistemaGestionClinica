<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRecetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecetas))
        Me.Diagnostico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoRecetaCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRecetaDiagnostico = New System.Windows.Forms.TextBox()
        Me.txtRecetaObservaciones = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRecetaIndicaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CodigoMedico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoHistoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpRecetaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRecetaCategoriasCodigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMedicosCodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHistoriaClinicaCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvRecetasRegistradas = New System.Windows.Forms.ListView()
        Me.Indicaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Observaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRecetaCodigo = New System.Windows.Forms.TextBox()
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
        'Diagnostico
        '
        Me.Diagnostico.Text = "Diagnóstico"
        Me.Diagnostico.Width = 105
        '
        'CodigoRecetaCategoria
        '
        Me.CodigoRecetaCategoria.Text = "Código Receta Categoría"
        Me.CodigoRecetaCategoria.Width = 204
        '
        'txtRecetaDiagnostico
        '
        Me.txtRecetaDiagnostico.Location = New System.Drawing.Point(263, 185)
        Me.txtRecetaDiagnostico.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecetaDiagnostico.MaxLength = 300
        Me.txtRecetaDiagnostico.Name = "txtRecetaDiagnostico"
        Me.txtRecetaDiagnostico.Size = New System.Drawing.Size(499, 27)
        Me.txtRecetaDiagnostico.TabIndex = 16
        '
        'txtRecetaObservaciones
        '
        Me.txtRecetaObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecetaObservaciones.Location = New System.Drawing.Point(263, 251)
        Me.txtRecetaObservaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecetaObservaciones.MaxLength = 500
        Me.txtRecetaObservaciones.Name = "txtRecetaObservaciones"
        Me.txtRecetaObservaciones.Size = New System.Drawing.Size(499, 27)
        Me.txtRecetaObservaciones.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 258)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Observaciones"
        '
        'txtRecetaIndicaciones
        '
        Me.txtRecetaIndicaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecetaIndicaciones.Location = New System.Drawing.Point(263, 218)
        Me.txtRecetaIndicaciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecetaIndicaciones.MaxLength = 500
        Me.txtRecetaIndicaciones.Name = "txtRecetaIndicaciones"
        Me.txtRecetaIndicaciones.Size = New System.Drawing.Size(499, 27)
        Me.txtRecetaIndicaciones.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 225)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Indicaciones"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 192)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Diagnóstico"
        '
        'CodigoMedico
        '
        Me.CodigoMedico.Text = "Código Médico"
        Me.CodigoMedico.Width = 124
        '
        'CodigoHistoria
        '
        Me.CodigoHistoria.Text = "Código Historia"
        Me.CodigoHistoria.Width = 133
        '
        'dtpRecetaFecha
        '
        Me.dtpRecetaFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRecetaFecha.Location = New System.Drawing.Point(263, 152)
        Me.dtpRecetaFecha.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpRecetaFecha.Name = "dtpRecetaFecha"
        Me.dtpRecetaFecha.Size = New System.Drawing.Size(167, 27)
        Me.dtpRecetaFecha.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 159)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 126)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(205, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Código Receta Categorias"
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 61
        '
        'Código
        '
        Me.Código.Text = "Código"
        Me.Código.Width = 73
        '
        'txtRecetaCategoriasCodigo
        '
        Me.txtRecetaCategoriasCodigo.Location = New System.Drawing.Point(263, 119)
        Me.txtRecetaCategoriasCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecetaCategoriasCodigo.MaxLength = 7
        Me.txtRecetaCategoriasCodigo.Name = "txtRecetaCategoriasCodigo"
        Me.txtRecetaCategoriasCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtRecetaCategoriasCodigo.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 383)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(185, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Recetas Registradas"
        '
        'txtMedicosCodigo
        '
        Me.txtMedicosCodigo.Location = New System.Drawing.Point(263, 86)
        Me.txtMedicosCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMedicosCodigo.MaxLength = 7
        Me.txtMedicosCodigo.Name = "txtMedicosCodigo"
        Me.txtMedicosCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtMedicosCodigo.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 93)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Código Médicos "
        '
        'txtHistoriaClinicaCodigo
        '
        Me.txtHistoriaClinicaCodigo.Location = New System.Drawing.Point(263, 53)
        Me.txtHistoriaClinicaCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHistoriaClinicaCodigo.MaxLength = 7
        Me.txtHistoriaClinicaCodigo.Name = "txtHistoriaClinicaCodigo"
        Me.txtHistoriaClinicaCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtHistoriaClinicaCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 60)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(186, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código Historia Clínica "
        '
        'lvRecetasRegistradas
        '
        Me.lvRecetasRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvRecetasRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoHistoria, Me.CodigoMedico, Me.CodigoRecetaCategoria, Me.Fecha, Me.Diagnostico, Me.Indicaciones, Me.Observaciones})
        Me.lvRecetasRegistradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRecetasRegistradas.FullRowSelect = True
        Me.lvRecetasRegistradas.GridLines = True
        Me.lvRecetasRegistradas.HideSelection = False
        Me.lvRecetasRegistradas.Location = New System.Drawing.Point(19, 426)
        Me.lvRecetasRegistradas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvRecetasRegistradas.MinimumSize = New System.Drawing.Size(956, 154)
        Me.lvRecetasRegistradas.Name = "lvRecetasRegistradas"
        Me.lvRecetasRegistradas.Size = New System.Drawing.Size(956, 154)
        Me.lvRecetasRegistradas.TabIndex = 36
        Me.lvRecetasRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvRecetasRegistradas.View = System.Windows.Forms.View.Details
        '
        'Indicaciones
        '
        Me.Indicaciones.Text = "Indicaciones"
        Me.Indicaciones.Width = 111
        '
        'Observaciones
        '
        Me.Observaciones.Text = "Observaciones"
        Me.Observaciones.Width = 238
        '
        'txtRecetaCodigo
        '
        Me.txtRecetaCodigo.Location = New System.Drawing.Point(263, 20)
        Me.txtRecetaCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRecetaCodigo.MaxLength = 7
        Me.txtRecetaCodigo.Name = "txtRecetaCodigo"
        Me.txtRecetaCodigo.Size = New System.Drawing.Size(84, 27)
        Me.txtRecetaCodigo.TabIndex = 1
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
        Me.txt.Location = New System.Drawing.Point(23, 27)
        Me.txt.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(61, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código"
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(802, 341)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(178, 46)
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
        Me.cmdCerrar.Location = New System.Drawing.Point(802, 286)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(178, 46)
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
        Me.cmdAgregar.Location = New System.Drawing.Point(802, 65)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(178, 46)
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
        Me.cmdEditar.Location = New System.Drawing.Point(802, 120)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(178, 46)
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
        Me.cmdEliminar.Location = New System.Drawing.Point(802, 176)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(178, 46)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(802, 231)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(178, 46)
        Me.cmdCancelar.TabIndex = 31
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 487)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 34
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtRecetaDiagnostico)
        Me.GroupBox1.Controls.Add(Me.txtRecetaObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtRecetaIndicaciones)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpRecetaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRecetaCategoriasCodigo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtMedicosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHistoriaClinicaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtRecetaCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(19, 55)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(766, 310)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Receta"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 53)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Recetas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmRecetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lvRecetasRegistradas)
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
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmRecetas"
        Me.Text = "frmRecetas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Diagnostico As ColumnHeader
    Friend WithEvents CodigoRecetaCategoria As ColumnHeader
    Friend WithEvents txtRecetaDiagnostico As TextBox
    Friend WithEvents txtRecetaObservaciones As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtRecetaIndicaciones As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CodigoMedico As ColumnHeader
    Friend WithEvents CodigoHistoria As ColumnHeader
    Friend WithEvents dtpRecetaFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents txtRecetaCategoriasCodigo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtMedicosCodigo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHistoriaClinicaCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lvRecetasRegistradas As ListView
    Friend WithEvents Indicaciones As ColumnHeader
    Friend WithEvents Observaciones As ColumnHeader
    Friend WithEvents txtRecetaCodigo As TextBox
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

    Private Sub frmRecetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
