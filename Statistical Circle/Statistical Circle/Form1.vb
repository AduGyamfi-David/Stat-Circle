Public Class Form1
    Dim Results(9, 2) As Single
    Dim PanelArray(99) As Panel
    Dim Avg(2) As Single
    Dim Points(99) As Single
    Dim Base As Short = 50

    Dim WithEvents GraphPanel As New Panel With {
            .BackColor = Color.White
    }
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Randomize()

        Dim Circle(Form2.NUMBER_OF_POINTS) As Point
        Console.WriteLine(Points.Length)

        'For i = 0 To Points.Length
        '    Dim p As Point = Points(i).Location
        'Next

        GraphPanel.Parent = Me
        GraphPanel.Location = New Point(Me.Width - 1000, 0)
        GraphPanel.Width = 1000
        GraphPanel.Height = 620
        GraphPanel.SendToBack()

        Dim Answer As New Label With {
            .Parent = GraphPanel,
            .Location = New Point(300, 300),
            .Width = 100,
            .Height = 50,
            .AutoSize = True,
            .Font = New Font("Sans Serif", 31, FontStyle.Bold)
        }

        'Dim g As Graphics = GraphPanel.CreateGraphics()

        Dim CircleCount As Short = 0

        For i = 0 To Form2.NUMBER_OF_POINTS - 1
            Dim NormalizedPoint As New Point(Form2.Hits(i).Location.X - Form2.WIDTH_BOUND, Form2.Hits(i).Location.Y - Form2.HEIGHT_BOUND)

            Console.WriteLine(NormalizedPoint.X.ToString() + " " + NormalizedPoint.Y.ToString())

            If (Math.Sqrt(NormalizedPoint.X ^ 2 + NormalizedPoint.Y ^ 2) < 200) Then
                Circle(CircleCount) = NormalizedPoint
                CircleCount += 1
            End If

            Answer.Text = 4 * (CircleCount / Form2.NUMBER_OF_POINTS)
        Next

        'g.DrawLine(New Pen(Color.Black, 5), New Point(550, 0), New Point(550, Me.Height))

        'For j = 1 To 100

        '    For i = 0 To 9

        '        ReDim PanelArray((j * Base) - 1)

        '        Hits(Base * j)

        '        CalcProb(i)

        '    Next

        'MsgBox(Results(0, 0) & ", " & Results(0, 1) & ", " & Results(0, 2) & vbNewLine &
        '       Results(1, 0) & ", " & Results(1, 1) & ", " & Results(1, 2) & vbNewLine &
        '       Results(2, 0) & ", " & Results(2, 1) & ", " & Results(2, 2) & vbNewLine &
        '       Results(3, 0) & ", " & Results(3, 1) & ", " & Results(3, 2) & vbNewLine &
        '       Results(4, 0) & ", " & Results(4, 1) & ", " & Results(4, 2) & vbNewLine &
        '       Results(5, 0) & ", " & Results(5, 1) & ", " & Results(5, 2) & vbNewLine &
        '       Results(6, 0) & ", " & Results(6, 1) & ", " & Results(6, 2) & vbNewLine &
        '       Results(7, 0) & ", " & Results(7, 1) & ", " & Results(7, 2) & vbNewLine &
        '       Results(8, 0) & ", " & Results(8, 1) & ", " & Results(8, 2) & vbNewLine &
        '       Results(9, 0) & ", " & Results(9, 1) & ", " & Results(9, 2))

        'For i = 0 To 9

        '        Avg(0) += Results(i, 0)
        '        Avg(1) += Results(i, 1)
        '        Avg(2) += Results(i, 2)

        '    Next

        '    Avg(0) = Avg(0) / 10
        '    Avg(1) = Avg(1) / 10
        '    Avg(2) = Avg(2) / 10

        '    Points(j - 1) = Avg(0)

        'Next

        'MsgBox(Points(0) & vbNewLine & Points(1) & vbNewLine & Points(2) & vbNewLine & Points(3) & vbNewLine & Points(4) & vbNewLine &
        '       Points(5) & vbNewLine & Points(6) & vbNewLine & Points(7) & vbNewLine & Points(8) & vbNewLine & Points(9) & vbNewLine &
        '       Points(10) & vbNewLine & Points(11) & vbNewLine & Points(12) & vbNewLine & Points(13) & vbNewLine & Points(14) & vbNewLine &
        '       Points(15) & vbNewLine & Points(16) & vbNewLine & Points(17) & vbNewLine & Points(18) & vbNewLine & Points(19) & vbNewLine &
        '       Points(20) & vbNewLine & Points(21) & vbNewLine & Points(22) & vbNewLine & Points(23) & vbNewLine & Points(24) & vbNewLine &
        '       Points(25) & vbNewLine & Points(26) & vbNewLine & Points(27) & vbNewLine & Points(28) & vbNewLine & Points(29) & vbNewLine &
        '       Points(30) & vbNewLine & Points(31) & vbNewLine & Points(32) & vbNewLine & Points(33) & vbNewLine & Points(34) & vbNewLine &
        '       Points(35) & vbNewLine & Points(36) & vbNewLine & Points(37) & vbNewLine & Points(38) & vbNewLine & Points(39) & vbNewLine &
        '       Points(40) & vbNewLine & Points(41) & vbNewLine & Points(42) & vbNewLine & Points(43) & vbNewLine & Points(44) & vbNewLine &
        '       Points(45) & vbNewLine & Points(46) & vbNewLine & Points(47) & vbNewLine & Points(48) & vbNewLine & Points(49))

        'Plot()

        'LoBF()

    End Sub
    'Private Sub MyPaint(s As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

    '    DrawAxes(e)

    '    'e.Graphics.DrawEllipse(Pens.Black, New Rectangle(125, 125, 400, 400))

    'End Sub

    Private Sub DrawingAxes(s As Object, e As PaintEventArgs) Handles GraphPanel.Paint
        e.Graphics.DrawLine(Pens.Black, New Point(20, 0), New Point(20, Me.Height))
        e.Graphics.DrawLine(Pens.Black, New Point(0, GraphPanel.Height - 20), New Point(Me.Width, GraphPanel.Height - 20))
    End Sub

    Private Sub AddAxisNumbers()

    End Sub
    Private Sub Hits(N As Integer)
        For i = 0 To N - 1
            PanelArray(i) = New Panel
            Dim Hit As New Panel With {
                .Width = 1,
                .Height = 1,
                .Location = New Point(Int(Rnd() * 400 + 125), Int(Rnd() * 400 + 125)),
                .BackColor = Color.Red}
            'Hit.Parent = Me
            PanelArray(i) = Hit
        Next
    End Sub
    Private Sub CalcProb(index As Byte)
        Dim O As Integer = 0
        Dim I As Integer = 0
        'MsgBox(Me.Controls.Count)
        'MsgBox(Me.Controls(0).ToString)
        For looper = 0 To PanelArray.Length - 1
            If Math.Sqrt(((PanelArray(looper).Location.X - 325) ^ 2) + ((PanelArray(looper).Location.Y - 325) ^ 2)) > 200 Then
                O += 1
            Else
                I += 1
            End If
        Next
        Results(index, 0) = I / O
        Results(index, 1) = I
        Results(index, 2) = O
        'MsgBox("In/Out Ratio = " & I / O & vbNewLine &
        '       "In = " & I & " out of 1000" & vbNewLine &
        '       "Out = " & O & " out of 1000")
    End Sub
    Private Sub Plot()

        For i = 0 To 99

            Dim Point As New Panel With {
                .Width = 5,
                .Height = 5,
                .Location = New Point(10 + (i + 1) * 12, 640 - ((Math.Round(Points(i), 2) - 3) * 400)),
                .BackColor = Color.MediumVioletRed}
            Point.Parent = Me

        Next

    End Sub
    Private Sub LoBF()
        Dim HitAvg As Single
        For i = 0 To Points.Length - 1
            HitAvg += Points(i)
        Next
        HitAvg = HitAvg / Points.Length

    End Sub
End Class
'panels are of from their actual location be a factor = the panels width / 2, and its height / 2
'algorithm for line of best fit, and display details
'to do this algorithm, need to find mean height of points, then pick that as middle
'then considering this, find residuals from each point, and plot a line through all these points
'may do a second line, excluding the mean
