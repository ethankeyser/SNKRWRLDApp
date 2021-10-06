Imports System.Windows
Imports System.Windows.Media.Animation

Class MainWindow

    Dim AppPath As String = System.IO.Directory.GetCurrentDirectory()
#Region "Window Event Declarations"
    Private Sub Window_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        Try
            ImgShowHide.Source = New BitmapImage(New Uri("C:\Users\User\source\repos\MoneyManagerPt1\MoneyManagerPt1\images\passwordUnlock1.png"))
            txtPassVisible.Text = "Password"
            Dim ts As New TimeSpan(0, 0, 2)
            Dim pauseTime As New TimeSpan(0, 0, 2)

            TypeWriteTextBlock("Welcome To SNKRWRLD", lblTitle, ts)

            TypeWriteTextBlock("Login", lblLogin, ts)

            TypeWriteTextBlock("Or", lblOr, ts)

            WidthChange(txtUser, ts, "Username/Email")
            WidthChange(txtPassVisible, ts, "Password")
            WidthChangeButton(btnRegister, ts)


        Catch ex As Exception
            MessageBox.Show("Error Occured When Animating Objects", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

    End Sub
#End Region

#Region "Function Declarations"
    Private Function TypeWriteTextBlock(text As String, txt As TextBlock, timespan As TimeSpan)
        Dim story As New Storyboard
        story.FillBehavior = FillBehavior.HoldEnd

        Dim DSKF As DiscreteStringKeyFrame
        Dim SAUKF As New StringAnimationUsingKeyFrames
        SAUKF.Duration = New Duration(timespan)

        Dim tmp As String
        For Each character As Char In text
            DSKF = New DiscreteStringKeyFrame
            DSKF.KeyTime = KeyTime.Paced
            tmp += character
            DSKF.Value = tmp
            SAUKF.KeyFrames.Add(DSKF)
        Next

        Storyboard.SetTargetName(SAUKF, txt.Name)
        Storyboard.SetTargetProperty(SAUKF, New PropertyPath(TextBlock.TextProperty))
        story.Children.Add(SAUKF)

        story.Begin(txt)

        Return True
    End Function


    Private Function WidthChange(obj As TextBox, timespan As TimeSpan, text As String)
        Dim story As New Storyboard
        story.FillBehavior = FillBehavior.HoldEnd

        Dim change As New DoubleAnimation(0, 234, timespan)

        Storyboard.SetTargetName(change, obj.Name)
        Storyboard.SetTargetProperty(change, New PropertyPath(TextBox.WidthProperty))
        story.Children.Add(change)

        story.Begin(obj)

        obj.Text = text
        Return True
    End Function

    Private Function WidthChangeButton(obj As Button, timespan As TimeSpan)
        Dim story As New Storyboard
        story.FillBehavior = FillBehavior.HoldEnd

        Dim change As New DoubleAnimation(0, 100, timespan)

        Storyboard.SetTargetName(change, obj.Name)
        Storyboard.SetTargetProperty(change, New PropertyPath(Button.WidthProperty))
        story.Children.Add(change)

        story.Begin(obj)

        Return True
    End Function

#End Region

#Region "Focus Properties"
    Private Sub UserDataFocus(sender As Object, e As RoutedEventArgs) Handles txtUser.GotFocus
        If txtUser.Text = "Username/Email" Then
            txtUser.Text = ""
        End If
    End Sub
    Private Sub UserDataLostFocus(sender As Object, e As RoutedEventArgs) Handles txtUser.LostFocus
        If txtUser.Text = "" Then
            txtUser.Text = "Username/Email"
        End If
    End Sub
    Private Sub PassDataFocus(sender As Object, e As RoutedEventArgs) Handles txtPass.GotFocus
        If txtPassVisible.Text = "Password" Then
            txtPass.Password = ""
        End If
    End Sub
    Private Sub PassDataFocus1(sender As Object, e As RoutedEventArgs) Handles txtPassVisible.GotFocus
        txtPass.Visibility = Visibility.Visible
        txtPassVisible.Visibility = Visibility.Hidden
        If txtPassVisible.Text = "Password" Then
            txtPass.Password = ""
            txtPassVisible.Text = ""
        End If
        txtPass.Focus()
    End Sub

    Private Sub PassDataLostFocus(sender As Object, e As RoutedEventArgs) Handles txtPass.LostFocus
        If txtPass.Password = "" Then
            txtPassVisible.Visibility = Visibility.Visible
            txtPass.Visibility = Visibility.Hidden
            txtPassVisible.Text = "Password"
        Else
            txtPassVisible.Visibility = Visibility.Hidden
            txtPass.Visibility = Visibility.Visible
            txtPassVisible.Text = ""
        End If
    End Sub



    Private Sub ImgShowHide_MouseDown(ByVal sender As System.Object, ByVal e As MouseButtonEventArgs)
        If txtPassVisible.Text <> "Password" Then
            ShowPassword()
        End If
    End Sub

    Private Sub ImgShowHide_MouseEnter(ByVal sender As System.Object, ByVal e As MouseEventArgs)
        If txtPassVisible.Text <> "Password" Then
            ShowPassword()
        End If
    End Sub

    Private Sub ImgShowHide_MouseUp(ByVal sender As System.Object, ByVal e As MouseButtonEventArgs)
        If txtPassVisible.Text <> "Password" Then
            HidePassword()
        End If
    End Sub

    Private Sub ImgShowHide_MouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs)
        If txtPassVisible.Text <> "Password" Then
            HidePassword()
        End If

    End Sub

    Private Sub ShowPassword()
        ImgShowHide.Source = New BitmapImage(New Uri("C:\Users\User\source\repos\MoneyManagerPt1\MoneyManagerPt1\images\passwordLock1.png"))
        txtPassVisible.Visibility = Windows.Visibility.Visible
        txtPass.Visibility = Windows.Visibility.Hidden
        txtPassVisible.Text = txtPass.Password
    End Sub

    Private Sub HidePassword()
        ImgShowHide.Source = New BitmapImage(New Uri("C:\Users\User\source\repos\MoneyManagerPt1\MoneyManagerPt1\images\passwordUnlock1.png"))
        txtPassVisible.Visibility = Windows.Visibility.Hidden
        txtPass.Visibility = Windows.Visibility.Visible
        txtPass.Focus()
    End Sub

    Private Sub txtPasswordbox_PasswordChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If txtPass.Password.Length > 0 Then
            ImgShowHide.Visibility = Windows.Visibility.Visible
        Else
            ImgShowHide.Visibility = Windows.Visibility.Hidden
        End If
    End Sub

    Private Sub RegisterButton_Click(sender As Object, e As RoutedEventArgs)
        Dim window As New RegistrationWindow
        window.Show()
    End Sub

#End Region

End Class
