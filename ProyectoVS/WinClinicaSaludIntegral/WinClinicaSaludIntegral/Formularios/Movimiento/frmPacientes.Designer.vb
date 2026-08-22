<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPacientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPacientes))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpPacientesFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.txtPacientesCondiciones = New System.Windows.Forms.TextBox()
        Me.txtPacientesDireccion = New System.Windows.Forms.TextBox()
        Me.txtPacientesCorreo = New System.Windows.Forms.TextBox()
        Me.txtPacientesTelefono = New System.Windows.Forms.TextBox()
        Me.txtPacientesSexo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPacientesApellidos = New System.Windows.Forms.TextBox()
        Me.txtPacientesNombres = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPacientesDNI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPacientesCodigo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lvPacientesRegistrados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pacientes "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpPacientesFechaNacimiento)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCondiciones)
        Me.GroupBox1.Controls.Add(Me.txtPacientesDireccion)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCorreo)
        Me.GroupBox1.Controls.Add(Me.txtPacientesTelefono)
        Me.GroupBox1.Controls.Add(Me.txtPacientesSexo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPacientesApellidos)
        Me.GroupBox1.Controls.Add(Me.txtPacientesNombres)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPacientesDNI)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCodigo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(817, 339)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paciente "
        '
        'dtpPacientesFechaNacimiento
        '
        Me.dtpPacientesFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPacientesFechaNacimiento.Location = New System.Drawing.Point(199, 298)
        Me.dtpPacientesFechaNacimiento.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpPacientesFechaNacimiento.Name = "dtpPacientesFechaNacimiento"
        Me.dtpPacientesFechaNacimiento.Size = New System.Drawing.Size(167, 27)
        Me.dtpPacientesFechaNacimiento.TabIndex = 21
        '
        'txtPacientesCondiciones
        '
        Me.txtPacientesCondiciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacientesCondiciones.Location = New System.Drawing.Point(199, 267)
        Me.txtPacientesCondiciones.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesCondiciones.MaxLength = 300
        Me.txtPacientesCondiciones.Name = "txtPacientesCondiciones"
        Me.txtPacientesCondiciones.Size = New System.Drawing.Size(604, 27)
        Me.txtPacientesCondiciones.TabIndex = 20
        '
        'txtPacientesDireccion
        '
        Me.txtPacientesDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacientesDireccion.Location = New System.Drawing.Point(199, 236)
        Me.txtPacientesDireccion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesDireccion.MaxLength = 200
        Me.txtPacientesDireccion.Name = "txtPacientesDireccion"
        Me.txtPacientesDireccion.Size = New System.Drawing.Size(604, 27)
        Me.txtPacientesDireccion.TabIndex = 19
        '
        'txtPacientesCorreo
        '
        Me.txtPacientesCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacientesCorreo.Location = New System.Drawing.Point(199, 205)
        Me.txtPacientesCorreo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesCorreo.MaxLength = 100
        Me.txtPacientesCorreo.Name = "txtPacientesCorreo"
        Me.txtPacientesCorreo.Size = New System.Drawing.Size(604, 27)
        Me.txtPacientesCorreo.TabIndex = 18
        '
        'txtPacientesTelefono
        '
        Me.txtPacientesTelefono.Location = New System.Drawing.Point(199, 174)
        Me.txtPacientesTelefono.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesTelefono.MaxLength = 9
        Me.txtPacientesTelefono.Name = "txtPacientesTelefono"
        Me.txtPacientesTelefono.Size = New System.Drawing.Size(118, 27)
        Me.txtPacientesTelefono.TabIndex = 17
        '
        'txtPacientesSexo
        '
        Me.txtPacientesSexo.Location = New System.Drawing.Point(199, 143)
        Me.txtPacientesSexo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesSexo.MaxLength = 1
        Me.txtPacientesSexo.Name = "txtPacientesSexo"
        Me.txtPacientesSexo.Size = New System.Drawing.Size(39, 27)
        Me.txtPacientesSexo.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 305)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 20)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Fecha de Nacimiento "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 274)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Condiciones"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 243)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 20)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Dirección "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 212)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Correo "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 181)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Teléfono"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Sexo"
        '
        'txtPacientesApellidos
        '
        Me.txtPacientesApellidos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacientesApellidos.Location = New System.Drawing.Point(199, 112)
        Me.txtPacientesApellidos.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesApellidos.MaxLength = 100
        Me.txtPacientesApellidos.Name = "txtPacientesApellidos"
        Me.txtPacientesApellidos.Size = New System.Drawing.Size(604, 27)
        Me.txtPacientesApellidos.TabIndex = 9
        '
        'txtPacientesNombres
        '
        Me.txtPacientesNombres.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPacientesNombres.Location = New System.Drawing.Point(199, 81)
        Me.txtPacientesNombres.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesNombres.MaxLength = 100
        Me.txtPacientesNombres.Name = "txtPacientesNombres"
        Me.txtPacientesNombres.Size = New System.Drawing.Size(604, 27)
        Me.txtPacientesNombres.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 119)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Apellidos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 88)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nombres"
        '
        'txtPacientesDNI
        '
        Me.txtPacientesDNI.Location = New System.Drawing.Point(199, 50)
        Me.txtPacientesDNI.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesDNI.MaxLength = 8
        Me.txtPacientesDNI.Name = "txtPacientesDNI"
        Me.txtPacientesDNI.Size = New System.Drawing.Size(118, 27)
        Me.txtPacientesDNI.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "DNI"
        '
        'txtPacientesCodigo
        '
        Me.txtPacientesCodigo.Location = New System.Drawing.Point(199, 19)
        Me.txtPacientesCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPacientesCodigo.MaxLength = 7
        Me.txtPacientesCodigo.Name = "txtPacientesCodigo"
        Me.txtPacientesCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtPacientesCodigo.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 389)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(199, 20)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Pacientes Registrados"
        '
        'lvPacientesRegistrados
        '
        Me.lvPacientesRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPacientesRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvPacientesRegistrados.FullRowSelect = True
        Me.lvPacientesRegistrados.GridLines = True
        Me.lvPacientesRegistrados.HideSelection = False
        Me.lvPacientesRegistrados.Location = New System.Drawing.Point(8, 417)
        Me.lvPacientesRegistrados.Margin = New System.Windows.Forms.Padding(2)
        Me.lvPacientesRegistrados.MinimumSize = New System.Drawing.Size(972, 163)
        Me.lvPacientesRegistrados.Name = "lvPacientesRegistrados"
        Me.lvPacientesRegistrados.Size = New System.Drawing.Size(972, 163)
        Me.lvPacientesRegistrados.TabIndex = 16
        Me.lvPacientesRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvPacientesRegistrados.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 81
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DNI"
        Me.ColumnHeader2.Width = 62
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombres"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Apellidos"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Sexo"
        Me.ColumnHeader5.Width = 54
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Teléfono"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Correo"
        Me.ColumnHeader7.Width = 65
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Dirección"
        Me.ColumnHeader8.Width = 146
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Condiciones"
        Me.ColumnHeader9.Width = 119
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Fecha de nacimiento"
        Me.ColumnHeader10.Width = 269
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
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(842, 307)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(138, 42)
        Me.cmdEliminados.TabIndex = 22
        Me.cmdEliminados.Text = "Eliminados"
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(842, 259)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(138, 42)
        Me.cmdCerrar.TabIndex = 21
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(842, 211)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(138, 42)
        Me.cmdCancelar.TabIndex = 20
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(842, 163)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(138, 42)
        Me.cmdEliminar.TabIndex = 19
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(842, 115)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(138, 42)
        Me.cmdEditar.TabIndex = 18
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(842, 67)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(138, 42)
        Me.cmdAgregar.TabIndex = 17
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'frmPacientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.lvPacientesRegistrados)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmPacientes"
        Me.Text = "Pacientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPacientesCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPacientesDNI As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtPacientesApellidos As TextBox
    Friend WithEvents txtPacientesNombres As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPacientesCondiciones As TextBox
    Friend WithEvents txtPacientesDireccion As TextBox
    Friend WithEvents txtPacientesCorreo As TextBox
    Friend WithEvents txtPacientesTelefono As TextBox
    Friend WithEvents txtPacientesSexo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpPacientesFechaNacimiento As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents lvPacientesRegistrados As ListView
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents ListaImagenesBotones As ImageList
End Class
