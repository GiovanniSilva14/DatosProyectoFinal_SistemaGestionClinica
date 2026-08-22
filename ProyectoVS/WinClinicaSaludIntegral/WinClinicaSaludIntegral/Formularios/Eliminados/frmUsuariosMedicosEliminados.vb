Imports System.Data
Imports System.Data.SqlClient

Public Class frmUsuariosMedicosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub UsuariosMedicosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Seguridad.spUsuariosMedicosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvUsuariosMedicosEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvUsuariosMedicosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosMedicosCodigo").ToString().Trim())
            lvUsuariosMedicosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosCodigo").ToString().Trim())
            lvUsuariosMedicosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicosCodigo").ToString().Trim())
            lvUsuariosMedicosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("UsuariosMedicosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub RelacionSeleccionada(sender As Object, e As EventArgs) Handles lvUsuariosMedicosEliminados.SelectedIndexChanged
        If lvUsuariosMedicosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub RelacionRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvUsuariosMedicosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una relación para recuperarla.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar la relación seleccionada?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coUsuarioMedicoRecuperar As New SqlCommand("Seguridad.spUsuariosMedicosRecuperarRegistro", cn)
            coUsuarioMedicoRecuperar.CommandType = CommandType.StoredProcedure
            coUsuarioMedicoRecuperar.Parameters.Add(New SqlParameter("@UsuariosMedicosCodigo",
                                                      SqlDbType.NChar, 7,
                                                      ParameterDirection.Input)).Value =
                                                      lvUsuariosMedicosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coUsuarioMedicoRecuperar.ExecuteNonQuery()
                MessageBox.Show("Relación recuperada.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vUsuarioMedicoRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la relación." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coUsuarioMedicoRecuperar.Dispose()
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
