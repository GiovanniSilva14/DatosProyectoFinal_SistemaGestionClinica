Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetaLaboratoriosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub RecetaLaboratoriosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spRecetaLaboratoriosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvRecetaLaboratoriosEliminados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvRecetaLaboratoriosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosCodigo").ToString().Trim())
            lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaCodigo").ToString().Trim())
            lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosExamen").ToString().Trim())
            lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosResultado").ToString().Trim())

            If IsDBNull(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosFecha")) Then
                lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add("")
            Else
                lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosFecha")).ToString("dd/MM/yyyy"))
            End If

            lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosObservaciones").ToString().Trim())
            lvRecetaLaboratoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaLaboratoriosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub LaboratorioSeleccionado(sender As Object, e As EventArgs) Handles lvRecetaLaboratoriosEliminados.SelectedIndexChanged
        If lvRecetaLaboratoriosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub LaboratorioRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvRecetaLaboratoriosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un examen para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar el examen seleccionado?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetaLaboratorioRecuperar As New SqlCommand("Atenciones.spRecetaLaboratoriosRecuperarRegistro", cn)
            coRecetaLaboratorioRecuperar.CommandType = CommandType.StoredProcedure

            coRecetaLaboratorioRecuperar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosCodigo",
                                                        SqlDbType.NChar, 7,
                                                        ParameterDirection.Input)).Value =
                                                        lvRecetaLaboratoriosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaLaboratorioRecuperar.ExecuteNonQuery()
                MessageBox.Show("Examen de laboratorio recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vRecetaLaboratorioRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el registro." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaLaboratorioRecuperar.Dispose()
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
