<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosMedicosEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuariosMedicosEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvUsuariosMedicosEliminados = New System.Windows.Forms.ListView()
        Me.UsuariosEmpleadosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuariosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EmpleadosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Text = "Usuarios Médicos Eliminados "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(680, 295)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(566, 295)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvUsuariosMedicosEliminados
        '
        Me.lvUsuariosMedicosEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsuariosMedicosEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UsuariosEmpleadosCodigo, Me.UsuariosCodigo, Me.EmpleadosCodigo})
        Me.lvUsuariosMedicosEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvUsuariosMedicosEliminados.FullRowSelect = True
        Me.lvUsuariosMedicosEliminados.GridLines = True
        Me.lvUsuariosMedicosEliminados.HideSelection = False
        Me.lvUsuariosMedicosEliminados.Location = New System.Drawing.Point(8, 93)
        Me.lvUsuariosMedicosEliminados.MinimumSize = New System.Drawing.Size(773, 196)
        Me.lvUsuariosMedicosEliminados.Name = "lvUsuariosMedicosEliminados"
        Me.lvUsuariosMedicosEliminados.Size = New System.Drawing.Size(773, 196)
        Me.lvUsuariosMedicosEliminados.TabIndex = 103
        Me.lvUsuariosMedicosEliminados.UseCompatibleStateImageBehavior = False
        Me.lvUsuariosMedicosEliminados.View = System.Windows.Forms.View.Details
        '
        'UsuariosEmpleadosCodigo
        '
        Me.UsuariosEmpleadosCodigo.Text = "Código"
        Me.UsuariosEmpleadosCodigo.Width = 218
        '
        'UsuariosCodigo
        '
        Me.UsuariosCodigo.Text = "Código Usuario"
        Me.UsuariosCodigo.Width = 252
        '
        'EmpleadosCodigo
        '
        Me.EmpleadosCodigo.Text = "Código Empleado"
        Me.EmpleadosCodigo.Width = 336
        '
        'frmUsuariosMedicosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 341)
        Me.Controls.Add(Me.lvUsuariosMedicosEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 388)
        Me.Name = "frmUsuariosMedicosEliminados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios Medicos Eliminados"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvUsuariosMedicosEliminados As ListView
    Friend WithEvents UsuariosEmpleadosCodigo As ColumnHeader
    Friend WithEvents UsuariosCodigo As ColumnHeader
    Friend WithEvents EmpleadosCodigo As ColumnHeader
End Class
