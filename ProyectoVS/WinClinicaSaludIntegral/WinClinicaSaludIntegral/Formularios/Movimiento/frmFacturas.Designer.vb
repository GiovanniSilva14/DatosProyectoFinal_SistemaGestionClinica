<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFacturas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturas))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPacientesCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvFacturasRegistradas = New System.Windows.Forms.ListView()
        Me.Código = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoPaciente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodigoEmpleado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SubTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IGV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Total = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtFacturaCodigo = New System.Windows.Forms.TextBox()
        Me.ListaImagenesBotones = New System.Windows.Forms.ImageList(Me.components)
        Me.txt = New System.Windows.Forms.Label()
        Me.cmdEliminados = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtEmpleadosCodigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFacturaSubTotal = New System.Windows.Forms.TextBox()
        Me.txtFacturaTotal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFacturaFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFacturaIGV = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 574)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 89)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Código Empleado"
        '
        'txtPacientesCodigo
        '
        Me.txtPacientesCodigo.Location = New System.Drawing.Point(183, 47)
        Me.txtPacientesCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPacientesCodigo.MaxLength = 7
        Me.txtPacientesCodigo.Name = "txtPacientesCodigo"
        Me.txtPacientesCodigo.Size = New System.Drawing.Size(124, 27)
        Me.txtPacientesCodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Código Paciente"
        '
        'lvFacturasRegistradas
        '
        Me.lvFacturasRegistradas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFacturasRegistradas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Código, Me.CodigoPaciente, Me.CodigoEmpleado, Me.Fecha, Me.SubTotal, Me.IGV, Me.Total})
        Me.lvFacturasRegistradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFacturasRegistradas.FullRowSelect = True
        Me.lvFacturasRegistradas.GridLines = True
        Me.lvFacturasRegistradas.HideSelection = False
        Me.lvFacturasRegistradas.Location = New System.Drawing.Point(29, 368)
        Me.lvFacturasRegistradas.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFacturasRegistradas.MinimumSize = New System.Drawing.Size(857, 202)
        Me.lvFacturasRegistradas.Name = "lvFacturasRegistradas"
        Me.lvFacturasRegistradas.Size = New System.Drawing.Size(857, 202)
        Me.lvFacturasRegistradas.TabIndex = 47
        Me.lvFacturasRegistradas.UseCompatibleStateImageBehavior = False
        Me.lvFacturasRegistradas.View = System.Windows.Forms.View.Details
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
        Me.Fecha.Width = 137
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
        'txtFacturaCodigo
        '
        Me.txtFacturaCodigo.Location = New System.Drawing.Point(183, 12)
        Me.txtFacturaCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaCodigo.MaxLength = 7
        Me.txtFacturaCodigo.Name = "txtFacturaCodigo"
        Me.txtFacturaCodigo.Size = New System.Drawing.Size(124, 27)
        Me.txtFacturaCodigo.TabIndex = 1
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
        Me.txt.Location = New System.Drawing.Point(24, 19)
        Me.txt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt.Name = "txt"
        Me.txt.Size = New System.Drawing.Size(61, 20)
        Me.txt.TabIndex = 0
        Me.txt.Text = "Código"
        '
        'cmdEliminados
        '
        Me.cmdEliminados.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminados.ImageKey = "IconoEliminados.gif"
        Me.cmdEliminados.ImageList = Me.ListaImagenesBotones
        Me.cmdEliminados.Location = New System.Drawing.Point(787, 251)
        Me.cmdEliminados.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEliminados.Name = "cmdEliminados"
        Me.cmdEliminados.Size = New System.Drawing.Size(188, 71)
        Me.cmdEliminados.TabIndex = 44
        Me.cmdEliminados.Text = "Eliminados "
        Me.cmdEliminados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdEliminados.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.ImageKey = "IconoCerrar.gif"
        Me.cmdCerrar.ImageList = Me.ListaImagenesBotones
        Me.cmdCerrar.Location = New System.Drawing.Point(787, 164)
        Me.cmdCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(188, 71)
        Me.cmdCerrar.TabIndex = 43
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.ImageKey = "IconoAgregar.gif"
        Me.cmdAgregar.ImageList = Me.ListaImagenesBotones
        Me.cmdAgregar.Location = New System.Drawing.Point(591, 78)
        Me.cmdAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(188, 71)
        Me.cmdAgregar.TabIndex = 39
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
        Me.cmdEditar.Location = New System.Drawing.Point(591, 164)
        Me.cmdEditar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(188, 71)
        Me.cmdEditar.TabIndex = 40
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
        Me.cmdEliminar.Location = New System.Drawing.Point(591, 251)
        Me.cmdEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(188, 71)
        Me.cmdEliminar.TabIndex = 41
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
        Me.cmdCancelar.Location = New System.Drawing.Point(787, 78)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(188, 71)
        Me.cmdCancelar.TabIndex = 42
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'txtEmpleadosCodigo
        '
        Me.txtEmpleadosCodigo.Location = New System.Drawing.Point(183, 82)
        Me.txtEmpleadosCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmpleadosCodigo.MaxLength = 7
        Me.txtEmpleadosCodigo.Name = "txtEmpleadosCodigo"
        Me.txtEmpleadosCodigo.Size = New System.Drawing.Size(124, 27)
        Me.txtEmpleadosCodigo.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(25, 333)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(190, 20)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "Facturas Registradas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtFacturaSubTotal)
        Me.GroupBox1.Controls.Add(Me.txtFacturaTotal)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtMotivo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dtpFacturaFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFacturaIGV)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtEmpleadosCodigo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPacientesCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFacturaCodigo)
        Me.GroupBox1.Controls.Add(Me.txt)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(29, 66)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(554, 263)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Factura"
        '
        'txtFacturaSubTotal
        '
        Me.txtFacturaSubTotal.Location = New System.Drawing.Point(183, 152)
        Me.txtFacturaSubTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaSubTotal.MaxLength = 12
        Me.txtFacturaSubTotal.Name = "txtFacturaSubTotal"
        Me.txtFacturaSubTotal.Size = New System.Drawing.Size(154, 27)
        Me.txtFacturaSubTotal.TabIndex = 17
        '
        'txtFacturaTotal
        '
        Me.txtFacturaTotal.Location = New System.Drawing.Point(183, 222)
        Me.txtFacturaTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaTotal.MaxLength = 12
        Me.txtFacturaTotal.Name = "txtFacturaTotal"
        Me.txtFacturaTotal.Size = New System.Drawing.Size(154, 27)
        Me.txtFacturaTotal.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 370)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 20)
        Me.Label9.TabIndex = 14
        '
        'txtMotivo
        '
        Me.txtMotivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotivo.Location = New System.Drawing.Point(332, 329)
        Me.txtMotivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMotivo.MaxLength = 12
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(102, 27)
        Me.txtMotivo.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 229)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 20)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 194)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "IGV"
        '
        'dtpFacturaFecha
        '
        Me.dtpFacturaFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFacturaFecha.Location = New System.Drawing.Point(183, 117)
        Me.dtpFacturaFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFacturaFecha.Name = "dtpFacturaFecha"
        Me.dtpFacturaFecha.Size = New System.Drawing.Size(249, 27)
        Me.dtpFacturaFecha.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 159)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Sub Total"
        '
        'txtFacturaIGV
        '
        Me.txtFacturaIGV.Location = New System.Drawing.Point(183, 187)
        Me.txtFacturaIGV.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFacturaIGV.MaxLength = 12
        Me.txtFacturaIGV.Name = "txtFacturaIGV"
        Me.txtFacturaIGV.Size = New System.Drawing.Size(154, 27)
        Me.txtFacturaIGV.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 124)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(991, 58)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Facturas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 591)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lvFacturasRegistradas)
        Me.Controls.Add(Me.cmdEliminados)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1009, 638)
        Me.Name = "frmFacturas"
        Me.Text = "Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPacientesCodigo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lvFacturasRegistradas As ListView
    Friend WithEvents Código As ColumnHeader
    Friend WithEvents CodigoPaciente As ColumnHeader
    Friend WithEvents CodigoEmpleado As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents SubTotal As ColumnHeader
    Friend WithEvents IGV As ColumnHeader
    Friend WithEvents Total As ColumnHeader
    Friend WithEvents txtFacturaCodigo As TextBox
    Friend WithEvents ListaImagenesBotones As ImageList
    Friend WithEvents txt As Label
    Friend WithEvents cmdEliminados As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents cmdEditar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents txtEmpleadosCodigo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFacturaTotal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpFacturaFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFacturaIGV As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFacturaSubTotal As TextBox
End Class
