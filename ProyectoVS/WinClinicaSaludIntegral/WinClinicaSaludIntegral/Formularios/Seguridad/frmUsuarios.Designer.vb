<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarios))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuariosCodigo = New System.Windows.Forms.TextBox()
        Me.UsuariosUltimoAcceso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosRol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosClave = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpUsuariosUltimoAcceso = New System.Windows.Forms.DateTimePicker()
        Me.txtUsuariosClave = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUsuariosRol = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUsuariosNombre = New System.Windows.Forms.TextBox()
        Me.lvUsuariosRegistrados = New System.Windows.Forms.ListView()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nombre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 365)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(191, 20)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Usuarios Registrados"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(782, 76)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(183, 44)
        Me.cmdAgregar.TabIndex = 72
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
        Me.cmdEditar.Location = New System.Drawing.Point(782, 129)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(183, 44)
        Me.cmdEditar.TabIndex = 73
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
        Me.cmdEliminar.Location = New System.Drawing.Point(782, 182)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(183, 44)
        Me.cmdEliminar.TabIndex = 74
        Me.cmdEliminar.Text = "Eliminar "
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Usuarios"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtUsuariosCodigo
        '
        Me.txtUsuariosCodigo.Location = New System.Drawing.Point(320, 62)
        Me.txtUsuariosCodigo.MaxLength = 7
        Me.txtUsuariosCodigo.Name = "txtUsuariosCodigo"
        Me.txtUsuariosCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtUsuariosCodigo.TabIndex = 3
        '
        'UsuariosUltimoAcceso
        '
        Me.UsuariosUltimoAcceso.Text = "Ultimo Acceso"
        Me.UsuariosUltimoAcceso.Width = 205
        '
        'UsuariosRol
        '
        Me.UsuariosRol.Text = "Rol"
        Me.UsuariosRol.Width = 148
        '
        'UsuariosClave
        '
        Me.UsuariosClave.Text = "Clave"
        Me.UsuariosClave.Width = 207
        '
        'UsuariosNombre
        '
        Me.UsuariosNombre.Text = "Nombre"
        Me.UsuariosNombre.Width = 187
        '
        'UsuariosCodigo
        '
        Me.UsuariosCodigo.Text = "Código"
        Me.UsuariosCodigo.Width = 218
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(782, 288)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(183, 44)
        Me.cmdCerrar.TabIndex = 76
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(782, 235)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(183, 44)
        Me.cmdCancelar.TabIndex = 75
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpUsuariosUltimoAcceso)
        Me.GroupBox1.Controls.Add(Me.txtUsuariosClave)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtUsuariosRol)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtUsuariosNombre)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtUsuariosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(768, 280)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuario"
        '
        'dtpUsuariosUltimoAcceso
        '
        Me.dtpUsuariosUltimoAcceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUsuariosUltimoAcceso.Location = New System.Drawing.Point(320, 240)
        Me.dtpUsuariosUltimoAcceso.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpUsuariosUltimoAcceso.Name = "dtpUsuariosUltimoAcceso"
        Me.dtpUsuariosUltimoAcceso.Size = New System.Drawing.Size(167, 27)
        Me.dtpUsuariosUltimoAcceso.TabIndex = 22
        '
        'txtUsuariosClave
        '
        Me.txtUsuariosClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsuariosClave.Location = New System.Drawing.Point(320, 154)
        Me.txtUsuariosClave.MaxLength = 30
        Me.txtUsuariosClave.Name = "txtUsuariosClave"
        Me.txtUsuariosClave.Size = New System.Drawing.Size(442, 27)
        Me.txtUsuariosClave.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 20)
        Me.Label9.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 240)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Ultimo Acceso"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Rol"
        '
        'txtUsuariosRol
        '
        Me.txtUsuariosRol.Location = New System.Drawing.Point(320, 194)
        Me.txtUsuariosRol.MaxLength = 12
        Me.txtUsuariosRol.Name = "txtUsuariosRol"
        Me.txtUsuariosRol.Size = New System.Drawing.Size(142, 27)
        Me.txtUsuariosRol.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Clave"
        '
        'txtUsuariosNombre
        '
        Me.txtUsuariosNombre.Location = New System.Drawing.Point(320, 106)
        Me.txtUsuariosNombre.MaxLength = 50
        Me.txtUsuariosNombre.Name = "txtUsuariosNombre"
        Me.txtUsuariosNombre.Size = New System.Drawing.Size(442, 27)
        Me.txtUsuariosNombre.TabIndex = 5
        '
        'lvUsuariosRegistrados
        '
        Me.lvUsuariosRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsuariosRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UsuariosCodigo, Me.UsuariosNombre, Me.UsuariosClave, Me.UsuariosRol, Me.UsuariosUltimoAcceso})
        Me.lvUsuariosRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvUsuariosRegistrados.FullRowSelect = True
        Me.lvUsuariosRegistrados.GridLines = True
        Me.lvUsuariosRegistrados.HideSelection = False
        Me.lvUsuariosRegistrados.Location = New System.Drawing.Point(8, 391)
        Me.lvUsuariosRegistrados.Name = "lvUsuariosRegistrados"
        Me.lvUsuariosRegistrados.Size = New System.Drawing.Size(957, 188)
        Me.lvUsuariosRegistrados.TabIndex = 80
        Me.lvUsuariosRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvUsuariosRegistrados.View = System.Windows.Forms.View.Details
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(782, 341)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(183, 44)
        Me.cmdEliminados.TabIndex = 77
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 575)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 78
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvUsuariosRegistrados)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmUsuarios"
        Me.Text = "Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsuariosCodigo As TextBox
    Friend WithEvents UsuariosUltimoAcceso As ColumnHeader
    Friend WithEvents UsuariosRol As ColumnHeader
    Friend WithEvents UsuariosClave As ColumnHeader
    Friend WithEvents UsuariosNombre As ColumnHeader
    Friend WithEvents UsuariosCodigo As ColumnHeader
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtUsuariosClave As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUsuariosRol As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUsuariosNombre As TextBox
    Friend WithEvents lvUsuariosRegistrados As ListView
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpUsuariosUltimoAcceso As DateTimePicker
End Class
