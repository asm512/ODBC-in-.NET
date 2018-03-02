Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Timers
Imports System.Windows.Threading

Class MainWindow
    Public Shared _odbcConnection As New Odbc.OdbcConnection("DRIVER={MySQL ODBC 5.3 ANSI Driver};SERVER=localhost;PORT=3306;DATABASE=hogwarts;USER=root;PASSWORD=root;OPTION=3;")
    Public Shared _dataReader As Odbc.OdbcDataReader
    Public Shared loggedIn As Boolean = False
    Private Shared WithEvents _timer As New Forms.Timer()
    Dim hasLoggedIn As Boolean = False

    Private Sub MetroWindow_Loaded(sender As Object, e As RoutedEventArgs)
        Dim lPage As New loginPage()
        mainwindowGrid.Children.Add(lPage)

        Dim dt As DispatcherTimer = New DispatcherTimer()
        AddHandler dt.Tick, AddressOf dispatcherTimer_Tick
        dt.Interval = New TimeSpan(0, 0, CInt(0.5))
        dt.Start()
    End Sub

    Public Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If (hasLoggedIn = True) Then
            Return
        End If
        If (loggedIn = True) Then
            mainwindowGrid.Children.Clear()
            Dim dashboardUC As New Dashboard()
            mainwindowGrid.Children.Add(dashboardUC)
            hasLoggedIn = True
        End If

    End Sub

    Private Sub ShowDashboard()
        mainwindowGrid.Children.Clear()
    End Sub

End Class