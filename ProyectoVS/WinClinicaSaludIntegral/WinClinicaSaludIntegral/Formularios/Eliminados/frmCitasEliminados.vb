Imports System.Data
Imports System.Data.SqlClient

Public Class frmCitasEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub CitasEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset()
        LlenarLista()
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daEliminados = New SqlDataAdapter("Atenciones.spCitasListaBorrados", cn)
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvCitasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1

            lvCitasEliminadas.Items.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("CitasCodigo").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("PacientesCodigo").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("MedicosCodigo").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("ConsultoriosCodigo").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("CitasFecha").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("CitasHora").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("CitasMotivo").ToString)

            lvCitasEliminadas.Items(i).SubItems.Add(
                dsDatos.Tables("Eliminados").Rows(i).Item("CitasCondiciones").ToString)

        Next
    End Sub

    Private Sub CitasEliminadasSeleccion(sender As Object, e As EventArgs) Handles lvCitasEliminadas.SelectedIndexChanged

        If lvCitasEliminadas.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True

    End Sub

    Private Sub CitasRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If MessageBox.Show("¿Desea recuperar la cita?",
                           "Recuperación de registros",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coCitasRecuperar As New SqlCommand(
                "Atenciones.spCitasRecuperarRegistro", cn)

            coCitasRecuperar.CommandType = CommandType.StoredProcedure

            '@CitasCodigo nchar(7)
            coCitasRecuperar.Parameters.Add(
                New SqlParameter(
                    "@CitasCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    lvCitasEliminadas.SelectedItems(0).Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try
                cn.Open()
                coCitasRecuperar.ExecuteNonQuery()

                CrearDataset()
                LlenarLista()

                MessageBox.Show(
                    "Cita recuperada",
                    "Recuperación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)

                vCitaRecuperada = 1
                cmdRecuperar.Enabled = False

            Catch ex As Exception
                MessageBox.Show(
                    "No se pudo recuperar la cita",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                MessageBox.Show(ex.Message)

            Finally
                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                End If
            End Try

        End If

    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class