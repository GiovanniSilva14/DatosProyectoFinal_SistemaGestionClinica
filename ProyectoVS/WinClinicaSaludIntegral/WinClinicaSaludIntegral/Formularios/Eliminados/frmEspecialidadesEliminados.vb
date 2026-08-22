Imports System.Data
Imports System.Data.SqlClient

Public Class frmEspecialidadesEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub EspecialidadesEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spEspecialidadesListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvEspecialidadesEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvEspecialidadesEliminadas.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EspecialidadesCodigo").ToString().Trim())
            lvEspecialidadesEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EspecialidadesNombre").ToString().Trim())
            lvEspecialidadesEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EspecialidadesDescripcion").ToString().Trim())
            lvEspecialidadesEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EspecialidadesEstado").ToString().Trim())
        Next
    End Sub

    Private Sub EspecialidadSeleccionada(sender As Object, e As EventArgs) Handles lvEspecialidadesEliminadas.SelectedIndexChanged
        If lvEspecialidadesEliminadas.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub EspecialidadRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvEspecialidadesEliminadas.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una especialidad para recuperarla.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar la especialidad seleccionada?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coEspecialidadRecuperar As New SqlCommand("Atenciones.spEspecialidadesRecuperarRegistro", cn)
            coEspecialidadRecuperar.CommandType = CommandType.StoredProcedure

            coEspecialidadRecuperar.Parameters.Add(New SqlParameter("@EspecialidadesCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value =
                                                    lvEspecialidadesEliminadas.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEspecialidadRecuperar.ExecuteNonQuery()
                MessageBox.Show("Especialidad recuperada.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vEspecialidadRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la especialidad." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEspecialidadRecuperar.Dispose()
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
