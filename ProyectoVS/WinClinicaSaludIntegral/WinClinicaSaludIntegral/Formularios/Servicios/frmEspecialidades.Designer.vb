<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEspecialidades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEspecialidades))
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtEspecialidadesDescripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lvEspecialidadesRegistradas = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtEspecialidadesNombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEspecialidadesCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 221
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width = 88
        '
        'txtEspecialidadesDescripcion
        '
        Me.txtEspecialidadesDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEspecialidadesDescripcion.Location = New System.Drawing.Point(155, 149)
        Me.txtEspecialidadesDescripcion.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEspecialidadesDescripcion.MaxLength = 250
        Me.txtEspecialidadesDescripcion.Name = "txtEspecialidadesDescripcion"
        Me.txtEspecialidadesDescripcion.Size = New System.Drawing.Size(508, 27)
        Me.txtEspecialidadesDescripcion.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 152)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción"
        '
        'lvEspecialidadesRegistradas
        '
        Me.lvEspecialidadesRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEspecialidadesRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvEspecialidadesRegistradas.FullRowSelect = True
        Me.lvEspecialidadesRegistradas.GridLines = True
        Me.lvEspecialidadesRegistradas.HideSelection = False
        Me.lvEspecialidadesRegistradas.Location = New System.Drawing.Point(8, 344)
        Me.lvEspecialidadesRegistradas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvEspecialidadesRegistradas.MinimumSize = New System.Drawing.Size(728, 236)
        Me.lvEspecialidadesRegistradas.Name = "lvEspecialidadesRegistradas"
        Me.lvEspecialidadesRegistradas.Size = New System.Drawing.Size(728, 236)
        Me.lvEspecialidadesRegistradas.TabIndex = 36
        Me.lvEspecialidadesRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvEspecialidadesRegistradas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Descripción"
        Me.ColumnHeader3.Width = 420
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 305)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(243, 20)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Especialidades Registradas"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(754, 248)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCerrar.TabIndex = 41
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtEspecialidadesDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtEspecialidadesNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtEspecialidadesCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 64)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(667, 225)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Especialidad"
        '
        'txtEspecialidadesNombre
        '
        Me.txtEspecialidadesNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEspecialidadesNombre.Location = New System.Drawing.Point(155, 102)
        Me.txtEspecialidadesNombre.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEspecialidadesNombre.MaxLength = 100
        Me.txtEspecialidadesNombre.Name = "txtEspecialidadesNombre"
        Me.txtEspecialidadesNombre.Size = New System.Drawing.Size(508, 27)
        Me.txtEspecialidadesNombre.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 102)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nombre"
        '
        'txtEspecialidadesCodigo
        '
        Me.txtEspecialidadesCodigo.Location = New System.Drawing.Point(155, 48)
        Me.txtEspecialidadesCodigo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEspecialidadesCodigo.MaxLength = 7
        Me.txtEspecialidadesCodigo.Name = "txtEspecialidadesCodigo"
        Me.txtEspecialidadesCodigo.Size = New System.Drawing.Size(118, 27)
        Me.txtEspecialidadesCodigo.TabIndex = 3
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
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Especialidades"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(754, 294)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminados.TabIndex = 42
        Me.cmdEliminados.Text = "Eliminados"
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(754, 202)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(179, 42)
        Me.cmdCancelar.TabIndex = 40
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(754, 110)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEditar.TabIndex = 38
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(754, 64)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(179, 42)
        Me.cmdAgregar.TabIndex = 37
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(754, 156)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(2)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(179, 42)
        Me.cmdEliminar.TabIndex = 39
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'frmEspecialidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.lvEspecialidadesRegistradas)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmEspecialidades"
        Me.Text = "Especialidades"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents txtEspecialidadesDescripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lvEspecialidadesRegistradas As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtEspecialidadesNombre As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEspecialidadesCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEliminar As Button
End Class
