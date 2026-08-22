Imports System.Data
Imports System.Data.SqlClient

Public Class frmFarmacia

    Private cn As SqlConnection
    Private dsDatos As DataSet
    Private daFarmacia As SqlDataAdapter
    Private vPosicion As Integer

    Private Sub FarmaciaCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        ActualizarFormulario()
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daFarmacia = New SqlDataAdapter("Atenciones.spFarmaciaListaSinBorrados", cn)
        daFarmacia.SelectCommand.CommandType = CommandType.StoredProcedure
        daFarmacia.Fill(dsDatos, "Farmacia")
    End Sub

    Private Sub ActualizarFormulario()
        Dim hayRegistros As Boolean = dsDatos.Tables("Farmacia").Rows.Count > 0

        If hayRegistros Then
            If vPosicion >= dsDatos.Tables("Farmacia").Rows.Count Then vPosicion = 0
            MostrarRegistro()
        Else
            LimpiarControles()
        End If

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, hayRegistros, hayRegistros, False, True, True)
    End Sub

    Private Sub MostrarRegistro()
        If dsDatos.Tables("Farmacia").Rows.Count = 0 Then Exit Sub

        Dim fila As DataRow = dsDatos.Tables("Farmacia").Rows(vPosicion)
        txtFarmaciaCodigo.Text = fila("FarmaciaCodigo").ToString().Trim()
        txtRecetaCodigo.Text = fila("RecetaCodigo").ToString().Trim()
        txtMedicamentosCodigo.Text = fila("MedicamentosCodigo").ToString().Trim()
        txtFarmaciaCantidad.Text = CDec(fila("FarmaciaCantidad")).ToString("0")
        txtFarmaciaDosis.Text = fila("FarmaciaDosis").ToString().Trim()
        txtFarmaciaFrecuencia.Text = fila("FarmaciaFrecuencia").ToString().Trim()
        txtFarmaciaDuracion.Text = fila("FarmaciaDuracion").ToString().Trim()
        txtFarmaciaObservaciones.Text = fila("FarmaciaObservaciones").ToString().Trim()
    End Sub

    Private Sub LlenarLista()
        lvFarmaciaRegistrada.Items.Clear()

        For Each fila As DataRow In dsDatos.Tables("Farmacia").Rows
            Dim item As New ListViewItem(fila("FarmaciaCodigo").ToString().Trim())
            item.SubItems.Add(fila("RecetaCodigo").ToString().Trim())
            item.SubItems.Add(fila("MedicamentosCodigo").ToString().Trim())
            item.SubItems.Add(CDec(fila("FarmaciaCantidad")).ToString("0"))
            item.SubItems.Add(fila("FarmaciaDosis").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaFrecuencia").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaDuracion").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaObservaciones").ToString().Trim())
            item.SubItems.Add(fila("FarmaciaEstado").ToString().Trim())
            lvFarmaciaRegistrada.Items.Add(item)
        Next
    End Sub

    Private Sub Controles(pCodigo As Boolean, pReceta As Boolean,
                          pMedicamento As Boolean, pCantidad As Boolean,
                          pDosis As Boolean, pFrecuencia As Boolean,
                          pDuracion As Boolean, pObservaciones As Boolean,
                          pLista As Boolean)
        txtFarmaciaCodigo.Enabled = pCodigo
        txtRecetaCodigo.Enabled = pReceta
        txtMedicamentosCodigo.Enabled = pMedicamento
        txtFarmaciaCantidad.Enabled = pCantidad
        txtFarmaciaDosis.Enabled = pDosis
        txtFarmaciaFrecuencia.Enabled = pFrecuencia
        txtFarmaciaDuracion.Enabled = pDuracion
        txtFarmaciaObservaciones.Enabled = pObservaciones
        lvFarmaciaRegistrada.Enabled = pLista
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
        txtFarmaciaCodigo.Clear()
        txtRecetaCodigo.Clear()
        txtMedicamentosCodigo.Clear()
        txtFarmaciaCantidad.Clear()
        txtFarmaciaDosis.Clear()
        txtFarmaciaFrecuencia.Clear()
        txtFarmaciaDuracion.Clear()
        txtFarmaciaObservaciones.Clear()
    End Sub

    Private Function ValidarDatos(ByRef cantidad As Decimal) As Boolean
        If txtFarmaciaCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de farmacia debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaCodigo.Focus() : Return False
        End If
        If txtRecetaCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de receta debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRecetaCodigo.Focus() : Return False
        End If
        If txtMedicamentosCodigo.Text.Trim().Length <> 7 Then
            MessageBox.Show("El código de medicamento debe tener 7 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtMedicamentosCodigo.Focus() : Return False
        End If
        If Not Decimal.TryParse(txtFarmaciaCantidad.Text.Trim(), cantidad) OrElse
           cantidad <= 0D OrElse cantidad <> Decimal.Truncate(cantidad) Then
            MessageBox.Show("La cantidad debe ser un número entero mayor que cero.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaCantidad.Focus() : Return False
        End If
        If cantidad > 99999D Then
            MessageBox.Show("La cantidad no puede superar 99999.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaCantidad.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtFarmaciaDosis.Text) Then
            MessageBox.Show("Falta la dosis.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaDosis.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtFarmaciaFrecuencia.Text) Then
            MessageBox.Show("Falta la frecuencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaFrecuencia.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtFarmaciaDuracion.Text) Then
            MessageBox.Show("Falta la duración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFarmaciaDuracion.Focus() : Return False
        End If
        If txtFarmaciaDosis.Text.Trim().Length > 100 OrElse
           txtFarmaciaFrecuencia.Text.Trim().Length > 100 OrElse
           txtFarmaciaDuracion.Text.Trim().Length > 100 OrElse
           txtFarmaciaObservaciones.Text.Trim().Length > 250 Then
            MessageBox.Show("Uno de los textos supera la longitud permitida.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Return True
    End Function

    Private Sub FarmaciaSeleccion(sender As Object, e As EventArgs) Handles lvFarmaciaRegistrada.SelectedIndexChanged
        If lvFarmaciaRegistrada.SelectedItems.Count = 0 Then Exit Sub
        Dim codigo As String = lvFarmaciaRegistrada.SelectedItems(0).Text.Trim()
        PosicionarPorCodigo(codigo)
        MostrarRegistro()
    End Sub

    Private Sub FarmaciaAgregar(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        If cmdAgregar.Text.Trim() = "Agregar" Then
            cmdAgregar.Text = "Guardar"
            LimpiarControles()
            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)
            txtFarmaciaCodigo.Focus()
            Exit Sub
        End If

        Dim cantidad As Decimal
        If Not ValidarDatos(cantidad) Then Exit Sub

        Using comando As New SqlCommand("Atenciones.spFarmaciaInsertarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            AgregarParametros(comando, cantidad, True)
            If Not EjecutarComando(comando, "Farmacia registrada.") Then Exit Sub
        End Using

        cmdAgregar.Text = "Agregar"
        vPosicion = 0
        CrearDataSet()
        LlenarLista()
        PosicionarPorCodigo(txtFarmaciaCodigo.Text.Trim())
        ActualizarFormulario()
    End Sub

    Private Sub FarmaciaEditar(sender As Object, e As EventArgs) Handles cmdEditar.Click
        If dsDatos.Tables("Farmacia").Rows.Count = 0 Then Exit Sub

        If cmdEditar.Text.Trim() = "Editar" Then
            cmdEditar.Text = "Guardar"
            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)
            txtRecetaCodigo.Focus()
            Exit Sub
        End If

        Dim cantidad As Decimal
        If Not ValidarDatos(cantidad) Then Exit Sub
        Dim codigoActual As String = txtFarmaciaCodigo.Text.Trim()

        Using comando As New SqlCommand("Atenciones.spFarmaciaEditarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            AgregarParametros(comando, cantidad, False)
            If Not EjecutarComando(comando, "Registro de farmacia modificado.") Then Exit Sub
        End Using

        cmdEditar.Text = "Editar"
        CrearDataSet()
        LlenarLista()
        PosicionarPorCodigo(codigoActual)
        ActualizarFormulario()
    End Sub

    Private Sub AgregarParametros(comando As SqlCommand, cantidad As Decimal, incluirEstado As Boolean)
        comando.Parameters.Add("@FarmaciaCodigo", SqlDbType.NChar, 7).Value = txtFarmaciaCodigo.Text.Trim()
        comando.Parameters.Add("@RecetaCodigo", SqlDbType.NChar, 7).Value = txtRecetaCodigo.Text.Trim()
        comando.Parameters.Add("@MedicamentosCodigo", SqlDbType.NChar, 7).Value = txtMedicamentosCodigo.Text.Trim()
        Dim pCantidad As SqlParameter = comando.Parameters.Add("@FarmaciaCantidad", SqlDbType.Decimal)
        pCantidad.Precision = 5 : pCantidad.Scale = 0 : pCantidad.Value = cantidad
        comando.Parameters.Add("@FarmaciaDosis", SqlDbType.NVarChar, 100).Value = txtFarmaciaDosis.Text.Trim()
        comando.Parameters.Add("@FarmaciaFrecuencia", SqlDbType.NVarChar, 100).Value = txtFarmaciaFrecuencia.Text.Trim()
        comando.Parameters.Add("@FarmaciaDuracion", SqlDbType.NVarChar, 100).Value = txtFarmaciaDuracion.Text.Trim()
        comando.Parameters.Add("@FarmaciaObservaciones", SqlDbType.NVarChar, 250).Value = txtFarmaciaObservaciones.Text.Trim()
        If incluirEstado Then comando.Parameters.Add("@FarmaciaEstado", SqlDbType.NChar, 1).Value = "A"
    End Sub

    Private Function EjecutarComando(comando As SqlCommand, mensaje As String) As Boolean
        Try
            If cn.State <> ConnectionState.Closed Then cn.Close()
            cn.Open()
            comando.ExecuteNonQuery()
            MessageBox.Show(mensaje, "Farmacia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As SqlException
            MessageBox.Show("No se pudo completar la operación." & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If cn.State <> ConnectionState.Closed Then cn.Close()
        End Try
    End Function

    Private Sub FarmaciaEliminar(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        If dsDatos.Tables("Farmacia").Rows.Count = 0 Then Exit Sub
        If MessageBox.Show("¿Desea eliminar el registro " & txtFarmaciaCodigo.Text.Trim() & "?",
                           "Eliminación de registros", MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> DialogResult.OK Then Exit Sub

        Using comando As New SqlCommand("Atenciones.spFarmaciaEliminarRegistro", cn)
            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.Add("@FarmaciaCodigo", SqlDbType.NChar, 7).Value = txtFarmaciaCodigo.Text.Trim()
            If Not EjecutarComando(comando, "Registro de farmacia eliminado.") Then Exit Sub
        End Using

        vPosicion = 0
        CrearDataSet()
        LlenarLista()
        ActualizarFormulario()
    End Sub

    Private Sub PosicionarPorCodigo(codigo As String)
        vPosicion = 0
        For i As Integer = 0 To dsDatos.Tables("Farmacia").Rows.Count - 1
            If dsDatos.Tables("Farmacia").Rows(i)("FarmaciaCodigo").ToString().Trim() = codigo Then
                vPosicion = i : Exit For
            End If
        Next
    End Sub

    Private Sub FarmaciaCancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"
        ActualizarFormulario()
    End Sub

    Private Sub FarmaciaCerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FarmaciaEliminados(sender As Object, e As EventArgs) Handles cmdEliminados.Click
        vFarmaciaRecuperada = 0
        Using formulario As New frmFarmaciaEliminados()
            formulario.ShowDialog()
        End Using
        If vFarmaciaRecuperada = 1 Then
            vPosicion = 0
            CrearDataSet()
            LlenarLista()
            ActualizarFormulario()
        End If
    End Sub

End Class
