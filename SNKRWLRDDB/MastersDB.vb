Imports System.Data
Imports System.Data.SqlClient
Public Class MastersDB
    Public Function AddUserDB(ByRef poUserInformation As SNKRWLRDCEL.UserInfo, ByRef psErrorMsg As String) As Boolean
        Try
            'creates a connection to the database and uses the id and password to gain access
            Dim dbSQL As New SqlConnection
            dbSQL.ConnectionString = "server=localhost;user id=root;password=dolphins13;database=SNKRWRLDDB"
            dbSQL.Open()
            Dim dsDataSet As New DataSet
            'creates a variable to access the stored procedure
            Dim cmd As New SqlCommand("spAddUser", dbSQL)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(poUserInformation.FirstName)
            cmd.Parameters.Add(poUserInformation.LastName)
            cmd.Parameters.Add(poUserInformation.DOB)
            cmd.Parameters.Add(poUserInformation.Email)
            cmd.Parameters.Add(poUserInformation.Password)
            cmd.ExecuteNonQuery()
            dbSQL.Close()
            Return True
        Catch ex As Exception
            'shows error message if the process fails and returns a false value
            psErrorMsg = ex.Message
            Return False
        End Try

    End Function

End Class
