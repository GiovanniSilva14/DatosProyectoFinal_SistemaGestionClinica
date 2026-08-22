Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetaCategoriasEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub RecetaCategoriasEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spRecetaCategoriasListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvRecetaCategoriasEliminadas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvRecetaCategoriasEliminadas.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaCategoriasCodigo").ToString().Trim())
            lvRecetaCategoriasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaCategoriasNombre").ToString().Trim())
            lvRecetaCategoriasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaCategoriasDescripcion").ToString().Trim())
            lvRecetaCategoriasEliminadas.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("RecetaCategoriasEstado").ToString().Trim())
        Next
    End Sub

    Private Sub RecetaCategoriaSeleccionada(sender As Object, e As EventArgs) Handles lvRecetaCategoriasEliminadas.SelectedIndexChanged
        If lvRecetaCategoriasEliminadas.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If

        cmdRecuperar.Enabled = True
    End Sub

    Private Sub RecetaCategoriaRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click

        If lvRecetaCategoriasEliminadas.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione una categoría de receta para recuperarla.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar la categoría de receta seleccionada?",
                           "Recuperación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetaCategoriaRecuperar As New SqlCommand("Atenciones.spRecetaCategoriasRecuperarRegistro", cn)
            coRecetaCategoriaRecuperar.CommandType = CommandType.StoredProcedure

            coRecetaCategoriaRecuperar.Parameters.Add(New SqlParameter("@RecetaCategoriasCodigo",
                                                    SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value =
                                                    lvRecetaCategoriasEliminadas.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaCategoriaRecuperar.ExecuteNonQuery()
                MessageBox.Show("RecetaCategoria recuperada.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vRecetaCategoriaRecuperada = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar la categoría de receta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaCategoriaRecuperar.Dispose()
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
