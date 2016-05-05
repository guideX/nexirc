'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.Channels
Imports nexIRC.IRC.Status
Imports Telerik.WinControls.UI
Imports nexIRC.nexIRC.IRC.Settings

Namespace Modules
    Public Module mdlObjects
        Public lSettings As New Settings
        Public lStrings As New IrcStrings
        Public lStatus As Status
        Public lChannels As New clsChannel
        Public lChannelLists As New clsChannelList
        Public lChannelFolder As New clsChannelFolder
        Public lProcessNumeric As New clsProcessNumeric
        Public lSettings_DCC As New clsDCC
        Public lSettings_Services As New clsServices
        Public lIdent As New Ident

        Public Sub SetSelectedRadComboBoxItem(_RadComboBox As RadDropDownList, _Text As String)
            Dim i As Integer
            If (Not String.IsNullOrEmpty(_Text)) Then
                For i = 1 To _RadComboBox.Items.Count - 1
                    If (_Text.ToLower().Trim() = _RadComboBox.Items(i).ToString().ToLower().Trim()) Then
                        _RadComboBox.SelectedIndex = i
                        Exit For
                    End If
                Next i
            End If
        End Sub

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
            Dim i As Integer, result As Boolean
            Try
                For i = 0 To lListView.Items.Count - 1
                    With lListView.Items(i)
                        If .Text.ToLower().Trim() = lData.ToLower().Trim() Then
                            result = True
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
        Public Function ReturnRadListBoxIndex(ByVal lListBox As RadListControl, ByVal lData As String) As Integer
            Dim i As Integer, result As Integer
            Try
                For i = 0 To lListBox.Items.Count
                    If lData.ToLower().Trim() = lListBox.Items(i).ToString.ToLower().Trim() Then
                        result = i
                        Exit For
                    End If
                Next i
                Return result
            Catch ex As Exception
                Throw
                Return Nothing
            End Try
        End Function
        Public Function ReturnListBoxIndex(ByVal lListBox As ListBox, ByVal lData As String) As Integer
            Dim i As Integer, result As Integer
            Try
                For i = 0 To lListBox.Items.Count
                    If LCase(Trim(lData)) = LCase(Trim(lListBox.Items(i).ToString)) Then
                        result = i
                        Exit For
                    End If
                Next i
                Return result
            Catch ex As Exception
                Throw
                Return Nothing
            End Try
        End Function

        Public Function FindListViewIndex(ByVal lListView As ListView, ByVal lText As String) As Integer
            Dim result As Integer, i As Integer
            Try
                If Len(lText) <> 0 Then
                    For i = 0 To lListView.Items.Count - 1
                        With lListView.Items(i)
                            If LCase(Trim(.Text)) = LCase(Trim(lText)) Then
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

        Public Function FindRadListViewIndex(ByVal lListView As RadListView, ByVal lText As String) As Integer
            Try
                Dim result As Integer, i As Integer
                If Len(lText) <> 0 Then
                    For i = 0 To lListView.Items.Count - 1
                        With lListView.Items(i)
                            If LCase(Trim(.Text)) = LCase(Trim(lText)) Then
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

        Public Function DoesItemExistInRadDropDown(_RadDropDownList As RadDropDownList, _Text As String) As Boolean
            Try
                For Each _Item As RadListDataItem In _RadDropDownList.Items
                    If (_Item.Text.Trim().ToLower() = _Text.Trim().ToLower()) Then
                        Return True
                    End If
                Next _Item
                Return False
            Catch ex As Exception
                Throw
                Return Nothing
            End Try
        End Function

        Public Function FindRadComboIndex(ByVal _RadDropDownList As RadDropDownList, ByVal text As String) As Integer
            Dim i As Integer, result As Integer
            Try
                If (Not String.IsNullOrEmpty(text)) Then
                    If (DoesItemExistInRadDropDown(_RadDropDownList, text)) = True Then
                        With _RadDropDownList
                            For i = 0 To _RadDropDownList.Items.Count
                                If (.Items(i).ToString().Trim().ToLower() = text.Trim().ToLower()) Then
                                    result = i
                                    Exit For
                                End If
                            Next i
                        End With
                    End If
                End If
                Return result
            Catch ex As Exception
                Throw
                Return Nothing
            End Try
        End Function

        Public Function FindComboIndex(ByVal comboBox As ComboBox, ByVal text As String) As Integer
            Dim i As Integer, result As Integer
            Try
                If (Not String.IsNullOrEmpty(text)) Then
                    With comboBox
                        For i = 0 To comboBox.Items.Count
                            If (.Items(i).ToString().Trim().ToLower() = text.Trim().ToLower()) Then
                                result = i
                                Exit For
                            End If
                        Next i
                    End With
                End If
                Return result
            Catch ex As Exception
                Throw
                Return Nothing
            End Try
        End Function
    End Module
End Namespace