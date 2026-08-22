Imports System.Data
Imports System.Data.SqlClient

Public Class frmBoletaDetalleEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub BoletaDetalleEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spBoletaDetalleListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvBoletaDetalleEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvBoletaDetalleEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetalleCodigo").ToString().Trim())
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaCodigo").ToString().Trim())
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetalleConcepto").ToString().Trim())
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetalleCantidad")).ToString("0"))
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetallePrecio")).ToString("0.00"))
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetalleImporte")).ToString("0.00"))
            lvBoletaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("BoletaDetalleEstado").ToString().Trim())
        Next
    End Sub

    Private Sub DetalleSeleccionado(sender As Object, e As EventArgs) Handles lvBoletaDetalleEliminados.SelectedIndexChanged
        If lvBoletaDetalleEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub DetalleRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvBoletaDetalleEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un detalle para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar el detalle seleccionado?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coBoletaDetalleRecuperar As New SqlCommand("Atenciones.spBoletaDetalleRecuperarRegistro", cn)
            coBoletaDetalleRecuperar.CommandType = CommandType.StoredProcedure
            coBoletaDetalleRecuperar.Parameters.Add(New SqlParameter("@BoletaDetalleCodigo", SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value =
                                                     lvBoletaDetalleEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coBoletaDetalleRecuperar.ExecuteNonQuery()
                MessageBox.Show("Detalle de boleta recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vBoletaDetalleRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coBoletaDetalleRecuperar.Dispose()
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
