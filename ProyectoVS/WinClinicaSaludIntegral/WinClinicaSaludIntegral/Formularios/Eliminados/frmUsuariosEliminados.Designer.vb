<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuariosEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvUsuariosEliminados = New System.Windows.Forms.ListView()
        Me.UsuariosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosClave = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosRol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosUltimoAcceso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Teal
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(800, 58)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Usuarios Eliminados "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(680, 287)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(101, 41)
        Me.cmdCerrar.TabIndex = 24
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdRecuperar
        '
        Me.cmdRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRecuperar.Enabled = False
        Me.cmdRecuperar.Location = New System.Drawing.Point(566, 287)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvUsuariosEliminados
        '
        Me.lvUsuariosEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsuariosEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UsuariosCodigo, Me.UsuariosNombre, Me.UsuariosClave, Me.UsuariosRol, Me.UsuariosUltimoAcceso})
        Me.lvUsuariosEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvUsuariosEliminados.FullRowSelect = True
        Me.lvUsuariosEliminados.GridLines = True
        Me.lvUsuariosEliminados.HideSelection = False
        Me.lvUsuariosEliminados.Location = New System.Drawing.Point(8, 80)
        Me.lvUsuariosEliminados.MinimumSize = New System.Drawing.Size(773, 201)
        Me.lvUsuariosEliminados.Name = "lvUsuariosEliminados"
        Me.lvUsuariosEliminados.Size = New System.Drawing.Size(773, 201)
        Me.lvUsuariosEliminados.TabIndex = 81
        Me.lvUsuariosEliminados.UseCompatibleStateImageBehavior = False
        Me.lvUsuariosEliminados.View = System.Windows.Forms.View.Details
        '
        'UsuariosCodigo
        '
        Me.UsuariosCodigo.Text = "Código"
        Me.UsuariosCodigo.Width = 73
        '
        'UsuariosNombre
        '
        Me.UsuariosNombre.Text = "Nombre"
        Me.UsuariosNombre.Width = 187
        '
        'UsuariosClave
        '
        Me.UsuariosClave.Text = "Clave"
        Me.UsuariosClave.Width = 207
        '
        'UsuariosRol
        '
        Me.UsuariosRol.Text = "Rol"
        Me.UsuariosRol.Width = 148
        '
        'UsuariosUltimoAcceso
        '
        Me.UsuariosUltimoAcceso.Text = "Ultimo Acceso"
        Me.UsuariosUltimoAcceso.Width = 143
        '
        'frmUsuariosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 339)
        Me.Controls.Add(Me.lvUsuariosEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 386)
        Me.Name = "frmUsuariosEliminados"
        Me.Text = "Usuarios Eliminados"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvUsuariosEliminados As ListView
    Friend WithEvents UsuariosCodigo As ColumnHeader
    Friend WithEvents UsuariosNombre As ColumnHeader
    Friend WithEvents UsuariosClave As ColumnHeader
    Friend WithEvents UsuariosRol As ColumnHeader
    Friend WithEvents UsuariosUltimoAcceso As ColumnHeader
End Class
