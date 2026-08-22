Imports System.Data
Imports System.Data.SqlClient

Public Class frmFacturas

    ' Zona de declaraciones
    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daFacturas As SqlDataAdapter
    Private vPosicion As Integer

    Private Sub FacturasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Facturas").Rows.Count > 0 Then
            vPosicion = 0
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Facturas").Rows.Count > 0,
                dsDatos.Tables("Facturas").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daFacturas = New SqlDataAdapter("Atenciones.spFacturaListaSinBorrados", cn)
        daFacturas.SelectCommand.CommandType = CommandType.StoredProcedure
        daFacturas.Fill(dsDatos, "Facturas")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos Is Nothing OrElse
           Not dsDatos.Tables.Contains("Facturas") OrElse
           dsDatos.Tables("Facturas").Rows.Count = 0 Then
            LimpiarControles()
            Exit Sub
        End If

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Facturas").Rows.Count Then
            vPosicion = 0
        End If

        Dim fila As DataRow = dsDatos.Tables("Facturas").Rows(vPosicion)

        txtFacturaCodigo.Text = fila("FacturaCodigo").ToString().Trim()
        txtPacientesCodigo.Text = fila("PacientesCodigo").ToString().Trim()
        txtEmpleadosCodigo.Text = fila("EmpleadosCodigo").ToString().Trim()

        If Not IsDBNull(fila("FacturaFecha")) Then
            dtpFacturaFecha.Value = CDate(fila("FacturaFecha"))
        End If

        txtFacturaSubTotal.Text = CDec(fila("FacturaSubtotal")).ToString("0.00")
        txtFacturaIGV.Text = CDec(fila("FacturaIGV")).ToString("0.00")
        txtFacturaTotal.Text = CDec(fila("FacturaTotal")).ToString("0.00")
    End Sub

    Private Sub LlenarLista()
        lvFacturasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Facturas").Rows.Count - 1
            Dim fila As DataRow = dsDatos.Tables("Facturas").Rows(i)
            Dim item As New ListViewItem(fila("FacturaCodigo").ToString().Trim())

            item.SubItems.Add(fila("PacientesCodigo").ToString().Trim())
            item.SubItems.Add(fila("EmpleadosCodigo").ToString().Trim())
            item.SubItems.Add(CDate(fila("FacturaFecha")).ToString("dd/MM/yyyy"))
            item.SubItems.Add(CDec(fila("FacturaSubtotal")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("FacturaIGV")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("FacturaTotal")).ToString("0.00"))
            item.SubItems.Add(fila("FacturaEstado").ToString().Trim())

            lvFacturasRegistradas.Items.Add(item)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean,
                          pPaciente As Boolean,
                          pEmpleado As Boolean,
                          pFecha As Boolean,
                          pSubtotal As Boolean,
                          pIGV As Boolean,
                          pTotal As Boolean,
                          pLista As Boolean)

        txtFacturaCodigo.Enabled = pCodigo
        txtPacientesCodigo.Enabled = pPaciente
        txtEmpleadosCodigo.Enabled = pEmpleado
        dtpFacturaFecha.Enabled = pFecha
        txtFacturaSubTotal.Enabled = pSubtotal
        txtFacturaIGV.Enabled = pIGV
        txtFacturaTotal.Enabled = pTotal
        lvFacturasRegistradas.Enabled = pLista
    End Sub

    Private Sub Botones(pAgregar As Boolean,
                        pEditar As Boolean,
                        pEliminar As Boolean,
                        pCancelar As Boolean,
                        pCerrar As Boolean,
                        pEliminados As Boolean)

        cmdAgregar.Enabled = pAgregar
        cmdEditar.Enabled = pEditar
        cmdEliminar.Enabled = pEliminar
        cmdCancelar.Enabled = pCancelar
        cmdCerrar.Enabled = pCerrar
        cmdEliminados.Enabled = pEliminados
    End Sub

    Private Sub LimpiarControles()
        txtFacturaCodigo.Clear()
        txtPacientesCodigo.Clear()
        txtEmpleadosCodigo.Clear()
        dtpFacturaFecha.Value = Date.Today
        txtFacturaSubTotal.Clear()
        txtFacturaIGV.Clear()
        txtFacturaTotal.Clear()
    End Sub

    Private Function ValidarDatos(ByRef subtotal As Decimal,
                                  ByRef igv As Decimal,
                                  ByRef total As Decimal) As Boolean

        If txtFacturaCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de la factura debe tener 7 caracteres.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFacturaCodigo.Focus()
            Return False
        End If

        If txtPacientesCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código del paciente debe tener 7 caracteres.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPacientesCodigo.Focus()
            Return False
        End If

        If txtEmpleadosCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código del empleado debe tener 7 caracteres.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmpleadosCodigo.Focus()
            Return False
        End If

        If Not Decimal.TryParse(txtFacturaSubTotal.Text.Trim(), subtotal) OrElse subtotal < 0D Then
            MessageBox.Show("Ingrese un subtotal válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFacturaSubTotal.Focus()
            Return False
        End If

        If Not Decimal.TryParse(txtFacturaIGV.Text.Trim(), igv) OrElse igv < 0D Then
            MessageBox.Show("Ingrese un IGV válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFacturaIGV.Focus()
            Return False
        End If

        If Not Decimal.TryParse(txtFacturaTotal.Text.Trim(), total) OrElse total < 0D Then
            MessageBox.Show("Ingrese un total válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFacturaTotal.Focus()
            Return False
        End If

        If Math.Round(total, 2) <> Math.Round(subtotal + igv, 2) Then
            MessageBox.Show("El total debe ser igual al subtotal más el IGV.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFacturaTotal.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub FacturasSeleccion(sender As Object, e As EventArgs) Handles lvFacturasRegistradas.SelectedIndexChanged
        If lvFacturasRegistradas.SelectedItems.Count = 0 Then Exit Sub

        Dim codigoSeleccionado As String = lvFacturasRegistradas.SelectedItems(0).Text.Trim()

        For i As Integer = 0 To dsDatos.Tables("Facturas").Rows.Count - 1
            If codigoSeleccionado = dsDatos.Tables("Facturas").Rows(i)("FacturaCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub FacturasAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            LimpiarControles()
            Controles(True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)
            txtFacturaCodigo.Focus()
            Exit Sub
        End If

        Dim subtotal As Decimal
        Dim igv As Decimal
        Dim total As Decimal

        If Not ValidarDatos(subtotal, igv, total) Then Exit Sub

        Using coFacturaNueva As New SqlCommand("Atenciones.spFacturaInsertarRegistro", cn)
            coFacturaNueva.CommandType = CommandType.StoredProcedure

            coFacturaNueva.Parameters.Add("@FacturaCodigo", SqlDbType.NChar, 7).Value = txtFacturaCodigo.Text.Trim()
            coFacturaNueva.Parameters.Add("@PacientesCodigo", SqlDbType.NChar, 7).Value = txtPacientesCodigo.Text.Trim()
            coFacturaNueva.Parameters.Add("@EmpleadosCodigo", SqlDbType.NChar, 7).Value = txtEmpleadosCodigo.Text.Trim()
            coFacturaNueva.Parameters.Add("@FacturaFecha", SqlDbType.Date).Value = dtpFacturaFecha.Value.Date

            Dim pSubtotal As SqlParameter = coFacturaNueva.Parameters.Add("@FacturaSubtotal", SqlDbType.Decimal)
            pSubtotal.Precision = 10 : pSubtotal.Scale = 2 : pSubtotal.Value = subtotal

            Dim pIGV As SqlParameter = coFacturaNueva.Parameters.Add("@FacturaIGV", SqlDbType.Decimal)
            pIGV.Precision = 10 : pIGV.Scale = 2 : pIGV.Value = igv

            Dim pTotal As SqlParameter = coFacturaNueva.Parameters.Add("@FacturaTotal", SqlDbType.Decimal)
            pTotal.Precision = 10 : pTotal.Scale = 2 : pTotal.Value = total

            coFacturaNueva.Parameters.Add("@FacturaEstado", SqlDbType.NChar, 1).Value = "A"

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coFacturaNueva.ExecuteNonQuery()
                MessageBox.Show("Factura registrada.", "Inserción de factura",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo registrar la factura." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        CreaDataSet()
        LlenarLista()
        vPosicion = Math.Max(0, dsDatos.Tables("Facturas").Rows.Count - 1)
        MostrarRegistro()

        cmdAgregar.Text = "Agregar"
        Controles(False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub FacturasEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click
        If dsDatos.Tables("Facturas").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtPacientesCodigo.Focus()
            Exit Sub
        End If

        Dim subtotal As Decimal
        Dim igv As Decimal
        Dim total As Decimal

        If Not ValidarDatos(subtotal, igv, total) Then Exit Sub

        Using coFacturaEditar As New SqlCommand("Atenciones.spFacturaEditarRegistro", cn)
            coFacturaEditar.CommandType = CommandType.StoredProcedure

            coFacturaEditar.Parameters.Add("@FacturaCodigo", SqlDbType.NChar, 7).Value = txtFacturaCodigo.Text.Trim()
            coFacturaEditar.Parameters.Add("@PacientesCodigo", SqlDbType.NChar, 7).Value = txtPacientesCodigo.Text.Trim()
            coFacturaEditar.Parameters.Add("@EmpleadosCodigo", SqlDbType.NChar, 7).Value = txtEmpleadosCodigo.Text.Trim()
            coFacturaEditar.Parameters.Add("@FacturaFecha", SqlDbType.Date).Value = dtpFacturaFecha.Value.Date

            Dim pSubtotal As SqlParameter = coFacturaEditar.Parameters.Add("@FacturaSubtotal", SqlDbType.Decimal)
            pSubtotal.Precision = 10 : pSubtotal.Scale = 2 : pSubtotal.Value = subtotal

            Dim pIGV As SqlParameter = coFacturaEditar.Parameters.Add("@FacturaIGV", SqlDbType.Decimal)
            pIGV.Precision = 10 : pIGV.Scale = 2 : pIGV.Value = igv

            Dim pTotal As SqlParameter = coFacturaEditar.Parameters.Add("@FacturaTotal", SqlDbType.Decimal)
            pTotal.Precision = 10 : pTotal.Scale = 2 : pTotal.Value = total

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coFacturaEditar.ExecuteNonQuery()
                MessageBox.Show("Factura modificada.", "Edición de factura",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la factura." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        Dim codigoActual As String = txtFacturaCodigo.Text.Trim()
        CreaDataSet()
        LlenarLista()
        PosicionarPorCodigo(codigoActual)
        MostrarRegistro()

        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub FacturasEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Facturas").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la factura " & txtFacturaCodigo.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK Then
            Exit Sub
        End If

        Using coFacturaEliminar As New SqlCommand("Atenciones.spFacturaEliminarRegistro", cn)
            coFacturaEliminar.CommandType = CommandType.StoredProcedure
            coFacturaEliminar.Parameters.Add("@FacturaCodigo", SqlDbType.NChar, 7).Value = txtFacturaCodigo.Text.Trim()

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coFacturaEliminar.ExecuteNonQuery()
                MessageBox.Show("Factura eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la factura." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        vPosicion = 0
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Facturas").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Botones(True, dsDatos.Tables("Facturas").Rows.Count > 0,
                dsDatos.Tables("Facturas").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub PosicionarPorCodigo(codigo As String)
        vPosicion = 0

        For i As Integer = 0 To dsDatos.Tables("Facturas").Rows.Count - 1
            If dsDatos.Tables("Facturas").Rows(i)("FacturaCodigo").ToString().Trim() = codigo Then
                vPosicion = i
                Exit For
            End If
        Next
    End Sub

    Private Sub FacturasCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Facturas").Rows.Count > 0,
                dsDatos.Tables("Facturas").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Facturas").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub FacturasCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FacturasEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vFacturaRecuperada = 0

        Using fFacturasEliminadas As New frmFacturasEliminados()
            fFacturasEliminadas.ShowDialog()
        End Using

        If vFacturaRecuperada = 1 Then
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            If dsDatos.Tables("Facturas").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Facturas").Rows.Count > 0,
                    dsDatos.Tables("Facturas").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class
