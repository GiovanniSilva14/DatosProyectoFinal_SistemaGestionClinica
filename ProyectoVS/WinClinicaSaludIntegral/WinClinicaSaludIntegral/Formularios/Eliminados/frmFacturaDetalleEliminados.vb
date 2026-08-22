Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturaDetalleEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub FacturaDetalleEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spFacturaDetalleListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvFacturaDetalleEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvFacturaDetalleEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetalleCodigo").ToString().Trim())
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaCodigo").ToString().Trim())
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetalleConcepto").ToString().Trim())
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetalleCantidad")).ToString("0"))
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetallePrecio")).ToString("0.00"))
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetalleImporte")).ToString("0.00"))
            lvFacturaDetalleEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("FacturaDetalleEstado").ToString().Trim())
        Next
    End Sub

    Private Sub DetalleSeleccionado(sender As Object, e As EventArgs) Handles lvFacturaDetalleEliminados.SelectedIndexChanged
        If lvFacturaDetalleEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub DetalleRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvFacturaDetalleEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un detalle para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar el detalle seleccionado?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coFacturaDetalleRecuperar As New SqlCommand("Atenciones.spFacturaDetalleRecuperarRegistro", cn)
            coFacturaDetalleRecuperar.CommandType = CommandType.StoredProcedure
            coFacturaDetalleRecuperar.Parameters.Add(New SqlParameter("@FacturaDetalleCodigo", SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value =
                                                     lvFacturaDetalleEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coFacturaDetalleRecuperar.ExecuteNonQuery()
                MessageBox.Show("Detalle de factura recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vFacturaDetalleRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coFacturaDetalleRecuperar.Dispose()
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
