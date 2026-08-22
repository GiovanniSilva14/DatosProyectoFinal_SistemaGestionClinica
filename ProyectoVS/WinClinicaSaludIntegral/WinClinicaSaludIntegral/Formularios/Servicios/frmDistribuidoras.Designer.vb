<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDistribuidoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDistribuidoras))
        Me.txtDistribuidorasDireccion = New System.Windows.Forms.TextBox()
        Me.txtDistribuidorasCorreo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDistribuidorasContacto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDistribuidorasTelefono = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDistribuidorasRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDistribuidorasRUC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDistribuidorasCodigo = New System.Windows.Forms.TextBox()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.lvDistribuidorasRegistradas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDistribuidorasDireccion
        '
        Me.txtDistribuidorasDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDistribuidorasDireccion.Location = New System.Drawing.Point(179, 184)
        Me.txtDistribuidorasDireccion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasDireccion.MaxLength = 200
        Me.txtDistribuidorasDireccion.Name = "txtDistribuidorasDireccion"
        Me.txtDistribuidorasDireccion.Size = New System.Drawing.Size(496, 27)
        Me.txtDistribuidorasDireccion.TabIndex = 17
        '
        'txtDistribuidorasCorreo
        '
        Me.txtDistribuidorasCorreo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDistribuidorasCorreo.Location = New System.Drawing.Point(179, 152)
        Me.txtDistribuidorasCorreo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasCorreo.MaxLength = 100
        Me.txtDistribuidorasCorreo.Name = "txtDistribuidorasCorreo"
        Me.txtDistribuidorasCorreo.Size = New System.Drawing.Size(496, 27)
        Me.txtDistribuidorasCorreo.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 348)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(235, 20)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Distribuidoras Registradas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasContacto)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasTelefono)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasDireccion)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasCorreo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasRazonSocial)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasRUC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 57)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(698, 268)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Distribuidora"
        '
        'txtDistribuidorasContacto
        '
        Me.txtDistribuidorasContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDistribuidorasContacto.Location = New System.Drawing.Point(180, 216)
        Me.txtDistribuidorasContacto.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasContacto.MaxLength = 100
        Me.txtDistribuidorasContacto.Name = "txtDistribuidorasContacto"
        Me.txtDistribuidorasContacto.Size = New System.Drawing.Size(495, 27)
        Me.txtDistribuidorasContacto.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 223)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 20)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Contacto"
        '
        'txtDistribuidorasTelefono
        '
        Me.txtDistribuidorasTelefono.Location = New System.Drawing.Point(180, 120)
        Me.txtDistribuidorasTelefono.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasTelefono.MaxLength = 9
        Me.txtDistribuidorasTelefono.Name = "txtDistribuidorasTelefono"
        Me.txtDistribuidorasTelefono.Size = New System.Drawing.Size(118, 27)
        Me.txtDistribuidorasTelefono.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 191)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Dirección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 159)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Correo"
        '
        'txtDistribuidorasRazonSocial
        '
        Me.txtDistribuidorasRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDistribuidorasRazonSocial.Location = New System.Drawing.Point(180, 88)
        Me.txtDistribuidorasRazonSocial.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasRazonSocial.MaxLength = 150
        Me.txtDistribuidorasRazonSocial.Name = "txtDistribuidorasRazonSocial"
        Me.txtDistribuidorasRazonSocial.Size = New System.Drawing.Size(495, 27)
        Me.txtDistribuidorasRazonSocial.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 127)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Teléfono"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Razón Social"
        '
        'txtDistribuidorasRUC
        '
        Me.txtDistribuidorasRUC.Location = New System.Drawing.Point(179, 56)
        Me.txtDistribuidorasRUC.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasRUC.MaxLength = 11
        Me.txtDistribuidorasRUC.Name = "txtDistribuidorasRUC"
        Me.txtDistribuidorasRUC.Size = New System.Drawing.Size(119, 27)
        Me.txtDistribuidorasRUC.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 63)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "RUC"
        '
        'txtDistribuidorasCodigo
        '
        Me.txtDistribuidorasCodigo.Location = New System.Drawing.Point(180, 24)
        Me.txtDistribuidorasCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDistribuidorasCodigo.MaxLength = 7
        Me.txtDistribuidorasCodigo.Name = "txtDistribuidorasCodigo"
        Me.txtDistribuidorasCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtDistribuidorasCodigo.TabIndex = 3
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(759, 57)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(179, 42)
        Me.cmdAgregar.TabIndex = 47
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
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
        'lvDistribuidorasRegistradas
        '
        Me.lvDistribuidorasRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDistribuidorasRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lvDistribuidorasRegistradas.FullRowSelect = True
        Me.lvDistribuidorasRegistradas.GridLines = True
        Me.lvDistribuidorasRegistradas.HideSelection = False
        Me.lvDistribuidorasRegistradas.Location = New System.Drawing.Point(8, 383)
        Me.lvDistribuidorasRegistradas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvDistribuidorasRegistradas.MinimumSize = New System.Drawing.Size(956, 197)
        Me.lvDistribuidorasRegistradas.Name = "lvDistribuidorasRegistradas"
        Me.lvDistribuidorasRegistradas.Size = New System.Drawing.Size(956, 197)
        Me.lvDistribuidorasRegistradas.TabIndex = 46
        Me.lvDistribuidorasRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvDistribuidorasRegistradas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 71
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "RUC"
        Me.ColumnHeader2.Width = 143
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Razón Social"
        Me.ColumnHeader3.Width = 143
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Teléfono"
        Me.ColumnHeader4.Width = 87
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Correo"
        Me.ColumnHeader5.Width = 181
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Dirección"
        Me.ColumnHeader6.Width = 182
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Contacto"
        Me.ColumnHeader7.Width = 218
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
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Distribuidoras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(759, 287)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminados.TabIndex = 52
        Me.cmdEliminados.Text = "Eliminados"
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(759, 195)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCancelar.TabIndex = 50
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(759, 103)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEditar.TabIndex = 48
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(759, 241)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCerrar.TabIndex = 51
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(759, 149)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminar.TabIndex = 49
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'frmDistribuidoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.lvDistribuidorasRegistradas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmDistribuidoras"
        Me.Text = "Distribuidoras"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDistribuidorasDireccion As TextBox
    Friend WithEvents txtDistribuidorasCorreo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtDistribuidorasTelefono As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtDistribuidorasRazonSocial As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDistribuidorasRUC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDistribuidorasCodigo As TextBox
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents lvDistribuidorasRegistradas As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents txtDistribuidorasContacto As TextBox
    Friend WithEvents Label8 As Label
End Class
