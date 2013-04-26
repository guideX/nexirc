<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerFolder
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
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFile = New System.Windows.Forms.MenuStrip
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HowToUseThisWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cboNetwork = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.lstServers = New System.Windows.Forms.ListBox
        Me.mnuFile.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'mnuFile
        '
        Me.mnuFile.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.mnuFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.mnuFile.Location = New System.Drawing.Point(0, 0)
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(289, 24)
        Me.mnuFile.TabIndex = 24
        Me.mnuFile.Text = "mnu"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToUseThisWindowToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HowToUseThisWindowToolStripMenuItem
        '
        Me.HowToUseThisWindowToolStripMenuItem.Enabled = False
        Me.HowToUseThisWindowToolStripMenuItem.Name = "HowToUseThisWindowToolStripMenuItem"
        Me.HowToUseThisWindowToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.HowToUseThisWindowToolStripMenuItem.Text = "How to use this Window"
        '
        'cboNetwork
        '
        Me.cboNetwork.FormattingEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(8, 42)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.Size = New System.Drawing.Size(195, 21)
        Me.cboNetwork.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Network:"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(210, 101)
        Me.cmdRemove.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(71, 26)
        Me.cmdRemove.TabIndex = 21
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(210, 190)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(71, 26)
        Me.cmdClose.TabIndex = 19
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(210, 69)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(71, 26)
        Me.cmdAdd.TabIndex = 18
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'lstServers
        '
        Me.lstServers.FormattingEnabled = True
        Me.lstServers.Location = New System.Drawing.Point(8, 69)
        Me.lstServers.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.lstServers.Name = "lstServers"
        Me.lstServers.Size = New System.Drawing.Size(195, 147)
        Me.lstServers.TabIndex = 16
        '
        'frmServerFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 224)
        Me.Controls.Add(Me.mnuFile)
        Me.Controls.Add(Me.cboNetwork)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.lstServers)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmServerFolder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Server Folder"
        Me.mnuFile.ResumeLayout(False)
        Me.mnuFile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HowToUseThisWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboNetwork As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents lstServers As System.Windows.Forms.ListBox
End Class
