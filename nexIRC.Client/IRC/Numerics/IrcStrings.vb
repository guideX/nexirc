﻿Option Explicit On
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.RichTextBox
Imports Telerik.WinControls.RichTextBox.Model
Imports Telerik.WinControls.RichTextBox.Layout
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Enums
Imports nexIRC.Client.nexIRC.Client.IRC.Numerics.clsIrcNumerics
Imports nexIRC.Business.Models
Imports nexIRC.Business.Models.Command

Namespace nexIRC.Client.IRC.Numerics
    Public Class IrcStrings
        Structure gCommandReturnData
            Public cSocketData As String
            Public cDoColorData As String
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
        Private lCommands As List(Of Command)
        Private Const lColorChar As String = ""
        Private lBackgroundColor As Integer

        Public Sub ProcessReplaceCommand(ByVal lStatusIndex As Integer, ByVal lType As IrcCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "")
            Dim commandData As gCommandReturnData
            commandData = ReturnReplacedCommand(lType, p1, p2, p3, p4)
            If commandData.cSocketData.Length <> 0 And commandData.cDoColorData.Length <> 0 Then
                Modules.lStatus.SendSocket(lStatusIndex, commandData.cSocketData)
                Modules.lStatus.AddText(commandData.cDoColorData, lStatusIndex)
            End If
        End Sub

        Private Function FindCommandIndex(ByVal lType As IrcCommandTypes) As Integer
            Dim i As Integer, result As Integer
            For i = 1 To lCommands.Count
                If lType = lCommands(i).CommandType Then
                    Return i
                End If
            Next i
            Return 0
        End Function

        Public Function ReturnReplacedCommand(ByVal lType As IrcCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "") As gCommandReturnData
            Dim msg As String, msg2 As String, i As Integer
            i = FindCommandIndex(lType)
            If i <> 0 Then
                msg = lCommands(i).Data
                msg2 = lCommands(i).Display
                msg = msg.Replace("$crlf", "")
                msg = msg.Replace("$crlf", "")
                msg = msg.Replace("$space", " ")
                msg = msg.Replace("$4sp", "    ")
                msg2 = msg2.Replace("$crlf", "")
                msg2 = msg2.Replace("$space", " ")
                msg2 = msg2.Replace("$4sp", "    ")
                If (msg.Contains("$activeservername")) Then msg = msg.Replace("$activeservername", Modules.lStatus.Description(Modules.lStatus.ActiveIndex))
                If (msg2.Contains("$activeservername")) Then msg2 = msg2.Replace("$activeservername", Modules.lStatus.Description(Modules.lStatus.ActiveIndex))
                With lCommands(i)
                    If Len(p1) <> 0 Then
                        msg = Replace(msg, .Param1, p1, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .Param1, p1, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p2)) Then
                        msg = Replace(msg, .Param2, p2, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .Param2, p2, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p3)) Then
                        msg = Replace(msg, .Param3, p3, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .Param3, p3, 1, -1, vbTextCompare)
                    End If
                    If (Not String.IsNullOrEmpty(p4)) Then
                        msg = Replace(msg, .Param4, p4, 1, -1, vbTextCompare)
                        msg2 = Replace(msg2, .Param4, p4, 1, -1, vbTextCompare)
                    End If
                End With
                ReturnReplacedCommand.cSocketData = msg
                ReturnReplacedCommand.cDoColorData = msg2
            Else
                ReturnReplacedCommand.cSocketData = ""
                ReturnReplacedCommand.cDoColorData = ""
            End If
        End Function

        Public Function DoesColorExist(ByVal lData As String) As Boolean
            If Len(lData) <> 0 And InStr(lData, lColorChar) <> 0 Then
                DoesColorExist = True
            Else
                DoesColorExist = False
            End If
        End Function

        Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
            Dim i As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Trim(LCase(IniFileHelper.ReadINI(Modules.lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), ""))) = lStringParameterName Then
                        IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")
                        Exit For
                    End If
                Next i
            End If
        End Sub

        Public Sub AddTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
            Dim i As Integer, n As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Len(IniFileHelper.ReadINI(Modules.lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")) = 0 Then
                        n = i
                        Exit For
                    End If
                Next i
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(n.ToString), lStringParameterName)
                lStrings.sFixedString(lTextStringIndex).sFind(n) = lStringParameterName
            End If
        End Sub

        Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)
            lColorTextBox.ScrollToCaret()
            lColorTextBox.SelectionStart = 0
        End Sub

        Public Function ReturnRightColorNumeric(ByVal lData As String) As Integer
            Dim result As Integer, msg As String, msg2 As String
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
        End Function

        Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)
            If Len(lData) <> 0 And lIndex <> 0 Then
                lStrings.sFixedString(lIndex).sData = lData
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Data", lData)
            End If
        End Sub

        Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lData As String)
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sDescription = lData
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Description", lData)
            End If
        End Sub

        Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sSyntax = lData
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Syntax", lData)
            End If
        End Sub

        Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)
            If lIndex <> 0 And Len(lData) <> 0 Then
                lStrings.sFixedString(lIndex).sSupport = lData
                IniFileHelper.WriteINI(Modules.lSettings.lINI.iText, Trim(Convert.ToString(lIndex)), "Support", lData)
            End If
        End Sub

        Public Sub ResetStrings()
            Modules.lProcessNumeric.lIrcNumericHelper.ResetMessages()
            ClearStrings()
            LoadStrings()
        End Sub

        Public Function FindStringIndexByDescription(ByVal lDescription As String) As Integer
            Dim result As Integer
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
        End Function

        Public Function ReturnStringTypeByDescription(ByVal lDescription As String) As eStringTypes
            Dim result As eStringTypes
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
        End Function

        Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer
            Dim i As Integer, result As Integer
            For i = 1 To lStrings.sFixedStringCount
                If lType = lStrings.sFixedString(i).sType Then
                    result = i
                    Exit For
                End If
            Next i
            Return result
        End Function

        Public Sub ProcessReplaceString(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "")
            Dim msg As String
            If Modules.lSettings.lIRC.iSettings.sNoIRCMessages = True Then Exit Sub
            msg = ReturnReplacedString(lType, r1, r2, r3, r4, r5, r6, r7, r8)
            If ReturnStringCompatibile(lType) = True Then
                If Len(msg) <> 0 Then Modules.lStatus.AddText(msg, lStatusIndex)
            Else
                Modules.lStatus.AddToUnsupported(lStatusIndex, msg)
            End If
        End Sub

        Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean
            Dim result As Boolean, c As Integer = FindStringIndex(lType), i As Integer
            With lStrings.sFixedString(c)
                For i = 1 To Modules.lSettings.lCompatibility.cCount
                    If InStr(LCase(Trim(Modules.lSettings.lCompatibility.cCompatibility(i).cDescription)), LCase(Trim(.sSupport))) <> 0 And Modules.lSettings.lCompatibility.cCompatibility(i).cEnabled = True Then
                        result = True
                        Exit For
                    End If
                Next i
            End With
            Return result
        End Function

        Public Function ReturnReplacedString(ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "") As String
            Dim msg As String, i As Integer
            i = FindStringIndex(lType)
            msg = lStrings.sFixedString(i).sData
            msg = msg.Replace("$crlf", Chr(10))
            msg = Replace(msg, "$space", " ")
            msg = Replace(msg, "$4sp", "    ")
            msg = Replace(msg, "$activeservername", Modules.lStatus.Description(Modules.lStatus.ActiveIndex))
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
        End Function

        Public Sub SaveTextStrings()
            Dim i As Integer
            For i = 1 To 200
                If Len(lStrings.sFixedString(i).sData) <> 0 Then
                    IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Type", Trim(Str(lStrings.sFixedString(i).sType)))
                    IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Data", Trim(lStrings.sFixedString(i).sData))
                    If Len(lStrings.sFixedString(i).sFind(1)) <> 0 Then IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Find1", lStrings.sFixedString(i).sFind(1))
                    If Len(lStrings.sFixedString(i).sFind(2)) <> 0 Then IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Find2", lStrings.sFixedString(i).sFind(2))
                    If Len(lStrings.sFixedString(i).sFind(3)) <> 0 Then IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Find3", lStrings.sFixedString(i).sFind(3))
                    If Len(lStrings.sFixedString(i).sFind(4)) <> 0 Then IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Find4", lStrings.sFixedString(i).sFind(4))
                    If Len(lStrings.sFixedString(i).sFind(5)) <> 0 Then IniFileHelper.WriteINI(Modules.lSettings.ReturnTextINI, Trim(Str(i)), "Find5", lStrings.sFixedString(i).sFind(5))
                End If
            Next i
        End Sub

        Public Function ReturnStringDataByType(ByVal lType As eStringTypes) As String
            Dim i As Integer
            For i = 1 To 200
                If lStrings.sFixedString(i).sType = lType Then
                    ReturnStringDataByType = lStrings.sFixedString(i).sData
                    Exit Function
                End If
            Next i
            ReturnStringDataByType = ""
        End Function

        Public Sub SetStringData(ByVal lType As eStringTypes, ByVal lData As String)
            Dim i As Integer
            i = FindStringIndex(lType)
            If i <> 0 Then
                lStrings.sFixedString(i).sData = lData
            End If
        End Sub

        Public Sub ClearStrings()
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
        End Sub

        Public Sub LoadCommands()
            lCommands = New List(Of Command)
            Dim c = Convert.ToInt32(IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, "Settings", "Count", "0"))
            For i As Integer = 1 To lCommands.Count
                With lCommands(i)
                    .Data = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Command", "")
                    If (Not String.IsNullOrEmpty(.Data)) Then
                        .CommandType = CType(IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Type", ""), IrcCommandTypes)
                        .Display = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Display", "")
                        .Param1 = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Param1", "")
                        If Len(.Param1) <> 0 Then .Param2 = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Param2", "")
                        If Len(.Param2) <> 0 Then .Param3 = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Param3", "")
                        If Len(.Param3) <> 0 Then .Param4 = IniFileHelper.ReadINI(Modules.lSettings.ReturnCommandsINI, Trim(Str(i)), "Param4", "")
                    End If
                End With
            Next i
        End Sub

        Public Sub LoadStrings()
            Dim msg As String, msg2 As String, splt() As String, splt2() As String
            Dim lIndex As Integer
            ReDim lStrings.sFixedString(Modules.lSettings.lArraySizes.aStrings)
            msg2 = My.Computer.FileSystem.ReadAllText(Modules.lSettings.lINI.iText, System.Text.Encoding.UTF8)
            msg2 = Replace(msg2, "$syschar", "•")
            msg2 = Replace(msg2, "$arrowchar", "»")
            splt = Split(msg2, Environment.NewLine)
            For Each msg In splt
                If LCase(msg) = "[settings]" Then
                Else
                    If Left(msg, 1) = "[" And Right(msg, 1) = "]" Then
                        lIndex = Convert.ToInt32(Trim(TextHelper.ParseData(msg, "[", "]")))
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
        End Sub

        Public Sub PopulateListViewWithStrings(ByVal lListView As RadListView)
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
        End Sub

        Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)
            lTextBox.Text = lData & Environment.NewLine & lTextBox.Text
        End Sub

        Public Sub Print(ByVal data As String, ByVal richTextBox As RadRichTextBox)
            Dim ircChar As String = "", s As Span, mint As Integer, i As Integer, msg As String, currentText As String = "", subText1 As String = "", subText2 As String = "", isForeColorSet As Boolean = False, isBackColorSet As Boolean = False
            richTextBox.Document.Selection.Clear()
            richTextBox.Document.CaretPosition.MoveToLastPositionInDocument()
            If (Not String.IsNullOrEmpty(data)) Then
                If (richTextBox.RichTextBoxElement.Tag = "1") Then
                    richTextBox.InsertLineBreak()
                Else
                    richTextBox.RichTextBoxElement.Tag = "1"
                End If
                If (Not data.Contains(ircChar)) Then
                    s = New Span(data)
                    s.FontSize = 20
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
                                        s.FontSize = 20
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
                                            s.ForeColor = TextHelper.ConvertIntToSystemColor(mint, True)
                                        ElseIf (Integer.TryParse(subText1, mint)) Then
                                            isForeColorSet = True
                                            data = data.Remove(0, 1)
                                            s.ForeColor = TextHelper.ConvertIntToSystemColor(mint, True)
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
                                        s.FontSize = 20
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
                            s.FontSize = 20
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
                                If (i > Modules.lSettings.lIRC.iSettings.sTextBufferSize) Then
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
        End Function
    End Class
End Namespace