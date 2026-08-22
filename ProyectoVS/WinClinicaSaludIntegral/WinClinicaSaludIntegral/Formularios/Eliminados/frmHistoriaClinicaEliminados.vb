Imports System.Data
Imports System.Data.SqlClient

Public Class frmHistoriaClinicaEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub HistoriaClinicaEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset()
        LlenarLista()
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daEliminados = New SqlDataAdapter("Atenciones.spHistoriaClinicaListaBorrados", cn)
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvHistoriaClinicaEliminados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1

            lvHistoriaClinicaEliminados.Items.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaCodigo").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("PacientesCodigo").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaFechaApertura").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaGrupoSanguineo").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaAlergias").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaAntecedentes").ToString)

            lvHistoriaClinicaEliminados.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("HistoriaClinicaObservaciones").ToString)

        Next
    End Sub

    Private Sub HistoriaClinicaEliminadosSeleccion(sender As Object, e As EventArgs) Handles lvHistoriaClinicaEliminados.SelectedIndexChanged

        If lvHistoriaClinicaEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True

    End Sub

    Private Sub HistoriaClinicaRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If MessageBox.Show("¿Desea recuperar la Historia Clínica?",
                           "Recuperación de registros",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coHistoriaClinicaRecuperar As New SqlCommand(
                "Atenciones.spHistoriaClinicaRecuperarRegistro", cn)

            coHistoriaClinicaRecuperar.CommandType = CommandType.StoredProcedure

            '@HistoriaClinicaCodigo nchar(7)
            coHistoriaClinicaRecuperar.Parameters.Add(
                New SqlParameter(
                    "@HistoriaClinicaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    lvHistoriaClinicaEliminados.SelectedItems(0).Text

            cn.Open()
            coHistoriaClinicaRecuperar.ExecuteNonQuery()
            cn.Close()

            CrearDataset()
            LlenarLista()

            MessageBox.Show(
                "Historia Clínica recuperada",
                "Recuperación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation)

            vHistoriaClinicaRecuperada = 1
            cmdRecuperar.Enabled = False

        End If

    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class