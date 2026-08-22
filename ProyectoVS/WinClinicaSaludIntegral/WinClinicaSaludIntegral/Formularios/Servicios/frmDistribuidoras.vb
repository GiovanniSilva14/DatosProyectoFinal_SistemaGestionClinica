Imports System.Data
Imports System.Data.SqlClient

Public Class frmDistribuidoras

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daDistribuidoras As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub DistribuidorasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Distribuidoras").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Distribuidoras").Rows.Count > 0,
                dsDatos.Tables("Distribuidoras").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daDistribuidoras = New SqlDataAdapter("Atenciones.spDistribuidorasListaSinBorrados", cn)
        daDistribuidoras.SelectCommand.CommandType = CommandType.StoredProcedure
        daDistribuidoras.Fill(dsDatos, "Distribuidoras")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Distribuidoras").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Distribuidoras").Rows.Count Then
            vPosicion = 0
        End If

        txtDistribuidorasCodigo.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasCodigo").ToString().Trim()
        txtDistribuidorasRUC.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasRUC").ToString().Trim()
        txtDistribuidorasRazonSocial.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasRazonSocial").ToString().Trim()
        txtDistribuidorasTelefono.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasTelefono").ToString().Trim()
        txtDistribuidorasCorreo.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasCorreo").ToString().Trim()
        txtDistribuidorasDireccion.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasDireccion").ToString().Trim()
        txtDistribuidorasContacto.Text = dsDatos.Tables("Distribuidoras").Rows(vPosicion).Item("DistribuidorasContacto").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvDistribuidorasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Distribuidoras").Rows.Count - 1
            lvDistribuidorasRegistradas.Items.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasCodigo").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasRUC").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasRazonSocial").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasTelefono").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasCorreo").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasDireccion").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasContacto").ToString().Trim())
            lvDistribuidorasRegistradas.Items(i).SubItems.Add(dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pRUC As Boolean,
                          pRazonSocial As Boolean, pTelefono As Boolean,
                          pCorreo As Boolean, pDireccion As Boolean,
                          pContacto As Boolean, pLista As Boolean)
        txtDistribuidorasCodigo.Enabled = pCodigo
        txtDistribuidorasRUC.Enabled = pRUC
        txtDistribuidorasRazonSocial.Enabled = pRazonSocial
        txtDistribuidorasTelefono.Enabled = pTelefono
        txtDistribuidorasCorreo.Enabled = pCorreo
        txtDistribuidorasDireccion.Enabled = pDireccion
        txtDistribuidorasContacto.Enabled = pContacto
        lvDistribuidorasRegistradas.Enabled = pLista
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
        txtDistribuidorasCodigo.Clear()
        txtDistribuidorasRUC.Clear()
        txtDistribuidorasRazonSocial.Clear()
        txtDistribuidorasTelefono.Clear()
        txtDistribuidorasCorreo.Clear()
        txtDistribuidorasDireccion.Clear()
        txtDistribuidorasContacto.Clear()
    End Sub

    Private Sub DistribuidorasSeleccion(sender As Object, e As EventArgs) Handles lvDistribuidorasRegistradas.SelectedIndexChanged
        If lvDistribuidorasRegistradas.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Distribuidoras").Rows.Count - 1
            If lvDistribuidorasRegistradas.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub DistribuidorasAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtDistribuidorasCodigo.Focus()

        Else
            If txtDistribuidorasCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasCodigo.Focus()
                Exit Sub
            End If

            If txtDistribuidorasRUC.Text.Trim().Length <> 11 Then
                MessageBox.Show("El RUC debe tener 11 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasRUC.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtDistribuidorasRazonSocial.Text) Then
                MessageBox.Show("Falta la razón social.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasRazonSocial.Focus()
                Exit Sub
            End If

            If txtDistribuidorasRazonSocial.Text.Trim().Length > 150 Then
                MessageBox.Show("La razón social no puede superar 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasRazonSocial.Focus()
                Exit Sub
            End If

            If txtDistribuidorasTelefono.Text.Trim().Length > 0 AndAlso
               txtDistribuidorasTelefono.Text.Trim().Length <> 9 Then
                MessageBox.Show("El teléfono debe tener 9 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasTelefono.Focus()
                Exit Sub
            End If

            If txtDistribuidorasCorreo.Text.Trim().Length > 100 Then
                MessageBox.Show("El correo no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasCorreo.Focus()
                Exit Sub
            End If

            If txtDistribuidorasDireccion.Text.Trim().Length > 200 Then
                MessageBox.Show("La dirección no puede superar 200 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasDireccion.Focus()
                Exit Sub
            End If

            If txtDistribuidorasContacto.Text.Trim().Length > 100 Then
                MessageBox.Show("El contacto no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasContacto.Focus()
                Exit Sub
            End If

            Dim coDistribuidoraNueva As New SqlCommand("Atenciones.spDistribuidorasInsertarRegistro", cn)
            coDistribuidoraNueva.CommandType = CommandType.StoredProcedure

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                                 SqlDbType.NChar, 7,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasCodigo.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasRUC",
                                                 SqlDbType.NChar, 11,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasRUC.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasRazonSocial",
                                                 SqlDbType.NVarChar, 150,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasRazonSocial.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasTelefono",
                                                 SqlDbType.NChar, 9,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasTelefono.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasCorreo",
                                                 SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasCorreo.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasDireccion",
                                                 SqlDbType.NVarChar, 200,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasDireccion.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasContacto",
                                                 SqlDbType.NVarChar, 100,
                                                 ParameterDirection.Input)).Value = txtDistribuidorasContacto.Text.Trim()

            coDistribuidoraNueva.Parameters.Add(New SqlParameter("@DistribuidorasEstado",
                                                 SqlDbType.NChar, 1,
                                                 ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coDistribuidoraNueva.ExecuteNonQuery()
                MessageBox.Show("Distribuidora registrada.", "Inserción de distribuidora",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar la distribuidora." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coDistribuidoraNueva.Dispose()
            End Try

            Dim codigoRegistrado As String = txtDistribuidorasCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Distribuidoras").Rows.Count - 1
                If dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub DistribuidorasEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Distribuidoras").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtDistribuidorasRUC.Focus()

        Else
            If txtDistribuidorasRUC.Text.Trim().Length <> 11 Then
                MessageBox.Show("El RUC debe tener 11 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasRUC.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtDistribuidorasRazonSocial.Text) OrElse
               txtDistribuidorasRazonSocial.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese una razón social válida de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasRazonSocial.Focus()
                Exit Sub
            End If

            If txtDistribuidorasTelefono.Text.Trim().Length > 0 AndAlso
               txtDistribuidorasTelefono.Text.Trim().Length <> 9 Then
                MessageBox.Show("El teléfono debe tener 9 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasTelefono.Focus()
                Exit Sub
            End If

            If txtDistribuidorasCorreo.Text.Trim().Length > 100 Then
                MessageBox.Show("El correo no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasCorreo.Focus()
                Exit Sub
            End If

            If txtDistribuidorasDireccion.Text.Trim().Length > 200 Then
                MessageBox.Show("La dirección no puede superar 200 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasDireccion.Focus()
                Exit Sub
            End If

            If txtDistribuidorasContacto.Text.Trim().Length > 100 Then
                MessageBox.Show("El contacto no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasContacto.Focus()
                Exit Sub
            End If

            Dim coDistribuidoraEditar As New SqlCommand("Atenciones.spDistribuidorasEditarRegistro", cn)
            coDistribuidoraEditar.CommandType = CommandType.StoredProcedure

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasCodigo.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasRUC",
                                                  SqlDbType.NChar, 11,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasRUC.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasRazonSocial",
                                                  SqlDbType.NVarChar, 150,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasRazonSocial.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasTelefono",
                                                  SqlDbType.NChar, 9,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasTelefono.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasCorreo",
                                                  SqlDbType.NVarChar, 100,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasCorreo.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasDireccion",
                                                  SqlDbType.NVarChar, 200,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasDireccion.Text.Trim()

            coDistribuidoraEditar.Parameters.Add(New SqlParameter("@DistribuidorasContacto",
                                                  SqlDbType.NVarChar, 100,
                                                  ParameterDirection.Input)).Value = txtDistribuidorasContacto.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coDistribuidoraEditar.ExecuteNonQuery()
                MessageBox.Show("Distribuidora modificada.", "Edición de distribuidora",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la distribuidora." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coDistribuidoraEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtDistribuidorasCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Distribuidoras").Rows.Count - 1
                If dsDatos.Tables("Distribuidoras").Rows(i).Item("DistribuidorasCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub DistribuidorasEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("Distribuidoras").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la distribuidora " & vbCrLf &
                           txtDistribuidorasRazonSocial.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coDistribuidoraEliminar As New SqlCommand("Atenciones.spDistribuidorasEliminarRegistro", cn)
            coDistribuidoraEliminar.CommandType = CommandType.StoredProcedure

            coDistribuidoraEliminar.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                                   SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtDistribuidorasCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coDistribuidoraEliminar.ExecuteNonQuery()
                MessageBox.Show("Distribuidora eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la distribuidora." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coDistribuidoraEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Distribuidoras").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Distribuidoras").Rows.Count > 0,
                    dsDatos.Tables("Distribuidoras").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub DistribuidorasCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Distribuidoras").Rows.Count > 0,
                dsDatos.Tables("Distribuidoras").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Distribuidoras").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub DistribuidorasCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub DistribuidorasEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vDistribuidoraRecuperada = 0

        Dim fDistribuidorasEliminadas As New frmDistribuidorasEliminados()
        fDistribuidorasEliminadas.ShowDialog()
        fDistribuidorasEliminadas.Dispose()

        If vDistribuidoraRecuperada = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Distribuidoras").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Distribuidoras").Rows.Count > 0,
                    dsDatos.Tables("Distribuidoras").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
