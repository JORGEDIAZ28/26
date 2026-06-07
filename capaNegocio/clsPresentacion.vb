Imports capaDatos

Public Class clsPresentacion
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDPresentacion() As Integer

        strConsulta = "select isnull(max(IDPRESENTACION),0)+1 from PRESENTACION"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Presentación!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarPresentaciones() As DataTable

        strConsulta = "select * from PRESENTACION"

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al listar Presentaciones!")

        End Try

    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarPresentacion(id As Integer) As DataTable

        strConsulta = "select * from PRESENTACION where IDPRESENTACION=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Presentación!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarPresentacion(
            tipoPresentacion As String,
            cantidad As Integer,
            unidad As String,
            estado As Boolean)

        strConsulta = "insert into PRESENTACION values('" &
                        tipoPresentacion & "'," &
                        cantidad & ",'" &
                        unidad & "'," &
                        IIf(estado, 1, 0) & ")"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Presentación!")

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarPresentacion(
            id As Integer,
            tipoPresentacion As String,
            cantidad As Integer,
            unidad As String,
            estado As Boolean)

        strConsulta = "update PRESENTACION set " &
                        "TIPOPRESENTACION='" & tipoPresentacion & "'," &
                        "CANTIDAD=" & cantidad & "," &
                        "UNIDAD='" & unidad & "'," &
                        "ESTADO=" & IIf(estado, 1, 0) &
                        " where IDPRESENTACION=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Presentación!")

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarPresentacion(id As Integer)

        strConsulta = "delete from PRESENTACION where IDPRESENTACION=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Presentación!")

        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaPresentacion(id As Integer)

        strConsulta = "update PRESENTACION set ESTADO=0 where IDPRESENTACION=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al dar de baja Presentación!")

        End Try

    End Sub
End Class
