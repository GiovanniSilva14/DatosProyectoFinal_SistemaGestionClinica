Imports System.Data
Imports System.Data.SqlClient

Public Class frmMedicosEliminados

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daEliminados As SqlDataAdapter

    Private Sub MedicosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spMedicosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvMedicosEliminados.Items.Clear()
        For Each fila As DataRow In dsDatos.Tables("Eliminados").Rows
            Dim item As New ListViewItem(fila("MedicosCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicosNombres").ToString().Trim())
            item.SubItems.Add(fila("MedicosApellidos").ToString().Trim())
            item.SubItems.Add(fila("MedicosCMP").ToString().Trim())
            item.SubItems.Add(fila("MedicosTelefono").ToString().Trim())
            item.SubItems.Add(fila("MedicosCorreo").ToString().Trim())
            item.SubItems.Add(fila("EspecialidadesCodigo").ToString().Trim())
            item.SubItems.Add(fila("ConsultoriosCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicosEstado").ToString().Trim())
            lvMedicosEliminados.Items.Add(item)
        Next
    End Sub

    Private Sub MedicoSeleccionado(sender As Object, e As EventArgs) Handles lvMedicosEliminados.SelectedIndexChanged
        cmdRecuperar.Enabled = lvMedicosEliminados.SelectedItems.Count > 0
    End Sub

    Private Sub MedicoRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvMedicosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un médico para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim codigo As String = lvMedicosEliminados.SelectedItems(0).Text.Trim()
        If MessageBox.Show("¿Desea recuperar al médico seleccionado?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) <> DialogResult.OK Then Exit Sub
        Using comando As New SqlCommand("Atenciones.spMedicosRecuperarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@MedicosCodigo", SqlDbType.NChar, 7).Value = codigo
            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                comando.ExecuteNonQuery()
                MessageBox.Show("Médico recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vMedicoRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar al médico." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using
        CrearDataSet() : LlenarLista() : cmdRecuperar.Enabled = False
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class
