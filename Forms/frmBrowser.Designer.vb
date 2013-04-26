<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowser))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdBack = New System.Windows.Forms.ToolStripButton()
        Me.cmdForward = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdHome = New System.Windows.Forms.ToolStripButton()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.cmdStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtUrl = New System.Windows.Forms.ToolStripTextBox()
        Me.cmdGo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 25)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(4)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(27, 28)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(617, 390)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdBack, Me.cmdForward, Me.ToolStripSeparator2, Me.cmdHome, Me.cmdRefresh, Me.cmdStop, Me.ToolStripSeparator1, Me.txtUrl, Me.cmdGo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(617, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdBack
        '
        Me.cmdBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdBack.Image = CType(resources.GetObject("cmdBack.Image"), System.Drawing.Image)
        Me.cmdBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(23, 22)
        Me.cmdBack.Text = "Back"
        '
        'cmdForward
        '
        Me.cmdForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdForward.Image = CType(resources.GetObject("cmdForward.Image"), System.Drawing.Image)
        Me.cmdForward.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdForward.Name = "cmdForward"
        Me.cmdForward.Size = New System.Drawing.Size(23, 22)
        Me.cmdForward.Text = "Forward"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdHome
        '
        Me.cmdHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdHome.Image = CType(resources.GetObject("cmdHome.Image"), System.Drawing.Image)
        Me.cmdHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHome.Name = "cmdHome"
        Me.cmdHome.Size = New System.Drawing.Size(23, 22)
        Me.cmdHome.Text = "Home"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(23, 22)
        Me.cmdRefresh.Text = "Refresh"
        '
        'cmdStop
        '
        Me.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdStop.Image = CType(resources.GetObject("cmdStop.Image"), System.Drawing.Image)
        Me.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(23, 22)
        Me.cmdStop.Text = "Stop"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'txtUrl
        '
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(100, 25)
        '
        'cmdGo
        '
        Me.cmdGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdGo.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdGo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(23, 22)
        Me.cmdGo.Text = "Go"
        '
        'frmBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 417)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBrowser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmBrowser"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdForward As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdHome As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtUrl As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents cmdGo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
