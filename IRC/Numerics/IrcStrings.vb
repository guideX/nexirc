'05-30-2016 - guideX
Option Explicit On
'Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules
Imports Telerik.WinControls.RichTextBox
Imports Telerik.WinControls.RichTextBox.Model
Imports Telerik.WinControls.RichTextBox.Layout
Imports nexIRC.Business.Helpers

Public Class IrcStrings
    Structure gCommandReturnData
        Public cSocketData As String
        Public cDoColorData As String
    End Structure

    Structure gCommand
        Public cData As String
        Public cCommandType As eCommandTypes
        Public cDisplay As String
        Public cParam1 As String
        Public cParam2 As String
        Public cParam3 As String
        Public cParam4 As String
    End Structure

    Structure gCommands
        Public cCount As Integer
        Public cCommad() As gCommand
    End Structure

    Structure gFixedString
        Public sData As String
        Public sType As eStringTypes
        Public sFind() As String
        Public sDescription As String
        Public sSupport As String
        Public sSyntax As String
    End Structure

    Structure gStrings
        Public sFixedStringCount As Integer
        Public sFixedString() As gFixedString
    End Structure

    Private lStrings As gStrings
    Private lCommands As gCommands
    Private Const lColorChar As String = ""
    Private lBackgroundColor As Integer

    Public Sub ProcessReplaceCommand(ByVal lStatusIndex As Integer, ByVal lType As eCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "")
        Try
            Dim commandData As gCommandReturnData
            commandData = ReturnReplacedCommand(lType, p1, p2, p3, p4)
            If commandData.cSocketData.Length <> 0 And commandData.cDoColorData.Length <> 0 Then
                lStatus.SendSocket(lStatusIndex, commandData.cSocketData)
                lStatus.AddText(commandData.cDoColorData, lStatusIndex)
            End If
        Catch ex As Exception
            '    Throw
        End Try
    End Sub

    Private Function FindCommandIndex(ByVal lType As eCommandTypes) As Integer
        Dim i As Integer, result As Integer
        Try
            For i = 1 To lCommands.cCount
                If lType = lCommands.cCommad(i).cCommandType Then
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

    Public Function ReturnReplacedCommand(ByVal lType As eCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "") As gCommandReturnData
        Try
            Dim msg As String, msg2 As String, i As Integer
            i = FindCommandIndex(lType)
            If i <> 0 Then
                msg = lCommands.cCommad(i).cData
                msg2 = lCommands.cCommad(i).cDisplay
                msg = msg.Replace("$crlf", "")
                msg = msg.Replace("$crlf", "")
                msg = msg.Replace("$space", " ")
                msg = msg.Replace("$4sp", "    ")
                msg2 = msg2.Replace("$crlf", "")
                msg2 = msg2.Replace("$space", " ")
                msg2 = msg2.Replace("$4sp", "    ")
                If (msg.Contains("$activeservername")) Then msg = msg.Replace("$activeservername", lStatus.Description(lStatus.ActiveIndex))
                If (msg2.Contains("$activeservername")) Then msg2 = msg2.Replace("$activeservername", lStatus.Description(lStatus.ActiveIndex))
                With lCommands.cCommad(i)
                    If Len(p1) <> 0 Then
                        msg = Replace(msg, .cParam1, p1, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .cParam1, p1, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p2)) Then
                        msg = Replace(msg, .cParam2, p2, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .cParam2, p2, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p3)) Then
                        msg = Replace(msg, .cParam3, p3, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .cParam3, p3, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p4)) Then
                        msg = Replace(msg, .cParam4, p4, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .cParam4, p4, 1, -1, vbTextCompare)
                    End If
                End With
                ReturnReplacedCommand.cSocketData = msg
                ReturnReplacedCommand.cDoColorData = msg2
            Else
                ReturnReplacedCommand.cSocketData = ""
                ReturnReplacedCommand.cDoColorData = ""
            End If
        Catch ex As Exception
            Return Nothing
            Throw
        End Try
    End Function

    Public Function DoesColorExist(ByVal lData As String) As Boolean
        Try
            If Len(lData) <> 0 And InStr(lData, lColorChar) <> 0 Then
                DoesColorExist = True
            Else
                DoesColorExist = False
            End If
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        Try
            Dim i As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Trim(LCase(NativeMethods.ReadINI(lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), ""))) = lStringParameterName Then
                        NativeMethods.WriteINI(lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")
                        Exit For
                    End If
                Next i
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub AddTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        Try
            Dim i As Integer, n As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Len(NativeMethods.ReadINI(lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")) = 0 Then
                        n = i
                        Exit For
                    End If
                Next i
                NativeMethods.WriteINI(lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(n.ToString), lStringParameterName)
                lStrings.sFixedString(lTextStringIndex).sFind(n) = lStringParameterName
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)
        Try
            lColorTextBox.ScrollToCaret()
            lColorTextBox.SelectionStart = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ConvertIntToSystemColor(ByVal lColor As Integer, Optional lBlackSetting As Boolean = False) As System.Drawing.Color
        Try
            Select Case lColor
                Case 0
                    If lBlackSetting = True Then
                        ConvertIntToSystemColor = Color.White
                    Else
                        ConvertIntToSystemColor = Color.Black
                    End If
                Case 1
                    If lBlackSetting = True Then
                        ConvertIntToSystemColor = Color.White
                    Else
                        ConvertIntToSystemColor = Color.Black
                    End If
                Case 2
                    ConvertIntToSystemColor = Color.DarkBlue
                Case 3
                    ConvertIntToSystemColor = Color.Coral
                Case 4
                    ConvertIntToSystemColor = Color.Red
                Case 5
                    ConvertIntToSystemColor = Color.DarkRed
                Case 6
                    ConvertIntToSystemColor = Color.Purple
                Case 7
                    ConvertIntToSystemColor = Color.Orange
                Case 8
                    ConvertIntToSystemColor = Color.Yellow
                Case 9
                    ConvertIntToSystemColor = Color.LightGreen
                Case 10
                    ConvertIntToSystemColor = Color.Turquoise
                Case 11
                    ConvertIntToSystemColor = Color.Aquamarine
                Case 12
                    ConvertIntToSystemColor = Color.Blue
                Case 13
                    ConvertIntToSystemColor = Color.Pink
                Case 14
                    ConvertIntToSystemColor = Color.Cyan
                Case 15
                    ConvertIntToSystemColor = Color.Gray
                Case 16
                    If lBlackSetting = True Then
                        ConvertIntToSystemColor = Color.Black
                    Else
                        ConvertIntToSystemColor = Color.White
                    End If
            End Select
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ReturnRightColorNumeric(ByVal lData As String) As Integer
        Dim result As Integer, msg As String, msg2 As String
        Try
            If Len(lData) <> 0 Then
                If IsNumeric(Left(lData, 1)) = True Then
                    If IsNumeric(Left(lData, 2)) = True Then
                        msg = Left(lData, 2)
                    Else
                        msg = Left(lData, 1)
                    End If
                    lData = Right(lData, Len(lData) - Len(msg))
                    If Left(lData, 1) = "," Then
                        lData = Right(lData, Len(lData) - 1)
                        If IsNumeric(Left(lData, 1)) = True Then
                            If IsNumeric(Left(lData, 2)) = True Then
                                msg2 = Left(lData, 2)
                            Else
                                msg2 = Left(lData, 1)
                            End If
                        Else
                            msg2 = "16"
                        End If
                    Else
                        msg2 = "16"
                    End If
                    If Len(msg) <> 0 Then
                        result = Convert.ToInt32(Trim(msg))
                        lBackgroundColor = Convert.ToInt32(msg2)
                    Else
                        result = 0
                        lBackgroundColor = 16
                    End If
                End If
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)
        Try
            If Len(lData) <> 0 And lIndex <> 0 Then
                lStrings.sFixedString(lIndex).sData = lData
                NativeMethods.WriteINI(lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Data", lData)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lData As String)
        Try
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sDescription = lData
                NativeMethods.WriteINI(lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Description", lData)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)
        Try
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sSyntax = lData
                NativeMethods.WriteINI(lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Syntax", lData)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)
        Try
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sSupport = lData
                NativeMethods.WriteINI(lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Support", lData)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ResetStrings()
        Try
            lProcessNumeric.lIrcNumericHelper.ResetMessages()
            ClearStrings()
            LoadStrings()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function FindStringIndexByDescription(ByVal lDescription As String) As Integer
        Dim result As Integer
        Try
            Dim i As Integer
            If (Not String.IsNullOrEmpty(lDescription)) Then
                For i = 1 To lStrings.sFixedStringCount
                    If (lDescription.ToLower() = lStrings.sFixedString(i).sDescription.ToLower()) Then
                        result = i
                        Exit For
                    End If
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function ReturnStringTypeByDescription(ByVal lDescription As String) As eStringTypes
        Dim result As eStringTypes
        Try
            Dim i As Integer
            If (Not String.IsNullOrEmpty(lDescription)) Then
                For i = 1 To 200 'LEON! FIX THAT
                    If (lDescription.ToLower() = lStrings.sFixedString(i).sDescription.ToLower()) Then
                        result = lStrings.sFixedString(i).sType
                        Exit For
                    End If
                Next i
            End If
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer
        Dim i As Integer, result As Integer
        Try
            For i = 1 To lStrings.sFixedStringCount
                If lType = lStrings.sFixedString(i).sType Then
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

    Public Sub ProcessReplaceString(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "")
        Try
            Dim msg As String
            If lSettings.lIRC.iSettings.sNoIRCMessages = True Then Exit Sub
            msg = ReturnReplacedString(lType, r1, r2, r3, r4, r5, r6, r7, r8)
            If ReturnStringCompatibile(lType) = True Then
                If Len(msg) <> 0 Then lStatus.AddText(msg, lStatusIndex)
            Else
                lStatus.AddToUnsupported(lStatusIndex, msg)
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean
        Dim result As Boolean, c As Integer = FindStringIndex(lType), i As Integer
        Try
            With lStrings.sFixedString(c)
                For i = 1 To lSettings.lCompatibility.Count
                    If InStr(LCase(Trim(lSettings.lCompatibility(i).Description)), LCase(Trim(.sSupport))) <> 0 And lSettings.lCompatibility(i).Enabled = True Then
                        result = True
                        Exit For
                    End If
                Next i
            End With
            Return result
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function ReturnReplacedString(ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "") As String
        Try
            Dim msg As String, i As Integer
            i = FindStringIndex(lType)
            msg = lStrings.sFixedString(i).sData
            msg = msg.Replace("$crlf", Chr(10))
            msg = Replace(msg, "$space", " ")
            msg = Replace(msg, "$4sp", "    ")
            msg = Replace(msg, "$activeservername", lStatus.Description(lStatus.ActiveIndex))
            With lStrings.sFixedString(i)
                If Len(r1) <> 0 Then msg = Replace(msg, .sFind(1), r1, 1, -1, vbTextCompare)
                If Len(r2) <> 0 Then msg = Replace(msg, .sFind(2), r2, 1, -1, vbTextCompare)
                If Len(r3) <> 0 Then msg = Replace(msg, .sFind(3), r3, 1, -1, vbTextCompare)
                If Len(r4) <> 0 Then msg = Replace(msg, .sFind(4), r4, 1, -1, vbTextCompare)
                If Len(r5) <> 0 Then msg = Replace(msg, .sFind(5), r5, 1, -1, vbTextCompare)
                If Len(r6) <> 0 Then msg = Replace(msg, .sFind(6), r6, 1, -1, vbTextCompare)
                If Len(r7) <> 0 Then msg = Replace(msg, .sFind(7), r7, 1, -1, vbTextCompare)
                If Len(r8) <> 0 Then msg = Replace(msg, .sFind(8), r8, 1, -1, vbTextCompare)
            End With
            ReturnReplacedString = msg
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub SaveTextStrings()
        Try
            Dim i As Integer
            For i = 1 To 200
                If Len(lStrings.sFixedString(i).sData) <> 0 Then
                    NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Type", Trim(Str(lStrings.sFixedString(i).sType)))
                    NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Data", Trim(lStrings.sFixedString(i).sData))
                    If Len(lStrings.sFixedString(i).sFind(1)) <> 0 Then NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Find1", lStrings.sFixedString(i).sFind(1))
                    If Len(lStrings.sFixedString(i).sFind(2)) <> 0 Then NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Find2", lStrings.sFixedString(i).sFind(2))
                    If Len(lStrings.sFixedString(i).sFind(3)) <> 0 Then NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Find3", lStrings.sFixedString(i).sFind(3))
                    If Len(lStrings.sFixedString(i).sFind(4)) <> 0 Then NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Find4", lStrings.sFixedString(i).sFind(4))
                    If Len(lStrings.sFixedString(i).sFind(5)) <> 0 Then NativeMethods.WriteINI(lSettings.ReturnTextINI, Trim(Str(i)), "Find5", lStrings.sFixedString(i).sFind(5))
                End If
            Next i
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function ReturnStringDataByType(ByVal lType As eStringTypes) As String
        Try
            Dim i As Integer
            For i = 1 To 200
                If lStrings.sFixedString(i).sType = lType Then
                    ReturnStringDataByType = lStrings.sFixedString(i).sData
                    Exit Function
                End If
            Next i
            ReturnStringDataByType = ""
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Sub SetStringData(ByVal lType As eStringTypes, ByVal lData As String)
        Try
            Dim i As Integer
            i = FindStringIndex(lType)
            If i <> 0 Then
                lStrings.sFixedString(i).sData = lData
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ClearStrings()
        Try
            Dim i As Integer, n As Integer
            ReDim lStrings.sFixedString(200)
            lStrings.sFixedStringCount = 0
            For i = 0 To 200
                With lStrings.sFixedString(i)
                    .sData = ""
                    .sDescription = ""
                    ReDim .sFind(8)
                    For n = 0 To 8
                        .sFind(n) = ""
                    Next n
                    .sType = 0
                End With
            Next i
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadCommands()
        Try
            Dim i As Integer
            ReDim lCommands.cCommad(100)
            lCommands.cCount = Convert.ToInt32(NativeMethods.ReadINI(lSettings.ReturnCommandsINI, "Settings", "Count", "0"))
            For i = 1 To lCommands.cCount
                With lCommands.cCommad(i)
                    .cData = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Command", "")
                    If Len(.cData) <> 0 Then
                        .cCommandType = CType(NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Type", ""), eCommandTypes)
                        .cDisplay = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Display", "")
                        .cParam1 = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Param1", "")
                        If Len(.cParam1) <> 0 Then .cParam2 = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Param2", "")
                        If Len(.cParam2) <> 0 Then .cParam3 = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Param3", "")
                        If Len(.cParam3) <> 0 Then .cParam4 = NativeMethods.ReadINI(lSettings.ReturnCommandsINI, Trim(Str(i)), "Param4", "")
                    End If
                End With
            Next i
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub LoadStrings()
        Try
            Dim msg As String, msg2 As String, splt() As String, splt2() As String
            Dim lIndex As Integer
            ReDim lStrings.sFixedString(lSettings.lArraySizes.aStrings)
            msg2 = My.Computer.FileSystem.ReadAllText(lSettings.lINI.iText, System.Text.Encoding.UTF8)
            msg2 = Replace(msg2, "$syschar", "•")
            msg2 = Replace(msg2, "$arrowchar", "»")
            splt = Split(msg2, Environment.NewLine)
            For Each msg In splt
                If LCase(msg) = "[settings]" Then
                Else
                    If Left(msg, 1) = "[" And Right(msg, 1) = "]" Then
                        lIndex = Convert.ToInt32(Trim(ParseData(msg, "[", "]")))
                        ReDim lStrings.sFixedString(lIndex).sFind(8)
                    Else
                        splt2 = Split(msg, "=")
                        Select Case LCase(splt2(0))
                            Case "count"
                                lStrings.sFixedStringCount = Convert.ToInt32(Trim(splt2(1)))
                            Case "description"
                                lStrings.sFixedString(lIndex).sDescription = splt2(1).ToString
                            Case "data"
                                lStrings.sFixedString(lIndex).sData = splt2(1).ToString
                            Case "find1"
                                lStrings.sFixedString(lIndex).sFind(1) = splt2(1).ToString
                            Case "find2"
                                lStrings.sFixedString(lIndex).sFind(2) = splt2(1).ToString
                            Case "find3"
                                lStrings.sFixedString(lIndex).sFind(3) = splt2(1).ToString
                            Case "find4"
                                lStrings.sFixedString(lIndex).sFind(4) = splt2(1).ToString
                            Case "find5"
                                lStrings.sFixedString(lIndex).sFind(5) = splt2(1).ToString
                            Case "find6"
                                lStrings.sFixedString(lIndex).sFind(6) = splt2(1).ToString
                            Case "find7"
                                lStrings.sFixedString(lIndex).sFind(7) = splt2(1).ToString
                            Case "find8"
                                lStrings.sFixedString(lIndex).sFind(8) = splt2(1).ToString
                            Case "type"
                                lStrings.sFixedString(lIndex).sType = CType(splt2(1).ToString, eStringTypes)
                            Case "support"
                                lStrings.sFixedString(lIndex).sSupport = splt2(1).ToString
                            Case "syntax"
                                lStrings.sFixedString(lIndex).sSyntax = splt2(1).ToString
                        End Select
                    End If
                End If
            Next msg
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub PopulateListViewWithStrings(ByVal lListView As RadListView)
        Try
            Dim i As Integer, lItem As Telerik.WinControls.UI.ListViewDataItem, msg As String
            lListView.Items.Clear()
            For i = 0 To lStrings.sFixedStringCount
                With lStrings.sFixedString(i)
                    msg = .sDescription
                    If Len(msg) <> 0 Then
                        lItem = New Telerik.WinControls.UI.ListViewDataItem
                        lItem.Text = msg
                        lItem.SubItems.Add(msg)
                        lItem.SubItems.Add(.sSupport)
                        lItem.SubItems.Add(.sSyntax)
                        lItem.SubItems.Add(Trim(Convert.ToString(.sType)))
                        lItem.SubItems.Add(.sData)
                        lListView.Items.Add(lItem)
                        'lListView.Show()
                    End If
                End With
            Next i
            lListView.SelectedIndex = 0
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)
        Try
            lTextBox.Text = lData & Environment.NewLine & lTextBox.Text
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetFileTitle(ByVal lFileName As String) As String
        Try
            Dim msg() As String
            msg = Split(lFileName, "\")
            GetFileTitle = msg(UBound(msg))
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function StripColorCodes(ByVal lData As String) As String
        Try
            Dim i As Integer, n As Integer, msg As String, msg2 As String
            For i = 0 To 15
                For n = 0 To 15
                    msg2 = "" & Trim(i.ToString) & "," & Trim(n.ToString)
                    If InStr(msg2, lData) <> 0 Then lData = Replace(lData, msg2, "")
                Next n
                msg = "" & Trim(i.ToString)
                If InStr(msg, lData) <> 0 Then lData = Replace(lData, msg, "")
            Next i
            Return lData
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Enum ColorCode
        White = 0
        Black = 1
        DarkBlue = 2
        DarkGreen = 3
        Red = 4
        DarkRed = 5
        DarkViolet = 6
        Orange = 7
        Yellow = 8
        LightGreen = 9
        Cyan = 10
        LightCyan = 11
        Blue = 12
        Violet = 13
        DarkGray = 14
        LightGray = 15
    End Enum

    Public Sub Print(data As String, richTextBox As RadRichTextBox)
        Dim ircChar As String = "", s As Span, mint As Integer, i As Integer, msg As String, currentText As String = "", subText1 As String = "", subText2 As String = "", isForeColorSet As Boolean = False, isBackColorSet As Boolean = False
        richTextBox.Document.CaretPosition.MoveToLastPositionInDocument()
        If (Not String.IsNullOrEmpty(data)) Then
            If (richTextBox.RichTextBoxElement.Tag = "1") Then
                richTextBox.InsertLineBreak()
            Else
                richTextBox.RichTextBoxElement.Tag = "1"
            End If
            If (Not data.Contains(ircChar)) Then
                s = New Span(data)
                s.ForeColor = Color.White
                richTextBox.InsertInline(s)
            Else
                s = New Span(data)
                s.ForeColor = Color.White
                For i = 0 To data.Length
                    If (Not String.IsNullOrEmpty(data)) Then
                        msg = data.Substring(0, 1)
                        If (msg = ircChar) Then
                            If (Not isForeColorSet) Then
                                If (Not String.IsNullOrEmpty(currentText)) Then
                                    s.ForeColor = Color.White
                                    s.Text = currentText
                                    richTextBox.InsertInline(s)
                                    currentText = ""
                                    isForeColorSet = False
                                    'isBackColorSet = False
                                    s = New Span()
                                End If
                                data = data.Remove(0, 1)
                                If (Not String.IsNullOrEmpty(data)) Then
                                    If (data.Length > 1) Then
                                        subText2 = data.Substring(0, 2)
                                    Else
                                        subText2 = "<>"
                                    End If
                                    subText1 = data.Substring(0, 1)
                                    If (Integer.TryParse(subText2, mint)) Then
                                        isForeColorSet = True
                                        data = data.Remove(0, 2)
                                        s.ForeColor = ConvertIntToSystemColor(mint, True)
                                    ElseIf (Integer.TryParse(subText1, mint)) Then
                                        isForeColorSet = True
                                        data = data.Remove(0, 1)
                                        s.ForeColor = ConvertIntToSystemColor(mint, True)
                                    End If
                                    If (data.Substring(0, 1) = ",") Then
                                        subText2 = data.Substring(0, 2)
                                        subText1 = data.Substring(0, 1)
                                        If (Integer.TryParse(subText2, mint)) Then
                                            data = data.Remove(0, 2)
                                            'isBackColorSet = True
                                            's.BackColor = ConvertIntToSystemColor(mint, True)
                                        ElseIf (Integer.TryParse(subText1, mint)) Then
                                            data = data.Remove(0, 1)
                                            'isBackColorSet = True
                                            's.BackColor = ConvertIntToSystemColor(mint, True)
                                        End If
                                    End If
                                End If
                            Else
                                If (Not String.IsNullOrEmpty(currentText)) Then
                                    s.Text = currentText
                                    richTextBox.InsertInline(s)
                                    currentText = ""
                                    isForeColorSet = False
                                    'isBackColorSet = False
                                    s = New Span()
                                    s.ForeColor = Color.White
                                End If
                            End If
                        Else
                            data = data.Remove(0, 1)
                            currentText = currentText & msg
                        End If
                    End If
                Next i
                If (Not String.IsNullOrEmpty(currentText)) Then
                    If (Not String.IsNullOrEmpty(currentText.Length)) Then
                        s.Text = currentText
                        richTextBox.InsertInline(s)
                        currentText = ""
                        Dim documentElements As New List(Of Telerik.WinControls.RichTextBox.Model.DocumentElement)()
                        For Each documentElement In richTextBox.Document.Sections().FirstOrDefault().Children().FirstOrDefault().Children()
                            documentElements.Add(documentElement)
                        Next documentElement
                        documentElements.Reverse()
                        i = 0
                        For Each documentElement As Telerik.WinControls.RichTextBox.Model.DocumentElement In documentElements
                            i = i + 1
                            If (i > lSettings.lIRC.iSettings.sTextBufferSize) Then
                                richTextBox.Document.Sections().FirstOrDefault().Children().FirstOrDefault().Children().Remove(documentElement)
                            End If
                        Next documentElement
                    End If
                End If
            End If
        End If
        richTextBox.Document.CaretPosition.MoveToLastPositionInDocument()
    End Sub

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function DecodeLongIPAddr(ByVal LongIPAddr As String) As String
        Try
            Dim msg!, msg2!
            Dim msg3, msg4, msg5, i As Integer, msg6 As String
            msg! = Int(LongIPAddr / 65536)
            msg2! = LongIPAddr - msg! * 65536
            msg3 = Int(msg! / 256)
            msg4 = msg! - msg3 * 256
            msg5 = Int(msg2! / 256)
            i = msg2! - msg5 * 256
            msg6 = Trim(Str(msg3)) & "."
            msg6 = msg6 & Trim(Str(msg4)) & "."
            msg6 = msg6 & Trim(Str(msg5)) & "."
            msg6 = msg6 & Trim(Str(i))
            DecodeLongIPAddr = msg6
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function EncodeIPAddr(ByVal lData As String) As String
        Try
            Dim msg, msg2, msg3 As String, msg4, msg5, i As Integer, msg6 As String
            msg4 = 1
            msg = ""
            Do
                msg2 = InStr(msg4, lData & ".", ".")
                msg3 = Hex(Val(Mid$(lData & ".", msg4, msg2 - msg4)))
                msg = msg & IIf(Len(msg3) = 1, "0" & msg3, msg3)
                msg4 = msg2 + 1
            Loop Until msg4 >= Len(lData & ".")
            msg5 = Val("&H" & Mid(msg, 1, 2)) * 256.0! + Val("&H" & Mid(msg, 3, 2))
            i = Val("&H" & Mid(msg, 5, 2)) * 256.0! + Val("&H" & Mid(msg, 7, 2))
            msg6 = Str(msg5 * 65536 + i)
            EncodeIPAddr = Trim$(msg6)
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function GetRnd(ByVal _start As Integer, ByVal _end As Integer) As Long
        Try
            Dim i As Long
            Randomize()
            i = _start + Convert.ToInt32(Rnd() * (_end - _start))
            Return i
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function DoRight(ByVal lData As String, ByVal lLength As Integer) As String
        Try
            DoRight = Right(lData, lLength).ToString
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer) As String
        Try
            DoLeft = Left(lData, lLength).ToString
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String
        Try
            If Len(lString) <> 0 Then
                LeftRight = lString.Substring(lLeft, lDistance)
            Else
                LeftRight = ""
            End If
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function

    Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String) As String
        Try
            Dim i As Integer, n As Integer, msg As String, msg2 As String
            If Len(lWhole) <> 0 Then
                i = InStr(lWhole, lStart)
                n = InStr(lWhole, lEnd)
                msg = Right(lWhole, Len(lWhole) - i)
                msg2 = Right(lWhole, Len(lWhole) - n)
                If Len(msg2) < Len(msg) Then
                    ParseData = Left(msg, Len(msg) - Len(msg2) - 1)
                Else
                    ParseData = ""
                End If
            Else
                ParseData = ""
            End If
        Catch ex As Exception
            Throw
            Return Nothing
        End Try
    End Function
End Class