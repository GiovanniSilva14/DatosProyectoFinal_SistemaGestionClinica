<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicamentosEliminados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicamentosEliminados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRecuperar = New System.Windows.Forms.Button()
        Me.lvMedicamentosEliminados = New System.Windows.Forms.ListView()
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoDistribuidora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Presentacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Stock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaVencimiento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.Label1.Size = New System.Drawing.Size(975, 58)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Medicamentos Eliminados"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(860, 263)
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
        Me.cmdRecuperar.Location = New System.Drawing.Point(746, 263)
        Me.cmdRecuperar.Name = "cmdRecuperar"
        Me.cmdRecuperar.Size = New System.Drawing.Size(101, 41)
        Me.cmdRecuperar.TabIndex = 26
        Me.cmdRecuperar.Text = "Recuperar"
        Me.cmdRecuperar.UseVisualStyleBackColor = True
        '
        'lvMedicamentosEliminados
        '
        Me.lvMedicamentosEliminados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMedicamentosEliminados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Codigo, Me.CodigoDistribuidora, Me.Nombre, Me.Presentacion, Me.Stock, Me.Precio, Me.FechaVencimiento, Me.Descripcion})
        Me.lvMedicamentosEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMedicamentosEliminados.FullRowSelect = True
        Me.lvMedicamentosEliminados.GridLines = True
        Me.lvMedicamentosEliminados.HideSelection = False
        Me.lvMedicamentosEliminados.Location = New System.Drawing.Point(8, 91)
        Me.lvMedicamentosEliminados.MinimumSize = New System.Drawing.Size(953, 157)
        Me.lvMedicamentosEliminados.Name = "lvMedicamentosEliminados"
        Me.lvMedicamentosEliminados.Size = New System.Drawing.Size(953, 157)
        Me.lvMedicamentosEliminados.TabIndex = 37
        Me.lvMedicamentosEliminados.UseCompatibleStateImageBehavior = False
        Me.lvMedicamentosEliminados.View = System.Windows.Forms.View.Details
        '
        'Codigo
        '
        Me.Codigo.Text = "Código"
        Me.Codigo.Width = 69
        '
        'CodigoDistribuidora
        '
        Me.CodigoDistribuidora.Text = "Código Distribuidora"
        Me.CodigoDistribuidora.Width = 175
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width = 90
        '
        'Presentacion
        '
        Me.Presentacion.Text = "Presentación"
        Me.Presentacion.Width = 121
        '
        'Stock
        '
        Me.Stock.Text = "Stock"
        Me.Stock.Width = 78
        '
        'Precio
        '
        Me.Precio.Text = "Precio"
        Me.Precio.Width = 61
        '
        'FechaVencimiento
        '
        Me.FechaVencimiento.Text = "Fecha de Vencimiento"
        Me.FechaVencimiento.Width = 181
        '
        'Descripcion
        '
        Me.Descripcion.Text = "Descripción"
        Me.Descripcion.Width = 198
        '
        'frmMedicamentosEliminados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 317)
        Me.Controls.Add(Me.lvMedicamentosEliminados)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdRecuperar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(993, 364)
        Me.Name = "frmMedicamentosEliminados"
        Me.Text = "Medicamentos Eliminados"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdRecuperar As Button
    Friend WithEvents lvMedicamentosEliminados As ListView
    Friend WithEvents Codigo As ColumnHeader
    Friend WithEvents CodigoDistribuidora As ColumnHeader
    Friend WithEvents Nombre As ColumnHeader
    Friend WithEvents Presentacion As ColumnHeader
    Friend WithEvents Stock As ColumnHeader
    Friend WithEvents Precio As ColumnHeader
    Friend WithEvents FechaVencimiento As ColumnHeader
    Friend WithEvents Descripcion As ColumnHeader
End Class
