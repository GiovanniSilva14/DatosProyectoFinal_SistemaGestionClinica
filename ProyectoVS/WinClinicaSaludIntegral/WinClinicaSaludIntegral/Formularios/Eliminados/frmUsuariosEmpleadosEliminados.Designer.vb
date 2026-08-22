<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosEmpleadosEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuariosEmpleadosEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvUsuariosEmpleadosEliminados = New System.Windows.Forms.ListView()
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
        Me.Label1.Text = "Usuarios Empleados Eliminados "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(687, 298)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(573, 298)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvUsuariosEmpleadosEliminados
        '
        Me.lvUsuariosEmpleadosEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvUsuariosEmpleadosEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UsuariosEmpleadosCodigo, Me.UsuariosCodigo, Me.EmpleadosCodigo})
        Me.lvUsuariosEmpleadosEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvUsuariosEmpleadosEliminados.FullRowSelect = True
        Me.lvUsuariosEmpleadosEliminados.GridLines = True
        Me.lvUsuariosEmpleadosEliminados.HideSelection = False
        Me.lvUsuariosEmpleadosEliminados.Location = New System.Drawing.Point(14, 78)
        Me.lvUsuariosEmpleadosEliminados.MinimumSize = New System.Drawing.Size(774, 199)
        Me.lvUsuariosEmpleadosEliminados.Name = "lvUsuariosEmpleadosEliminados"
        Me.lvUsuariosEmpleadosEliminados.Size = New System.Drawing.Size(774, 199)
        Me.lvUsuariosEmpleadosEliminados.TabIndex = 92
        Me.lvUsuariosEmpleadosEliminados.UseCompatibleStateImageBehavior = False
        Me.lvUsuariosEmpleadosEliminados.View = System.Windows.Forms.View.Details
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
        'frmUsuariosEmpleadosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 345)
        Me.Controls.Add(Me.lvUsuariosEmpleadosEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 392)
        Me.Name = "frmUsuariosEmpleadosEliminados"
        Me.Text = "Usuarios Empleados Eliminados"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvUsuariosEmpleadosEliminados As ListView
    Friend WithEvents UsuariosEmpleadosCodigo As ColumnHeader
    Friend WithEvents UsuariosCodigo As ColumnHeader
    Friend WithEvents EmpleadosCodigo As ColumnHeader
End Class
