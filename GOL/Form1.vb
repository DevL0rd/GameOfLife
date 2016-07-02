Public Class Form1
    '------------------------------------------
    'Graphics Objects
    '------------------------------------------
    Private G As Graphics
    Private BBG As Graphics
    Private BB As Bitmap
    Private tSec As Integer = TimeOfDay.Second
    Private tTicks As Integer = 0
    Private MaxTicks As Integer = 0
    Private IsRunning As Boolean = True
    Private W_Cubes As Integer = 175
    Private H_Cubes As Integer = 100
    Private CubeStates(,) As Boolean
    Private IsPaused As Boolean = True
    Private Mx As Integer = 0
    Private My As Integer = 0
    Private LeftMouse As Boolean = False
    Private RightMouse As Boolean = False
    Private IsLoading As Boolean = True
    Dim yInterval As Integer = 8
    Dim xInterval As Integer = 8
    Dim xIndex As Integer = 0
    Dim yIndex As Integer = 0
    Dim Halfx As Integer = 0
    Dim Halfy As Integer = 0
    Dim myx As Integer = 1
    Dim myy As Integer = 1
    Dim filledcount As Integer = 0
    Public BIN As String = Application.StartupPath & "\Saves\"
    Dim MapX As Integer = 0
    Dim MapY As Integer = 0
    Dim AlgToUse As String = "Default"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        InitGraphics()
        GenerateNewMap()
        IsLoading = False
        TimerLoop.Interval = 40
        TimerLoop.Enabled = True
        TimerLoop.Start()
        Halfx = W_Cubes / 2
        Halfy = H_Cubes / 2
        ProgressBar1.Visible = False
        MapW.Value = W_Cubes
        lbl_MapW.Text = "Width(" & W_Cubes & ")"
        MapH.Value = H_Cubes
        lbl_MapH.Text = "Height(" & H_Cubes & ")"
    End Sub
    Sub GameTick()
        Application.DoEvents()
        If IsPaused = False Then
            ApplyRules()
        End If
        If LeftMouse Then
            HandleLeftMouse()
        ElseIf RightMouse Then
            HandleRightMouse()
        End If
        DrawGraphics()
    End Sub
    Sub GenerateNewMap()
        IsPaused = True

        xIndex = 0
        ReDim CubeStates(900, 900)
        ProgressBar1.Maximum = (W_Cubes + 3) * (H_Cubes + 3)
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                CubeStates(xIndex, yIndex) = False
                CubeAge(xIndex, yIndex) = 0
                ProgressBar1.Value += 1
                yIndex += 1
            End While
            xIndex += 1
        End While
        Halfx = W_Cubes / 2
        Halfy = H_Cubes / 2
        ProgressBar1.Visible = False
        MapW.Value = W_Cubes
        lbl_MapW.Text = "Width(" & W_Cubes & ")"
        MapH.Value = H_Cubes
        lbl_MapH.Text = "Height(" & H_Cubes & ")"
    End Sub
    Sub InitGraphics()
        'Initialize graphics
        G = CreateGraphics()
        BB = New Bitmap(Width - 15, Height - 39 - BottomPanel.Height)
        BBG = CreateGraphics()
    End Sub
    Private StateBKUP(900, 900) As Boolean
    Private CubeAge(900, 900) As Integer
    Sub BKUPStates()
        xIndex = 0
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                StateBKUP(xIndex, yIndex) = CubeStates(xIndex, yIndex)
                yIndex += 1
            End While
            xIndex += 1
        End While
    End Sub
    Sub SaveFile(FilePath As String)
        xIndex = 0
        writeIni(FilePath, "WorldData", "W_Cubes", W_Cubes)
        writeIni(FilePath, "WorldData", "H_Cubes", H_Cubes)
        writeIni(FilePath, "WorldData", "xInterval", xInterval)
        writeIni(FilePath, "WorldData", "yInterval", yInterval)
        writeIni(FilePath, "WorldData", "MapX", MapX)
        writeIni(FilePath, "WorldData", "MapY", MapY)
        writeIni(FilePath, "WorldData", "AlgToUse", AlgToUse)
        ProgressBar1.Maximum = (W_Cubes + 3) * (H_Cubes + 3)
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        While xIndex <= W_Cubes + 2
            yIndex = 0

            While yIndex <= H_Cubes + 2
                writeIni(FilePath, xIndex & "-" & yIndex, "IsLive", CubeStates(xIndex, yIndex).ToString)
                ProgressBar1.Value += 1
                yIndex += 1
            End While
            xIndex += 1
        End While
        ProgressBar1.Visible = False
    End Sub
    Sub LoadFile(FilePath As String)
        xIndex = 0
        W_Cubes = ReadIni(FilePath, "WorldData", "W_Cubes", "")
        H_Cubes = ReadIni(FilePath, "WorldData", "H_Cubes", "")
        xInterval = ReadIni(FilePath, "WorldData", "xInterval", "")
        yInterval = ReadIni(FilePath, "WorldData", "yInterval", "")
        MapX = ReadIni(FilePath, "WorldData", "MapX", "")
        MapY = ReadIni(FilePath, "WorldData", "MapY", "")
        AlgToUse = ReadIni(FilePath, "WorldData", "AlgToUse", "")
        Algorythm.SelectedItem = AlgToUse
        ProgressBar1.Maximum = (W_Cubes + 3) * (H_Cubes + 3)
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Dim thiscount As Integer = 0
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                CubeStates(xIndex, yIndex) = CBool(ReadIni(FilePath, xIndex & "-" & yIndex, "IsLive", ""))
                thiscount += 1
                ProgressBar1.Value += 1
                yIndex += 1
            End While
            xIndex += 1
        End While
        Halfx = W_Cubes / 2
        Halfy = H_Cubes / 2
        MapW.Value = W_Cubes
        lbl_MapW.Text = "Width(" & W_Cubes & ")"
        MapH.Value = H_Cubes
        lbl_MapH.Text = "Height(" & H_Cubes & ")"
        ProgressBar1.Visible = False

    End Sub
    Sub RESTstates()
        xIndex = 0
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                CubeStates(xIndex, yIndex) = StateBKUP(xIndex, yIndex)
                yIndex += 1
            End While
            xIndex += 1
        End While
    End Sub

    Sub ApplyRules()
        xIndex = 1

        Dim NewCubeStates(900, 900) As Boolean
        While xIndex <= W_Cubes - 1
            yIndex = 1
            While yIndex <= H_Cubes - 1

                filledcount = 0

                If CubeStates(xIndex - 1, yIndex - 1) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex, yIndex - 1) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex + 1, yIndex - 1) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex - 1, yIndex) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex + 1, yIndex) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex - 1, yIndex + 1) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex, yIndex + 1) = True Then
                    filledcount += 1
                End If
                If CubeStates(xIndex + 1, yIndex + 1) = True Then
                    filledcount += 1
                End If
                If AlgToUse = "Default" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount < 2 Then
                            NewCubeStates(xIndex, yIndex) = False
                        ElseIf filledcount = 2 Then
                            NewCubeStates(xIndex, yIndex) = True
                        ElseIf filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        ElseIf filledcount > 3 Then
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Live Free or Die" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 0 Then
                            NewCubeStates(xIndex, yIndex) = True
                        ElseIf filledcount > 0 Then
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 2 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Replicator" Then

                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount Mod 2 <> 0 Then
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount Mod 2 <> 0 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Replicator 2" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        filledcount += 1
                        If filledcount Mod 2 <> 0 Then
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount Mod 2 <> 0 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Life Without Death" Then
                    If CubeStates(xIndex, yIndex) = False Then
                        If filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Maze" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount >= 1 AndAlso filledcount <= 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Mazectric" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount >= 1 AndAlso filledcount <= 4 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "2X2" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 1 Or filledcount = 2 Or filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 6 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "High Life" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 2 Or filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 6 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Move" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 2 Or filledcount = 4 Or filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 6 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Day & Night" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 3 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 4 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Seeds" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        NewCubeStates(xIndex, yIndex) = False
                    Else
                        If filledcount = 2 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Amoeba" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 1 Or filledcount = 3 Or filledcount = 5 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 5 Or filledcount = 7 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Assimilation" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 4 Or filledcount = 5 Or filledcount = 6 Or filledcount = 7 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 4 Or filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Coral" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount >= 4 AndAlso filledcount <= 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "34 Life" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 3 Or filledcount = 4 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 4 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Diamoeba" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount >= 5 AndAlso filledcount <= 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 5 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Gnarl" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 1 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 1 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Long life" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 4 Or filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Pseudo life" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 2 Or filledcount = 3 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 5 Or filledcount = 7 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Serviettes" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        NewCubeStates(xIndex, yIndex) = False
                    Else
                        If filledcount = 2 Or filledcount = 3 Or filledcount = 4 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "Stains" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 2 Or filledcount = 3 Or filledcount = 5 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 3 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                ElseIf AlgToUse = "WalledCities" Then
                    If CubeStates(xIndex, yIndex) = True Then
                        If filledcount = 2 Or filledcount = 3 Or filledcount = 4 Or filledcount = 5 Then
                            NewCubeStates(xIndex, yIndex) = True
                        Else
                            NewCubeStates(xIndex, yIndex) = False
                        End If
                    Else
                        If filledcount = 4 Or filledcount = 5 Or filledcount = 6 Or filledcount = 7 Or filledcount = 8 Then
                            NewCubeStates(xIndex, yIndex) = True
                        End If
                    End If
                End If
                yIndex += 1
            End While
            xIndex += 1
        End While
        CubeStates = NewCubeStates
    End Sub
    Private Sub DrawGraphics()
        xIndex = 1
        myx = 0
        myy = 0
        Dim AreaOutline As New Pen(Color.Blue)
        AreaOutline.Width = 2
        G.FillRectangle(New SolidBrush(Color.Black), MapX + xInterval, MapY + yInterval, xInterval * (W_Cubes - 1), yInterval * (H_Cubes - 1))
        While xIndex <= W_Cubes - 1
            myx = MapX + (xIndex * xInterval)

            If ShowGrid.Checked Then
                G.DrawLine(Pens.DarkGray, New Point(myx, MapY + yInterval), New Point(myx, MapY + (yInterval * H_Cubes)))
            End If
            If IsPaused Then
                If xIndex = Halfx Or xIndex = Halfx + 1 Then
                    G.DrawLine(Pens.Blue, New Point(myx, MapY + yInterval), New Point(myx, MapY + (yInterval * H_Cubes)))
                End If
            End If
            yIndex = 1
            While yIndex <= H_Cubes - 1S
                myy = MapY + (yIndex * yInterval)


                If ShowGrid.Checked Then
                    G.DrawLine(Pens.DarkGray, New Point(MapX + xInterval, myy), New Point(MapX + (xInterval * W_Cubes), myy))
                End If
                If IsPaused Then
                    If yIndex = Halfy Or yIndex = Halfy + 1 Then
                        G.DrawLine(Pens.Blue, New Point(MapX + xInterval, myy), New Point(MapX + (xInterval * W_Cubes), myy))
                    End If
                End If
                If CubeStates(xIndex, yIndex) = True Then
                    G.FillEllipse(Brushes.Green, myx + 1, myy + 1, xInterval - 2, yInterval - 2)
                End If

                yIndex += 1
            End While
            xIndex += 1
        End While
        G.DrawRectangle(AreaOutline, MapX + xInterval, MapY + yInterval, xInterval * (W_Cubes - 1), yInterval * (H_Cubes - 1))
        G.DrawString(MaxTicks, Me.Font, Brushes.Red, New Point(1, 1))
        ' DRAW BUFFER TO SCREEN
        G = Graphics.FromImage(BB)
        BBG = CreateGraphics()
        BBG.DrawImage(BB, 0, 0)
        ' FIX OVERDRAW
        If IsPaused Then
            G.Clear(Color.DarkRed)
        Else
            G.Clear(Color.DarkGreen)
        End If

        CountTick()
    End Sub
    Private Sub CountTick()
        'Calculates the number of ticks per second the main loop is running at
        If tSec = TimeOfDay.Second Then
            tTicks = tTicks + 1
        Else
            MaxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
    End Sub
    Sub HandleLeftMouse()
        xIndex = 1
        myx = 0
        myy = 0
        Dim mouserect As New Rectangle(Mx - MapX, My - MapY, 1, 1)
        Dim thisrect As Rectangle
        While xIndex <= W_Cubes - 1
            myx = xIndex * xInterval
            yIndex = 1
            While yIndex <= H_Cubes - 1
                myy = yIndex * yInterval
                thisrect = New Rectangle(myx, myy, xInterval, yInterval)
                If mouserect.IntersectsWith(thisrect) Then
                    If CubeStates(xIndex, yIndex) = False Then
                        CubeStates(xIndex, yIndex) = True
                    End If
                End If

                yIndex += 1
            End While
            xIndex += 1
        End While
    End Sub
    Sub HandleRightMouse()
        xIndex = 1
        myx = 0
        myy = 0
        Dim mouserect As New Rectangle(Mx - MapX, My - MapY, 1, 1)
        Dim thisrect As Rectangle
        While xIndex <= W_Cubes - 1
            myx = xIndex * xInterval
            yIndex = 1
            While yIndex <= H_Cubes - 1
                myy = yIndex * yInterval
                thisrect = New Rectangle(myx, myy, xInterval, yInterval)
                If mouserect.IntersectsWith(thisrect) Then
                    If CubeStates(xIndex, yIndex) = True Then
                        CubeStates(xIndex, yIndex) = False
                    End If
                End If
                yIndex += 1
            End While
            xIndex += 1
        End While
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Space Then
            If IsPaused Then
                IsPaused = False
                TimerLoop.Interval = RenderSpeed.Value
            Else
                TimerLoop.Interval = 1
                IsPaused = True
            End If
        ElseIf e.KeyValue = Keys.C Then
            TimerLoop.Interval = 1
            GenerateNewMap()
        ElseIf e.KeyValue = Keys.F1 Then
            BKUPStates()
        ElseIf e.KeyValue = Keys.F2 Then
            RESTstates()
        ElseIf e.KeyValue = Keys.W Then
            MapY += yInterval
        ElseIf e.KeyValue = Keys.S Then
            MapY -= yInterval
        ElseIf e.KeyValue = Keys.D Then
            MapX -= xInterval
        ElseIf e.KeyValue = Keys.A Then
            MapX += xInterval
        End If
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            LeftMouse = True
        ElseIf e.Button = MouseButtons.Right Then
            RightMouse = True
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            LeftMouse = False
        ElseIf e.Button = MouseButtons.Right Then
            RightMouse = False
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Mx = e.X
        My = e.Y
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        InitGraphics()
    End Sub

    Private Sub TimerLoop_Tick(sender As Object, e As EventArgs) Handles TimerLoop.Tick
        GameTick()
    End Sub

    Private Sub RenderSpeed_Scroll(sender As Object, e As EventArgs) Handles RenderSpeed.Scroll
        TimerLoop.Interval = RenderSpeed.Value
        ActiveControl = Nothing
    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            xInterval += 1
            yInterval += 1
        ElseIf e.Delta < 0 Then
            xInterval -= 1
            yInterval -= 1
            If xInterval = 0 Then
                xInterval = 1
            End If
            If yInterval = 0 Then
                yInterval = 1
            End If
        End If
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        SaveFileDialog1.Filter = "GOL Files (*.GOL*)|*.GOL"
        SaveFileDialog1.InitialDirectory = BIN
        SaveFileDialog1.FileName = ".GOL"
        SaveFileDialog1.ShowDialog()
        Dim wasteofspacetousefilename As String = SaveFileDialog1.FileName
        SaveFile(wasteofspacetousefilename)
        ActiveControl = Nothing
    End Sub

    Private Sub btn_Load_Click(sender As Object, e As EventArgs) Handles btn_Load.Click
        OpenFileDialog1.Filter = "GOL Files (*.GOL*)|*.GOL"
        OpenFileDialog1.InitialDirectory = BIN
        OpenFileDialog1.FileName = ".GOL"
        OpenFileDialog1.ShowDialog()
        Dim wasteofspacetousefilename As String = OpenFileDialog1.FileName
        If System.IO.File.Exists(wasteofspacetousefilename) Then
            LoadFile(wasteofspacetousefilename)
        End If
        ActiveControl = Nothing
    End Sub

    Private Sub btn_SaveState_Click(sender As Object, e As EventArgs) Handles btn_SaveState.Click
        BKUPStates()
        ActiveControl = Nothing
    End Sub

    Private Sub btn_LoadState_Click(sender As Object, e As EventArgs) Handles btn_LoadState.Click
        RESTstates()
        ActiveControl = Nothing
    End Sub

    Private Sub ShowGrid_CheckedChanged(sender As Object, e As EventArgs) Handles ShowGrid.CheckedChanged
        ActiveControl = Nothing
    End Sub

    Private Sub MapW_Scroll(sender As Object, e As EventArgs) Handles MapW.Scroll
        W_Cubes = MapW.Value
        lbl_MapW.Text = "Width(" & W_Cubes & ")"
        Halfx = W_Cubes / 2
        ActiveControl = Nothing
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles MapH.Scroll
        H_Cubes = MapH.Value
        lbl_MapH.Text = "Height(" & H_Cubes & ")"
        Halfy = H_Cubes / 2
        ActiveControl = Nothing
    End Sub

    Private Sub Algorythm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Algorythm.SelectedIndexChanged
        AlgToUse = Algorythm.SelectedItem
        ActiveControl = Nothing
    End Sub
End Class
