Imports System.Data
Imports System.Data.SqlClient

Public Class frmRecetas

    ' Zona de declaraciones
    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daRecetas As SqlDataAdapter
    Dim vPosicion As Integer

    Private Sub RecetasCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CreaDataSet()

        If dsDatos.Tables("Recetas").Rows.Count > 0 Then
            MostrarRegistro()
        End If

        LlenarLista()

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)
    End Sub

    Private Sub CreaDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet

        daRecetas = New SqlDataAdapter(
            "Atenciones.spRecetaListaSinBorrados", cn)

        daRecetas.Fill(dsDatos, "Recetas")
    End Sub

    Private Sub MostrarRegistro()

        If dsDatos.Tables("Recetas").Rows.Count = 0 Then
            Exit Sub
        End If

        txtRecetaCodigo.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaCodigo").ToString

        txtHistoriaClinicaCodigo.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("HistoriaClinicaCodigo").ToString

        txtMedicosCodigo.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("MedicosCodigo").ToString

        txtRecetaCategoriasCodigo.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaCategoriasCodigo").ToString

        dtpRecetaFecha.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaFecha").ToString

        txtRecetaDiagnostico.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaDiagnostico").ToString

        txtRecetaIndicaciones.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaIndicaciones").ToString

        txtRecetaObservaciones.Text =
            dsDatos.Tables("Recetas").Rows(vPosicion).
            Item("RecetaObservaciones").ToString

    End Sub

    Private Sub LlenarLista()

        lvRecetasRegistradas.Items.Clear()

        For i As Integer = 0 To dsDatos.Tables("Recetas").Rows.Count - 1

            lvRecetasRegistradas.Items.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaCodigo").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("HistoriaClinicaCodigo").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("MedicosCodigo").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaCategoriasCodigo").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaFecha").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaDiagnostico").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaIndicaciones").ToString)

            lvRecetasRegistradas.Items(i).SubItems.Add(
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaObservaciones").ToString)

        Next

    End Sub

    Private Sub Controles(
        pRecetaCodigo As Boolean,
        pHistoriaClinicaCodigo As Boolean,
        pMedicosCodigo As Boolean,
        pRecetaCategoriasCodigo As Boolean,
        pRecetaFecha As Boolean,
        pRecetaDiagnostico As Boolean,
        pRecetaIndicaciones As Boolean,
        pRecetaObservaciones As Boolean,
        pLista As Boolean)

        txtRecetaCodigo.Enabled = pRecetaCodigo
        txtHistoriaClinicaCodigo.Enabled = pHistoriaClinicaCodigo
        txtMedicosCodigo.Enabled = pMedicosCodigo
        txtRecetaCategoriasCodigo.Enabled = pRecetaCategoriasCodigo
        dtpRecetaFecha.Enabled = pRecetaFecha
        txtRecetaDiagnostico.Enabled = pRecetaDiagnostico
        txtRecetaIndicaciones.Enabled = pRecetaIndicaciones
        txtRecetaObservaciones.Enabled = pRecetaObservaciones
        lvRecetasRegistradas.Enabled = pLista

    End Sub

    Private Sub Botones(
        pAgregar As Boolean,
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

    Private Sub RecetasSeleccion(
        sender As Object,
        e As EventArgs) Handles lvRecetasRegistradas.SelectedIndexChanged

        If lvRecetasRegistradas.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To dsDatos.Tables("Recetas").Rows.Count - 1

            If lvRecetasRegistradas.SelectedItems(0).Text =
                dsDatos.Tables("Recetas").Rows(i).
                Item("RecetaCodigo").ToString Then

                vPosicion = i
                Exit For

            End If

        Next

        MostrarRegistro()

    End Sub

    Private Sub RecetasAgregar(
        sender As Object,
        e As EventArgs) Handles cmdAgregar.Click

        If cmdAgregar.Text.Trim = "Agregar" Then

            cmdAgregar.Text = "Guardar"

            Controles(True, True, True, True, True, True, True, True, False)
            Botones(True, False, False, True, False, False)

            txtRecetaCodigo.Clear()
            txtHistoriaClinicaCodigo.Clear()
            txtMedicosCodigo.Clear()
            txtRecetaCategoriasCodigo.Clear()
            dtpRecetaFecha.Value = Date.Today
            txtRecetaDiagnostico.Clear()
            txtRecetaIndicaciones.Clear()
            txtRecetaObservaciones.Clear()

            txtRecetaCodigo.Focus()

        Else

            ' Código de receta
            If Len(Trim(txtRecetaCodigo.Text)) = 0 Or
                Len(Trim(txtRecetaCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Receta incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaCodigo.Focus()
                Exit Sub

            End If

            ' Código de historia clínica
            If Len(Trim(txtHistoriaClinicaCodigo.Text)) = 0 Or
                Len(Trim(txtHistoriaClinicaCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Historia Clínica incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtHistoriaClinicaCodigo.Focus()
                Exit Sub

            End If

            ' Código de médico
            If Len(Trim(txtMedicosCodigo.Text)) = 0 Or
                Len(Trim(txtMedicosCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Médico incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtMedicosCodigo.Focus()
                Exit Sub

            End If

            ' Código de categoría
            If Len(Trim(txtRecetaCategoriasCodigo.Text)) = 0 Or
                Len(Trim(txtRecetaCategoriasCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Categoría incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaCategoriasCodigo.Focus()
                Exit Sub

            End If

            ' Diagnóstico
            If Len(Trim(txtRecetaDiagnostico.Text)) = 0 Then

                MessageBox.Show(
                    "Falta Diagnóstico",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaDiagnostico.Focus()
                Exit Sub

            End If

            ' Indicaciones
            If Len(Trim(txtRecetaIndicaciones.Text)) = 0 Then

                MessageBox.Show(
                    "Faltan Indicaciones",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaIndicaciones.Focus()
                Exit Sub

            End If

            ' Observaciones puede quedar vacío
            If Len(Trim(txtRecetaObservaciones.Text)) = 0 Then
                txtRecetaObservaciones.Text = ""
            End If

            ' Consumir procedimiento para insertar
            Dim coRecetaNueva As New SqlCommand(
                "Atenciones.spRecetasInsertarRegistro", cn)

            coRecetaNueva.CommandType = CommandType.StoredProcedure

            '@RecetaCodigo nchar(7)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtRecetaCodigo.Text

            '@HistoriaClinicaCodigo nchar(7)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@HistoriaClinicaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtHistoriaClinicaCodigo.Text

            '@MedicosCodigo nchar(7)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@MedicosCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtMedicosCodigo.Text

            '@RecetaCategoriasCodigo nchar(7)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaCategoriasCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtRecetaCategoriasCodigo.Text

            '@RecetaFecha date
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaFecha",
                    SqlDbType.Date)).Value =
                    dtpRecetaFecha.Value.Date

            '@RecetaDiagnostico nvarchar(500)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaDiagnostico",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaDiagnostico.Text

            '@RecetaIndicaciones nvarchar(500)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaIndicaciones",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaIndicaciones.Text

            '@RecetaObservaciones nvarchar(500)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaObservaciones",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaObservaciones.Text

            '@RecetaEstado nchar(1)
            coRecetaNueva.Parameters.Add(
                New SqlParameter(
                    "@RecetaEstado",
                    SqlDbType.NChar,
                    1,
                    ParameterDirection.Input)).Value = "A"

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try

                cn.Open()
                coRecetaNueva.ExecuteNonQuery()

                MessageBox.Show(
                    "Receta registrada",
                    "Inserción de Receta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1)

            Catch ex As Exception

                MessageBox.Show("No se pudo insertar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub

            Finally

                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                End If

            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Recetas").Rows.Count > 0 Then
                MostrarRegistro()
            End If

            cmdAgregar.Text = "Agregar"

            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)

        End If

    End Sub

    Private Sub RecetasEliminar(
        sender As Object,
        e As EventArgs) Handles cmdEliminar.Click

        If dsDatos.Tables("Recetas").Rows.Count = 0 Then

            MessageBox.Show(
                "No existen recetas para eliminar",
                "Eliminación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If

        If MessageBox.Show(
            "¿Desea eliminar la receta " &
            Trim(txtRecetaCodigo.Text) & "?",
            "Eliminación de registros",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coRecetaEliminar As New SqlCommand(
                "Atenciones.spRecetaEliminarRegistro", cn)

            coRecetaEliminar.CommandType = CommandType.StoredProcedure

            coRecetaEliminar.Parameters.Add(
                New SqlParameter(
                    "@RecetaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtRecetaCodigo.Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try

                cn.Open()
                coRecetaEliminar.ExecuteNonQuery()

                MessageBox.Show(
                    "Receta eliminada",
                    "Eliminación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)

            Catch ex As Exception

                MessageBox.Show("No se pudo eliminar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub

            Finally

                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                End If

            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Recetas").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarCampos()
            End If

        End If

    End Sub

    Private Sub RecetasEditar(
        sender As Object,
        e As EventArgs) Handles cmdEditar.Click

        If dsDatos.Tables("Recetas").Rows.Count = 0 Then

            MessageBox.Show(
                "No existen recetas para editar",
                "Edición",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub

        End If

        If cmdEditar.Text.Trim = "Editar" Then

            cmdEditar.Text = "Guardar"

            Controles(False, True, True, True, True, True, True, True, False)
            Botones(False, True, False, True, False, False)

            txtHistoriaClinicaCodigo.Focus()

        Else

            ' Código de historia clínica
            If Len(Trim(txtHistoriaClinicaCodigo.Text)) = 0 Or
                Len(Trim(txtHistoriaClinicaCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Historia Clínica incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtHistoriaClinicaCodigo.Focus()
                Exit Sub

            End If

            ' Código de médico
            If Len(Trim(txtMedicosCodigo.Text)) = 0 Or
                Len(Trim(txtMedicosCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Médico incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtMedicosCodigo.Focus()
                Exit Sub

            End If

            ' Código de categoría
            If Len(Trim(txtRecetaCategoriasCodigo.Text)) = 0 Or
                Len(Trim(txtRecetaCategoriasCodigo.Text)) <> 7 Then

                MessageBox.Show(
                    "Código de Categoría incorrecto, debe ser de 7 caracteres",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaCategoriasCodigo.Focus()
                Exit Sub

            End If

            ' Diagnóstico
            If Len(Trim(txtRecetaDiagnostico.Text)) = 0 Then

                MessageBox.Show(
                    "Falta Diagnóstico",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaDiagnostico.Focus()
                Exit Sub

            End If

            ' Indicaciones
            If Len(Trim(txtRecetaIndicaciones.Text)) = 0 Then

                MessageBox.Show(
                    "Faltan Indicaciones",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                txtRecetaIndicaciones.Focus()
                Exit Sub

            End If

            ' Observaciones puede quedar vacío
            If Len(Trim(txtRecetaObservaciones.Text)) = 0 Then
                txtRecetaObservaciones.Text = ""
            End If

            Dim coRecetaEditar As New SqlCommand(
                "Atenciones.spRecetasEditarRegistro", cn)

            coRecetaEditar.CommandType = CommandType.StoredProcedure

            '@RecetaCodigo nchar(7)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtRecetaCodigo.Text

            '@HistoriaClinicaCodigo nchar(7)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@HistoriaClinicaCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtHistoriaClinicaCodigo.Text

            '@MedicosCodigo nchar(7)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@MedicosCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtMedicosCodigo.Text

            '@RecetaCategoriasCodigo nchar(7)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaCategoriasCodigo",
                    SqlDbType.NChar,
                    7,
                    ParameterDirection.Input)).Value =
                    txtRecetaCategoriasCodigo.Text

            '@RecetaFecha date
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaFecha",
                    SqlDbType.Date)).Value =
                    dtpRecetaFecha.Value.Date

            '@RecetaDiagnostico nvarchar(500)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaDiagnostico",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaDiagnostico.Text

            '@RecetaIndicaciones nvarchar(500)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaIndicaciones",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaIndicaciones.Text

            '@RecetaObservaciones nvarchar(500)
            coRecetaEditar.Parameters.Add(
                New SqlParameter(
                    "@RecetaObservaciones",
                    SqlDbType.NVarChar,
                    500,
                    ParameterDirection.Input)).Value =
                    txtRecetaObservaciones.Text

            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If

            Try

                cn.Open()
                coRecetaEditar.ExecuteNonQuery()

                MessageBox.Show(
                    "Receta modificada",
                    "Edición de Receta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1)

            Catch ex As Exception

                MessageBox.Show("No se pudo modificar el registro")
                MessageBox.Show(ex.Message)
                Exit Sub

            Finally

                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                End If

            End Try

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Recetas").Rows.Count > 0 Then
                MostrarRegistro()
            End If

            cmdEditar.Text = "Editar"

            Controles(False, False, False, False, False, False, False, False, True)
            Botones(True, True, True, False, True, True)

        End If

    End Sub

    Private Sub RecetasCancelar(
        sender As Object,
        e As EventArgs) Handles cmdCancelar.Click

        cmdAgregar.Text = "Agregar"
        cmdEditar.Text = "Editar"

        Controles(False, False, False, False, False, False, False, False, True)
        Botones(True, True, True, False, True, True)

        If dsDatos.Tables("Recetas").Rows.Count > 0 Then
            MostrarRegistro()
        Else
            LimpiarCampos()
        End If

    End Sub

    Private Sub LimpiarCampos()

        txtRecetaCodigo.Clear()
        txtHistoriaClinicaCodigo.Clear()
        txtMedicosCodigo.Clear()
        txtRecetaCategoriasCodigo.Clear()
        dtpRecetaFecha.Value = Date.Today
        txtRecetaDiagnostico.Clear()
        txtRecetaIndicaciones.Clear()
        txtRecetaObservaciones.Clear()

    End Sub

    Private Sub RecetasCerrar(
        sender As Object,
        e As EventArgs) Handles cmdCerrar.Click

        Me.Close()

    End Sub

    Private Sub RecetasEliminadas(
        sender As Object,
        e As EventArgs) Handles cmdEliminados.Click

        vRecetaRecuperada = 0

        Dim fRecetasEliminadas As New frmRecetasEliminados
        fRecetasEliminadas.ShowDialog()

        If vRecetaRecuperada = 1 Then

            vPosicion = 0
            CreaDataSet()
            LlenarLista()

            If dsDatos.Tables("Recetas").Rows.Count > 0 Then
                MostrarRegistro()
            Else
                LimpiarCampos()
            End If

        End If

    End Sub

End Class
