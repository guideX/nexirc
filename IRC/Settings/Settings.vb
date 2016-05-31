'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports System.IO
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Enum
Imports nexIRC.Models.Compatibility
Imports nexIRC.Models.Media
Imports nexIRC.Business.Helpers
Imports nexIRC.Models.ChannelFolder
Imports nexIRC.Models.Query
Imports nexIRC.Models
Imports nexIRC.Models.Network
Imports nexIRC.Models.Server

Public Class Settings
    Structure gArraySizes
        Public aCompatibility As Integer
        Public aProcess As Integer
        Public aNickList As Integer
        Public aAutoAllowList As Integer
        Public aAutoDenyList As Integer
        Public aSpamFilterCount As Integer
        Public aRecientServers As Integer
        Public aNotifyItems As Integer
        Public aNetworks As Integer
        Public aServers As Integer
        Public aNickNames As Integer
        Public aServices As Integer
        Public aServiceCommands As Integer
        Public aServiceParams As Integer
        Public aDCCIgnore As Integer
        Public aDownloadManager As Integer
        Public aChannelFolder As Integer
        Public aChannelList As Integer
        Public aStatusWindows As Integer
        Public aChannelWindows As Integer
        Public aServerLinks As Integer
        Public aQueries As Integer
        Public aStrings As Integer
        Public aPlaylists As Integer
        Public aMediaFiles As Integer
        Public aSub As Integer
    End Structure

    Structure gINI
        Public iBasePath As String
        Public iCompatibility As String
        Public iMedia As String
        Public iQuery As String
        Public iQueryLogs As String
        Public iDCC As String
        Public iNetworks As String
        Public iIRC As String
        Public iNicks As String
        Public iIdent As String
        Public iServers As String
        Public iErrors As String
        Public iChannelFolders As String
        Public iText As String
        Public iStringSettings As String
        Public iNotify As String
        Public iServices As String
        Public iCommands As String
        Public iDownloadManager As String
        Public iRecientServers As String
        Public iPlaylists As String
        Public iNotepad As String
    End Structure

    Structure gNick
        Public nNick As String
    End Structure

    Structure gNicks
        Public nCount As Integer
        Public nIndex As Integer
        Public nNick() As gNick
    End Structure

    Structure gIdentdSettings
        Public iEnabled As Boolean
    End Structure

    Structure gNotify
        Public nNickName As String
        Public nMessage As String
        Public nNetwork As String
    End Structure

    Structure gNotifyList
        Public nModified As Boolean
        Public nCount As Integer
        Public nNotify() As gNotify
    End Structure

    Structure gIdentd
        Public iUserID As String
        Public iSystem As String
        Public iPort As Long
        Public iSettings As gIdentdSettings
    End Structure

    Structure gStringSettings
        Public sUnknowns As UnknownsIn
        Public sUnsupported As UnsupportedIn
        'Public sServerInNotices As Boolean
    End Structure

    Structure gDownload
        Public dFileName As String
        Public dFilePath As String
        Public dNickName As String
    End Structure

    Structure gDownloadManager
        Public dDownload() As gDownload
        Public dCount As Integer
    End Structure

    Structure gIgnoreExtensions
        Public iCount As Integer
        Public iExtension As String
    End Structure

    Structure gWindowSize
        Public wWidth As Integer
        Public wHeight As Integer
    End Structure

    Structure gInitialWindowSizes
        Public iChannel As gWindowSize
        Public iNotice As gWindowSize
        Public lStatus As gWindowSize
    End Structure

    Structure gSettings
        Public sNetworkAvailability As Boolean
        Public sAutoAddToChannelFolder As Boolean
        Public sWindowSizes As gInitialWindowSizes
        Public sPrompts As Boolean
        Public sOper As Boolean
        Public sExtendedMessages As Boolean
        Public sNoIRCMessages As Boolean
        Public sCustomizeOnStartup As Boolean
        Public sPopupChannelFolders As Boolean
        Public sMOTDInOwnWindow As Boolean
        Public sHideMOTD As Boolean
        Public sChangeNickNameWindow As Boolean
        Public sNoticesInOwnWindow As Boolean
        Public sStringSettings As gStringSettings
        Public sURL As String
        Public sShowUserAddresses As Boolean
        Public sShowRawWindow As Boolean
        Public sShowWindowsAutomatically As Boolean
        Public sAutoMaximize As Boolean
        Public sQuitMessage As String
        'Public sHideStatusOnClose As Boolean
        Public sAutoConnect As Boolean
        Public sVideoBackground As Boolean
        Public sChannelFolderCloseOnJoin As Boolean
        Public sAutoNavigateChannelUrls As Boolean
        Public sCloseWindowOnDisconnect As Boolean
        Public sTextBufferSize As Integer
    End Structure

    Structure gIRC
        Public iInitialized As Boolean
        Public iNicks As gNicks
        Public iIdent As gIdentd
        Public iSettings As gSettings
        Public iPass As String
        Public iEMail As String
        Public iRealName As String
        Public iOperName As String
        Public iOperPass As String
        Public iModes As ModeModel
    End Structure

    Structure gWinVisible
        Public wMain As Boolean
        Public wCustomize As Boolean
        Public wAddNetwork As Boolean
        Public wAddNickName As Boolean
        Public wEditServer As Boolean
    End Structure

    Structure gRecientServers
        Public sCount As Integer
        Public sItem() As String
    End Structure

    Private lAway As Boolean
    Public lArraySizes As gArraySizes
    Public lDownloadManager As gDownloadManager
    Public lINI As gINI
    Public lWinVisible As gWinVisible
    Public lIRC As gIRC
    Public lServers As ServersModel = New ServersModel
    Public lNetworks As NetworksModel = New NetworksModel
    Public lChannelFolders As List(Of ChannelFolderModel) = New List(Of ChannelFolderModel)
    Public lNotify As gNotifyList
    Public lQuerySettings As QueryModel
    Public lRecientServers As gRecientServers
    Public lPlaylists As List(Of PlaylistModel) = New List(Of PlaylistModel)
    Public lMediaFiles As List(Of MediaFileModel) = New List(Of MediaFileModel)
    Public lCompatibility As New List(Of CompatibilityModel)
    Public lBlack As Boolean = False

    Public Function FindCompatibilityIndex(ByVal lDescription As String) As Integer
        Dim result As Integer
        Try
            For i As Integer = 1 To lCompatibility.Count
                With lCompatibility(i)
                    If LCase(Trim(.Description)) = LCase(Trim(lDescription)) Then
                        result = i
                        Exit For
                    End If
                End With
            Next i
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub SaveCompatibility()
        Dim i As Integer
        NativeMethods.WriteINI(lINI.iCompatibility, "Settings", "Count", Trim(lCompatibility.Count.ToString))
        For i = 1 To lCompatibility.Capacity
            With lCompatibility(i)
                NativeMethods.WriteINI(lINI.iCompatibility, Trim(i.ToString), "Description", .Description)
                NativeMethods.WriteINI(lINI.iCompatibility, Trim(i.ToString), "Enabled", Trim(.Enabled.ToString))
            End With
        Next i
    End Sub

    Public Sub LoadCompatibility()
        Dim i As Integer, c As Integer
        c = NativeMethods.ReadINIInt(lINI.iCompatibility, "Settings", "Count", 0)
        For i = 1 To c
            Dim newItem = New CompatibilityModel()
            newItem.Description = NativeMethods.ReadINI(lINI.iCompatibility, i.ToString, "Description", "")
            newItem.Enabled = NativeMethods.ReadINIBool(lINI.iCompatibility, i.ToString, "Enabled", False)
            lCompatibility.Add(newItem)
        Next i
    End Sub

    Public Sub AddToCompatibility(ByVal description As String, ByVal enabled As Boolean)
        If (Not String.IsNullOrEmpty(description)) Then
            'lCompatibility.Modified = True
            Dim c = New CompatibilityModel
            c.Description = description
            c.Enabled = enabled
            lCompatibility.Add(c)
        End If
    End Sub

    Public Sub RemoveFromCompatibility(ByVal lIndex As Integer)
        Try
            'lCompatibility.Modified = True
            With lCompatibility(lIndex)
                .Enabled = False
                .Description = ""
            End With
            SortCompatibility()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SortCompatibility()
        Dim lEnabled(lArraySizes.aCompatibility) As Boolean, lDescription(lArraySizes.aCompatibility) As String, i As Integer, c As Integer
        For i = 1 To lCompatibility.Count
            With lCompatibility(i)
                lEnabled(i) = .Enabled
                lDescription(i) = .Description
                .Enabled = False
                .Description = ""
            End With
        Next i
        For i = 1 To lArraySizes.aCompatibility
            If Len(lDescription(i)) <> 0 Then
                c = c + 1
                With lCompatibility(c)
                    .Description = lDescription(i)
                    .Enabled = lEnabled(i)
                End With
            End If
        Next i
    End Sub

    Public Sub LoadPlaylists()
        Dim i As Integer
        Dim c = NativeMethods.ReadINIInt(lINI.iPlaylists, "Settings", "Count", 0)
        For i = 1 To c
            Dim p = New PlaylistModel
            p.Name = NativeMethods.ReadINI(lINI.iPlaylists, "Settings", Trim(i.ToString), "Name")
            p.Type = CType(NativeMethods.ReadINIInt(lINI.iPlaylists, Trim(i.ToString), "Type", 0), PlaylistType)
        Next i
    End Sub

    Public Sub NewPlaylist(ByVal name As String)
        Dim p = New PlaylistModel
        p.Name = name
        lPlaylists.Add(p)
    End Sub

    Public Sub LoadMediaFiles()
        Try
            Dim i As Integer
            With lMediaFiles
                Dim n = NativeMethods.ReadINIInt(lINI.iMedia, "Settings", "Count", 0)
                For i = 1 To n
                    Dim f = New MediaFileModel
                    f.File = NativeMethods.ReadINI(lINI.iMedia, i.ToString, "File", "")
                Next i
            End With
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveMediaFiles()
        Try
            Dim i As Integer
            With lMediaFiles
                NativeMethods.WriteINI(lINI.iMedia, "Settings", "Count", Trim(lMediaFiles.Count.ToString))
                For i = 1 To lMediaFiles.Count
                    NativeMethods.WriteINI(lINI.iMedia, Trim(i.ToString), "File", lMediaFiles(i).File)
                Next i
            End With
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Public Sub SaveMediaFiles()")
        End Try
    End Sub

    Public Function ReturnDownloadManagerFullPath(ByVal lFileName As String) As String
        Try
            Dim i As Integer, msg As String = ""
            If Len(lFileName) <> 0 Then
                For i = 0 To lDownloadManager.dCount
                    With lDownloadManager.dDownload(i)
                        If LCase(Trim(.dFileName)) = LCase(Trim(lFileName)) Then
                            msg = .dFilePath & .dFileName
                        End If
                    End With
                Next i
            End If
            Return msg
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub AddToRecientServerList(ByVal lServerIndex As Integer)
        Try
            Dim msg As String
            If lServerIndex <> 0 Then
                msg = lServers.Servers(lServerIndex).Ip
                If msg = lRecientServers.sItem(1) Or msg = lRecientServers.sItem(2) Or msg = lRecientServers.sItem(3) Then Exit Sub
                lRecientServers.sItem(3) = lRecientServers.sItem(2)
                lRecientServers.sItem(2) = lRecientServers.sItem(1)
                lRecientServers.sItem(1) = msg
                RefreshRecientServersMenu()
                SaveRecientServers()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadRecientServers()
        Try
            Dim i As Integer
            lRecientServers.sCount = lArraySizes.aRecientServers
            ReDim lRecientServers.sItem(lRecientServers.sCount)
            For i = 1 To lRecientServers.sCount
                lRecientServers.sItem(i) = NativeMethods.ReadINI(lINI.iRecientServers, "Items", Trim(i.ToString), "")
            Next i
            RefreshRecientServersMenu()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub RefreshRecientServersMenu()
        Try
            mdiMain.cmd_RecientServer1.Text = lRecientServers.sItem(1)
            mdiMain.cmd_RecientServer2.Text = lRecientServers.sItem(2)
            mdiMain.cmd_RecientServer3.Text = lRecientServers.sItem(3)
            If Len(mdiMain.cmd_RecientServer1.Text) = 0 Then
                mdiMain.cmd_RecientServer1.Text = "(Empty)"
                mdiMain.cmd_RecientServer1.Enabled = False
            Else
                mdiMain.cmd_RecientServer1.Enabled = True
            End If
            If Len(mdiMain.cmd_RecientServer2.Text) = 0 Then
                mdiMain.cmd_RecientServer2.Text = "(Empty)"
                mdiMain.cmd_RecientServer2.Enabled = False
            Else
                mdiMain.cmd_RecientServer2.Enabled = True
            End If
            If Len(mdiMain.cmd_RecientServer3.Text) = 0 Then
                mdiMain.cmd_RecientServer3.Text = "(Empty)"
                mdiMain.cmd_RecientServer3.Enabled = False
            Else
                mdiMain.cmd_RecientServer3.Enabled = True
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveRecientServers()
        Try
            Dim i As Integer
            For i = 1 To lRecientServers.sCount
                NativeMethods.WriteINI(lINI.iRecientServers, "Items", Trim(i.ToString), lRecientServers.sItem(i))
            Next i
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub WriteTextFile(ByVal lFileName As String, ByVal lData As String)
        Try
            Dim w As StreamWriter
            w = New StreamWriter(lFileName)
            w.Write(lData)
            w.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ReadTextFile(ByVal lFileName As String) As String
        Try
            Dim r As StreamReader, msg As String, msg2 As String
            r = New StreamReader(lFileName)
            msg = r.ReadLine
            msg2 = ""
            Do While Not msg Is Nothing
                If Len(msg2) <> 0 Then
                    msg2 = msg2 & Environment.NewLine & msg
                Else
                    msg2 = msg
                End If
            Loop
            ReadTextFile = msg2
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub LoadQuerySettings()
        Dim i As Integer
        lQuerySettings = New QueryModel
        lQuerySettings.AutoAllow = CType(NativeMethods.ReadINI(lINI.iQuery, "Settings", "AutoAllow", "1"), QueryOption)
        lQuerySettings.AutoDeny = CType(NativeMethods.ReadINI(lINI.iQuery, "Settings", "AutoDeny", "1"), QueryOption)
        lQuerySettings.StandByMessage = NativeMethods.ReadINI(lINI.iQuery, "Settings", "StandByMessage", "")
        lQuerySettings.DeclineMessage = NativeMethods.ReadINI(lINI.iQuery, "Settings", "DeclineMessage", "")
        lQuerySettings.EnableSpamFilter = NativeMethods.ReadINIBool(lINI.iQuery, "Settings", "EnableSpamFilter ", True)
        lQuerySettings.PromptUser = NativeMethods.ReadINIBool(lINI.iQuery, "Settings", "PromptUser", False)
        lQuerySettings.AutoShowWindow = NativeMethods.ReadINIBool(lINI.iQuery, "Settings", "AutoShowWindow", True)
        For i = 1 To NativeMethods.ReadINIInt(lINI.iQuery, "Settings", "AutoAllowCount", 0)
            lQuerySettings.AutoAllowList.Add(NativeMethods.ReadINI(lINI.iQuery, "AutoAllowList", i.ToString, ""))
        Next i
        For i = 0 To lQuerySettings.AutoDenyList.Count - 1
            lQuerySettings.AutoDenyList(i) = NativeMethods.ReadINI(lINI.iQuery, "AutoDenyList", i.ToString, "")
        Next i
        For i = 0 To lQuerySettings.SpamPhrases.Count - 1
            lQuerySettings.SpamPhrases(i) = NativeMethods.ReadINI(lINI.iQuery, "SpamPhrases", Trim(i.ToString), "")
        Next i
    End Sub

    Public Sub SaveQuerySettings()
        Dim i As Integer
        With lQuerySettings
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "AutoAllow", Convert.ToInt32(.AutoAllow).ToString)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "AutoDeny", Convert.ToInt32(.AutoDeny).ToString)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "StandByMessage", .StandByMessage)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "DeclineMessage", .DeclineMessage)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "EnableSpamFilter", Trim(.EnableSpamFilter.ToString))
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "PromptUser", Trim(.PromptUser.ToString))
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "AutoAllowCount", .AutoAllowList.Count.ToString)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "AutoDenyCount", .AutoDenyList.Count.ToString)
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "SpamPhraseCount", Trim(.SpamPhrases.Count.ToString))
            NativeMethods.WriteINI(lINI.iQuery, "Settings", "AutoShowWindow", Trim(.AutoShowWindow.ToString))
            For i = 1 To .AutoAllowList.Count
                NativeMethods.WriteINI(lINI.iQuery, "AutoAllowList", Trim(i.ToString), .AutoAllowList(i))
            Next i
            For i = 1 To .AutoDenyList.Count
                NativeMethods.WriteINI(lINI.iQuery, "AutoDenyList", Trim(i.ToString), .AutoDenyList(i))
            Next i
            For i = 1 To .SpamPhrases.Count
                NativeMethods.WriteINI(lINI.iQuery, "SpamPhrases", Trim(i.ToString), .SpamPhrases(i))
            Next i
        End With
    End Sub

    Public Sub PopulateNotifyByListView(ByVal lListView As RadListView)
        Try
            Dim i As Integer, n As Integer
            For i = 0 To (lListView.Items.Count - 1)
                n = n + 1
                With lListView.Items(i)
                    lNotify.nNotify(n).nNickName = .Text
                    lNotify.nNotify(n).nNetwork = .Item(2).ToString
                    lNotify.nNotify(n).nMessage = .Item(1).ToString
                End With
            Next i
            lNotify.nCount = n
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function FindNotifyIndex(ByVal lNickName As String) As Integer
        Try
            Dim i As Integer
            FindNotifyIndex = 0
            If Len(lNickName) <> 0 Then
                For i = 1 To lNotify.nCount
                    If LCase(Trim(lNickName)) = LCase(Trim(lNotify.nNotify(i).nNickName)) Then
                        FindNotifyIndex = i
                        Exit For
                    End If
                Next i
            End If
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function ReturnAwayStatus() As Boolean
        ReturnAwayStatus = lAway
    End Function

    Public Sub SetAwayStatus(ByVal lStatus As Boolean)
        lAway = lStatus
    End Sub

    Public Sub LoadNotifyList()
        Dim i As Integer
        ReDim lNotify.nNotify(lArraySizes.aNotifyItems)
        lNotify.nCount = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iNotify, "Settings", "Count", "0")))
        If lNotify.nCount <> 0 Then
            For i = 1 To lNotify.nCount
                With lNotify.nNotify(i)
                    .nNickName = NativeMethods.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "NickName", "")
                    .nMessage = NativeMethods.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "Message", "")
                    .nNetwork = NativeMethods.ReadINI(lINI.iNotify, Trim(Convert.ToString(i)), "Network", "")
                End With
            Next i
        End If
    End Sub

    Public Sub AddToNotifyList(_Item As gNotify)
        Try
            lNotify.nCount = lNotify.nCount + 1
            With lNotify.nNotify(lNotify.nCount)
                .nNickName = _Item.nNickName
                .nNetwork = _Item.nNetwork
                .nMessage = _Item.nMessage
            End With
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Public Sub AddToNotifyList(_Item As gNotify)")
        End Try
    End Sub

    Public Sub SaveNotifyList()
        Dim i As Integer
        If lNotify.nModified = True Then
            NativeMethods.WriteINI(lINI.iNotify, "Settings", "Count", Trim(lNotify.nCount.ToString))
            For i = 1 To lNotify.nCount
                With lNotify.nNotify(i)
                    NativeMethods.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "NickName", .nNickName)
                    NativeMethods.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "Message", .nMessage)
                    NativeMethods.WriteINI(lINI.iNotify, Trim(Convert.ToString(i)), "Network", .nNetwork)
                End With
            Next i
            lNotify.nModified = False
        End If
    End Sub

    Public Function ReturnOtherNickName(ByVal lUnAcceptedNick As String) As String
        Dim i As Integer
        For i = 1 To lIRC.iNicks.nCount
            With lIRC.iNicks.nNick(i)
                If LCase(.nNick) <> lUnAcceptedNick And Len(.nNick) <> 0 Then
                    ReturnOtherNickName = .nNick
                    Exit Function
                End If
            End With
        Next i
        ReturnOtherNickName = ""
    End Function

    Public Function ReturnTextINI() As String
        ReturnTextINI = lINI.iText
    End Function

    Public Function ReturnCommandsINI() As String
        ReturnCommandsINI = lINI.iCommands
    End Function

    Public Function ReturnBasePath() As String
        ReturnBasePath = lINI.iBasePath
    End Function

    Public Sub SetArraySizes()
        With lArraySizes
            .aSub = 1000
            .aCompatibility = 1000
            .aPlaylists = 500
            .aMediaFiles = 20000
            .aProcess = 20000
            .aAutoAllowList = 100
            .aAutoDenyList = 100
            .aChannelFolder = 300
            .aChannelList = 500
            .aChannelWindows = 100
            .aDCCIgnore = 100
            .aDownloadManager = 300
            .aNetworks = 1000
            .aNickList = 2000
            .aNickNames = 100
            .aNotifyItems = 100
            .aQueries = 300
            .aRecientServers = 3
            .aServerLinks = 1000
            .aServers = 3000
            .aServiceCommands = 100
            .aServiceParams = 4
            .aServices = 100
            .aSpamFilterCount = 200
            .aStatusWindows = 300
            .aStrings = 300
        End With
        'ReDim lNetworks.Networks(lArraySizes.aNetworks)
        'ReDim lServers.Server(lArraySizes.aServers)
        ReDim lIRC.iNicks.nNick(lArraySizes.aNickNames)
    End Sub

    Private Sub SetINIFiles()
        With lINI
            .iBasePath = Path.GetDirectoryName(Application.ExecutablePath) & "\"
            .iNotepad = lINI.iBasePath & "data\config\notepad.txt"
            .iPlaylists = lINI.iBasePath & "data\config\playlists.ini"
            .iQueryLogs = lINI.iBasePath & "data\logs\query.txt"
            .iNotify = lINI.iBasePath & "data\config\notify.ini"
            .iStringSettings = lINI.iBasePath & "data\config\stringsettings.ini"
            .iNetworks = lINI.iBasePath & "data\config\networks.ini"
            .iDCC = lINI.iBasePath & "data\config\dcc.ini"
            .iQuery = lINI.iBasePath & "data\config\query.ini"
            .iServers = lINI.iBasePath & "data\config\servers.ini"
            .iIRC = lINI.iBasePath & "data\config\settings.ini"
            .iNicks = lINI.iBasePath & "data\config\nicknames.ini"
            .iIdent = lINI.iBasePath & "data\config\Ident.ini"
            .iErrors = lINI.iBasePath & "data\config\errors.ini"
            .iChannelFolders = lINI.iBasePath & "data\config\channelfolders.ini"
            .iText = lINI.iBasePath & "data\config\text.ini"
            .iCommands = lINI.iBasePath & "data\config\commands.ini"
            .iServices = lINI.iBasePath & "data\config\services.ini"
            .iDownloadManager = lINI.iBasePath & "data\config\downloadmanager.ini"
            .iRecientServers = lINI.iBasePath & "data\config\recientservers.ini"
            .iMedia = lINI.iBasePath & "data\config\media.ini"
            .iCompatibility = lINI.iBasePath & "data\config\compatibility.ini"
        End With
    End Sub
    Private Sub LoadNickNames()
        Dim i As Integer
        With lIRC.iNicks
            .nCount = Convert.ToInt32(NativeMethods.ReadINI(lINI.iNicks, "Settings", "Count", "0"))
            If .nCount <> 0 Then .nIndex = Convert.ToInt32(NativeMethods.ReadINI(lINI.iNicks, "Settings", "Index", "0"))
        End With
        If lIRC.iNicks.nCount <> 0 Then
            For i = 1 To lIRC.iNicks.nCount
                With lIRC.iNicks.nNick(i)
                    .nNick = NativeMethods.ReadINI(lINI.iNicks, Trim(Str(i)), "Nick", "")
                End With
            Next i
        End If
    End Sub

    Private Sub LoadIdent()
        With lIRC.iIdent
            .iSettings.iEnabled = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIdent, "Settings", "Enabled", Convert.ToString(True)))
            If .iSettings.iEnabled = True Then
                .iUserID = NativeMethods.ReadINI(lINI.iIdent, "Settings", "UserID", "")
                .iPort = Convert.ToInt64(NativeMethods.ReadINI(lINI.iIdent, "Settings", "Port", "0"))
                .iSystem = NativeMethods.ReadINI(lINI.iIdent, "Settings", "System", "")
            End If
        End With
    End Sub

    Public Sub LoadNetworks()
        Dim c = 0, index = 0
        c = NativeMethods.ReadINIInt(lINI.iNetworks, "Settings", "Count", 0)
        If c <> 0 Then index = NativeMethods.ReadINIInt(lINI.iNetworks, "Settings", "Index", 0)
        If c <> 0 Then
            lNetworks = New NetworksModel()
            lNetworks.Index = index
            For i As Integer = 1 To c
                Dim n = New NetworkModel
                n.Name = NativeMethods.ReadINI(lINI.iNetworks, i.ToString, "Description", "")
                n.ID = i
                If (Not String.IsNullOrEmpty(n.Name)) Then
                    lNetworks.Networks.Add(n)
                End If
            Next i
        End If
    End Sub

    Private Sub LoadServers()
        lServers.Servers = New List(Of ServerModel)
        lServers.Index = NativeMethods.ReadINIInt(lINI.iServers, "Settings", "Index", 0)
        For i As Integer = 1 To NativeMethods.ReadINIInt(lINI.iServers, "Settings", "Count", 0)
            Dim server = New ServerModel
            server.Description = NativeMethods.ReadINI(lINI.iServers, i.ToString, "Description", "")
            server.Ip = NativeMethods.ReadINI(lINI.iServers, i.ToString, "Ip", "")
            server.NetworkIndex = NativeMethods.ReadINIInt(lINI.iServers, i.ToString, "NetworkIndex", 0)
            server.Port = NativeMethods.ReadINIInt(lINI.iServers, i.ToString, "Port", 0)
            If (Not String.IsNullOrEmpty(server.Description) And Not String.IsNullOrEmpty(server.Ip)) Then
                lServers.Servers.Add(server)
            End If
        Next i
    End Sub

    Public Sub LoadStringSettings()
        Dim i As Integer
        With lIRC.iSettings.sStringSettings
            i = 0
            i = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iStringSettings, "Settings", "Unknowns", "2")))
            Select Case i
                Case 1
                    .sUnknowns = UnknownsIn.StatusWindow
                Case 2
                    .sUnknowns = UnknownsIn.OwnWindow
                Case 3
                    .sUnknowns = UnknownsIn.Hide
            End Select
            i = 0
            i = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iStringSettings, "Settings", "Unsupported", "2")))
            Select Case i
                Case 1
                    .sUnsupported = UnsupportedIn.StatusWindow
                Case 2
                    .sUnsupported = UnsupportedIn.OwnWindow
                Case 3
                    .sUnsupported = UnsupportedIn.Hide
            End Select
            '.sServerInNotices = Convert.ToBoolean(Trim(NativeMethods.ReadINI(lINI.iStringSettings, "Settings", "ServerInNotices", "True")))
        End With
    End Sub

    Private Sub LoadDownloadManager()
        Dim i As Integer
        ReDim lDownloadManager.dDownload(lArraySizes.aDownloadManager)
        With lDownloadManager
            .dCount = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iDownloadManager, "Settings", "Count", "0")))
            For i = 1 To .dCount
                .dDownload(i).dFileName = NativeMethods.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "FileName", "")
                .dDownload(i).dFilePath = NativeMethods.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "FilePath", "")
                .dDownload(i).dNickName = NativeMethods.ReadINI(lINI.iDownloadManager, Trim(i.ToString), "NickName", "")
            Next i
        End With
    End Sub

    Public Sub SetListViewToDownloadManager(ByVal lListView As ListView)
        Dim i As Integer
        For i = 1 To lDownloadManager.dCount
            With lDownloadManager.dDownload(i)
                lListView.Items.Add(.dFileName, 0)
            End With
        Next i
    End Sub

    Public Sub LoadSettings()
        If lIRC.iInitialized = False Then
            mdiMain.SetLoadingFormProgress("Setting INI Files", 5)
            SetINIFiles()
            mdiMain.SetLoadingFormProgress("Loading Recient Servers", 11)
            LoadRecientServers()
            mdiMain.SetLoadingFormProgress("Loading Services", 12)
            lSettings_Services.LoadServices()
            mdiMain.SetLoadingFormProgress("Loading String Settings", 15)
            LoadStringSettings()
            mdiMain.SetLoadingFormProgress("Loading Channel Folders", 17)
            LoadChannelFolders()
            mdiMain.SetLoadingFormProgress("Loading Nicknames", 22)
            LoadNickNames()
            mdiMain.SetLoadingFormProgress("Loading Ident", 25)
            LoadIdent()
            mdiMain.SetLoadingFormProgress("Loading Networks", 27)
            LoadNetworks()
            mdiMain.SetLoadingFormProgress("Loading Servers", 32)
            LoadServers()
            mdiMain.SetLoadingFormProgress("Loading Modes", 50)
            LoadModes()
            mdiMain.SetLoadingFormProgress("Loading Notify List", 52)
            LoadNotifyList()
            mdiMain.SetLoadingFormProgress("Loading Bot Commands", 55)
            lStrings.LoadCommands()
            mdiMain.SetLoadingFormProgress("Loading Compatibility", 60)
            LoadCompatibility()
            mdiMain.SetLoadingFormProgress("Loading DCC Settings", 65)
            lSettings_DCC.LoadDCCSettings()
            mdiMain.SetLoadingFormProgress("Loading Download Manager", 68)
            LoadDownloadManager()
            mdiMain.SetLoadingFormProgress("Loading IRC Settings", 70)
            With lIRC.iSettings
                .sChannelFolderCloseOnJoin = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ChannelFolderCloseOnJoin", "True"))
                .sShowUserAddresses = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ShowUserAddresses", "True"))
                .sHideMOTD = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "HideMOTD", "True"))
                .sPrompts = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "Prompts", "True"))
                .sShowRawWindow = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ShowRawWindow", "False"))
                .sExtendedMessages = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ExtendedMessages", "True"))
                .sNoIRCMessages = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "NoIRCMessages", "False"))
                .sCustomizeOnStartup = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ShowCustomizeOnStartup", "False"))
                .sPopupChannelFolders = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "PopupChannelFolders", "True"))
                .sMOTDInOwnWindow = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "MOTDInOwnWindow", "True"))
                .sChangeNickNameWindow = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ChangeNickNameWindow", "True"))
                .sNoticesInOwnWindow = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "NoticesInOwnWindow", "True"))
                .sURL = NativeMethods.ReadINI(lINI.iIRC, "Settings", "URL", "http: //www.bing.com")
                .sShowWindowsAutomatically = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "ShowWindowsAutomatically", "False"))
                .sAutoMaximize = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "AutoMaximize", "False"))
                .sQuitMessage = NativeMethods.ReadINI(lINI.iIRC, "Settings", "QuitMessage", "nexIRC - http://www.team-nexgen.com/")
                .sAutoConnect = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "AutoConnect", "False"))
                .sVideoBackground = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "VideoBackground", "True"))
                .sAutoNavigateChannelUrls = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "AutoNavigateChannelUrls", "True"))
                .sCloseWindowOnDisconnect = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "CloseWindowOnDisconnect", "False"))
                .sAutoAddToChannelFolder = Convert.ToBoolean(NativeMethods.ReadINI(lINI.iIRC, "Settings", "AutoAddToChannelFolder", "True"))
                .sWindowSizes.iChannel.wWidth = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iIRC, "Settings", "InitialChannelWidth", "600")))
                .sWindowSizes.iChannel.wHeight = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iIRC, "Settings", "InitialChannelHeight", "200")))
                .sWindowSizes.lStatus.wWidth = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iIRC, "Settings", "InitialStatusWidth", "600")))
                .sWindowSizes.lStatus.wHeight = Convert.ToInt32(Trim(NativeMethods.ReadINI(lINI.iIRC, "Settings", "InitialStatusHeight", "200")))
                .sWindowSizes.iNotice.wWidth = NativeMethods.ReadINIInt(lINI.iIRC, "Settings", "InitialNoticeWidth", 600)
                .sWindowSizes.iNotice.wHeight = NativeMethods.ReadINIInt(lINI.iIRC, "Settings", "InitialNoticeHeight", 200)
                .sTextBufferSize = NativeMethods.ReadINIInt(lINI.iIRC, "Settings", "TextBufferSize", 150)
            End With
            With lIRC
                .iEMail = NativeMethods.ReadINI(lINI.iIRC, "Settings", "EMail", "user@team-nexgen.com")
                .iPass = NativeMethods.ReadINI(lINI.iIRC, "Settings", "Password", "")
                .iRealName = NativeMethods.ReadINI(lINI.iIRC, "Settings", "RealName", "nexIRC User")
                .iOperName = NativeMethods.ReadINI(lINI.iIRC, "Settings", "OperName", "")
                .iOperPass = NativeMethods.ReadINI(lINI.iIRC, "Settings", "OperPass", "")
            End With
        End If
        mdiMain.SetLoadingFormProgress("Loading Strings", 80)
        lStrings.LoadStrings()
        mdiMain.SetLoadingFormProgress("Loading Query Settings", 95)
        LoadQuerySettings()
    End Sub

    Public Sub SaveWindowSizes()
        With lIRC.iSettings
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialChannelWidth", .sWindowSizes.iChannel.wWidth.ToString.Trim)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialChannelHeight", .sWindowSizes.iChannel.wHeight.ToString.Trim)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialStatusWidth", .sWindowSizes.lStatus.wWidth.ToString.Trim)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialStatusHeight", .sWindowSizes.lStatus.wHeight.ToString.Trim)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialNoticeWidth", .sWindowSizes.iNotice.wWidth.ToString.Trim)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "InitialNoticeHeight", .sWindowSizes.iNotice.wHeight.ToString.Trim)
        End With
    End Sub

    Public Sub StartupSettings()
        With lIRC.iSettings
            If .sCustomizeOnStartup = True Then
                frmCustomize.Show()
            End If
        End With
    End Sub

    Public Function FindDownloadManagerIndexByFileName(ByVal fileName As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(fileName)) Then
                For i = 1 To lDownloadManager.dCount
                    With lDownloadManager.dDownload(i)
                        If LCase(fileName) = LCase(.dFileName) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub AddToDownloadManager(ByVal lFile As String, ByVal lNickname As String, Optional ByVal lShowDownloadManager As Boolean = False)
        Dim msg As String, msg2 As String
        msg = lStrings.GetFileTitle(lFile)
        msg2 = Left(lFile, Len(lFile) - Len(msg))
        If Len(msg) <> 0 And Len(msg2) <> 0 And Len(lNickname) <> 0 Then
            If FindDownloadManagerIndexByFileName(msg) = 0 Then
                lDownloadManager.dCount = lDownloadManager.dCount + 1
                With lDownloadManager.dDownload(lDownloadManager.dCount)
                    .dFileName = msg
                    .dFilePath = msg2
                    .dNickName = lNickname
                End With
                SaveDownloadManagerSettings()
                If lShowDownloadManager = True Then frmDownloadManager.Show()
            End If
        End If
    End Sub

    Public Sub RemoveFromDownloadManager(ByVal lIndex As Integer)
        If lIndex <> 0 Then
            With lDownloadManager.dDownload(lIndex)
                .dFileName = ""
                .dFilePath = ""
                .dNickName = ""
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "FileName", "")
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "FilePath", "")
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(lIndex.ToString), "NickName", "")
            End With
        End If
    End Sub

    Private Sub SaveDownloadManagerSettings()
        Dim lFileName(300) As String, lFilePath(300) As String, lNickName(300) As String, i As Integer, n As Integer
        For i = 1 To lDownloadManager.dCount
            With lDownloadManager.dDownload(i)
                If Len(.dFileName) <> 0 And Len(.dFilePath) <> 0 And Len(.dNickName) <> 0 Then
                    n = n + 1
                    lFileName(n) = .dFileName
                    lFilePath(n) = .dFilePath
                    lNickName(n) = .dNickName
                End If
            End With
        Next i
        If n <> 0 Then
            NativeMethods.WriteINI(lINI.iDownloadManager, "Settings", "Count", Trim(lDownloadManager.dCount.ToString))
            For i = 1 To n
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "FileName", lFileName(i))
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "FilePath", lFilePath(i))
                NativeMethods.WriteINI(lINI.iDownloadManager, Trim(i.ToString), "NickName", lNickName(i))
            Next i
        End If
    End Sub

    Private Sub SaveIdentdSettings()
        With lIRC.iIdent
            NativeMethods.WriteINI(lINI.iIdent, "Settings", "UserID", .iUserID)
            NativeMethods.WriteINI(lINI.iIdent, "Settings", "System", .iSystem)
            NativeMethods.WriteINI(lINI.iIdent, "Settings", "Port", .iPort.ToString)
            NativeMethods.WriteINI(lINI.iIdent, "Settings", "Enabled", Trim(.iSettings.iEnabled.ToString))
        End With
    End Sub

    Public Function ReturnNickIndex(ByVal nickName As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(nickName)) Then
                For i = 1 To lIRC.iNicks.nCount
                    With lIRC.iNicks.nNick(i)
                        If (nickName.ToLower() = .nNick.ToLower) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Private Sub SaveNickNames()
        Dim nickNames As List(Of String), i As Integer, nickName As String, n As Integer
        Try
            nickNames = New List(Of String)
            For i = 1 To lIRC.iNicks.nCount
                If (Not String.IsNullOrEmpty(lIRC.iNicks.nNick(i).nNick)) Then
                    nickNames.Add(lIRC.iNicks.nNick(i).nNick)
                End If
            Next i
            nickNames = nickNames.Distinct().ToList()
            n = 0
            For Each nickName In nickNames
                n = n + 1
                NativeMethods.WriteINI(lINI.iNicks, n.ToString(), "Nick", nickName)
            Next nickName
            If (lIRC.iNicks.nIndex <> 0) Then NativeMethods.WriteINI(lINI.iNicks, "Settings", "Index", lIRC.iNicks.nIndex.ToString())
            If (lIRC.iNicks.nIndex <> 0) Then NativeMethods.WriteINI(lINI.iNicks, "Settings", "Count", n.ToString())
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveSettings()
        With lIRC.iSettings
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "TextBufferSize", .sTextBufferSize.ToString().Trim())
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "AutoNavigateChannelUrls", Trim(.sAutoNavigateChannelUrls.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ChannelFolderCloseOnJoin", Trim(.sChannelFolderCloseOnJoin.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "VideoBackground", Trim(.sVideoBackground.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "QuitMessage", .sQuitMessage)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Prompts", Trim(.sPrompts.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ShowUserAddresses", Trim(.sShowUserAddresses.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "URL", .sURL)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "MOTDInOwnWindow", Trim(.sMOTDInOwnWindow.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "PopupChannelFolders", Trim(.sPopupChannelFolders.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ShowCustomizeOnStartup", Trim(.sCustomizeOnStartup.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "NoIRCMessages", Trim(.sNoIRCMessages.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ExtendedMessages", Trim(.sExtendedMessages.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ChangeNickNameWindow", Trim(.sChangeNickNameWindow.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "NoticesInOwnWindow", Trim(.sNoticesInOwnWindow.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "HideMOTD", Trim(.sHideMOTD.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ShowRawWindow", Trim(.sShowRawWindow.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ShowWindowsAutomatically", Trim(.sShowWindowsAutomatically.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "AutoMaximize", Trim(.sAutoMaximize.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "AutoConnect", Trim(.sAutoConnect.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "CloseWindowOnDisconnect", Trim(.sCloseWindowOnDisconnect.ToString))
            SaveWindowSizes()
        End With
        With lIRC.iSettings.sStringSettings
            NativeMethods.WriteINI(lINI.iStringSettings, "Settings", "Unknowns", Trim(Str(.sUnknowns)))
            NativeMethods.WriteINI(lINI.iStringSettings, "Settings", "Unsupported", Trim(Str(.sUnsupported)))
        End With
        With lIRC.iModes
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Invisible", Trim(.Invisible.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "LocalOperator", Trim(.LocalOperator.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Operator", Trim(.Operator.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Restricted", Trim(.Restricted.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "ServerNotices", Trim(.ServerNotices.ToString))
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Wallops", Trim(.Wallops.ToString))
        End With
        With lIRC
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "OperName", .iOperName)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "OperPass", .iOperPass)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "EMail", .iEMail)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "Password", .iPass)
            NativeMethods.WriteINI(lINI.iIRC, "Settings", "RealName", .iRealName)
        End With
        SaveCompatibility()
        SaveRecientServers()
        lSettings_Services.SaveServices()
        SaveIdentdSettings()
        SaveNickNames()
        SaveNetworks()
        SaveServers()
        SaveNotifyList()
        lSettings_DCC.SaveDCCSettings()
        SaveDownloadManagerSettings()
        SaveQuerySettings()
    End Sub

    Public Function AddServer(ByVal description As String, ByVal ip As String, ByVal networkIndex As Integer, ByVal port As Long) As Integer
        If (Not String.IsNullOrEmpty(description) And Not String.IsNullOrEmpty(ip) And networkIndex <> 0 And port <> 0) Then
            Dim server = New ServerModel
            server.Description = description
            server.Ip = ip
            server.NetworkIndex = networkIndex
            server.Port = port
            SaveServers()
        End If
        Return lServers.Servers.Count
    End Function

    Public Function AddNetwork(ByVal name As String) As Integer
        If (Not String.IsNullOrEmpty(name)) Then
            Dim n = New NetworkModel
            n.Name = name
            If (lWinVisible.wCustomize) Then
                frmCustomize.lCustomize.RefreshNetworks(frmCustomize.cboNetworks)
                frmCustomize.cboNetworks.Text = name
                lNetworks.Networks.Add(n)
                SaveNetworks()
            End If
        End If
        Return lNetworks.Networks.Count
        'If Len(lDescription) <> 0 Then
        'Dim c = lNetworks.Networks.Count + 1
        'With lNetworks.nNetwork(lNetworks.Networks.Count)
        '.Name = lDescription
        'End With
        'If lWinVisible.wCustomize = True Then
        'frmCustomize.lCustomize.RefreshNetworks(frmCustomize.cboNetworks)
        'frmCustomize.cboNetworks.Text = lDescription
        'End If
        'End If
        'SaveNetworks()
        'AddNetwork = lNetworks.nCount
    End Function

    Public Sub SaveServers()
        Dim i As Integer
        NativeMethods.WriteINI(lINI.iServers, "Settings", "Count", lServers.Servers.Count.ToString())
        NativeMethods.WriteINI(lINI.iServers, "Settings", "Index", lServers.Index.ToString())
        For i = 1 To lServers.Servers.Count
            With lServers.Servers(i)
                NativeMethods.WriteINI(lINI.iServers, i.ToString, "Ip", .Ip)
                NativeMethods.WriteINI(lINI.iServers, i.ToString, "Port", Trim(Convert.ToString(.Port)))
                NativeMethods.WriteINI(lINI.iServers, i.ToString, "Description", .Description)
                NativeMethods.WriteINI(lINI.iServers, i.ToString, "NetworkIndex", Trim(.NetworkIndex.ToString))
            End With
        Next i
    End Sub

    Private Sub SaveNetworks()
        Dim i As Integer
        If lNetworks.Networks.Count <> 0 Then
            NativeMethods.WriteINI(lINI.iNetworks, "Settings", "Count", Trim(lNetworks.Networks.Count.ToString))
            NativeMethods.WriteINI(lINI.iNetworks, "Settings", "Index", Trim(lNetworks.Index.ToString))
            For i = 0 To lNetworks.Networks.Count - 1
                With lNetworks.Networks(i)
                    NativeMethods.WriteINI(lINI.iNetworks, i.ToString, "Name", .Name)
                End With
            Next i
        End If
    End Sub

    Public Function FindServerIndexByIp(ByVal lIp As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(lIp)) Then
                For i = 1 To lServers.Servers.Count
                    With lServers.Servers(i)
                        If (.Ip.ToLower() = lIp.ToLower()) Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function FindServerIndex(ByVal lDescription As String) As Integer
        Dim i As Integer, result As Integer
        Try
            If (Not String.IsNullOrEmpty(lDescription)) Then
                For i = 1 To lServers.Servers.Count
                    With lServers.Servers(i)
                        If .Description.ToLower() = lDescription.ToLower() Then
                            result = i
                            Exit For
                        End If
                    End With
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function FindNetworkIndex(ByVal name As String) As Integer
        Dim n = 0
        For i = 0 To lNetworks.Networks.Count - 1
            If (lNetworks.Networks(i).Name = name) Then
                Return i + 1 ' THIS IS WEIRD!!!!
            End If
        Next i
        Return 0
    End Function

    Public Sub FillComboWithServers(ByVal lCombo As ComboBox, Optional ByVal lNetworkIndex As Integer = 0, Optional ByVal lClearCombo As Boolean = False)
        Try
            Dim i As Integer
            If lClearCombo = True Then lCombo.Items.Clear()
            For i = 1 To lServers.Servers.Count
                With lServers.Servers(i)
                    If (.Description IsNot Nothing) Then
                        If (.Description.Length <> 0) Then
                            If lNetworkIndex <> 0 Then
                                If lNetworkIndex = .NetworkIndex Then
                                    lCombo.Items.Add(.Description)
                                End If
                            Else
                                lCombo.Items.Add(.Description)
                            End If
                        End If
                    End If
                End With
            Next i
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Public Sub FillComboWithServers(Optional ByVal lServerIndex As Integer = 0)")
        End Try
    End Sub

    Public Sub FillRadComboWithNetworks(ByVal _RadDropDownList As RadDropDownList, Optional ByVal _Clear As Boolean = False)
        Dim i As Integer
        If _Clear = True Then _RadDropDownList.Items.Clear()
        For i = 0 To lNetworks.Networks.Count - 1
            If (lNetworks.Networks(i).Name IsNot Nothing) Then
                If (lNetworks.Networks(i).Name.Length <> 0) Then
                    Dim rldi = New RadListDataItem
                    rldi.Text = lNetworks.Networks(i).Name
                    rldi.Tag = lNetworks.Networks(i).ID
                    _RadDropDownList.Items.Add(rldi)
                End If
            End If
        Next i
        _RadDropDownList.Text = lSettings.lNetworks.Networks(lSettings.lNetworks.Index).Name
    End Sub

    Public Sub FillComboWithNetworks(ByVal lCombo As ComboBox, Optional ByVal lClearCombo As Boolean = False)
        Dim i As Integer
        If lClearCombo = True Then lCombo.Items.Clear()
        For i = 0 To lNetworks.Networks.Count - 1
            If (Not String.IsNullOrEmpty(lNetworks.Networks(i).Name)) Then
                lCombo.Items.Add(lNetworks.Networks(i).Name)
            End If
        Next i
    End Sub

    Public Function FindNickNameIndex(ByVal lNickName As String) As Integer
        Dim result As Integer
        Dim i As Integer
        If Len(lNickName) <> 0 Then
            For i = 1 To lIRC.iNicks.nCount
                With lIRC.iNicks.nNick(i)
                    If LCase(lNickName) = LCase(.nNick) Then
                        result = i
                        Exit For
                    End If
                End With
            Next i
        End If
        Return result
    End Function

    Public Function AddNickName(ByVal lNickName As String) As Integer
        Dim result As Integer
        If Len(lNickName) <> 0 Then
            If FindNickNameIndex(lNickName) <> 0 Then Return 0
            lIRC.iNicks.nCount = lIRC.iNicks.nCount + 1
            With lIRC.iNicks.nNick(lIRC.iNicks.nCount)
                .nNick = lNickName
                result = lIRC.iNicks.nCount
            End With
            SaveNickNames()
            If lWinVisible.wCustomize = True Then frmCustomize.cboMyNickNames.Items.Add(lNickName)
        End If
        Return result
    End Function

    Public Sub RemoveNetwork(ByVal lIndex As Integer)
        lNetworks.Networks(lIndex).Name = ""
        CleanUpNetworks()
    End Sub

    Public Sub CleanUpNetworks()
        Dim g = New List(Of NetworkModel), newIndex = 0, oldIndex As Integer
        For Each network As NetworkModel In lNetworks.Networks ' Loop through networks
            If (network IsNot Nothing) Then ' Check Network is not nothing
                If (Not String.IsNullOrEmpty(network.Name)) Then ' Check that Network name is not nothing
                    If (lNetworks.Index = oldIndex) Then ' Check the Active Index is the Original Index
                        lNetworks.Index = newIndex ' Set Active Index to newIndex, the new Index
                    End If
                    g.Add(network) ' Add Network to Good Collection
                    newIndex = newIndex + 1 ' Increment Index
                End If
            End If
            oldIndex = oldIndex + 1 ' Increment Old Index
        Next network
        lNetworks.Networks = g ' Set Networks List to g
    End Sub

    Public Function ShowPrompts() As Boolean
        With lIRC.iSettings
            Return .sPrompts
        End With
    End Function

    Public Sub LoadModes()
        lIRC.iModes = New ModeModel
        lIRC.iModes.Invisible = NativeMethods.ReadINIBool(lINI.iIRC, "Settings", "Invisible", True)
        lIRC.iModes.LocalOperator = NativeMethods.ReadINIBool(lINI.iIRC, "Settings", "LocalOperator", False)
        lIRC.iModes.Operator = NativeMethods.ReadINIBool(lINI.iIRC, "Settings", "Operator", False)
        lIRC.iModes.Restricted = NativeMethods.ReadINIBool(lINI.iIRC, "Settings", "Restricted", False)
        lIRC.iModes.ServerNotices = NativeMethods.ReadINIBool(lINI.iIRC, "Settings", "ServerNotices", True)
    End Sub

    Public Sub LoadChannelFolders()
        lChannelFolders = New List(Of ChannelFolderModel)
        Dim count = NativeMethods.ReadINIInt(lINI.iChannelFolders, "Settings", "Count", 0), n As Integer
        If (count <> 0) Then
            For i As Integer = 1 To count
                Dim c = New ChannelFolderModel
                c.Channel = NativeMethods.ReadINI(lINI.iChannelFolders, i.ToString, "Channel", "")
                c.Network = NativeMethods.ReadINI(lINI.iChannelFolders, i.ToString, "Network", "")
                If (Integer.TryParse(NativeMethods.ReadINI(lINI.iChannelFolders, i.ToString, "Order", "0"), n)) Then
                    c.Order = n
                End If
                If (Not String.IsNullOrEmpty(c.Channel)) Then
                    lChannelFolders.Add(c)
                End If
            Next i
        End If
    End Sub

    Public Sub SaveChannelFolders()
        NativeMethods.WriteINI(lINI.iChannelFolders, "Settings", "Count", lChannelFolders.Count.ToString())
        Dim i = 0
        For Each c In lChannelFolders
            i = i + 1
            NativeMethods.WriteINI(lINI.iChannelFolders, i.ToString, "Channel", c.Channel)
            NativeMethods.WriteINI(lINI.iChannelFolders, i.ToString, "Network", c.Network)
            NativeMethods.WriteINI(lINI.iChannelFolders, i.ToString, "Order", c.Order.ToString)
        Next c
    End Sub

    Public Sub AddToChannelFolders(ByVal channel As String, ByVal networkIndex As Integer)
        If (Not String.IsNullOrEmpty(channel)) Then
            Dim c = New ChannelFolderModel
            c.Channel = channel
            c.Network = lNetworks.Networks(networkIndex).Name
            SaveChannelFolders()
        End If
    End Sub

    Public Sub RemoveChannelFolder(ByVal lIndex As Integer)
        With lChannelFolders(lIndex)
            .Channel = ""
            .Order = 0
            .Network = ""
        End With
        SaveChannelFolders()
    End Sub

    Public Function FindChannelFolderIndexes(ByVal channel As String, network As String) As List(Of Integer)
        Dim result As List(Of Integer)
        result = New List(Of Integer)()
        For i As Integer = 1 To (lChannelFolders.Count - 1)
            If ((channel.ToLower().Trim() = lChannelFolders(i).Channel.ToLower().Trim()) And (network.ToLower().Trim() = lChannelFolders(i).Network.ToLower().Trim())) Then
                result.Add(i)
            End If
        Next i
        Return result
    End Function

    Public Sub RemoveServer(ByVal lIndex As Integer)
        If lIndex <> 0 Then
            With lServers.Servers(lIndex)
                .Description = ""
                .Ip = ""
                .NetworkIndex = 0
                .Port = 0
            End With
        End If
    End Sub
End Class