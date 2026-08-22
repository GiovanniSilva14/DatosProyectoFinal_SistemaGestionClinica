' Name Spaces
Imports System.Data
Imports System.Data.SqlClient

Public Class frmPacientes

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daPacientes As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub LibrosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        MostrarRegistro()
        LlenarLista()
        Controles(False, False, False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet
        daPacientes = New SqlDataAdapter("Atenciones.spPacientesListaSinBorrados", cn)
        daPacientes.Fill(dsDatos, "Pacientes")
    End Sub

    Private Sub MostrarRegistro()
        txtPacientesCodigo.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesCodigo").ToString
        txtPacientesDNI.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesDNI").ToString
        txtPacientesNombres.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesNombres").ToString
        txtPacientesApellidos.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesApellidos").ToString
        txtPacientesSexo.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesSexo").ToString
        txtPacientesTelefono.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesTelefono").ToString
        txtPacientesCorreo.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesCorreo").ToString
        txtPacientesDireccion.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesDireccion").ToString
        txtPacientesCondiciones.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesCondiciones").ToString
        dtpPacientesFechaNacimiento.Text = dsDatos.Tables("Pacientes").Rows(vPosicion).Item("PacientesFechaNacimiento").ToString
    End Sub

    Private Sub LlenarLista()
        lvPacientesRegistrados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Pacientes").Rows.Count - 1
            lvPacientesRegistrados.Items.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesCodigo").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesDNI").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesNombres").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesApellidos").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesSexo").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesTelefono").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesCorreo").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesDireccion").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesCondiciones").ToString)
            lvPacientesRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Pacientes").Rows(i).Item("PacientesFechaNacimiento").ToString)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pDNI As Boolean, pNombres As Boolean, pApellidos As Boolean, pFechaNacimiento As Boolean, pSexo As Boolean, pTelefono As Boolean,
                          pCorreo As Boolean, pDireccion As Boolean, pCondiciones As Boolean, pLista As Boolean)
        txtPacientesCodigo.Enabled = pCodigo
        txtPacientesDNI.Enabled = pDNI
        txtPacientesNombres.Enabled = pNombres
        txtPacientesApellidos.Enabled = pApellidos
        txtPacientesSexo.Enabled = pFechaNacimiento
        txtPacientesTelefono.Enabled = pTelefono
        txtPacientesCorreo.Enabled = pCorreo
        txtPacientesDireccion.Enabled = pDireccion
        txtPacientesCondiciones.Enabled = pCondiciones
        dtpPacientesFechaNacimiento.Enabled = pFechaNacimiento
        lvPacientesRegistrados.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean, pEditar As Boolean, pEliminar As Boolean, pCancelar As Boolean, pCerrar As Boolean, pEliminados As Boolean)
        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub PacientesSeleccion(sender As Object, e As EventArgs) Handles lvPacientesRegistrados.SelectedIndexChanged
        If lvPacientesRegistrados.SelectedItems.Count = 0 Then Exit Sub
        For i As Integer = 0 To dsDatos.Tables("Pacientes").Rows.Count - 1
            If lvPacientesRegistrados.SelectedItems(0).Text = dsDatos.Tables("Pacientes").Rows(i).Item("PacientesCodigo") Then
                vPosicion = i
                Exit For
            End If
        Next
        MostrarRegistro()
    End Sub

    Private Sub PacientesAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)
            txtPacientesCodigo.Clear() : txtPacientesDNI.Clear() : txtPacientesNombres.Clear() : txtPacientesApellidos.Clear()
            txtPacientesSexo.Clear() : txtPacientesTelefono.Clear() : txtPacientesCorreo.Clear() : txtPacientesDireccion.Clear()
            txtPacientesCondiciones.Clear() : txtPacientesCodigo.Focus()

        Else
            ' Consistencias
            ' Consistencias de los datos 
            ' Datos tipo caracter obligatorio
            If Len(Trim(txtPacientesCodigo.Text)) = 0 Or Len(Trim(txtPacientesCodigo.Text)) <> 7 Then
                MessageBox.Show("Código incorrecto, debe ser de 7 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCodigo.Focus()
                Exit Sub
            End If

            ' DNI
            If Len(Trim(txtPacientesDNI.Text)) = 0 Then
                MessageBox.Show("Falta DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesDNI.Focus()
                Exit Sub
            End If

            ' Nombres
            If Len(Trim(txtPacientesNombres.Text)) = 0 Then
                MessageBox.Show("Falta Nombres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesNombres.Focus()
                Exit Sub
            End If

            ' Apellidos
            If Len(Trim(txtPacientesApellidos.Text)) = 0 Then
                MessageBox.Show("Falta Apellidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesApellidos.Focus()
                Exit Sub
            End If

            ' Sexo
            If Len(Trim(txtPacientesSexo.Text)) = 0 Then
                MessageBox.Show("Falta Sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesSexo.Focus()
                Exit Sub
            End If

            ' Teléfono
            If Len(Trim(txtPacientesTelefono.Text)) = 0 Then
                MessageBox.Show("Falta Teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesTelefono.Focus()
                Exit Sub
            End If

            ' Correo
            If Len(Trim(txtPacientesCorreo.Text)) = 0 Then
                MessageBox.Show("Falta Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCorreo.Focus()
                Exit Sub
            End If

            ' Dirección
            If Len(Trim(txtPacientesDireccion.Text)) = 0 Then
                MessageBox.Show("Falta Dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesDireccion.Focus()
                Exit Sub
            End If

            ' Condiciones
            If Len(Trim(txtPacientesCondiciones.Text)) = 0 Then
                MessageBox.Show("Falta Condiciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCondiciones.Focus()
                Exit Sub
            End If

            ' Consumir SP para insertar 
            ' Crear comando sql 
            Dim coPacienteNuevo As New SqlCommand("Atenciones.spPacientesInsertarRegistro", cn)
            coPacienteNuevo.CommandType = CommandType.StoredProcedure

            '@PacientesCodigo nchar(7), 
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtPacientesCodigo.Text

            '@PacientesDNI nchar(8),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesDNI", SqlDbType.NChar, 8, ParameterDirection.Input)).Value = txtPacientesDNI.Text

            '@PacientesNombres nvarchar(100),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesNombres", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesNombres.Text

            '@PacientesApellidos nvarchar(100),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesApellidos", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesApellidos.Text

            '@PacientesFechaNacimiento date,
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesFechaNacimiento", SqlDbType.Date)).Value = dtpPacientesFechaNacimiento.Text

            '@PacientesSexo nchar(1),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesSexo", SqlDbType.NChar, 1, ParameterDirection.Input)).Value = txtPacientesSexo.Text

            '@PacientesTelefono nchar(9),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesTelefono", SqlDbType.NChar, 9, ParameterDirection.Input)).Value = txtPacientesTelefono.Text

            '@PacientesCorreo nvarchar(100),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesCorreo", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesCorreo.Text

            '@PacientesDireccion nvarchar(200),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesDireccion", SqlDbType.NVarChar, 200, ParameterDirection.Input)).Value = txtPacientesDireccion.Text

            '@PacientesCondiciones nvarchar(300),
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesCondiciones", SqlDbType.NVarChar, 300, ParameterDirection.Input)).Value = txtPacientesCondiciones.Text

            '@PacientesEstado nchar(1)
            coPacienteNuevo.Parameters.Add(New SqlParameter("@PacientesEstado", SqlDbType.NChar, 1, ParameterDirection.Input)).Value = "A"

            ' Conexión 
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If
            Try
                cn.Open()
                coPacienteNuevo.ExecuteNonQuery()
                MessageBox.Show("Paciente registrado", "Inserccion de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show("No se pudo insertar el registro")
                'No usar 
                MessageBox.Show(ex.Message)
                Exit Sub
            Finally
                cn.Close()
            End Try

            CreaDataSet()
            LlenarLista()

            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If

    End Sub

    Private Sub PacientesElminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If MessageBox.Show("¿Desea eliminar a " & vbCrLf & Trim(txtPacientesApellidos.Text) & " " & Trim(txtPacientesNombres.Text) & " ?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            Dim coPacientesEliminar As New SqlCommand("Atenciones.spPacientesEliminarRegistro", cn)
            coPacientesEliminar.CommandType = CommandType.StoredProcedure
            coPacientesEliminar.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtPacientesCodigo.Text
            cn.Open()
            coPacientesEliminar.ExecuteNonQuery()
            cn.Close()
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            MostrarRegistro()
            MessageBox.Show("Paciente eliminado", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub PacientesEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If cmdEditar.Text.Trim = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)

        Else
            ' Consistencias
            ' Consistencias de los datos 
            ' DNI
            If Len(Trim(txtPacientesDNI.Text)) = 0 Then
                MessageBox.Show("Falta DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesDNI.Focus()
                Exit Sub
            End If

            ' Nombres
            If Len(Trim(txtPacientesNombres.Text)) = 0 Then
                MessageBox.Show("Falta Nombres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesNombres.Focus()
                Exit Sub
            End If

            ' Apellidos
            If Len(Trim(txtPacientesApellidos.Text)) = 0 Then
                MessageBox.Show("Falta Apellidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesApellidos.Focus()
                Exit Sub
            End If

            ' Sexo
            If Len(Trim(txtPacientesSexo.Text)) = 0 Then
                MessageBox.Show("Falta Sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesSexo.Focus()
                Exit Sub
            End If

            ' Teléfono
            If Len(Trim(txtPacientesTelefono.Text)) = 0 Then
                MessageBox.Show("Falta Teléfono", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesTelefono.Focus()
                Exit Sub
            End If

            ' Correo
            If Len(Trim(txtPacientesCorreo.Text)) = 0 Then
                MessageBox.Show("Falta Correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCorreo.Focus()
                Exit Sub
            End If

            ' Dirección
            If Len(Trim(txtPacientesDireccion.Text)) = 0 Then
                MessageBox.Show("Falta Dirección", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesDireccion.Focus()
                Exit Sub
            End If

            ' Condiciones
            If Len(Trim(txtPacientesCondiciones.Text)) = 0 Then
                MessageBox.Show("Falta Condiciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPacientesCondiciones.Focus()
                Exit Sub
            End If

            ' Consumir SP para editar
            ' Crear comando sql 
            Dim coPacienteEditar As New SqlCommand("Atenciones.spPacientesEditarRegistro", cn)
            coPacienteEditar.CommandType = CommandType.StoredProcedure

            '@PacientesCodigo nchar(7), 
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesCodigo", SqlDbType.NChar, 7, ParameterDirection.Input)).Value = txtPacientesCodigo.Text

            '@PacientesDNI nchar(8),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesDNI", SqlDbType.NChar, 8, ParameterDirection.Input)).Value = txtPacientesDNI.Text

            '@PacientesNombres nvarchar(100),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesNombres", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesNombres.Text

            '@PacientesApellidos nvarchar(100),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesApellidos", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesApellidos.Text

            '@PacientesFechaNacimiento date,
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesFechaNacimiento", SqlDbType.Date)).Value = dtpPacientesFechaNacimiento.Text

            '@PacientesSexo nchar(1),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesSexo", SqlDbType.NChar, 1, ParameterDirection.Input)).Value = txtPacientesSexo.Text

            '@PacientesTelefono nchar(9),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesTelefono", SqlDbType.NChar, 9, ParameterDirection.Input)).Value = txtPacientesTelefono.Text

            '@PacientesCorreo nvarchar(100),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesCorreo", SqlDbType.NVarChar, 100, ParameterDirection.Input)).Value = txtPacientesCorreo.Text

            '@PacientesDireccion nvarchar(200),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesDireccion", SqlDbType.NVarChar, 200, ParameterDirection.Input)).Value = txtPacientesDireccion.Text

            '@PacientesCondiciones nvarchar(300),
            coPacienteEditar.Parameters.Add(New SqlParameter("@PacientesCondiciones", SqlDbType.NVarChar, 300, ParameterDirection.Input)).Value = txtPacientesCondiciones.Text

            ' Conexión 
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If
            Try
                cn.Open()
                coPacienteEditar.ExecuteNonQuery()
                MessageBox.Show("Paciente modificado", "Edición de Paciente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show("No se pudo modificar el registro")
                'No usar 
                MessageBox.Show(ex.Message)
                Exit Sub
            Finally
                cn.Close()
            End Try

            CreaDataSet()
            LlenarLista()

            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If


    End Sub


    Private Sub PacientesCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)

        If dsDatos.Tables("Pacientes").Rows.Count > 0 Then
            MostrarRegistro()
        End If
    End Sub


    Private Sub PacientesCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()

    End Sub

    Private Sub PacientesEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vPacienteRecuperado = 0
        Dim fPacientesEliminados As New frmPacientesElminados
        fPacientesEliminados.ShowDialog()
        If vPacienteRecuperado = 1 Then
            CreaDataSet()
            LlenarLista()
            MostrarRegistro()
        End If
    End Sub
End Class