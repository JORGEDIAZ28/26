Imports capaDatos

Public Class clsUsuario

    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDUsuario() As Integer

        strConsulta = "select isnull(max(IDUSUARIO),0)+1 from USUARIO"

        Try
            dt = objMan.listarComando(strConsulta)
            Return dt.Rows(0).Item(0)

        Catch ex As Exception
            Throw New Exception("Error al generar ID de Usuario!")
        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarUsuarios() As DataTable

        strConsulta = "select * from USUARIO"

        Try
            Return objMan.listarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al listar Usuarios!")
        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarUsuarios(id As Integer) As DataTable

        strConsulta = "select * from USUARIO where IDUSUARIO=" & id

        Try
            Return objMan.listarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al buscar Usuario!")
        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarUsuario(
            dni As String,
            nom As String,
            apePat As String,
            apeMat As String,
            fechaNac As Date,
            correo As String,
            telefono As String,
            direccion As String,
            sexo As String,
            cargo As String,
            usuario As String,
            clave As String,
            estado As Boolean,
            pregunta As String,
            respuesta As String)

        strConsulta = "insert into USUARIO values('" &
                        dni & "','" &
                        nom & "','" &
                        apePat & "','" &
                        apeMat & "','" &
                        correo & "','" &
                        telefono & "','" &
                        direccion & "','" &
                        sexo & "','" &
                        cargo & "','" &
                        usuario & "','" &
                        clave & "'," &
                        IIf(estado, 1, 0) & ",'" &
                        pregunta & "','" &
                        respuesta & "','" &
                        fechaNac & "')"

        Try
            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al registrar Usuario!")
        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarUsuario(
            id As Integer,
            dni As String,
            nom As String,
            apePat As String,
            apeMat As String,
            fechaNac As Date,
            correo As String,
            telefono As String,
            direccion As String,
            sexo As String,
            cargo As String,
            usuario As String,
            clave As String,
            estado As Boolean,
            pregunta As String,
            respuesta As String)

        strConsulta = "update USUARIO set " &
                        "DNI='" & dni & "'," &
                        "NOMBRE='" & nom & "'," &
                        "APELLIDOPATERNO='" & apePat & "'," &
                        "APELLIDOMATERNO='" & apeMat & "'," &
                        "FECHANACIMIENTO='" & fechaNac & "'," &
                        "CORREO='" & correo & "'," &
                        "TELEFONO='" & telefono & "'," &
                        "DIRECCION='" & direccion & "'," &
                        "SEXO='" & sexo & "'," &
                        "CARGO='" & cargo & "'," &
                        "USUARIO='" & usuario & "'," &
                        "CLAVE='" & clave & "'," &
                        "ESTADO=" & IIf(estado, 1, 0) & "," &
                        "PREGUNTA='" & pregunta & "'," &
                        "RESPUESTA='" & respuesta & "' " &
                        "where IDUSUARIO=" & id

        Try
            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al modificar Usuario!")
        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarUsuario(id As Integer)

        strConsulta = "delete from USUARIO where IDUSUARIO=" & id

        Try
            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al eliminar Usuario!")
        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaUsuario(id As Integer)

        strConsulta = "update USUARIO set ESTADO=0 where IDUSUARIO=" & id

        Try
            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception
            Throw New Exception("Error al dar de baja Usuario!")
        End Try

    End Sub

    '=========================================
    ' LOGIN
    '=========================================

    Public Function iniciarSesion(usu As String, con As String) As Boolean

        strConsulta = "select * from USUARIO where USUARIO='" &
                        usu & "' and CLAVE='" & con & "'"

        dt = New DataTable

        Try

            dt = objMan.listarComando(strConsulta)

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("Error al validar inicio de sesión!")
        End Try

    End Function

    '=========================================
    ' OBTENER NOMBRE COMPLETO
    '=========================================

    Public Function obtenerNombreUsuario(usu As String) As String

        strConsulta = "select NOMBRE + ' ' + " &
                       "APELLIDOPATERNO + ' ' + " &
                       "APELLIDOMATERNO " &
                       "from USUARIO " &
                       "where USUARIO='" & usu & "'"

        Try

            Return objMan.listarComando(strConsulta).Rows(0).Item(0)

        Catch ex As Exception
            Throw New Exception("Error al consultar nombre de usuario!")
        End Try

    End Function

    Public Function obtenerCargoUsuario(usu As String) As String

        strConsulta = "select CARGO " &
                   "from USUARIO " &
                   "where USUARIO='" & usu & "'"

        Try

            Return objMan.listarComando(strConsulta).Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al consultar cargo de usuario!")

        End Try

    End Function

    Public Function buscarPorLogin(usu As String) As DataTable
        ' Consulta al servidor de base de datos [cite: 496]
        strConsulta = "select * from USUARIO where USUARIO='" & usu & "'"
        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al buscar pregunta de seguridad!")
        End Try
    End Function

End Class