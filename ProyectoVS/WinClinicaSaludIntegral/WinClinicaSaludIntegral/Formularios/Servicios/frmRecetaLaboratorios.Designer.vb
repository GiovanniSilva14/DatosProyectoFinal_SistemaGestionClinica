<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecetaLaboratorios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecetaLaboratorios))
        Me.LaboratoriosFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosExamen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRecetaLaboratoriosObservaciones = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RecetaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dtpRecetaLaboratoriosFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LaboratoriosResultado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvRecetaLaboratoriosRegistrados = New System.Windows.Forms.ListView()
        Me.LaboratoriosObservaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtRecetaLaboratoriosResultado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecetaLaboratoriosExamen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecetaCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRecetaLaboratoriosCodigo = New System.Windows.Forms.TextBox()
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LaboratoriosFecha
        '
        Me.LaboratoriosFecha.Text = "Fecha"
        Me.LaboratoriosFecha.Width = 110
        '
        'LaboratoriosExamen
        '
        Me.LaboratoriosExamen.Text = "Examen"
        Me.LaboratoriosExamen.Width = 81
        '
        'txtRecetaLaboratoriosObservaciones
        '
        Me.txtRecetaLaboratoriosObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecetaLaboratoriosObservaciones.Location = New System.Drawing.Point(170, 184)
        Me.txtRecetaLaboratoriosObservaciones.MaxLength = 300
        Me.txtRecetaLaboratoriosObservaciones.Name = "txtRecetaLaboratoriosObservaciones"
        Me.txtRecetaLaboratoriosObservaciones.Size = New System.Drawing.Size(584, 27)
        Me.txtRecetaLaboratoriosObservaciones.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Observaciones"
        '
        'RecetaCodigo
        '
        Me.RecetaCodigo.Text = "Código Receta"
        Me.RecetaCodigo.Width = 123
        '
        'LaboratoriosCodigo
        '
        Me.LaboratoriosCodigo.Text = "Código"
        Me.LaboratoriosCodigo.Width = 68
        '
        'dtpRecetaLaboratoriosFecha
        '
        Me.dtpRecetaLaboratoriosFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRecetaLaboratoriosFecha.Location = New System.Drawing.Point(170, 152)
        Me.dtpRecetaLaboratoriosFecha.Name = "dtpRecetaLaboratoriosFecha"
        Me.dtpRecetaLaboratoriosFecha.Size = New System.Drawing.Size(229, 27)
        Me.dtpRecetaLaboratoriosFecha.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Fecha"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Resultado"
        '
        'LaboratoriosResultado
        '
        Me.LaboratoriosResultado.Text = "Resultado"
        Me.LaboratoriosResultado.Width = 162
        '
        'lvRecetaLaboratoriosRegistrados
        '
        Me.lvRecetaLaboratoriosRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvRecetaLaboratoriosRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LaboratoriosCodigo, Me.RecetaCodigo, Me.LaboratoriosExamen, Me.LaboratoriosResultado, Me.LaboratoriosFecha, Me.LaboratoriosObservaciones})
        Me.lvRecetaLaboratoriosRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRecetaLaboratoriosRegistrados.FullRowSelect = True
        Me.lvRecetaLaboratoriosRegistrados.GridLines = True
        Me.lvRecetaLaboratoriosRegistrados.HideSelection = False
        Me.lvRecetaLaboratoriosRegistrados.Location = New System.Drawing.Point(8, 352)
        Me.lvRecetaLaboratoriosRegistrados.MinimumSize = New System.Drawing.Size(760, 227)
        Me.lvRecetaLaboratoriosRegistrados.Name = "lvRecetaLaboratoriosRegistrados"
        Me.lvRecetaLaboratoriosRegistrados.Size = New System.Drawing.Size(760, 227)
        Me.lvRecetaLaboratoriosRegistrados.TabIndex = 36
        Me.lvRecetaLaboratoriosRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvRecetaLaboratoriosRegistrados.View = System.Windows.Forms.View.Details
        '
        'LaboratoriosObservaciones
        '
        Me.LaboratoriosObservaciones.Text = "Observaciones"
        Me.LaboratoriosObservaciones.Width = 216
        '
        'txtRecetaLaboratoriosResultado
        '
        Me.txtRecetaLaboratoriosResultado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecetaLaboratoriosResultado.Location = New System.Drawing.Point(170, 120)
        Me.txtRecetaLaboratoriosResultado.MaxLength = 300
        Me.txtRecetaLaboratoriosResultado.Name = "txtRecetaLaboratoriosResultado"
        Me.txtRecetaLaboratoriosResultado.Size = New System.Drawing.Size(584, 27)
        Me.txtRecetaLaboratoriosResultado.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 582)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 34
        '
        'txtRecetaLaboratoriosExamen
        '
        Me.txtRecetaLaboratoriosExamen.Location = New System.Drawing.Point(170, 88)
        Me.txtRecetaLaboratoriosExamen.MaxLength = 150
        Me.txtRecetaLaboratoriosExamen.Name = "txtRecetaLaboratoriosExamen"
        Me.txtRecetaLaboratoriosExamen.Size = New System.Drawing.Size(115, 27)
        Me.txtRecetaLaboratoriosExamen.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Examen"
        '
        'txtRecetaCodigo
        '
        Me.txtRecetaCodigo.Location = New System.Drawing.Point(170, 56)
        Me.txtRecetaCodigo.MaxLength = 7
        Me.txtRecetaCodigo.Name = "txtRecetaCodigo"
        Me.txtRecetaCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtRecetaCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código Receta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 307)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(297, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Laboratorios Recetas Registradas"
        '
        'txtRecetaLaboratoriosCodigo
        '
        Me.txtRecetaLaboratoriosCodigo.Location = New System.Drawing.Point(170, 24)
        Me.txtRecetaLaboratoriosCodigo.MaxLength = 7
        Me.txtRecetaLaboratoriosCodigo.Name = "txtRecetaLaboratoriosCodigo"
        Me.txtRecetaLaboratoriosCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtRecetaLaboratoriosCodigo.TabIndex = 1
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(22, 31)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(61, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(796, 368)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(172, 69)
        Me.cmdCerrar.TabIndex = 32
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
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
        Me.cmdEditar.Location = New System.Drawing.Point(796, 146)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(172, 69)
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
        Me.cmdEliminar.Location = New System.Drawing.Point(796, 220)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(172, 69)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(796, 294)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(172, 69)
        Me.cmdCancelar.TabIndex = 31
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(796, 72)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(172, 69)
        Me.cmdAgregar.TabIndex = 28
        Me.cmdAgregar.Text = "Agregar "
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(796, 442)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(172, 69)
        Me.cmdEliminados.TabIndex = 33
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtRecetaLaboratoriosObservaciones)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpRecetaLaboratoriosFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtRecetaLaboratoriosResultado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtRecetaLaboratoriosExamen)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRecetaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtRecetaLaboratoriosCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 243)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Laboratorio Receta"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = " Laboratorios Recetas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmRecetaLaboratorios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.lvRecetaLaboratoriosRegistrados)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmRecetaLaboratorios"
        Me.Text = "Receta Laboratorio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LaboratoriosFecha As ColumnHeader
    Friend WithEvents LaboratoriosExamen As ColumnHeader
    Friend WithEvents txtRecetaLaboratoriosObservaciones As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RecetaCodigo As ColumnHeader
    Friend WithEvents LaboratoriosCodigo As ColumnHeader
    Friend WithEvents dtpRecetaLaboratoriosFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LaboratoriosResultado As ColumnHeader
    Friend WithEvents lvRecetaLaboratoriosRegistrados As ListView
    Friend WithEvents LaboratoriosObservaciones As ColumnHeader
    Friend WithEvents txtRecetaLaboratoriosResultado As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRecetaLaboratoriosExamen As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRecetaCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRecetaLaboratoriosCodigo As TextBox
    Friend WithEvents txt As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
End Class
