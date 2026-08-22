Imports System.Data
Imports System.Data.SqlClient

Public Class frmUsuariosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub UsuariosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Seguridad.spUsuariosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvUsuariosEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvUsuariosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosCodigo").ToString().Trim())
            lvUsuariosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosNombre").ToString().Trim())
            lvUsuariosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosClave").ToString().Trim())
            lvUsuariosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosRol").ToString().Trim())
            If IsDBNull(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosUltimoAcceso")) Then
                lvUsuariosEliminados.Items(i).SubItems.Add("")
            Else
                lvUsuariosEliminados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosUltimoAcceso")).ToString("dd/MM/yyyy HH:mm:ss"))
            End If
            lvUsuariosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub UsuarioSeleccionado(sender As Object, e As EventArgs) Handles lvUsuariosEliminados.SelectedIndexChanged
        If lvUsuariosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub UsuarioRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvUsuariosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un usuario para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar al usuario seleccionado?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coUsuarioRecuperar As New SqlCommand("Seguridad.spUsuariosRecuperarRegistro", cn)
            coUsuarioRecuperar.CommandType = CommandType.StoredProcedure
            coUsuarioRecuperar.Parameters.Add(New SqlParameter("@UsuariosCodigo", SqlDbType.NChar, 7,
                                               ParameterDirection.Input)).Value =
                                               lvUsuariosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioRecuperar.ExecuteNonQuery()
                MessageBox.Show("Usuario recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vUsuarioRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el usuario." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioRecuperar.Dispose()
            End Try

            CrearDataSet()
            LlenarLista()
            cmdRecuperar.Enabled = False
        End If
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class
