Imports System.Data
Imports System.Data.SqlClient

Public Class frmConsultorios

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daConsultorios As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub ConsultoriosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Consultorios").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Consultorios").Rows.Count > 0,
                dsDatos.Tables("Consultorios").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daConsultorios = New SqlDataAdapter("Atenciones.spConsultoriosListaSinBorrados", cn)
        daConsultorios.SelectCommand.CommandType = CommandType.StoredProcedure
        daConsultorios.Fill(dsDatos, "Consultorios")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Consultorios").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Consultorios").Rows.Count Then
            vPosicion = 0
        End If

        txtConsultoriosCodigo.Text = dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosCodigo").ToString().Trim()
        txtConsultoriosNombre.Text = dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosNombre").ToString().Trim()
        txtConsultoriosNumero.Text = dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosNumero").ToString().Trim()
        txtConsultoriosUbicacion.Text = dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosUbicacion").ToString().Trim()
        txtConsultoriosPiso.Text = CDec(dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosPiso")).ToString("0")
        txtConsultoriosDescripcion.Text = dsDatos.Tables("Consultorios").Rows(vPosicion).Item("ConsultoriosDescripcion").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvConsultoriosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Consultorios").Rows.Count - 1
            lvConsultoriosRegistrados.Items.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosCodigo").ToString().Trim())
            lvConsultoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosNombre").ToString().Trim())
            lvConsultoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosNumero").ToString().Trim())
            lvConsultoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosUbicacion").ToString().Trim())
            lvConsultoriosRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosPiso")).ToString("0"))
            lvConsultoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosDescripcion").ToString().Trim())
            lvConsultoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pNombre As Boolean,
                          pNumero As Boolean, pUbicacion As Boolean,
                          pPiso As Boolean, pDescripcion As Boolean,
                          pLista As Boolean)
        txtConsultoriosCodigo.Enabled = pCodigo
        txtConsultoriosNombre.Enabled = pNombre
        txtConsultoriosNumero.Enabled = pNumero
        txtConsultoriosUbicacion.Enabled = pUbicacion
        txtConsultoriosPiso.Enabled = pPiso
        txtConsultoriosDescripcion.Enabled = pDescripcion
        lvConsultoriosRegistrados.Enabled = pLista
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
        txtConsultoriosCodigo.Clear()
        txtConsultoriosNombre.Clear()
        txtConsultoriosNumero.Clear()
        txtConsultoriosUbicacion.Clear()
        txtConsultoriosPiso.Clear()
        txtConsultoriosDescripcion.Clear()
    End Sub

    Private Sub ConsultoriosSeleccion(sender As Object, e As EventArgs) Handles lvConsultoriosRegistrados.SelectedIndexChanged
        If lvConsultoriosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Consultorios").Rows.Count - 1
            If lvConsultoriosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub ConsultoriosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtConsultoriosCodigo.Focus()

        Else
            Dim piso As Decimal

            If txtConsultoriosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtConsultoriosNombre.Text) Then
                MessageBox.Show("Falta el nombre del consultorio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosNombre.Focus()
                Exit Sub
            End If

            If txtConsultoriosNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("El nombre no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosNombre.Focus()
                Exit Sub
            End If

            If txtConsultoriosNumero.Text.Trim().Length <> 5 Then
                MessageBox.Show("El número del consultorio debe tener 5 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosNumero.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtConsultoriosUbicacion.Text) Then
                MessageBox.Show("Falta la ubicación del consultorio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosUbicacion.Focus()
                Exit Sub
            End If

            If txtConsultoriosUbicacion.Text.Trim().Length > 100 Then
                MessageBox.Show("La ubicación no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosUbicacion.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtConsultoriosPiso.Text.Trim(), piso) OrElse
               piso <= 0D OrElse piso <> Decimal.Truncate(piso) OrElse piso > 99D Then
                MessageBox.Show("El piso debe ser un número entero entre 1 y 99.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosPiso.Focus()
                Exit Sub
            End If

            If txtConsultoriosDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosDescripcion.Focus()
                Exit Sub
            End If

            Dim coConsultorioNuevo As New SqlCommand("Atenciones.spConsultoriosInsertarRegistro", cn)
            coConsultorioNuevo.CommandType = CommandType.StoredProcedure

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosCodigo",
                                               SqlDbType.NChar, 7,
                                               ParameterDirection.Input)).Value = txtConsultoriosCodigo.Text.Trim()

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosNombre",
                                               SqlDbType.NVarChar, 100,
                                               ParameterDirection.Input)).Value = txtConsultoriosNombre.Text.Trim()

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosNumero",
                                               SqlDbType.NChar, 5,
                                               ParameterDirection.Input)).Value = txtConsultoriosNumero.Text.Trim()

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosUbicacion",
                                               SqlDbType.NVarChar, 100,
                                               ParameterDirection.Input)).Value = txtConsultoriosUbicacion.Text.Trim()

            Dim parametroPiso As SqlParameter = coConsultorioNuevo.Parameters.Add("@ConsultoriosPiso", SqlDbType.Decimal)
            parametroPiso.Precision = 2
            parametroPiso.Scale = 0
            parametroPiso.Value = piso

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosDescripcion",
                                               SqlDbType.NVarChar, 250,
                                               ParameterDirection.Input)).Value = txtConsultoriosDescripcion.Text.Trim()

            coConsultorioNuevo.Parameters.Add(New SqlParameter("@ConsultoriosEstado",
                                               SqlDbType.NChar, 1,
                                               ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coConsultorioNuevo.ExecuteNonQuery()
                MessageBox.Show("Consultorio registrado.", "Inserción de consultorio",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el consultorio." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coConsultorioNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtConsultoriosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Consultorios").Rows.Count - 1
                If dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub ConsultoriosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Consultorios").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtConsultoriosNombre.Focus()

        Else
            Dim piso As Decimal

            If String.IsNullOrWhiteSpace(txtConsultoriosNombre.Text) OrElse
               txtConsultoriosNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese un nombre válido de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosNombre.Focus()
                Exit Sub
            End If

            If txtConsultoriosNumero.Text.Trim().Length <> 5 Then
                MessageBox.Show("El número del consultorio debe tener 5 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosNumero.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtConsultoriosUbicacion.Text) OrElse
               txtConsultoriosUbicacion.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese una ubicación válida de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosUbicacion.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtConsultoriosPiso.Text.Trim(), piso) OrElse
               piso <= 0D OrElse piso <> Decimal.Truncate(piso) OrElse piso > 99D Then
                MessageBox.Show("El piso debe ser un número entero entre 1 y 99.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosPiso.Focus()
                Exit Sub
            End If

            If txtConsultoriosDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtConsultoriosDescripcion.Focus()
                Exit Sub
            End If

            Dim coConsultorioEditar As New SqlCommand("Atenciones.spConsultoriosEditarRegistro", cn)
            coConsultorioEditar.CommandType = CommandType.StoredProcedure

            coConsultorioEditar.Parameters.Add(New SqlParameter("@ConsultoriosCodigo",
                                                SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value = txtConsultoriosCodigo.Text.Trim()

            coConsultorioEditar.Parameters.Add(New SqlParameter("@ConsultoriosNombre",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtConsultoriosNombre.Text.Trim()

            coConsultorioEditar.Parameters.Add(New SqlParameter("@ConsultoriosNumero",
                                                SqlDbType.NChar, 5,
                                                ParameterDirection.Input)).Value = txtConsultoriosNumero.Text.Trim()

            coConsultorioEditar.Parameters.Add(New SqlParameter("@ConsultoriosUbicacion",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtConsultoriosUbicacion.Text.Trim()

            Dim parametroPiso As SqlParameter = coConsultorioEditar.Parameters.Add("@ConsultoriosPiso", SqlDbType.Decimal)
            parametroPiso.Precision = 2
            parametroPiso.Scale = 0
            parametroPiso.Value = piso

            coConsultorioEditar.Parameters.Add(New SqlParameter("@ConsultoriosDescripcion",
                                                SqlDbType.NVarChar, 250,
                                                ParameterDirection.Input)).Value = txtConsultoriosDescripcion.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coConsultorioEditar.ExecuteNonQuery()
                MessageBox.Show("Consultorio modificado.", "Edición de consultorio",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el consultorio." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coConsultorioEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtConsultoriosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Consultorios").Rows.Count - 1
                If dsDatos.Tables("Consultorios").Rows(i).Item("ConsultoriosCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub ConsultoriosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("Consultorios").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar el consultorio " & vbCrLf &
                           txtConsultoriosNombre.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coConsultorioEliminar As New SqlCommand("Atenciones.spConsultoriosEliminarRegistro", cn)
            coConsultorioEliminar.CommandType = CommandType.StoredProcedure

            coConsultorioEliminar.Parameters.Add(New SqlParameter("@ConsultoriosCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtConsultoriosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coConsultorioEliminar.ExecuteNonQuery()
                MessageBox.Show("Consultorio eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el consultorio." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coConsultorioEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Consultorios").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Consultorios").Rows.Count > 0,
                    dsDatos.Tables("Consultorios").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub ConsultoriosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Consultorios").Rows.Count > 0,
                dsDatos.Tables("Consultorios").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Consultorios").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub ConsultoriosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub ConsultoriosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vConsultorioRecuperado = 0

        Dim fConsultoriosEliminados As New frmConsultoriosEliminados()
        fConsultoriosEliminados.ShowDialog()
        fConsultoriosEliminados.Dispose()

        If vConsultorioRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Consultorios").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Consultorios").Rows.Count > 0,
                    dsDatos.Tables("Consultorios").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
