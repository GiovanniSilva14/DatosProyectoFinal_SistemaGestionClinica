<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistoriaClinicaEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistoriaClinicaEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvHistoriaClinicaEliminados = New System.Windows.Forms.ListView()
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaApertura = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrupoSanguineo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.alergia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Antecendentes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Observaciones = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(895, 58)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Historias Clinicas Eliminadas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(782, 280)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(101, 41)
        Me.cmdCerrar.TabIndex = 27
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdRecuperar
        '
        Me.cmdRecuperar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRecuperar.Enabled = False
        Me.cmdRecuperar.Location = New System.Drawing.Point(668, 280)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 26
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvHistoriaClinicaEliminados
        '
        Me.lvHistoriaClinicaEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvHistoriaClinicaEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Codigo, Me.CodigoPaciente, Me.FechaApertura, Me.GrupoSanguineo, Me.alergia, Me.Antecendentes, Me.Observaciones, Me.Condiciones})
        Me.lvHistoriaClinicaEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvHistoriaClinicaEliminados.FullRowSelect = True
        Me.lvHistoriaClinicaEliminados.GridLines = True
        Me.lvHistoriaClinicaEliminados.HideSelection = False
        Me.lvHistoriaClinicaEliminados.Location = New System.Drawing.Point(8, 93)
        Me.lvHistoriaClinicaEliminados.Margin = New System.Windows.Forms.Padding(2)
        Me.lvHistoriaClinicaEliminados.MinimumSize = New System.Drawing.Size(878, 182)
        Me.lvHistoriaClinicaEliminados.Name = "lvHistoriaClinicaEliminados"
        Me.lvHistoriaClinicaEliminados.Size = New System.Drawing.Size(878, 182)
        Me.lvHistoriaClinicaEliminados.TabIndex = 37
        Me.lvHistoriaClinicaEliminados.UseCompatibleStateImageBehavior = False
        Me.lvHistoriaClinicaEliminados.View = System.Windows.Forms.View.Details
        '
        'Codigo
        '
        Me.Codigo.Text = "Código "
        Me.Codigo.Width = 73
        '
        'CodigoPaciente
        '
        Me.CodigoPaciente.Text = "Código Paciente"
        Me.CodigoPaciente.Width = 150
        '
        'FechaApertura
        '
        Me.FechaApertura.Text = "Fecha Apertura"
        Me.FechaApertura.Width = 133
        '
        'GrupoSanguineo
        '
        Me.GrupoSanguineo.Text = "Grupo Sanguíneo"
        Me.GrupoSanguineo.Width = 145
        '
        'alergia
        '
        Me.alergia.Text = "Alergía "
        Me.alergia.Width = 74
        '
        'Antecendentes
        '
        Me.Antecendentes.Text = "Antecendentes"
        Me.Antecendentes.Width = 125
        '
        'Observaciones
        '
        Me.Observaciones.Text = "Observaciones"
        Me.Observaciones.Width = 129
        '
        'Condiciones
        '
        Me.Condiciones.Text = ""
        Me.Condiciones.Width = 0
        '
        'frmHistoriaClinicaEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 339)
        Me.Controls.Add(Me.lvHistoriaClinicaEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(913, 386)
        Me.Name = "frmHistoriaClinicaEliminados"
        Me.Text = "Historia Clinica Eliminados"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvHistoriaClinicaEliminados As ListView
    Friend WithEvents Codigo As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents FechaApertura As ColumnHeader
    Friend WithEvents GrupoSanguineo As ColumnHeader
    Friend WithEvents alergia As ColumnHeader
    Friend WithEvents Antecendentes As ColumnHeader
    Friend WithEvents Observaciones As ColumnHeader
    Friend WithEvents Condiciones As ColumnHeader
End Class
