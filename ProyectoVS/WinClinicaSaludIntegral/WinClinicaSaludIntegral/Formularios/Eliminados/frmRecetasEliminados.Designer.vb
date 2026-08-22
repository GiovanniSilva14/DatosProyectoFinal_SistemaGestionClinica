<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecetasEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecetasEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvRecetasEliminadas = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoHistoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoMedico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoRecetaCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Diagnostico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Indicaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Observaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(982, 58)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Recetas Eliminadas "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(866, 239)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(752, 239)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvRecetasEliminadas
        '
        Me.lvRecetasEliminadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvRecetasEliminadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoHistoria, Me.CodigoMedico, Me.CodigoRecetaCategoria, Me.Fecha, Me.Diagnostico, Me.Indicaciones, Me.Observaciones})
        Me.lvRecetasEliminadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRecetasEliminadas.FullRowSelect = True
        Me.lvRecetasEliminadas.GridLines = True
        Me.lvRecetasEliminadas.HideSelection = False
        Me.lvRecetasEliminadas.Location = New System.Drawing.Point(11, 80)
        Me.lvRecetasEliminadas.Margin = New System.Windows.Forms.Padding(2)
        Me.lvRecetasEliminadas.MinimumSize = New System.Drawing.Size(956, 154)
        Me.lvRecetasEliminadas.Name = "lvRecetasEliminadas"
        Me.lvRecetasEliminadas.Size = New System.Drawing.Size(956, 154)
        Me.lvRecetasEliminadas.TabIndex = 37
        Me.lvRecetasEliminadas.UseCompatibleStateImageBehavior = False
        Me.lvRecetasEliminadas.View = System.Windows.Forms.View.Details
        '
        'Código
        '
        Me.Código.Text = "Código"
        Me.Código.Width = 73
        '
        'CodigoHistoria
        '
        Me.CodigoHistoria.Text = "Código Historia"
        Me.CodigoHistoria.Width = 133
        '
        'CodigoMedico
        '
        Me.CodigoMedico.Text = "Código Médico"
        Me.CodigoMedico.Width = 124
        '
        'CodigoRecetaCategoria
        '
        Me.CodigoRecetaCategoria.Text = "Código Receta Categoría"
        Me.CodigoRecetaCategoria.Width = 204
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 61
        '
        'Diagnostico
        '
        Me.Diagnostico.Text = "Diagnóstico"
        Me.Diagnostico.Width = 105
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
        'frmRecetasEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 292)
        Me.Controls.Add(Me.lvRecetasEliminadas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1000, 339)
        Me.Name = "frmRecetasEliminados"
        Me.Text = "Recetas Eliminados"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvRecetasEliminadas As ListView
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents CodigoHistoria As ColumnHeader
    Friend WithEvents CodigoMedico As ColumnHeader
    Friend WithEvents CodigoRecetaCategoria As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Diagnostico As ColumnHeader
    Friend WithEvents Indicaciones As ColumnHeader
    Friend WithEvents Observaciones As ColumnHeader
End Class
