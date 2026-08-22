<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecetaLaboratoriosEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecetaLaboratoriosEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvRecetaLaboratoriosEliminados = New System.Windows.Forms.ListView()
        Me.LaboratoriosCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RecetaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosExamen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosResultado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LaboratoriosObservaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Text = "Receta Laboratorios Eliminados "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(680, 313)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(566, 313)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvRecetaLaboratoriosEliminados
        '
        Me.lvRecetaLaboratoriosEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvRecetaLaboratoriosEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LaboratoriosCodigo, Me.RecetaCodigo, Me.LaboratoriosExamen, Me.LaboratoriosResultado, Me.LaboratoriosFecha, Me.LaboratoriosObservaciones})
        Me.lvRecetaLaboratoriosEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRecetaLaboratoriosEliminados.FullRowSelect = True
        Me.lvRecetaLaboratoriosEliminados.GridLines = True
        Me.lvRecetaLaboratoriosEliminados.HideSelection = False
        Me.lvRecetaLaboratoriosEliminados.Location = New System.Drawing.Point(21, 80)
        Me.lvRecetaLaboratoriosEliminados.MinimumSize = New System.Drawing.Size(760, 227)
        Me.lvRecetaLaboratoriosEliminados.Name = "lvRecetaLaboratoriosEliminados"
        Me.lvRecetaLaboratoriosEliminados.Size = New System.Drawing.Size(760, 227)
        Me.lvRecetaLaboratoriosEliminados.TabIndex = 37
        Me.lvRecetaLaboratoriosEliminados.UseCompatibleStateImageBehavior = False
        Me.lvRecetaLaboratoriosEliminados.View = System.Windows.Forms.View.Details
        '
        'LaboratoriosCodigo
        '
        Me.LaboratoriosCodigo.Text = "Código"
        Me.LaboratoriosCodigo.Width = 68
        '
        'RecetaCodigo
        '
        Me.RecetaCodigo.Text = "Código Receta"
        Me.RecetaCodigo.Width = 123
        '
        'LaboratoriosExamen
        '
        Me.LaboratoriosExamen.Text = "Examen"
        Me.LaboratoriosExamen.Width = 81
        '
        'LaboratoriosResultado
        '
        Me.LaboratoriosResultado.Text = "Resultado"
        Me.LaboratoriosResultado.Width = 162
        '
        'LaboratoriosFecha
        '
        Me.LaboratoriosFecha.Text = "Fecha"
        Me.LaboratoriosFecha.Width = 110
        '
        'LaboratoriosObservaciones
        '
        Me.LaboratoriosObservaciones.Text = "Observaciones"
        Me.LaboratoriosObservaciones.Width = 216
        '
        'frmRecetaLaboratoriosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 362)
        Me.Controls.Add(Me.lvRecetaLaboratoriosEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 409)
        Me.Name = "frmRecetaLaboratoriosEliminados"
        Me.Text = "Receta Laboratorios Eliminados"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvRecetaLaboratoriosEliminados As ListView
    Friend WithEvents LaboratoriosCodigo As ColumnHeader
    Friend WithEvents RecetaCodigo As ColumnHeader
    Friend WithEvents LaboratoriosExamen As ColumnHeader
    Friend WithEvents LaboratoriosResultado As ColumnHeader
    Friend WithEvents LaboratoriosFecha As ColumnHeader
    Friend WithEvents LaboratoriosObservaciones As ColumnHeader
End Class
