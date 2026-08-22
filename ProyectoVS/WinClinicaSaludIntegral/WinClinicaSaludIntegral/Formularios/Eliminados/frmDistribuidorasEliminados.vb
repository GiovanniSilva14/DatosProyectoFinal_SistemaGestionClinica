Imports System.Data
Imports System.Data.SqlClient

Public Class frmDistribuidorasEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub DistribuidorasEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spDistribuidorasListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvDistribuidorasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvDistribuidorasEliminadas.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasCodigo").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasRUC").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasRazonSocial").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasTelefono").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasCorreo").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasDireccion").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasContacto").ToString().Trim())
            lvDistribuidorasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasEstado").ToString().Trim())
        Next
    End Sub

    Private Sub DistribuidoraSeleccionada(sender As Object, e As EventArgs) Handles lvDistribuidorasEliminadas.SelectedIndexChanged
        If lvDistribuidorasEliminadas.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub DistribuidoraRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvDistribuidorasEliminadas.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una distribuidora para recuperarla.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar la distribuidora seleccionada?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coDistribuidoraRecuperar As New SqlCommand("Atenciones.spDistribuidorasRecuperarRegistro", cn)
            coDistribuidoraRecuperar.CommandType = CommandType.StoredProcedure

            coDistribuidoraRecuperar.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value =
                                                    lvDistribuidorasEliminadas.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coDistribuidoraRecuperar.ExecuteNonQuery()
                MessageBox.Show("Distribuidora recuperada.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vDistribuidoraRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la distribuidora." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coDistribuidoraRecuperar.Dispose()
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
