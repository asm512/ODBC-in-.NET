Public Class Dashboard
    Private Sub addStudentButton_Click(sender As Object, e As RoutedEventArgs)
        mainGrid.Children.Clear()
        Dim addUser As New AddUser()
        mainGrid.Children.Add(addUser)
    End Sub
End Class
