'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmChooseNetwork
    Private lServerToChange As Integer
    Private lNetworkIndex As Integer

    Enum eNetworkOpType
        nMoveNetwork = 1
    End Enum

    Private lNetworkOpType As eNetworkOpType

    Public Sub SetNetworkOpType(ByVal lType As eNetworkOpType)
        On Error Resume Next
        lNetworkOpType = lType
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetNetworkOpType(ByVal lType As eNetworkOpType)")
    End Sub

    Public Sub SetNetworkIndex(ByVal lIndex As Integer)
        On Error Resume Next
        If lIndex <> 0 Then lNetworkIndex = lIndex
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetNetworkIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub SetServerToChange(ByVal lIndex As Integer)
        On Error Resume Next
        If lIndex <> 0 Then lServerToChange = lIndex
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetServerToChange(ByVal lIndex As Integer)")
    End Sub

    Private Sub frmChooseNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Dim i As Integer
        For i = 0 To lNetworks.nCount
            With lNetworks.nNetwork(i)
                If Len(.nDescription) <> 0 Then cboNetwork.Items.Add(.nDescription)
            End With
        Next i
        cboNetwork.Text = lNetworks.nNetwork(lNetworkIndex).nDescription
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub frmChooseNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim i As Integer, msg As String
        If lNetworkOpType = eNetworkOpType.nMoveNetwork Then
            If lServerToChange <> 0 Then
                msg = cboNetwork.Text
                i = FindNetworkIndex(msg)
                lServers.sServer(lServerToChange).sNetworkIndex = i
                clsFiles.WriteINI(lINI.iServers, Trim(Str(lServerToChange)), "NetworkIndex", Trim(Str(i)))
                If lWinVisible.wCustomize = True Then
                    frmCustomize.cboNetworks.Text = lNetworks.nNetwork(i).nDescription
                End If
            End If
        End If
        Me.Close()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub
End Class