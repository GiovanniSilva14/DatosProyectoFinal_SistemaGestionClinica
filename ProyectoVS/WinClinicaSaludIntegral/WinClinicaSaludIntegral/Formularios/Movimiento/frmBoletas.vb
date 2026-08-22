Imports System.Data
Imports System.Data.SqlClient

Public Class frmBoletas

    ' Zona de declaraciones
    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daBoletas As SqlDataAdapter
    Private vPosicion As Integer

    Private Sub BoletasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Boletas").Rows.Count > 0 Then
            vPosicion = 0
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Boletas").Rows.Count > 0,
                dsDatos.Tables("Boletas").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daBoletas = New SqlDataAdapter("Atenciones.spBoletaListaSinBorrados", cn)
        daBoletas.SelectCommand.CommandType = CommandType.StoredProcedure
        daBoletas.Fill(dsDatos, "Boletas")
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos Is Nothing OrElse
           Not dsDatos.Tables.Contains("Boletas") OrElse
           dsDatos.Tables("Boletas").Rows.Count = 0 Then
            LimpiarControles()
            Exit Sub
        End If

        If vPosicion < 0 OrElse vPosicion >= dsDatos.Tables("Boletas").Rows.Count Then
            vPosicion = 0
        End If

        Dim fila As DataRow = dsDatos.Tables("Boletas").Rows(vPosicion)

        txtBoletaCodigo.Text = fila("BoletaCodigo").ToString().Trim()
        txtPacientesCodigo.Text = fila("PacientesCodigo").ToString().Trim()
        txtEmpleadosCodigo.Text = fila("EmpleadosCodigo").ToString().Trim()

        If Not IsDBNull(fila("BoletaFecha")) Then
            dtpBoletaFecha.Value = CDate(fila("BoletaFecha"))
        End If

        txtBoletaSubtotal.Text = CDec(fila("BoletaSubtotal")).ToString("0.00")
        txtBoletaIGV.Text = CDec(fila("BoletaIGV")).ToString("0.00")
        txtBoletaTotal.Text = CDec(fila("BoletaTotal")).ToString("0.00")
    End Sub

    Private Sub LlenarLista()
        lvBoletasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Boletas").Rows.Count - 1
            Dim fila As DataRow = dsDatos.Tables("Boletas").Rows(i)
            Dim item As New ListViewItem(fila("BoletaCodigo").ToString().Trim())

            item.SubItems.Add(fila("PacientesCodigo").ToString().Trim())
            item.SubItems.Add(fila("EmpleadosCodigo").ToString().Trim())
            item.SubItems.Add(CDate(fila("BoletaFecha")).ToString("dd/MM/yyyy"))
            item.SubItems.Add(CDec(fila("BoletaSubtotal")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("BoletaIGV")).ToString("0.00"))
            item.SubItems.Add(CDec(fila("BoletaTotal")).ToString("0.00"))
            item.SubItems.Add(fila("BoletaEstado").ToString().Trim())

            lvBoletasRegistradas.Items.Add(item)
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

        txtBoletaCodigo.Enabled = pCodigo
        txtPacientesCodigo.Enabled = pPaciente
        txtEmpleadosCodigo.Enabled = pEmpleado
        dtpBoletaFecha.Enabled = pFecha
        txtBoletaSubtotal.Enabled = pSubtotal
        txtBoletaIGV.Enabled = pIGV
        txtBoletaTotal.Enabled = pTotal
        lvBoletasRegistradas.Enabled = pLista
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
        txtBoletaCodigo.Clear()
        txtPacientesCodigo.Clear()
        txtEmpleadosCodigo.Clear()
        dtpBoletaFecha.Value = Date.Today
        txtBoletaSubtotal.Clear()
        txtBoletaIGV.Clear()
        txtBoletaTotal.Clear()
    End Sub

    Private Function ValidarDatos(ByRef subtotal As Decimal,
                                  ByRef igv As Decimal,
                                  ByRef total As Decimal) As Boolean

        If txtBoletaCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de la boleta debe tener 7 caracteres.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoletaCodigo.Focus()
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

        If Not Decimal.TryParse(txtBoletaSubtotal.Text.Trim(), subtotal) OrElse subtotal < 0D Then
            MessageBox.Show("Ingrese un subtotal válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoletaSubtotal.Focus()
            Return False
        End If

        If Not Decimal.TryParse(txtBoletaIGV.Text.Trim(), igv) OrElse igv < 0D Then
            MessageBox.Show("Ingrese un IGV válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoletaIGV.Focus()
            Return False
        End If

        If Not Decimal.TryParse(txtBoletaTotal.Text.Trim(), total) OrElse total < 0D Then
            MessageBox.Show("Ingrese un total válido mayor o igual que cero.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoletaTotal.Focus()
            Return False
        End If

        If Math.Round(total, 2) <> Math.Round(subtotal + igv, 2) Then
            MessageBox.Show("El total debe ser igual al subtotal más el IGV.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBoletaTotal.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub BoletasSeleccion(sender As Object, e As EventArgs) Handles lvBoletasRegistradas.SelectedIndexChanged
        If lvBoletasRegistradas.SelectedItems.Count = 0 Then Exit Sub

        Dim codigoSeleccionado As String = lvBoletasRegistradas.SelectedItems(0).Text.Trim()

        For i As Integer = 0 To dsDatos.Tables("Boletas").Rows.Count - 1
            If codigoSeleccionado = dsDatos.Tables("Boletas").Rows(i)("BoletaCodigo").ToString().Trim() Then
                vPosicion = i
                Exit For
            End If
        Next

        MostrarRegistro()
    End Sub

    Private Sub BoletasAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            LimpiarControles()
            Controles(True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)
            txtBoletaCodigo.Focus()
            Exit Sub
        End If

        Dim subtotal As Decimal
        Dim igv As Decimal
        Dim total As Decimal

        If Not ValidarDatos(subtotal, igv, total) Then Exit Sub

        Using coBoletaNueva As New SqlCommand("Atenciones.spBoletaInsertarRegistro", cn)
            coBoletaNueva.CommandType = CommandType.StoredProcedure

            coBoletaNueva.Parameters.Add("@BoletaCodigo", SqlDbType.NChar, 7).Value = txtBoletaCodigo.Text.Trim()
            coBoletaNueva.Parameters.Add("@PacientesCodigo", SqlDbType.NChar, 7).Value = txtPacientesCodigo.Text.Trim()
            coBoletaNueva.Parameters.Add("@EmpleadosCodigo", SqlDbType.NChar, 7).Value = txtEmpleadosCodigo.Text.Trim()
            coBoletaNueva.Parameters.Add("@BoletaFecha", SqlDbType.Date).Value = dtpBoletaFecha.Value.Date

            Dim pSubtotal As SqlParameter = coBoletaNueva.Parameters.Add("@BoletaSubtotal", SqlDbType.Decimal)
            pSubtotal.Precision = 10 : pSubtotal.Scale = 2 : pSubtotal.Value = subtotal

            Dim pIGV As SqlParameter = coBoletaNueva.Parameters.Add("@BoletaIGV", SqlDbType.Decimal)
            pIGV.Precision = 10 : pIGV.Scale = 2 : pIGV.Value = igv

            Dim pTotal As SqlParameter = coBoletaNueva.Parameters.Add("@BoletaTotal", SqlDbType.Decimal)
            pTotal.Precision = 10 : pTotal.Scale = 2 : pTotal.Value = total

            coBoletaNueva.Parameters.Add("@BoletaEstado", SqlDbType.NChar, 1).Value = "A"

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coBoletaNueva.ExecuteNonQuery()
                MessageBox.Show("Boleta registrada.", "Inserción de boleta",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo registrar la boleta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        CreaDataSet()
        LlenarLista()
        vPosicion = Math.Max(0, dsDatos.Tables("Boletas").Rows.Count - 1)
        MostrarRegistro()

        cmdAgregar.Text = "Agregar"
        Controles(False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub BoletasEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click
        If dsDatos.Tables("Boletas").Rows.Count = 0 Then Exit Sub

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

        Using coBoletaEditar As New SqlCommand("Atenciones.spBoletaEditarRegistro", cn)
            coBoletaEditar.CommandType = CommandType.StoredProcedure

            coBoletaEditar.Parameters.Add("@BoletaCodigo", SqlDbType.NChar, 7).Value = txtBoletaCodigo.Text.Trim()
            coBoletaEditar.Parameters.Add("@PacientesCodigo", SqlDbType.NChar, 7).Value = txtPacientesCodigo.Text.Trim()
            coBoletaEditar.Parameters.Add("@EmpleadosCodigo", SqlDbType.NChar, 7).Value = txtEmpleadosCodigo.Text.Trim()
            coBoletaEditar.Parameters.Add("@BoletaFecha", SqlDbType.Date).Value = dtpBoletaFecha.Value.Date

            Dim pSubtotal As SqlParameter = coBoletaEditar.Parameters.Add("@BoletaSubtotal", SqlDbType.Decimal)
            pSubtotal.Precision = 10 : pSubtotal.Scale = 2 : pSubtotal.Value = subtotal

            Dim pIGV As SqlParameter = coBoletaEditar.Parameters.Add("@BoletaIGV", SqlDbType.Decimal)
            pIGV.Precision = 10 : pIGV.Scale = 2 : pIGV.Value = igv

            Dim pTotal As SqlParameter = coBoletaEditar.Parameters.Add("@BoletaTotal", SqlDbType.Decimal)
            pTotal.Precision = 10 : pTotal.Scale = 2 : pTotal.Value = total

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coBoletaEditar.ExecuteNonQuery()
                MessageBox.Show("Boleta modificada.", "Edición de boleta",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo modificar la boleta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        Dim codigoActual As String = txtBoletaCodigo.Text.Trim()
        CreaDataSet()
        LlenarLista()
        PosicionarPorCodigo(codigoActual)
        MostrarRegistro()

        cmdEditar.Text = "Editar"
        Controles(False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub BoletasEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Boletas").Rows.Count = 0 Then Exit Sub

        If MessageBox.Show("¿Desea eliminar la boleta " & txtBoletaCodigo.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK Then
            Exit Sub
        End If

        Using coBoletaEliminar As New SqlCommand("Atenciones.spBoletaEliminarRegistro", cn)
            coBoletaEliminar.CommandType = CommandType.StoredProcedure
            coBoletaEliminar.Parameters.Add("@BoletaCodigo", SqlDbType.NChar, 7).Value = txtBoletaCodigo.Text.Trim()

            Try
                If cn.State <> ConnectionState.Closed Then cn.Close()
                cn.Open()
                coBoletaEliminar.ExecuteNonQuery()
                MessageBox.Show("Boleta eliminada.", "Eliminación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                MessageBox.Show("No se pudo eliminar la boleta." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
            End Try
        End Using

        vPosicion = 0
        CreaDataSet()
        LlenarLista()

        If dsDatos.Tables("Boletas").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Botones(True, dsDatos.Tables("Boletas").Rows.Count > 0,
                dsDatos.Tables("Boletas").Rows.Count > 0, False, True, True)
    End Sub

    Private Sub PosicionarPorCodigo(codigo As String)
        vPosicion = 0

        For i As Integer = 0 To dsDatos.Tables("Boletas").Rows.Count - 1
            If dsDatos.Tables("Boletas").Rows(i)("BoletaCodigo").ToString().Trim() = codigo Then
                vPosicion = i
                Exit For
            End If
        Next
    End Sub

    Private Sub BoletasCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, True)
        Botones(True, dsDatos.Tables("Boletas").Rows.Count > 0,
                dsDatos.Tables("Boletas").Rows.Count > 0, False, True, True)

        If dsDatos.Tables("Boletas").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarControles()
        End If
    End Sub

    Private Sub BoletasCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub BoletasEliminadas(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vBoletaRecuperada = 0

        Using fBoletasEliminadas As New frmBoletasEliminados()
            fBoletasEliminadas.ShowDialog()
        End Using

        If vBoletaRecuperada = 1 Then
            CreaDataSet()
            LlenarLista()
            vPosicion = 0

            If dsDatos.Tables("Boletas").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarControles()
            End If

            Botones(True, dsDatos.Tables("Boletas").Rows.Count > 0,
                    dsDatos.Tables("Boletas").Rows.Count > 0, False, True, True)
        End If
    End Sub

End Class

