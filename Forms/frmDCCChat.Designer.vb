<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDCCChat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDCCChat))
        Me.txtIncoming = New System.Windows.Forms.RichTextBox()
        Me.txtOutgoing = New System.Windows.Forms.TextBox()
        Me.tlsDCCChat = New System.Windows.Forms.ToolStrip()
        Me.cmdConnect = New System.Windows.Forms.ToolStripButton()
        Me.cmdDisconnect = New System.Windows.Forms.ToolStripButton()
        Me.tlsSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboUsers = New System.Windows.Forms.ToolStripComboBox()
        Me.txtIncomingNoColor = New System.Windows.Forms.TextBox()
        Me.tlsDCCChat.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIncoming
        '
        Me.txtIncoming.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIncoming.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtIncoming.Location = New System.Drawing.Point(0, 25)
        Me.txtIncoming.Name = "txtIncoming"
        Me.txtIncoming.Size = New System.Drawing.Size(334, 90)
        Me.txtIncoming.TabIndex = 1
        Me.txtIncoming.Text = ""
        '
        'txtOutgoing
        '
        Me.txtOutgoing.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtOutgoing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 124)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(334, 14)
        Me.txtOutgoing.TabIndex = 0
        '
        'tlsDCCChat
        '
        Me.tlsDCCChat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlsDCCChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdConnect, Me.cmdDisconnect, Me.tlsSep1, Me.cboUsers})
        Me.tlsDCCChat.Location = New System.Drawing.Point(0, 0)
        Me.tlsDCCChat.Name = "tlsDCCChat"
        Me.tlsDCCChat.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsDCCChat.Size = New System.Drawing.Size(346, 25)
        Me.tlsDCCChat.TabIndex = 2
        Me.tlsDCCChat.Text = "ToolStrip1"
        '
        'cmdConnect
        '
        Me.cmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdConnect.Image = CType(resources.GetObject("cmdConnect.Image"), System.Drawing.Image)
        Me.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(51, 22)
        Me.cmdConnect.Text = "Connect"
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdDisconnect.Enabled = False
        Me.cmdDisconnect.Image = CType(resources.GetObject("cmdDisconnect.Image"), System.Drawing.Image)
        Me.cmdDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Size = New System.Drawing.Size(63, 22)
        Me.cmdDisconnect.Text = "Disconnect"
        '
        'tlsSep1
        '
        Me.tlsSep1.Name = "tlsSep1"
        Me.tlsSep1.Size = New System.Drawing.Size(6, 25)
        '
        'cboUsers
        '
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(121, 25)
        '
        'txtIncomingNoColor
        '
        Me.txtIncomingNoColor.Location = New System.Drawing.Point(0, 25)
        Me.txtIncomingNoColor.Multiline = True
        Me.txtIncomingNoColor.Name = "txtIncomingNoColor"
        Me.txtIncomingNoColor.Size = New System.Drawing.Size(334, 90)
        Me.txtIncomingNoColor.TabIndex = 3
        Me.txtIncomingNoColor.Visible = False
        '
        'frmDCCChat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(346, 150)
        Me.Controls.Add(Me.tlsDCCChat)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.txtIncoming)
        Me.Controls.Add(Me.txtIncomingNoColor)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmDCCChat"
        Me.Text = "DCC Chat"
        Me.tlsDCCChat.ResumeLayout(False)
        Me.tlsDCCChat.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIncoming As System.Windows.Forms.RichTextBox
    Friend WithEvents txtOutgoing As System.Windows.Forms.TextBox
    Friend WithEvents tlsDCCChat As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdDisconnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlsSep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtIncomingNoColor As System.Windows.Forms.TextBox
    Friend WithEvents cboUsers As System.Windows.Forms.ToolStripComboBox
End Class
