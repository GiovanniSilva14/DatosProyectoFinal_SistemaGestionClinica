Imports System.Data
Imports System.Data.SqlClient

Public Class frmEmpleadosEliminados

    Dim cn As SqlConnection
    Dim dsDatos As DataSet
    Dim daEliminados As SqlDataAdapter

    Private Sub EmpleadosEliminadosCarga(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearDataSet()
        LlenarLista()
        cmdRecuperar.Enabled = False
    End Sub

    Private Sub CrearDataSet()
        cn = New SqlConnection(cnClinica)
        dsDatos = New DataSet()
        daEliminados = New SqlDataAdapter("Atenciones.spEmpleadosListaBorrados", cn)
        daEliminados.SelectCommand.CommandType = CommandType.StoredProcedure
        daEliminados.Fill(dsDatos, "Eliminados")
    End Sub

    Private Sub LlenarLista()
        lvEmpleadosEliminados.Items.Clear()
        For i As Integer = 0 To dsDatos.Tables("Eliminados").Rows.Count - 1
            lvEmpleadosEliminados.Items.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosCodigo").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosDNI").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosNombres").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosApellidos").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosCargo").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosTelefono").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosCorreo").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosDireccion").ToString().Trim())
            lvEmpleadosEliminados.Items(i).SubItems.Add(CDate(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosFechaIngreso")).ToString("dd/MM/yyyy"))
            lvEmpleadosEliminados.Items(i).SubItems.Add(dsDatos.Tables("Eliminados").Rows(i).Item("EmpleadosEstado").ToString().Trim())
        Next
    End Sub

    Private Sub EmpleadoSeleccionado(sender As Object, e As EventArgs) Handles lvEmpleadosEliminados.SelectedIndexChanged
        If lvEmpleadosEliminados.SelectedItems.Count = 0 Then
            cmdRecuperar.Enabled = False
            Exit Sub
        End If
        cmdRecuperar.Enabled = True
    End Sub

    Private Sub EmpleadoRecuperar(sender As Object, e As EventArgs) Handles cmdRecuperar.Click
        If lvEmpleadosEliminados.SelectedItems.Count = 0 Then
            MessageBox.Show("Seleccione un empleado para recuperarlo.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("¿Desea recuperar al empleado seleccionado?", "Recuperación de registros",
                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                           MessageBoxDefaultButton.Button2) = DialogResult.OK Then

            Dim coEmpleadoRecuperar As New SqlCommand("Atenciones.spEmpleadosRecuperarRegistro", cn)
            coEmpleadoRecuperar.CommandType = CommandType.StoredProcedure
            coEmpleadoRecuperar.Parameters.Add(New SqlParameter("@EmpleadosCodigo", SqlDbType.NChar, 7,
                                                ParameterDirection.Input)).Value =
                                                lvEmpleadosEliminados.SelectedItems(0).Text.Trim()

            If cn.State <> ConnectionState.Closed Then cn.Close()
            Try
                cn.Open()
                coEmpleadoRecuperar.ExecuteNonQuery()
                MessageBox.Show("Empleado recuperado.", "Recuperación",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                vEmpleadoRecuperado = 1
            Catch ex As SqlException
                MessageBox.Show("No se pudo recuperar el empleado." & vbCrLf & ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then cn.Close()
                coEmpleadoRecuperar.Dispose()
            End Try

            CrearDataSet()
            LlenarLista()
            cmdRecuperar.Enabled = False
        End If
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

End Class
