Imports System.Data
Imports System.Data.SqlClient

Public Class frmCitas

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daCitas As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub CitasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        If dsDatos.Tables("Citas").Rows.Count > 0 Then
            MostrarRegistro()
        End If
        LlenarLista()
        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daCitas = New SqlDataAdapter("Atenciones.spCitasListaSinBorrados", cn)
        daCitas.Fill(dsDatos, "Citas")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Citas").Rows.Count = 0 Then Exit Sub

        txtCitasCodigo.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("CitasCodigo").ToString
        txtPacientesCodigo.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("PacientesCodigo").ToString
        txtMedicosCodigo.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("MedicosCodigo").ToString
        txtConsultoriosCodigo.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("ConsultoriosCodigo").ToString
        dtpCitasFecha.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("CitasFecha").ToString
        txtCitasHora.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("CitasHora").ToString
        txtCitasMotivo.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("CitasMotivo").ToString
        txtCitasCondiciones.Text = dsDatos.Tables("Citas").Rows(vPosicion).Item("CitasCondiciones").ToString
    End Sub

    Private Sub LlenarLista()
        lvCitasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Citas").Rows.Count - 1
            lvCitasRegistradas.Items.Add(dsDatos.Tables("Citas").Rows(i).Item("CitasCodigo").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("PacientesCodigo").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("MedicosCodigo").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("ConsultoriosCodigo").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("CitasFecha").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("CitasHora").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("CitasMotivo").ToString)
            lvCitasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Citas").Rows(i).Item("CitasCondiciones").ToString)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pPaciente As Boolean, pMedico As Boolean, pConsultorio As Boolean,
                          pFecha As Boolean, pHora As Boolean, pMotivo As Boolean, pCondiciones As Boolean,
                          pLista As Boolean)

        txtCitasCodigo.Enabled = pCodigo
        txtPacientesCodigo.Enabled = pPaciente
        txtMedicosCodigo.Enabled = pMedico
        txtConsultoriosCodigo.Enabled = pConsultorio
        dtpCitasFecha.Enabled = pFecha
        txtCitasHora.Enabled = pHora
        txtCitasMotivo.Enabled = pMotivo
        txtCitasCondiciones.Enabled = pCondiciones
        lvCitasRegistradas.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean, pEditar As Boolean, pEliminar As Boolean,
                        pCancelar As Boolean, pCerrar As Boolean, pEliminados As Boolean)

        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub CitasSeleccion(sender As Object, e As EventArgs) Handles lvCitasRegistradas.SelectedIndexChanged
        If lvCitasRegistradas.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Citas").Rows.Count - 1
            If lvCitasRegistradas.SelectedItems(0).Text = dsDatos.Tables("Citas").Rows(i).Item("CitasCodigo").ToString Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub CitasAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim = "Agregar" Then
            cmdAgregar.Text = "Guardar"

            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            txtCitasCodigo.Clear()
            txtPacientesCodigo.Clear()
            txtMedicosCodigo.Clear()
            txtConsultoriosCodigo.Clear()
            txtCitasHora.Clear()
            txtCitasMotivo.Clear()
            txtCitasCondiciones.Clear()

            txtCitasCodigo.Focus()

        Else
            If Len(Trim(txtCitasCodigo.Text)) = 0 Or Len(Trim(txtCitasCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Cita incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtPacientesCodigo.Text)) = 0 Or Len(Trim(txtPacientesCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Paciente incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtMedicosCodigo.Text)) = 0 Or Len(Trim(txtMedicosCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Médico incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicosCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtConsultoriosCodigo.Text)) = 0 Or Len(Trim(txtConsultoriosCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Consultorio incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasHora.Text)) = 0 Then
                MessageBox.Show("Falta Hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasHora.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasMotivo.Text)) = 0 Then
                MessageBox.Show("Falta Motivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasMotivo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasCondiciones.Text)) = 0 Then
                MessageBox.Show("Falta Condiciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasCondiciones.Focus()
                Exit Sub
            End If

            Dim coCitaNueva As New SqlCommand("Atenciones.spCitasInsertarRegistro", cn)
            coCitaNueva.CommandType = CommandType.StoredProcedure

            coCitaNueva.Parameters.Add(New SqlParameter("@CitasCodigo", SqlDbType.NChar, 7)).Value = txtCitasCodigo.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7)).Value = txtPacientesCodigo.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@MedicosCodigo", SqlDbType.NChar, 7)).Value = txtMedicosCodigo.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@ConsultoriosCodigo", SqlDbType.NChar, 7)).Value = txtConsultoriosCodigo.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@CitasFecha", SqlDbType.Date)).Value = dtpCitasFecha.Value.Date
            coCitaNueva.Parameters.Add(New SqlParameter("@CitasHora", SqlDbType.Time)).Value = TimeSpan.Parse(txtCitasHora.Text)
            coCitaNueva.Parameters.Add(New SqlParameter("@CitasMotivo", SqlDbType.NVarChar, 250)).Value = txtCitasMotivo.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@CitasCondiciones", SqlDbType.NVarChar, 300)).Value = txtCitasCondiciones.Text
            coCitaNueva.Parameters.Add(New SqlParameter("@CitasEstado", SqlDbType.NChar, 1)).Value = "A"

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try
                cn.Open()
                coCitaNueva.ExecuteNonQuery()
                MessageBox.Show("Cita registrada", "Inserción de Cita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CitasEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If cmdEditar.Text.Trim = "Editar" Then
            cmdEditar.Text = "Guardar"

            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)

            txtPacientesCodigo.Focus()

        Else
            If Len(Trim(txtPacientesCodigo.Text)) = 0 Or Len(Trim(txtPacientesCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Paciente incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtMedicosCodigo.Text)) = 0 Or Len(Trim(txtMedicosCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Médico incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicosCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtConsultoriosCodigo.Text)) = 0 Or Len(Trim(txtConsultoriosCodigo.Text)) <> 7 Then
                MessageBox.Show("Código Consultorio incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosCodigo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasHora.Text)) = 0 Then
                MessageBox.Show("Falta Hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasHora.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasMotivo.Text)) = 0 Then
                MessageBox.Show("Falta Motivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasMotivo.Focus()
                Exit Sub
            End If

            If Len(Trim(txtCitasCondiciones.Text)) = 0 Then
                MessageBox.Show("Falta Condiciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCitasCondiciones.Focus()
                Exit Sub
            End If

            Dim coCitaEditar As New SqlCommand("Atenciones.spCitasEditarRegistro", cn)
            coCitaEditar.CommandType = CommandType.StoredProcedure

            coCitaEditar.Parameters.Add(New SqlParameter("@CitasCodigo", SqlDbType.NChar, 7)).Value = txtCitasCodigo.Text
            coCitaEditar.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7)).Value = txtPacientesCodigo.Text
            coCitaEditar.Parameters.Add(New SqlParameter("@MedicosCodigo", SqlDbType.NChar, 7)).Value = txtMedicosCodigo.Text
            coCitaEditar.Parameters.Add(New SqlParameter("@ConsultoriosCodigo", SqlDbType.NChar, 7)).Value = txtConsultoriosCodigo.Text
            coCitaEditar.Parameters.Add(New SqlParameter("@CitasFecha", SqlDbType.Date)).Value = dtpCitasFecha.Value.Date
            coCitaEditar.Parameters.Add(New SqlParameter("@CitasHora", SqlDbType.Time)).Value = TimeSpan.Parse(txtCitasHora.Text)
            coCitaEditar.Parameters.Add(New SqlParameter("@CitasMotivo", SqlDbType.NVarChar, 250)).Value = txtCitasMotivo.Text
            coCitaEditar.Parameters.Add(New SqlParameter("@CitasCondiciones", SqlDbType.NVarChar, 300)).Value = txtCitasCondiciones.Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try
                cn.Open()
                coCitaEditar.ExecuteNonQuery()
                MessageBox.Show("Cita modificada", "Edición de Cita", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub CitasEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If MessageBox.Show("¿Desea eliminar la cita " & txtCitasCodigo.Text & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coCitaEliminar As New SqlCommand("Atenciones.spCitasEliminarRegistro", cn)
            coCitaEliminar.CommandType = CommandType.StoredProcedure
            coCitaEliminar.Parameters.Add(New SqlParameter("@CitasCodigo", SqlDbType.NChar, 7)).Value = txtCitasCodigo.Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try
                cn.Open()
                coCitaEliminar.ExecuteNonQuery()
                MessageBox.Show("Cita eliminada", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                MessageBox.Show("No se pudo eliminar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub
            Finally
                cn.Close()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Citas").Rows.Count > 0 Then
                MostrarRegistro()
            End If
        End If

    End Sub

    Private Sub CitasCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)

        If dsDatos.Tables("Citas").Rows.Count > 0 Then
            MostrarRegistro()
        End If
    End Sub

    Private Sub CitasCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub CitasEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vCitaRecuperada = 0
        Dim fCitasEliminadas As New frmCitasEliminados
        fCitasEliminadas.ShowDialog()
        If vCitaRecuperada = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("Citas").Rows.Count > 0 Then
                MostrarRegistro()
            End If
        End If

    End Sub

End Class