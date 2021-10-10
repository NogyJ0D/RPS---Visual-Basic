Public Class Nombre
    Public User As String
    Public Sub BtnNombre_Click(sender As Object, e As EventArgs) Handles BtnNombre.Click
        User = InpNombre.Text

        If String.IsNullOrEmpty(User) = False Then
            Dim Form1 As New Form1
            Form1.Show()
            Me.Close()
        End If
    End Sub
End Class