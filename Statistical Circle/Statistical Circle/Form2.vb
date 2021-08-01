Public Class Form2
    Public Const NUMBER_OF_POINTS As Short = 3000
    Public Hits(NUMBER_OF_POINTS) As Panel
    Public Const WIDTH_BOUND As Short = 300
    Public Const HEIGHT_BOUND As Short = 150
    Public Const SPACE_BOUND As Short = 200
    Private WithEvents Stats As New Button With {
            .Width = 100,
            .Height = 50,
            .Location = New Point(600, 400),
            .Text = "SEE STATS",
            .Parent = Me,
            .Name = "cmdStats"
    }

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        AddBoundaries()
        AddPoints()

    End Sub

    Private Sub AddPoints()

        For i = 1 To NUMBER_OF_POINTS
            Dim Hit As New Panel With {
                .Width = 2,
                .Height = 2,
                .Location = New Point(Math.Round(Rnd() * SPACE_BOUND) + WIDTH_BOUND, Math.Round(Rnd() * SPACE_BOUND) + HEIGHT_BOUND),
                .Parent = Me,
                .BackColor = Color.Red
            }
            Hits(i - 1) = Hit
            Hit.BringToFront()
        Next

    End Sub

    Private Sub AddBoundaries()

        Dim first_vert As New Panel With {
            .Width = 1,
            .Height = Me.Height,
            .Location = New Point(WIDTH_BOUND, 0),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim sec_vert As New Panel With {
            .Width = 1,
            .Height = Me.Height,
            .Location = New Point(WIDTH_BOUND + SPACE_BOUND, 0),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim first_hori As New Panel With {
            .Width = Me.Width,
            .Height = 1,
            .Location = New Point(0, HEIGHT_BOUND),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim sec_hori As New Panel With {
            .Width = Me.Width,
            .Height = 1,
            .Location = New Point(0, HEIGHT_BOUND + SPACE_BOUND),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim circle As New Panel With {
            .Parent = Me,
            .BackColor = Color.Black
        }

        circle.SetBounds(0, 0, SPACE_BOUND, SPACE_BOUND)

        Dim center_shape As New Drawing2D.GraphicsPath
        center_shape.StartFigure()
        center_shape.AddEllipse(circle.Bounds)
        center_shape.CloseFigure()
        circle.SetBounds(1, 1, SPACE_BOUND - 2, SPACE_BOUND - 2)
        center_shape.AddEllipse(circle.Bounds)
        center_shape.CloseAllFigures()

        circle.Region = New Region(center_shape)
        circle.Width = SPACE_BOUND
        circle.Height = SPACE_BOUND
        circle.Location = New Point(WIDTH_BOUND, HEIGHT_BOUND)


        circle.SendToBack()

    End Sub

    Private Sub Next_Form(sender As Object, e As EventArgs) Handles Stats.Click
        Form1.Show()
        Hide()
    End Sub

    Public Function getHits()
        Return Hits
    End Function

    Public Function getBounds()

    End Function
End Class