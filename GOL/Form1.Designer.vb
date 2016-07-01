<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TimerLoop = New System.Windows.Forms.Timer(Me.components)
        Me.BottomPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_MapH = New System.Windows.Forms.Label()
        Me.MapH = New System.Windows.Forms.TrackBar()
        Me.lbl_MapW = New System.Windows.Forms.Label()
        Me.MapW = New System.Windows.Forms.TrackBar()
        Me.ShowGrid = New System.Windows.Forms.CheckBox()
        Me.btn_LoadState = New System.Windows.Forms.Button()
        Me.btn_SaveState = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btn_Load = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.RenderSpeed = New System.Windows.Forms.TrackBar()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BottomPanel.SuspendLayout()
        CType(Me.MapH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MapW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RenderSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerLoop
        '
        Me.TimerLoop.Enabled = True
        Me.TimerLoop.Interval = 10
        '
        'BottomPanel
        '
        Me.BottomPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BottomPanel.Controls.Add(Me.Label1)
        Me.BottomPanel.Controls.Add(Me.lbl_MapH)
        Me.BottomPanel.Controls.Add(Me.MapH)
        Me.BottomPanel.Controls.Add(Me.lbl_MapW)
        Me.BottomPanel.Controls.Add(Me.MapW)
        Me.BottomPanel.Controls.Add(Me.ShowGrid)
        Me.BottomPanel.Controls.Add(Me.btn_LoadState)
        Me.BottomPanel.Controls.Add(Me.btn_SaveState)
        Me.BottomPanel.Controls.Add(Me.ProgressBar1)
        Me.BottomPanel.Controls.Add(Me.btn_Load)
        Me.BottomPanel.Controls.Add(Me.btn_Save)
        Me.BottomPanel.Controls.Add(Me.RenderSpeed)
        Me.BottomPanel.Location = New System.Drawing.Point(0, 817)
        Me.BottomPanel.Name = "BottomPanel"
        Me.BottomPanel.Size = New System.Drawing.Size(1406, 30)
        Me.BottomPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(985, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Speed"
        '
        'lbl_MapH
        '
        Me.lbl_MapH.AutoSize = True
        Me.lbl_MapH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MapH.ForeColor = System.Drawing.Color.White
        Me.lbl_MapH.Location = New System.Drawing.Point(713, 9)
        Me.lbl_MapH.Name = "lbl_MapH"
        Me.lbl_MapH.Size = New System.Drawing.Size(59, 13)
        Me.lbl_MapH.TabIndex = 11
        Me.lbl_MapH.Text = "Height(0)"
        '
        'MapH
        '
        Me.MapH.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MapH.AutoSize = False
        Me.MapH.LargeChange = 100
        Me.MapH.Location = New System.Drawing.Point(783, 5)
        Me.MapH.Maximum = 800
        Me.MapH.Minimum = 50
        Me.MapH.Name = "MapH"
        Me.MapH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MapH.RightToLeftLayout = True
        Me.MapH.Size = New System.Drawing.Size(196, 22)
        Me.MapH.SmallChange = 25
        Me.MapH.TabIndex = 10
        Me.MapH.TabStop = False
        Me.MapH.TickFrequency = 50
        Me.MapH.Value = 50
        '
        'lbl_MapW
        '
        Me.lbl_MapW.AutoSize = True
        Me.lbl_MapW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MapW.ForeColor = System.Drawing.Color.White
        Me.lbl_MapW.Location = New System.Drawing.Point(443, 9)
        Me.lbl_MapW.Name = "lbl_MapW"
        Me.lbl_MapW.Size = New System.Drawing.Size(55, 13)
        Me.lbl_MapW.TabIndex = 9
        Me.lbl_MapW.Text = "Width(0)"
        '
        'MapW
        '
        Me.MapW.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MapW.AutoSize = False
        Me.MapW.LargeChange = 100
        Me.MapW.Location = New System.Drawing.Point(513, 5)
        Me.MapW.Maximum = 800
        Me.MapW.Minimum = 50
        Me.MapW.Name = "MapW"
        Me.MapW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MapW.RightToLeftLayout = True
        Me.MapW.Size = New System.Drawing.Size(196, 22)
        Me.MapW.SmallChange = 20
        Me.MapW.TabIndex = 7
        Me.MapW.TabStop = False
        Me.MapW.TickFrequency = 50
        Me.MapW.Value = 50
        '
        'ShowGrid
        '
        Me.ShowGrid.AutoSize = True
        Me.ShowGrid.ForeColor = System.Drawing.Color.White
        Me.ShowGrid.Location = New System.Drawing.Point(362, 8)
        Me.ShowGrid.Name = "ShowGrid"
        Me.ShowGrid.Size = New System.Drawing.Size(75, 17)
        Me.ShowGrid.TabIndex = 6
        Me.ShowGrid.TabStop = False
        Me.ShowGrid.Text = "Show Grid"
        Me.ShowGrid.UseVisualStyleBackColor = True
        '
        'btn_LoadState
        '
        Me.btn_LoadState.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_LoadState.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_LoadState.FlatAppearance.BorderSize = 0
        Me.btn_LoadState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LoadState.ForeColor = System.Drawing.Color.White
        Me.btn_LoadState.Location = New System.Drawing.Point(263, 4)
        Me.btn_LoadState.Name = "btn_LoadState"
        Me.btn_LoadState.Size = New System.Drawing.Size(93, 23)
        Me.btn_LoadState.TabIndex = 5
        Me.btn_LoadState.TabStop = False
        Me.btn_LoadState.Text = "Load State (F2)"
        Me.btn_LoadState.UseVisualStyleBackColor = False
        '
        'btn_SaveState
        '
        Me.btn_SaveState.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_SaveState.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_SaveState.FlatAppearance.BorderSize = 0
        Me.btn_SaveState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SaveState.ForeColor = System.Drawing.Color.White
        Me.btn_SaveState.Location = New System.Drawing.Point(165, 4)
        Me.btn_SaveState.Name = "btn_SaveState"
        Me.btn_SaveState.Size = New System.Drawing.Size(92, 23)
        Me.btn_SaveState.TabIndex = 4
        Me.btn_SaveState.TabStop = False
        Me.btn_SaveState.Text = "Save State (F1)"
        Me.btn_SaveState.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Green
        Me.ProgressBar1.Location = New System.Drawing.Point(1232, 4)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(171, 23)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False
        '
        'btn_Load
        '
        Me.btn_Load.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Load.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Load.FlatAppearance.BorderSize = 0
        Me.btn_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Load.ForeColor = System.Drawing.Color.White
        Me.btn_Load.Location = New System.Drawing.Point(84, 4)
        Me.btn_Load.Name = "btn_Load"
        Me.btn_Load.Size = New System.Drawing.Size(75, 23)
        Me.btn_Load.TabIndex = 2
        Me.btn_Load.TabStop = False
        Me.btn_Load.Text = "Load"
        Me.btn_Load.UseVisualStyleBackColor = False
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_Save.FlatAppearance.BorderSize = 0
        Me.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Save.ForeColor = System.Drawing.Color.White
        Me.btn_Save.Location = New System.Drawing.Point(3, 4)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.TabStop = False
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = False
        '
        'RenderSpeed
        '
        Me.RenderSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RenderSpeed.AutoSize = False
        Me.RenderSpeed.LargeChange = 20
        Me.RenderSpeed.Location = New System.Drawing.Point(1034, 4)
        Me.RenderSpeed.Maximum = 200
        Me.RenderSpeed.Minimum = 1
        Me.RenderSpeed.Name = "RenderSpeed"
        Me.RenderSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RenderSpeed.Size = New System.Drawing.Size(196, 22)
        Me.RenderSpeed.SmallChange = 10
        Me.RenderSpeed.TabIndex = 0
        Me.RenderSpeed.TabStop = False
        Me.RenderSpeed.TickFrequency = 10
        Me.RenderSpeed.Value = 40
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 847)
        Me.Controls.Add(Me.BottomPanel)
        Me.MinimumSize = New System.Drawing.Size(1422, 886)
        Me.Name = "Form1"
        Me.Text = "Game Of Life .NET"
        Me.BottomPanel.ResumeLayout(False)
        Me.BottomPanel.PerformLayout()
        CType(Me.MapH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MapW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RenderSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TimerLoop As Timer
    Friend WithEvents BottomPanel As Panel
    Friend WithEvents RenderSpeed As TrackBar
    Friend WithEvents btn_Save As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btn_Load As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btn_LoadState As Button
    Friend WithEvents btn_SaveState As Button
    Friend WithEvents ShowGrid As CheckBox
    Friend WithEvents lbl_MapW As Label
    Friend WithEvents MapW As TrackBar
    Friend WithEvents lbl_MapH As Label
    Friend WithEvents MapH As TrackBar
    Friend WithEvents Label1 As Label
End Class
