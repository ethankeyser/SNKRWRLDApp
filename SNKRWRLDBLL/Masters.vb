Imports System.Data
Imports System.Data.SqlClient
Public Class Masters

    Public Function AddUser(ByRef poUserInformation As SNKRWLRDCEL.UserInfo, ByRef psErrorMsg As String)

        Try
            Dim dalDB As SNKRWLRDDB.MastersDB

            If dalDB.AddUserDB(poUserInformation, psErrorMsg) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            psErrorMsg = "Error occurred while adding a user to the system"
            Return False
        End Try
    End Function

End Class
