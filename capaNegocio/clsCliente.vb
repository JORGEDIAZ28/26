Imports capaDatos

Public Class clsCliente
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDCliente() As Integer

        strConsulta = "select isnull(max(IDCLIENTE),0)+1 from CLIENTE"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Cliente!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarClientes() As DataTable

        strConsulta = "select * from CLIENTE"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Clientes!")

        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarClientes(id As Integer) As DataTable

        strConsulta = "select * from CLIENTE where IDCLIENTE=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Cliente!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarCliente(
            tipoDoc As String,
            nroDoc As String,
            tipoCliente As String,
            nombres As String,
            apePat As String,
            apeMat As String,
            razonSocial As String,
            direccion As String,
            telefono As String,
            correo As String)

        strConsulta = "insert into CLIENTE values('" &
                        tipoDoc & "','" &
                        nroDoc & "','" &
                        tipoCliente & "','" &
                        nombres & "','" &
                        apePat & "','" &
                        apeMat & "','" &
                        razonSocial & "','" &
                        direccion & "','" &
                        telefono & "','" &
                        correo & "')"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Cliente!")

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarCliente(
            id As Integer,
            tipoDoc As String,
            nroDoc As String,
            tipoCliente As String,
            nombres As String,
            apePat As String,
            apeMat As String,
            razonSocial As String,
            direccion As String,
            telefono As String,
            correo As String)

        strConsulta = "update CLIENTE set " &
                        "TIPODOC='" & tipoDoc & "'," &
                        "NRODOC='" & nroDoc & "'," &
                        "TIPO_CLIENTE='" & tipoCliente & "'," &
                        "NOMBRES='" & nombres & "'," &
                        "APELLIDOPATERNO='" & apePat & "'," &
                        "APELLIDOMATERNO='" & apeMat & "'," &
                        "RAZONSOCIAL='" & razonSocial & "'," &
                        "DIRECCION='" & direccion & "'," &
                        "TELEFONO='" & telefono & "'," &
                        "CORREO='" & correo & "' " &
                        "where IDCLIENTE=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Cliente!")

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarCliente(id As Integer)

        strConsulta = "delete from CLIENTE where IDCLIENTE=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Cliente!")

        End Try

    End Sub
End Class
