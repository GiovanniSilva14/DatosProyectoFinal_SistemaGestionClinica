Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturasEliminados

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daEliminados As SqlDataAdapter

    Private Sub FacturasEliminadasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spFacturaListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvFacturasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            Dim fila As DataRow = dsDatos.Tables("Eliminados").Rows(i)
            Dim item As New ListViewItem(fila("FacturaCodigo").ToString().Trim())

            item.SubItems.Add(fila("PacientesCodigo").ToString().Trim())
            item.SubItems.Add(fila("EmpleadosCodigo").ToString().Trim())
            item.SubItems.Add(CDate(fila("FacturaFecha")).ToString("dd/MM/yyyy"))
            item.SubItems.Add(CDec(fila("FacturaSubtotal")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("FacturaIGV")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("FacturaTotal")).ToString("0.00"))
            item.SubItems.Add(fila("FacturaEstado").ToString().Trim())

            lvFacturasEliminadas.Items.Add(item)
        Next
    End Sub

    Private Sub FacturaEliminadaSeleccionada(sender As Object, e As EventArgs) Handles lvFacturasEliminadas.SelectedIndexChanged
        cmdRecuperar.Enabled = lvFacturasEliminadas.SelectedItems.Count > 0
    End Sub

    Private Sub FacturaRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvFacturasEliminadas.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una factura para recuperarla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim codigoFactura As String = lvFacturasEliminadas.SelectedItems(0).Text.Trim()

        If MessageBox.Show("¿Desea recuperar la factura " & codigoFactura & "?",
                           "Recuperación de registros",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) <> DialogResult.OK Then
            Exit Sub
        End If

        Using coFacturaRecuperar As New SqlCommand("Atenciones.spFacturaRecuperarRegistro", cn)
            coFacturaRecuperar.CommandType = CommandType.StoredProcedure
            coFacturaRecuperar.Parameters.Add("@FacturaCodigo", SqlDbType.NChar, 7).Value = codigoFactura

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coFacturaRecuperar.ExecuteNonQuery()

                MessageBox.Show("Factura recuperada.",
                                "Recuperación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                vFacturaRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la factura." & vbCrLf & ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        CrearDataset()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class
