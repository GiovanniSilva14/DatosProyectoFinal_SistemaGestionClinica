Imports System.Data
Imports System.Data.SqlClient

Public Class frmMedicos

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daMedicos As SqlDataAdapter
    Private vPosicion As Integer

    Private Sub MedicosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        ActualizarFormulario()
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daMedicos = New SqlDataAdapter("Atenciones.spMedicosListaSinBorrados", cn)
        daMedicos.SelectCommand.CommandType = CommandType.StoredProcedure
        daMedicos.Fill(dsDatos, "Medicos")
    End Sub

    Private Sub ActualizarFormulario()
        Dim hayRegistros As Boolean = dsDatos.Tables("Medicos").Rows.Count > 0
        If hayRegistros Then
            If vPosicion >= dsDatos.Tables("Medicos").Rows.Count Then vPosicion = 0
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, hayRegistros, hayRegistros, False, True, True)
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Medicos").Rows.Count = 0 Then Exit Sub
        Dim fila As DataRow = dsDatos.Tables("Medicos").Rows(vPosicion)
        txtMedicosCodigo.Text = fila("MedicosCodigo").ToString().Trim()
        txtMedicosNombres.Text = fila("MedicosNombres").ToString().Trim()
        txtMedicosApellidos.Text = fila("MedicosApellidos").ToString().Trim()
        txtMedicosCMP.Text = fila("MedicosCMP").ToString().Trim()
        txtMedicosTelefono.Text = fila("MedicosTelefono").ToString().Trim()
        txtMedicosCorreo.Text = fila("MedicosCorreo").ToString().Trim()
        txtEspecialidadesCodigo.Text = fila("EspecialidadesCodigo").ToString().Trim()
        txtConsultoriosCodigo.Text = fila("ConsultoriosCodigo").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvMedicosRegistrados.Items.Clear()
        For Each fila As DataRow In dsDatos.Tables("Medicos").Rows
            Dim item As New ListViewItem(fila("MedicosCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicosNombres").ToString().Trim())
            item.SubItems.Add(fila("MedicosApellidos").ToString().Trim())
            item.SubItems.Add(fila("MedicosCMP").ToString().Trim())
            item.SubItems.Add(fila("MedicosTelefono").ToString().Trim())
            item.SubItems.Add(fila("MedicosCorreo").ToString().Trim())
            item.SubItems.Add(fila("EspecialidadesCodigo").ToString().Trim())
            item.SubItems.Add(fila("ConsultoriosCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicosEstado").ToString().Trim())
            lvMedicosRegistrados.Items.Add(item)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pNombres As Boolean,
                          pApellidos As Boolean, pCMP As Boolean,
                          pTelefono As Boolean, pCorreo As Boolean,
                          pEspecialidad As Boolean, pConsultorio As Boolean,
                          pLista As Boolean)
        txtMedicosCodigo.Enabled = pCodigo
        txtMedicosNombres.Enabled = pNombres
        txtMedicosApellidos.Enabled = pApellidos
        txtMedicosCMP.Enabled = pCMP
        txtMedicosTelefono.Enabled = pTelefono
        txtMedicosCorreo.Enabled = pCorreo
        txtEspecialidadesCodigo.Enabled = pEspecialidad
        txtConsultoriosCodigo.Enabled = pConsultorio
        lvMedicosRegistrados.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean, pEditar As Boolean,
                        pEliminar As Boolean, pCancelar As Boolean,
                        pCerrar As Boolean, pEliminados As Boolean)
        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub LimpiarControles()
        txtMedicosCodigo.Clear()
        txtMedicosNombres.Clear()
        txtMedicosApellidos.Clear()
        txtMedicosCMP.Clear()
        txtMedicosTelefono.Clear()
        txtMedicosCorreo.Clear()
        txtEspecialidadesCodigo.Clear()
        txtConsultoriosCodigo.Clear()
    End Sub

    Private Function ValidarDatos() As Boolean
        If txtMedicosCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código del médico debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosCodigo.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtMedicosNombres.Text) OrElse txtMedicosNombres.Text.Trim().Length > 100 Then
            MessageBox.Show("Ingrese nombres válidos de hasta 100 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosNombres.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtMedicosApellidos.Text) OrElse txtMedicosApellidos.Text.Trim().Length > 100 Then
            MessageBox.Show("Ingrese apellidos válidos de hasta 100 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosApellidos.Focus() : Return False
        End If
        If txtMedicosCMP.Text.Trim().Length <> 10 Then
            MessageBox.Show("El CMP debe tener 10 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosCMP.Focus() : Return False
        End If
        If txtMedicosTelefono.Text.Trim().Length > 0 AndAlso txtMedicosTelefono.Text.Trim().Length <> 9 Then
            MessageBox.Show("El teléfono debe tener 9 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosTelefono.Focus() : Return False
        End If
        If txtMedicosCorreo.Text.Trim().Length > 100 Then
            MessageBox.Show("El correo no puede superar 100 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicosCorreo.Focus() : Return False
        End If
        If txtEspecialidadesCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de especialidad debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEspecialidadesCodigo.Focus() : Return False
        End If
        If txtConsultoriosCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de consultorio debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtConsultoriosCodigo.Focus() : Return False
        End If
        Return True
    End Function

    Private Sub MedicosSeleccion(sender As Object, e As EventArgs) Handles lvMedicosRegistrados.SelectedIndexChanged
        If lvMedicosRegistrados.SelectedItems.Count = 0 Then Exit Sub
        PosicionarPorCodigo(lvMedicosRegistrados.SelectedItems(0).Text.Trim())
        MostrarRegistro()
    End Sub

    Private Sub MedicosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            LimpiarControles()
            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)
            txtMedicosCodigo.Focus()
            Exit Sub
        End If
        If Not ValidarDatos() Then Exit Sub
        Dim codigoActual As String = txtMedicosCodigo.Text.Trim()
        Using comando As New SqlCommand("Atenciones.spMedicosInsertarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            AgregarParametros(comando, True)
            If Not EjecutarComando(comando, "Médico registrado.") Then Exit Sub
        End Using
        cmdAgregar.Text = "Agregar"
        CrearDataSet() : LlenarLista() : PosicionarPorCodigo(codigoActual) : ActualizarFormulario()
    End Sub

    Private Sub MedicosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click
        If dsDatos.Tables("Medicos").Rows.Count = 0 Then Exit Sub
        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtMedicosNombres.Focus()
            Exit Sub
        End If
        If Not ValidarDatos() Then Exit Sub
        Dim codigoActual As String = txtMedicosCodigo.Text.Trim()
        Using comando As New SqlCommand("Atenciones.spMedicosEditarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            AgregarParametros(comando, False)
            If Not EjecutarComando(comando, "Médico modificado.") Then Exit Sub
        End Using
        cmdEditar.Text = "Editar"
        CrearDataSet() : LlenarLista() : PosicionarPorCodigo(codigoActual) : ActualizarFormulario()
    End Sub

    Private Sub AgregarParametros(comando As SqlCommand, incluirEstado As Boolean)
        comando.Parameters.Add("@MedicosCodigo", SqlDbType.NChar, 7).Value = txtMedicosCodigo.Text.Trim()
        comando.Parameters.Add("@MedicosNombres", SqlDbType.NVarChar, 100).Value = txtMedicosNombres.Text.Trim()
        comando.Parameters.Add("@MedicosApellidos", SqlDbType.NVarChar, 100).Value = txtMedicosApellidos.Text.Trim()
        comando.Parameters.Add("@MedicosCMP", SqlDbType.NChar, 10).Value = txtMedicosCMP.Text.Trim()
        comando.Parameters.Add("@MedicosTelefono", SqlDbType.NChar, 9).Value = txtMedicosTelefono.Text.Trim()
        comando.Parameters.Add("@MedicosCorreo", SqlDbType.NVarChar, 100).Value = txtMedicosCorreo.Text.Trim()
        comando.Parameters.Add("@EspecialidadesCodigo", SqlDbType.NChar, 7).Value = txtEspecialidadesCodigo.Text.Trim()
        comando.Parameters.Add("@ConsultoriosCodigo", SqlDbType.NChar, 7).Value = txtConsultoriosCodigo.Text.Trim()
        If incluirEstado Then comando.Parameters.Add("@MedicosEstado", SqlDbType.NChar, 1).Value = "A"
    End Sub

    Private Function EjecutarComando(comando As SqlCommand, mensaje As String) As Boolean
        Try
            If cn.State <> ConnectionState.Closed Then cn.Close()
            cn.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show(mensaje, "Médicos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As SqlException
            MessageBox.Show("No se pudo completar la operación." & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
        End Try
    End Function

    Private Sub MedicosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Medicos").Rows.Count = 0 Then Exit Sub
        If MessageBox.Show("¿Desea eliminar al médico " & txtMedicosNombres.Text.Trim() & " " &
                           txtMedicosApellidos.Text.Trim() & "?", "Eliminación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) <> DialogResult.OK Then Exit Sub
        Using comando As New SqlCommand("Atenciones.spMedicosEliminarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@MedicosCodigo", SqlDbType.NChar, 7).Value = txtMedicosCodigo.Text.Trim()
            If Not EjecutarComando(comando, "Médico eliminado.") Then Exit Sub
        End Using
        vPosicion = 0 : CrearDataSet() : LlenarLista() : ActualizarFormulario()
    End Sub

    Private Sub PosicionarPorCodigo(codigo As String)
        vPosicion = 0
        For i As Integer = 0 To dsDatos.Tables("Medicos").Rows.Count - 1
            If dsDatos.Tables("Medicos").Rows(i)("MedicosCodigo").ToString().Trim() = codigo Then
                vPosicion = i : Exit For
            End If
        Next
    End Sub

    Private Sub MedicosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar" : cmdEditar.Text = "Editar" : ActualizarFormulario()
    End Sub

    Private Sub MedicosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub MedicosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vMedicoRecuperado = 0
        Using formulario As New frmMedicosEliminados()
            formulario.ShowDialog()
        End Using
        If vMedicoRecuperado = 1 Then
            vPosicion = 0 : CrearDataSet() : LlenarLista() : ActualizarFormulario()
        End If
    End Sub

End Class
