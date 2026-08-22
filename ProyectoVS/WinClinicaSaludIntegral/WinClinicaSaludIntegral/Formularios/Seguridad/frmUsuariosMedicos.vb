Imports System.Data
Imports System.Data.SqlClient

Public Class frmUsuariosMedicos

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daUsuariosMedicos As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub UsuariosMedicosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("UsuariosMedicos").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("UsuariosMedicos").Rows.Count > 0,
                dsDatos.Tables("UsuariosMedicos").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daUsuariosMedicos = New SqlDataAdapter("Seguridad.spUsuariosMedicosListaSinBorrados", cn)
        daUsuariosMedicos.SelectCommand.CommandType = CommandType.StoredProcedure
        daUsuariosMedicos.Fill(dsDatos, "UsuariosMedicos")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("UsuariosMedicos").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("UsuariosMedicos").Rows.Count Then
            vPosicion = 0
        End If

        txtUsuariosMedicosCodigo.Text = dsDatos.Tables("UsuariosMedicos").Rows(vPosicion).Item("UsuariosMedicosCodigo").ToString().Trim()
        txtUsuariosCodigo.Text = dsDatos.Tables("UsuariosMedicos").Rows(vPosicion).Item("UsuariosCodigo").ToString().Trim()
        txtMedicosCodigo.Text = dsDatos.Tables("UsuariosMedicos").Rows(vPosicion).Item("MedicosCodigo").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvUsuariosMedicosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("UsuariosMedicos").Rows.Count - 1
            lvUsuariosMedicosRegistrados.Items.Add(dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosMedicosCodigo").ToString().Trim())
            lvUsuariosMedicosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosCodigo").ToString().Trim())
            lvUsuariosMedicosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosMedicos").Rows(i).Item("MedicosCodigo").ToString().Trim())
            lvUsuariosMedicosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosMedicosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pRelacionCodigo As Boolean, pUsuarioCodigo As Boolean,
                          pMedicoCodigo As Boolean, pLista As Boolean)
        txtUsuariosMedicosCodigo.Enabled = pRelacionCodigo
        txtUsuariosCodigo.Enabled = pUsuarioCodigo
        txtMedicosCodigo.Enabled = pMedicoCodigo
        lvUsuariosMedicosRegistrados.Enabled = pLista
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
        txtUsuariosMedicosCodigo.Clear()
        txtUsuariosCodigo.Clear()
        txtMedicosCodigo.Clear()
    End Sub

    Private Sub UsuariosMedicosSeleccion(sender As Object, e As EventArgs) Handles lvUsuariosMedicosRegistrados.SelectedIndexChanged
        If lvUsuariosMedicosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("UsuariosMedicos").Rows.Count - 1
            If lvUsuariosMedicosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosMedicosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub UsuariosMedicosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtUsuariosMedicosCodigo.Focus()

        Else
            If txtUsuariosMedicosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de relación debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosMedicosCodigo.Focus()
                Exit Sub
            End If

            If txtUsuariosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de usuario debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosCodigo.Focus()
                Exit Sub
            End If

            If txtMedicosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de médico debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicosCodigo.Focus()
                Exit Sub
            End If


            Dim coUsuarioMedicoNuevo As New SqlCommand("Seguridad.spUsuariosMedicosInsertarRegistro", cn)
            coUsuarioMedicoNuevo.CommandType = CommandType.StoredProcedure

            coUsuarioMedicoNuevo.Parameters.Add(New SqlParameter("@UsuariosMedicosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtUsuariosMedicosCodigo.Text.Trim()
            coUsuarioMedicoNuevo.Parameters.Add(New SqlParameter("@UsuariosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioMedicoNuevo.Parameters.Add(New SqlParameter("@MedicosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtMedicosCodigo.Text.Trim()
            coUsuarioMedicoNuevo.Parameters.Add(New SqlParameter("@UsuariosMedicosEstado",
                                                   SqlDbType.NChar, 1,
                                                   ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coUsuarioMedicoNuevo.ExecuteNonQuery()
                MessageBox.Show("Relación entre usuario y médico registrada.", "Inserción",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioMedicoNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtUsuariosMedicosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("UsuariosMedicos").Rows.Count - 1
                If dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosMedicosCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub UsuariosMedicosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("UsuariosMedicos").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, False)
            Botones(False, True, False, True, False, False)
            txtUsuariosCodigo.Focus()

        Else
            If txtUsuariosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de usuario debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosCodigo.Focus()
                Exit Sub
            End If

            If txtMedicosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de médico debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicosCodigo.Focus()
                Exit Sub
            End If

            Dim coUsuarioMedicoEditar As New SqlCommand("Seguridad.spUsuariosMedicosEditarRegistro", cn)
            coUsuarioMedicoEditar.CommandType = CommandType.StoredProcedure

            coUsuarioMedicoEditar.Parameters.Add(New SqlParameter("@UsuariosMedicosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtUsuariosMedicosCodigo.Text.Trim()
            coUsuarioMedicoEditar.Parameters.Add(New SqlParameter("@UsuariosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioMedicoEditar.Parameters.Add(New SqlParameter("@MedicosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtMedicosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coUsuarioMedicoEditar.ExecuteNonQuery()
                MessageBox.Show("Relación entre usuario y médico modificada.", "Edición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioMedicoEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtUsuariosMedicosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("UsuariosMedicos").Rows.Count - 1
                If dsDatos.Tables("UsuariosMedicos").Rows(i).Item("UsuariosMedicosCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub UsuariosMedicosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("UsuariosMedicos").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la relación seleccionada?", "Eliminación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coUsuarioMedicoEliminar As New SqlCommand("Seguridad.spUsuariosMedicosEliminarRegistro", cn)
            coUsuarioMedicoEliminar.CommandType = CommandType.StoredProcedure
            coUsuarioMedicoEliminar.Parameters.Add(New SqlParameter("@UsuariosMedicosCodigo",
                                                     SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value = txtUsuariosMedicosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioMedicoEliminar.ExecuteNonQuery()
                MessageBox.Show("Relación eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioMedicoEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("UsuariosMedicos").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("UsuariosMedicos").Rows.Count > 0,
                    dsDatos.Tables("UsuariosMedicos").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub UsuariosMedicosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("UsuariosMedicos").Rows.Count > 0,
                dsDatos.Tables("UsuariosMedicos").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("UsuariosMedicos").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub UsuariosMedicosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub UsuariosMedicosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vUsuarioMedicoRecuperado = 0
        Dim formulario As New frmUsuariosMedicosEliminados()
        formulario.ShowDialog()
        formulario.Dispose()

        If vUsuarioMedicoRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("UsuariosMedicos").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("UsuariosMedicos").Rows.Count > 0,
                    dsDatos.Tables("UsuariosMedicos").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
