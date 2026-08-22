<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoletaDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBoletaDetalle))
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txtBoletaDetalleCantidad = New System.Windows.Forms.TextBox()
        Me.txtBoletaDetalleImporte = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBoletaDetallePrecio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBoletaDetalleConcepto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBoletaCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBoletaDetalleCodigo = New System.Windows.Forms.TextBox()
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.BoletaDetalleImporte = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetallePrecio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleConcepto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaFacturaCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BoletaDetalleCódigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvBoletaDetalleRegistrados = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(746, 279)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(183, 47)
        Me.cmdCerrar.TabIndex = 65
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
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
        'txtBoletaDetalleCantidad
        '
        Me.txtBoletaDetalleCantidad.Location = New System.Drawing.Point(199, 122)
        Me.txtBoletaDetalleCantidad.MaxLength = 5
        Me.txtBoletaDetalleCantidad.Name = "txtBoletaDetalleCantidad"
        Me.txtBoletaDetalleCantidad.Size = New System.Drawing.Size(114, 27)
        Me.txtBoletaDetalleCantidad.TabIndex = 17
        '
        'txtBoletaDetalleImporte
        '
        Me.txtBoletaDetalleImporte.Location = New System.Drawing.Point(199, 184)
        Me.txtBoletaDetalleImporte.MaxLength = 12
        Me.txtBoletaDetalleImporte.Name = "txtBoletaDetalleImporte"
        Me.txtBoletaDetalleImporte.Size = New System.Drawing.Size(142, 27)
        Me.txtBoletaDetalleImporte.TabIndex = 16
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
        Me.Label7.Location = New System.Drawing.Point(13, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Importe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Precio"
        '
        'txtBoletaDetallePrecio
        '
        Me.txtBoletaDetallePrecio.Location = New System.Drawing.Point(199, 153)
        Me.txtBoletaDetallePrecio.MaxLength = 12
        Me.txtBoletaDetallePrecio.Name = "txtBoletaDetallePrecio"
        Me.txtBoletaDetallePrecio.Size = New System.Drawing.Size(142, 27)
        Me.txtBoletaDetallePrecio.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "Detalles de Boleta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Cantidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 321)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(282, 20)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Detalles de Boletas Registradas"
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(746, 71)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(183, 47)
        Me.cmdAgregar.TabIndex = 61
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
        Me.cmdEditar.Location = New System.Drawing.Point(746, 123)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(183, 47)
        Me.cmdEditar.TabIndex = 62
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
        Me.cmdEliminar.Location = New System.Drawing.Point(746, 175)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(183, 47)
        Me.cmdEliminar.TabIndex = 63
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
        Me.cmdCancelar.Location = New System.Drawing.Point(746, 227)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(183, 47)
        Me.cmdCancelar.TabIndex = 64
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtBoletaDetalleCantidad)
        Me.GroupBox1.Controls.Add(Me.txtBoletaDetalleImporte)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtBoletaDetallePrecio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtBoletaDetalleConcepto)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBoletaCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtBoletaDetalleCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(27, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 231)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de Boleta"
        '
        'txtBoletaDetalleConcepto
        '
        Me.txtBoletaDetalleConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBoletaDetalleConcepto.Location = New System.Drawing.Point(199, 91)
        Me.txtBoletaDetalleConcepto.MaxLength = 150
        Me.txtBoletaDetalleConcepto.Name = "txtBoletaDetalleConcepto"
        Me.txtBoletaDetalleConcepto.Size = New System.Drawing.Size(459, 27)
        Me.txtBoletaDetalleConcepto.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Concepto"
        '
        'txtBoletaCodigo
        '
        Me.txtBoletaCodigo.Location = New System.Drawing.Point(199, 60)
        Me.txtBoletaCodigo.MaxLength = 7
        Me.txtBoletaCodigo.Name = "txtBoletaCodigo"
        Me.txtBoletaCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtBoletaCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Boleta Código"
        '
        'txtBoletaDetalleCodigo
        '
        Me.txtBoletaDetalleCodigo.Location = New System.Drawing.Point(199, 29)
        Me.txtBoletaDetalleCodigo.MaxLength = 7
        Me.txtBoletaDetalleCodigo.Name = "txtBoletaDetalleCodigo"
        Me.txtBoletaDetalleCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtBoletaDetalleCodigo.TabIndex = 1
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(13, 36)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(172, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Boleta Detalle Código"
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(746, 331)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(183, 47)
        Me.cmdEliminados.TabIndex = 66
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'BoletaDetalleImporte
        '
        Me.BoletaDetalleImporte.Text = "Importe"
        Me.BoletaDetalleImporte.Width = 172
        '
        'BoletaDetallePrecio
        '
        Me.BoletaDetallePrecio.Text = "Precio"
        Me.BoletaDetallePrecio.Width = 129
        '
        'BoletaDetalleCantidad
        '
        Me.BoletaDetalleCantidad.Text = "Cantidad"
        Me.BoletaDetalleCantidad.Width = 182
        '
        'BoletaDetalleConcepto
        '
        Me.BoletaDetalleConcepto.Text = "Concepto"
        Me.BoletaDetalleConcepto.Width = 271
        '
        'BoletaFacturaCodigo
        '
        Me.BoletaFacturaCodigo.Text = "Boleta Código"
        Me.BoletaFacturaCodigo.Width = 137
        '
        'BoletaDetalleCódigo
        '
        Me.BoletaDetalleCódigo.Text = "Código"
        Me.BoletaDetalleCódigo.Width = 77
        '
        'lvBoletaDetalleRegistrados
        '
        Me.lvBoletaDetalleRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvBoletaDetalleRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.BoletaDetalleCódigo, Me.BoletaFacturaCodigo, Me.BoletaDetalleConcepto, Me.BoletaDetalleCantidad, Me.BoletaDetallePrecio, Me.BoletaDetalleImporte})
        Me.lvBoletaDetalleRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBoletaDetalleRegistrados.FullRowSelect = True
        Me.lvBoletaDetalleRegistrados.GridLines = True
        Me.lvBoletaDetalleRegistrados.HideSelection = False
        Me.lvBoletaDetalleRegistrados.Location = New System.Drawing.Point(8, 384)
        Me.lvBoletaDetalleRegistrados.MinimumSize = New System.Drawing.Size(971, 195)
        Me.lvBoletaDetalleRegistrados.Name = "lvBoletaDetalleRegistrados"
        Me.lvBoletaDetalleRegistrados.Size = New System.Drawing.Size(971, 195)
        Me.lvBoletaDetalleRegistrados.TabIndex = 69
        Me.lvBoletaDetalleRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvBoletaDetalleRegistrados.View = System.Windows.Forms.View.Details
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 570)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 67
        '
        'frmBoletaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.lvBoletaDetalleRegistrados)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmBoletaDetalle"
        Me.Text = "Boleta Detalle"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCerrar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txtBoletaDetalleCantidad As TextBox
    Friend WithEvents txtBoletaDetalleImporte As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBoletaDetallePrecio As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtBoletaDetalleConcepto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBoletaCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBoletaDetalleCodigo As TextBox
    Friend WithEvents txt As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents BoletaDetalleImporte As ColumnHeader
    Friend WithEvents BoletaDetallePrecio As ColumnHeader
    Friend WithEvents BoletaDetalleCantidad As ColumnHeader
    Friend WithEvents BoletaDetalleConcepto As ColumnHeader
    Friend WithEvents BoletaFacturaCodigo As ColumnHeader
    Friend WithEvents BoletaDetalleCódigo As ColumnHeader
    Friend WithEvents lvBoletaDetalleRegistrados As ListView
    Friend WithEvents Label2 As Label
End Class
