Public Class Form2
    Dim Hits(1000) As Panel

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

        AddBoundaries(150, 300)
        AddPoints(150, 300)

    End Sub

    Private Sub AddPoints(height_bound As Short, width_bound As Short)

        For i = 1 To 1000
            Dim Hit As New Panel With {
                .Width = 2,
                .Height = 2,
                .Location = New Point(Math.Round(Rnd() * 200) + width_bound, Math.Round(Rnd() * 200) + height_bound),
                .Parent = Me,
                .BackColor = Color.Red
            }
            Hits(i - 1) = Hit
            Hit.BringToFront()
        Next

    End Sub

    Private Sub AddBoundaries(height As Short, width As Short)

        Dim first_vert As New Panel With {
            .Width = 1,
            .Height = Me.Height,
            .Location = New Point(width, 0),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim sec_vert As New Panel With {
            .Width = 1,
            .Height = Me.Height,
            .Location = New Point(width + 200, 0),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim first_hori As New Panel With {
            .Width = Me.Width,
            .Height = 1,
            .Location = New Point(0, height),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim sec_hori As New Panel With {
            .Width = Me.Width,
            .Height = 1,
            .Location = New Point(0, height + 200),
            .BackColor = Color.Black,
            .Parent = Me
        }

        Dim circle As New Panel With {
            .Parent = Me,
            .BackColor = Color.Black
        }

        circle.SetBounds(0, 0, 200, 200)

        Dim center_shape As New Drawing2D.GraphicsPath
        center_shape.StartFigure()
        center_shape.AddEllipse(circle.Bounds)
        center_shape.CloseFigure()
        circle.SetBounds(1, 1, 198, 198)
        center_shape.AddEllipse(circle.Bounds)
        center_shape.CloseAllFigures()

        circle.Region = New Region(center_shape)
        circle.Width = 200
        circle.Height = 200
        circle.Location = New Point(width, height)


        circle.SendToBack()

    End Sub

    Private Sub Next_Form(sender As Object, e As EventArgs) Handles Stats.Click
        Form1.Show()
        Hide()
    End Sub

    Public Function getHits()
        Return Hits
    End Function
End Class