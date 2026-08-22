' Name Spaces
Imports System.Data
Imports System.Data.SqlClient

Public Class frmHistoriaClinica

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daHistoriaClinica As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub HistoriaClinicaCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        MostrarRegistro()
        LlenarLista()
        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daHistoriaClinica = New SqlDataAdapter("Atenciones.spHistoriaClinicaListaSinBorrados", cn)
        daHistoriaClinica.Fill(dsDatos, "HistoriaClinica")
    End Sub

    Private Sub MostrarRegistro()
        txtHistoriaClinicaCodigo.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaCodigo").ToString
        txtPacientesCodigo.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("PacientesCodigo").ToString
        dtpHistoriaClinicaFechaApertura.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaFechaApertura").ToString
        txtHistoriaClinicaGrupoSanguineo.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaGrupoSanguineo").ToString
        txtHistoriaClinicaAlergias.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaAlergias").ToString
        txtHistoriaClinicaAntecedentes.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaAntecedentes").ToString
        txtHistoriaClinicaObservaciones.Text = dsDatos.Tables("HistoriaClinica").Rows(vPosicion).Item("HistoriaClinicaObservaciones").ToString
    End Sub

    Private Sub LlenarLista()
        lvHistoriaClinicaRegistrados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("HistoriaClinica").Rows.Count - 1
            lvHistoriaClinicaRegistrados.Items.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaCodigo").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("PacientesCodigo").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaFechaApertura").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaGrupoSanguineo").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaAlergias").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaAntecedentes").ToString)
            lvHistoriaClinicaRegistrados.Items(i).SubItems.Add(dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaObservaciones").ToString)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pPaciente As Boolean, pFechaApertura As Boolean, pGrupoSanguineo As Boolean, pAlergias As Boolean,
                          pAntecedentes As Boolean, pObservaciones As Boolean, pFake As Boolean, pLista As Boolean)
        txtHistoriaClinicaCodigo.Enabled = pCodigo
        txtPacientesCodigo.Enabled = pPaciente
        dtpHistoriaClinicaFechaApertura.Enabled = pFechaApertura
        txtHistoriaClinicaGrupoSanguineo.Enabled = pGrupoSanguineo
        txtHistoriaClinicaAlergias.Enabled = pAlergias
        txtHistoriaClinicaAntecedentes.Enabled = pAntecedentes
        txtHistoriaClinicaObservaciones.Enabled = pObservaciones
        lvHistoriaClinicaRegistrados.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean, pEditar As Boolean, pEliminar As Boolean, pCancelar As Boolean, pCerrar As Boolean, pEliminados As Boolean)
        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub HistoriaClinicaSeleccion(sender As Object, e As EventArgs) Handles lvHistoriaClinicaRegistrados.SelectedIndexChanged
        If lvHistoriaClinicaRegistrados.SelectedItems.Count = 0 Then Exit Sub
        For i As Integer = 0 To dsDatos.Tables("HistoriaClinica").Rows.Count - 1
            If lvHistoriaClinicaRegistrados.SelectedItems(0).Text = dsDatos.Tables("HistoriaClinica").Rows(i).Item("HistoriaClinicaCodigo") Then
                vPosicion = i
                Exit For
            End If
        Next
        MostrarRegistro()
    End Sub

    Private Sub HistoriaClinicaAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            txtHistoriaClinicaCodigo.Clear()
            txtPacientesCodigo.Clear()
            dtpHistoriaClinicaFechaApertura.Value = Date.Today
            txtHistoriaClinicaGrupoSanguineo.Clear()
            txtHistoriaClinicaAlergias.Clear()
            txtHistoriaClinicaAntecedentes.Clear()
            txtHistoriaClinicaObservaciones.Clear()

            txtHistoriaClinicaCodigo.Focus()

        Else

            ' Código
            If Len(Trim(txtHistoriaClinicaCodigo.Text)) = 0 Or Len(Trim(txtHistoriaClinicaCodigo.Text)) <> 7 Then
                MessageBox.Show("Código incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaCodigo.Focus()
                Exit Sub
            End If

            ' Paciente
            If Len(Trim(txtPacientesCodigo.Text)) = 0 Or Len(Trim(txtPacientesCodigo.Text)) <> 7 Then
                MessageBox.Show("Falta código de Paciente o es incorrecto (7 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCodigo.Focus()
                Exit Sub
            End If

            ' Grupo Sanguíneo
            If Len(Trim(txtHistoriaClinicaGrupoSanguineo.Text)) = 0 Then
                MessageBox.Show("Falta Grupo Sanguíneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaGrupoSanguineo.Focus()
                Exit Sub
            End If

            ' Si Alergias está vacío simplemente guardar vacío
            If Len(Trim(txtHistoriaClinicaAlergias.Text)) = 0 Then
                txtHistoriaClinicaAlergias.Text = ""
            End If

            ' Antecedentes
            If Len(Trim(txtHistoriaClinicaAntecedentes.Text)) = 0 Then
                MessageBox.Show("Falta Antecedentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaAntecedentes.Focus()
                Exit Sub
            End If

            ' Observaciones
            If Len(Trim(txtHistoriaClinicaObservaciones.Text)) = 0 Then
                MessageBox.Show("Falta Observaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaObservaciones.Focus()
                Exit Sub
            End If

            Dim coHistoriaClinicaNuevo As New SqlCommand("Atenciones.spHistoriaClinicaInsertarRegistro", cn)
            coHistoriaClinicaNuevo.CommandType = CommandType.StoredProcedure

            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaCodigo", SqlDbType.NChar, 7)).Value = txtHistoriaClinicaCodigo.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7)).Value = txtPacientesCodigo.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaFechaApertura", SqlDbType.Date)).Value = dtpHistoriaClinicaFechaApertura.Value.Date
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaGrupoSanguineo", SqlDbType.NVarChar, 5)).Value = txtHistoriaClinicaGrupoSanguineo.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaAlergias", SqlDbType.NVarChar, 250)).Value = txtHistoriaClinicaAlergias.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaAntecedentes", SqlDbType.NVarChar, 500)).Value = txtHistoriaClinicaAntecedentes.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaObservaciones", SqlDbType.NVarChar, 500)).Value = txtHistoriaClinicaObservaciones.Text
            coHistoriaClinicaNuevo.Parameters.Add(New SqlParameter("@HistoriaClinicaEstado", SqlDbType.NChar, 1)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coHistoriaClinicaNuevo.ExecuteNonQuery()
                MessageBox.Show("Historia Clínica registrada", "Inserción", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("No se pudo insertar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub

            Finally
                cn.Close()
            End Try

            CreaDataSet()
            LlenarLista()

            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)

        End If

    End Sub

    Private Sub HistoriaClinicaEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If MessageBox.Show("¿Desea eliminar la Historia Clínica del Paciente " & vbCrLf & Trim(txtPacientesCodigo.Text) & " ?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            Dim coHistoriaClinicaEliminar As New SqlCommand("Atenciones.spHistoriaClinicaEliminarRegistro", cn)
            coHistoriaClinicaEliminar.CommandType = CommandType.StoredProcedure
            coHistoriaClinicaEliminar.Parameters.Add(New SqlParameter("@HistoriaClinicaCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtHistoriaClinicaCodigo.Text
            cn.Open()
            coHistoriaClinicaEliminar.ExecuteNonQuery()
            cn.Close()
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            MostrarRegistro()
            MessageBox.Show("Historia Clínica eliminada", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub HistoriaClinicaEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If cmdEditar.Text = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)

        Else
            ' Paciente
            If Len(Trim(txtPacientesCodigo.Text)) = 0 Or Len(Trim(txtPacientesCodigo.Text)) <> 7 Then
                MessageBox.Show("Falta código de Paciente o es incorrecto (7 caracteres)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCodigo.Focus()
                Exit Sub
            End If

            ' Grupo sanguíneo
            If Len(Trim(txtHistoriaClinicaGrupoSanguineo.Text)) = 0 Then
                MessageBox.Show("Falta Grupo Sanguíneo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaGrupoSanguineo.Focus()
                Exit Sub
            End If

            ' Alergias puede quedar vacío
            If Len(Trim(txtHistoriaClinicaAlergias.Text)) = 0 Then
                txtHistoriaClinicaAlergias.Text = ""
            End If

            ' Antecedentes
            If Len(Trim(txtHistoriaClinicaAntecedentes.Text)) = 0 Then
                MessageBox.Show("Falta Antecedentes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaAntecedentes.Focus()
                Exit Sub
            End If

            ' Observaciones
            If Len(Trim(txtHistoriaClinicaObservaciones.Text)) = 0 Then
                MessageBox.Show("Falta Observaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtHistoriaClinicaObservaciones.Focus()
                Exit Sub
            End If

            Dim coHistoriaClinicaEditar As New SqlCommand("Atenciones.spHistoriaClinicaEditarRegistro", cn)
            coHistoriaClinicaEditar.CommandType = CommandType.StoredProcedure

            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtHistoriaClinicaCodigo.Text
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtPacientesCodigo.Text
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaFechaApertura", SqlDbType.Date)).Value = dtpHistoriaClinicaFechaApertura.Value.Date
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaGrupoSanguineo", SqlDbType.NVarChar, 5, ParameterDirection.Input)).Value = txtHistoriaClinicaGrupoSanguineo.Text
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaAlergias", SqlDbType.NVarChar, 250, ParameterDirection.Input)).Value = txtHistoriaClinicaAlergias.Text
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaAntecedentes", SqlDbType.NVarChar, 500, ParameterDirection.Input)).Value = txtHistoriaClinicaAntecedentes.Text
            coHistoriaClinicaEditar.Parameters.Add(New SqlParameter("@HistoriaClinicaObservaciones", SqlDbType.NVarChar, 500, ParameterDirection.Input)).Value = txtHistoriaClinicaObservaciones.Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try
                cn.Open()
                coHistoriaClinicaEditar.ExecuteNonQuery()
                MessageBox.Show("Historia Clínica modificada", "Edición de Historia Clínica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Catch ex As Exception
                MessageBox.Show("No se pudo modificar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub

            Finally
                cn.Close()
            End Try

            CreaDataSet()
            LlenarLista()

            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If

    End Sub

    Private Sub HistoriaClinicaCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
        MostrarRegistro()
    End Sub

    Private Sub HistoriaClinicaCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub HistoriaClinicaEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click

        vHistoriaClinicaRecuperada = 0

        Dim fHistoriaClinicaEliminados As New frmHistoriaClinicaEliminados
        fHistoriaClinicaEliminados.ShowDialog()

        If vHistoriaClinicaRecuperada = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("HistoriaClinica").Rows.Count > 0 Then
                MostrarRegistro()
            End If
        End If

    End Sub

End Class