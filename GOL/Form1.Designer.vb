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
        Me.BottomBar = New System.Windows.Forms.Panel()
        Me.btn_Load = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.RenderSpeed = New System.Windows.Forms.TrackBar()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BottomBar.SuspendLayout()
        CType(Me.RenderSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerLoop
        '
        Me.TimerLoop.Enabled = True
        Me.TimerLoop.Interval = 10
        '
        'BottomBar
        '
        Me.BottomBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BottomBar.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BottomBar.Controls.Add(Me.btn_Load)
        Me.BottomBar.Controls.Add(Me.btn_Save)
        Me.BottomBar.Controls.Add(Me.RenderSpeed)
        Me.BottomBar.Location = New System.Drawing.Point(0, 809)
        Me.BottomBar.Name = "BottomBar"
        Me.BottomBar.Size = New System.Drawing.Size(810, 30)
        Me.BottomBar.TabIndex = 0
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
        Me.btn_Save.Text = "Save"
        Me.btn_Save.UseVisualStyleBackColor = False
        '
        'RenderSpeed
        '
        Me.RenderSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RenderSpeed.AutoSize = False
        Me.RenderSpeed.LargeChange = 20
        Me.RenderSpeed.Location = New System.Drawing.Point(165, 3)
        Me.RenderSpeed.Maximum = 200
        Me.RenderSpeed.Minimum = 1
        Me.RenderSpeed.Name = "RenderSpeed"
        Me.RenderSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RenderSpeed.Size = New System.Drawing.Size(142, 24)
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
        Me.ClientSize = New System.Drawing.Size(810, 839)
        Me.Controls.Add(Me.BottomBar)
        Me.Name = "Form1"
        Me.Text = "Game Of Life .NET"
        Me.BottomBar.ResumeLayout(False)
        CType(Me.RenderSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TimerLoop As Timer
    Friend WithEvents BottomBar As Panel
    Friend WithEvents RenderSpeed As TrackBar
    Friend WithEvents btn_Save As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btn_Load As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
