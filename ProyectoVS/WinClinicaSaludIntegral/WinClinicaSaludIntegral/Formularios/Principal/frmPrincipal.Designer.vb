<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MovimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPacientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCitas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHistoriaClinica = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRecetas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuBoletas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFarmacia = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuServicios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMédicos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEspecialidades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuConsultorios = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMedicamentos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLaboratoriosDeReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDistribuidoras = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMantenimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCategoriasReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDetalleFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDetalleBoleta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSeguridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuariosEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuUsuariosMedicos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCerrarSesión = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAcercaDeClinicaSaludIntegral = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnMedicos = New System.Windows.Forms.ToolStripButton()
        Me.btnPacientes = New System.Windows.Forms.ToolStripButton()
        Me.btnCitas = New System.Windows.Forms.ToolStripButton()
        Me.btnRecetas = New System.Windows.Forms.ToolStripButton()
        Me.btnFacturas = New System.Windows.Forms.ToolStripButton()
        Me.btnFarmacia = New System.Windows.Forms.ToolStripButton()
        Me.btnUsuarios = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovimientoToolStripMenuItem, Me.mnuServicios, Me.mnuMantenimiento, Me.mnuSeguridad, Me.mnuAyuda})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'MovimientoToolStripMenuItem
        '
        Me.MovimientoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPacientes, Me.mnuCitas, Me.mnuHistoriaClinica, Me.ToolStripSeparator1, Me.mnuRecetas, Me.mnuFacturas, Me.ToolStripSeparator2, Me.mnuBoletas, Me.mnuFarmacia})
        resources.ApplyResources(Me.MovimientoToolStripMenuItem, "MovimientoToolStripMenuItem")
        Me.MovimientoToolStripMenuItem.Name = "MovimientoToolStripMenuItem"
        '
        'mnuPacientes
        '
        Me.mnuPacientes.CheckOnClick = True
        Me.mnuPacientes.DoubleClickEnabled = True
        resources.ApplyResources(Me.mnuPacientes, "mnuPacientes")
        Me.mnuPacientes.Name = "mnuPacientes"
        '
        'mnuCitas
        '
        resources.ApplyResources(Me.mnuCitas, "mnuCitas")
        Me.mnuCitas.Name = "mnuCitas"
        '
        'mnuHistoriaClinica
        '
        resources.ApplyResources(Me.mnuHistoriaClinica, "mnuHistoriaClinica")
        Me.mnuHistoriaClinica.Name = "mnuHistoriaClinica"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'mnuRecetas
        '
        resources.ApplyResources(Me.mnuRecetas, "mnuRecetas")
        Me.mnuRecetas.Name = "mnuRecetas"
        '
        'mnuFacturas
        '
        resources.ApplyResources(Me.mnuFacturas, "mnuFacturas")
        Me.mnuFacturas.Name = "mnuFacturas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'mnuBoletas
        '
        resources.ApplyResources(Me.mnuBoletas, "mnuBoletas")
        Me.mnuBoletas.Name = "mnuBoletas"
        '
        'mnuFarmacia
        '
        resources.ApplyResources(Me.mnuFarmacia, "mnuFarmacia")
        Me.mnuFarmacia.Name = "mnuFarmacia"
        '
        'mnuServicios
        '
        Me.mnuServicios.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMédicos, Me.mnuEspecialidades, Me.mnuConsultorios, Me.ToolStripSeparator3, Me.mnuMedicamentos, Me.mnuLaboratoriosDeReceta, Me.mnuDistribuidoras})
        resources.ApplyResources(Me.mnuServicios, "mnuServicios")
        Me.mnuServicios.Name = "mnuServicios"
        '
        'mnuMédicos
        '
        resources.ApplyResources(Me.mnuMédicos, "mnuMédicos")
        Me.mnuMédicos.Name = "mnuMédicos"
        '
        'mnuEspecialidades
        '
        resources.ApplyResources(Me.mnuEspecialidades, "mnuEspecialidades")
        Me.mnuEspecialidades.Name = "mnuEspecialidades"
        '
        'mnuConsultorios
        '
        resources.ApplyResources(Me.mnuConsultorios, "mnuConsultorios")
        Me.mnuConsultorios.Name = "mnuConsultorios"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'mnuMedicamentos
        '
        resources.ApplyResources(Me.mnuMedicamentos, "mnuMedicamentos")
        Me.mnuMedicamentos.Name = "mnuMedicamentos"
        '
        'mnuLaboratoriosDeReceta
        '
        resources.ApplyResources(Me.mnuLaboratoriosDeReceta, "mnuLaboratoriosDeReceta")
        Me.mnuLaboratoriosDeReceta.Name = "mnuLaboratoriosDeReceta"
        '
        'mnuDistribuidoras
        '
        resources.ApplyResources(Me.mnuDistribuidoras, "mnuDistribuidoras")
        Me.mnuDistribuidoras.Name = "mnuDistribuidoras"
        '
        'mnuMantenimiento
        '
        Me.mnuMantenimiento.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEmpleados, Me.mnuCategoriasReceta, Me.ToolStripSeparator4, Me.mnuDetalleFactura, Me.mnuDetalleBoleta})
        resources.ApplyResources(Me.mnuMantenimiento, "mnuMantenimiento")
        Me.mnuMantenimiento.Name = "mnuMantenimiento"
        '
        'mnuEmpleados
        '
        resources.ApplyResources(Me.mnuEmpleados, "mnuEmpleados")
        Me.mnuEmpleados.Name = "mnuEmpleados"
        '
        'mnuCategoriasReceta
        '
        resources.ApplyResources(Me.mnuCategoriasReceta, "mnuCategoriasReceta")
        Me.mnuCategoriasReceta.Name = "mnuCategoriasReceta"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'mnuDetalleFactura
        '
        resources.ApplyResources(Me.mnuDetalleFactura, "mnuDetalleFactura")
        Me.mnuDetalleFactura.Name = "mnuDetalleFactura"
        '
        'mnuDetalleBoleta
        '
        resources.ApplyResources(Me.mnuDetalleBoleta, "mnuDetalleBoleta")
        Me.mnuDetalleBoleta.Name = "mnuDetalleBoleta"
        '
        'mnuSeguridad
        '
        Me.mnuSeguridad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUsuarios, Me.mnuUsuariosEmpleados, Me.mnuUsuariosMedicos, Me.ToolStripSeparator5, Me.mnuCerrarSesión})
        resources.ApplyResources(Me.mnuSeguridad, "mnuSeguridad")
        Me.mnuSeguridad.Name = "mnuSeguridad"
        '
        'mnuUsuarios
        '
        resources.ApplyResources(Me.mnuUsuarios, "mnuUsuarios")
        Me.mnuUsuarios.Name = "mnuUsuarios"
        '
        'mnuUsuariosEmpleados
        '
        resources.ApplyResources(Me.mnuUsuariosEmpleados, "mnuUsuariosEmpleados")
        Me.mnuUsuariosEmpleados.Name = "mnuUsuariosEmpleados"
        '
        'mnuUsuariosMedicos
        '
        resources.ApplyResources(Me.mnuUsuariosMedicos, "mnuUsuariosMedicos")
        Me.mnuUsuariosMedicos.Name = "mnuUsuariosMedicos"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'mnuCerrarSesión
        '
        resources.ApplyResources(Me.mnuCerrarSesión, "mnuCerrarSesión")
        Me.mnuCerrarSesión.Name = "mnuCerrarSesión"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAcercaDeClinicaSaludIntegral})
        resources.ApplyResources(Me.mnuAyuda, "mnuAyuda")
        Me.mnuAyuda.Name = "mnuAyuda"
        '
        'mnuAcercaDeClinicaSaludIntegral
        '
        resources.ApplyResources(Me.mnuAcercaDeClinicaSaludIntegral, "mnuAcercaDeClinicaSaludIntegral")
        Me.mnuAcercaDeClinicaSaludIntegral.Name = "mnuAcercaDeClinicaSaludIntegral"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnMedicos, Me.btnPacientes, Me.btnCitas, Me.btnRecetas, Me.btnFacturas, Me.btnFarmacia, Me.btnUsuarios, Me.btnSalir})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'btnMedicos
        '
        resources.ApplyResources(Me.btnMedicos, "btnMedicos")
        Me.btnMedicos.Name = "btnMedicos"
        '
        'btnPacientes
        '
        resources.ApplyResources(Me.btnPacientes, "btnPacientes")
        Me.btnPacientes.Name = "btnPacientes"
        '
        'btnCitas
        '
        resources.ApplyResources(Me.btnCitas, "btnCitas")
        Me.btnCitas.Name = "btnCitas"
        '
        'btnRecetas
        '
        resources.ApplyResources(Me.btnRecetas, "btnRecetas")
        Me.btnRecetas.Name = "btnRecetas"
        '
        'btnFacturas
        '
        resources.ApplyResources(Me.btnFacturas, "btnFacturas")
        Me.btnFacturas.Name = "btnFacturas"
        '
        'btnFarmacia
        '
        resources.ApplyResources(Me.btnFarmacia, "btnFarmacia")
        Me.btnFarmacia.Name = "btnFarmacia"
        '
        'btnUsuarios
        '
        resources.ApplyResources(Me.btnUsuarios, "btnUsuarios")
        Me.btnUsuarios.Name = "btnUsuarios"
        '
        'btnSalir
        '
        resources.ApplyResources(Me.btnSalir, "btnSalir")
        Me.btnSalir.Name = "btnSalir"
        '
        'FrmPrincipal
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MovimientoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuPacientes As ToolStripMenuItem
    Friend WithEvents mnuCitas As ToolStripMenuItem
    Friend WithEvents mnuHistoriaClinica As ToolStripMenuItem
    Friend WithEvents mnuRecetas As ToolStripMenuItem
    Friend WithEvents mnuFacturas As ToolStripMenuItem
    Friend WithEvents mnuBoletas As ToolStripMenuItem
    Friend WithEvents mnuFarmacia As ToolStripMenuItem
    Friend WithEvents mnuServicios As ToolStripMenuItem
    Friend WithEvents mnuMédicos As ToolStripMenuItem
    Friend WithEvents mnuEspecialidades As ToolStripMenuItem
    Friend WithEvents mnuConsultorios As ToolStripMenuItem
    Friend WithEvents mnuMedicamentos As ToolStripMenuItem
    Friend WithEvents mnuLaboratoriosDeReceta As ToolStripMenuItem
    Friend WithEvents mnuDistribuidoras As ToolStripMenuItem
    Friend WithEvents mnuMantenimiento As ToolStripMenuItem
    Friend WithEvents mnuEmpleados As ToolStripMenuItem
    Friend WithEvents mnuCategoriasReceta As ToolStripMenuItem
    Friend WithEvents mnuDetalleFactura As ToolStripMenuItem
    Friend WithEvents mnuDetalleBoleta As ToolStripMenuItem
    Friend WithEvents mnuSeguridad As ToolStripMenuItem
    Friend WithEvents mnuUsuarios As ToolStripMenuItem
    Friend WithEvents mnuUsuariosEmpleados As ToolStripMenuItem
    Friend WithEvents mnuUsuariosMedicos As ToolStripMenuItem
    Friend WithEvents mnuCerrarSesión As ToolStripMenuItem
    Friend WithEvents mnuAyuda As ToolStripMenuItem
    Friend WithEvents mnuAcercaDeClinicaSaludIntegral As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnMedicos As ToolStripButton
    Friend WithEvents btnPacientes As ToolStripButton
    Friend WithEvents btnCitas As ToolStripButton
    Friend WithEvents btnRecetas As ToolStripButton
    Friend WithEvents btnFacturas As ToolStripButton
    Friend WithEvents btnFarmacia As ToolStripButton
    Friend WithEvents btnUsuarios As ToolStripButton
    Friend WithEvents btnSalir As ToolStripButton
End Class
