<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoading
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.prgLoading = New Telerik.WinControls.UI.RadProgressBar()
        Me.lblStatus = New Telerik.WinControls.UI.RadLabel()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        CType(Me.prgLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'prgLoading
        '
        Me.prgLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.prgLoading.ImageIndex = -1
        Me.prgLoading.ImageKey = ""
        Me.prgLoading.ImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.prgLoading.Location = New System.Drawing.Point(12, 36)
        Me.prgLoading.Name = "prgLoading"
        Me.prgLoading.SeparatorColor1 = System.Drawing.Color.White
        Me.prgLoading.SeparatorColor2 = System.Drawing.Color.White
        Me.prgLoading.SeparatorColor3 = System.Drawing.Color.White
        Me.prgLoading.SeparatorColor4 = System.Drawing.Color.White
        Me.prgLoading.Size = New System.Drawing.Size(284, 29)
        Me.prgLoading.TabIndex = 0
        Me.prgLoading.ThemeName = "Office2010Black"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(12, 12)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(64, 18)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Please Wait"
        Me.lblStatus.ThemeName = "Office2010Black"
        '
        'FrmLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 82)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.prgLoading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLoading"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Loading"
        Me.ThemeName = "Office2010Black"
        CType(Me.prgLoading, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents prgLoading As Telerik.WinControls.UI.RadProgressBar
    Friend WithEvents lblStatus As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
End Class

