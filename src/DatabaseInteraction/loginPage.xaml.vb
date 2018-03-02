Imports System.Data
Imports System.IO
Imports System.ComponentModel

Public Class LoginPage
    Dim WithEvents _bgWorker As BackgroundWorker = New BackgroundWorker()
    Dim username As String
    Dim password As String
    Dim loginSuccess As Boolean

    Private Sub UserControl_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.Key = Key.Enter) Then
            loginButton_Click()
        End If
    End Sub

    Private Sub loginButton_Click(Optional sender As Object = Nothing, Optional e As RoutedEventArgs = Nothing) Handles loginButton.Click
        loginProgressRing.Visibility = Visibility.Visible
        username = usernameTextbox.Text
        password = passwordTextbox.Password.ToString()
        _bgWorker.RunWorkerAsync()
    End Sub

    Sub AttemptLoginAsync(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles _bgWorker.DoWork
        Dim conn As New Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=hogwarts;USER=root;PASSWORD=root;OPTION=3;")
        Dim rs As Odbc.OdbcDataReader
        Dim sql As New Odbc.OdbcCommand($"select password from users where username = '{username}' and password = '{password}'", conn)

        Try
            conn.Open()
            rs = sql.ExecuteReader
        Catch
            'Temporary notification
            MessageBox.Show("err")
            Return
        End Try
        If rs.Read() Then
            loginSuccess = True
        Else
            'Display error somewhere
            loginSuccess = False
        End If
        conn.Close()
    End Sub
    Private Sub bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _bgWorker.RunWorkerCompleted
        loginProgressRing.Visibility = Visibility.Hidden
        'Invoke the method in the MainWindow instance
        MainWindow.loggedIn = loginSuccess
    End Sub

End Class