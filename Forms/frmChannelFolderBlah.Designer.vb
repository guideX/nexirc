<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelFolder1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtChannel = New System.Windows.Forms.TextBox()
        Me.lstChannels = New System.Windows.Forms.ListBox()
        Me.cmdJoin = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.chkPopupOnConnect = New System.Windows.Forms.CheckBox()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNetwork = New System.Windows.Forms.ComboBox()
        Me.mnuFile = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseThisWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkAutoClose = New System.Windows.Forms.CheckBox()
        Me.lnkJumpToChannelList = New System.Windows.Forms.LinkLabel()
        Me.mnuFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter name of channel to join:"
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(11, 40)
        Me.txtChannel.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(195, 21)
        Me.txtChannel.TabIndex = 1
        '
        'lstChannels
        '
        Me.lstChannels.FormattingEnabled = True
        Me.lstChannels.Location = New System.Drawing.Point(11, 104)
        Me.lstChannels.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lstChannels.Name = "lstChannels"
        Me.lstChannels.Size = New System.Drawing.Size(195, 108)
        Me.lstChannels.TabIndex = 2
        '
        'cmdJoin
        '
        Me.cmdJoin.Location = New System.Drawing.Point(213, 40)
        Me.cmdJoin.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdJoin.Name = "cmdJoin"
        Me.cmdJoin.Size = New System.Drawing.Size(71, 26)
        Me.cmdJoin.TabIndex = 3
        Me.cmdJoin.Text = "Join"
        Me.cmdJoin.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdAdd.Location = New System.Drawing.Point(213, 72)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 26)
        Me.cmdAdd.TabIndex = 4
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Location = New System.Drawing.Point(213, 186)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(71, 26)
        Me.cmdClose.TabIndex = 7
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chkPopupOnConnect
        '
        Me.chkPopupOnConnect.AutoSize = True
        Me.chkPopupOnConnect.Location = New System.Drawing.Point(11, 218)
        Me.chkPopupOnConnect.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.chkPopupOnConnect.Name = "chkPopupOnConnect"
        Me.chkPopupOnConnect.Size = New System.Drawing.Size(112, 17)
        Me.chkPopupOnConnect.TabIndex = 8
        Me.chkPopupOnConnect.Text = "Popup on connect"
        Me.chkPopupOnConnect.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(213, 104)
        Me.cmdRemove.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(71, 26)
        Me.cmdRemove.TabIndex = 9
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Network:"
        '
        'cboNetwork
        '
        Me.cboNetwork.FormattingEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(11, 77)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.Size = New System.Drawing.Size(195, 21)
        Me.cboNetwork.TabIndex = 11
        '
        'mnuFile
        '
        Me.mnuFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.mnuFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuFile.Location = New System.Drawing.Point(0, 0)
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(293, 24)
        Me.mnuFile.TabIndex = 12
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
        'chkAutoClose
        '
        Me.chkAutoClose.AutoSize = True
        Me.chkAutoClose.Location = New System.Drawing.Point(11, 234)
        Me.chkAutoClose.Name = "chkAutoClose"
        Me.chkAutoClose.Size = New System.Drawing.Size(89, 17)
        Me.chkAutoClose.TabIndex = 13
        Me.chkAutoClose.Text = "Close on Join"
        Me.chkAutoClose.UseVisualStyleBackColor = True
        '
        'lnkJumpToChannelList
        '
        Me.lnkJumpToChannelList.AutoSize = True
        Me.lnkJumpToChannelList.Location = New System.Drawing.Point(175, 238)
        Me.lnkJumpToChannelList.Name = "lnkJumpToChannelList"
        Me.lnkJumpToChannelList.Size = New System.Drawing.Size(106, 13)
        Me.lnkJumpToChannelList.TabIndex = 14
        Me.lnkJumpToChannelList.TabStop = True
        Me.lnkJumpToChannelList.Text = "Jump to Channel List"
        '
        'frmChannelFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdClose
        Me.ClientSize = New System.Drawing.Size(293, 259)
        Me.Controls.Add(Me.lnkJumpToChannelList)
        Me.Controls.Add(Me.chkAutoClose)
        Me.Controls.Add(Me.mnuFile)
        Me.Controls.Add(Me.cboNetwork)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.chkPopupOnConnect)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdJoin)
        Me.Controls.Add(Me.lstChannels)
        Me.Controls.Add(Me.txtChannel)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChannelFolder"
        Me.Text = "nexIRC - Channel Folder"
        Me.mnuFile.ResumeLayout(False)
        Me.mnuFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtChannel As System.Windows.Forms.TextBox
    Friend WithEvents lstChannels As System.Windows.Forms.ListBox
    Friend WithEvents cmdJoin As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chkPopupOnConnect As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNetwork As System.Windows.Forms.ComboBox
    Friend WithEvents mnuFile As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HowToUseThisWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkAutoClose As System.Windows.Forms.CheckBox
    Friend WithEvents lnkJumpToChannelList As System.Windows.Forms.LinkLabel
End Class
