Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetaLaboratorios

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daRecetaLaboratorios As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub RecetaLaboratoriosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0,
                dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daRecetaLaboratorios = New SqlDataAdapter("Atenciones.spRecetaLaboratoriosListaSinBorrados", cn)
        daRecetaLaboratorios.SelectCommand.CommandType = CommandType.StoredProcedure
        daRecetaLaboratorios.Fill(dsDatos, "RecetaLaboratorios")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("RecetaLaboratorios").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("RecetaLaboratorios").Rows.Count Then
            vPosicion = 0
        End If

        txtRecetaLaboratoriosCodigo.Text = dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosCodigo").ToString().Trim()
        txtRecetaCodigo.Text = dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaCodigo").ToString().Trim()
        txtRecetaLaboratoriosExamen.Text = dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosExamen").ToString().Trim()
        txtRecetaLaboratoriosResultado.Text = dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosResultado").ToString().Trim()

        If Not IsDBNull(dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosFecha")) Then
            dtpRecetaLaboratoriosFecha.Value = CDate(dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosFecha"))
        End If

        txtRecetaLaboratoriosObservaciones.Text = dsDatos.Tables("RecetaLaboratorios").Rows(vPosicion).Item("RecetaLaboratoriosObservaciones").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvRecetaLaboratoriosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("RecetaLaboratorios").Rows.Count - 1
            lvRecetaLaboratoriosRegistrados.Items.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosCodigo").ToString().Trim())
            lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaCodigo").ToString().Trim())
            lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosExamen").ToString().Trim())
            lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosResultado").ToString().Trim())

            If IsDBNull(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosFecha")) Then
                lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add("")
            Else
                lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(CDate(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosFecha")).ToString("dd/MM/yyyy"))
            End If

            lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosObservaciones").ToString().Trim())
            lvRecetaLaboratoriosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pReceta As Boolean,
                          pExamen As Boolean, pResultado As Boolean,
                          pFecha As Boolean, pObservaciones As Boolean,
                          pLista As Boolean)
        txtRecetaLaboratoriosCodigo.Enabled = pCodigo
        txtRecetaCodigo.Enabled = pReceta
        txtRecetaLaboratoriosExamen.Enabled = pExamen
        txtRecetaLaboratoriosResultado.Enabled = pResultado
        dtpRecetaLaboratoriosFecha.Enabled = pFecha
        txtRecetaLaboratoriosObservaciones.Enabled = pObservaciones
        lvRecetaLaboratoriosRegistrados.Enabled = pLista
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
        txtRecetaLaboratoriosCodigo.Clear()
        txtRecetaCodigo.Clear()
        txtRecetaLaboratoriosExamen.Clear()
        txtRecetaLaboratoriosResultado.Clear()
        dtpRecetaLaboratoriosFecha.Value = Date.Today
        txtRecetaLaboratoriosObservaciones.Clear()
    End Sub

    Private Sub RecetaLaboratoriosSeleccion(sender As Object, e As EventArgs) Handles lvRecetaLaboratoriosRegistrados.SelectedIndexChanged
        If lvRecetaLaboratoriosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("RecetaLaboratorios").Rows.Count - 1
            If lvRecetaLaboratoriosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub RecetaLaboratoriosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtRecetaLaboratoriosCodigo.Focus()

        Else
            If txtRecetaLaboratoriosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosCodigo.Focus()
                Exit Sub
            End If

            If txtRecetaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de receta debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtRecetaLaboratoriosExamen.Text) Then
                MessageBox.Show("Falta el nombre del examen.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosExamen.Focus()
                Exit Sub
            End If

            If txtRecetaLaboratoriosExamen.Text.Trim().Length > 150 Then
                MessageBox.Show("El examen no puede superar 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosExamen.Focus()
                Exit Sub
            End If

            If txtRecetaLaboratoriosResultado.Text.Trim().Length > 300 Then
                MessageBox.Show("El resultado no puede superar 300 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosResultado.Focus()
                Exit Sub
            End If

            If txtRecetaLaboratoriosObservaciones.Text.Trim().Length > 300 Then
                MessageBox.Show("Las observaciones no pueden superar 300 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosObservaciones.Focus()
                Exit Sub
            End If

            Dim coRecetaLaboratorioNuevo As New SqlCommand("Atenciones.spRecetaLaboratoriosInsertarRegistro", cn)
            coRecetaLaboratorioNuevo.CommandType = CommandType.StoredProcedure

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaLaboratoriosCodigo",
                                                     SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value = txtRecetaLaboratoriosCodigo.Text.Trim()

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaCodigo",
                                                     SqlDbType.NChar, 7,
                                                     ParameterDirection.Input)).Value = txtRecetaCodigo.Text.Trim()

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaLaboratoriosExamen",
                                                     SqlDbType.NVarChar, 150,
                                                     ParameterDirection.Input)).Value = txtRecetaLaboratoriosExamen.Text.Trim()

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaLaboratoriosResultado",
                                                     SqlDbType.NVarChar, 300,
                                                     ParameterDirection.Input)).Value = txtRecetaLaboratoriosResultado.Text.Trim()

            coRecetaLaboratorioNuevo.Parameters.Add("@RecetaLaboratoriosFecha",
                                                    SqlDbType.Date).Value = dtpRecetaLaboratoriosFecha.Value.Date

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaLaboratoriosObservaciones",
                                                     SqlDbType.NVarChar, 300,
                                                     ParameterDirection.Input)).Value = txtRecetaLaboratoriosObservaciones.Text.Trim()

            coRecetaLaboratorioNuevo.Parameters.Add(New SqlParameter("@RecetaLaboratoriosEstado",
                                                     SqlDbType.NChar, 1,
                                                     ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaLaboratorioNuevo.ExecuteNonQuery()
                MessageBox.Show("Examen de laboratorio registrado.", "Inserción",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el registro." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaLaboratorioNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtRecetaLaboratoriosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("RecetaLaboratorios").Rows.Count - 1
                If dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosCodigo").ToString().Trim() = codigoRegistrado Then
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

    Private Sub RecetaLaboratoriosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("RecetaLaboratorios").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtRecetaCodigo.Focus()

        Else
            If txtRecetaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de receta debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtRecetaLaboratoriosExamen.Text) OrElse
               txtRecetaLaboratoriosExamen.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese un examen válido de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosExamen.Focus()
                Exit Sub
            End If

            If txtRecetaLaboratoriosResultado.Text.Trim().Length > 300 Then
                MessageBox.Show("El resultado no puede superar 300 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosResultado.Focus()
                Exit Sub
            End If

            If txtRecetaLaboratoriosObservaciones.Text.Trim().Length > 300 Then
                MessageBox.Show("Las observaciones no pueden superar 300 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRecetaLaboratoriosObservaciones.Focus()
                Exit Sub
            End If

            Dim coRecetaLaboratorioEditar As New SqlCommand("Atenciones.spRecetaLaboratoriosEditarRegistro", cn)
            coRecetaLaboratorioEditar.CommandType = CommandType.StoredProcedure

            coRecetaLaboratorioEditar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosCodigo",
                                                      SqlDbType.NChar, 7,
                                                      ParameterDirection.Input)).Value = txtRecetaLaboratoriosCodigo.Text.Trim()

            coRecetaLaboratorioEditar.Parameters.Add(New SqlParameter("@RecetaCodigo",
                                                      SqlDbType.NChar, 7,
                                                      ParameterDirection.Input)).Value = txtRecetaCodigo.Text.Trim()

            coRecetaLaboratorioEditar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosExamen",
                                                      SqlDbType.NVarChar, 150,
                                                      ParameterDirection.Input)).Value = txtRecetaLaboratoriosExamen.Text.Trim()

            coRecetaLaboratorioEditar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosResultado",
                                                      SqlDbType.NVarChar, 300,
                                                      ParameterDirection.Input)).Value = txtRecetaLaboratoriosResultado.Text.Trim()

            coRecetaLaboratorioEditar.Parameters.Add("@RecetaLaboratoriosFecha",
                                                     SqlDbType.Date).Value = dtpRecetaLaboratoriosFecha.Value.Date

            coRecetaLaboratorioEditar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosObservaciones",
                                                      SqlDbType.NVarChar, 300,
                                                      ParameterDirection.Input)).Value = txtRecetaLaboratoriosObservaciones.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaLaboratorioEditar.ExecuteNonQuery()
                MessageBox.Show("Examen de laboratorio modificado.", "Edición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el registro." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaLaboratorioEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtRecetaLaboratoriosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("RecetaLaboratorios").Rows.Count - 1
                If dsDatos.Tables("RecetaLaboratorios").Rows(i).Item("RecetaLaboratoriosCodigo").ToString().Trim() = codigoEditado Then
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

    Private Sub RecetaLaboratoriosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("RecetaLaboratorios").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar el examen " & vbCrLf &
                           txtRecetaLaboratoriosExamen.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetaLaboratorioEliminar As New SqlCommand("Atenciones.spRecetaLaboratoriosEliminarRegistro", cn)
            coRecetaLaboratorioEliminar.CommandType = CommandType.StoredProcedure

            coRecetaLaboratorioEliminar.Parameters.Add(New SqlParameter("@RecetaLaboratoriosCodigo",
                                                       SqlDbType.NChar, 7,
                                                       ParameterDirection.Input)).Value = txtRecetaLaboratoriosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coRecetaLaboratorioEliminar.ExecuteNonQuery()
                MessageBox.Show("Examen de laboratorio eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el registro." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coRecetaLaboratorioEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0,
                    dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub RecetaLaboratoriosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0,
                dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub RecetaLaboratoriosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub RecetaLaboratoriosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vRecetaLaboratorioRecuperado = 0

        Dim fRecetaLaboratoriosEliminados As New frmRecetaLaboratoriosEliminados()
        fRecetaLaboratoriosEliminados.ShowDialog()
        fRecetaLaboratoriosEliminados.Dispose()

        If vRecetaLaboratorioRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0,
                    dsDatos.Tables("RecetaLaboratorios").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
