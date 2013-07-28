<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuerySettings
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkAutoShowWindow = New System.Windows.Forms.CheckBox()
        Me.chkPromptUser = New System.Windows.Forms.CheckBox()
        Me.chkSpamFilter = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDeclineMessage = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStandbyMessage = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAutoDeny3 = New System.Windows.Forms.RadioButton()
        Me.optAutoDeny2 = New System.Windows.Forms.RadioButton()
        Me.optAutoDeny1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optAutoAllow3 = New System.Windows.Forms.RadioButton()
        Me.optAutoAllow2 = New System.Windows.Forms.RadioButton()
        Me.optAutoAllow1 = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstAutoAllowList = New System.Windows.Forms.ListBox()
        Me.cmdAddToAutoAllowList = New System.Windows.Forms.Button()
        Me.cmdRemoveFromAutoAllowList = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lstAutoDenyList = New System.Windows.Forms.ListBox()
        Me.cmdAddToAutoDenyList = New System.Windows.Forms.Button()
        Me.cmdRemoveFromAutoDenyList = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtQueryLog = New System.Windows.Forms.RichTextBox()
        Me.lstConnections = New System.Windows.Forms.ListBox()
        Me.cmdClearLog = New System.Windows.Forms.Button()
        Me.lstQueryLog = New System.Windows.Forms.ListBox()
        Me.picLog = New System.Windows.Forms.PictureBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.cmdAddToSpamPhrases = New System.Windows.Forms.Button()
        Me.cmdRemoveFromSpamPhrases = New System.Windows.Forms.Button()
        Me.lstSpamPhrases = New System.Windows.Forms.ListBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.mnuFile = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseThisWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.picLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.mnuFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(446, 206)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage1.Controls.Add(Me.chkAutoShowWindow)
        Me.TabPage1.Controls.Add(Me.chkPromptUser)
        Me.TabPage1.Controls.Add(Me.chkSpamFilter)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDeclineMessage)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtStandbyMessage)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(438, 180)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Options"
        '
        'chkAutoShowWindow
        '
        Me.chkAutoShowWindow.AutoSize = True
        Me.chkAutoShowWindow.Location = New System.Drawing.Point(9, 121)
        Me.chkAutoShowWindow.Name = "chkAutoShowWindow"
        Me.chkAutoShowWindow.Size = New System.Drawing.Size(118, 17)
        Me.chkAutoShowWindow.TabIndex = 9
        Me.chkAutoShowWindow.Text = "Auto show Window"
        Me.chkAutoShowWindow.UseVisualStyleBackColor = True
        '
        'chkPromptUser
        '
        Me.chkPromptUser.AutoSize = True
        Me.chkPromptUser.Location = New System.Drawing.Point(9, 139)
        Me.chkPromptUser.Name = "chkPromptUser"
        Me.chkPromptUser.Size = New System.Drawing.Size(146, 17)
        Me.chkPromptUser.TabIndex = 13
        Me.chkPromptUser.Text = "Prompt me on new query"
        Me.chkPromptUser.UseVisualStyleBackColor = True
        '
        'chkSpamFilter
        '
        Me.chkSpamFilter.AutoSize = True
        Me.chkSpamFilter.Location = New System.Drawing.Point(9, 157)
        Me.chkSpamFilter.Name = "chkSpamFilter"
        Me.chkSpamFilter.Size = New System.Drawing.Size(114, 17)
        Me.chkSpamFilter.TabIndex = 12
        Me.chkSpamFilter.Text = "Enable Spam Filter"
        Me.chkSpamFilter.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Decline Message:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDeclineMessage
        '
        Me.txtDeclineMessage.Location = New System.Drawing.Point(105, 33)
        Me.txtDeclineMessage.Name = "txtDeclineMessage"
        Me.txtDeclineMessage.Size = New System.Drawing.Size(233, 21)
        Me.txtDeclineMessage.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Standby Message:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStandbyMessage
        '
        Me.txtStandbyMessage.Location = New System.Drawing.Point(105, 6)
        Me.txtStandbyMessage.Name = "txtStandbyMessage"
        Me.txtStandbyMessage.Size = New System.Drawing.Size(233, 21)
        Me.txtStandbyMessage.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAutoDeny3)
        Me.GroupBox2.Controls.Add(Me.optAutoDeny2)
        Me.GroupBox2.Controls.Add(Me.optAutoDeny1)
        Me.GroupBox2.Location = New System.Drawing.Point(344, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(88, 80)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Auto Deny"
        '
        'optAutoDeny3
        '
        Me.optAutoDeny3.AutoSize = True
        Me.optAutoDeny3.Location = New System.Drawing.Point(8, 54)
        Me.optAutoDeny3.Name = "optAutoDeny3"
        Me.optAutoDeny3.Size = New System.Drawing.Size(59, 17)
        Me.optAutoDeny3.TabIndex = 11
        Me.optAutoDeny3.TabStop = True
        Me.optAutoDeny3.Text = "No one"
        Me.optAutoDeny3.UseVisualStyleBackColor = True
        '
        'optAutoDeny2
        '
        Me.optAutoDeny2.AutoSize = True
        Me.optAutoDeny2.Location = New System.Drawing.Point(8, 37)
        Me.optAutoDeny2.Name = "optAutoDeny2"
        Me.optAutoDeny2.Size = New System.Drawing.Size(71, 17)
        Me.optAutoDeny2.TabIndex = 10
        Me.optAutoDeny2.TabStop = True
        Me.optAutoDeny2.Text = "Everyone"
        Me.optAutoDeny2.UseVisualStyleBackColor = True
        '
        'optAutoDeny1
        '
        Me.optAutoDeny1.AutoSize = True
        Me.optAutoDeny1.Location = New System.Drawing.Point(8, 20)
        Me.optAutoDeny1.Name = "optAutoDeny1"
        Me.optAutoDeny1.Size = New System.Drawing.Size(41, 17)
        Me.optAutoDeny1.TabIndex = 9
        Me.optAutoDeny1.TabStop = True
        Me.optAutoDeny1.Text = "List"
        Me.optAutoDeny1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optAutoAllow3)
        Me.GroupBox1.Controls.Add(Me.optAutoAllow2)
        Me.GroupBox1.Controls.Add(Me.optAutoAllow1)
        Me.GroupBox1.Location = New System.Drawing.Point(344, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(88, 83)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto allow"
        '
        'optAutoAllow3
        '
        Me.optAutoAllow3.AutoSize = True
        Me.optAutoAllow3.Location = New System.Drawing.Point(8, 54)
        Me.optAutoAllow3.Name = "optAutoAllow3"
        Me.optAutoAllow3.Size = New System.Drawing.Size(59, 17)
        Me.optAutoAllow3.TabIndex = 8
        Me.optAutoAllow3.TabStop = True
        Me.optAutoAllow3.Text = "No one"
        Me.optAutoAllow3.UseVisualStyleBackColor = True
        '
        'optAutoAllow2
        '
        Me.optAutoAllow2.AutoSize = True
        Me.optAutoAllow2.Location = New System.Drawing.Point(8, 37)
        Me.optAutoAllow2.Name = "optAutoAllow2"
        Me.optAutoAllow2.Size = New System.Drawing.Size(71, 17)
        Me.optAutoAllow2.TabIndex = 7
        Me.optAutoAllow2.TabStop = True
        Me.optAutoAllow2.Text = "Everyone"
        Me.optAutoAllow2.UseVisualStyleBackColor = True
        '
        'optAutoAllow1
        '
        Me.optAutoAllow1.AutoSize = True
        Me.optAutoAllow1.Location = New System.Drawing.Point(8, 20)
        Me.optAutoAllow1.Name = "optAutoAllow1"
        Me.optAutoAllow1.Size = New System.Drawing.Size(41, 17)
        Me.optAutoAllow1.TabIndex = 6
        Me.optAutoAllow1.TabStop = True
        Me.optAutoAllow1.Text = "List"
        Me.optAutoAllow1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage2.Controls.Add(Me.lstAutoAllowList)
        Me.TabPage2.Controls.Add(Me.cmdAddToAutoAllowList)
        Me.TabPage2.Controls.Add(Me.cmdRemoveFromAutoAllowList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(438, 180)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Auto Allow List"
        '
        'lstAutoAllowList
        '
        Me.lstAutoAllowList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAutoAllowList.FormattingEnabled = True
        Me.lstAutoAllowList.IntegralHeight = False
        Me.lstAutoAllowList.Location = New System.Drawing.Point(6, 6)
        Me.lstAutoAllowList.Name = "lstAutoAllowList"
        Me.lstAutoAllowList.Size = New System.Drawing.Size(426, 139)
        Me.lstAutoAllowList.TabIndex = 3
        '
        'cmdAddToAutoAllowList
        '
        Me.cmdAddToAutoAllowList.Location = New System.Drawing.Point(276, 151)
        Me.cmdAddToAutoAllowList.Name = "cmdAddToAutoAllowList"
        Me.cmdAddToAutoAllowList.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddToAutoAllowList.TabIndex = 2
        Me.cmdAddToAutoAllowList.Text = "Add"
        Me.cmdAddToAutoAllowList.UseVisualStyleBackColor = True
        '
        'cmdRemoveFromAutoAllowList
        '
        Me.cmdRemoveFromAutoAllowList.Location = New System.Drawing.Point(357, 151)
        Me.cmdRemoveFromAutoAllowList.Name = "cmdRemoveFromAutoAllowList"
        Me.cmdRemoveFromAutoAllowList.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemoveFromAutoAllowList.TabIndex = 1
        Me.cmdRemoveFromAutoAllowList.Text = "Remove"
        Me.cmdRemoveFromAutoAllowList.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage3.Controls.Add(Me.lstAutoDenyList)
        Me.TabPage3.Controls.Add(Me.cmdAddToAutoDenyList)
        Me.TabPage3.Controls.Add(Me.cmdRemoveFromAutoDenyList)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(438, 180)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Auto Deny List"
        '
        'lstAutoDenyList
        '
        Me.lstAutoDenyList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstAutoDenyList.FormattingEnabled = True
        Me.lstAutoDenyList.IntegralHeight = False
        Me.lstAutoDenyList.Location = New System.Drawing.Point(6, 6)
        Me.lstAutoDenyList.Name = "lstAutoDenyList"
        Me.lstAutoDenyList.Size = New System.Drawing.Size(426, 139)
        Me.lstAutoDenyList.TabIndex = 6
        '
        'cmdAddToAutoDenyList
        '
        Me.cmdAddToAutoDenyList.Location = New System.Drawing.Point(276, 151)
        Me.cmdAddToAutoDenyList.Name = "cmdAddToAutoDenyList"
        Me.cmdAddToAutoDenyList.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddToAutoDenyList.TabIndex = 5
        Me.cmdAddToAutoDenyList.Text = "Add"
        Me.cmdAddToAutoDenyList.UseVisualStyleBackColor = True
        '
        'cmdRemoveFromAutoDenyList
        '
        Me.cmdRemoveFromAutoDenyList.Location = New System.Drawing.Point(357, 151)
        Me.cmdRemoveFromAutoDenyList.Name = "cmdRemoveFromAutoDenyList"
        Me.cmdRemoveFromAutoDenyList.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemoveFromAutoDenyList.TabIndex = 4
        Me.cmdRemoveFromAutoDenyList.Text = "Remove"
        Me.cmdRemoveFromAutoDenyList.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage4.Controls.Add(Me.txtQueryLog)
        Me.TabPage4.Controls.Add(Me.lstConnections)
        Me.TabPage4.Controls.Add(Me.cmdClearLog)
        Me.TabPage4.Controls.Add(Me.lstQueryLog)
        Me.TabPage4.Controls.Add(Me.picLog)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(438, 180)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Log"
        '
        'txtQueryLog
        '
        Me.txtQueryLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQueryLog.Location = New System.Drawing.Point(167, 5)
        Me.txtQueryLog.Name = "txtQueryLog"
        Me.txtQueryLog.Size = New System.Drawing.Size(266, 141)
        Me.txtQueryLog.TabIndex = 10
        Me.txtQueryLog.Text = ""
        '
        'lstConnections
        '
        Me.lstConnections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstConnections.FormattingEnabled = True
        Me.lstConnections.IntegralHeight = False
        Me.lstConnections.Location = New System.Drawing.Point(5, 5)
        Me.lstConnections.Name = "lstConnections"
        Me.lstConnections.Size = New System.Drawing.Size(83, 141)
        Me.lstConnections.TabIndex = 9
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Location = New System.Drawing.Point(357, 151)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearLog.TabIndex = 2
        Me.cmdClearLog.Text = "Clear"
        Me.cmdClearLog.UseVisualStyleBackColor = True
        '
        'lstQueryLog
        '
        Me.lstQueryLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstQueryLog.FormattingEnabled = True
        Me.lstQueryLog.IntegralHeight = False
        Me.lstQueryLog.Location = New System.Drawing.Point(89, 5)
        Me.lstQueryLog.Name = "lstQueryLog"
        Me.lstQueryLog.Size = New System.Drawing.Size(77, 141)
        Me.lstQueryLog.TabIndex = 0
        '
        'picLog
        '
        Me.picLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.picLog.Location = New System.Drawing.Point(4, 4)
        Me.picLog.Name = "picLog"
        Me.picLog.Size = New System.Drawing.Size(430, 143)
        Me.picLog.TabIndex = 11
        Me.picLog.TabStop = False
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TabPage5.Controls.Add(Me.cmdAddToSpamPhrases)
        Me.TabPage5.Controls.Add(Me.cmdRemoveFromSpamPhrases)
        Me.TabPage5.Controls.Add(Me.lstSpamPhrases)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(438, 180)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Spam Phrases"
        '
        'cmdAddToSpamPhrases
        '
        Me.cmdAddToSpamPhrases.Location = New System.Drawing.Point(276, 151)
        Me.cmdAddToSpamPhrases.Name = "cmdAddToSpamPhrases"
        Me.cmdAddToSpamPhrases.Size = New System.Drawing.Size(75, 23)
        Me.cmdAddToSpamPhrases.TabIndex = 2
        Me.cmdAddToSpamPhrases.Text = "Add"
        Me.cmdAddToSpamPhrases.UseVisualStyleBackColor = True
        '
        'cmdRemoveFromSpamPhrases
        '
        Me.cmdRemoveFromSpamPhrases.Location = New System.Drawing.Point(357, 151)
        Me.cmdRemoveFromSpamPhrases.Name = "cmdRemoveFromSpamPhrases"
        Me.cmdRemoveFromSpamPhrases.Size = New System.Drawing.Size(75, 23)
        Me.cmdRemoveFromSpamPhrases.TabIndex = 1
        Me.cmdRemoveFromSpamPhrases.Text = "Remove"
        Me.cmdRemoveFromSpamPhrases.UseVisualStyleBackColor = True
        '
        'lstSpamPhrases
        '
        Me.lstSpamPhrases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstSpamPhrases.FormattingEnabled = True
        Me.lstSpamPhrases.IntegralHeight = False
        Me.lstSpamPhrases.Location = New System.Drawing.Point(6, 6)
        Me.lstSpamPhrases.Name = "lstSpamPhrases"
        Me.lstSpamPhrases.Size = New System.Drawing.Size(426, 139)
        Me.lstSpamPhrases.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(383, 239)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(302, 239)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'mnuFile
        '
        Me.mnuFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.mnuFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuFile.Location = New System.Drawing.Point(0, 0)
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(470, 24)
        Me.mnuFile.TabIndex = 8
        Me.mnuFile.Text = "mnu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToUseThisWindowToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        Me.HelpToolStripMenuItem.Visible = False
        '
        'HowToUseThisWindowToolStripMenuItem
        '
        Me.HowToUseThisWindowToolStripMenuItem.Enabled = False
        Me.HowToUseThisWindowToolStripMenuItem.Name = "HowToUseThisWindowToolStripMenuItem"
        Me.HowToUseThisWindowToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.HowToUseThisWindowToolStripMenuItem.Text = "How to use this Window"
        '
        'frmQuerySettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 267)
        Me.Controls.Add(Me.mnuFile)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuerySettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Query Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        CType(Me.picLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.mnuFile.ResumeLayout(False)
        Me.mnuFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optAutoAllow3 As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoAllow2 As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoAllow1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optAutoDeny3 As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoDeny2 As System.Windows.Forms.RadioButton
    Friend WithEvents optAutoDeny1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStandbyMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDeclineMessage As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents chkSpamFilter As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cmdAddToAutoAllowList As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveFromAutoAllowList As System.Windows.Forms.Button
    Friend WithEvents cmdAddToAutoDenyList As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveFromAutoDenyList As System.Windows.Forms.Button
    Friend WithEvents chkPromptUser As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cmdClearLog As System.Windows.Forms.Button
    Friend WithEvents lstQueryLog As System.Windows.Forms.ListBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdAddToSpamPhrases As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveFromSpamPhrases As System.Windows.Forms.Button
    Friend WithEvents lstSpamPhrases As System.Windows.Forms.ListBox
    Friend WithEvents lstAutoAllowList As System.Windows.Forms.ListBox
    Friend WithEvents lstAutoDenyList As System.Windows.Forms.ListBox
    Friend WithEvents lstConnections As System.Windows.Forms.ListBox
    Friend WithEvents txtQueryLog As System.Windows.Forms.RichTextBox
    Friend WithEvents picLog As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoShowWindow As System.Windows.Forms.CheckBox
    Friend WithEvents mnuFile As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HowToUseThisWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
