<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeConnection
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
        Me.chkConnectImmediatly = New System.Windows.Forms.CheckBox()
        Me.chkNewStatusWindow = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboServer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboNetwork = New System.Windows.Forms.ComboBox()
        Me.mnuFile = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseThisWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.mnuFile.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkConnectImmediatly
        '
        Me.chkConnectImmediatly.AutoSize = True
        Me.chkConnectImmediatly.FlatAppearance.BorderSize = 2
        Me.chkConnectImmediatly.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkConnectImmediatly.Location = New System.Drawing.Point(69, 83)
        Me.chkConnectImmediatly.Name = "chkConnectImmediatly"
        Me.chkConnectImmediatly.Size = New System.Drawing.Size(118, 17)
        Me.chkConnectImmediatly.TabIndex = 11
        Me.chkConnectImmediatly.Text = "Connect Immediatly"
        Me.chkConnectImmediatly.UseVisualStyleBackColor = True
        '
        'chkNewStatusWindow
        '
        Me.chkNewStatusWindow.AutoSize = True
        Me.chkNewStatusWindow.FlatAppearance.BorderSize = 2
        Me.chkNewStatusWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNewStatusWindow.Location = New System.Drawing.Point(69, 100)
        Me.chkNewStatusWindow.Name = "chkNewStatusWindow"
        Me.chkNewStatusWindow.Size = New System.Drawing.Size(119, 17)
        Me.chkNewStatusWindow.TabIndex = 10
        Me.chkNewStatusWindow.Text = "New Status Window"
        Me.chkNewStatusWindow.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Server:"
        '
        'cboServer
        '
        Me.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServer.FormattingEnabled = True
        Me.cboServer.Location = New System.Drawing.Point(69, 56)
        Me.cboServer.Name = "cboServer"
        Me.cboServer.Size = New System.Drawing.Size(189, 21)
        Me.cboServer.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Network:"
        '
        'cboNetwork
        '
        Me.cboNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNetwork.FormattingEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(69, 29)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.Size = New System.Drawing.Size(189, 21)
        Me.cboNetwork.TabIndex = 6
        '
        'mnuFile
        '
        Me.mnuFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.mnuFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuFile.Location = New System.Drawing.Point(0, 0)
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(268, 24)
        Me.mnuFile.TabIndex = 15
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
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(88, 123)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(82, 23)
        Me.cmdOK.TabIndex = 17
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Image = Global.nexIRC.My.Resources.Resources.cancel
        Me.cmdCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancel.Location = New System.Drawing.Point(176, 123)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(82, 23)
        Me.cmdCancel.TabIndex = 16
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmChangeConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 151)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.mnuFile)
        Me.Controls.Add(Me.chkConnectImmediatly)
        Me.Controls.Add(Me.chkNewStatusWindow)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboServer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboNetwork)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeConnection"
        Me.Text = "Change Connection"
        Me.mnuFile.ResumeLayout(False)
        Me.mnuFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkConnectImmediatly As System.Windows.Forms.CheckBox
    Friend WithEvents chkNewStatusWindow As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboServer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboNetwork As System.Windows.Forms.ComboBox
    Friend WithEvents mnuFile As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HowToUseThisWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
