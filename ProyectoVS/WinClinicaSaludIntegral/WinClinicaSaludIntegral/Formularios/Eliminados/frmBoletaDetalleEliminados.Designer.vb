<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoletaDetalleEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoletaDetalleEliminados))
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvBoletaDetalleEliminados = New System.Windows.Forms.ListView()
        Me.BoletaDetalleCódigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaFacturaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetallePrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleImporte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
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
        Me.Label1.Text = "Boletas Detalles Eliminadas "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvBoletaDetalleEliminados
        '
        Me.lvBoletaDetalleEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBoletaDetalleEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BoletaDetalleCódigo, Me.BoletaFacturaCodigo, Me.BoletaDetalleConcepto, Me.BoletaDetalleCantidad, Me.BoletaDetallePrecio, Me.BoletaDetalleImporte})
        Me.lvBoletaDetalleEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBoletaDetalleEliminados.FullRowSelect = True
        Me.lvBoletaDetalleEliminados.GridLines = True
        Me.lvBoletaDetalleEliminados.HideSelection = False
        Me.lvBoletaDetalleEliminados.Location = New System.Drawing.Point(8, 88)
        Me.lvBoletaDetalleEliminados.MinimumSize = New System.Drawing.Size(773, 219)
        Me.lvBoletaDetalleEliminados.Name = "lvBoletaDetalleEliminados"
        Me.lvBoletaDetalleEliminados.Size = New System.Drawing.Size(773, 219)
        Me.lvBoletaDetalleEliminados.TabIndex = 70
        Me.lvBoletaDetalleEliminados.UseCompatibleStateImageBehavior = False
        Me.lvBoletaDetalleEliminados.View = System.Windows.Forms.View.Details
        '
        'BoletaDetalleCódigo
        '
        Me.BoletaDetalleCódigo.Text = "Código"
        Me.BoletaDetalleCódigo.Width = 65
        '
        'BoletaFacturaCodigo
        '
        Me.BoletaFacturaCodigo.Text = "Boleta Código"
        Me.BoletaFacturaCodigo.Width = 117
        '
        'BoletaDetalleConcepto
        '
        Me.BoletaDetalleConcepto.Text = "Concepto"
        Me.BoletaDetalleConcepto.Width = 244
        '
        'BoletaDetalleCantidad
        '
        Me.BoletaDetalleCantidad.Text = "Cantidad"
        Me.BoletaDetalleCantidad.Width = 108
        '
        'BoletaDetallePrecio
        '
        Me.BoletaDetallePrecio.Text = "Precio"
        Me.BoletaDetallePrecio.Width = 93
        '
        'BoletaDetalleImporte
        '
        Me.BoletaDetalleImporte.Text = "Importe"
        Me.BoletaDetalleImporte.Width = 128
        '
        'frmBoletaDetalleEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 360)
        Me.Controls.Add(Me.lvBoletaDetalleEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(818, 407)
        Me.Name = "frmBoletaDetalleEliminados"
        Me.Text = "Boleta Detalle Eliminados"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lvBoletaDetalleEliminados As ListView
    Friend WithEvents BoletaDetalleCódigo As ColumnHeader
    Friend WithEvents BoletaFacturaCodigo As ColumnHeader
    Friend WithEvents BoletaDetalleConcepto As ColumnHeader
    Friend WithEvents BoletaDetalleCantidad As ColumnHeader
    Friend WithEvents BoletaDetallePrecio As ColumnHeader
    Friend WithEvents BoletaDetalleImporte As ColumnHeader
End Class
