<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMedicamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicamentos))
        Me.Stock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtMedicamentosDescripcion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CodigoDistribuidora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Presentacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvMedicamentosRegistrados = New System.Windows.Forms.ListView()
        Me.Precio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaVencimiento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Descripcion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtMedicamentosStock = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMedicamentosNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDistribuidorasCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMedicamentosCodigo = New System.Windows.Forms.TextBox()
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpMedicamentosFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.txtMedicamentosPrecio = New System.Windows.Forms.TextBox()
        Me.txtMedicamentosPresentacion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Stock
        '
        Me.Stock.Text = "Stock"
        Me.Stock.Width = 78
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width = 90
        '
        'txtMedicamentosDescripcion
        '
        Me.txtMedicamentosDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicamentosDescripcion.Location = New System.Drawing.Point(230, 259)
        Me.txtMedicamentosDescripcion.MaxLength = 250
        Me.txtMedicamentosDescripcion.Name = "txtMedicamentosDescripcion"
        Me.txtMedicamentosDescripcion.Size = New System.Drawing.Size(514, 27)
        Me.txtMedicamentosDescripcion.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 266)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Descripción "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Fecha de Vencimiento"
        '
        'CodigoDistribuidora
        '
        Me.CodigoDistribuidora.Text = "Código Distribuidora"
        Me.CodigoDistribuidora.Width = 175
        '
        'Codigo
        '
        Me.Codigo.Text = "Código"
        Me.Codigo.Width = 69
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 198)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Precio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Stock"
        '
        'Presentacion
        '
        Me.Presentacion.Text = "Presentación"
        Me.Presentacion.Width = 121
        '
        'lvMedicamentosRegistrados
        '
        Me.lvMedicamentosRegistrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvMedicamentosRegistrados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Codigo, Me.CodigoDistribuidora, Me.Nombre, Me.Presentacion, Me.Stock, Me.Precio, Me.FechaVencimiento, Me.Descripcion})
        Me.lvMedicamentosRegistrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMedicamentosRegistrados.FullRowSelect = True
        Me.lvMedicamentosRegistrados.GridLines = True
        Me.lvMedicamentosRegistrados.HideSelection = False
        Me.lvMedicamentosRegistrados.Location = New System.Drawing.Point(16, 422)
        Me.lvMedicamentosRegistrados.MinimumSize = New System.Drawing.Size(953, 157)
        Me.lvMedicamentosRegistrados.Name = "lvMedicamentosRegistrados"
        Me.lvMedicamentosRegistrados.Size = New System.Drawing.Size(953, 157)
        Me.lvMedicamentosRegistrados.TabIndex = 36
        Me.lvMedicamentosRegistrados.UseCompatibleStateImageBehavior = False
        Me.lvMedicamentosRegistrados.View = System.Windows.Forms.View.Details
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
        'txtMedicamentosStock
        '
        Me.txtMedicamentosStock.Location = New System.Drawing.Point(230, 157)
        Me.txtMedicamentosStock.MaxLength = 6
        Me.txtMedicamentosStock.Name = "txtMedicamentosStock"
        Me.txtMedicamentosStock.Size = New System.Drawing.Size(114, 27)
        Me.txtMedicamentosStock.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 582)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 34
        '
        'txtMedicamentosNombre
        '
        Me.txtMedicamentosNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicamentosNombre.Location = New System.Drawing.Point(230, 89)
        Me.txtMedicamentosNombre.MaxLength = 100
        Me.txtMedicamentosNombre.Name = "txtMedicamentosNombre"
        Me.txtMedicamentosNombre.Size = New System.Drawing.Size(514, 27)
        Me.txtMedicamentosNombre.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Presentación"
        '
        'txtDistribuidorasCodigo
        '
        Me.txtDistribuidorasCodigo.Location = New System.Drawing.Point(230, 55)
        Me.txtDistribuidorasCodigo.MaxLength = 7
        Me.txtDistribuidorasCodigo.Name = "txtDistribuidorasCodigo"
        Me.txtDistribuidorasCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtDistribuidorasCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre  "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 388)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(237, 20)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Medicamentos Registrados"
        '
        'txtMedicamentosCodigo
        '
        Me.txtMedicamentosCodigo.Location = New System.Drawing.Point(230, 21)
        Me.txtMedicamentosCodigo.MaxLength = 7
        Me.txtMedicamentosCodigo.Name = "txtMedicamentosCodigo"
        Me.txtMedicamentosCodigo.Size = New System.Drawing.Size(114, 27)
        Me.txtMedicamentosCodigo.TabIndex = 1
        '
        'txt
        '
        Me.txt.AutoSize = True
        Me.txt.Location = New System.Drawing.Point(22, 28)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(66, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código "
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(797, 293)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(172, 54)
        Me.cmdCerrar.TabIndex = 32
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
        'cmdEditar
        '
        Me.cmdEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditar.ImageKey = "IconoEditar.gif"
        Me.cmdEditar.ImageList = Me.ListaImagenesBotones
        Me.cmdEditar.Location = New System.Drawing.Point(797, 119)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(172, 54)
        Me.cmdEditar.TabIndex = 29
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
        Me.cmdEliminar.Location = New System.Drawing.Point(797, 177)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(172, 54)
        Me.cmdEliminar.TabIndex = 30
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
        Me.cmdCancelar.Location = New System.Drawing.Point(797, 235)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(172, 54)
        Me.cmdCancelar.TabIndex = 31
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(797, 61)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(172, 54)
        Me.cmdAgregar.TabIndex = 28
        Me.cmdAgregar.Text = "Agregar "
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(797, 351)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(172, 54)
        Me.cmdEliminados.TabIndex = 33
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dtpMedicamentosFechaVencimiento)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosPrecio)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosPresentacion)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosStock)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosNombre)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDistribuidorasCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtMedicamentosCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(750, 318)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Medicamento"
        '
        'dtpMedicamentosFechaVencimiento
        '
        Me.dtpMedicamentosFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMedicamentosFechaVencimiento.Location = New System.Drawing.Point(230, 225)
        Me.dtpMedicamentosFechaVencimiento.Name = "dtpMedicamentosFechaVencimiento"
        Me.dtpMedicamentosFechaVencimiento.Size = New System.Drawing.Size(229, 27)
        Me.dtpMedicamentosFechaVencimiento.TabIndex = 20
        '
        'txtMedicamentosPrecio
        '
        Me.txtMedicamentosPrecio.Location = New System.Drawing.Point(230, 191)
        Me.txtMedicamentosPrecio.MaxLength = 12
        Me.txtMedicamentosPrecio.Name = "txtMedicamentosPrecio"
        Me.txtMedicamentosPrecio.Size = New System.Drawing.Size(114, 27)
        Me.txtMedicamentosPrecio.TabIndex = 19
        '
        'txtMedicamentosPresentacion
        '
        Me.txtMedicamentosPresentacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedicamentosPresentacion.Location = New System.Drawing.Point(230, 123)
        Me.txtMedicamentosPresentacion.MaxLength = 100
        Me.txtMedicamentosPresentacion.Name = "txtMedicamentosPresentacion"
        Me.txtMedicamentosPresentacion.Size = New System.Drawing.Size(514, 27)
        Me.txtMedicamentosPresentacion.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(162, 20)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Código Distribuidora"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 55)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Medicamentos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmMedicamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.lvMedicamentosRegistrados)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmMedicamentos"
        Me.Text = "Medicamentos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Stock As ColumnHeader
    Friend WithEvents Nombre As ColumnHeader
    Friend WithEvents txtMedicamentosDescripcion As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CodigoDistribuidora As ColumnHeader
    Friend WithEvents Codigo As ColumnHeader
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Presentacion As ColumnHeader
    Friend WithEvents lvMedicamentosRegistrados As ListView
    Friend WithEvents Precio As ColumnHeader
    Friend WithEvents FechaVencimiento As ColumnHeader
    Friend WithEvents Descripcion As ColumnHeader
    Friend WithEvents txtMedicamentosStock As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMedicamentosNombre As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDistribuidorasCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtMedicamentosCodigo As TextBox
    Friend WithEvents txt As Label
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMedicamentosPrecio As TextBox
    Friend WithEvents txtMedicamentosPresentacion As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpMedicamentosFechaVencimiento As DateTimePicker
End Class
