Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmLogin

    Private Const MAXIMO_INTENTOS As Integer = 5
    Private intentosFallidos As Integer = 0

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Clear()
        txtClave.Clear()

        ' Oculta la contraseña mientras el usuario la escribe.
        txtClave.UseSystemPasswordChar = True

        ' Permite aceptar con Enter y cancelar con Escape.
        Me.AcceptButton = cmdAceptar
        Me.CancelButton = cmdCancelar

        txtUsuario.Focus()
    End Sub

    Private Sub IngresoAlSistema(sender As Object, e As EventArgs) Handles cmdAceptar.Click

        Dim nombreUsuario As String = txtUsuario.Text.Trim()
        Dim claveIngresada As String = txtClave.Text

        If String.IsNullOrWhiteSpace(nombreUsuario) Then
            MessageBox.Show("Falta ingresar el usuario.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsuario.Focus()
            Exit Sub
        End If

        If nombreUsuario.Length > 50 Then
            MessageBox.Show("El usuario no puede superar 50 caracteres.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsuario.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(claveIngresada) Then
            MessageBox.Show("Falta ingresar la contraseña.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtClave.Focus()
            Exit Sub
        End If

        Dim claveMD5 As String = fEncriptarDato(claveIngresada)

        Using cn As New SqlConnection(cnClinica)
            Using coIniciarSesion As New SqlCommand("Seguridad.spAutenticacionUsuarios", cn)
                coIniciarSesion.CommandType = CommandType.StoredProcedure

                Dim paNombre As New SqlParameter()
                paNombre.ParameterName = "@Nombre"
                paNombre.Direction = ParameterDirection.Input
                paNombre.SqlDbType = SqlDbType.NVarChar
                paNombre.Size = 50
                paNombre.Value = nombreUsuario
                coIniciarSesion.Parameters.Add(paNombre)

                Dim paClave As New SqlParameter()
                paClave.ParameterName = "@Clave"
                paClave.Direction = ParameterDirection.Input
                paClave.SqlDbType = SqlDbType.NVarChar
                paClave.Size = 100
                paClave.Value = claveMD5
                coIniciarSesion.Parameters.Add(paClave)

                Dim paResultado As New SqlParameter()
                paResultado.ParameterName = "@Resultado"
                paResultado.Direction = ParameterDirection.ReturnValue
                paResultado.SqlDbType = SqlDbType.Int
                coIniciarSesion.Parameters.Add(paResultado)

                Try
                    cn.Open()
                    coIniciarSesion.ExecuteNonQuery()

                    Dim vResultado As Integer = Convert.ToInt32(
                        coIniciarSesion.Parameters("@Resultado").Value)

                    If vResultado = 1 Then
                        intentosFallidos = 0
                        txtClave.Clear()
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        RegistrarIntentoIncorrecto()
                    End If

                Catch ex As SqlException
                    MessageBox.Show("No se pudo validar el usuario." & vbCrLf &
                                    "Verifique la conexión con SQL Server." & vbCrLf & vbCrLf &
                                    ex.Message,
                                    "Error de conexión",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub RegistrarIntentoIncorrecto()
        intentosFallidos += 1
        txtClave.Clear()

        If intentosFallidos >= MAXIMO_INTENTOS Then
            MessageBox.Show("Se alcanzó el máximo de intentos permitidos.",
                            "Acceso bloqueado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)

            cmdAceptar.Enabled = False
            txtUsuario.Enabled = False
            txtClave.Enabled = False
        Else
            Dim intentosRestantes As Integer = MAXIMO_INTENTOS - intentosFallidos

            ' No se informa cuál de los dos datos es incorrecto.
            MessageBox.Show("Usuario o contraseña incorrectos." & vbCrLf &
                            "Intentos restantes: " & intentosRestantes.ToString(),
                            "Acceso denegado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)

            txtClave.Focus()
        End If
    End Sub

    Private Function fEncriptarDato(clave As String) As String
        Using claveEncriptada As MD5 = MD5.Create()
            Return ObtenerDatoEncriptado(claveEncriptada, clave)
        End Using
    End Function

    Public Shared Function ObtenerDatoEncriptado(datoAEncriptar As MD5,
                                                  ingreso As String) As String
        Dim datos As Byte() = datoAEncriptar.ComputeHash(Encoding.UTF8.GetBytes(ingreso))
        Dim resultado As New StringBuilder()

        For i As Integer = 0 To datos.Length - 1
            resultado.Append(datos(i).ToString("x2"))
        Next

        Return resultado.ToString()
    End Function

    Private Sub Cancelar(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        txtClave.Clear()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
