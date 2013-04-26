'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.Channels
Imports nexIRC.IRC.Status

Module mdlObjects
    Public lIdent As New clsIdent
    Public lStatus As clsStatus
    Public lChannels As New clsChannel
    Public lChannelLists As New clsChannelList

    Public Function ReturnFirstSelectedListViewItem(ByVal lListView As ListView) As ListViewItem
        On Error Resume Next
        Dim i As Integer
        ReturnFirstSelectedListViewItem = Nothing
        For i = 1 To lListView.Items.Count - 1
            With lListView.Items(i)
                If .Selected = True Then
                    ReturnFirstSelectedListViewItem = lListView.Items(i)
                    Exit For
                End If
            End With
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnSelectedListViewIndex(ByVal lListView As ListView) As Integer")
    End Function

    Public Function DoesListViewItemExist(ByVal lListView As ListView, ByVal lData As String) As Boolean
        On Error Resume Next
        Dim i As Integer
        For i = 0 To lListView.Items.Count - 1
            With lListView.Items(i)
                If LCase(Trim(.Text)) = LCase(Trim(lData)) Then
                    DoesListViewItemExist = True
                    Exit Function
                End If
            End With
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function DoesListViewItemExist(ByVal lListView As ListView, ByVal lData As String) As Boolean")
    End Function

    Public Function ReturnListBoxIndex(ByVal lListBox As ListBox, ByVal lData As String) As Integer
        On Error Resume Next
        Dim i As Integer
        For i = 0 To lListBox.Items.Count
            If LCase(Trim(lData)) = LCase(Trim(lListBox.Items(i).ToString)) Then
                ReturnListBoxIndex = i
                Exit For
            End If
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnListBoxIndex(ByVal lListBox As ListBox, ByVal lData As String) As Integer")
    End Function

    Public Function FindListViewIndex(ByVal lListView As ListView, ByVal lText As String) As Integer
        On Error Resume Next
        Dim i As Integer
        If Len(lText) <> 0 Then
            For i = 0 To lListView.Items.Count - 1
                With lListView.Items(i)
                    If LCase(Trim(.Text)) = LCase(Trim(lText)) Then
                        FindListViewIndex = i
                        Exit For
                    End If
                End With
            Next i
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function FindListViewIndex(ByVal lListView As ListView, ByVal lText As String) As Integer")
    End Function

    Public Function FindComboIndex(ByVal lComboBox As ComboBox, ByVal lText As String) As Integer
        On Error Resume Next
        Dim i As Integer
        If Len(lText) <> 0 Then
            FindComboIndex = 0
            With lComboBox
                For i = 0 To lComboBox.Items.Count
                    If Trim(LCase(.Items(i).ToString)) = Trim(LCase(lText)) Then
                        FindComboIndex = i
                        Exit For
                    End If
                Next i
            End With
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function FindComboIndex(ByVal lText As String) As Integer")
    End Function
End Module
