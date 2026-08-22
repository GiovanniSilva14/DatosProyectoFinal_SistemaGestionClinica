Public Class FrmPrincipal

#Region "Login regiones"
    Private Sub PrincipalCarga(sender As Object, e As EventArgs) Handles MyBase.Load

        'Mostrar el formulario de Login
        Me.Hide()

        Dim fLogin As New frmLogin
        Dim resultado As DialogResult = fLogin.ShowDialog()

        If resultado = DialogResult.OK Then
            Me.Show()
        Else
            Application.Exit()
        End If

    End Sub
#End Region

#Region "Movimiento Regiones"
    Private Sub MovimientoOpciones(sender As Object, e As EventArgs) _
        Handles mnuPacientes.Click, mnuCitas.Click, mnuHistoriaClinica.Click,
                mnuRecetas.Click, mnuFacturas.Click, mnuBoletas.Click, mnuFarmacia.Click

        If sender Is mnuPacientes Then
            Pacientes()
        ElseIf sender Is mnuCitas Then
            Citas()
        ElseIf sender Is mnuHistoriaClinica Then
            HistoriaClinica()
        ElseIf sender Is mnuRecetas Then
            Recetas()
        ElseIf sender Is mnuFacturas Then
            Facturas()
        ElseIf sender Is mnuBoletas Then
            Boletas()
        ElseIf sender Is mnuFarmacia Then
            Farmacia()
        End If

    End Sub


    Private Sub Pacientes()  'Formulario que no se repite
        Dim fPacientes As New frmPacientes
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fPacientes.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fPacientes.MdiParent = Me
        fPacientes.Show()
    End Sub

    Private Sub Citas()
        Dim fCitas As New frmCitas
        fCitas.MdiParent = Me
        fCitas.Show()
    End Sub

    Private Sub HistoriaClinica()
        Dim fHistoriaClinica As New frmHistoriaClinica
        fHistoriaClinica.MdiParent = Me
        fHistoriaClinica.Show()
    End Sub

    Private Sub Recetas()
        Dim fRecetas As New frmRecetas
        fRecetas.MdiParent = Me
        fRecetas.Show()
    End Sub

    Private Sub Facturas()
        Dim fFacturas As New frmFacturas
        fFacturas.MdiParent = Me
        fFacturas.Show()
    End Sub

    Private Sub Boletas()
        Dim fBoletas As New frmBoletas
        fBoletas.MdiParent = Me
        fBoletas.Show()
    End Sub

    Private Sub Farmacia() 'Formulario que no se repite
        Dim fFarmacia As New frmFarmacia
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fFarmacia.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fFarmacia.MdiParent = Me
        fFarmacia.Show()
    End Sub

#End Region

#Region "Servicios Regiones"
    Private Sub ServiciosOpciones(sender As Object, e As EventArgs) _
        Handles mnuMédicos.Click, mnuEspecialidades.Click, mnuConsultorios.Click,
                mnuMedicamentos.Click, mnuLaboratoriosDeReceta.Click, mnuDistribuidoras.Click

        If sender Is mnuMédicos Then
            Medicos()
        ElseIf sender Is mnuEspecialidades Then
            Especialidades()
        ElseIf sender Is mnuConsultorios Then
            Consultorios()
        ElseIf sender Is mnuMedicamentos Then
            Medicamentos()
        ElseIf sender Is mnuLaboratoriosDeReceta Then
            LaboratoriosReceta()
        ElseIf sender Is mnuDistribuidoras Then
            Distribuidoras()
        End If

    End Sub


    Private Sub Medicos()  'Formulario que no se repite
        Dim fMedicos As New frmMedicos
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fMedicos.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fMedicos.MdiParent = Me
        fMedicos.Show()
    End Sub

    Private Sub Especialidades()  'Formulario que no se repite
        Dim fEspecialidades As New frmEspecialidades
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fEspecialidades.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fEspecialidades.MdiParent = Me
        fEspecialidades.Show()
    End Sub

    Private Sub Consultorios()  'Formulario que no se repite
        Dim fConsultorios As New frmConsultorios
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fConsultorios.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fConsultorios.MdiParent = Me
        fConsultorios.Show()
    End Sub

    Private Sub Medicamentos()  'Formulario que no se repite
        Dim fMedicamentos As New frmMedicamentos
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fMedicamentos.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fMedicamentos.MdiParent = Me
        fMedicamentos.Show()
    End Sub

    Private Sub LaboratoriosReceta()  'Formulario que no se repite
        Dim fLaboratoriosReceta As New frmRecetaLaboratorios
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fLaboratoriosReceta.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fLaboratoriosReceta.MdiParent = Me
        fLaboratoriosReceta.Show()
    End Sub
    Private Sub Distribuidoras()  'Formulario que no se repite
        Dim fDistribuidoras As New frmDistribuidoras
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fDistribuidoras.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fDistribuidoras.MdiParent = Me
        fDistribuidoras.Show()
    End Sub
#End Region

