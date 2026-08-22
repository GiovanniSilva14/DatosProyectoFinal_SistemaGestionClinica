Imports System.Data
Imports System.Data.SqlClient

Public Class frmConsultoriosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub ConsultoriosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spConsultoriosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvConsultoriosEliminados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvConsultoriosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosCodigo").ToString().Trim())
            lvConsultoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosNombre").ToString().Trim())
            lvConsultoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosNumero").ToString().Trim())
            lvConsultoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosUbicacion").ToString().Trim())
            lvConsultoriosEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosPiso")).ToString("0"))
            lvConsultoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosDescripcion").ToString().Trim())
            lvConsultoriosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub ConsultorioSeleccionado(sender As Object, e As EventArgs) Handles lvConsultoriosEliminados.SelectedIndexChanged
        If lvConsultoriosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub ConsultorioRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvConsultoriosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un consultorio para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar el consultorio seleccionado?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coConsultorioRecuperar As New SqlCommand("Atenciones.spConsultoriosRecuperarRegistro", cn)
            coConsultorioRecuperar.CommandType = CommandType.StoredProcedure

            coConsultorioRecuperar.Parameters.Add(New SqlParameter("@ConsultoriosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value =
                                                   lvConsultoriosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coConsultorioRecuperar.ExecuteNonQuery()
                MessageBox.Show("Consultorio recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vConsultorioRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el consultorio." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coConsultorioRecuperar.Dispose()
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
