'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.Channels
Imports nexIRC.IRC.Status
Imports Telerik.WinControls.UI
Namespace Modules
    Public Module mdlObjects
        Public lIdent As New clsIdent
        Public lStatus As clsStatus
        Public lChannels As New clsChannel
        Public lChannelLists As New clsChannelList
        Public lChannelFolder As New clsChannelFolder
        Public lProcessNumeric As New clsProcessNumeric

        Public Function ReturnFirstSelectedListViewItem(ByVal lListView As ListView) As ListViewItem
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
        End Function

        Public Function DoesListViewItemExist(ByVal lListView As ListView, ByVal lData As String) As Boolean
            Dim i As Integer
            For i = 0 To lListView.Items.Count - 1
                With lListView.Items(i)
                    If LCase(Trim(.Text)) = LCase(Trim(lData)) Then
                        DoesListViewItemExist = True
                        Exit Function
                    End If
                End With
            Next i
        End Function

        Public Function ReturnRadListBoxIndex(ByVal lListBox As RadListControl, ByVal lData As String) As Integer
            Dim i As Integer
            For i = 0 To lListBox.Items.Count
                If LCase(Trim(lData)) = LCase(Trim(lListBox.Items(i).ToString)) Then
                    ReturnRadListBoxIndex = i
                    Exit For
                End If
            Next i
        End Function

        Public Function ReturnListBoxIndex(ByVal lListBox As ListBox, ByVal lData As String) As Integer
            Dim i As Integer
            For i = 0 To lListBox.Items.Count
                If LCase(Trim(lData)) = LCase(Trim(lListBox.Items(i).ToString)) Then
                    ReturnListBoxIndex = i
                    Exit For
                End If
            Next i
        End Function

        Public Function FindListViewIndex(ByVal lListView As ListView, ByVal lText As String) As Integer
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
        End Function

        Public Function FindRadListViewIndex(ByVal lListView As RadListView, ByVal lText As String) As Integer
            Dim i As Integer
            If Len(lText) <> 0 Then
                For i = 0 To lListView.Items.Count - 1
                    With lListView.Items(i)
                        If LCase(Trim(.Text)) = LCase(Trim(lText)) Then
                            FindRadListViewIndex = i
                            Exit For
                        End If
                    End With
                Next i
            End If
        End Function

        Public Function DoesItemExistInRadDropDown(_RadDropDownList As RadDropDownList, _Text As String) As Boolean
            'Try
            For Each _Item As RadListDataItem In _RadDropDownList.Items
                If (_Item.Text.Trim().ToLower() = _Text.Trim().ToLower()) Then
                    Return True
                End If
            Next _Item
            Return False
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Function DoesItemExistInRadDropDown(_RadDropDownList As RadDropDownList, _Text As String) As Boolean")
            'End Try
        End Function

        Public Function FindRadComboIndex(ByVal _RadDropDownList As RadDropDownList, ByVal _Text As String) As Integer
            'Try
            Dim i As Integer
            If Len(_Text) <> 0 Then
                If (DoesItemExistInRadDropDown(_RadDropDownList, _Text)) = True Then
                    FindRadComboIndex = 0
                    With _RadDropDownList
                        For i = 0 To _RadDropDownList.Items.Count
                            If Trim(LCase(.Items(i).ToString)) = Trim(LCase(_Text)) Then
                                FindRadComboIndex = i
                                Exit For
                            End If
                        Next i
                    End With
                End If
            End If
            'Catch ex As Exception
            'ProcessError(ex.Message, "Public Function FindRadComboIndex(ByVal _RadDropDownList As RadDropDownList, ByVal _Text As String) As Integer")
            'End Try
        End Function

        Public Function FindComboIndex(ByVal lComboBox As ComboBox, ByVal lText As String) As Integer
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
        End Function
    End Module
End Namespace