#Region "Mantenimiento Regiones"
    Private Sub MantenimientoOpciones(sender As Object, e As EventArgs) _
        Handles mnuEmpleados.Click, mnuCategoriasReceta.Click,
                mnuDetalleFactura.Click, mnuDetalleBoleta.Click

        If sender Is mnuEmpleados Then
            Empleados()
        ElseIf sender Is mnuCategoriasReceta Then
            CategoriasReceta()
        ElseIf sender Is mnuDetalleFactura Then
            DetalleFactura()
        ElseIf sender Is mnuDetalleBoleta Then
            DetalleBoleta()
        End If

    End Sub


    Private Sub Empleados()  'Formulario que no se repite
        Dim fEmpleados As New frmEmpleados
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fEmpleados.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fEmpleados.MdiParent = Me
        fEmpleados.Show()
    End Sub

    Private Sub CategoriasReceta()  'Formulario que no se repite
        Dim fCategoriasReceta As New frmRecetaCategorias
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fCategoriasReceta.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fCategoriasReceta.MdiParent = Me
        fCategoriasReceta.Show()
    End Sub

    Private Sub DetalleFactura()  'Formulario que no se repite
        Dim fDetalleFactura As New frmFacturaDetalle
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fDetalleFactura.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fDetalleFactura.MdiParent = Me
        fDetalleFactura.Show()
    End Sub

    Private Sub DetalleBoleta()  'Formulario que no se repite
        Dim fDetalleBoleta As New frmBoletaDetalle
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fDetalleBoleta.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fDetalleBoleta.MdiParent = Me
        fDetalleBoleta.Show()
    End Sub

#End Region

#Region "Seguridad Regiones"
    Private Sub SeguridadOpciones(sender As Object, e As EventArgs) _
        Handles mnuUsuarios.Click, mnuUsuariosEmpleados.Click, mnuUsuariosMedicos.Click

        If sender Is mnuUsuarios Then
            Usuarios()
        ElseIf sender Is mnuUsuariosEmpleados Then
            UsuariosEmpleados()
        ElseIf sender Is mnuUsuariosMedicos Then
            UsuariosMedicos()
        End If

    End Sub


    Private Sub Usuarios()  'Formulario que no se repite
        Dim fUsuarios As New frmUsuarios
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fUsuarios.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fUsuarios.MdiParent = Me
        fUsuarios.Show()
    End Sub

    Private Sub UsuariosEmpleados()  'Formulario que no se repite
        Dim fUsuariosEmpleados As New frmUsuariosEmpleados
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fUsuariosEmpleados.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fUsuariosEmpleados.MdiParent = Me
        fUsuariosEmpleados.Show()
    End Sub

    Private Sub UsuariosMedicos()  'Formulario que no se repite
        Dim fUsuariosMedicos As New frmUsuariosMedicos
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fUsuariosMedicos.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fUsuariosMedicos.MdiParent = Me
        fUsuariosMedicos.Show()
    End Sub


#End Region

#Region "Ayuda Regiones"
    Private Sub AyudaOpciones(sender As Object, e As EventArgs) _
    Handles mnuAcercaDeClinicaSaludIntegral.Click

        If sender Is mnuAcercaDeClinicaSaludIntegral Then
            AcercaDeSaludIntegral()
        End If
    End Sub

    Private Sub AcercaDeSaludIntegral()
        Dim fAcercaDeClinicaSaludIntegral As New frmAcercaDeClinicaSaludIntegral
        fAcercaDeClinicaSaludIntegral.ShowDialog()
    End Sub

    Private Sub CerrarSesión(sender As Object, e As EventArgs) Handles mnuCerrarSesión.Click
        Close()
    End Sub

#End Region

#Region "Botones Regiones"
    Private Sub BotonesOpciones(sender As Object, e As EventArgs) _
        Handles btnMedicos.Click, btnPacientes.Click, btnCitas.Click, btnRecetas.Click, btnFacturas.Click, btnUsuarios.Click, btnFarmacia.Click, btnSalir.Click
        If sender Is btnMedicos Then
            btMedicos()
        ElseIf sender Is btnPacientes Then
            btPacientes()
        ElseIf sender Is btnCitas Then
            btCitas()
        ElseIf sender Is btnRecetas Then
            btRecetas()
        ElseIf sender Is btnFacturas Then
            btFacturas()
        ElseIf sender Is btnUsuarios Then
            btUsuarios()
        ElseIf sender Is btnFarmacia Then
            btFarmacia()
        ElseIf sender Is btnSalir Then
            btSalir()
        End If
    End Sub

    Private Sub btMedicos()  'Formulario que no se repite
        Dim fMedicos As New frmMedicos
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fMedicos.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fMedicos.MdiParent = Me
        fMedicos.Show()
    End Sub

    Private Sub btPacientes()  'Formulario que no se repite
        Dim fPacientes As New frmPacientes
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fPacientes.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fPacientes.MdiParent = Me
        fPacientes.Show()
    End Sub

    Private Sub btCitas()
        Dim fCitas As New frmCitas
        fCitas.MdiParent = Me
        fCitas.Show()
    End Sub

    Private Sub btRecetas()
        Dim fRecetas As New frmRecetas
        fRecetas.MdiParent = Me
        fRecetas.Show()
    End Sub

    Private Sub btFacturas()
        Dim fFacturas As New frmFacturas
        fFacturas.MdiParent = Me
        fFacturas.Show()
    End Sub

    Private Sub btUsuarios()  'Formulario que no se repite
        Dim fUsuarios As New frmUsuarios
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fUsuarios.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fUsuarios.MdiParent = Me
        fUsuarios.Show()
    End Sub

    Private Sub btFarmacia() 'Formulario que no se repite
        Dim fFarmacia As New frmFarmacia
        Dim F As Form
        Dim fHijos As FrmPrincipal = Me
        For Each F In fHijos.MdiChildren
            If F.Name = fFarmacia.Name Then
                F.Select()
                Exit Sub
            End If
        Next
        fFarmacia.MdiParent = Me
        fFarmacia.Show()
    End Sub

    Private Sub btSalir()
        Close()
    End Sub

#End Region

End Class