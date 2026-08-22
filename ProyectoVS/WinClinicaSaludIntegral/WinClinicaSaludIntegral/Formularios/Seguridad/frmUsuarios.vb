Imports System.Data
Imports System.Data.SqlClient

Public Class frmUsuarios

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daUsuarios As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub UsuariosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Usuarios").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Usuarios").Rows.Count > 0,
                dsDatos.Tables("Usuarios").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daUsuarios = New SqlDataAdapter("Seguridad.spUsuariosListaSinBorrados", cn)
        daUsuarios.SelectCommand.CommandType = CommandType.StoredProcedure
        daUsuarios.Fill(dsDatos, "Usuarios")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Usuarios").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Usuarios").Rows.Count Then
            vPosicion = 0
        End If

        txtUsuariosCodigo.Text = dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosCodigo").ToString().Trim()
        txtUsuariosNombre.Text = dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosNombre").ToString().Trim()
        txtUsuariosClave.Text = dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosClave").ToString().Trim()
        txtUsuariosRol.Text = dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosRol").ToString().Trim()

        If Not IsDBNull(dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosUltimoAcceso")) Then
            dtpUsuariosUltimoAcceso.Value = CDate(dsDatos.Tables("Usuarios").Rows(vPosicion).Item("UsuariosUltimoAcceso"))
        End If
    End Sub

    Private Sub LlenarLista()
        lvUsuariosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Usuarios").Rows.Count - 1
            lvUsuariosRegistrados.Items.Add(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosCodigo").ToString().Trim())
            lvUsuariosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosNombre").ToString().Trim())
            lvUsuariosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosClave").ToString().Trim())
            lvUsuariosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosRol").ToString().Trim())

            If IsDBNull(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosUltimoAcceso")) Then
                lvUsuariosRegistrados.Items(i).SubItems.Add("")
            Else
                lvUsuariosRegistrados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosUltimoAcceso")).ToString("dd/MM/yyyy HH:mm:ss"))
            End If

            lvUsuariosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pNombre As Boolean,
                          pClave As Boolean, pRol As Boolean,
                          pUltimoAcceso As Boolean, pLista As Boolean)
        txtUsuariosCodigo.Enabled = pCodigo
        txtUsuariosNombre.Enabled = pNombre
        txtUsuariosClave.Enabled = pClave
        txtUsuariosRol.Enabled = pRol
        dtpUsuariosUltimoAcceso.Enabled = pUltimoAcceso
        lvUsuariosRegistrados.Enabled = pLista
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
        txtUsuariosCodigo.Clear()
        txtUsuariosNombre.Clear()
        txtUsuariosClave.Clear()
        txtUsuariosRol.Clear()
        dtpUsuariosUltimoAcceso.Value = Date.Now
    End Sub

    Private Sub UsuariosSeleccion(sender As Object, e As EventArgs) Handles lvUsuariosRegistrados.SelectedIndexChanged
        If lvUsuariosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Usuarios").Rows.Count - 1
            If lvUsuariosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub UsuariosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtUsuariosCodigo.Focus()

        Else
            If txtUsuariosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsuariosNombre.Text) Then
                MessageBox.Show("Falta el nombre de usuario.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosNombre.Focus()
                Exit Sub
            End If

            If txtUsuariosNombre.Text.Trim().Length > 50 Then
                MessageBox.Show("El nombre de usuario no puede superar 50 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosNombre.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsuariosClave.Text) Then
                MessageBox.Show("Falta la clave del usuario.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosClave.Focus()
                Exit Sub
            End If

            If txtUsuariosClave.Text.Trim().Length > 50 Then
                MessageBox.Show("La clave no puede superar 50 caracteres según el procedimiento almacenado.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosClave.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsuariosRol.Text) OrElse
               txtUsuariosRol.Text.Trim().Length > 30 Then
                MessageBox.Show("Ingrese un rol válido de hasta 30 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosRol.Focus()
                Exit Sub
            End If


            Dim coUsuarioNuevo As New SqlCommand("Seguridad.spUsuariosInsertarRegistro", cn)
            coUsuarioNuevo.CommandType = CommandType.StoredProcedure

            coUsuarioNuevo.Parameters.Add(New SqlParameter("@UsuariosCodigo",
                                           SqlDbType.NChar, 7,
                                           ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioNuevo.Parameters.Add(New SqlParameter("@UsuariosNombre",
                                           SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input)).Value = txtUsuariosNombre.Text.Trim()
            coUsuarioNuevo.Parameters.Add(New SqlParameter("@UsuariosClave",
                                           SqlDbType.NVarChar, 50,
                                           ParameterDirection.Input)).Value = txtUsuariosClave.Text.Trim()
            coUsuarioNuevo.Parameters.Add(New SqlParameter("@UsuariosRol",
                                           SqlDbType.NVarChar, 30,
                                           ParameterDirection.Input)).Value = txtUsuariosRol.Text.Trim()
            coUsuarioNuevo.Parameters.Add("@UsuariosUltimoAcceso",
                                          SqlDbType.DateTime).Value = dtpUsuariosUltimoAcceso.Value
            coUsuarioNuevo.Parameters.Add(New SqlParameter("@UsuariosEstado",
                                           SqlDbType.NChar, 1,
                                           ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coUsuarioNuevo.ExecuteNonQuery()
                MessageBox.Show("Usuario registrado.", "Inserción de usuario",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el usuario." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtUsuariosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Usuarios").Rows.Count - 1
                If dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub UsuariosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Usuarios").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtUsuariosNombre.Focus()

        Else
            If String.IsNullOrWhiteSpace(txtUsuariosNombre.Text) OrElse
               txtUsuariosNombre.Text.Trim().Length > 50 Then
                MessageBox.Show("Ingrese un nombre válido de hasta 50 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosNombre.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsuariosClave.Text) OrElse
               txtUsuariosClave.Text.Trim().Length > 50 Then
                MessageBox.Show("Ingrese una clave válida de hasta 50 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosClave.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtUsuariosRol.Text) OrElse
               txtUsuariosRol.Text.Trim().Length > 30 Then
                MessageBox.Show("Ingrese un rol válido de hasta 30 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuariosRol.Focus()
                Exit Sub
            End If

            Dim coUsuarioEditar As New SqlCommand("Seguridad.spUsuariosEditarRegistro", cn)
            coUsuarioEditar.CommandType = CommandType.StoredProcedure

            coUsuarioEditar.Parameters.Add(New SqlParameter("@UsuariosCodigo", SqlDbType.NChar, 7,
                                            ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()
            coUsuarioEditar.Parameters.Add(New SqlParameter("@UsuariosNombre", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input)).Value = txtUsuariosNombre.Text.Trim()
            coUsuarioEditar.Parameters.Add(New SqlParameter("@UsuariosClave", SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input)).Value = txtUsuariosClave.Text.Trim()
            coUsuarioEditar.Parameters.Add(New SqlParameter("@UsuariosRol", SqlDbType.NVarChar, 30,
                                            ParameterDirection.Input)).Value = txtUsuariosRol.Text.Trim()
            coUsuarioEditar.Parameters.Add("@UsuariosUltimoAcceso",
                                           SqlDbType.DateTime).Value = dtpUsuariosUltimoAcceso.Value

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioEditar.ExecuteNonQuery()
                MessageBox.Show("Usuario modificado.", "Edición de usuario",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el usuario." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtUsuariosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0
            For i As Integer = 0 To dsDatos.Tables("Usuarios").Rows.Count - 1
                If dsDatos.Tables("Usuarios").Rows(i).Item("UsuariosCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i : Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub UsuariosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Usuarios").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar al usuario " & txtUsuariosNombre.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coUsuarioEliminar As New SqlCommand("Seguridad.spUsuariosEliminarRegistro", cn)
            coUsuarioEliminar.CommandType = CommandType.StoredProcedure
            coUsuarioEliminar.Parameters.Add(New SqlParameter("@UsuariosCodigo", SqlDbType.NChar, 7,
                                              ParameterDirection.Input)).Value = txtUsuariosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioEliminar.ExecuteNonQuery()
                MessageBox.Show("Usuario eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el usuario." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("Usuarios").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("Usuarios").Rows.Count > 0,
                    dsDatos.Tables("Usuarios").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub UsuariosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Usuarios").Rows.Count > 0,
                dsDatos.Tables("Usuarios").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("Usuarios").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub UsuariosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub UsuariosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vUsuarioRecuperado = 0
        Dim formulario As New frmUsuariosEliminados()
        formulario.ShowDialog()
        formulario.Dispose()

        If vUsuarioRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("Usuarios").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("Usuarios").Rows.Count > 0,
                    dsDatos.Tables("Usuarios").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
