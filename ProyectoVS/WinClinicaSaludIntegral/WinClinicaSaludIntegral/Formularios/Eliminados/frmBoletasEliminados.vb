Imports System.Data
Imports System.Data.SqlClient

Public Class frmBoletasEliminados

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daEliminados As SqlDataAdapter

    Private Sub BoletasEliminadasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataset()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataset()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spBoletaListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvBoletasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            Dim fila As DataRow = dsDatos.Tables("Eliminados").Rows(i)
            Dim item As New ListViewItem(fila("BoletaCodigo").ToString().Trim())

            item.SubItems.Add(fila("PacientesCodigo").ToString().Trim())
            item.SubItems.Add(fila("EmpleadosCodigo").ToString().Trim())
            item.SubItems.Add(CDate(fila("BoletaFecha")).ToString("dd/MM/yyyy"))
            item.SubItems.Add(CDec(fila("BoletaSubtotal")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("BoletaIGV")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("BoletaTotal")).ToString("0.00"))
            item.SubItems.Add(fila("BoletaEstado").ToString().Trim())

            lvBoletasEliminadas.Items.Add(item)
        Next
    End Sub

    Private Sub BoletaEliminadaSeleccionada(sender As Object, e As EventArgs) Handles lvBoletasEliminadas.SelectedIndexChanged
        cmdRecuperar.Enabled = lvBoletasEliminadas.SelectedItems.Count > 0
    End Sub

    Private Sub BoletaRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvBoletasEliminadas.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una boleta para recuperarla.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim codigoBoleta As String = lvBoletasEliminadas.SelectedItems(0).Text.Trim()

        If MessageBox.Show("¿Desea recuperar la boleta " & codigoBoleta & "?",
                           "Recuperación de registros",
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) <> DialogResult.OK Then
            Exit Sub
        End If

        Using coBoletaRecuperar As New SqlCommand("Atenciones.spBoletaRecuperarRegistro", cn)
            coBoletaRecuperar.CommandType = CommandType.StoredProcedure
            coBoletaRecuperar.Parameters.Add("@BoletaCodigo", SqlDbType.NChar, 7).Value = codigoBoleta

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coBoletaRecuperar.ExecuteNonQuery()

                MessageBox.Show("Boleta recuperada.",
                                "Recuperación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                vBoletaRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la boleta." & vbCrLf & ex.Message,
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

