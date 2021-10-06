Imports System.Windows.SizeToContent
Public Class RegistrationWindow


#Region "Page Event Declarations"


    Private Sub Window_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded

    End Sub

#End Region

#Region "Focus Properties"

    Private Sub FirstNameFocus(sender As Object, e As RoutedEventArgs) Handles txtFirstName.GotFocus
        If txtFirstName.Text.Trim = "First Name" Then
            txtFirstName.Text = ""
        End If
    End Sub

    Private Sub FirstNameLostFocus(sender As Object, e As RoutedEventArgs) Handles txtFirstName.LostFocus
        If txtFirstName.Text.Trim = "" Then
            txtFirstName.Text = "First Name"
        End If
    End Sub

    Private Sub LastNameFocus(sender As Object, e As RoutedEventArgs) Handles txtLast.GotFocus
        If txtLast.Text.Trim = "Last Name" Then
            txtLast.Text = ""
        End If
    End Sub

    Private Sub LastNameLostFocus(sender As Object, e As RoutedEventArgs) Handles txtLast.LostFocus
        If txtLast.Text.Trim = "" Then
            txtLast.Text = "Last Name"
        End If
    End Sub

    Private Sub EmailFocus(sender As Object, e As RoutedEventArgs) Handles txtEmail.GotFocus
        If txtEmail.Text.Trim = "Email Address" Then
            txtEmail.Text = ""
        End If
    End Sub

    Private Sub EmailLostFocus(sender As Object, e As RoutedEventArgs) Handles txtEmail.LostFocus
        If txtEmail.Text.Trim = "" Then
            txtEmail.Text = "Email Address"
        End If
    End Sub

    Private Sub DOBFocus(sender As Object, e As RoutedEventArgs) Handles txtDOB.GotFocus
        If txtDOB.Text.Trim = "Date of Birth" Then
            txtDOB.Text = ""
        End If
    End Sub

    Private Sub DOBLostFocus(sender As Object, e As RoutedEventArgs) Handles txtDOB.LostFocus
        If txtDOB.Text.Trim = "" Then
            txtDOB.Text = "Date of Birth"
        End If
    End Sub

    Private Sub PassFocus(sender As Object, e As RoutedEventArgs) Handles txtPass.GotFocus
        If txtPass.Text.Trim = "Password" Then
            txtPass.Text = ""
        End If
    End Sub

    Private Sub PassLostFocus(sender As Object, e As RoutedEventArgs) Handles txtPass.LostFocus
        If txtPass.Text.Trim = "" Then
            txtPass.Text = "Password"
        End If
    End Sub

    Private Sub ConfirmPassFocus(sender As Object, e As RoutedEventArgs) Handles txtCPass.GotFocus
        If txtCPass.Text.Trim = "Confirm Password" Then
            txtCPass.Text = ""
        End If
    End Sub

    Private Sub ConfirmPassLostFocus(sender As Object, e As RoutedEventArgs) Handles txtCPass.LostFocus
        If txtCPass.Text.Trim = "" Then
            txtCPass.Text = "Confirm Password"
        End If
    End Sub
#End Region

    Private Sub btnRegister_Click(sender As Object, e As RoutedEventArgs)
        Dim lsErrorCode As String = ""


        Try

            If CheckInformation() Then

                Dim UserInfo As New SNKRWRLDBLL.Masters
                Dim Users As New SNKRWLRDCEL.UserInfo

                If UserInfo.AddUser(Users, lsErrorCode) Then
                    Dim newInstance As Welcome
                    newInstance.Show()
                Else
                    MessageBox.Show("Error Occurred While Registering, Please Try Again Later", "Warning", MessageBoxButton.OK, MessageBoxImage.Error)
                End If
            End If


        Catch ex As Exception

        End Try

    End Sub


    Private Function CheckInformation()
        Dim isSave As Boolean = True
        Dim errorMsg As String = ""

        Dim users As SNKRWRLDBLL.Masters
        If txtCPass.Text <> txtPass.Text Then
            isSave = False
            errorMsg = errorMsg & "Please Check Both Passwords. "
        End If

        If txtPass.Text.Trim = "" Then
            isSave = False
            errorMsg = errorMsg & "Please enter a Password. "
        End If

        Dim isCapital As Boolean
        Dim isLower As Boolean
        Dim isValid As Boolean

        For Each l In txtPass.Text
            Dim letter As String = l
            If letter = letter.ToUpper() Then
                isCapital = True
            Else
                isLower = True
            End If
        Next
        If isCapital = False Or isLower = False Then
            isSave = False
            errorMsg = errorMsg & "Password must contain a capital and lower case letter. "
        End If

        If txtDOB.Text.Trim = "" Then
            isSave = False
            errorMsg = errorMsg & "Please enter your date of birth. "
        End If

        If txtEmail.Text.Trim = "" Then
            isSave = False
            errorMsg = errorMsg & "Please enter your email. "
        End If

        If txtFirstName.Text.Trim = "" Then
            isSave = False
            errorMsg = errorMsg & "Please enter your first name. "
        End If

        If txtLast.Text.Trim = "" Then
            isSave = False
            errorMsg = errorMsg & "Please enter your last name. "
        End If

        If isSave = False Then
            MessageBox.Show(errorMsg, "Check Data Fields", MessageBoxButton.OK, MessageBoxImage.Warning)
            Return False
        Else
            Return True
        End If
    End Function
End Class
