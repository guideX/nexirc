'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Public Class frmVideoPlayer
    Inherits System.Windows.Forms.Form
    Private WithEvents lVideo As clsVideo
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        lVideo = New clsVideo
        lVideo.Parent = PnlVideo
        lVideo.BackColor = Color.Black
        lVideo.Location = New Point(0, 0)
        lVideo.Size = PnlVideo.ClientSize
        lVideo.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    ' Friend WithEvents ApiVideo1 As ApiVideo

    Friend WithEvents TmrDisplay As System.Timers.Timer
    Friend WithEvents TrackOffset As System.Windows.Forms.TrackBar
    Friend WithEvents PnlOffset As System.Windows.Forms.Panel
    Friend WithEvents PnlAudio As System.Windows.Forms.Panel
    Friend WithEvents LblBalance As System.Windows.Forms.Label
    Friend WithEvents LblVolume As System.Windows.Forms.Label
    Friend WithEvents ChkMuteRight As System.Windows.Forms.CheckBox
    Friend WithEvents ChkMuteLeft As System.Windows.Forms.CheckBox
    Friend WithEvents TrackVolume As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBalance As System.Windows.Forms.TrackBar
    Friend WithEvents PnlVideo As System.Windows.Forms.Panel
    Friend WithEvents tspTop As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPlay As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPause As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdResume As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrackSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdControls As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdRepeat As System.Windows.Forms.ToolStripButton
    Friend WithEvents LblSpeed As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TmrDisplay = New System.Timers.Timer()
        Me.TrackOffset = New System.Windows.Forms.TrackBar()
        Me.PnlOffset = New System.Windows.Forms.Panel()
        Me.PnlAudio = New System.Windows.Forms.Panel()
        Me.LblSpeed = New System.Windows.Forms.Label()
        Me.TrackSpeed = New System.Windows.Forms.TrackBar()
        Me.ChkMuteLeft = New System.Windows.Forms.CheckBox()
        Me.TrackVolume = New System.Windows.Forms.TrackBar()
        Me.LblBalance = New System.Windows.Forms.Label()
        Me.LblVolume = New System.Windows.Forms.Label()
        Me.ChkMuteRight = New System.Windows.Forms.CheckBox()
        Me.TrackBalance = New System.Windows.Forms.TrackBar()
        Me.PnlVideo = New System.Windows.Forms.Panel()
        Me.tspTop = New System.Windows.Forms.ToolStrip()
        Me.cmdOpen = New System.Windows.Forms.ToolStripButton()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdPlay = New System.Windows.Forms.ToolStripButton()
        Me.cmdStop = New System.Windows.Forms.ToolStripButton()
        Me.cmdRepeat = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdPause = New System.Windows.Forms.ToolStripButton()
        Me.cmdResume = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdControls = New System.Windows.Forms.ToolStripButton()
        Me.lblTime = New System.Windows.Forms.ToolStripLabel()
        CType(Me.TmrDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlOffset.SuspendLayout()
        Me.PnlAudio.SuspendLayout()
        CType(Me.TrackSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tspTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'TmrDisplay
        '
        Me.TmrDisplay.Interval = 333.0R
        Me.TmrDisplay.SynchronizingObject = Me
        '
        'TrackOffset
        '
        Me.TrackOffset.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackOffset.BackColor = System.Drawing.SystemColors.Control
        Me.TrackOffset.Location = New System.Drawing.Point(0, 1)
        Me.TrackOffset.Maximum = 0
        Me.TrackOffset.Name = "TrackOffset"
        Me.TrackOffset.Size = New System.Drawing.Size(531, 42)
        Me.TrackOffset.TabIndex = 0
        Me.TrackOffset.TickFrequency = 0
        Me.TrackOffset.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'PnlOffset
        '
        Me.PnlOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlOffset.Controls.Add(Me.TrackOffset)
        Me.PnlOffset.Location = New System.Drawing.Point(0, 387)
        Me.PnlOffset.Name = "PnlOffset"
        Me.PnlOffset.Size = New System.Drawing.Size(527, 34)
        Me.PnlOffset.TabIndex = 1
        '
        'PnlAudio
        '
        Me.PnlAudio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PnlAudio.BackColor = System.Drawing.SystemColors.Control
        Me.PnlAudio.Controls.Add(Me.LblSpeed)
        Me.PnlAudio.Controls.Add(Me.TrackSpeed)
        Me.PnlAudio.Controls.Add(Me.ChkMuteLeft)
        Me.PnlAudio.Controls.Add(Me.TrackVolume)
        Me.PnlAudio.Controls.Add(Me.LblBalance)
        Me.PnlAudio.Controls.Add(Me.LblVolume)
        Me.PnlAudio.Controls.Add(Me.ChkMuteRight)
        Me.PnlAudio.Controls.Add(Me.TrackBalance)
        Me.PnlAudio.Location = New System.Drawing.Point(0, 28)
        Me.PnlAudio.Name = "PnlAudio"
        Me.PnlAudio.Size = New System.Drawing.Size(88, 356)
        Me.PnlAudio.TabIndex = 2
        '
        'LblSpeed
        '
        Me.LblSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSpeed.AutoSize = True
        Me.LblSpeed.ForeColor = System.Drawing.Color.Black
        Me.LblSpeed.Location = New System.Drawing.Point(10, 150)
        Me.LblSpeed.Name = "LblSpeed"
        Me.LblSpeed.Size = New System.Drawing.Size(37, 13)
        Me.LblSpeed.TabIndex = 8
        Me.LblSpeed.Text = "Speed"
        '
        'TrackSpeed
        '
        Me.TrackSpeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackSpeed.BackColor = System.Drawing.SystemColors.Control
        Me.TrackSpeed.Location = New System.Drawing.Point(3, 166)
        Me.TrackSpeed.Maximum = 2000
        Me.TrackSpeed.Minimum = 1
        Me.TrackSpeed.Name = "TrackSpeed"
        Me.TrackSpeed.Size = New System.Drawing.Size(82, 42)
        Me.TrackSpeed.TabIndex = 7
        Me.TrackSpeed.TickFrequency = 100
        Me.TrackSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackSpeed.Value = 1000
        '
        'ChkMuteLeft
        '
        Me.ChkMuteLeft.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ChkMuteLeft.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.ChkMuteLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ChkMuteLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ChkMuteLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ChkMuteLeft.ForeColor = System.Drawing.Color.Black
        Me.ChkMuteLeft.Location = New System.Drawing.Point(13, 104)
        Me.ChkMuteLeft.Name = "ChkMuteLeft"
        Me.ChkMuteLeft.Size = New System.Drawing.Size(88, 24)
        Me.ChkMuteLeft.TabIndex = 4
        Me.ChkMuteLeft.Text = "Mute Left"
        '
        'TrackVolume
        '
        Me.TrackVolume.BackColor = System.Drawing.SystemColors.Control
        Me.TrackVolume.Location = New System.Drawing.Point(3, 75)
        Me.TrackVolume.Maximum = 1000
        Me.TrackVolume.Name = "TrackVolume"
        Me.TrackVolume.Size = New System.Drawing.Size(82, 42)
        Me.TrackVolume.TabIndex = 3
        Me.TrackVolume.TickFrequency = 100
        Me.TrackVolume.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackVolume.Value = 500
        '
        'LblBalance
        '
        Me.LblBalance.AutoSize = True
        Me.LblBalance.ForeColor = System.Drawing.Color.Black
        Me.LblBalance.Location = New System.Drawing.Point(10, 11)
        Me.LblBalance.Name = "LblBalance"
        Me.LblBalance.Size = New System.Drawing.Size(44, 13)
        Me.LblBalance.TabIndex = 3
        Me.LblBalance.Text = "Balance"
        '
        'LblVolume
        '
        Me.LblVolume.AutoSize = True
        Me.LblVolume.ForeColor = System.Drawing.Color.Black
        Me.LblVolume.Location = New System.Drawing.Point(10, 56)
        Me.LblVolume.Name = "LblVolume"
        Me.LblVolume.Size = New System.Drawing.Size(41, 13)
        Me.LblVolume.TabIndex = 4
        Me.LblVolume.Text = "Volume"
        '
        'ChkMuteRight
        '
        Me.ChkMuteRight.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ChkMuteRight.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.ChkMuteRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.ChkMuteRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.ChkMuteRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ChkMuteRight.ForeColor = System.Drawing.Color.Black
        Me.ChkMuteRight.Location = New System.Drawing.Point(13, 123)
        Me.ChkMuteRight.Name = "ChkMuteRight"
        Me.ChkMuteRight.Size = New System.Drawing.Size(88, 24)
        Me.ChkMuteRight.TabIndex = 3
        Me.ChkMuteRight.Text = "Mute Right"
        '
        'TrackBalance
        '
        Me.TrackBalance.BackColor = System.Drawing.SystemColors.Control
        Me.TrackBalance.Location = New System.Drawing.Point(3, 27)
        Me.TrackBalance.Maximum = 1000
        Me.TrackBalance.Name = "TrackBalance"
        Me.TrackBalance.Size = New System.Drawing.Size(82, 42)
        Me.TrackBalance.TabIndex = 3
        Me.TrackBalance.TickFrequency = 250
        Me.TrackBalance.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBalance.Value = 500
        '
        'PnlVideo
        '
        Me.PnlVideo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlVideo.BackColor = System.Drawing.SystemColors.Control
        Me.PnlVideo.Location = New System.Drawing.Point(91, 28)
        Me.PnlVideo.Name = "PnlVideo"
        Me.PnlVideo.Size = New System.Drawing.Size(436, 356)
        Me.PnlVideo.TabIndex = 4
        '
        'tspTop
        '
        Me.tspTop.BackColor = System.Drawing.SystemColors.Control
        Me.tspTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspTop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdOpen, Me.cmdClose, Me.ToolStripSeparator1, Me.cmdPlay, Me.cmdStop, Me.cmdRepeat, Me.ToolStripSeparator2, Me.cmdPause, Me.cmdResume, Me.ToolStripSeparator3, Me.cmdControls, Me.lblTime})
        Me.tspTop.Location = New System.Drawing.Point(0, 0)
        Me.tspTop.Name = "tspTop"
        Me.tspTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tspTop.Size = New System.Drawing.Size(527, 25)
        Me.tspTop.TabIndex = 5
        Me.tspTop.Text = "ToolStrip1"
        '
        'cmdOpen
        '
        Me.cmdOpen.ForeColor = System.Drawing.Color.Black
        Me.cmdOpen.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(37, 22)
        Me.cmdOpen.Text = "Open"
        '
        'cmdClose
        '
        Me.cmdClose.ForeColor = System.Drawing.Color.Black
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(37, 22)
        Me.cmdClose.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdPlay
        '
        Me.cmdPlay.ForeColor = System.Drawing.Color.Black
        Me.cmdPlay.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(31, 22)
        Me.cmdPlay.Text = "Play"
        '
        'cmdStop
        '
        Me.cmdStop.ForeColor = System.Drawing.Color.Black
        Me.cmdStop.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(33, 22)
        Me.cmdStop.Text = "Stop"
        '
        'cmdRepeat
        '
        Me.cmdRepeat.CheckOnClick = True
        Me.cmdRepeat.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdRepeat.Name = "cmdRepeat"
        Me.cmdRepeat.Size = New System.Drawing.Size(46, 22)
        Me.cmdRepeat.Text = "Repeat"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdPause
        '
        Me.cmdPause.ForeColor = System.Drawing.Color.Black
        Me.cmdPause.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(40, 22)
        Me.cmdPause.Text = "Pause"
        '
        'cmdResume
        '
        Me.cmdResume.ForeColor = System.Drawing.Color.Black
        Me.cmdResume.ImageTransparentColor = System.Drawing.Color.White
        Me.cmdResume.Name = "cmdResume"
        Me.cmdResume.Size = New System.Drawing.Size(49, 22)
        Me.cmdResume.Text = "Resume"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'cmdControls
        '
        Me.cmdControls.ForeColor = System.Drawing.Color.Black
        Me.cmdControls.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdControls.Name = "cmdControls"
        Me.cmdControls.Size = New System.Drawing.Size(86, 22)
        Me.cmdControls.Text = "Toggle Controls"
        '
        'lblTime
        '
        Me.lblTime.ForeColor = System.Drawing.Color.Black
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(29, 22)
        Me.lblTime.Text = "Time"
        '
        'frmVideoPlayer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(527, 421)
        Me.Controls.Add(Me.tspTop)
        Me.Controls.Add(Me.PnlVideo)
        Me.Controls.Add(Me.PnlAudio)
        Me.Controls.Add(Me.PnlOffset)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVideoPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC Player"
        CType(Me.TmrDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlOffset.ResumeLayout(False)
        Me.PnlOffset.PerformLayout()
        Me.PnlAudio.ResumeLayout(False)
        Me.PnlAudio.PerformLayout()
        CType(Me.TrackSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tspTop.ResumeLayout(False)
        Me.tspTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub TmrDisplay_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles TmrDisplay.Elapsed
        Dim TotalSec As Long = CLng(lVideo.TotalTime() / 1000)
        Dim CurrentSec As Long = lVideo.CurrentTime()
        If CurrentSec >= TrackOffset.Minimum And CurrentSec <= TrackOffset.Maximum Then
            TrackOffset.Value = CInt(CurrentSec)
        Else
            TrackOffset.Value = TrackOffset.Minimum
        End If
        CurrentSec = CLng(CurrentSec / 1000)
        lblTime.Text = "   Total time = " & CStr(Int(TotalSec / 60)).PadLeft(2, CChar("0")) & ":" & CStr(CInt(TotalSec Mod 60)).PadLeft(2, CChar("0")) & "     Time = " & CStr(Int(CurrentSec / 60)).PadLeft(2, CChar("0")) & ":" & CStr(CInt(CurrentSec Mod 60)).PadLeft(2, CChar("0"))
    End Sub

    Private Sub TrackOffset_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackOffset.Scroll
        Dim Mute As clsVideo.Channels = lVideo.Mute
        lVideo.Mute = clsVideo.Channels.Both
        lVideo.MoveToTime(TrackOffset.Value)
        lVideo.Mute = Mute
    End Sub

    Private Sub ChkMute_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMuteRight.CheckedChanged, ChkMuteLeft.CheckedChanged
        'Try
        If ChkMuteLeft.Checked = True And ChkMuteRight.Checked = True Then
            lVideo.Mute = clsVideo.Channels.Both
        ElseIf ChkMuteLeft.Checked = True And ChkMuteRight.Checked = False Then
            lVideo.Mute = clsVideo.Channels.Left
        ElseIf ChkMuteLeft.Checked = False And ChkMuteRight.Checked = True Then
            lVideo.Mute = clsVideo.Channels.Right
        Else
            lVideo.Mute = clsVideo.Channels.None
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ChkMute_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMuteRight.CheckedChanged, ChkMuteLeft.CheckedChanged")
        'End Try
    End Sub

    Private Sub TrackVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackVolume.Scroll
        'On Error Resume Next
        lVideo.Volume = TrackVolume.Value
    End Sub

    Private Sub TrackBalance_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBalance.Scroll
        'On Error Resume Next
        lVideo.Balance = TrackBalance.Value
    End Sub

    'Private Sub TrackSpeed_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'lVideo.Speed = TrackSpeed.Value
    'End Sub

    'Private Sub BtnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'lVideo.Play()
    'End Sub

    'Private Sub BtnPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'lVideo.Pause()
    'End Sub

    'Private Sub BtnResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'lVideo.Resume()
    'End Sub

    'Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'lVideo.Stop()
    'End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.MdiParent = mdiMain
        TmrDisplay.Enabled = True
    End Sub

    Public Sub OpenAndPlay(ByVal lFileName As String)
        If clsFiles.DoesFileExist(lFileName) = True Then
            lVideo.Open(lFileName)
            If lVideo.TotalTime >= 0 Then
                TrackOffset.Value = 0
                TrackOffset.Minimum = 0
                TrackOffset.Maximum = CInt(lVideo.TotalTime)
            End If
            lVideo.Play()
        End If
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        Dim AskFile As New OpenFileDialog
        AskFile.AddExtension = True
        AskFile.CheckFileExists = True
        AskFile.CheckPathExists = True
        AskFile.Multiselect = False
        AskFile.ShowReadOnly = False
        If AskFile.ShowDialog(Me) = DialogResult.OK Then
            lVideo.Open(AskFile.FileName)
            If lVideo.TotalTime >= 0 Then
                TrackOffset.Value = 0
                TrackOffset.Minimum = 0
                TrackOffset.Maximum = CInt(lVideo.TotalTime)
            End If
            lVideo.Play()
        End If
        AskFile.Dispose()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        lVideo.Close()
    End Sub

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click
        lVideo.Play()
    End Sub

    Private Sub cmdPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPause.Click
        lVideo.Pause()
    End Sub

    Private Sub cmdResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResume.Click
        lVideo.Resume()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        lVideo.Stop()
    End Sub

    Private Sub cmdControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdControls.Click
        If PnlAudio.Visible = True Then
            PnlAudio.Visible = False
            PnlVideo.Left = 0
            PnlVideo.Width = Me.Width
        Else
            PnlAudio.Visible = True
            PnlVideo.Left = 91
            PnlVideo.Width = Me.Width - 91
        End If
    End Sub

    Private Sub cmdRepeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRepeat.Click
        lVideo.Repeat = cmdRepeat.Checked
    End Sub
End Class