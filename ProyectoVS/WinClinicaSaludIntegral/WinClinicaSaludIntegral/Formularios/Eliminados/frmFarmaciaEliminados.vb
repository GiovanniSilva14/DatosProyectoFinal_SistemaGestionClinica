Imports System.Data
Imports System.Data.SqlClient

Public Class frmFarmaciaEliminados

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daEliminados As SqlDataAdapter

    Private Sub FarmaciaEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spFarmaciaListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvFarmaciaEliminada.Items.Clear()
        For Each fila As DataRow In dsDatos.Tables("Eliminados").Rows
            Dim item As New ListViewItem(fila("FarmaciaCodigo").ToString().Trim())
            item.SubItems.Add(fila("RecetaCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicamentosCodigo").ToString().Trim())
            item.SubItems.Add(CDec(fila("FarmaciaCantidad")).ToString("0"))
            item.SubItems.Add(fila("FarmaciaDosis").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaFrecuencia").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaDuracion").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaObservaciones").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaEstado").ToString().Trim())
            lvFarmaciaEliminada.Items.Add(item)
        Next
    End Sub

    Private Sub FarmaciaSeleccion(sender As Object, e As EventArgs) Handles lvFarmaciaEliminada.SelectedIndexChanged
        cmdRecuperar.Enabled = lvFarmaciaEliminada.SelectedItems.Count > 0
    End Sub

    Private Sub FarmaciaRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvFarmaciaEliminada.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un registro para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim codigo As String = lvFarmaciaEliminada.SelectedItems(0).Text.Trim()
        If MessageBox.Show("¿Desea recuperar el registro " & codigo & "?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK Then Exit Sub

        Using comando As New SqlCommand("Atenciones.spFarmaciaRecuperarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@FarmaciaCodigo", SqlDbType.NChar, 7).Value = codigo
            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                comando.ExecuteNonQuery()
                MessageBox.Show("Registro de farmacia recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vFarmaciaRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el registro." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class
