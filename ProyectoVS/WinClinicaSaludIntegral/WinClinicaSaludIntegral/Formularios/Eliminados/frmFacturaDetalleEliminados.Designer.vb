<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaDetalleEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaDetalleEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvFacturaDetalleEliminados = New System.Windows.Forms.ListView()
        Me.FacturaDetalleCódigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetallePrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleImporte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Text = "Facturas Detalles Eliminados "
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
        'lvFacturaDetalleEliminados
        '
        Me.lvFacturaDetalleEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFacturaDetalleEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FacturaDetalleCódigo, Me.FacturaCodigo, Me.FacturaDetalleConcepto, Me.FacturaDetalleCantidad, Me.FacturaDetallePrecio, Me.FacturaDetalleImporte})
        Me.lvFacturaDetalleEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFacturaDetalleEliminados.FullRowSelect = True
        Me.lvFacturaDetalleEliminados.GridLines = True
        Me.lvFacturaDetalleEliminados.HideSelection = False
        Me.lvFacturaDetalleEliminados.Location = New System.Drawing.Point(12, 94)
        Me.lvFacturaDetalleEliminados.MinimumSize = New System.Drawing.Size(776, 231)
        Me.lvFacturaDetalleEliminados.Name = "lvFacturaDetalleEliminados"
        Me.lvFacturaDetalleEliminados.Size = New System.Drawing.Size(776, 231)
        Me.lvFacturaDetalleEliminados.TabIndex = 59
        Me.lvFacturaDetalleEliminados.UseCompatibleStateImageBehavior = False
        Me.lvFacturaDetalleEliminados.View = System.Windows.Forms.View.Details
        '
        'FacturaDetalleCódigo
        '
        Me.FacturaDetalleCódigo.Text = "Código"
        Me.FacturaDetalleCódigo.Width = 78
        '
        'FacturaCodigo
        '
        Me.FacturaCodigo.Text = "Factura Código"
        Me.FacturaCodigo.Width = 144
        '
        'FacturaDetalleConcepto
        '
        Me.FacturaDetalleConcepto.Text = "Concepto"
        Me.FacturaDetalleConcepto.Width = 116
        '
        'FacturaDetalleCantidad
        '
        Me.FacturaDetalleCantidad.Text = "Cantidad"
        Me.FacturaDetalleCantidad.Width = 157
        '
        'FacturaDetallePrecio
        '
        Me.FacturaDetallePrecio.Text = "Precio"
        Me.FacturaDetallePrecio.Width = 129
        '
        'FacturaDetalleImporte
        '
        Me.FacturaDetalleImporte.Text = "Importe"
        Me.FacturaDetalleImporte.Width = 172
        '
        'frmFacturaDetalleEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 390)
        Me.Controls.Add(Me.lvFacturaDetalleEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 437)
        Me.Name = "frmFacturaDetalleEliminados"
        Me.Text = "Factura Detalle Eliminados"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvFacturaDetalleEliminados As ListView
    Friend WithEvents FacturaDetalleCódigo As ColumnHeader
    Friend WithEvents FacturaCodigo As ColumnHeader
    Friend WithEvents FacturaDetalleConcepto As ColumnHeader
    Friend WithEvents FacturaDetalleCantidad As ColumnHeader
    Friend WithEvents FacturaDetallePrecio As ColumnHeader
    Friend WithEvents FacturaDetalleImporte As ColumnHeader
End Class
