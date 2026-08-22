Imports System.Data
Imports System.Data.SqlClient

Public Class frmBoletaDetalle

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daBoletaDetalle As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub BoletaDetalleCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("BoletaDetalle").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("BoletaDetalle").Rows.Count > 0,
                dsDatos.Tables("BoletaDetalle").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daBoletaDetalle = New SqlDataAdapter("Atenciones.spBoletaDetalleListaSinBorrados", cn)
        daBoletaDetalle.SelectCommand.CommandType = CommandType.StoredProcedure
        daBoletaDetalle.Fill(dsDatos, "BoletaDetalle")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("BoletaDetalle").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("BoletaDetalle").Rows.Count Then
            vPosicion = 0
        End If

        txtBoletaDetalleCodigo.Text = dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaDetalleCodigo").ToString().Trim()
        txtBoletaCodigo.Text = dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaCodigo").ToString().Trim()
        txtBoletaDetalleConcepto.Text = dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaDetalleConcepto").ToString().Trim()
        txtBoletaDetalleCantidad.Text = CDec(dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaDetalleCantidad")).ToString("0")
        txtBoletaDetallePrecio.Text = CDec(dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaDetallePrecio")).ToString("0.00")
        txtBoletaDetalleImporte.Text = CDec(dsDatos.Tables("BoletaDetalle").Rows(vPosicion).Item("BoletaDetalleImporte")).ToString("0.00")
    End Sub

    Private Sub LlenarLista()
        lvBoletaDetalleRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("BoletaDetalle").Rows.Count - 1
            lvBoletaDetalleRegistrados.Items.Add(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleCodigo").ToString().Trim())
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaCodigo").ToString().Trim())
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleConcepto").ToString().Trim())
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleCantidad")).ToString("0"))
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetallePrecio")).ToString("0.00"))
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleImporte")).ToString("0.00"))
            lvBoletaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pDetalleCodigo As Boolean, pBoletaCodigo As Boolean,
                          pConcepto As Boolean, pCantidad As Boolean,
                          pPrecio As Boolean, pImporte As Boolean,
                          pLista As Boolean)
        txtBoletaDetalleCodigo.Enabled = pDetalleCodigo
        txtBoletaCodigo.Enabled = pBoletaCodigo
        txtBoletaDetalleConcepto.Enabled = pConcepto
        txtBoletaDetalleCantidad.Enabled = pCantidad
        txtBoletaDetallePrecio.Enabled = pPrecio
        txtBoletaDetalleImporte.Enabled = pImporte
        lvBoletaDetalleRegistrados.Enabled = pLista
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
        txtBoletaDetalleCodigo.Clear()
        txtBoletaCodigo.Clear()
        txtBoletaDetalleConcepto.Clear()
        txtBoletaDetalleCantidad.Clear()
        txtBoletaDetallePrecio.Clear()
        txtBoletaDetalleImporte.Clear()
    End Sub

    Private Sub BoletaDetalleSeleccion(sender As Object, e As EventArgs) Handles lvBoletaDetalleRegistrados.SelectedIndexChanged
        If lvBoletaDetalleRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("BoletaDetalle").Rows.Count - 1
            If lvBoletaDetalleRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub BoletaDetalleAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtBoletaDetalleCodigo.Focus()

        Else
            Dim cantidad As Decimal
            Dim precio As Decimal
            Dim importe As Decimal

            If txtBoletaDetalleCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código del detalle debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleCodigo.Focus()
                Exit Sub
            End If

            If txtBoletaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de boleta debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtBoletaDetalleConcepto.Text) OrElse
               txtBoletaDetalleConcepto.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese un concepto válido de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleConcepto.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetalleCantidad.Text.Trim(), cantidad) OrElse
               cantidad <= 0D OrElse cantidad <> Decimal.Truncate(cantidad) OrElse cantidad > 99999D Then
                MessageBox.Show("La cantidad debe ser un entero entre 1 y 99999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleCantidad.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetallePrecio.Text.Trim(), precio) OrElse
               precio < 0D OrElse precio > 99999999.99D Then
                MessageBox.Show("Ingrese un precio válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetallePrecio.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetalleImporte.Text.Trim(), importe) OrElse
               importe < 0D OrElse importe > 99999999.99D Then
                MessageBox.Show("Ingrese un importe válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleImporte.Focus()
                Exit Sub
            End If

            If Math.Round(importe, 2) <> Math.Round(cantidad * precio, 2) Then
                MessageBox.Show("El importe debe ser igual a la cantidad multiplicada por el precio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleImporte.Focus()
                Exit Sub
            End If

            Dim coBoletaDetalleNuevo As New SqlCommand("Atenciones.spBoletaDetalleInsertarRegistro", cn)
            coBoletaDetalleNuevo.CommandType = CommandType.StoredProcedure

            coBoletaDetalleNuevo.Parameters.Add(New SqlParameter("@BoletaDetalleCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtBoletaDetalleCodigo.Text.Trim()
            coBoletaDetalleNuevo.Parameters.Add(New SqlParameter("@BoletaCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtBoletaCodigo.Text.Trim()
            coBoletaDetalleNuevo.Parameters.Add(New SqlParameter("@BoletaDetalleConcepto",
                                                  SqlDbType.NVarChar, 150,
                                                  ParameterDirection.Input)).Value = txtBoletaDetalleConcepto.Text.Trim()

            Dim parametroCantidad As SqlParameter = coBoletaDetalleNuevo.Parameters.Add("@BoletaDetalleCantidad", SqlDbType.Decimal)
            parametroCantidad.Precision = 5
            parametroCantidad.Scale = 0
            parametroCantidad.Value = cantidad

            Dim parametroPrecio As SqlParameter = coBoletaDetalleNuevo.Parameters.Add("@BoletaDetallePrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10
            parametroPrecio.Scale = 2
            parametroPrecio.Value = precio

            Dim parametroImporte As SqlParameter = coBoletaDetalleNuevo.Parameters.Add("@BoletaDetalleImporte", SqlDbType.Decimal)
            parametroImporte.Precision = 10
            parametroImporte.Scale = 2
            parametroImporte.Value = importe

            coBoletaDetalleNuevo.Parameters.Add(New SqlParameter("@BoletaDetalleEstado",
                                                  SqlDbType.NChar, 1,
                                                  ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coBoletaDetalleNuevo.ExecuteNonQuery()
                MessageBox.Show("Detalle de boleta registrado.", "Inserción",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coBoletaDetalleNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtBoletaDetalleCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("BoletaDetalle").Rows.Count - 1
                If dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleCodigo").ToString().Trim() = codigoRegistrado Then
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

    Private Sub BoletaDetalleEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("BoletaDetalle").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtBoletaCodigo.Focus()

        Else
            Dim cantidad As Decimal
            Dim precio As Decimal
            Dim importe As Decimal

            If txtBoletaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de boleta debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtBoletaDetalleConcepto.Text) OrElse
               txtBoletaDetalleConcepto.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese un concepto válido de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleConcepto.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetalleCantidad.Text.Trim(), cantidad) OrElse
               cantidad <= 0D OrElse cantidad <> Decimal.Truncate(cantidad) OrElse cantidad > 99999D Then
                MessageBox.Show("La cantidad debe ser un entero entre 1 y 99999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleCantidad.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetallePrecio.Text.Trim(), precio) OrElse precio < 0D Then
                MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetallePrecio.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtBoletaDetalleImporte.Text.Trim(), importe) OrElse importe < 0D Then
                MessageBox.Show("Ingrese un importe válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleImporte.Focus()
                Exit Sub
            End If

            If Math.Round(importe, 2) <> Math.Round(cantidad * precio, 2) Then
                MessageBox.Show("El importe debe ser igual a la cantidad multiplicada por el precio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBoletaDetalleImporte.Focus()
                Exit Sub
            End If

            Dim coBoletaDetalleEditar As New SqlCommand("Atenciones.spBoletaDetalleEditarRegistro", cn)
            coBoletaDetalleEditar.CommandType = CommandType.StoredProcedure

            coBoletaDetalleEditar.Parameters.Add(New SqlParameter("@BoletaDetalleCodigo", SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtBoletaDetalleCodigo.Text.Trim()
            coBoletaDetalleEditar.Parameters.Add(New SqlParameter("@BoletaCodigo", SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtBoletaCodigo.Text.Trim()
            coBoletaDetalleEditar.Parameters.Add(New SqlParameter("@BoletaDetalleConcepto", SqlDbType.NVarChar, 150,
                                                   ParameterDirection.Input)).Value = txtBoletaDetalleConcepto.Text.Trim()

            Dim parametroCantidad As SqlParameter = coBoletaDetalleEditar.Parameters.Add("@BoletaDetalleCantidad", SqlDbType.Decimal)
            parametroCantidad.Precision = 5 : parametroCantidad.Scale = 0 : parametroCantidad.Value = cantidad
            Dim parametroPrecio As SqlParameter = coBoletaDetalleEditar.Parameters.Add("@BoletaDetallePrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10 : parametroPrecio.Scale = 2 : parametroPrecio.Value = precio
            Dim parametroImporte As SqlParameter = coBoletaDetalleEditar.Parameters.Add("@BoletaDetalleImporte", SqlDbType.Decimal)
            parametroImporte.Precision = 10 : parametroImporte.Scale = 2 : parametroImporte.Value = importe

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coBoletaDetalleEditar.ExecuteNonQuery()
                MessageBox.Show("Detalle de boleta modificado.", "Edición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coBoletaDetalleEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtBoletaDetalleCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0
            For i As Integer = 0 To dsDatos.Tables("BoletaDetalle").Rows.Count - 1
                If dsDatos.Tables("BoletaDetalle").Rows(i).Item("BoletaDetalleCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i : Exit For
                End If
            Next
            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub BoletaDetalleEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("BoletaDetalle").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar el detalle " & txtBoletaDetalleCodigo.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coBoletaDetalleEliminar As New SqlCommand("Atenciones.spBoletaDetalleEliminarRegistro", cn)
            coBoletaDetalleEliminar.CommandType = CommandType.StoredProcedure
            coBoletaDetalleEliminar.Parameters.Add(New SqlParameter("@BoletaDetalleCodigo", SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtBoletaDetalleCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coBoletaDetalleEliminar.ExecuteNonQuery()
                MessageBox.Show("Detalle de boleta eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coBoletaDetalleEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("BoletaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("BoletaDetalle").Rows.Count > 0,
                    dsDatos.Tables("BoletaDetalle").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub BoletaDetalleCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("BoletaDetalle").Rows.Count > 0,
                dsDatos.Tables("BoletaDetalle").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("BoletaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub BoletaDetalleCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub BoletaDetalleEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vBoletaDetalleRecuperado = 0
        Dim formulario As New frmBoletaDetalleEliminados()
        formulario.ShowDialog()
        formulario.Dispose()

        If vBoletaDetalleRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("BoletaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("BoletaDetalle").Rows.Count > 0,
                    dsDatos.Tables("BoletaDetalle").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
