Imports System.Data
Imports System.Data.SqlClient

Public Class frmUsuariosEmpleados

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daUsuariosEmpleados As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub UsuariosEmpleadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0,
                dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daUsuariosEmpleados = New SqlDataAdapter("Seguridad.spUsuariosEmpleadosListaSinBorrados", cn)
        daUsuariosEmpleados.SelectCommand.CommandType = CommandType.StoredProcedure
        daUsuariosEmpleados.Fill(dsDatos, "UsuariosEmpleados")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("UsuariosEmpleados").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("UsuariosEmpleados").Rows.Count Then
            vPosicion = 0
        End If

        txtUsuariosEmpleadosCodigo.Text = dsDatos.Tables("UsuariosEmpleados").Rows(vPosicion).Item("UsuariosEmpleadosCodigo").ToString().Trim()
        txtUsuariosCodigo.Text = dsDatos.Tables("UsuariosEmpleados").Rows(vPosicion).Item("UsuariosCodigo").ToString().Trim()
        txtEmpleadosCodigo.Text = dsDatos.Tables("UsuariosEmpleados").Rows(vPosicion).Item("EmpleadosCodigo").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvUsuariosEmpleadosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("UsuariosEmpleados").Rows.Count - 1
            lvUsuariosEmpleadosRegistrados.Items.Add(dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosEmpleadosCodigo").ToString().Trim())
            lvUsuariosEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosCodigo").ToString().Trim())
            lvUsuariosEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("EmpleadosCodigo").ToString().Trim())
            lvUsuariosEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosEmpleadosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pRelacionCodigo As Boolean, pUsuarioCodigo As Boolean,
                          pEmpleadoCodigo As Boolean, pLista As Boolean)
        txtUsuariosEmpleadosCodigo.Enabled = pRelacionCodigo
        txtUsuariosCodigo.Enabled = pUsuarioCodigo
        txtEmpleadosCodigo.Enabled = pEmpleadoCodigo
        lvUsuariosEmpleadosRegistrados.Enabled = pLista
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
        txtUsuariosEmpleadosCodigo.Clear()
        txtUsuariosCodigo.Clear()
        txtEmpleadosCodigo.Clear()
    End Sub

    Private Sub UsuariosEmpleadosSeleccion(sender As Object, e As EventArgs) Handles lvUsuariosEmpleadosRegistrados.SelectedIndexChanged
        If lvUsuariosEmpleadosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("UsuariosEmpleados").Rows.Count - 1
            If lvUsuariosEmpleadosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosEmpleadosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub UsuariosEmpleadosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtUsuariosEmpleadosCodigo.Focus()

        Else
            If txtUsuariosEmpleadosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de relación debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosEmpleadosCodigo.Focus()
                Exit Sub
            End If

            If txtUsuariosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de usuario debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosCodigo.Focus()
                Exit Sub
            End If

            If txtEmpleadosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de empleado debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCodigo.Focus()
                Exit Sub
            End If


            Dim coUsuarioEmpleadoNuevo As New SqlCommand("Seguridad.spUsuariosEmpleadosInsertarRegistro", cn)
            coUsuarioEmpleadoNuevo.CommandType = CommandType.StoredProcedure

            coUsuarioEmpleadoNuevo.Parameters.Add(New SqlParameter("@UsuariosEmpleadosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtUsuariosEmpleadosCodigo.Text.Trim()
            coUsuarioEmpleadoNuevo.Parameters.Add(New SqlParameter("@UsuariosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtEmpleadosCodigo.Text.Trim()
            coUsuarioEmpleadoNuevo.Parameters.Add(New SqlParameter("@UsuariosEmpleadosEstado",
                                                   SqlDbType.NChar, 1,
                                                   ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coUsuarioEmpleadoNuevo.ExecuteNonQuery()
                MessageBox.Show("Relación entre usuario y empleado registrada.", "Inserción",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioEmpleadoNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtUsuariosEmpleadosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("UsuariosEmpleados").Rows.Count - 1
                If dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosEmpleadosCodigo").ToString().Trim() = codigoRegistrado Then
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

    Private Sub UsuariosEmpleadosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("UsuariosEmpleados").Rows.Count = 0 Then Exit Sub

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

            If txtEmpleadosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de empleado debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCodigo.Focus()
                Exit Sub
            End If

            Dim coUsuarioEmpleadoEditar As New SqlCommand("Seguridad.spUsuariosEmpleadosEditarRegistro", cn)
            coUsuarioEmpleadoEditar.CommandType = CommandType.StoredProcedure

            coUsuarioEmpleadoEditar.Parameters.Add(New SqlParameter("@UsuariosEmpleadosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtUsuariosEmpleadosCodigo.Text.Trim()
            coUsuarioEmpleadoEditar.Parameters.Add(New SqlParameter("@UsuariosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtEmpleadosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coUsuarioEmpleadoEditar.ExecuteNonQuery()
                MessageBox.Show("Relación entre usuario y empleado modificada.", "Edición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioEmpleadoEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtUsuariosEmpleadosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("UsuariosEmpleados").Rows.Count - 1
                If dsDatos.Tables("UsuariosEmpleados").Rows(i).Item("UsuariosEmpleadosCodigo").ToString().Trim() = codigoEditado Then
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

    Private Sub UsuariosEmpleadosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("UsuariosEmpleados").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la relación seleccionada?", "Eliminación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coUsuarioEmpleadoEliminar As New SqlCommand("Seguridad.spUsuariosEmpleadosEliminarRegistro", cn)
            coUsuarioEmpleadoEliminar.CommandType = CommandType.StoredProcedure
            coUsuarioEmpleadoEliminar.Parameters.Add(New SqlParameter("@UsuariosEmpleadosCodigo",
                                                     SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value = txtUsuariosEmpleadosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioEmpleadoEliminar.ExecuteNonQuery()
                MessageBox.Show("Relación eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioEmpleadoEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0,
                    dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub UsuariosEmpleadosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0,
                dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub UsuariosEmpleadosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub UsuariosEmpleadosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vUsuarioEmpleadoRecuperado = 0
        Dim formulario As New frmUsuariosEmpleadosEliminados()
        formulario.ShowDialog()
        formulario.Dispose()

        If vUsuarioEmpleadoRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0,
                    dsDatos.Tables("UsuariosEmpleados").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
