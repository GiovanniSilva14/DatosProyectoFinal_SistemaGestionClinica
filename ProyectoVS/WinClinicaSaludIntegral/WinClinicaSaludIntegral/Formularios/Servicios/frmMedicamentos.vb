Imports System.Data
Imports System.Data.SqlClient

Public Class frmMedicamentos

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daMedicamentos As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub MedicamentosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Medicamentos").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Medicamentos").Rows.Count > 0,
                dsDatos.Tables("Medicamentos").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daMedicamentos = New SqlDataAdapter("Atenciones.spMedicamentosListaSinBorrados", cn)
        daMedicamentos.SelectCommand.CommandType = CommandType.StoredProcedure
        daMedicamentos.Fill(dsDatos, "Medicamentos")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Medicamentos").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Medicamentos").Rows.Count Then
            vPosicion = 0
        End If

        txtMedicamentosCodigo.Text = dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosCodigo").ToString().Trim()
        txtDistribuidorasCodigo.Text = dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("DistribuidorasCodigo").ToString().Trim()
        txtMedicamentosNombre.Text = dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosNombre").ToString().Trim()
        txtMedicamentosPresentacion.Text = dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosPresentacion").ToString().Trim()
        txtMedicamentosStock.Text = CDec(dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosStock")).ToString("0")
        txtMedicamentosPrecio.Text = CDec(dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosPrecio")).ToString("0.00")
        dtpMedicamentosFechaVencimiento.Value = CDate(dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosFechaVencimiento"))
        txtMedicamentosDescripcion.Text = dsDatos.Tables("Medicamentos").Rows(vPosicion).Item("MedicamentosDescripcion").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvMedicamentosRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Medicamentos").Rows.Count - 1
            lvMedicamentosRegistrados.Items.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosCodigo").ToString().Trim())
            lvMedicamentosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("DistribuidorasCodigo").ToString().Trim())
            lvMedicamentosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosNombre").ToString().Trim())
            lvMedicamentosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosPresentacion").ToString().Trim())
            lvMedicamentosRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosStock")).ToString("0"))
            lvMedicamentosRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosPrecio")).ToString("0.00"))
            lvMedicamentosRegistrados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosFechaVencimiento")).ToString("dd/MM/yyyy"))
            lvMedicamentosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosDescripcion").ToString().Trim())
            lvMedicamentosRegistrados.Items(i).SubItems.Add(dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pDistribuidora As Boolean,
                          pNombre As Boolean, pPresentacion As Boolean,
                          pStock As Boolean, pPrecio As Boolean,
                          pFechaVencimiento As Boolean, pDescripcion As Boolean,
                          pLista As Boolean)
        txtMedicamentosCodigo.Enabled = pCodigo
        txtDistribuidorasCodigo.Enabled = pDistribuidora
        txtMedicamentosNombre.Enabled = pNombre
        txtMedicamentosPresentacion.Enabled = pPresentacion
        txtMedicamentosStock.Enabled = pStock
        txtMedicamentosPrecio.Enabled = pPrecio
        dtpMedicamentosFechaVencimiento.Enabled = pFechaVencimiento
        txtMedicamentosDescripcion.Enabled = pDescripcion
        lvMedicamentosRegistrados.Enabled = pLista
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
        txtMedicamentosCodigo.Clear()
        txtDistribuidorasCodigo.Clear()
        txtMedicamentosNombre.Clear()
        txtMedicamentosPresentacion.Clear()
        txtMedicamentosStock.Clear()
        txtMedicamentosPrecio.Clear()
        dtpMedicamentosFechaVencimiento.Value = Date.Today
        txtMedicamentosDescripcion.Clear()
    End Sub

    Private Sub MedicamentosSeleccion(sender As Object, e As EventArgs) Handles lvMedicamentosRegistrados.SelectedIndexChanged
        If lvMedicamentosRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("Medicamentos").Rows.Count - 1
            If lvMedicamentosRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub MedicamentosAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtMedicamentosCodigo.Focus()

        Else
            Dim stock As Decimal
            Dim precio As Decimal

            If txtMedicamentosCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosCodigo.Focus()
                Exit Sub
            End If

            If txtDistribuidorasCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de distribuidora debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtMedicamentosNombre.Text) OrElse
               txtMedicamentosNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese un nombre válido de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosNombre.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtMedicamentosPresentacion.Text) OrElse
               txtMedicamentosPresentacion.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese una presentación válida de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosPresentacion.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicamentosStock.Text.Trim(), stock) OrElse
               stock < 0D OrElse stock <> Decimal.Truncate(stock) OrElse stock > 999999D Then
                MessageBox.Show("El stock debe ser un número entero entre 0 y 999999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosStock.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicamentosPrecio.Text.Trim(), precio) OrElse
               precio < 0D OrElse precio > 99999999.99D Then
                MessageBox.Show("Ingrese un precio válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosPrecio.Focus()
                Exit Sub
            End If

            If txtMedicamentosDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosDescripcion.Focus()
                Exit Sub
            End If

            Dim coMedicamentoNuevo As New SqlCommand("Atenciones.spMedicamentosInsertarRegistro", cn)
            coMedicamentoNuevo.CommandType = CommandType.StoredProcedure

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@MedicamentosCodigo",
                                               SqlDbType.NChar, 7,
                                               ParameterDirection.Input)).Value = txtMedicamentosCodigo.Text.Trim()

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                               SqlDbType.NChar, 7,
                                               ParameterDirection.Input)).Value = txtDistribuidorasCodigo.Text.Trim()

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@MedicamentosNombre",
                                               SqlDbType.NVarChar, 100,
                                               ParameterDirection.Input)).Value = txtMedicamentosNombre.Text.Trim()

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@MedicamentosPresentacion",
                                               SqlDbType.NVarChar, 100,
                                               ParameterDirection.Input)).Value = txtMedicamentosPresentacion.Text.Trim()

            Dim parametroStock As SqlParameter = coMedicamentoNuevo.Parameters.Add("@MedicamentosStock", SqlDbType.Decimal)
            parametroStock.Precision = 6
            parametroStock.Scale = 0
            parametroStock.Value = stock

            Dim parametroPrecio As SqlParameter = coMedicamentoNuevo.Parameters.Add("@MedicamentosPrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10
            parametroPrecio.Scale = 2
            parametroPrecio.Value = precio

            coMedicamentoNuevo.Parameters.Add("@MedicamentosFechaVencimiento",
                                              SqlDbType.Date).Value = dtpMedicamentosFechaVencimiento.Value.Date

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@MedicamentosDescripcion",
                                               SqlDbType.NVarChar, 250,
                                               ParameterDirection.Input)).Value = txtMedicamentosDescripcion.Text.Trim()

            coMedicamentoNuevo.Parameters.Add(New SqlParameter("@MedicamentosEstado",
                                               SqlDbType.NChar, 1,
                                               ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coMedicamentoNuevo.ExecuteNonQuery()
                MessageBox.Show("Medicamento registrado.", "Inserción de medicamento",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el medicamento." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coMedicamentoNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtMedicamentosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Medicamentos").Rows.Count - 1
                If dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosCodigo").ToString().Trim() = codigoRegistrado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdAgregar.Text = "Agregar"
            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub MedicamentosEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Medicamentos").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtDistribuidorasCodigo.Focus()

        Else
            Dim stock As Decimal
            Dim precio As Decimal

            If txtDistribuidorasCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de distribuidora debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDistribuidorasCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtMedicamentosNombre.Text) OrElse
               txtMedicamentosNombre.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese un nombre válido de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosNombre.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtMedicamentosPresentacion.Text) OrElse
               txtMedicamentosPresentacion.Text.Trim().Length > 100 Then
                MessageBox.Show("Ingrese una presentación válida de hasta 100 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosPresentacion.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicamentosStock.Text.Trim(), stock) OrElse
               stock < 0D OrElse stock <> Decimal.Truncate(stock) OrElse stock > 999999D Then
                MessageBox.Show("El stock debe ser un número entero entre 0 y 999999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosStock.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtMedicamentosPrecio.Text.Trim(), precio) OrElse
               precio < 0D OrElse precio > 99999999.99D Then
                MessageBox.Show("Ingrese un precio válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosPrecio.Focus()
                Exit Sub
            End If

            If txtMedicamentosDescripcion.Text.Trim().Length > 250 Then
                MessageBox.Show("La descripción no puede superar 250 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMedicamentosDescripcion.Focus()
                Exit Sub
            End If

            Dim coMedicamentoEditar As New SqlCommand("Atenciones.spMedicamentosEditarRegistro", cn)
            coMedicamentoEditar.CommandType = CommandType.StoredProcedure

            coMedicamentoEditar.Parameters.Add(New SqlParameter("@MedicamentosCodigo",
                                                SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value = txtMedicamentosCodigo.Text.Trim()

            coMedicamentoEditar.Parameters.Add(New SqlParameter("@DistribuidorasCodigo",
                                                SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value = txtDistribuidorasCodigo.Text.Trim()

            coMedicamentoEditar.Parameters.Add(New SqlParameter("@MedicamentosNombre",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtMedicamentosNombre.Text.Trim()

            coMedicamentoEditar.Parameters.Add(New SqlParameter("@MedicamentosPresentacion",
                                                SqlDbType.NVarChar, 100,
                                                ParameterDirection.Input)).Value = txtMedicamentosPresentacion.Text.Trim()

            Dim parametroStock As SqlParameter = coMedicamentoEditar.Parameters.Add("@MedicamentosStock", SqlDbType.Decimal)
            parametroStock.Precision = 6
            parametroStock.Scale = 0
            parametroStock.Value = stock

            Dim parametroPrecio As SqlParameter = coMedicamentoEditar.Parameters.Add("@MedicamentosPrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10
            parametroPrecio.Scale = 2
            parametroPrecio.Value = precio

            coMedicamentoEditar.Parameters.Add("@MedicamentosFechaVencimiento",
                                               SqlDbType.Date).Value = dtpMedicamentosFechaVencimiento.Value.Date

            coMedicamentoEditar.Parameters.Add(New SqlParameter("@MedicamentosDescripcion",
                                                SqlDbType.NVarChar, 250,
                                                ParameterDirection.Input)).Value = txtMedicamentosDescripcion.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coMedicamentoEditar.ExecuteNonQuery()
                MessageBox.Show("Medicamento modificado.", "Edición de medicamento",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el medicamento." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coMedicamentoEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtMedicamentosCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("Medicamentos").Rows.Count - 1
                If dsDatos.Tables("Medicamentos").Rows(i).Item("MedicamentosCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i
                    Exit For
                End If
            Next

            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub MedicamentosEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("Medicamentos").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar el medicamento " & vbCrLf &
                           txtMedicamentosNombre.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coMedicamentoEliminar As New SqlCommand("Atenciones.spMedicamentosEliminarRegistro", cn)
            coMedicamentoEliminar.CommandType = CommandType.StoredProcedure

            coMedicamentoEliminar.Parameters.Add(New SqlParameter("@MedicamentosCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtMedicamentosCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coMedicamentoEliminar.ExecuteNonQuery()
                MessageBox.Show("Medicamento eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el medicamento." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coMedicamentoEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Medicamentos").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Medicamentos").Rows.Count > 0,
                    dsDatos.Tables("Medicamentos").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub MedicamentosCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Medicamentos").Rows.Count > 0,
                dsDatos.Tables("Medicamentos").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Medicamentos").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub MedicamentosCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub MedicamentosEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vMedicamentoRecuperado = 0

        Dim fMedicamentosEliminados As New frmMedicamentosEliminados()
        fMedicamentosEliminados.ShowDialog()
        fMedicamentosEliminados.Dispose()

        If vMedicamentoRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Medicamentos").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Medicamentos").Rows.Count > 0,
                    dsDatos.Tables("Medicamentos").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
