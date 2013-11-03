'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
'Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Classes.IO
Imports nexIRC.Classes.UI
Imports nexIRC.clsCommandTypes
Imports nexIRC.clsIrcNumerics
Imports nexIRC.Modules

Module mdlStrings
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
        'On Error Resume Next
        Dim lCommandData As gCommandReturnData
        lCommandData = ReturnReplacedCommand(lType, p1, p2, p3, p4)
        If Len(lCommandData.cSocketData) <> 0 And Len(lCommandData.cDoColorData) <> 0 Then
            lStatus.SendSocket(lStatusIndex, lCommandData.cSocketData)
            lStatus.AddText(lCommandData.cDoColorData, lStatusIndex)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub ProcessReplaceCommand(lType As eStringTypes, lTextBox As ctlTBox, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String)")
    End Sub

    Private Function FindCommandIndex(ByVal lType As eCommandTypes) As Integer
        'On Error Resume Next
        Dim i As Integer
        For i = 1 To lCommands.cCount
            If lType = lCommands.cCommad(i).cCommandType Then
                FindCommandIndex = i
                Exit Function
            End If
        Next i
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Function FindStringIndex(lType As eStringTypes) As Integer")
    End Function

    Public Function ReturnReplacedCommand(ByVal lType As eCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "") As gCommandReturnData
        'On Error Resume Next
        Dim msg As String, msg2 As String, i As Integer
        i = FindCommandIndex(lType)
        If i <> 0 Then
            msg = lCommands.cCommad(i).cData
            msg2 = lCommands.cCommad(i).cDisplay
            msg = Replace(msg, "$crlf", "")
            msg = Replace(msg, "$space", " ")
            msg = Replace(msg, "$4sp", "    ")
            msg2 = Replace(msg2, "$crlf", "")
            msg2 = Replace(msg2, "$space", " ")
            msg2 = Replace(msg2, "$4sp", "    ")
            If InStr(msg, "$activeservername") <> 0 Then msg = Replace(msg, "$activeservername", lStatus.Description(lStatus.ActiveIndex))
            If InStr(msg2, "$activeservername") <> 0 Then msg2 = Replace(msg2, "$activeservername", lStatus.Description(lStatus.ActiveIndex))
            With lCommands.cCommad(i)
                If Len(p1) <> 0 Then
                    msg = Replace(msg, .cParam1, p1, 1, -1, vbTextCompare)
                    msg2 = Replace(msg2, .cParam1, p1, 1, -1, vbTextCompare)
                End If
                If Len(p2) <> 0 Then
                    msg = Replace(msg, .cParam2, p2, 1, -1, vbTextCompare)
                    msg2 = Replace(msg2, .cParam2, p2, 1, -1, vbTextCompare)
                End If
                If Len(p3) <> 0 Then
                    msg = Replace(msg, .cParam3, p3, 1, -1, vbTextCompare)
                    msg2 = Replace(msg2, .cParam3, p3, 1, -1, vbTextCompare)
                End If
                If Len(p4) <> 0 Then
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
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnReplacedString(lType As eStringTypes, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String) As String")
    End Function

    Public Function DoesColorExist(ByVal lData As String) As Boolean
        'On Error Resume Next
        If Len(lData) <> 0 And InStr(lData, lColorChar) <> 0 Then
            DoesColorExist = True
        Else
            DoesColorExist = False
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function DoesColorExist(ByVal lData As String) As Boolean")
    End Function

    Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        Try
            Dim i As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Trim(LCase(clsFiles.ReadINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), ""))) = lStringParameterName Then
                        clsFiles.WriteINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")
                        Exit For
                    End If
                Next i
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)")
        End Try
    End Sub

    Public Sub AddTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        Try
            Dim i As Integer, n As Integer
            If Len(lStringParameterName) <> 0 Then
                For i = 1 To 100
                    If Len(clsFiles.ReadINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")) = 0 Then
                        n = i
                        Exit For
                    End If
                Next i
                clsFiles.WriteINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(n.ToString), lStringParameterName)
                lStrings.sFixedString(lTextStringIndex).sFind(n) = lStringParameterName
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub AddTextStringParameter(ByVal lStringParameterName As String)")
        End Try
    End Sub

    Public Sub tDoColor(ByVal lData As String, ByVal lColorTextBox As RichTextBox)
        'On Error Resume Next
        Dim msg As String, splt() As String, n As Integer, i As Integer, b As Boolean, msg2 As String
        Dim lFont As System.Drawing.Font = lColorTextBox.SelectionFont
        lData = Replace(lData, "docolor", "")
        msg = lData
        lBackgroundColor = 16
        lColorTextBox.SelectionStart = 0
        lColorTextBox.SelectionLength = 0
        If InStr(lData, "") <> 0 Then
            lFont = lColorTextBox.SelectionFont
            splt = Split(msg, "")
            For i = 0 To UBound(splt)
                If Len(splt(i)) <> 0 Then
                    lBackgroundColor = 16
                    n = ReturnRightColorNumeric(splt(i))
                    msg2 = Trim(CStr(n))
                    lColorTextBox.SelectionColor = ConvertIntToSystemColor(n)
                    lColorTextBox.SelectionBackColor = ConvertIntToSystemColor(lBackgroundColor)
                    If Left(splt(i), Len(msg2)) = msg2 Then splt(i) = Right(splt(i), Len(splt(i)) - Len(msg2))
                    If Len(msg2) <> 0 Then
                        If Left(splt(i), 1) = "," Then
                            splt(i) = Right(splt(i), Len(splt(i)) - 1)
                            If IsNumeric(Left(splt(i), 1)) Then
                                If IsNumeric(Left(splt(i), 2)) Then
                                    splt(i) = Right(splt(i), Len(splt(i)) - 2)
                                Else
                                    splt(i) = Right(splt(i), Len(splt(i)) - 1)
                                End If
                            End If
                        End If
                    End If
                    If i = 0 Then
                        lColorTextBox.SelectedText = LTrim(Right(splt(i), Len(splt(i)) + Len(Trim(CStr(n)))))
                    Else
                        lColorTextBox.SelectedText = Right(splt(i), Len(splt(i)) + Len(Trim(CStr(n))))
                    End If
                End If
            Next i
            lColorTextBox.SelectedText = vbCrLf
        Else
            lColorTextBox.SelectionColor = Color.Black
            lColorTextBox.SelectionBackColor = ConvertIntToSystemColor(lBackgroundColor)
            lColorTextBox.SelectedText = msg & vbCrLf
        End If
        If InStr(lData, "") <> 0 Then
            splt = Split(lData, "")
            Select Case UBound(splt)
                Case 1
                    If Len(splt(1)) <> 0 Then
                        If Left(Trim(splt(1)), 1) = "" Then
                            lColorTextBox.Select(0, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        Else
                            lColorTextBox.Select(InStr(lData, "") - 1, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        End If
                    End If
                Case 2
                    If Len(splt(1)) <> 0 Then
                        If Left(Trim(splt(1)), 1) = "" Then
                            lColorTextBox.Select(0, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        Else
                            lColorTextBox.Select(InStr(lData, "") - 1, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        End If
                        If Left(Trim(splt(2)), 1) = "" Then
                            lColorTextBox.Select(0, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        Else
                            lColorTextBox.Select(InStr(lData, "") - 1, Len(lData))
                            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                            lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                        End If
                    End If
                Case Else
                    For i = 0 To UBound(splt)
                        If i <> 0 Then
                            If b = True Then
                                b = False
                            Else
                                b = True
                            End If
                        End If
                        If Len(splt(i)) <> 0 Then
                            n = lColorTextBox.Find(splt(i))
                            n = n - 1
                            If n = -1 Then n = 0
                            If n > 0 Then
                                lColorTextBox.Select(n, n + Len(splt(i)))
                                If b = True Then
                                    lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Bold)
                                Else
                                    lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Regular)
                                End If
                                lColorTextBox.SelectedText = Replace(lColorTextBox.SelectedText, "", "")
                            End If
                        End If
                    Next i
            End Select
            lColorTextBox.SelectionFont = New Font(lFont.FontFamily, lFont.Size, FontStyle.Regular)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub DoColor(ByVal lData As String)")
    End Sub

    Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)
        'On Error Resume Next
        lColorTextBox.ScrollToCaret()
        lColorTextBox.SelectionStart = 0
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)")
    End Sub

    Public Function ConvertIntToSystemColor(ByVal lColor As Integer, Optional lBlackSetting As Boolean = False) As System.Drawing.Color
        'On Error Resume Next
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
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ConvertIntToSystemColor(ByVal lColor As Integer) As System.Drawing.Color")
    End Function

    Public Function ReturnRightColorNumeric(ByVal lData As String) As Integer
        'On Error Resume Next
        Dim msg As String, msg2 As String
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
                    ReturnRightColorNumeric = CInt(Trim(msg))
                    lBackgroundColor = CInt(msg2)
                Else
                    ReturnRightColorNumeric = 0
                    lBackgroundColor = 16
                End If
            End If
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnRightNumeric(ByVal lData As String) As Integer")
    End Function

    Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)
        'On Error Resume Next
        If Len(lData) <> 0 And lIndex <> 0 Then
            lStrings.sFixedString(lIndex).sData = lData
            clsFiles.WriteINI(lINI.iText, Trim(CStr(lIndex)), "Data", lData)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lData As String)
        'On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sDescription = lData
            clsFiles.WriteINI(lINI.iText, Trim(CStr(lIndex)), "Description", lData)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lDescription As String)")
    End Sub

    Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)
        'On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sSyntax = lData
            clsFiles.WriteINI(lINI.iText, Trim(CStr(lIndex)), "Syntax", lData)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)
        'On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sSupport = lData
            clsFiles.WriteINI(lINI.iText, Trim(CStr(lIndex)), "Support", lData)
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub ResetStrings()
        'On Error Resume Next
        lProcessNumeric.lIrcNumericHelper.ResetMessages()
        ClearStrings()
        LoadStrings()
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub ResetStrings()")
    End Sub

    Public Function FindStringIndexByDescription(ByVal lDescription As String) As Integer
        'On Error Resume Next
        Dim i As Integer
        If Len(lDescription) <> 0 Then
            For i = 1 To lStrings.sFixedStringCount
                If LCase(lDescription) = LCase(lStrings.sFixedString(i).sDescription) Then
                    FindStringIndexByDescription = i
                    Exit For
                End If
            Next i
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function FindStringIndexByDescription(lDescription As String) As Integer")
    End Function

    Public Function ReturnStringTypeByDescription(ByVal lDescription As String) As eStringTypes
        'On Error Resume Next
        Dim i As Integer
        If Len(lDescription) <> 0 Then
            For i = 1 To 200
                If LCase(lDescription) = LCase(lStrings.sFixedString(i).sDescription) Then
                    ReturnStringTypeByDescription = lStrings.sFixedString(i).sType
                    Exit For
                End If
            Next i
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnStringTypeByDescription(lDescription As String) As eStringTypes")
    End Function

    Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer
        Try
            Dim i As Integer
            For i = 1 To lStrings.sFixedStringCount
                If lType = lStrings.sFixedString(i).sType Then
                    FindStringIndex = i
                    Exit Function
                End If
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer")
        End Try
    End Function

    Public Sub ProcessReplaceString(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "")
        Try
            Dim msg As String
            If lIRC.iSettings.sNoIRCMessages = True Then Exit Sub
            msg = ReturnReplacedString(lType, r1, r2, r3, r4, r5, r6, r7, r8)
            If ReturnStringCompatibile(lType) = True Then
                If Len(msg) <> 0 Then lStatus.AddText(msg, lStatusIndex)
            Else
                lStatus.AddToUnsupported(lStatusIndex, msg)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub ProcessReplaceString()")
        End Try
    End Sub

    Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean
        'On Error Resume Next
        Dim c As Integer = FindStringIndex(lType), i As Integer
        With lStrings.sFixedString(c)
            For i = 1 To lCompatibility.cCount
                If InStr(LCase(Trim(lCompatibility.cCompatibility(i).cDescription)), LCase(Trim(.sSupport))) <> 0 And lCompatibility.cCompatibility(i).cEnabled = True Then
                    ReturnStringCompatibile = True
                    Exit For
                End If
            Next i
        End With
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean")
    End Function

    Public Function ReturnReplacedString(ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "") As String
        'On Error Resume Next
        Dim msg As String, i As Integer
        i = FindStringIndex(lType)
        msg = lStrings.sFixedString(i).sData
        msg = Replace(msg, "$crlf", Chr(13))
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
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnReplacedString(lType As eStringTypes, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String) As String")
    End Function

    Public Sub SaveTextStrings()
        'On Error Resume Next
        Dim i As Integer
        For i = 1 To 200
            If Len(lStrings.sFixedString(i).sData) <> 0 Then
                clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Type", Trim(Str(lStrings.sFixedString(i).sType)))
                clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Data", Trim(lStrings.sFixedString(i).sData))
                If Len(lStrings.sFixedString(i).sFind(1)) <> 0 Then clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Find1", lStrings.sFixedString(i).sFind(1))
                If Len(lStrings.sFixedString(i).sFind(2)) <> 0 Then clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Find2", lStrings.sFixedString(i).sFind(2))
                If Len(lStrings.sFixedString(i).sFind(3)) <> 0 Then clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Find3", lStrings.sFixedString(i).sFind(3))
                If Len(lStrings.sFixedString(i).sFind(4)) <> 0 Then clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Find4", lStrings.sFixedString(i).sFind(4))
                If Len(lStrings.sFixedString(i).sFind(5)) <> 0 Then clsFiles.WriteINI(ReturnTextINI, Trim(Str(i)), "Find5", lStrings.sFixedString(i).sFind(5))
            End If
        Next i
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SaveTextStrings()")
    End Sub

    Public Function ReturnStringDataByType(ByVal lType As eStringTypes) As String
        'On Error Resume Next
        Dim i As Integer
        For i = 1 To 200
            If lStrings.sFixedString(i).sType = lType Then
                ReturnStringDataByType = lStrings.sFixedString(i).sData
                Exit Function
            End If
        Next i
        ReturnStringDataByType = ""
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ReturnStringData(lIndex As Integer) As String")
    End Function

    Public Sub SetStringData(ByVal lType As eStringTypes, ByVal lData As String)
        'On Error Resume Next
        Dim i As Integer
        i = FindStringIndex(lType)
        If i <> 0 Then
            lStrings.sFixedString(i).sData = lData
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub SetStringData(lType As eStringTypes)")
    End Sub

    Public Sub ClearStrings()
        'On Error Resume Next
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
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub ClearStrings()")
    End Sub

    Public Sub LoadCommands()
        'On Error Resume Next
        Dim i As Integer
        ReDim lCommands.cCommad(100)
        lCommands.cCount = CInt(clsFiles.ReadINI(ReturnCommandsINI, "Settings", "Count", "0"))
        For i = 1 To lCommands.cCount
            With lCommands.cCommad(i)
                .cData = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Command", "")
                If Len(.cData) <> 0 Then
                    .cCommandType = CType(clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Type", ""), eCommandTypes)
                    .cDisplay = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Display", "")
                    .cParam1 = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param1", "")
                    If Len(.cParam1) <> 0 Then .cParam2 = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param2", "")
                    If Len(.cParam2) <> 0 Then .cParam3 = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param3", "")
                    If Len(.cParam3) <> 0 Then .cParam4 = clsFiles.ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param4", "")
                End If
            End With
        Next i
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub LoadCommand()")
    End Sub

    Public Sub LoadStrings()
        'On Error Resume Next
        Dim msg As String, msg2 As String, splt() As String, splt2() As String
        Dim lIndex As Integer
        ReDim lStrings.sFixedString(lArraySizes.aStrings)
        msg2 = My.Computer.FileSystem.ReadAllText(lINI.iText, System.Text.Encoding.UTF8)
        msg2 = Replace(msg2, "$syschar", "•")
        msg2 = Replace(msg2, "$arrowchar", "»")
        splt = Split(msg2, vbCrLf)
        For Each msg In splt
            If LCase(msg) = "[settings]" Then
            Else
                If Left(msg, 1) = "[" And Right(msg, 1) = "]" Then
                    lIndex = CInt(Trim(ParseData(msg, "[", "]")))
                    ReDim lStrings.sFixedString(lIndex).sFind(8)
                Else
                    splt2 = Split(msg, "=")
                    Select Case LCase(splt2(0))
                        Case "count"
                            lStrings.sFixedStringCount = CInt(Trim(splt2(1)))
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
        If Err.Number <> 0 Then MsgBox(Err.Description)
    End Sub

    Public Sub PopulateListViewWithStrings(ByVal lListView As RadListView)
        'On Error Resume Next
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
                    lItem.SubItems.Add(Trim(CStr(.sType)))
                    lItem.SubItems.Add(.sData)
                    lListView.Items.Add(lItem)
                    'lListView.Show()
                End If
            End With
        Next i
        lListView.SelectedIndex = 0
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub PopulateListViewWithStrings(ByVal lListView As ListView)")
    End Sub

    Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)
        'On Error Resume Next
        'clsLockWindowUpdate.LockWindowUpdate(lTextBox.Handle)
        lTextBox.Text = lData & vbCrLf & lTextBox.Text
        'clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)")
    End Sub

    Public Function GetFileTitle(ByVal lFileName As String) As String
        'On Error Resume Next
        Dim msg() As String
        msg = Split(lFileName, "\")
        GetFileTitle = msg(UBound(msg))
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function GetFileTitle(ByVal lFileName As String) As String")
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
            ProcessError(ex.Message, "Public Function StripColorCodes(ByVal lData As String) As String")
            Return Nothing
        End Try
    End Function

    Public Sub DoColor(lData As String, lTextBox As RichTextBox, Optional _Black As Boolean = False)
        Try
            _Black = True
            Dim i As Integer, msg As String, lBackColor As Integer = 16, lForeColor As Integer, _ScrollToBottom As New clsScrollToBottom
            If Len(lData.Trim) = 0 Then Exit Sub
            If lQuerySettings.qEnableSpamFilter = True Then
                For i = 1 To lQuerySettings.qSpamPhraseCount
                    If InStr(LCase(lData), LCase(lQuerySettings.qSpamPhrases(i).ToString)) <> 0 Then Exit Sub
                Next i
            End If
            'clsLockWindowUpdate.LockWindowUpdate(lTextBox.Handle)
            lTextBox.SelectionStart = Len(lTextBox.Text)
            lTextBox.SelectionLength = Len(lTextBox.Text)
            lTextBox.SelectedText = vbCrLf
            'clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
            If InStr(lData, "") <> 0 Then
                For i = 0 To Len(lData)
                    If Len(lData) = 0 Then
                        'clsLockWindowUpdate.LockWindowUpdate(lTextBox.Handle)
                        'lTextBox.SelectionStart = lTextBox.Text.Length
                        'lTextBox.SelectionLength = lTextBox.Text.Length
                        'lTextBox.ScrollToCaret()
                        _ScrollToBottom.ScrollToBottom(lTextBox)
                        'clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
                        Exit Sub
                    End If
                    msg = Left(lData, 1)
                    lData = Right(lData, Len(lData) - 1)
                    If msg = "" Then
                        If IsNumeric(Left(lData, 2)) = True And Not InStr(Left(lData, 2), ",") <> 0 Then
                            lForeColor = CInt(Trim(Left(lData, 2)))
                            lData = Right(lData, Len(lData) - 2)
                        ElseIf IsNumeric(Left(lData, 1)) Then
                            lForeColor = CInt(Trim(Left(lData, 1)))
                            lData = Right(lData, Len(lData) - 1)
                        Else
                            lForeColor = 0
                            lBackColor = 16
                            lTextBox.SelectionColor = ConvertIntToSystemColor(lForeColor, _Black)
                            lTextBox.SelectionBackColor = ConvertIntToSystemColor(lBackColor, _Black)
                            If msg <> "" Then
                                lTextBox.SelectedText = msg
                            End If
                        End If
                        If Left(lData, 1) = "," Then
                            lData = Right(lData, Len(lData) - 1)
                            If IsNumeric(Left(lData, 2)) = True And Not InStr(Left(lData, 2), ",") <> 0 Then
                                lBackColor = CInt(Trim(Left(lData, 2)))
                                lData = Right(lData, Len(lData) - 2)
                            ElseIf IsNumeric(Left(lData, 1)) Then
                                lBackColor = CInt(Trim(Left(lData, 1)))
                                lData = Right(lData, Len(lData) - 1)
                            End If
                        End If
                    Else
                        lTextBox.SelectionColor = ConvertIntToSystemColor(lForeColor, _Black)
                        lTextBox.SelectionBackColor = ConvertIntToSystemColor(lBackColor, _Black)
                        If msg <> "" Then
                            'clsLockWindowUpdate.LockWindowUpdate(lTextBox.Handle)
                            lTextBox.SelectedText = msg
                            'clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
                        End If
                    End If
                Next i
            Else
                lTextBox.SelectionColor = ConvertIntToSystemColor(lForeColor, _Black)
                lTextBox.SelectionBackColor = ConvertIntToSystemColor(lBackColor, _Black)
                lTextBox.SelectedText = lData
            End If
            'lTextBox.SelectionStart = lTextBox.Text.Length
            'lTextBox.SelectionLength = lTextBox.TextLength
            'lTextBox.ScrollToCaret()
            'clsLockWindowUpdate.LockWindowUpdate(lTextBox.Handle)
            _ScrollToBottom.ScrollToBottom(lTextBox)
            'clsLockWindowUpdate.LockWindowUpdate(IntPtr.Zero)
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub DoColor(lData As String, lTextBox As RichTextBox)")
        End Try
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
            ProcessError(ex.Message, "Private Function DecodeLongIPAddr(ByVal LongIPAddr As String) As String")
            Return ""
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
            ProcessError(ex.Message, "Private Function EncodeIPAddr(ByVal IPAddr As String) As String")
            Return ""
        End Try
    End Function

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function GetRnd(ByVal lStart As Integer, ByVal lEnd As Integer) As Long
        Try
            Dim i As Long
            Randomize()
            i = lStart + (Rnd() * (lEnd - lStart))
            Return i
        Catch ex As Exception
            ProcessError(ex.Message, "Private Function GetRnd(ByVal lStart As Integer, ByVal lEnd As Integer) As Long")
        End Try
    End Function

    Public Function DoRight(ByVal lData As String, ByVal lLength As Integer) As String
        Try
            DoRight = Right(lData, lLength).ToString
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function DoRight(ByVal lData As String, ByVal lLength As Integer)")
            Return Nothing
        End Try
    End Function

    Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer) As String
        Try
            DoLeft = Left(lData, lLength).ToString
        Catch ex As Exception
            ProcessError(ex.Message, "Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer)")
            Return Nothing
        End Try
    End Function

    Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String
        'On Error Resume Next
        If Len(lString) <> 0 Then
            LeftRight = lString.Substring(lLeft, lDistance)
        Else
            LeftRight = ""
        End If
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String")
    End Function

    Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String) As String
        'On Error Resume Next
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
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String)")
    End Function
End Module