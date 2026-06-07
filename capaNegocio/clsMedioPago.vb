Imports capaDatos

Public Class clsMedioPago

    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDMedioPago() As Integer

        strConsulta = "select isnull(max(IDMEDIOPAGO),0)+1 from MEDIO_PAGO"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Medio de Pago!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarMedioPago() As DataTable

        strConsulta = "select * from MEDIO_PAGO"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Medios de Pago!")

        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarMedioPago(id As Integer) As DataTable

        strConsulta = "select * from MEDIO_PAGO where IDMEDIOPAGO=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Medio de Pago!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarMedioPago(
            nombre As String,
            estado As Boolean)

        strConsulta = "insert into MEDIO_PAGO values('" &
                        nombre & "'," &
                        IIf(estado, 1, 0) & ")"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Medio de Pago!")

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarMedioPago(
            id As Integer,
            nombre As String,
            estado As Boolean)

        strConsulta = "update MEDIO_PAGO set " &
                        "NOMBRE='" & nombre & "'," &
                        "ESTADO=" & IIf(estado, 1, 0) &
                        " where IDMEDIOPAGO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Medio de Pago!")

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarMedioPago(id As Integer)

        strConsulta = "delete from MEDIO_PAGO where IDMEDIOPAGO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Medio de Pago!")

        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaMedioPago(id As Integer)

        strConsulta = "update MEDIO_PAGO set ESTADO=0 where IDMEDIOPAGO=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al dar de baja Medio de Pago!")

        End Try

    End Sub

End Class
