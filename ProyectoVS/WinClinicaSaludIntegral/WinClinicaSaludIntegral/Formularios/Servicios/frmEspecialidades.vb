Imports System.Data
Imports System.Data.SqlClient

Public Class frmEspecialidades

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEspecialidades As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub EspecialidadesCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Especialidades").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("Especialidades").Rows.Count > 0,
                dsDatos.Tables("Especialidades").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEspecialidades = New SqlDataAdapter("Atenciones.spEspecialidadesListaSinBorrados", cn)
        daEspecialidades.SelectCommand.CommandType = CommandType.StoredProcedure
        daEspecialidades.Fill(dsDatos, "Especialidades")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Especialidades").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Especialidades").Rows.Count Then
            vPosicion = 0
        End If

        txtEspecialidadesCodigo.Text = dsDatos.Tables("Especialidades").Rows(vPosicion).Item("EspecialidadesCodigo").ToString().Trim()
        txtEspecialidadesNombre.Text = dsDatos.Tables("Especialidades").Rows(vPosicion).Item("EspecialidadesNombre").ToString().Trim()
        txtEspecialidadesDescripcion.Text = dsDatos.Tables("Especialidades").Rows(vPosicion).Item("EspecialidadesDescripcion").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvEspecialidadesRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Especialidades").Rows.Count - 1
            lvEspecialidadesRegistradas.Items.Add(dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesCodigo").ToString().Trim())
            lvEspecialidadesRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesNombre").ToString().Trim())
            lvEspecialidadesRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesDescripcion").ToString().Trim())
            lvEspecialidadesRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pNombre As Boolean,
                          pDescripcion As Boolean, pLista As Boolean)
        txtEspecialidadesCodigo.Enabled = pCodigo
        txtEspecialidadesNombre.Enabled = pNombre
        txtEspecialidadesDescripcion.Enabled = pDescripcion
        lvEspecialidadesRegistradas.Enabled = pLista
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
        txtEspecialidadesCodigo.Clear()
        txtEspecialidadesNombre.Clear()
        txtEspecialidadesDescripcion.Clear()
    End Sub

    Private Sub EspecialidadesSeleccion(sender As Object, e As EventArgs) Handles lvEspecialidadesRegistradas.SelectedIndexChanged
        If lvEspecialidadesRegistradas.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Especialidades").Rows.Count - 1
            If lvEspecialidadesRegistradas.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub EspecialidadesAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtEspecialidadesCodigo.Focus()

        Else
            ' Consistencia del código
            If txtEspecialidadesCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesCodigo.Focus()
                Exit Sub
            End If

            ' Consistencia del nombre
            If String.IsNullOrWhiteSpace(txtEspecialidadesNombre.Text) Then
                MessageBox.Show("Falta el nombre de la especialidad.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesNombre.Focus()
                Exit Sub
            End If

            If txtEspecialidadesNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("El nombre no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesNombre.Focus()
                Exit Sub
            End If

            ' Consistencia de la descripción
            If txtEspecialidadesDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesDescripcion.Focus()
                Exit Sub
            End If

            ' Consumir procedimiento almacenado para insertar
            Dim coEspecialidadNueva As New SqlCommand("Atenciones.spEspecialidadesInsertarRegistro", cn)
            coEspecialidadNueva.CommandType = CommandType.StoredProcedure

            coEspecialidadNueva.Parameters.Add(New SqlParameter("@EspecialidadesCodigo",
                                                SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value = txtEspecialidadesCodigo.Text.Trim()

            coEspecialidadNueva.Parameters.Add(New SqlParameter("@EspecialidadesNombre",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtEspecialidadesNombre.Text.Trim()

            coEspecialidadNueva.Parameters.Add(New SqlParameter("@EspecialidadesDescripcion",
                                                SqlDbType.NVarChar, 250,
                                                ParameterDirection.Input)).Value = txtEspecialidadesDescripcion.Text.Trim()

            coEspecialidadNueva.Parameters.Add(New SqlParameter("@EspecialidadesEstado",
                                                SqlDbType.NChar, 1,
                                                ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEspecialidadNueva.ExecuteNonQuery()
                MessageBox.Show("Especialidad registrada.", "Inserción de especialidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar la especialidad." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEspecialidadNueva.Dispose()
            End Try

            Dim codigoRegistrado As String = txtEspecialidadesCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Especialidades").Rows.Count - 1
                If dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesCodigo").ToString().Trim() = codigoRegistrado Then
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

    Private Sub EspecialidadesEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Especialidades").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, False)
            Botones(False, True, False, True, False, False)
            txtEspecialidadesNombre.Focus()

        Else
            ' Consistencia del nombre
            If String.IsNullOrWhiteSpace(txtEspecialidadesNombre.Text) Then
                MessageBox.Show("Falta el nombre de la especialidad.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesNombre.Focus()
                Exit Sub
            End If

            If txtEspecialidadesNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("El nombre no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesNombre.Focus()
                Exit Sub
            End If

            ' Consistencia de la descripción
            If txtEspecialidadesDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEspecialidadesDescripcion.Focus()
                Exit Sub
            End If

            ' Consumir procedimiento almacenado para editar
            Dim coEspecialidadEditar As New SqlCommand("Atenciones.spEspecialidadesEditarRegistro", cn)
            coEspecialidadEditar.CommandType = CommandType.StoredProcedure

            coEspecialidadEditar.Parameters.Add(New SqlParameter("@EspecialidadesCodigo",
                                                 SqlDbType.NChar, 7,
                                                 ParameterDirection.Input)).Value = txtEspecialidadesCodigo.Text.Trim()

            coEspecialidadEditar.Parameters.Add(New SqlParameter("@EspecialidadesNombre",
                                                 SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input)).Value = txtEspecialidadesNombre.Text.Trim()

            coEspecialidadEditar.Parameters.Add(New SqlParameter("@EspecialidadesDescripcion",
                                                 SqlDbType.NVarChar, 250,
                                                 ParameterDirection.Input)).Value = txtEspecialidadesDescripcion.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEspecialidadEditar.ExecuteNonQuery()
                MessageBox.Show("Especialidad modificada.", "Edición de especialidad",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la especialidad." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEspecialidadEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtEspecialidadesCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Especialidades").Rows.Count - 1
                If dsDatos.Tables("Especialidades").Rows(i).Item("EspecialidadesCodigo").ToString().Trim() = codigoEditado Then
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

    Private Sub EspecialidadesEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("Especialidades").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la especialidad " & vbCrLf &
                           txtEspecialidadesNombre.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coEspecialidadEliminar As New SqlCommand("Atenciones.spEspecialidadesEliminarRegistro", cn)
            coEspecialidadEliminar.CommandType = CommandType.StoredProcedure

            coEspecialidadEliminar.Parameters.Add(New SqlParameter("@EspecialidadesCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtEspecialidadesCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEspecialidadEliminar.ExecuteNonQuery()
                MessageBox.Show("Especialidad eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la especialidad." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEspecialidadEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Especialidades").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Especialidades").Rows.Count > 0,
                    dsDatos.Tables("Especialidades").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub EspecialidadesCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, True)
        Botones(True, dsDatos.Tables("Especialidades").Rows.Count > 0,
                dsDatos.Tables("Especialidades").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Especialidades").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub EspecialidadesCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub EspecialidadesEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vEspecialidadRecuperada = 0

        Dim fEspecialidadesEliminadas As New frmEspecialidadesEliminados()
        fEspecialidadesEliminadas.ShowDialog()
        fEspecialidadesEliminadas.Dispose()

        If vEspecialidadRecuperada = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Especialidades").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Especialidades").Rows.Count > 0,
                    dsDatos.Tables("Especialidades").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
