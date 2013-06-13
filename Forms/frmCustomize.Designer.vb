<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomize
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomize))
        Dim ListViewDetailColumn4 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Description")
        Dim ListViewDetailColumn5 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Server")
        Dim ListViewDetailColumn6 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Port")
        Dim ListViewDetailColumn7 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Name")
        Dim ListViewDetailColumn8 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Network")
        Dim ListViewDetailColumn9 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "Message")
        Me.cmdCancelNow = New Telerik.WinControls.UI.RadButton()
        Me.cmdServersMove = New Telerik.WinControls.UI.RadButton()
        Me.cmdServersClear = New Telerik.WinControls.UI.RadButton()
        Me.cmdServerAdd = New Telerik.WinControls.UI.RadButton()
        Me.cmdServerDelete = New Telerik.WinControls.UI.RadButton()
        Me.cmdServerEdit = New Telerik.WinControls.UI.RadButton()
        Me.lnkNetworkDelete = New System.Windows.Forms.LinkLabel()
        Me.lnkNetworkAdd = New System.Windows.Forms.LinkLabel()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboNetworkNotify = New System.Windows.Forms.ComboBox()
        Me.txtNotifyMessage = New System.Windows.Forms.TextBox()
        Me.lblNotifyMessage = New System.Windows.Forms.Label()
        Me.txtNotifyNickName = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optUnsupportedOwn = New System.Windows.Forms.RadioButton()
        Me.optUnsupportedStatus = New System.Windows.Forms.RadioButton()
        Me.optUnsupportedHide = New System.Windows.Forms.RadioButton()
        Me.cmdCompatibility = New System.Windows.Forms.Button()
        Me.cmdEditString = New System.Windows.Forms.Button()
        Me.lvwStrings = New System.Windows.Forms.ListView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optUnknownsOwn = New System.Windows.Forms.RadioButton()
        Me.optUnknownsStatus = New System.Windows.Forms.RadioButton()
        Me.optUnknownsHide = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDisplayModeMinimal = New System.Windows.Forms.RadioButton()
        Me.optDisplayModeRaw = New System.Windows.Forms.RadioButton()
        Me.optDisplayModeNormal = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmdDCCIgnoreRemove = New System.Windows.Forms.Button()
        Me.cmdDCCIgnoreAdd = New System.Windows.Forms.Button()
        Me.lstDCCIgnoreItems = New System.Windows.Forms.ListBox()
        Me.cmdRemoveIgnoreExtension = New System.Windows.Forms.Button()
        Me.cmdAddIgnoreExtension = New System.Windows.Forms.Button()
        Me.lstIgnoreExtensions = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkPopupDownloadManager = New System.Windows.Forms.CheckBox()
        Me.txtDownloadDirectory = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboDCCFileExists = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkAutoCloseDialogs = New System.Windows.Forms.CheckBox()
        Me.chkAutoIgnoreExceptNotify = New System.Windows.Forms.CheckBox()
        Me.fraDCCSend = New System.Windows.Forms.GroupBox()
        Me.optDCCSendPrompt = New System.Windows.Forms.RadioButton()
        Me.optDCCSendIgnore = New System.Windows.Forms.RadioButton()
        Me.optDCCSendAcceptAll = New System.Windows.Forms.RadioButton()
        Me.fraDCCChat = New System.Windows.Forms.GroupBox()
        Me.optDCCChatAcceptAll = New System.Windows.Forms.RadioButton()
        Me.optDCCChatPrompt = New System.Windows.Forms.RadioButton()
        Me.optDCCChatIgnore = New System.Windows.Forms.RadioButton()
        Me.cmdNetworkSettings = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdApplyNow = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.cmdConnectNow = New Telerik.WinControls.UI.RadButton()
        Me.chkNewStatus = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadPageView1 = New Telerik.WinControls.UI.RadPageView()
        Me.RadPageViewPage1 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lvwServers = New Telerik.WinControls.UI.RadListView()
        Me.cboNetworks = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtServerPort = New System.Windows.Forms.TextBox()
        Me.RadPageViewPage2 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtURL = New Telerik.WinControls.UI.RadTextBox()
        Me.lblHomePage = New Telerik.WinControls.UI.RadLabel()
        Me.RadButton3 = New Telerik.WinControls.UI.RadButton()
        Me.cmdEditUserSettings = New Telerik.WinControls.UI.RadButton()
        Me.cboMyNickNames = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmdClearMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.cmdRemoveMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.cmdAddMyNickName = New Telerik.WinControls.UI.RadButton()
        Me.RadPageViewPage3 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.cmdInOwnWindow = New Telerik.WinControls.UI.RadButton()
        Me.cmdQuerySettings = New Telerik.WinControls.UI.RadButton()
        Me.chkCloseStatusWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkHideMOTDs = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowNicknameWindow = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkCloseChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAddToChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkBrowseChannelURLs = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.chkShowBrowser = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowCustomize = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoConnect = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.chkServerNotices = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkLocalOp = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkOperator = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkRestricted = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkWallops = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.chkInvisible = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkServerInNotices = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowUserAddresses = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkExtendedMessages = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.chkNoIRCMessages = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoCloseSupportingWindows = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkVideoBackground = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkPopupChannelFolder = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkAutoMaximize = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.chkHideStatusOnClose = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowWindowsAutomatically = New Telerik.WinControls.UI.RadCheckBox()
        Me.chkShowPrompts = New Telerik.WinControls.UI.RadCheckBox()
        Me.RadPageViewPage4 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.lvwNotify = New Telerik.WinControls.UI.RadListView()
        Me.RadPageViewPage5 = New Telerik.WinControls.UI.RadPageViewPage()
        Me.RadPageViewPage6 = New Telerik.WinControls.UI.RadPageViewPage()
        CType(Me.cmdCancelNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServersMove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServersClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdServerEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fraDCCSend.SuspendLayout()
        Me.fraDCCChat.SuspendLayout()
        CType(Me.cmdApplyNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdConnectNow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNewStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageView1.SuspendLayout()
        Me.RadPageViewPage1.SuspendLayout()
        CType(Me.lvwServers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNetworks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage2.SuspendLayout()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHomePage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdEditUserSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMyNickNames, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdClearMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdRemoveMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdAddMyNickName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage3.SuspendLayout()
        CType(Me.cmdInOwnWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdQuerySettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCloseStatusWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideMOTDs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowNicknameWindow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCloseChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAddToChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBrowseChannelURLs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowBrowser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowCustomize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoConnect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkServerNotices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLocalOp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOperator, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRestricted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkWallops, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInvisible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkServerInNotices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowUserAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExtendedMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoIRCMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoCloseSupportingWindows, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVideoBackground, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPopupChannelFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoMaximize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHideStatusOnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowWindowsAutomatically, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowPrompts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage4.SuspendLayout()
        CType(Me.lvwNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPageViewPage5.SuspendLayout()
        Me.RadPageViewPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelNow
        '
        Me.cmdCancelNow.Image = Global.nexIRC.My.Resources.Resources.cancel
        Me.cmdCancelNow.Location = New System.Drawing.Point(456, 365)
        Me.cmdCancelNow.Name = "cmdCancelNow"
        Me.cmdCancelNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdCancelNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdCancelNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdCancelNow.TabIndex = 24
        Me.cmdCancelNow.Text = "Ca&ncel"
        Me.cmdCancelNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdServersMove
        '
        Me.cmdServersMove.Image = Global.nexIRC.My.Resources.Resources.add1
        Me.cmdServersMove.Location = New System.Drawing.Point(379, 268)
        Me.cmdServersMove.Name = "cmdServersMove"
        Me.cmdServersMove.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServersMove.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServersMove.Size = New System.Drawing.Size(67, 29)
        Me.cmdServersMove.TabIndex = 19
        Me.cmdServersMove.Text = "&Move"
        Me.cmdServersMove.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdServersClear
        '
        Me.cmdServersClear.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdServersClear.Location = New System.Drawing.Point(454, 268)
        Me.cmdServersClear.Name = "cmdServersClear"
        Me.cmdServersClear.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServersClear.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServersClear.Size = New System.Drawing.Size(67, 29)
        Me.cmdServersClear.TabIndex = 19
        Me.cmdServersClear.Text = "C&lear"
        Me.cmdServersClear.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdServerAdd
        '
        Me.cmdServerAdd.Image = Global.nexIRC.My.Resources.Resources.add
        Me.cmdServerAdd.Location = New System.Drawing.Point(3, 268)
        Me.cmdServerAdd.Name = "cmdServerAdd"
        Me.cmdServerAdd.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerAdd.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerAdd.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerAdd.TabIndex = 20
        Me.cmdServerAdd.Text = "&Add"
        Me.cmdServerAdd.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdServerDelete
        '
        Me.cmdServerDelete.Image = Global.nexIRC.My.Resources.Resources.delete
        Me.cmdServerDelete.Location = New System.Drawing.Point(76, 268)
        Me.cmdServerDelete.Name = "cmdServerDelete"
        Me.cmdServerDelete.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerDelete.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerDelete.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerDelete.TabIndex = 19
        Me.cmdServerDelete.Text = "&Delete"
        Me.cmdServerDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdServerEdit
        '
        Me.cmdServerEdit.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmdServerEdit.Location = New System.Drawing.Point(149, 268)
        Me.cmdServerEdit.Name = "cmdServerEdit"
        Me.cmdServerEdit.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdServerEdit.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdServerEdit.Size = New System.Drawing.Size(67, 29)
        Me.cmdServerEdit.TabIndex = 18
        Me.cmdServerEdit.Text = "&Edit"
        Me.cmdServerEdit.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'lnkNetworkDelete
        '
        Me.lnkNetworkDelete.AutoSize = True
        Me.lnkNetworkDelete.Location = New System.Drawing.Point(484, 7)
        Me.lnkNetworkDelete.Name = "lnkNetworkDelete"
        Me.lnkNetworkDelete.Size = New System.Drawing.Size(40, 13)
        Me.lnkNetworkDelete.TabIndex = 17
        Me.lnkNetworkDelete.TabStop = True
        Me.lnkNetworkDelete.Text = "Delete"
        '
        'lnkNetworkAdd
        '
        Me.lnkNetworkAdd.AutoSize = True
        Me.lnkNetworkAdd.Location = New System.Drawing.Point(452, 7)
        Me.lnkNetworkAdd.Name = "lnkNetworkAdd"
        Me.lnkNetworkAdd.Size = New System.Drawing.Size(28, 13)
        Me.lnkNetworkAdd.TabIndex = 16
        Me.lnkNetworkAdd.TabStop = True
        Me.lnkNetworkAdd.Text = "Add"
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.Color.Black
        Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServer.Location = New System.Drawing.Point(102, 122)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(247, 19)
        Me.txtServer.TabIndex = 12
        Me.txtServer.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(1, 274)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Network:"
        '
        'cboNetworkNotify
        '
        Me.cboNetworkNotify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNetworkNotify.FormattingEnabled = True
        Me.cboNetworkNotify.Location = New System.Drawing.Point(108, 270)
        Me.cboNetworkNotify.Margin = New System.Windows.Forms.Padding(4)
        Me.cboNetworkNotify.Name = "cboNetworkNotify"
        Me.cboNetworkNotify.Size = New System.Drawing.Size(415, 26)
        Me.cboNetworkNotify.TabIndex = 22
        '
        'txtNotifyMessage
        '
        Me.txtNotifyMessage.Location = New System.Drawing.Point(108, 237)
        Me.txtNotifyMessage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNotifyMessage.Name = "txtNotifyMessage"
        Me.txtNotifyMessage.Size = New System.Drawing.Size(415, 26)
        Me.txtNotifyMessage.TabIndex = 18
        '
        'lblNotifyMessage
        '
        Me.lblNotifyMessage.AutoSize = True
        Me.lblNotifyMessage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotifyMessage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNotifyMessage.Location = New System.Drawing.Point(1, 241)
        Me.lblNotifyMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNotifyMessage.Name = "lblNotifyMessage"
        Me.lblNotifyMessage.Size = New System.Drawing.Size(60, 13)
        Me.lblNotifyMessage.TabIndex = 17
        Me.lblNotifyMessage.Text = "Message:"
        '
        'txtNotifyNickName
        '
        Me.txtNotifyNickName.Location = New System.Drawing.Point(108, 203)
        Me.txtNotifyNickName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNotifyNickName.Name = "txtNotifyNickName"
        Me.txtNotifyNickName.Size = New System.Drawing.Size(415, 26)
        Me.txtNotifyNickName.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(1, 207)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "Nickname:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optUnsupportedOwn)
        Me.GroupBox2.Controls.Add(Me.optUnsupportedStatus)
        Me.GroupBox2.Controls.Add(Me.optUnsupportedHide)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(4, 200)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(107, 91)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Unsupported"
        '
        'optUnsupportedOwn
        '
        Me.optUnsupportedOwn.AutoSize = True
        Me.optUnsupportedOwn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnsupportedOwn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnsupportedOwn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnsupportedOwn.Location = New System.Drawing.Point(8, 42)
        Me.optUnsupportedOwn.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnsupportedOwn.Name = "optUnsupportedOwn"
        Me.optUnsupportedOwn.Size = New System.Drawing.Size(46, 17)
        Me.optUnsupportedOwn.TabIndex = 2
        Me.optUnsupportedOwn.TabStop = True
        Me.optUnsupportedOwn.Text = "Own"
        Me.optUnsupportedOwn.UseVisualStyleBackColor = True
        '
        'optUnsupportedStatus
        '
        Me.optUnsupportedStatus.AutoSize = True
        Me.optUnsupportedStatus.Enabled = False
        Me.optUnsupportedStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnsupportedStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnsupportedStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnsupportedStatus.Location = New System.Drawing.Point(8, 19)
        Me.optUnsupportedStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnsupportedStatus.Name = "optUnsupportedStatus"
        Me.optUnsupportedStatus.Size = New System.Drawing.Size(55, 17)
        Me.optUnsupportedStatus.TabIndex = 1
        Me.optUnsupportedStatus.TabStop = True
        Me.optUnsupportedStatus.Text = "Status"
        Me.optUnsupportedStatus.UseVisualStyleBackColor = True
        '
        'optUnsupportedHide
        '
        Me.optUnsupportedHide.AutoSize = True
        Me.optUnsupportedHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnsupportedHide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnsupportedHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnsupportedHide.Location = New System.Drawing.Point(8, 64)
        Me.optUnsupportedHide.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnsupportedHide.Name = "optUnsupportedHide"
        Me.optUnsupportedHide.Size = New System.Drawing.Size(45, 17)
        Me.optUnsupportedHide.TabIndex = 0
        Me.optUnsupportedHide.TabStop = True
        Me.optUnsupportedHide.Text = "Hide"
        Me.optUnsupportedHide.UseVisualStyleBackColor = True
        '
        'cmdCompatibility
        '
        Me.cmdCompatibility.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.cmdCompatibility.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCompatibility.Location = New System.Drawing.Point(350, 252)
        Me.cmdCompatibility.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCompatibility.Name = "cmdCompatibility"
        Me.cmdCompatibility.Size = New System.Drawing.Size(173, 40)
        Me.cmdCompatibility.TabIndex = 6
        Me.cmdCompatibility.Text = "Compatibility"
        Me.cmdCompatibility.UseVisualStyleBackColor = True
        '
        'cmdEditString
        '
        Me.cmdEditString.Image = CType(resources.GetObject("cmdEditString.Image"), System.Drawing.Image)
        Me.cmdEditString.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditString.Location = New System.Drawing.Point(131, 252)
        Me.cmdEditString.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdEditString.Name = "cmdEditString"
        Me.cmdEditString.Size = New System.Drawing.Size(173, 40)
        Me.cmdEditString.TabIndex = 11
        Me.cmdEditString.Text = "Edit Text String"
        Me.cmdEditString.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEditString.UseVisualStyleBackColor = True
        '
        'lvwStrings
        '
        Me.lvwStrings.FullRowSelect = True
        Me.lvwStrings.Location = New System.Drawing.Point(131, 4)
        Me.lvwStrings.Margin = New System.Windows.Forms.Padding(4)
        Me.lvwStrings.Name = "lvwStrings"
        Me.lvwStrings.Size = New System.Drawing.Size(392, 232)
        Me.lvwStrings.TabIndex = 10
        Me.lvwStrings.UseCompatibleStateImageBehavior = False
        Me.lvwStrings.View = System.Windows.Forms.View.Details
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optUnknownsOwn)
        Me.GroupBox3.Controls.Add(Me.optUnknownsStatus)
        Me.GroupBox3.Controls.Add(Me.optUnknownsHide)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(4, 104)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(107, 91)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Unknown Text:"
        '
        'optUnknownsOwn
        '
        Me.optUnknownsOwn.AutoSize = True
        Me.optUnknownsOwn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnknownsOwn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnknownsOwn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnknownsOwn.Location = New System.Drawing.Point(8, 42)
        Me.optUnknownsOwn.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnknownsOwn.Name = "optUnknownsOwn"
        Me.optUnknownsOwn.Size = New System.Drawing.Size(46, 17)
        Me.optUnknownsOwn.TabIndex = 2
        Me.optUnknownsOwn.TabStop = True
        Me.optUnknownsOwn.Text = "Own"
        Me.optUnknownsOwn.UseVisualStyleBackColor = True
        '
        'optUnknownsStatus
        '
        Me.optUnknownsStatus.AutoSize = True
        Me.optUnknownsStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnknownsStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnknownsStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnknownsStatus.Location = New System.Drawing.Point(8, 19)
        Me.optUnknownsStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnknownsStatus.Name = "optUnknownsStatus"
        Me.optUnknownsStatus.Size = New System.Drawing.Size(55, 17)
        Me.optUnknownsStatus.TabIndex = 1
        Me.optUnknownsStatus.TabStop = True
        Me.optUnknownsStatus.Text = "Status"
        Me.optUnknownsStatus.UseVisualStyleBackColor = True
        '
        'optUnknownsHide
        '
        Me.optUnknownsHide.AutoSize = True
        Me.optUnknownsHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optUnknownsHide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optUnknownsHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optUnknownsHide.Location = New System.Drawing.Point(8, 64)
        Me.optUnknownsHide.Margin = New System.Windows.Forms.Padding(4)
        Me.optUnknownsHide.Name = "optUnknownsHide"
        Me.optUnknownsHide.Size = New System.Drawing.Size(45, 17)
        Me.optUnknownsHide.TabIndex = 0
        Me.optUnknownsHide.TabStop = True
        Me.optUnknownsHide.Text = "Hide"
        Me.optUnknownsHide.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optDisplayModeMinimal)
        Me.GroupBox1.Controls.Add(Me.optDisplayModeRaw)
        Me.GroupBox1.Controls.Add(Me.optDisplayModeNormal)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(107, 91)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Text Mode:"
        '
        'optDisplayModeMinimal
        '
        Me.optDisplayModeMinimal.AutoSize = True
        Me.optDisplayModeMinimal.Enabled = False
        Me.optDisplayModeMinimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDisplayModeMinimal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDisplayModeMinimal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDisplayModeMinimal.Location = New System.Drawing.Point(8, 64)
        Me.optDisplayModeMinimal.Margin = New System.Windows.Forms.Padding(4)
        Me.optDisplayModeMinimal.Name = "optDisplayModeMinimal"
        Me.optDisplayModeMinimal.Size = New System.Drawing.Size(58, 17)
        Me.optDisplayModeMinimal.TabIndex = 5
        Me.optDisplayModeMinimal.TabStop = True
        Me.optDisplayModeMinimal.Text = "Minimal"
        Me.optDisplayModeMinimal.UseVisualStyleBackColor = True
        '
        'optDisplayModeRaw
        '
        Me.optDisplayModeRaw.AutoSize = True
        Me.optDisplayModeRaw.Enabled = False
        Me.optDisplayModeRaw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDisplayModeRaw.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDisplayModeRaw.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDisplayModeRaw.Location = New System.Drawing.Point(8, 42)
        Me.optDisplayModeRaw.Margin = New System.Windows.Forms.Padding(4)
        Me.optDisplayModeRaw.Name = "optDisplayModeRaw"
        Me.optDisplayModeRaw.Size = New System.Drawing.Size(45, 17)
        Me.optDisplayModeRaw.TabIndex = 4
        Me.optDisplayModeRaw.TabStop = True
        Me.optDisplayModeRaw.Text = "Raw"
        Me.optDisplayModeRaw.UseVisualStyleBackColor = True
        '
        'optDisplayModeNormal
        '
        Me.optDisplayModeNormal.AutoSize = True
        Me.optDisplayModeNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDisplayModeNormal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDisplayModeNormal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDisplayModeNormal.Location = New System.Drawing.Point(8, 19)
        Me.optDisplayModeNormal.Margin = New System.Windows.Forms.Padding(4)
        Me.optDisplayModeNormal.Name = "optDisplayModeNormal"
        Me.optDisplayModeNormal.Size = New System.Drawing.Size(57, 17)
        Me.optDisplayModeNormal.TabIndex = 3
        Me.optDisplayModeNormal.TabStop = True
        Me.optDisplayModeNormal.Text = "Normal"
        Me.optDisplayModeNormal.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(349, 162)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(85, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Ignore Items:"
        '
        'cmdDCCIgnoreRemove
        '
        Me.cmdDCCIgnoreRemove.Enabled = False
        Me.cmdDCCIgnoreRemove.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDCCIgnoreRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDCCIgnoreRemove.Image = CType(resources.GetObject("cmdDCCIgnoreRemove.Image"), System.Drawing.Image)
        Me.cmdDCCIgnoreRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDCCIgnoreRemove.Location = New System.Drawing.Point(444, 256)
        Me.cmdDCCIgnoreRemove.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDCCIgnoreRemove.Name = "cmdDCCIgnoreRemove"
        Me.cmdDCCIgnoreRemove.Size = New System.Drawing.Size(85, 37)
        Me.cmdDCCIgnoreRemove.TabIndex = 33
        Me.cmdDCCIgnoreRemove.Text = "Del"
        Me.cmdDCCIgnoreRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDCCIgnoreRemove.UseVisualStyleBackColor = True
        '
        'cmdDCCIgnoreAdd
        '
        Me.cmdDCCIgnoreAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDCCIgnoreAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDCCIgnoreAdd.Image = CType(resources.GetObject("cmdDCCIgnoreAdd.Image"), System.Drawing.Image)
        Me.cmdDCCIgnoreAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDCCIgnoreAdd.Location = New System.Drawing.Point(352, 256)
        Me.cmdDCCIgnoreAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdDCCIgnoreAdd.Name = "cmdDCCIgnoreAdd"
        Me.cmdDCCIgnoreAdd.Size = New System.Drawing.Size(84, 37)
        Me.cmdDCCIgnoreAdd.TabIndex = 32
        Me.cmdDCCIgnoreAdd.Text = "Add"
        Me.cmdDCCIgnoreAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDCCIgnoreAdd.UseVisualStyleBackColor = True
        '
        'lstDCCIgnoreItems
        '
        Me.lstDCCIgnoreItems.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDCCIgnoreItems.ForeColor = System.Drawing.Color.Black
        Me.lstDCCIgnoreItems.FormattingEnabled = True
        Me.lstDCCIgnoreItems.IntegralHeight = False
        Me.lstDCCIgnoreItems.Location = New System.Drawing.Point(352, 184)
        Me.lstDCCIgnoreItems.Margin = New System.Windows.Forms.Padding(4)
        Me.lstDCCIgnoreItems.Name = "lstDCCIgnoreItems"
        Me.lstDCCIgnoreItems.Size = New System.Drawing.Size(176, 62)
        Me.lstDCCIgnoreItems.TabIndex = 31
        '
        'cmdRemoveIgnoreExtension
        '
        Me.cmdRemoveIgnoreExtension.Enabled = False
        Me.cmdRemoveIgnoreExtension.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveIgnoreExtension.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemoveIgnoreExtension.Image = CType(resources.GetObject("cmdRemoveIgnoreExtension.Image"), System.Drawing.Image)
        Me.cmdRemoveIgnoreExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdRemoveIgnoreExtension.Location = New System.Drawing.Point(442, 113)
        Me.cmdRemoveIgnoreExtension.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRemoveIgnoreExtension.Name = "cmdRemoveIgnoreExtension"
        Me.cmdRemoveIgnoreExtension.Size = New System.Drawing.Size(83, 37)
        Me.cmdRemoveIgnoreExtension.TabIndex = 30
        Me.cmdRemoveIgnoreExtension.Text = "Del"
        Me.cmdRemoveIgnoreExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdRemoveIgnoreExtension.UseVisualStyleBackColor = True
        '
        'cmdAddIgnoreExtension
        '
        Me.cmdAddIgnoreExtension.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddIgnoreExtension.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddIgnoreExtension.Image = CType(resources.GetObject("cmdAddIgnoreExtension.Image"), System.Drawing.Image)
        Me.cmdAddIgnoreExtension.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAddIgnoreExtension.Location = New System.Drawing.Point(351, 113)
        Me.cmdAddIgnoreExtension.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAddIgnoreExtension.Name = "cmdAddIgnoreExtension"
        Me.cmdAddIgnoreExtension.Size = New System.Drawing.Size(83, 37)
        Me.cmdAddIgnoreExtension.TabIndex = 29
        Me.cmdAddIgnoreExtension.Text = "Add"
        Me.cmdAddIgnoreExtension.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAddIgnoreExtension.UseVisualStyleBackColor = True
        '
        'lstIgnoreExtensions
        '
        Me.lstIgnoreExtensions.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstIgnoreExtensions.FormattingEnabled = True
        Me.lstIgnoreExtensions.IntegralHeight = False
        Me.lstIgnoreExtensions.Location = New System.Drawing.Point(351, 40)
        Me.lstIgnoreExtensions.Margin = New System.Windows.Forms.Padding(4)
        Me.lstIgnoreExtensions.Name = "lstIgnoreExtensions"
        Me.lstIgnoreExtensions.Size = New System.Drawing.Size(176, 64)
        Me.lstIgnoreExtensions.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(346, 17)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Ignore Extensions:"
        '
        'chkPopupDownloadManager
        '
        Me.chkPopupDownloadManager.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkPopupDownloadManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPopupDownloadManager.Location = New System.Drawing.Point(119, 112)
        Me.chkPopupDownloadManager.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPopupDownloadManager.Name = "chkPopupDownloadManager"
        Me.chkPopupDownloadManager.Size = New System.Drawing.Size(276, 24)
        Me.chkPopupDownloadManager.TabIndex = 26
        Me.chkPopupDownloadManager.Text = "Popup Download Manager"
        Me.chkPopupDownloadManager.UseVisualStyleBackColor = True
        '
        'txtDownloadDirectory
        '
        Me.txtDownloadDirectory.Location = New System.Drawing.Point(271, 195)
        Me.txtDownloadDirectory.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDownloadDirectory.Name = "txtDownloadDirectory"
        Me.txtDownloadDirectory.Size = New System.Drawing.Size(75, 26)
        Me.txtDownloadDirectory.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(123, 200)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Download Directory:"
        '
        'cboDCCFileExists
        '
        Me.cboDCCFileExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDCCFileExists.FormattingEnabled = True
        Me.cboDCCFileExists.Items.AddRange(New Object() {"Prompt", "Overwrite", "Ignore"})
        Me.cboDCCFileExists.Location = New System.Drawing.Point(271, 158)
        Me.cboDCCFileExists.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDCCFileExists.Name = "cboDCCFileExists"
        Me.cboDCCFileExists.Size = New System.Drawing.Size(75, 26)
        Me.cboDCCFileExists.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(123, 162)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "When file exists:"
        '
        'chkAutoCloseDialogs
        '
        Me.chkAutoCloseDialogs.AutoSize = True
        Me.chkAutoCloseDialogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAutoCloseDialogs.Location = New System.Drawing.Point(119, 51)
        Me.chkAutoCloseDialogs.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoCloseDialogs.Name = "chkAutoCloseDialogs"
        Me.chkAutoCloseDialogs.Size = New System.Drawing.Size(143, 17)
        Me.chkAutoCloseDialogs.TabIndex = 18
        Me.chkAutoCloseDialogs.Text = "Auto close DCC dialogs"
        Me.chkAutoCloseDialogs.UseVisualStyleBackColor = True
        '
        'chkAutoIgnoreExceptNotify
        '
        Me.chkAutoIgnoreExceptNotify.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAutoIgnoreExceptNotify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAutoIgnoreExceptNotify.Location = New System.Drawing.Point(119, 74)
        Me.chkAutoIgnoreExceptNotify.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoIgnoreExceptNotify.Name = "chkAutoIgnoreExceptNotify"
        Me.chkAutoIgnoreExceptNotify.Size = New System.Drawing.Size(276, 30)
        Me.chkAutoIgnoreExceptNotify.TabIndex = 17
        Me.chkAutoIgnoreExceptNotify.Text = "Auto ignore everyone except users in notify list"
        Me.chkAutoIgnoreExceptNotify.UseVisualStyleBackColor = True
        '
        'fraDCCSend
        '
        Me.fraDCCSend.Controls.Add(Me.optDCCSendPrompt)
        Me.fraDCCSend.Controls.Add(Me.optDCCSendIgnore)
        Me.fraDCCSend.Controls.Add(Me.optDCCSendAcceptAll)
        Me.fraDCCSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fraDCCSend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDCCSend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDCCSend.Location = New System.Drawing.Point(4, 104)
        Me.fraDCCSend.Margin = New System.Windows.Forms.Padding(4)
        Me.fraDCCSend.Name = "fraDCCSend"
        Me.fraDCCSend.Padding = New System.Windows.Forms.Padding(4)
        Me.fraDCCSend.Size = New System.Drawing.Size(107, 91)
        Me.fraDCCSend.TabIndex = 2
        Me.fraDCCSend.TabStop = False
        Me.fraDCCSend.Text = "DCC Send"
        '
        'optDCCSendPrompt
        '
        Me.optDCCSendPrompt.AutoSize = True
        Me.optDCCSendPrompt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCSendPrompt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCSendPrompt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCSendPrompt.Location = New System.Drawing.Point(8, 19)
        Me.optDCCSendPrompt.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCSendPrompt.Name = "optDCCSendPrompt"
        Me.optDCCSendPrompt.Size = New System.Drawing.Size(58, 17)
        Me.optDCCSendPrompt.TabIndex = 2
        Me.optDCCSendPrompt.TabStop = True
        Me.optDCCSendPrompt.Text = "Prompt"
        Me.optDCCSendPrompt.UseVisualStyleBackColor = True
        '
        'optDCCSendIgnore
        '
        Me.optDCCSendIgnore.AutoSize = True
        Me.optDCCSendIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCSendIgnore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCSendIgnore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCSendIgnore.Location = New System.Drawing.Point(8, 62)
        Me.optDCCSendIgnore.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCSendIgnore.Name = "optDCCSendIgnore"
        Me.optDCCSendIgnore.Size = New System.Drawing.Size(56, 17)
        Me.optDCCSendIgnore.TabIndex = 1
        Me.optDCCSendIgnore.TabStop = True
        Me.optDCCSendIgnore.Text = "Ignore"
        Me.optDCCSendIgnore.UseVisualStyleBackColor = True
        '
        'optDCCSendAcceptAll
        '
        Me.optDCCSendAcceptAll.AutoSize = True
        Me.optDCCSendAcceptAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCSendAcceptAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCSendAcceptAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCSendAcceptAll.Location = New System.Drawing.Point(8, 42)
        Me.optDCCSendAcceptAll.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCSendAcceptAll.Name = "optDCCSendAcceptAll"
        Me.optDCCSendAcceptAll.Size = New System.Drawing.Size(71, 17)
        Me.optDCCSendAcceptAll.TabIndex = 3
        Me.optDCCSendAcceptAll.TabStop = True
        Me.optDCCSendAcceptAll.Text = "Accept All"
        Me.optDCCSendAcceptAll.UseVisualStyleBackColor = True
        '
        'fraDCCChat
        '
        Me.fraDCCChat.Controls.Add(Me.optDCCChatAcceptAll)
        Me.fraDCCChat.Controls.Add(Me.optDCCChatPrompt)
        Me.fraDCCChat.Controls.Add(Me.optDCCChatIgnore)
        Me.fraDCCChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fraDCCChat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraDCCChat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraDCCChat.Location = New System.Drawing.Point(4, 4)
        Me.fraDCCChat.Margin = New System.Windows.Forms.Padding(4)
        Me.fraDCCChat.Name = "fraDCCChat"
        Me.fraDCCChat.Padding = New System.Windows.Forms.Padding(4)
        Me.fraDCCChat.Size = New System.Drawing.Size(107, 91)
        Me.fraDCCChat.TabIndex = 1
        Me.fraDCCChat.TabStop = False
        Me.fraDCCChat.Text = "DCC Chat"
        '
        'optDCCChatAcceptAll
        '
        Me.optDCCChatAcceptAll.AutoSize = True
        Me.optDCCChatAcceptAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCChatAcceptAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCChatAcceptAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCChatAcceptAll.Location = New System.Drawing.Point(8, 42)
        Me.optDCCChatAcceptAll.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCChatAcceptAll.Name = "optDCCChatAcceptAll"
        Me.optDCCChatAcceptAll.Size = New System.Drawing.Size(71, 17)
        Me.optDCCChatAcceptAll.TabIndex = 3
        Me.optDCCChatAcceptAll.TabStop = True
        Me.optDCCChatAcceptAll.Text = "Accept All"
        Me.optDCCChatAcceptAll.UseVisualStyleBackColor = True
        '
        'optDCCChatPrompt
        '
        Me.optDCCChatPrompt.AutoSize = True
        Me.optDCCChatPrompt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCChatPrompt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCChatPrompt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCChatPrompt.Location = New System.Drawing.Point(8, 19)
        Me.optDCCChatPrompt.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCChatPrompt.Name = "optDCCChatPrompt"
        Me.optDCCChatPrompt.Size = New System.Drawing.Size(58, 17)
        Me.optDCCChatPrompt.TabIndex = 2
        Me.optDCCChatPrompt.TabStop = True
        Me.optDCCChatPrompt.Text = "Prompt"
        Me.optDCCChatPrompt.UseVisualStyleBackColor = True
        '
        'optDCCChatIgnore
        '
        Me.optDCCChatIgnore.AutoSize = True
        Me.optDCCChatIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDCCChatIgnore.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDCCChatIgnore.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDCCChatIgnore.Location = New System.Drawing.Point(8, 64)
        Me.optDCCChatIgnore.Margin = New System.Windows.Forms.Padding(4)
        Me.optDCCChatIgnore.Name = "optDCCChatIgnore"
        Me.optDCCChatIgnore.Size = New System.Drawing.Size(56, 17)
        Me.optDCCChatIgnore.TabIndex = 1
        Me.optDCCChatIgnore.TabStop = True
        Me.optDCCChatIgnore.Text = "Ignore"
        Me.optDCCChatIgnore.UseVisualStyleBackColor = True
        '
        'cmdNetworkSettings
        '
        Me.cmdNetworkSettings.Image = CType(resources.GetObject("cmdNetworkSettings.Image"), System.Drawing.Image)
        Me.cmdNetworkSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdNetworkSettings.Location = New System.Drawing.Point(119, 4)
        Me.cmdNetworkSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdNetworkSettings.Name = "cmdNetworkSettings"
        Me.cmdNetworkSettings.Size = New System.Drawing.Size(196, 39)
        Me.cmdNetworkSettings.TabIndex = 15
        Me.cmdNetworkSettings.Text = "Edit Network Settings"
        Me.cmdNetworkSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdNetworkSettings.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "accept.png")
        Me.ImageList1.Images.SetKeyName(1, "add.png")
        Me.ImageList1.Images.SetKeyName(2, "cancel.png")
        Me.ImageList1.Images.SetKeyName(3, "close.png")
        Me.ImageList1.Images.SetKeyName(4, "delete.png")
        Me.ImageList1.Images.SetKeyName(5, "edit (1).png")
        Me.ImageList1.Images.SetKeyName(6, "move.png")
        Me.ImageList1.Images.SetKeyName(7, "remove.png")
        Me.ImageList1.Images.SetKeyName(8, "web.png")
        Me.ImageList1.Images.SetKeyName(9, "user.png")
        Me.ImageList1.Images.SetKeyName(10, "configure.png")
        Me.ImageList1.Images.SetKeyName(11, "network.png")
        Me.ImageList1.Images.SetKeyName(12, "announce.png")
        Me.ImageList1.Images.SetKeyName(13, "documents.png")
        Me.ImageList1.Images.SetKeyName(14, "copy.png")
        '
        'cmdApplyNow
        '
        Me.cmdApplyNow.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.cmdApplyNow.Location = New System.Drawing.Point(363, 365)
        Me.cmdApplyNow.Name = "cmdApplyNow"
        Me.cmdApplyNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdApplyNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdApplyNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdApplyNow.TabIndex = 23
        Me.cmdApplyNow.Text = "&Apply"
        Me.cmdApplyNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadButton1
        '
        Me.RadButton1.Image = Global.nexIRC.My.Resources.Resources.accept
        Me.RadButton1.Location = New System.Drawing.Point(271, 365)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.RadButton1.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.RadButton1.Size = New System.Drawing.Size(86, 29)
        Me.RadButton1.TabIndex = 22
        Me.RadButton1.Text = "&OK"
        Me.RadButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdConnectNow
        '
        Me.cmdConnectNow.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.cmdConnectNow.Location = New System.Drawing.Point(0, 365)
        Me.cmdConnectNow.Name = "cmdConnectNow"
        Me.cmdConnectNow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        '
        '
        '
        Me.cmdConnectNow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 0)
        Me.cmdConnectNow.Size = New System.Drawing.Size(86, 29)
        Me.cmdConnectNow.TabIndex = 21
        Me.cmdConnectNow.Text = "&Connect"
        Me.cmdConnectNow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkNewStatus
        '
        Me.chkNewStatus.Location = New System.Drawing.Point(92, 376)
        Me.chkNewStatus.Name = "chkNewStatus"
        Me.chkNewStatus.Size = New System.Drawing.Size(121, 18)
        Me.chkNewStatus.TabIndex = 21
        Me.chkNewStatus.Text = "New Status Window"
        '
        'RadPageView1
        '
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage1)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage2)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage3)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage4)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage5)
        Me.RadPageView1.Controls.Add(Me.RadPageViewPage6)
        Me.RadPageView1.Location = New System.Drawing.Point(0, 0)
        Me.RadPageView1.Name = "RadPageView1"
        Me.RadPageView1.SelectedPage = Me.RadPageViewPage1
        Me.RadPageView1.Size = New System.Drawing.Size(542, 359)
        Me.RadPageView1.TabIndex = 25
        Me.RadPageView1.Text = "RadPageView1"
        Me.RadPageView1.ThemeName = "Vista"
        '
        'RadPageViewPage1
        '
        Me.RadPageViewPage1.Controls.Add(Me.lvwServers)
        Me.RadPageViewPage1.Controls.Add(Me.cboNetworks)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServersMove)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServersClear)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerAdd)
        Me.RadPageViewPage1.Controls.Add(Me.lnkNetworkAdd)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerDelete)
        Me.RadPageViewPage1.Controls.Add(Me.lnkNetworkDelete)
        Me.RadPageViewPage1.Controls.Add(Me.cmdServerEdit)
        Me.RadPageViewPage1.Controls.Add(Me.txtServer)
        Me.RadPageViewPage1.Controls.Add(Me.txtServerPort)
        Me.RadPageViewPage1.Image = Global.nexIRC.My.Resources.Resources.web
        Me.RadPageViewPage1.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage1.Name = "RadPageViewPage1"
        Me.RadPageViewPage1.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage1.Text = "Network"
        '
        'lvwServers
        '
        ListViewDetailColumn4.HeaderText = "Description"
        ListViewDetailColumn5.HeaderText = "Server"
        ListViewDetailColumn6.HeaderText = "Port"
        ListViewDetailColumn6.Width = 117.0!
        Me.lvwServers.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn4, ListViewDetailColumn5, ListViewDetailColumn6})
        Me.lvwServers.EnableColumnSort = True
        Me.lvwServers.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwServers.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwServers.ItemSpacing = -1
        Me.lvwServers.Location = New System.Drawing.Point(3, 29)
        Me.lvwServers.MultiSelect = True
        Me.lvwServers.Name = "lvwServers"
        Me.lvwServers.Size = New System.Drawing.Size(518, 233)
        Me.lvwServers.TabIndex = 23
        Me.lvwServers.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'cboNetworks
        '
        Me.cboNetworks.DropDownAnimationEnabled = True
        Me.cboNetworks.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboNetworks.Location = New System.Drawing.Point(3, 3)
        Me.cboNetworks.Name = "cboNetworks"
        Me.cboNetworks.ShowImageInEditorArea = True
        Me.cboNetworks.Size = New System.Drawing.Size(443, 20)
        Me.cboNetworks.TabIndex = 22
        '
        'txtServerPort
        '
        Me.txtServerPort.BackColor = System.Drawing.Color.Black
        Me.txtServerPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServerPort.Location = New System.Drawing.Point(244, 149)
        Me.txtServerPort.Name = "txtServerPort"
        Me.txtServerPort.Size = New System.Drawing.Size(100, 19)
        Me.txtServerPort.TabIndex = 21
        Me.txtServerPort.Visible = False
        '
        'RadPageViewPage2
        '
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel3)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel2)
        Me.RadPageViewPage2.Controls.Add(Me.RadLabel1)
        Me.RadPageViewPage2.Controls.Add(Me.txtURL)
        Me.RadPageViewPage2.Controls.Add(Me.lblHomePage)
        Me.RadPageViewPage2.Controls.Add(Me.RadButton3)
        Me.RadPageViewPage2.Controls.Add(Me.cmdEditUserSettings)
        Me.RadPageViewPage2.Controls.Add(Me.cboMyNickNames)
        Me.RadPageViewPage2.Controls.Add(Me.cmdClearMyNickName)
        Me.RadPageViewPage2.Controls.Add(Me.cmdRemoveMyNickName)
        Me.RadPageViewPage2.Controls.Add(Me.cmdAddMyNickName)
        Me.RadPageViewPage2.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.RadPageViewPage2.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage2.Name = "RadPageViewPage2"
        Me.RadPageViewPage2.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage2.Text = "User"
        '
        'RadLabel3
        '
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Location = New System.Drawing.Point(7, 5)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(59, 18)
        Me.RadLabel3.TabIndex = 66
        Me.RadLabel3.Text = "Nickname:"
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Location = New System.Drawing.Point(7, 65)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(74, 18)
        Me.RadLabel2.TabIndex = 66
        Me.RadLabel2.Text = "User Settings:"
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Location = New System.Drawing.Point(7, 95)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(85, 18)
        Me.RadLabel1.TabIndex = 65
        Me.RadLabel1.Text = "Identd Settings:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(122, 119)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(402, 20)
        Me.txtURL.TabIndex = 0
        Me.txtURL.TabStop = False
        '
        'lblHomePage
        '
        Me.lblHomePage.BackColor = System.Drawing.Color.Transparent
        Me.lblHomePage.Location = New System.Drawing.Point(7, 121)
        Me.lblHomePage.Name = "lblHomePage"
        Me.lblHomePage.Size = New System.Drawing.Size(64, 18)
        Me.lblHomePage.TabIndex = 64
        Me.lblHomePage.Text = "Homepage:"
        '
        'RadButton3
        '
        Me.RadButton3.Location = New System.Drawing.Point(394, 89)
        Me.RadButton3.Name = "RadButton3"
        Me.RadButton3.Size = New System.Drawing.Size(130, 24)
        Me.RadButton3.TabIndex = 63
        Me.RadButton3.Text = "Edit"
        '
        'cmdEditUserSettings
        '
        Me.cmdEditUserSettings.Location = New System.Drawing.Point(394, 59)
        Me.cmdEditUserSettings.Name = "cmdEditUserSettings"
        Me.cmdEditUserSettings.Size = New System.Drawing.Size(130, 24)
        Me.cmdEditUserSettings.TabIndex = 60
        Me.cmdEditUserSettings.Text = "Edit"
        '
        'cboMyNickNames
        '
        Me.cboMyNickNames.DropDownAnimationEnabled = True
        Me.cboMyNickNames.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboMyNickNames.Location = New System.Drawing.Point(122, 3)
        Me.cboMyNickNames.Name = "cboMyNickNames"
        Me.cboMyNickNames.ShowImageInEditorArea = True
        Me.cboMyNickNames.Size = New System.Drawing.Size(402, 20)
        Me.cboMyNickNames.TabIndex = 62
        '
        'cmdClearMyNickName
        '
        Me.cmdClearMyNickName.Location = New System.Drawing.Point(394, 29)
        Me.cmdClearMyNickName.Name = "cmdClearMyNickName"
        Me.cmdClearMyNickName.Size = New System.Drawing.Size(130, 24)
        Me.cmdClearMyNickName.TabIndex = 61
        Me.cmdClearMyNickName.Text = "Clear"
        '
        'cmdRemoveMyNickName
        '
        Me.cmdRemoveMyNickName.Location = New System.Drawing.Point(258, 29)
        Me.cmdRemoveMyNickName.Name = "cmdRemoveMyNickName"
        Me.cmdRemoveMyNickName.Size = New System.Drawing.Size(130, 24)
        Me.cmdRemoveMyNickName.TabIndex = 60
        Me.cmdRemoveMyNickName.Text = "Remove"
        '
        'cmdAddMyNickName
        '
        Me.cmdAddMyNickName.Location = New System.Drawing.Point(122, 29)
        Me.cmdAddMyNickName.Name = "cmdAddMyNickName"
        Me.cmdAddMyNickName.Size = New System.Drawing.Size(130, 24)
        Me.cmdAddMyNickName.TabIndex = 59
        Me.cmdAddMyNickName.Text = "Add"
        '
        'RadPageViewPage3
        '
        Me.RadPageViewPage3.Controls.Add(Me.cmdInOwnWindow)
        Me.RadPageViewPage3.Controls.Add(Me.cmdQuerySettings)
        Me.RadPageViewPage3.Controls.Add(Me.chkCloseStatusWindow)
        Me.RadPageViewPage3.Controls.Add(Me.chkHideMOTDs)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowNicknameWindow)
        Me.RadPageViewPage3.Controls.Add(Me.chkCloseChannelFolder)
        Me.RadPageViewPage3.Controls.Add(Me.chkAddToChannelFolder)
        Me.RadPageViewPage3.Controls.Add(Me.chkBrowseChannelURLs)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel8)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowBrowser)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowCustomize)
        Me.RadPageViewPage3.Controls.Add(Me.chkAutoConnect)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel7)
        Me.RadPageViewPage3.Controls.Add(Me.chkServerNotices)
        Me.RadPageViewPage3.Controls.Add(Me.chkLocalOp)
        Me.RadPageViewPage3.Controls.Add(Me.chkOperator)
        Me.RadPageViewPage3.Controls.Add(Me.chkRestricted)
        Me.RadPageViewPage3.Controls.Add(Me.chkWallops)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel6)
        Me.RadPageViewPage3.Controls.Add(Me.chkInvisible)
        Me.RadPageViewPage3.Controls.Add(Me.chkServerInNotices)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowUserAddresses)
        Me.RadPageViewPage3.Controls.Add(Me.chkExtendedMessages)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel5)
        Me.RadPageViewPage3.Controls.Add(Me.chkNoIRCMessages)
        Me.RadPageViewPage3.Controls.Add(Me.chkAutoCloseSupportingWindows)
        Me.RadPageViewPage3.Controls.Add(Me.chkVideoBackground)
        Me.RadPageViewPage3.Controls.Add(Me.chkPopupChannelFolder)
        Me.RadPageViewPage3.Controls.Add(Me.chkAutoMaximize)
        Me.RadPageViewPage3.Controls.Add(Me.RadLabel4)
        Me.RadPageViewPage3.Controls.Add(Me.chkHideStatusOnClose)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowWindowsAutomatically)
        Me.RadPageViewPage3.Controls.Add(Me.chkShowPrompts)
        Me.RadPageViewPage3.Image = Global.nexIRC.My.Resources.Resources.applications
        Me.RadPageViewPage3.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage3.Name = "RadPageViewPage3"
        Me.RadPageViewPage3.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage3.Text = "Settings"
        '
        'cmdInOwnWindow
        '
        Me.cmdInOwnWindow.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmdInOwnWindow.Location = New System.Drawing.Point(176, 225)
        Me.cmdInOwnWindow.Name = "cmdInOwnWindow"
        Me.cmdInOwnWindow.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        '
        '
        '
        Me.cmdInOwnWindow.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 0, 2)
        Me.cmdInOwnWindow.Size = New System.Drawing.Size(130, 24)
        Me.cmdInOwnWindow.TabIndex = 65
        Me.cmdInOwnWindow.Text = "In Own Window"
        Me.cmdInOwnWindow.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdQuerySettings
        '
        Me.cmdQuerySettings.Image = Global.nexIRC.My.Resources.Resources.configure
        Me.cmdQuerySettings.Location = New System.Drawing.Point(176, 195)
        Me.cmdQuerySettings.Name = "cmdQuerySettings"
        Me.cmdQuerySettings.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        '
        '
        Me.cmdQuerySettings.RootElement.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cmdQuerySettings.Size = New System.Drawing.Size(130, 24)
        Me.cmdQuerySettings.TabIndex = 64
        Me.cmdQuerySettings.Text = "Query Settings"
        Me.cmdQuerySettings.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkCloseStatusWindow
        '
        Me.chkCloseStatusWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkCloseStatusWindow.Location = New System.Drawing.Point(376, 244)
        Me.chkCloseStatusWindow.Name = "chkCloseStatusWindow"
        Me.chkCloseStatusWindow.Size = New System.Drawing.Size(125, 18)
        Me.chkCloseStatusWindow.TabIndex = 62
        Me.chkCloseStatusWindow.Text = "Close Status Window"
        '
        'chkHideMOTDs
        '
        Me.chkHideMOTDs.BackColor = System.Drawing.Color.Transparent
        Me.chkHideMOTDs.Location = New System.Drawing.Point(376, 219)
        Me.chkHideMOTDs.Name = "chkHideMOTDs"
        Me.chkHideMOTDs.Size = New System.Drawing.Size(79, 18)
        Me.chkHideMOTDs.TabIndex = 62
        Me.chkHideMOTDs.Text = "Hide MOTD"
        '
        'chkShowNicknameWindow
        '
        Me.chkShowNicknameWindow.BackColor = System.Drawing.Color.Transparent
        Me.chkShowNicknameWindow.Location = New System.Drawing.Point(376, 195)
        Me.chkShowNicknameWindow.Name = "chkShowNicknameWindow"
        Me.chkShowNicknameWindow.Size = New System.Drawing.Size(145, 18)
        Me.chkShowNicknameWindow.TabIndex = 62
        Me.chkShowNicknameWindow.Text = "Show Nickname Window"
        '
        'chkCloseChannelFolder
        '
        Me.chkCloseChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkCloseChannelFolder.Location = New System.Drawing.Point(376, 171)
        Me.chkCloseChannelFolder.Name = "chkCloseChannelFolder"
        Me.chkCloseChannelFolder.Size = New System.Drawing.Size(126, 18)
        Me.chkCloseChannelFolder.TabIndex = 62
        Me.chkCloseChannelFolder.Text = "Close Channel Folder"
        '
        'chkAddToChannelFolder
        '
        Me.chkAddToChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkAddToChannelFolder.Location = New System.Drawing.Point(376, 147)
        Me.chkAddToChannelFolder.Name = "chkAddToChannelFolder"
        Me.chkAddToChannelFolder.Size = New System.Drawing.Size(133, 18)
        Me.chkAddToChannelFolder.TabIndex = 62
        Me.chkAddToChannelFolder.Text = "Add to Channel Folder"
        '
        'chkBrowseChannelURLs
        '
        Me.chkBrowseChannelURLs.BackColor = System.Drawing.Color.Transparent
        Me.chkBrowseChannelURLs.Location = New System.Drawing.Point(376, 123)
        Me.chkBrowseChannelURLs.Name = "chkBrowseChannelURLs"
        Me.chkBrowseChannelURLs.Size = New System.Drawing.Size(130, 18)
        Me.chkBrowseChannelURLs.TabIndex = 63
        Me.chkBrowseChannelURLs.Text = "Browse Channel URL's"
        '
        'RadLabel8
        '
        Me.RadLabel8.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel8.Location = New System.Drawing.Point(376, 99)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(63, 18)
        Me.RadLabel8.TabIndex = 62
        Me.RadLabel8.Text = "On Startup:"
        '
        'chkShowBrowser
        '
        Me.chkShowBrowser.BackColor = System.Drawing.Color.Transparent
        Me.chkShowBrowser.Location = New System.Drawing.Point(376, 75)
        Me.chkShowBrowser.Name = "chkShowBrowser"
        Me.chkShowBrowser.Size = New System.Drawing.Size(90, 18)
        Me.chkShowBrowser.TabIndex = 61
        Me.chkShowBrowser.Text = "Show Browser"
        '
        'chkShowCustomize
        '
        Me.chkShowCustomize.BackColor = System.Drawing.Color.Transparent
        Me.chkShowCustomize.Location = New System.Drawing.Point(376, 51)
        Me.chkShowCustomize.Name = "chkShowCustomize"
        Me.chkShowCustomize.Size = New System.Drawing.Size(103, 18)
        Me.chkShowCustomize.TabIndex = 60
        Me.chkShowCustomize.Text = "Show Customize"
        '
        'chkAutoConnect
        '
        Me.chkAutoConnect.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoConnect.Location = New System.Drawing.Point(376, 27)
        Me.chkAutoConnect.Name = "chkAutoConnect"
        Me.chkAutoConnect.Size = New System.Drawing.Size(89, 18)
        Me.chkAutoConnect.TabIndex = 59
        Me.chkAutoConnect.Text = "Auto Connect"
        '
        'RadLabel7
        '
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Location = New System.Drawing.Point(376, 3)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(63, 18)
        Me.RadLabel7.TabIndex = 51
        Me.RadLabel7.Text = "On Startup:"
        '
        'chkServerNotices
        '
        Me.chkServerNotices.BackColor = System.Drawing.Color.Transparent
        Me.chkServerNotices.Location = New System.Drawing.Point(176, 147)
        Me.chkServerNotices.Name = "chkServerNotices"
        Me.chkServerNotices.Size = New System.Drawing.Size(92, 18)
        Me.chkServerNotices.TabIndex = 52
        Me.chkServerNotices.Text = "Server Notices"
        '
        'chkLocalOp
        '
        Me.chkLocalOp.BackColor = System.Drawing.Color.Transparent
        Me.chkLocalOp.Location = New System.Drawing.Point(176, 123)
        Me.chkLocalOp.Name = "chkLocalOp"
        Me.chkLocalOp.Size = New System.Drawing.Size(64, 18)
        Me.chkLocalOp.TabIndex = 52
        Me.chkLocalOp.Text = "Local Op"
        '
        'chkOperator
        '
        Me.chkOperator.BackColor = System.Drawing.Color.Transparent
        Me.chkOperator.Location = New System.Drawing.Point(176, 99)
        Me.chkOperator.Name = "chkOperator"
        Me.chkOperator.Size = New System.Drawing.Size(65, 18)
        Me.chkOperator.TabIndex = 52
        Me.chkOperator.Text = "Operator"
        '
        'chkRestricted
        '
        Me.chkRestricted.BackColor = System.Drawing.Color.Transparent
        Me.chkRestricted.Location = New System.Drawing.Point(176, 75)
        Me.chkRestricted.Name = "chkRestricted"
        Me.chkRestricted.Size = New System.Drawing.Size(70, 18)
        Me.chkRestricted.TabIndex = 58
        Me.chkRestricted.Text = "Restricted"
        '
        'chkWallops
        '
        Me.chkWallops.BackColor = System.Drawing.Color.Transparent
        Me.chkWallops.Location = New System.Drawing.Point(176, 51)
        Me.chkWallops.Name = "chkWallops"
        Me.chkWallops.Size = New System.Drawing.Size(60, 18)
        Me.chkWallops.TabIndex = 57
        Me.chkWallops.Text = "Wallops"
        '
        'RadLabel6
        '
        Me.RadLabel6.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel6.Location = New System.Drawing.Point(173, 3)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(77, 18)
        Me.RadLabel6.TabIndex = 50
        Me.RadLabel6.Text = "Server Modes:"
        '
        'chkInvisible
        '
        Me.chkInvisible.BackColor = System.Drawing.Color.Transparent
        Me.chkInvisible.Location = New System.Drawing.Point(176, 27)
        Me.chkInvisible.Name = "chkInvisible"
        Me.chkInvisible.Size = New System.Drawing.Size(61, 18)
        Me.chkInvisible.TabIndex = 51
        Me.chkInvisible.Text = "Invisible"
        '
        'chkServerInNotices
        '
        Me.chkServerInNotices.BackColor = System.Drawing.Color.Transparent
        Me.chkServerInNotices.Location = New System.Drawing.Point(6, 292)
        Me.chkServerInNotices.Name = "chkServerInNotices"
        Me.chkServerInNotices.Size = New System.Drawing.Size(104, 18)
        Me.chkServerInNotices.TabIndex = 56
        Me.chkServerInNotices.Text = "Server in Notices"
        '
        'chkShowUserAddresses
        '
        Me.chkShowUserAddresses.BackColor = System.Drawing.Color.Transparent
        Me.chkShowUserAddresses.Location = New System.Drawing.Point(6, 268)
        Me.chkShowUserAddresses.Name = "chkShowUserAddresses"
        Me.chkShowUserAddresses.Size = New System.Drawing.Size(124, 18)
        Me.chkShowUserAddresses.TabIndex = 55
        Me.chkShowUserAddresses.Text = "Show user addresses"
        '
        'chkExtendedMessages
        '
        Me.chkExtendedMessages.BackColor = System.Drawing.Color.Transparent
        Me.chkExtendedMessages.Location = New System.Drawing.Point(6, 244)
        Me.chkExtendedMessages.Name = "chkExtendedMessages"
        Me.chkExtendedMessages.Size = New System.Drawing.Size(119, 18)
        Me.chkExtendedMessages.TabIndex = 52
        Me.chkExtendedMessages.Text = "Extended Messages"
        '
        'RadLabel5
        '
        Me.RadLabel5.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel5.Location = New System.Drawing.Point(6, 195)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(25, 18)
        Me.RadLabel5.TabIndex = 50
        Me.RadLabel5.Text = "IRC:"
        '
        'chkNoIRCMessages
        '
        Me.chkNoIRCMessages.BackColor = System.Drawing.Color.Transparent
        Me.chkNoIRCMessages.Location = New System.Drawing.Point(6, 219)
        Me.chkNoIRCMessages.Name = "chkNoIRCMessages"
        Me.chkNoIRCMessages.Size = New System.Drawing.Size(107, 18)
        Me.chkNoIRCMessages.TabIndex = 51
        Me.chkNoIRCMessages.Text = "No IRC Messages"
        '
        'chkAutoCloseSupportingWindows
        '
        Me.chkAutoCloseSupportingWindows.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoCloseSupportingWindows.Location = New System.Drawing.Point(6, 171)
        Me.chkAutoCloseSupportingWindows.Name = "chkAutoCloseSupportingWindows"
        Me.chkAutoCloseSupportingWindows.Size = New System.Drawing.Size(122, 18)
        Me.chkAutoCloseSupportingWindows.TabIndex = 54
        Me.chkAutoCloseSupportingWindows.Text = "Close on Disconnect"
        '
        'chkVideoBackground
        '
        Me.chkVideoBackground.BackColor = System.Drawing.Color.Transparent
        Me.chkVideoBackground.Location = New System.Drawing.Point(6, 147)
        Me.chkVideoBackground.Name = "chkVideoBackground"
        Me.chkVideoBackground.Size = New System.Drawing.Size(112, 18)
        Me.chkVideoBackground.TabIndex = 54
        Me.chkVideoBackground.Text = "Video Background"
        '
        'chkPopupChannelFolder
        '
        Me.chkPopupChannelFolder.BackColor = System.Drawing.Color.Transparent
        Me.chkPopupChannelFolder.Location = New System.Drawing.Point(6, 123)
        Me.chkPopupChannelFolder.Name = "chkPopupChannelFolder"
        Me.chkPopupChannelFolder.Size = New System.Drawing.Size(127, 18)
        Me.chkPopupChannelFolder.TabIndex = 53
        Me.chkPopupChannelFolder.Text = "Popup channel folder"
        '
        'chkAutoMaximize
        '
        Me.chkAutoMaximize.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoMaximize.Location = New System.Drawing.Point(6, 99)
        Me.chkAutoMaximize.Name = "chkAutoMaximize"
        Me.chkAutoMaximize.Size = New System.Drawing.Size(95, 18)
        Me.chkAutoMaximize.TabIndex = 52
        Me.chkAutoMaximize.Text = "Auto Maximize"
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(3, 3)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(96, 18)
        Me.RadLabel4.TabIndex = 0
        Me.RadLabel4.Text = "Interface Settings:"
        '
        'chkHideStatusOnClose
        '
        Me.chkHideStatusOnClose.BackColor = System.Drawing.Color.Transparent
        Me.chkHideStatusOnClose.Location = New System.Drawing.Point(6, 75)
        Me.chkHideStatusOnClose.Name = "chkHideStatusOnClose"
        Me.chkHideStatusOnClose.Size = New System.Drawing.Size(124, 18)
        Me.chkHideStatusOnClose.TabIndex = 51
        Me.chkHideStatusOnClose.Text = "Hide Status on Close"
        '
        'chkShowWindowsAutomatically
        '
        Me.chkShowWindowsAutomatically.BackColor = System.Drawing.Color.Transparent
        Me.chkShowWindowsAutomatically.Location = New System.Drawing.Point(6, 51)
        Me.chkShowWindowsAutomatically.Name = "chkShowWindowsAutomatically"
        Me.chkShowWindowsAutomatically.Size = New System.Drawing.Size(124, 18)
        Me.chkShowWindowsAutomatically.TabIndex = 50
        Me.chkShowWindowsAutomatically.Text = "Auto Show Windows"
        '
        'chkShowPrompts
        '
        Me.chkShowPrompts.BackColor = System.Drawing.Color.Transparent
        Me.chkShowPrompts.Location = New System.Drawing.Point(6, 27)
        Me.chkShowPrompts.Name = "chkShowPrompts"
        Me.chkShowPrompts.Size = New System.Drawing.Size(93, 18)
        Me.chkShowPrompts.TabIndex = 49
        Me.chkShowPrompts.Text = "Show Prompts"
        '
        'RadPageViewPage4
        '
        Me.RadPageViewPage4.Controls.Add(Me.lvwNotify)
        Me.RadPageViewPage4.Controls.Add(Me.Label19)
        Me.RadPageViewPage4.Controls.Add(Me.Label16)
        Me.RadPageViewPage4.Controls.Add(Me.cboNetworkNotify)
        Me.RadPageViewPage4.Controls.Add(Me.txtNotifyNickName)
        Me.RadPageViewPage4.Controls.Add(Me.lblNotifyMessage)
        Me.RadPageViewPage4.Controls.Add(Me.txtNotifyMessage)
        Me.RadPageViewPage4.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.RadPageViewPage4.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage4.Name = "RadPageViewPage4"
        Me.RadPageViewPage4.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage4.Text = "Notify"
        '
        'lvwNotify
        '
        ListViewDetailColumn7.HeaderText = "Name"
        ListViewDetailColumn8.HeaderText = "Network"
        ListViewDetailColumn9.HeaderText = "Message"
        Me.lvwNotify.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn7, ListViewDetailColumn8, ListViewDetailColumn9})
        Me.lvwNotify.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNotify.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNotify.ItemSpacing = -1
        Me.lvwNotify.Location = New System.Drawing.Point(4, 3)
        Me.lvwNotify.Name = "lvwNotify"
        Me.lvwNotify.Size = New System.Drawing.Size(514, 193)
        Me.lvwNotify.TabIndex = 23
        Me.lvwNotify.Text = "RadListView1"
        Me.lvwNotify.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        '
        'RadPageViewPage5
        '
        Me.RadPageViewPage5.Controls.Add(Me.GroupBox2)
        Me.RadPageViewPage5.Controls.Add(Me.lvwStrings)
        Me.RadPageViewPage5.Controls.Add(Me.cmdCompatibility)
        Me.RadPageViewPage5.Controls.Add(Me.GroupBox1)
        Me.RadPageViewPage5.Controls.Add(Me.cmdEditString)
        Me.RadPageViewPage5.Controls.Add(Me.GroupBox3)
        Me.RadPageViewPage5.Image = Global.nexIRC.My.Resources.Resources.film
        Me.RadPageViewPage5.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage5.Name = "RadPageViewPage5"
        Me.RadPageViewPage5.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage5.Text = "Text"
        '
        'RadPageViewPage6
        '
        Me.RadPageViewPage6.Controls.Add(Me.lstIgnoreExtensions)
        Me.RadPageViewPage6.Controls.Add(Me.Label15)
        Me.RadPageViewPage6.Controls.Add(Me.fraDCCChat)
        Me.RadPageViewPage6.Controls.Add(Me.cmdDCCIgnoreRemove)
        Me.RadPageViewPage6.Controls.Add(Me.cmdNetworkSettings)
        Me.RadPageViewPage6.Controls.Add(Me.cmdDCCIgnoreAdd)
        Me.RadPageViewPage6.Controls.Add(Me.fraDCCSend)
        Me.RadPageViewPage6.Controls.Add(Me.lstDCCIgnoreItems)
        Me.RadPageViewPage6.Controls.Add(Me.chkAutoIgnoreExceptNotify)
        Me.RadPageViewPage6.Controls.Add(Me.cmdRemoveIgnoreExtension)
        Me.RadPageViewPage6.Controls.Add(Me.chkAutoCloseDialogs)
        Me.RadPageViewPage6.Controls.Add(Me.cmdAddIgnoreExtension)
        Me.RadPageViewPage6.Controls.Add(Me.Label6)
        Me.RadPageViewPage6.Controls.Add(Me.cboDCCFileExists)
        Me.RadPageViewPage6.Controls.Add(Me.Label8)
        Me.RadPageViewPage6.Controls.Add(Me.Label7)
        Me.RadPageViewPage6.Controls.Add(Me.chkPopupDownloadManager)
        Me.RadPageViewPage6.Controls.Add(Me.txtDownloadDirectory)
        Me.RadPageViewPage6.Image = Global.nexIRC.My.Resources.Resources.network1
        Me.RadPageViewPage6.Location = New System.Drawing.Point(10, 37)
        Me.RadPageViewPage6.Name = "RadPageViewPage6"
        Me.RadPageViewPage6.Size = New System.Drawing.Size(521, 311)
        Me.RadPageViewPage6.Text = "DCC"
        '
        'frmCustomize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(543, 398)
        Me.Controls.Add(Me.RadPageView1)
        Me.Controls.Add(Me.chkNewStatus)
        Me.Controls.Add(Me.cmdCancelNow)
        Me.Controls.Add(Me.cmdApplyNow)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.cmdConnectNow)
        Me.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustomize"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Customize"
        CType(Me.cmdCancelNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServersMove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServersClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdServerEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fraDCCSend.ResumeLayout(False)
        Me.fraDCCSend.PerformLayout()
        Me.fraDCCChat.ResumeLayout(False)
        Me.fraDCCChat.PerformLayout()
        CType(Me.cmdApplyNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdConnectNow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNewStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPageView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageView1.ResumeLayout(False)
        Me.RadPageViewPage1.ResumeLayout(False)
        Me.RadPageViewPage1.PerformLayout()
        CType(Me.lvwServers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNetworks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage2.ResumeLayout(False)
        Me.RadPageViewPage2.PerformLayout()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHomePage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdEditUserSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMyNickNames, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdClearMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdRemoveMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdAddMyNickName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage3.ResumeLayout(False)
        Me.RadPageViewPage3.PerformLayout()
        CType(Me.cmdInOwnWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdQuerySettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCloseStatusWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideMOTDs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowNicknameWindow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCloseChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAddToChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBrowseChannelURLs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowBrowser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowCustomize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoConnect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkServerNotices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLocalOp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOperator, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRestricted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkWallops, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInvisible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkServerInNotices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowUserAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExtendedMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoIRCMessages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoCloseSupportingWindows, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVideoBackground, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPopupChannelFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoMaximize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHideStatusOnClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowWindowsAutomatically, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowPrompts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage4.ResumeLayout(False)
        Me.RadPageViewPage4.PerformLayout()
        CType(Me.lvwNotify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPageViewPage5.ResumeLayout(False)
        Me.RadPageViewPage6.ResumeLayout(False)
        Me.RadPageViewPage6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optDisplayModeRaw As System.Windows.Forms.RadioButton
    Friend WithEvents optDisplayModeNormal As System.Windows.Forms.RadioButton
    Friend WithEvents optDisplayModeMinimal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optUnknownsOwn As System.Windows.Forms.RadioButton
    Friend WithEvents optUnknownsStatus As System.Windows.Forms.RadioButton
    Friend WithEvents optUnknownsHide As System.Windows.Forms.RadioButton
    Friend WithEvents txtNotifyMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblNotifyMessage As System.Windows.Forms.Label
    Friend WithEvents txtNotifyNickName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdEditString As System.Windows.Forms.Button
    Friend WithEvents lvwStrings As System.Windows.Forms.ListView
    'Friend WithEvents chkHideChildrenOnFocus As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboNetworkNotify As System.Windows.Forms.ComboBox
    'Friend WithEvents sldTextSpeed As AxComctlLib.AxSlider
    'Friend WithEvents sldHammerTime As AxComctlLib.AxSlider
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents fraDCCChat As System.Windows.Forms.GroupBox
    Friend WithEvents optDCCChatIgnore As System.Windows.Forms.RadioButton
    Friend WithEvents optDCCChatAcceptAll As System.Windows.Forms.RadioButton
    Friend WithEvents optDCCChatPrompt As System.Windows.Forms.RadioButton
    Friend WithEvents fraDCCSend As System.Windows.Forms.GroupBox
    Friend WithEvents optDCCSendAcceptAll As System.Windows.Forms.RadioButton
    Friend WithEvents optDCCSendPrompt As System.Windows.Forms.RadioButton
    Friend WithEvents optDCCSendIgnore As System.Windows.Forms.RadioButton
    Friend WithEvents cmdNetworkSettings As System.Windows.Forms.Button
    Friend WithEvents chkAutoIgnoreExceptNotify As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoCloseDialogs As System.Windows.Forms.CheckBox
    Friend WithEvents cboDCCFileExists As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDownloadDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkPopupDownloadManager As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmdDCCIgnoreRemove As System.Windows.Forms.Button
    Friend WithEvents cmdDCCIgnoreAdd As System.Windows.Forms.Button
    Friend WithEvents lstDCCIgnoreItems As System.Windows.Forms.ListBox
    Friend WithEvents cmdRemoveIgnoreExtension As System.Windows.Forms.Button
    Friend WithEvents cmdAddIgnoreExtension As System.Windows.Forms.Button
    Friend WithEvents lstIgnoreExtensions As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdCompatibility As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optUnsupportedOwn As System.Windows.Forms.RadioButton
    Friend WithEvents optUnsupportedStatus As System.Windows.Forms.RadioButton
    Friend WithEvents optUnsupportedHide As System.Windows.Forms.RadioButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lnkNetworkDelete As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNetworkAdd As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdServerEdit As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServerAdd As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServerDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServersMove As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdServersClear As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdConnectNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdApplyNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancelNow As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkNewStatus As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadPageView1 As Telerik.WinControls.UI.RadPageView
    Friend WithEvents RadPageViewPage1 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage2 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage3 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage4 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage5 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents RadPageViewPage6 As Telerik.WinControls.UI.RadPageViewPage
    Friend WithEvents txtServerPort As System.Windows.Forms.TextBox
    Friend WithEvents cboNetworks As Telerik.WinControls.UI.RadDropDownList
    Private WithEvents lvwServers As Telerik.WinControls.UI.RadListView
    Friend WithEvents cmdClearMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdRemoveMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdAddMyNickName As Telerik.WinControls.UI.RadButton
    Friend WithEvents cboMyNickNames As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmdEditUserSettings As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton3 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtURL As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblHomePage As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkShowWindowsAutomatically As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowPrompts As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkHideStatusOnClose As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoMaximize As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkPopupChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkNoIRCMessages As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoCloseSupportingWindows As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkVideoBackground As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkServerInNotices As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowUserAddresses As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkExtendedMessages As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkServerNotices As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkLocalOp As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkOperator As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkRestricted As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkWallops As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkInvisible As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkCloseStatusWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkHideMOTDs As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowNicknameWindow As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkCloseChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAddToChannelFolder As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkBrowseChannelURLs As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents chkShowBrowser As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkShowCustomize As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents chkAutoConnect As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmdInOwnWindow As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdQuerySettings As Telerik.WinControls.UI.RadButton
    Friend WithEvents lvwNotify As Telerik.WinControls.UI.RadListView
End Class
