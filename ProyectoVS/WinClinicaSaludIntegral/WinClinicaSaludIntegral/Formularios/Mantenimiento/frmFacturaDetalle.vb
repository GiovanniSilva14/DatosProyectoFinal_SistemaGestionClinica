Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturaDetalle

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daFacturaDetalle As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub FacturaDetalleCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("FacturaDetalle").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("FacturaDetalle").Rows.Count > 0,
                dsDatos.Tables("FacturaDetalle").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daFacturaDetalle = New SqlDataAdapter("Atenciones.spFacturaDetalleListaSinBorrados", cn)
        daFacturaDetalle.SelectCommand.CommandType = CommandType.StoredProcedure
        daFacturaDetalle.Fill(dsDatos, "FacturaDetalle")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("FacturaDetalle").Rows.Count = 0 Then Exit Sub

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("FacturaDetalle").Rows.Count Then
            vPosicion = 0
        End If

        txtFacturaDetalleCodigo.Text = dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaDetalleCodigo").ToString().Trim()
        txtFacturaCodigo.Text = dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaCodigo").ToString().Trim()
        txtFacturaDetalleConcepto.Text = dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaDetalleConcepto").ToString().Trim()
        txtFacturaDetalleCantidad.Text = CDec(dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaDetalleCantidad")).ToString("0")
        txtFacturaDetallePrecio.Text = CDec(dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaDetallePrecio")).ToString("0.00")
        txtFacturaDetalleImporte.Text = CDec(dsDatos.Tables("FacturaDetalle").Rows(vPosicion).Item("FacturaDetalleImporte")).ToString("0.00")
    End Sub

    Private Sub LlenarLista()
        lvFacturaDetalleRegistrados.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("FacturaDetalle").Rows.Count - 1
            lvFacturaDetalleRegistrados.Items.Add(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleCodigo").ToString().Trim())
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaCodigo").ToString().Trim())
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleConcepto").ToString().Trim())
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleCantidad")).ToString("0"))
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetallePrecio")).ToString("0.00"))
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(CDec(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleImporte")).ToString("0.00"))
            lvFacturaDetalleRegistrados.Items(i).SubItems.Add(dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleEstado").ToString().Trim())
        Next
    End Sub

    Private Sub Controles(pDetalleCodigo As Boolean, pFacturaCodigo As Boolean,
                          pConcepto As Boolean, pCantidad As Boolean,
                          pPrecio As Boolean, pImporte As Boolean,
                          pLista As Boolean)
        txtFacturaDetalleCodigo.Enabled = pDetalleCodigo
        txtFacturaCodigo.Enabled = pFacturaCodigo
        txtFacturaDetalleConcepto.Enabled = pConcepto
        txtFacturaDetalleCantidad.Enabled = pCantidad
        txtFacturaDetallePrecio.Enabled = pPrecio
        txtFacturaDetalleImporte.Enabled = pImporte
        lvFacturaDetalleRegistrados.Enabled = pLista
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
        txtFacturaDetalleCodigo.Clear()
        txtFacturaCodigo.Clear()
        txtFacturaDetalleConcepto.Clear()
        txtFacturaDetalleCantidad.Clear()
        txtFacturaDetallePrecio.Clear()
        txtFacturaDetalleImporte.Clear()
    End Sub

    Private Sub FacturaDetalleSeleccion(sender As Object, e As EventArgs) Handles lvFacturaDetalleRegistrados.SelectedIndexChanged
        If lvFacturaDetalleRegistrados.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = 0 To dsDatos.Tables("FacturaDetalle").Rows.Count - 1
            If lvFacturaDetalleRegistrados.SelectedItems(0).Text.Trim() =
               dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub FacturaDetalleAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            Controles(True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            LimpiarControles()
            txtFacturaDetalleCodigo.Focus()

        Else
            Dim cantidad As Decimal
            Dim precio As Decimal
            Dim importe As Decimal

            If txtFacturaDetalleCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código del detalle debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleCodigo.Focus()
                Exit Sub
            End If

            If txtFacturaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de factura debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtFacturaDetalleConcepto.Text) OrElse
               txtFacturaDetalleConcepto.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese un concepto válido de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleConcepto.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetalleCantidad.Text.Trim(), cantidad) OrElse
               cantidad <= 0D OrElse cantidad <> Decimal.Truncate(cantidad) OrElse cantidad > 99999D Then
                MessageBox.Show("La cantidad debe ser un entero entre 1 y 99999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleCantidad.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetallePrecio.Text.Trim(), precio) OrElse
               precio < 0D OrElse precio > 99999999.99D Then
                MessageBox.Show("Ingrese un precio válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetallePrecio.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetalleImporte.Text.Trim(), importe) OrElse
               importe < 0D OrElse importe > 99999999.99D Then
                MessageBox.Show("Ingrese un importe válido mayor o igual que cero.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleImporte.Focus()
                Exit Sub
            End If

            If Math.Round(importe, 2) <> Math.Round(cantidad * precio, 2) Then
                MessageBox.Show("El importe debe ser igual a la cantidad multiplicada por el precio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleImporte.Focus()
                Exit Sub
            End If

            Dim coFacturaDetalleNuevo As New SqlCommand("Atenciones.spFacturaDetalleInsertarRegistro", cn)
            coFacturaDetalleNuevo.CommandType = CommandType.StoredProcedure

            coFacturaDetalleNuevo.Parameters.Add(New SqlParameter("@FacturaDetalleCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtFacturaDetalleCodigo.Text.Trim()
            coFacturaDetalleNuevo.Parameters.Add(New SqlParameter("@FacturaCodigo",
                                                  SqlDbType.NChar, 7,
                                                  ParameterDirection.Input)).Value = txtFacturaCodigo.Text.Trim()
            coFacturaDetalleNuevo.Parameters.Add(New SqlParameter("@FacturaDetalleConcepto",
                                                  SqlDbType.NVarChar, 150,
                                                  ParameterDirection.Input)).Value = txtFacturaDetalleConcepto.Text.Trim()

            Dim parametroCantidad As SqlParameter = coFacturaDetalleNuevo.Parameters.Add("@FacturaDetalleCantidad", SqlDbType.Decimal)
            parametroCantidad.Precision = 5
            parametroCantidad.Scale = 0
            parametroCantidad.Value = cantidad

            Dim parametroPrecio As SqlParameter = coFacturaDetalleNuevo.Parameters.Add("@FacturaDetallePrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10
            parametroPrecio.Scale = 2
            parametroPrecio.Value = precio

            Dim parametroImporte As SqlParameter = coFacturaDetalleNuevo.Parameters.Add("@FacturaDetalleImporte", SqlDbType.Decimal)
            parametroImporte.Precision = 10
            parametroImporte.Scale = 2
            parametroImporte.Value = importe

            coFacturaDetalleNuevo.Parameters.Add(New SqlParameter("@FacturaDetalleEstado",
                                                  SqlDbType.NChar, 1,
                                                  ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then cn.Close()

            Try
                cn.Open()
                coFacturaDetalleNuevo.ExecuteNonQuery()
                MessageBox.Show("Detalle de factura registrado.", "Inserción",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo insertar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coFacturaDetalleNuevo.Dispose()
            End Try

            Dim codigoRegistrado As String = txtFacturaDetalleCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            For i As Integer = 0 To dsDatos.Tables("FacturaDetalle").Rows.Count - 1
                If dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleCodigo").ToString().Trim() = codigoRegistrado Then
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

    Private Sub FacturaDetalleEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("FacturaDetalle").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtFacturaCodigo.Focus()

        Else
            Dim cantidad As Decimal
            Dim precio As Decimal
            Dim importe As Decimal

            If txtFacturaCodigo.Text.Trim().Length <> 7 Then
                MessageBox.Show("El código de factura debe tener 7 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaCodigo.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtFacturaDetalleConcepto.Text) OrElse
               txtFacturaDetalleConcepto.Text.Trim().Length > 150 Then
                MessageBox.Show("Ingrese un concepto válido de hasta 150 caracteres.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleConcepto.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetalleCantidad.Text.Trim(), cantidad) OrElse
               cantidad <= 0D OrElse cantidad <> Decimal.Truncate(cantidad) OrElse cantidad > 99999D Then
                MessageBox.Show("La cantidad debe ser un entero entre 1 y 99999.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleCantidad.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetallePrecio.Text.Trim(), precio) OrElse precio < 0D Then
                MessageBox.Show("Ingrese un precio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetallePrecio.Focus()
                Exit Sub
            End If

            If Not Decimal.TryParse(txtFacturaDetalleImporte.Text.Trim(), importe) OrElse importe < 0D Then
                MessageBox.Show("Ingrese un importe válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleImporte.Focus()
                Exit Sub
            End If

            If Math.Round(importe, 2) <> Math.Round(cantidad * precio, 2) Then
                MessageBox.Show("El importe debe ser igual a la cantidad multiplicada por el precio.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtFacturaDetalleImporte.Focus()
                Exit Sub
            End If

            Dim coFacturaDetalleEditar As New SqlCommand("Atenciones.spFacturaDetalleEditarRegistro", cn)
            coFacturaDetalleEditar.CommandType = CommandType.StoredProcedure

            coFacturaDetalleEditar.Parameters.Add(New SqlParameter("@FacturaDetalleCodigo", SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtFacturaDetalleCodigo.Text.Trim()
            coFacturaDetalleEditar.Parameters.Add(New SqlParameter("@FacturaCodigo", SqlDbType.NChar, 7,
                                                   ParameterDirection.Input)).Value = txtFacturaCodigo.Text.Trim()
            coFacturaDetalleEditar.Parameters.Add(New SqlParameter("@FacturaDetalleConcepto", SqlDbType.NVarChar, 150,
                                                   ParameterDirection.Input)).Value = txtFacturaDetalleConcepto.Text.Trim()

            Dim parametroCantidad As SqlParameter = coFacturaDetalleEditar.Parameters.Add("@FacturaDetalleCantidad", SqlDbType.Decimal)
            parametroCantidad.Precision = 5 : parametroCantidad.Scale = 0 : parametroCantidad.Value = cantidad
            Dim parametroPrecio As SqlParameter = coFacturaDetalleEditar.Parameters.Add("@FacturaDetallePrecio", SqlDbType.Decimal)
            parametroPrecio.Precision = 10 : parametroPrecio.Scale = 2 : parametroPrecio.Value = precio
            Dim parametroImporte As SqlParameter = coFacturaDetalleEditar.Parameters.Add("@FacturaDetalleImporte", SqlDbType.Decimal)
            parametroImporte.Precision = 10 : parametroImporte.Scale = 2 : parametroImporte.Value = importe

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coFacturaDetalleEditar.ExecuteNonQuery()
                MessageBox.Show("Detalle de factura modificado.", "Edición",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coFacturaDetalleEditar.Dispose()
            End Try

            Dim codigoEditado As String = txtFacturaDetalleCodigo.Text.Trim()
            CreaDataSet()
            LlenarLista()
            vPosicion = 0
            For i As Integer = 0 To dsDatos.Tables("FacturaDetalle").Rows.Count - 1
                If dsDatos.Tables("FacturaDetalle").Rows(i).Item("FacturaDetalleCodigo").ToString().Trim() = codigoEditado Then
                    vPosicion = i : Exit For
                End If
            Next
            MostrarRegistro()
            cmdEditar.Text = "Editar"
            Controles(False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)
        End If
    End Sub

    Private Sub FacturaDetalleEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("FacturaDetalle").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar el detalle " & txtFacturaDetalleCodigo.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coFacturaDetalleEliminar As New SqlCommand("Atenciones.spFacturaDetalleEliminarRegistro", cn)
            coFacturaDetalleEliminar.CommandType = CommandType.StoredProcedure
            coFacturaDetalleEliminar.Parameters.Add(New SqlParameter("@FacturaDetalleCodigo", SqlDbType.NChar, 7,
                                                    ParameterDirection.Input)).Value = txtFacturaDetalleCodigo.Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coFacturaDetalleEliminar.ExecuteNonQuery()
                MessageBox.Show("Detalle de factura eliminado.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar el detalle." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coFacturaDetalleEliminar.Dispose()
            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("FacturaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("FacturaDetalle").Rows.Count > 0,
                    dsDatos.Tables("FacturaDetalle").Rows.Count > 0, False, True, True)
        End If
    End Sub

    Private Sub FacturaDetalleCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("FacturaDetalle").Rows.Count > 0,
                dsDatos.Tables("FacturaDetalle").Rows.Count > 0, False, True, True)
        If dsDatos.Tables("FacturaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
    End Sub

    Private Sub FacturaDetalleCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FacturaDetalleEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vFacturaDetalleRecuperado = 0
        Dim formulario As New frmFacturaDetalleEliminados()
        formulario.ShowDialog()
        formulario.Dispose()

        If vFacturaDetalleRecuperado = 1 Then
            vPosicion = 0
            CreaDataSet()
            LlenarLista()
            If dsDatos.Tables("FacturaDetalle").Rows.Count > 0 Then MostrarRegistro() Else LimpiarControles()
            Botones(True, dsDatos.Tables("FacturaDetalle").Rows.Count > 0,
                    dsDatos.Tables("FacturaDetalle").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
