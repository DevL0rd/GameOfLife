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
    Private W_Cubes As Integer = 0
    Private H_Cubes As Integer = 0
    Private Cubes As Integer = 100
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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        InitGraphics()
        GenerateNewMap()
        IsLoading = False
        TimerLoop.Interval = 40
        TimerLoop.Enabled = True
        TimerLoop.Start()
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
        H_Cubes = Cubes
        W_Cubes = Cubes
        xIndex = 0
        ReDim CubeStates(900, 900)
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                CubeStates(xIndex, yIndex) = False
                yIndex += 1
            End While
            xIndex += 1
        End While
        Halfx = Cubes / 2
        Halfy = Halfx
    End Sub
    Sub InitGraphics()
        'Initialize graphics
        G = CreateGraphics()
        BB = New Bitmap(Width - 15, Height - 39 - BottomBar.Height)
        BBG = CreateGraphics()
    End Sub
    Private StateBKUP(900, 900) As Boolean
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
        While xIndex <= W_Cubes + 2
            yIndex = 0
            writeIni(FilePath, "WorldData", "Cubes", Cubes)
            writeIni(FilePath, "WorldData", "W_Cubes", W_Cubes)
            writeIni(FilePath, "WorldData", "H_Cubes", H_Cubes)
            writeIni(FilePath, "WorldData", "xInterval", xInterval)
            writeIni(FilePath, "WorldData", "yInterval", yInterval)
            writeIni(FilePath, "WorldData", "MapX", MapX)
            writeIni(FilePath, "WorldData", "MapY", MapY)
            While yIndex <= H_Cubes + 2
                writeIni(FilePath, xIndex & "-" & yIndex, "IsLive", CubeStates(xIndex, yIndex).ToString)
                yIndex += 1
            End While
            xIndex += 1
        End While
    End Sub
    Sub LoadFile(FilePath As String)
        xIndex = 0
        Cubes = ReadIni(FilePath, "WorldData", "Cubes", "")
        W_Cubes = ReadIni(FilePath, "WorldData", "W_Cubes", "")
        H_Cubes = ReadIni(FilePath, "WorldData", "H_Cubes", "")
        xInterval = ReadIni(FilePath, "WorldData", "xInterval", "")
        yInterval = ReadIni(FilePath, "WorldData", "yInterval", "")
        MapX = ReadIni(FilePath, "WorldData", "MapX", "")
        MapY = ReadIni(FilePath, "WorldData", "MapY", "")
        While xIndex <= W_Cubes + 2
            yIndex = 0
            While yIndex <= H_Cubes + 2
                CubeStates(xIndex, yIndex) = CBool(ReadIni(FilePath, xIndex & "-" & yIndex, "IsLive", ""))
                yIndex += 1
            End While
            xIndex += 1
        End While
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
        While xIndex <= W_Cubes - 1
            myx = MapX + (xIndex * xInterval)
            If IsPaused Then
                If xIndex = Halfx Or xIndex = Halfx + 1 Then
                    G.DrawLine(Pens.Red, New Point(myx, MapY + yInterval), New Point(myx, MapY + (yInterval * H_Cubes)))
                Else
                    G.DrawLine(Pens.DarkGray, New Point(myx, MapY + yInterval), New Point(myx, MapY + (yInterval * H_Cubes)))
                End If

            End If
            yIndex = 1
            While yIndex <= H_Cubes - 1S
                myy = MapY + (yIndex * yInterval)
                If IsPaused Then
                    If yIndex = Halfy Or yIndex = Halfy + 1 Then
                        G.DrawLine(Pens.Red, New Point(MapX + xInterval, myy), New Point(MapX + (xInterval * W_Cubes), myy))
                    Else
                        G.DrawLine(Pens.DarkGray, New Point(MapX + xInterval, myy), New Point(MapX + (xInterval * W_Cubes), myy))
                    End If
                End If
                If CubeStates(xIndex, yIndex) = True Then

                    G.FillEllipse(Brushes.LightGreen, myx, myy, xInterval, yInterval)
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
        G.Clear(Color.Black)
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

                BKUPStates()
                IsPaused = False
                TimerLoop.Interval = RenderSpeed.Value

            Else
                TimerLoop.Interval = 1
                RESTstates()
                IsPaused = True
            End If
        ElseIf e.KeyValue = Keys.C Then
            TimerLoop.Interval = 1
            GenerateNewMap()
        ElseIf e.KeyValue = Keys.F1 Then
            SaveFile(BIN & "QuickSave.GOL")
        ElseIf e.KeyValue = Keys.F2 Then
            IsPaused = True
            LoadFile(BIN & "QuickSave.GOL")
            BKUPStates()
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
            MapX -= W_Cubes / xInterval
            MapY -= H_Cubes / yInterval
        ElseIf e.Delta < 0 Then
            xInterval -= 1
            yInterval -= 1
            MapX += W_Cubes / xInterval
            MapY += H_Cubes / yInterval
        End If
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        SaveFileDialog1.Filter = "GOL Files (*.GOL*)|*.GOL"
        SaveFileDialog1.InitialDirectory = BIN
        SaveFileDialog1.FileName = ".GOL"
        SaveFileDialog1.ShowDialog()
        Dim wasteofspacetousefilename As String = SaveFileDialog1.FileName
        SaveFile(SaveFileDialog1.FileName)
        ActiveControl = Nothing
    End Sub

    Private Sub btn_Load_Click(sender As Object, e As EventArgs) Handles btn_Load.Click
        OpenFileDialog1.Filter = "GOL Files (*.GOL*)|*.GOL"
        OpenFileDialog1.InitialDirectory = BIN
        OpenFileDialog1.FileName = ".GOL"
        OpenFileDialog1.ShowDialog()
        Dim wasteofspacetousefilename As String = OpenFileDialog1.FileName
        If System.IO.File.Exists(OpenFileDialog1.FileName) Then
            LoadFile(OpenFileDialog1.FileName)
        End If
        ActiveControl = Nothing
    End Sub
End Class
