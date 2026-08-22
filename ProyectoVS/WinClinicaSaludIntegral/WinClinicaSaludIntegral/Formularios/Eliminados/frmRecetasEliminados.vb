Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetasEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub RecetasEliminadasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset()
        LlenarLista()
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet

        daEliminados = New SqlDataAdapter(
            "Atenciones.spRecetaListaBorrados", cn)

        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()

        lvRecetasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1

            lvRecetasEliminadas.Items.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaCodigo").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("HistoriaClinicaCodigo").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("MedicosCodigo").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaCategoriasCodigo").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaFecha").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaDiagnostico").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaIndicaciones").ToString)

            lvRecetasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).
                Item("RecetaObservaciones").ToString)

        Next

    End Sub

    Private Sub RecetasEliminadasSeleccion(
        sender As Object,
        e As EventArgs) Handles lvRecetasEliminadas.SelectedIndexChanged

        If lvRecetasEliminadas.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True

    End Sub

    Private Sub RecetasRecuperar(
        sender As Object,
        e As EventArgs) Handles cmdRecuperar.Click

        If MessageBox.Show(
            "¿Desea recuperar la receta?",
            "Recuperación de registros",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Error,
            MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetasRecuperar As New SqlCommand(
                "Atenciones.spRecetaRecuperarRegistro", cn)

            coRecetasRecuperar.CommandType =
                CommandType.StoredProcedure

            '@RecetaCodigo nchar(7)
            coRecetasRecuperar.Parameters.Add(
                New SqlParameter(
                    "@RecetaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    lvRecetasEliminadas.SelectedItems(0).Text

            cn.Open()
            coRecetasRecuperar.ExecuteNonQuery()
            cn.Close()

            CrearDataset()
            LlenarLista()

            MessageBox.Show(
                "Receta recuperada",
                "Recuperación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation)

            vRecetaRecuperada = 1
            cmdRecuperar.Enabled = False

        End If

    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class