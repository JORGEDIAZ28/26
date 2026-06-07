Imports capaDatos

Public Class clsMarca
    Dim objMan As New clsMantenimiento
    Dim strConsulta As String
    Dim dt As New DataTable

    '=========================================
    ' OBTENER ID
    '=========================================

    Public Function obtenerIDMarca() As Integer

        strConsulta = "select isnull(max(IDMARCA),0)+1 from MARCA"

        Try

            dt = objMan.listarComando(strConsulta)

            Return dt.Rows(0).Item(0)

        Catch ex As Exception

            Throw New Exception("Error al generar ID de Marca!")

        End Try

    End Function

    '=========================================
    ' LISTAR
    '=========================================

    Public Function listarMarcas() As DataTable
        ' Hacemos un JOIN para traer el nombre del laboratorio en lugar de su ID
        strConsulta = "SELECT M.IDMARCA, M.NOMBREMARCA, M.DESCRIPCION, M.VIGENCIA, L.NOMBRELABORATORIO AS LABORATORIO " &
                  "FROM MARCA M " &
                  "INNER JOIN LABORATORIO L ON M.IDLABORATORIO = L.IDLABORATORIO"

        Try
            Return objMan.listarComando(strConsulta)
        Catch ex As Exception
            Throw New Exception("Error al listar Marcas!")
        End Try
    End Function

    '=========================================
    ' BUSCAR
    '=========================================

    Public Function buscarMarca(id As Integer) As DataTable

        strConsulta = "select * from MARCA where IDMARCA=" & id

        Try

            Return objMan.listarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al buscar Marca!")

        End Try

    End Function

    '=========================================
    ' GUARDAR
    '=========================================

    Public Sub guardarMarca(
            nombre As String,
            descripcion As String,
            vigencia As Boolean,
            idLaboratorio As Integer)

        strConsulta = "insert into MARCA values('" &
                        nombre & "','" &
                        descripcion & "'," &
                        IIf(vigencia, 1, 0) & "," &
                        idLaboratorio & ")"

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al registrar Marca!")

        End Try

    End Sub

    '=========================================
    ' MODIFICAR
    '=========================================

    Public Sub modificarMarca(
            id As Integer,
            nombre As String,
            descripcion As String,
            vigencia As Boolean,
            idLaboratorio As Integer)

        strConsulta = "update MARCA set " &
                        "NOMBREMARCA='" & nombre & "'," &
                        "DESCRIPCION='" & descripcion & "'," &
                        "VIGENCIA=" & IIf(vigencia, 1, 0) & "," &
                        "IDLABORATORIO=" & idLaboratorio &
                        " where IDMARCA=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al modificar Marca!")

        End Try

    End Sub

    '=========================================
    ' ELIMINAR
    '=========================================

    Public Sub eliminarMarca(id As Integer)

        strConsulta = "delete from MARCA where IDMARCA=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al eliminar Marca!")

        End Try

    End Sub

    '=========================================
    ' DAR BAJA
    '=========================================

    Public Sub darBajaMarca(id As Integer)

        strConsulta = "update MARCA set VIGENCIA=0 where IDMARCA=" & id

        Try

            objMan.ejecutarComando(strConsulta)

        Catch ex As Exception

            Throw New Exception("Error al dar de baja Marca!")

        End Try

    End Sub

    Public Function listarMarcasPorLaboratorio(idLab As Integer) As DataTable
        ' Esto permite que si eligen un Lab, el combo de Marcas se filtre (Escalabilidad)
        strConsulta = "SELECT IDMARCA, NOMBREMARCA FROM MARCA WHERE VIGENCIA = 1 AND IDLABORATORIO = " & idLab
        Return objMan.listarComando(strConsulta)
    End Function

End Class
