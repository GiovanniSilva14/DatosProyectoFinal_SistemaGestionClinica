Imports System.Data
Imports System.Data.SqlClient

Public Class frmPacientesElminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daELiminados As SqlDataAdapter

    Private Sub PacientesElminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset
        LlenarLista
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daELiminados = New SqlDataAdapter("Atenciones.spPacientesListaBorrados", cn)
        daELiminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvPacientesEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvPacientesEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("PacientesCodigo").ToString)
            lvPacientesEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("PacientesDNI").ToString)
            lvPacientesEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("PacientesNombres").ToString)
            lvPacientesEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("PacientesApellidos").ToString)
            lvPacientesEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("PacientesSexo").ToString)
        Next
    End Sub

    Private Sub lvPacientesRegistradosSeleccion(sender As Object, e As EventArgs) Handles lvPacientesEliminados.SelectedIndexChanged
        If lvPacientesEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub PacientesRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If MessageBox.Show("¿Desea recuperar el paciente?",
                      "Recuperación de registros", MessageBoxButtons.OKCancel,
                      MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) =
                      DialogResult.OK Then

            Dim coPacientesRecuperar As New SqlCommand("Atenciones.spPacientesRecuperarRegistro", cn)
            coPacientesRecuperar.CommandType = CommandType.StoredProcedure

            '@PacientesCodigo nchar(7),
            coPacientesRecuperar.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = lvPacientesEliminados.SelectedItems(0).Text

            cn.Open()
            coPacientesRecuperar.ExecuteNonQuery()
            cn.Close()

            CrearDataset()
            LlenarLista()
            MessageBox.Show("Paciente recuperado", "Recuperación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            vPacienteRecuperado = 1
            cmdRecuperar.Enabled = False

        End If
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub
End Class