<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturasEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturasEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvFacturasEliminadas = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoEmpleado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SubTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IGV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(816, 58)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Facturas Eliminadas "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(680, 331)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(566, 331)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 23
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvFacturasEliminadas
        '
        Me.lvFacturasEliminadas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFacturasEliminadas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoPaciente, Me.CodigoEmpleado, Me.Fecha, Me.SubTotal, Me.IGV, Me.Total})
        Me.lvFacturasEliminadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFacturasEliminadas.FullRowSelect = True
        Me.lvFacturasEliminadas.GridLines = True
        Me.lvFacturasEliminadas.HideSelection = False
        Me.lvFacturasEliminadas.Location = New System.Drawing.Point(13, 85)
        Me.lvFacturasEliminadas.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFacturasEliminadas.MinimumSize = New System.Drawing.Size(790, 239)
        Me.lvFacturasEliminadas.Name = "lvFacturasEliminadas"
        Me.lvFacturasEliminadas.Size = New System.Drawing.Size(790, 239)
        Me.lvFacturasEliminadas.TabIndex = 48
        Me.lvFacturasEliminadas.UseCompatibleStateImageBehavior = False
        Me.lvFacturasEliminadas.View = System.Windows.Forms.View.Details
        '
        'Código
        '
        Me.Código.Text = "Código"
        Me.Código.Width = 78
        '
        'CodigoPaciente
        '
        Me.CodigoPaciente.Text = "Código Paciente"
        Me.CodigoPaciente.Width = 135
        '
        'CodigoEmpleado
        '
        Me.CodigoEmpleado.Text = "Código Empleado"
        Me.CodigoEmpleado.Width = 157
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 83
        '
        'SubTotal
        '
        Me.SubTotal.Text = "Sub Total"
        Me.SubTotal.Width = 130
        '
        'IGV
        '
        Me.IGV.Text = "IGV"
        Me.IGV.Width = 108
        '
        'Total
        '
        Me.Total.Text = "Total"
        Me.Total.Width = 94
        '
        'frmFacturasEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 393)
        Me.Controls.Add(Me.lvFacturasEliminadas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(834, 440)
        Me.Name = "frmFacturasEliminados"
        Me.Text = "Facturas Eliminadas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvFacturasEliminadas As ListView
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents CodigoEmpleado As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents SubTotal As ColumnHeader
    Friend WithEvents IGV As ColumnHeader
    Friend WithEvents Total As ColumnHeader
End Class
