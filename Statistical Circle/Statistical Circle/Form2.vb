Public Class Form2
    Dim Hits() As Panel
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        Dim Stats As New Button With {
            .Width = 200,
            .Height = 50,
            .Location = New Point(Me.Width - 200, Me.Height - 75),
            .Text = "SEE STATS"}

        AddPoints()
    End Sub

    Private Sub AddPoints()
        For i = 1 To 100
            Dim Hit As New Panel With {
                .Width = 5,
                .Height = 5,
                .Location = New Point(Rnd() * Me.Width, Rnd() * Me.Height),
                .Parent = Me,
                .BackColor = Color.Black
            }
        Next

    End Sub
End Class