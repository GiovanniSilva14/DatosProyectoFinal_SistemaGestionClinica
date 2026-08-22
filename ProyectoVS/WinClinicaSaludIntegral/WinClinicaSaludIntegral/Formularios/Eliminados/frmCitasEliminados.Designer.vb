<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCitasEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCitasEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvCitasEliminadas = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoMedico = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoConsultorio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Hora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Motivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Condiciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(848, 58)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Citas Eliminadas "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(735, 313)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(621, 313)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvCitasEliminadas
        '
        Me.lvCitasEliminadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCitasEliminadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoPaciente, Me.CodigoMedico, Me.CodigoConsultorio, Me.Fecha, Me.Hora, Me.Motivo, Me.Condiciones})
        Me.lvCitasEliminadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCitasEliminadas.FullRowSelect = True
        Me.lvCitasEliminadas.GridLines = True
        Me.lvCitasEliminadas.HideSelection = False
        Me.lvCitasEliminadas.Location = New System.Drawing.Point(8, 82)
        Me.lvCitasEliminadas.MinimumSize = New System.Drawing.Size(828, 225)
        Me.lvCitasEliminadas.Name = "lvCitasEliminadas"
        Me.lvCitasEliminadas.Size = New System.Drawing.Size(828, 225)
        Me.lvCitasEliminadas.TabIndex = 26
        Me.lvCitasEliminadas.UseCompatibleStateImageBehavior = False
        Me.lvCitasEliminadas.View = System.Windows.Forms.View.Details
        '
        'Código
        '
        Me.Código.Text = "Código "
        Me.Código.Width = 77
        '
        'CodigoPaciente
        '
        Me.CodigoPaciente.Text = "Código Paciente"
        Me.CodigoPaciente.Width = 139
        '
        'CodigoMedico
        '
        Me.CodigoMedico.Text = "Código Medico"
        Me.CodigoMedico.Width = 126
        '
        'CodigoConsultorio
        '
        Me.CodigoConsultorio.Text = "Código Consultorio"
        Me.CodigoConsultorio.Width = 162
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 66
        '
        'Hora
        '
        Me.Hora.Text = "Hora"
        Me.Hora.Width = 56
        '
        'Motivo
        '
        Me.Motivo.Text = "Motivo"
        Me.Motivo.Width = 74
        '
        'Condiciones
        '
        Me.Condiciones.Text = "Condiciones"
        Me.Condiciones.Width = 129
        '
        'frmCitasEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 384)
        Me.Controls.Add(Me.lvCitasEliminadas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(866, 431)
        Me.Name = "frmCitasEliminados"
        Me.Text = "Citas Eliminadas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvCitasEliminadas As ListView
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents CodigoMedico As ColumnHeader
    Friend WithEvents CodigoConsultorio As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Hora As ColumnHeader
    Friend WithEvents Motivo As ColumnHeader
    Friend WithEvents Condiciones As ColumnHeader
End Class
