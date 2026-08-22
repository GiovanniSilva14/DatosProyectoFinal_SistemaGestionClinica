<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaDetalle
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaDetalle))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFacturaDetallePrecio = New System.Windows.Forms.TextBox()
        Me.lvFacturaDetalleRegistrados = New System.Windows.Forms.ListView()
        Me.FacturaDetalleCódigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetallePrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FacturaDetalleImporte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFacturaDetalleImporte = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFacturaDetalleConcepto = New System.Windows.Forms.TextBox()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFacturaCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFacturaDetalleCantidad = New System.Windows.Forms.TextBox()
        Me.txtFacturaDetalleCodigo = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 566)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Precio"
        '
        'txtFacturaDetallePrecio
        '
        Me.txtFacturaDetallePrecio.Location = New System.Drawing.Point(209, 158)
        Me.txtFacturaDetallePrecio.MaxLength = 12
        Me.txtFacturaDetallePrecio.Name = "txtFacturaDetallePrecio"
        Me.txtFacturaDetallePrecio.Size = New System.Drawing.Size(142, 27)
        Me.txtFacturaDetallePrecio.TabIndex = 7
        '
        'lvFacturaDetalleRegistrados
        '
        Me.lvFacturaDetalleRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFacturaDetalleRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FacturaDetalleCódigo, Me.FacturaCodigo, Me.FacturaDetalleConcepto, Me.FacturaDetalleCantidad, Me.FacturaDetallePrecio, Me.FacturaDetalleImporte})
        Me.lvFacturaDetalleRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFacturaDetalleRegistrados.FullRowSelect = True
        Me.lvFacturaDetalleRegistrados.GridLines = True
        Me.lvFacturaDetalleRegistrados.HideSelection = False
        Me.lvFacturaDetalleRegistrados.Location = New System.Drawing.Point(27, 393)
        Me.lvFacturaDetalleRegistrados.MinimumSize = New System.Drawing.Size(902, 193)
        Me.lvFacturaDetalleRegistrados.Name = "lvFacturaDetalleRegistrados"
        Me.lvFacturaDetalleRegistrados.Size = New System.Drawing.Size(902, 193)
        Me.lvFacturaDetalleRegistrados.TabIndex = 58
        Me.lvFacturaDetalleRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvFacturaDetalleRegistrados.View = System.Windows.Forms.View.Details
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
        Me.FacturaDetalleConcepto.Width = 212
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
        'txtFacturaDetalleImporte
        '
        Me.txtFacturaDetalleImporte.Location = New System.Drawing.Point(209, 191)
        Me.txtFacturaDetalleImporte.MaxLength = 12
        Me.txtFacturaDetalleImporte.Name = "txtFacturaDetalleImporte"
        Me.txtFacturaDetalleImporte.Size = New System.Drawing.Size(142, 27)
        Me.txtFacturaDetalleImporte.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 20)
        Me.Label9.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Importe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Cantidad"
        '
        'txtFacturaDetalleConcepto
        '
        Me.txtFacturaDetalleConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFacturaDetalleConcepto.Location = New System.Drawing.Point(209, 92)
        Me.txtFacturaDetalleConcepto.MaxLength = 150
        Me.txtFacturaDetalleConcepto.Name = "txtFacturaDetalleConcepto"
        Me.txtFacturaDetalleConcepto.Size = New System.Drawing.Size(429, 27)
        Me.txtFacturaDetalleConcepto.TabIndex = 5
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(746, 336)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(183, 48)
        Me.cmdEliminados.TabIndex = 55
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'ListaImagenesBotones
        '
        Me.ListaImagenesBotones.ImageStream = CType(resources.GetObject("ListaImagenesBotones.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenesBotones.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenesBotones.Images.SetKeyName(0, "IconoAgregar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(1, "IconoCancelar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(2, "IconoCerrar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(3, "IconoEditar.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(4, "IconoEliminados.gif")
        Me.ListaImagenesBotones.Images.SetKeyName(5, "IconoEliminar.gif")
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(22, 33)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(181, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Detalle Factura Código"
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(746, 282)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(183, 48)
        Me.cmdCerrar.TabIndex = 54
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Detalles de Factura"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Concepto"
        '
        'txtFacturaCodigo
        '
        Me.txtFacturaCodigo.Location = New System.Drawing.Point(209, 59)
        Me.txtFacturaCodigo.MaxLength = 7
        Me.txtFacturaCodigo.Name = "txtFacturaCodigo"
        Me.txtFacturaCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtFacturaCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Factura Código"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 364)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(292, 20)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Detalles de Facturas Registradas"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(746, 66)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(183, 48)
        Me.cmdAgregar.TabIndex = 50
        Me.cmdAgregar.Text = "Agregar "
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(746, 120)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(183, 48)
        Me.cmdEditar.TabIndex = 51
        Me.cmdEditar.Text = "Editar "
        Me.cmdEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.ImageKey = "IconoEliminar.gif"
        Me.cmdEliminar.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminar.Location = New System.Drawing.Point(746, 174)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(183, 48)
        Me.cmdEliminar.TabIndex = 52
        Me.cmdEliminar.Text = "Eliminar "
        Me.cmdEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.ImageKey = "IconoCancelar.gif"
        Me.cmdCancelar.ImageList = Me.ListaImagenesBotones
        Me.cmdCancelar.Location = New System.Drawing.Point(746, 228)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(183, 48)
        Me.cmdCancelar.TabIndex = 53
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtFacturaDetalleCantidad)
        Me.GroupBox1.Controls.Add(Me.txtFacturaDetalleImporte)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFacturaDetallePrecio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFacturaDetalleConcepto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFacturaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFacturaDetalleCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(27, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 239)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de Factura"
        '
        'txtFacturaDetalleCantidad
        '
        Me.txtFacturaDetalleCantidad.Location = New System.Drawing.Point(209, 125)
        Me.txtFacturaDetalleCantidad.MaxLength = 5
        Me.txtFacturaDetalleCantidad.Name = "txtFacturaDetalleCantidad"
        Me.txtFacturaDetalleCantidad.Size = New System.Drawing.Size(114, 27)
        Me.txtFacturaDetalleCantidad.TabIndex = 17
        '
        'txtFacturaDetalleCodigo
        '
        Me.txtFacturaDetalleCodigo.Location = New System.Drawing.Point(209, 26)
        Me.txtFacturaDetalleCodigo.MaxLength = 7
        Me.txtFacturaDetalleCodigo.Name = "txtFacturaDetalleCodigo"
        Me.txtFacturaDetalleCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtFacturaDetalleCodigo.TabIndex = 1
        '
        'frmFacturaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvFacturaDetalleRegistrados)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmFacturaDetalle"
        Me.ShowInTaskbar = False
        Me.Text = "Factura Detalle"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFacturaDetallePrecio As TextBox
    Friend WithEvents lvFacturaDetalleRegistrados As ListView
    Friend WithEvents FacturaDetalleCódigo As ColumnHeader
    Friend WithEvents FacturaCodigo As ColumnHeader
    Friend WithEvents FacturaDetalleConcepto As ColumnHeader
    Friend WithEvents FacturaDetalleCantidad As ColumnHeader
    Friend WithEvents FacturaDetallePrecio As ColumnHeader
    Friend WithEvents FacturaDetalleImporte As ColumnHeader
    Friend WithEvents txtFacturaDetalleImporte As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFacturaDetalleConcepto As TextBox
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txt As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFacturaCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFacturaDetalleCodigo As TextBox
    Friend WithEvents txtFacturaDetalleCantidad As TextBox
End Class
