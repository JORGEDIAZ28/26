Imports capaDatos

Public Class clsLaboratorio
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDLaboratorio() As Integer

        strConsulta = "select isnull(max(IDLABORATORIO),0)+1 from LABORATORIO"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Laboratorio!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarLaboratorios() As DataTable

        strConsulta = "select * from LABORATORIO"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Laboratorios!")

        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarLaboratorio(id As Integer) As DataTable

        strConsulta = "select * from LABORATORIO where IDLABORATORIO=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Laboratorio!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarLaboratorio(
            nombre As String,
            direccion As String,
            telefono As String,
            vigencia As Boolean)

        strConsulta = "insert into LABORATORIO values('" &
                        nombre & "','" &
                        direccion & "','" &
                        telefono & "'," &
                        IIf(vigencia, 1, 0) & ")"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Laboratorio!")

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarLaboratorio(
            id As Integer,
            nombre As String,
            direccion As String,
            telefono As String,
            vigencia As Boolean)

        strConsulta = "update LABORATORIO set " &
                        "NOMBRELABORATORIO='" & nombre & "'," &
                        "DIRECCION='" & direccion & "'," &
                        "TELEFONO='" & telefono & "'," &
                        "VIGENCIA=" & IIf(vigencia, 1, 0) &
                        " where IDLABORATORIO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Laboratorio!")

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarLaboratorio(id As Integer)

        strConsulta = "delete from LABORATORIO where IDLABORATORIO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Laboratorio!")

        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaLaboratorio(id As Integer)

        strConsulta = "update LABORATORIO set VIGENCIA=0 where IDLABORATORIO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al dar de baja Laboratorio!")

        End Try

    End Sub
End Class
