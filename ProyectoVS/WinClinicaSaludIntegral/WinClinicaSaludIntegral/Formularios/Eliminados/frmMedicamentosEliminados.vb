Imports System.Data
Imports System.Data.SqlClient

Public Class frmMedicamentosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub MedicamentosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spMedicamentosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvMedicamentosEliminados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvMedicamentosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosCodigo").ToString().Trim())
            lvMedicamentosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("DistribuidorasCodigo").ToString().Trim())
            lvMedicamentosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosNombre").ToString().Trim())
            lvMedicamentosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosPresentacion").ToString().Trim())
            lvMedicamentosEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosStock")).ToString("0"))
            lvMedicamentosEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosPrecio")).ToString("0.00"))
            lvMedicamentosEliminados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosFechaVencimiento")).ToString("dd/MM/yyyy"))
            lvMedicamentosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosDescripcion").ToString().Trim())
            lvMedicamentosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("MedicamentosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub MedicamentoSeleccionado(sender As Object, e As EventArgs) Handles lvMedicamentosEliminados.SelectedIndexChanged
        If lvMedicamentosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub MedicamentoRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvMedicamentosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un medicamento para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar el medicamento seleccionado?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coMedicamentoRecuperar As New SqlCommand("Atenciones.spMedicamentosRecuperarRegistro", cn)
            coMedicamentoRecuperar.CommandType = CommandType.StoredProcedure

            coMedicamentoRecuperar.Parameters.Add(New SqlParameter("@MedicamentosCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value =
                                                   lvMedicamentosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coMedicamentoRecuperar.ExecuteNonQuery()
                MessageBox.Show("Medicamento recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vMedicamentoRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el medicamento." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coMedicamentoRecuperar.Dispose()
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
