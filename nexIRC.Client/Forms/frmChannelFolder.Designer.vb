<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelFolder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChannelFolder))
        Me.txtChannel = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.cmdJoin = New Telerik.WinControls.UI.RadButton()
        Me.cmdAdd = New Telerik.WinControls.UI.RadButton()
        Me.cmdRemove = New Telerik.WinControls.UI.RadButton()
        Me.cmdClose = New Telerik.WinControls.UI.RadButton()
        Me.lblNetwork = New Telerik.WinControls.UI.RadLabel()
        Me.cboNetwork = New Telerik.WinControls.UI.RadDropDownList()
        Me.lstChannels = New Telerik.WinControls.UI.RadListControl()
        Me.lnkJumpToChannelList = New System.Windows.Forms.LinkLabel()
        Me.chkPopupOnConnect = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkCloseOnJoin = New Telerik.WinControls.UI.RadCheckBox()
        Me.HighContrastBlackTheme1 = New Telerik.WinControls.Themes.HighContrastBlackTheme()
        Me.Office2010BlackTheme1 = New Telerik.WinControls.Themes.Office2010BlackTheme()
        CType(Me.txtChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdJoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lstChannels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPopupOnConnect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCloseOnJoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(12, 32)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(197, 20)
        Me.txtChannel.TabIndex = 0
        Me.txtChannel.TabStop = False
        Me.txtChannel.ThemeName = "Office2010Black"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(12, 12)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(156, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "Enter name of channel to join:"
        Me.RadLabel1.ThemeName = "Office2010Black"
        '
        'cmdJoin
        '
        Me.cmdJoin.Location = New System.Drawing.Point(220, 78)
        Me.cmdJoin.Name = "cmdJoin"
        Me.cmdJoin.Size = New System.Drawing.Size(76, 24)
        Me.cmdJoin.TabIndex = 1
        Me.cmdJoin.Text = "Join"
        Me.cmdJoin.ThemeName = "Office2010Black"
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(220, 108)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(76, 24)
        Me.cmdAdd.TabIndex = 0
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.ThemeName = "Office2010Black"
        '
        'cmdRemove
        '
        Me.cmdRemove.Location = New System.Drawing.Point(220, 138)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(76, 24)
        Me.cmdRemove.TabIndex = 0
        Me.cmdRemove.Text = "Remove"
        Me.cmdRemove.ThemeName = "Office2010Black"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(220, 221)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(76, 24)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.ThemeName = "Office2010Black"
        '
        'lblNetwork
        '
        Me.lblNetwork.Location = New System.Drawing.Point(12, 58)
        Me.lblNetwork.Name = "lblNetwork"
        Me.lblNetwork.Size = New System.Drawing.Size(51, 18)
        Me.lblNetwork.TabIndex = 2
        Me.lblNetwork.Text = "Network:"
        Me.lblNetwork.ThemeName = "Office2010Black"
        '
        'cboNetwork
        '
        Me.cboNetwork.DropDownAnimationEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(12, 78)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.ShowImageInEditorArea = True
        Me.cboNetwork.Size = New System.Drawing.Size(197, 20)
        Me.cboNetwork.TabIndex = 0
        Me.cboNetwork.ThemeName = "Office2010Black"
        '
        'lstChannels
        '
        Me.lstChannels.CaseSensitiveSort = True
        Me.lstChannels.ItemHeight = 18
        Me.lstChannels.Location = New System.Drawing.Point(12, 108)
        Me.lstChannels.Name = "lstChannels"
        Me.lstChannels.Size = New System.Drawing.Size(197, 137)
        Me.lstChannels.TabIndex = 3
        Me.lstChannels.Text = "Channel Folder"
        Me.lstChannels.ThemeName = "Office2010Black"
        '
        'lnkJumpToChannelList
        '
        Me.lnkJumpToChannelList.AutoSize = True
        Me.lnkJumpToChannelList.Location = New System.Drawing.Point(182, 280)
        Me.lnkJumpToChannelList.Name = "lnkJumpToChannelList"
        Me.lnkJumpToChannelList.Size = New System.Drawing.Size(114, 13)
        Me.lnkJumpToChannelList.TabIndex = 4
        Me.lnkJumpToChannelList.TabStop = True
        Me.lnkJumpToChannelList.Text = "Jump to Channel List"
        '
        'chkPopupOnConnect
        '
        Me.chkPopupOnConnect.Location = New System.Drawing.Point(12, 251)
        Me.chkPopupOnConnect.Name = "chkPopupOnConnect"
        Me.chkPopupOnConnect.Size = New System.Drawing.Size(114, 18)
        Me.chkPopupOnConnect.TabIndex = 5
        Me.chkPopupOnConnect.Text = "Popup on Connect"
        Me.chkPopupOnConnect.ThemeName = "Office2010Black"
        '
        'chkCloseOnJoin
        '
        Me.chkCloseOnJoin.Location = New System.Drawing.Point(12, 275)
        Me.chkCloseOnJoin.Name = "chkCloseOnJoin"
        Me.chkCloseOnJoin.Size = New System.Drawing.Size(86, 18)
        Me.chkCloseOnJoin.TabIndex = 6
        Me.chkCloseOnJoin.Text = "Close on Join"
        Me.chkCloseOnJoin.ThemeName = "Office2010Black"
        '
        'frmChannelFolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 305)
        Me.Controls.Add(Me.chkCloseOnJoin)
        Me.Controls.Add(Me.chkPopupOnConnect)
        Me.Controls.Add(Me.lnkJumpToChannelList)
        Me.Controls.Add(Me.lstChannels)
        Me.Controls.Add(Me.cboNetwork)
        Me.Controls.Add(Me.lblNetwork)
        Me.Controls.Add(Me.cmdJoin)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.txtChannel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChannelFolder"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Channel Folder"
        Me.ThemeName = "Office2010Black"
        CType(Me.txtChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdJoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lstChannels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPopupOnConnect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCloseOnJoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChannel As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdJoin As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdRemove As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblNetwork As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cboNetwork As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lstChannels As Telerik.WinControls.UI.RadListControl
    Friend WithEvents lnkJumpToChannelList As System.Windows.Forms.LinkLabel
    Friend WithEvents chkPopupOnConnect As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkCloseOnJoin As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents HighContrastBlackTheme1 As Telerik.WinControls.Themes.HighContrastBlackTheme
    Friend WithEvents Office2010BlackTheme1 As Telerik.WinControls.Themes.Office2010BlackTheme
End Class

