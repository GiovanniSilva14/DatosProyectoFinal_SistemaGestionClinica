Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetaCategorias

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daRecetaCategorias As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub RecetaCategoriasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("RecetaCategorias").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("RecetaCategorias").Rows.Count > 0,
                dsDatos.Tables("RecetaCategorias").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daRecetaCategorias = New SqlDataAdapter("Atenciones.spRecetaCategoriasListaSinBorrados", cn)
        daRecetaCategorias.SelectCommand.CommandType = CommandType.StoredProcedure
        daRecetaCategorias.Fill(dsDatos, "RecetaCategorias")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("RecetaCategorias").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("RecetaCategorias").Rows.Count Then
            vPosicion = 0
        End If

        txtRecetaCategoriasCodigo.Text = dsDatos.Tables("RecetaCategorias").Rows(vPosicion).Item("RecetaCategoriasCodigo").ToString().Trim()
        txtRecetaCategoriasNombre.Text = dsDatos.Tables("RecetaCategorias").Rows(vPosicion).Item("RecetaCategoriasNombre").ToString().Trim()
        txtRecetaCategoriasDescripcion.Text = dsDatos.Tables("RecetaCategorias").Rows(vPosicion).Item("RecetaCategoriasDescripcion").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvRecetaCategoriasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("RecetaCategorias").Rows.Count - 1
            lvRecetaCategoriasRegistradas.Items.Add(dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasCodigo").ToString().Trim())
            lvRecetaCategoriasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasNombre").ToString().Trim())
            lvRecetaCategoriasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasDescripcion").ToString().Trim())
            lvRecetaCategoriasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pNombre As Boolean,
                          pDescripcion As Boolean, pLista As Boolean)
        txtRecetaCategoriasCodigo.Enabled = pCodigo
        txtRecetaCategoriasNombre.Enabled = pNombre
        txtRecetaCategoriasDescripcion.Enabled = pDescripcion
        lvRecetaCategoriasRegistradas.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean, pEditar As Boolean,
                        pEliminar As Boolean, pCancelar As Boolean,
                        pCerrar As Boolean, pEliminados As Boolean)
        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub LimpiarControles()
        txtRecetaCategoriasCodigo.Clear()
        txtRecetaCategoriasNombre.Clear()
        txtRecetaCategoriasDescripcion.Clear()
    End Sub

    Private Sub RecetaCategoriasSeleccion(sender As Object, e As EventArgs) Handles lvRecetaCategoriasRegistradas.SelectedIndexChanged
        If lvRecetaCategoriasRegistradas.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("RecetaCategorias").Rows.Count - 1
            If lvRecetaCategoriasRegistradas.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub RecetaCategoriasAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtRecetaCategoriasCodigo.Focus()

        Else
            ' Consistencia del código
            If txtRecetaCategoriasCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasCodigo.Focus()
                Exit Sub
            End If

            ' Consistencia del nombre
            If String.IsNullOrWhiteSpace(txtRecetaCategoriasNombre.Text) Then
                MessageBox.Show("Falta el nombre de la categoría de receta.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasNombre.Focus()
                Exit Sub
            End If

            If txtRecetaCategoriasNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("El nombre no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasNombre.Focus()
                Exit Sub
            End If

            ' Consistencia de la descripción
            If txtRecetaCategoriasDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasDescripcion.Focus()
                Exit Sub
            End If

            ' Consumir procedimiento almacenado para insertar
            Dim coRecetaCategoriaNueva As New SqlCommand("Atenciones.spRecetaCategoriasInsertarRegistro", cn)
            coRecetaCategoriaNueva.CommandType = CommandType.StoredProcedure

            coRecetaCategoriaNueva.Parameters.Add(New SqlParameter("@RecetaCategoriasCodigo",
                                                SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value = txtRecetaCategoriasCodigo.Text.Trim()

            coRecetaCategoriaNueva.Parameters.Add(New SqlParameter("@RecetaCategoriasNombre",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtRecetaCategoriasNombre.Text.Trim()

            coRecetaCategoriaNueva.Parameters.Add(New SqlParameter("@RecetaCategoriasDescripcion",
                                                SqlDbType.NVarChar, 250,
                                                ParameterDirection.Input)).Value = txtRecetaCategoriasDescripcion.Text.Trim()

            coRecetaCategoriaNueva.Parameters.Add(New SqlParameter("@RecetaCategoriasEstado",
                                                SqlDbType.NChar, 1,
                                                ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaCategoriaNueva.ExecuteNonQuery()
                MessageBox.Show("RecetaCategoria registrada.", "Inserción de categoría de receta",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar la categoría de receta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaCategoriaNueva.Dispose()
            End Try

            Dim codigoRegistrado As String = txtRecetaCategoriasCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("RecetaCategorias").Rows.Count - 1
                If dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub RecetaCategoriasEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("RecetaCategorias").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, False)
            Botones(False, True, False, True, False, False)
            txtRecetaCategoriasNombre.Focus()

        Else
            ' Consistencia del nombre
            If String.IsNullOrWhiteSpace(txtRecetaCategoriasNombre.Text) Then
                MessageBox.Show("Falta el nombre de la categoría de receta.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasNombre.Focus()
                Exit Sub
            End If

            If txtRecetaCategoriasNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("El nombre no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasNombre.Focus()
                Exit Sub
            End If

            ' Consistencia de la descripción
            If txtRecetaCategoriasDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCategoriasDescripcion.Focus()
                Exit Sub
            End If

            ' Consumir procedimiento almacenado para editar
            Dim coRecetaCategoriaEditar As New SqlCommand("Atenciones.spRecetaCategoriasEditarRegistro", cn)
            coRecetaCategoriaEditar.CommandType = CommandType.StoredProcedure

            coRecetaCategoriaEditar.Parameters.Add(New SqlParameter("@RecetaCategoriasCodigo",
                                                 SqlDbType.NChar, 7,
                                                 ParameterDirection.Input)).Value = txtRecetaCategoriasCodigo.Text.Trim()

            coRecetaCategoriaEditar.Parameters.Add(New SqlParameter("@RecetaCategoriasNombre",
                                                 SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input)).Value = txtRecetaCategoriasNombre.Text.Trim()

            coRecetaCategoriaEditar.Parameters.Add(New SqlParameter("@RecetaCategoriasDescripcion",
                                                 SqlDbType.NVarChar, 250,
                                                 ParameterDirection.Input)).Value = txtRecetaCategoriasDescripcion.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaCategoriaEditar.ExecuteNonQuery()
                MessageBox.Show("RecetaCategoria modificada.", "Edición de categoría de receta",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la categoría de receta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaCategoriaEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtRecetaCategoriasCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("RecetaCategorias").Rows.Count - 1
                If dsDatos.Tables("RecetaCategorias").Rows(i).Item("RecetaCategoriasCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub RecetaCategoriasEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("RecetaCategorias").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la categoría de receta " & vbCrLf &
                           txtRecetaCategoriasNombre.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetaCategoriaEliminar As New SqlCommand("Atenciones.spRecetaCategoriasEliminarRegistro", cn)
            coRecetaCategoriaEliminar.CommandType = CommandType.StoredProcedure

            coRecetaCategoriaEliminar.Parameters.Add(New SqlParameter("@RecetaCategoriasCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtRecetaCategoriasCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaCategoriaEliminar.ExecuteNonQuery()
                MessageBox.Show("RecetaCategoria eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la categoría de receta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaCategoriaEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("RecetaCategorias").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("RecetaCategorias").Rows.Count > 0,
                    dsDatos.Tables("RecetaCategorias").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub RecetaCategoriasCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("RecetaCategorias").Rows.Count > 0,
                dsDatos.Tables("RecetaCategorias").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("RecetaCategorias").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub RecetaCategoriasCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub RecetaCategoriasEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vRecetaCategoriaRecuperada = 0

        Dim fRecetaCategoriasEliminadas As New frmRecetaCategoriasEliminados()
        fRecetaCategoriasEliminadas.ShowDialog()
        fRecetaCategoriasEliminadas.Dispose()

        If vRecetaCategoriaRecuperada = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("RecetaCategorias").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("RecetaCategorias").Rows.Count > 0,
                    dsDatos.Tables("RecetaCategorias").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
