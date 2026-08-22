Imports System.Data
Imports System.Data.SqlClient

Public Class frmEmpleados

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEmpleados As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub EmpleadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Empleados").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Empleados").Rows.Count > 0,
                dsDatos.Tables("Empleados").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEmpleados = New SqlDataAdapter("Atenciones.spEmpleadosListaSinBorrados", cn)
        daEmpleados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEmpleados.Fill(dsDatos, "Empleados")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Empleados").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Empleados").Rows.Count Then
            vPosicion = 0
        End If

        txtEmpleadosCodigo.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosCodigo").ToString().Trim()
        txtEmpleadosDNI.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosDNI").ToString().Trim()
        txtEmpleadosNombres.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosNombres").ToString().Trim()
        txtEmpleadosApellidos.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosApellidos").ToString().Trim()
        txtEmpleadosCargo.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosCargo").ToString().Trim()
        txtEmpleadosTelefono.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosTelefono").ToString().Trim()
        txtEmpleadosCorreo.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosCorreo").ToString().Trim()
        txtEmpleadosDireccion.Text = dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosDireccion").ToString().Trim()
        dtpEmpleadosFechaIngreso.Value = CDate(dsDatos.Tables("Empleados").Rows(vPosicion).Item("EmpleadosFechaIngreso"))
    End Sub

    Private Sub LlenarLista()
        lvEmpleadosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Empleados").Rows.Count - 1
            lvEmpleadosRegistrados.Items.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCodigo").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosDNI").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosNombres").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosApellidos").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCargo").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosTelefono").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCorreo").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosDireccion").ToString().Trim())
            lvEmpleadosRegistrados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosFechaIngreso")).ToString("dd/MM/yyyy"))
            lvEmpleadosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pDNI As Boolean,
                          pNombres As Boolean, pApellidos As Boolean,
                          pCargo As Boolean, pTelefono As Boolean,
                          pCorreo As Boolean, pDireccion As Boolean,
                          pFechaIngreso As Boolean, pLista As Boolean)
        txtEmpleadosCodigo.Enabled = pCodigo
        txtEmpleadosDNI.Enabled = pDNI
        txtEmpleadosNombres.Enabled = pNombres
        txtEmpleadosApellidos.Enabled = pApellidos
        txtEmpleadosCargo.Enabled = pCargo
        txtEmpleadosTelefono.Enabled = pTelefono
        txtEmpleadosCorreo.Enabled = pCorreo
        txtEmpleadosDireccion.Enabled = pDireccion
        dtpEmpleadosFechaIngreso.Enabled = pFechaIngreso
        lvEmpleadosRegistrados.Enabled = pLista
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
        txtEmpleadosCodigo.Clear()
        txtEmpleadosDNI.Clear()
        txtEmpleadosNombres.Clear()
        txtEmpleadosApellidos.Clear()
        txtEmpleadosCargo.Clear()
        txtEmpleadosTelefono.Clear()
        txtEmpleadosCorreo.Clear()
        txtEmpleadosDireccion.Clear()
        dtpEmpleadosFechaIngreso.Value = Date.Today
    End Sub

    Private Sub EmpleadosSeleccion(sender As Object, e As EventArgs) Handles lvEmpleadosRegistrados.SelectedIndexChanged
        If lvEmpleadosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Empleados").Rows.Count - 1
            If lvEmpleadosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub EmpleadosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtEmpleadosCodigo.Focus()

        Else
            If txtEmpleadosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCodigo.Focus()
                Exit Sub
            End If

            If txtEmpleadosDNI.Text.Trim().Length <> 8 Then
                MessageBox.Show("El DNI debe tener 8 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosDNI.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosNombres.Text) OrElse
               txtEmpleadosNombres.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese nombres válidos de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosNombres.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosApellidos.Text) OrElse
               txtEmpleadosApellidos.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese apellidos válidos de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosApellidos.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosCargo.Text) OrElse
               txtEmpleadosCargo.Text.Trim().Length > 50 Then
                MessageBox.Show("Ingrese un cargo válido de hasta 50 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCargo.Focus()
                Exit Sub
            End If

            If txtEmpleadosTelefono.Text.Trim().Length > 0 AndAlso
               txtEmpleadosTelefono.Text.Trim().Length <> 9 Then
                MessageBox.Show("El teléfono debe tener 9 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosTelefono.Focus()
                Exit Sub
            End If

            If txtEmpleadosCorreo.Text.Trim().Length > 100 Then
                MessageBox.Show("El correo no puede superar 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCorreo.Focus()
                Exit Sub
            End If

            If txtEmpleadosDireccion.Text.Trim().Length > 200 Then
                MessageBox.Show("La dirección no puede superar 200 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosDireccion.Focus()
                Exit Sub
            End If

            Dim coEmpleadoNuevo As New SqlCommand("Atenciones.spEmpleadosInsertarRegistro", cn)
            coEmpleadoNuevo.CommandType = CommandType.StoredProcedure

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosCodigo",
                                            SqlDbType.NChar, 7,
                                            ParameterDirection.Input)).Value = txtEmpleadosCodigo.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosDNI",
                                            SqlDbType.NChar, 8,
                                            ParameterDirection.Input)).Value = txtEmpleadosDNI.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosNombres",
                                            SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input)).Value = txtEmpleadosNombres.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosApellidos",
                                            SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input)).Value = txtEmpleadosApellidos.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosCargo",
                                            SqlDbType.NVarChar, 50,
                                            ParameterDirection.Input)).Value = txtEmpleadosCargo.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosTelefono",
                                            SqlDbType.NChar, 9,
                                            ParameterDirection.Input)).Value = txtEmpleadosTelefono.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosCorreo",
                                            SqlDbType.NVarChar, 100,
                                            ParameterDirection.Input)).Value = txtEmpleadosCorreo.Text.Trim()

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosDireccion",
                                            SqlDbType.NVarChar, 200,
                                            ParameterDirection.Input)).Value = txtEmpleadosDireccion.Text.Trim()

            coEmpleadoNuevo.Parameters.Add("@EmpleadosFechaIngreso",
                                           SqlDbType.Date).Value = dtpEmpleadosFechaIngreso.Value.Date

            coEmpleadoNuevo.Parameters.Add(New SqlParameter("@EmpleadosEstado",
                                            SqlDbType.NChar, 1,
                                            ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEmpleadoNuevo.ExecuteNonQuery()
                MessageBox.Show("Empleado registrado.", "Inserción de empleado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el empleado." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEmpleadoNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtEmpleadosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Empleados").Rows.Count - 1
                If dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub EmpleadosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Empleados").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtEmpleadosDNI.Focus()

        Else
            If txtEmpleadosDNI.Text.Trim().Length <> 8 Then
                MessageBox.Show("El DNI debe tener 8 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosDNI.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosNombres.Text) OrElse
               txtEmpleadosNombres.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese nombres válidos de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosNombres.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosApellidos.Text) OrElse
               txtEmpleadosApellidos.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese apellidos válidos de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosApellidos.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtEmpleadosCargo.Text) OrElse
               txtEmpleadosCargo.Text.Trim().Length > 50 Then
                MessageBox.Show("Ingrese un cargo válido de hasta 50 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosCargo.Focus()
                Exit Sub
            End If

            If txtEmpleadosTelefono.Text.Trim().Length > 0 AndAlso
               txtEmpleadosTelefono.Text.Trim().Length <> 9 Then
                MessageBox.Show("El teléfono debe tener 9 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtEmpleadosTelefono.Focus()
                Exit Sub
            End If

            If txtEmpleadosCorreo.Text.Trim().Length > 100 OrElse
               txtEmpleadosDireccion.Text.Trim().Length > 200 Then
                MessageBox.Show("El correo o la dirección superan la longitud permitida.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim coEmpleadoEditar As New SqlCommand("Atenciones.spEmpleadosEditarRegistro", cn)
            coEmpleadoEditar.CommandType = CommandType.StoredProcedure

            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosCodigo", SqlDbType.NChar, 7,
                                             ParameterDirection.Input)).Value = txtEmpleadosCodigo.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosDNI", SqlDbType.NChar, 8,
                                             ParameterDirection.Input)).Value = txtEmpleadosDNI.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosNombres", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input)).Value = txtEmpleadosNombres.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosApellidos", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input)).Value = txtEmpleadosApellidos.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosCargo", SqlDbType.NVarChar, 50,
                                             ParameterDirection.Input)).Value = txtEmpleadosCargo.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosTelefono", SqlDbType.NChar, 9,
                                             ParameterDirection.Input)).Value = txtEmpleadosTelefono.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosCorreo", SqlDbType.NVarChar, 100,
                                             ParameterDirection.Input)).Value = txtEmpleadosCorreo.Text.Trim()
            coEmpleadoEditar.Parameters.Add(New SqlParameter("@EmpleadosDireccion", SqlDbType.NVarChar, 200,
                                             ParameterDirection.Input)).Value = txtEmpleadosDireccion.Text.Trim()
            coEmpleadoEditar.Parameters.Add("@EmpleadosFechaIngreso",
                                            SqlDbType.Date).Value = dtpEmpleadosFechaIngreso.Value.Date

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coEmpleadoEditar.ExecuteNonQuery()
                MessageBox.Show("Empleado modificado.", "Edición de empleado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el empleado." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEmpleadoEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtEmpleadosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Empleados").Rows.Count - 1
                If dsDatos.Tables("Empleados").Rows(i).Item("EmpleadosCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub EmpleadosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Empleados").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar al empleado " & vbCrLf &
                           txtEmpleadosNombres.Text.Trim() & " " & txtEmpleadosApellidos.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coEmpleadoEliminar As New SqlCommand("Atenciones.spEmpleadosEliminarRegistro", cn)
            coEmpleadoEliminar.CommandType = CommandType.StoredProcedure
            coEmpleadoEliminar.Parameters.Add(New SqlParameter("@EmpleadosCodigo", SqlDbType.NChar, 7,
                                               ParameterDirection.Input)).Value = txtEmpleadosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coEmpleadoEliminar.ExecuteNonQuery()
                MessageBox.Show("Empleado eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el empleado." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEmpleadoEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("Empleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("Empleados").Rows.Count > 0,
                    dsDatos.Tables("Empleados").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub EmpleadosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Empleados").Rows.Count > 0,
                dsDatos.Tables("Empleados").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("Empleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub EmpleadosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub EmpleadosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vEmpleadoRecuperado = 0
        Dim fEmpleadosEliminados As New frmEmpleadosEliminados()
        fEmpleadosEliminados.ShowDialog()
        fEmpleadosEliminados.Dispose()

        If vEmpleadoRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("Empleados").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("Empleados").Rows.Count > 0,
                    dsDatos.Tables("Empleados").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
