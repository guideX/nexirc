'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Public Class clsScript
    Enum eMathFunction
        mNotFound = 0
        mAdd = 1
        mSubtract = 2
        mMultiply = 3
    End Enum

    Enum eStorageType
        sNotFound = 0
        sSubParam = 1
        sVariable = 2
        sIRC_SETTINGS = 3
        sSERVERS_SETTINGS = 4
    End Enum

    Enum eActions
        aMsgBox = 1
        aActiveStatusText = 2
    End Enum

    Structure gPositionInString
        Public pNameStart As Integer
        Public pStart As Integer
        Public pEnd As Integer
    End Structure

    Enum eDataTypes
        dString = 1
        dInteger = 2
    End Enum

    Structure gVariable
        Public vName As String
        Public vType As eDataTypes
        Public vData As String
        Public vParent As String
    End Structure

    Structure gVariables
        Public vVariable() As gVariable
        Public vCount As Integer
    End Structure

    Structure gSub
        Public sName As String
        Public sCode As String
        Public sParamNames() As String
        Public sParamTypes() As eDataTypes
        Public sParamValue() As String
        Public sParamCount As Integer
    End Structure

    Structure gSubs
        Public sCount As Integer
        Public sSub() As gSub
    End Structure

    Private lVariables As gVariables
    Private lSubs As gSubs
    Private Delegate Sub IntegerDelegate(ByVal lIndex As Integer)

    Private Function AddVariable(ByVal lName As String, ByVal lType As eDataTypes, ByVal lData As String, ByVal lParent As String) As Integer
        'Try
        If lVariables.vCount = lArraySizes.aSub Then
            ProcessError("Ran out of space for variables", "Public Function AddVariable(ByVal lName As String) As Integer")
            Exit Function
        End If
        If Len(lName) <> 0 Then
            lVariables.vCount = lVariables.vCount + 1
            With lVariables.vVariable(lVariables.vCount)
                .vName = lName
                .vType = lType
                .vData = lData
                .vParent = lParent
            End With
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function AddVariable(ByVal lName As String) As Integer")
        'End Try
    End Function

    Private Sub RemoveVariable(ByVal lIndex As Integer)
        'Try
        With lVariables.vVariable(lIndex)
            .vName = Nothing
            .vType = Nothing
            .vData = Nothing
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub RemoveVariable(ByVal lIndex As Integer)")
        'End Try
    End Sub

    Private Function FindVariableIndex(ByVal lSubIndex As Integer, ByVal lName As String) As Integer
        'Try
        If Len(lName) <> 0 Then
            For i As Integer = 1 To lVariables.vCount
                With lVariables.vVariable(i)
                    If InStr(Trim(LCase(.vName)), Trim(LCase(lName))) <> 0 And lSubIndex = FindSubIndex(.vParent) Then
                        Return i
                        Exit Function
                    End If
                End With
            Next i
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function FindVariableIndex(ByVal lName As String) As Integer")
        'End Try
    End Function

    Private Sub SortVariables()
        'Try
        Dim msg() As String, msg2() As eDataTypes, msg3() As String, msg4() As String, i As Integer, c As Integer
        ReDim msg(lArraySizes.aSub), msg2(lArraySizes.aSub), msg3(lArraySizes.aSub), msg4(lArraySizes.aSub)
        For i = 1 To lArraySizes.aSub
            With lVariables.vVariable(i)
                If Len(.vName) <> 0 Then
                    c = c + 1
                    msg(c) = .vName
                    msg2(c) = .vType
                    msg3(c) = .vData
                    msg4(c) = .vParent
                End If
            End With
        Next i
        For i = 0 To lArraySizes.aSub
            RemoveVariable(i)
        Next i
        lVariables.vCount = 0
        For i = 1 To c
            AddVariable(msg(i), msg2(i), msg3(i), msg4(i))
        Next i
        lVariables.vCount = 1
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub SortVariables()")
        'End Try
    End Sub

    Private Function AddSub(ByVal lName As String) As Integer
        'Try
        If lSubs.sCount = lArraySizes.aSub Then
            ProcessError("Ran out of space for subs", "Public Sub AddSub(ByVal lName As String, ByVal lCode As String)")
            Exit Function
        End If
        lName = Left(lName, Len(lName) - 2)
        lName = Right(lName, Len(lName) - 1)
        If Len(lName) <> 0 Then
            lSubs.sCount = lSubs.sCount + 1
            With lSubs.sSub(lSubs.sCount)
                ReDim .sParamNames(lArraySizes.aSub)
                ReDim .sParamTypes(lArraySizes.aSub)
                ReDim .sParamValue(lArraySizes.aSub)
                .sName = lName
            End With
            Return lSubs.sCount
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub AddSub(ByVal lName As String)")
        'End Try
    End Function

    Private Sub SetSubParamValue(ByVal lIndex As Integer, ByVal lParamIndex As Integer, ByVal lValue As String)
        'Try
        If lIndex <> 0 And lParamIndex <> 0 Then
            With lSubs.sSub(lIndex)
                Select Case .sParamTypes(lParamIndex)
                    Case eDataTypes.dString
                        .sParamValue(lParamIndex) = lValue
                    Case eDataTypes.dInteger
                        .sParamValue(lParamIndex) = lValue
                End Select
            End With
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetSubParamValue(ByVal lIndex As Integer, ByVal lParamIndex As Integer, ByVal lValue As String)")
        'End Try
    End Sub

    Private Sub AddSubParam(ByVal lIndex As Integer, ByVal lName As String, ByVal lDataType As eDataTypes)
        'Try
        With lSubs.sSub(lIndex)
            .sParamCount = .sParamCount + 1
            .sParamNames(.sParamCount) = lName
            .sParamTypes(.sParamCount) = lDataType
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub AddParam(ByVal lName As String, ByVal lDataType As eDataTypes)")
        'End Try
    End Sub

    Private Sub AddToSubCode(ByVal lIndex As Integer, ByVal lData As String)
        'Try
        With lSubs.sSub(lIndex)
            .sCode = .sCode & vbCrLf & lData
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub AddToSubCode(ByVal lIndex As Integer, ByVal lData As String)")
        'End Try
    End Sub

    Private Sub DeleteSub(ByVal lIndex As Integer)
        'Try
        If lIndex <> 0 Then
            With lSubs.sSub(lIndex)
                .sName = ""
                .sCode = ""
            End With
        End If
        SortSubs()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DeleteSub(ByVal lIndex As Integer)")
        'End Try
    End Sub

    Private Function ReturnSubParamValue(ByVal lIndex As Integer, ByVal lParamIndex As Integer) As String
        'Try
        Return lSubs.sSub(lIndex).sParamValue(lParamIndex)
        'Catch ex As Exception
        'Return Nothing
        'ProcessError(ex.Message, "Public Function ReturnSubParamValue(ByVal lIndex As Integer, ByVal lParamIndex As Integer) As String")
        'End Try
    End Function

    Private Function FindSubParamIndex(ByVal lIndex As Integer, ByVal lName As String) As Integer
        'Try
        Dim i As Integer
        With lSubs.sSub(lIndex)
            For i = 1 To .sParamCount
                If LCase(Trim(lName)) = LCase(Trim(.sParamNames(i))) Then
                    Return i
                    Exit For
                End If
            Next i
        End With
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function FindSubParamIndex(ByVal lIndex As Integer, ByVal lName As String) As Integer")
        'End Try
    End Function

    Private Function FindSubIndex(ByVal lName As String) As Integer
        'Try
        Dim i As Integer
        lName = Trim(lName)
        lName = Replace(lName, Chr(10), "")
        lName = Replace(lName, Chr(13), "")
        lName = Replace(lName, vbCrLf, "")
        For i = 0 To lSubs.sCount
            With lSubs.sSub(i)
                If Len(.sName) <> 0 Then
                    If InStr(.sName, lName) <> 0 Or InStr(lName, .sName) <> 0 Then
                        FindSubIndex = i
                        Exit Function
                    End If
                End If
            End With
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function FindSubIndex(ByVal lName As String) As Integer")
        'End Try
    End Function

    Private Sub SortSubs()
        'Try
        Dim msg() As String, msg2() As String, i As Integer, c As Integer
        ReDim msg(lArraySizes.aSub)
        ReDim msg2(lArraySizes.aSub)
        For i = 0 To lSubs.sCount
            With lSubs.sSub(i)
                If Len(lSubs.sSub(i).sName) <> 0 And Len(lSubs.sSub(i).sCode) <> 0 Then
                    msg(i) = lSubs.sSub(i).sName
                    msg2(i) = lSubs.sSub(i).sCode
                    c = c + 1
                End If
            End With
        Next i
        For i = 0 To lArraySizes.aSub
            With lSubs.sSub(i)
                .sName = ""
                .sCode = ""
            End With
        Next i
        lSubs.sCount = c
        For i = 0 To c
            With lSubs.sSub(i)
                .sName = msg(i)
                .sCode = msg(i)
            End With
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SortSubs()")
        'End Try
    End Sub

    Public Sub DoSubByName(ByVal lName As String)
        'Try
        Dim i As Integer
        If Len(lName) <> 0 Then
            i = FindSubIndex(lName)
            If i <> 0 Then DoCode(i)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoSubByName(ByVal lName As String)")
        'End Try
    End Sub

    Public Sub ReadCodeFile(ByVal lFile As String)
        'Try
        Dim msg As String, msg2 As String, splt() As String, splt2() As String, splt3() As String, i As Integer, n As Integer, t As Integer, lSub As Boolean, lSubCode As String = ""
        ReDim splt2(lArraySizes.aSub)
        If Len(lFile) <> 0 Then
            msg = My.Computer.FileSystem.ReadAllText(lFile)
            If Len(msg) <> 0 Then
                splt = Split(msg, vbCrLf)
                For i = 0 To UBound(splt)
                    splt(i) = Trim(splt(i))
                    If Left(splt(i), 1) = Chr(32) Then
                        splt(i) = Right(splt(i), Len(splt(i)) - 1)
                    End If
                    If lSub = False Then
                        If Left(LCase(splt(i)), 4) = "sub " And Right(splt(i), 1) = ")" Then
                            lSub = True
                            msg2 = Right(splt(i), Len(splt(i)) - 3)
                            n = AddSub(msg2)
                            msg2 = ParseData(splt(i), "(", ")")
                            If Len(msg2) <> 0 Then
                                splt2 = Split(msg2, ",")
                                For t = 0 To UBound(splt2)
                                    splt3 = Split(splt2(t), " As ")
                                    Select Case LCase(Trim(splt3(1)))
                                        Case "string"
                                            AddSubParam(n, splt3(0), eDataTypes.dString)
                                        Case "integer"
                                            AddSubParam(n, splt3(0), eDataTypes.dInteger)
                                    End Select
                                Next t
                            End If
                        End If
                    Else
                        If InStr(splt(i), "End Sub", CompareMethod.Text) <> 0 Then
                            lSub = False
                        Else
                            AddToSubCode(n, splt(i))
                        End If
                    End If
                Next i
            End If
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ReadCodeFile(ByVal lFile As String)")
        'End Try
    End Sub

    Private Function ReturnPositionInString(ByVal lData As String) As gPositionInString
        'Try
        Dim msg As String, i As Integer, n As Integer, t As Integer, e As Integer, b As Boolean
        msg = ""
        If Len(lData) = 0 Then
            'Return Nothing
            Exit Function
        End If
        For i = 0 To Len(lData)
            If Len(msg) <> 0 Then
                msg = msg & Left(lData, 1)
            Else
                msg = Left(lData, 1)
                e = Len(msg)
            End If
            lData = Right(lData, Len(lData) - 1)
            Select Case Right(msg, 1)
                Case "("
                    If b = True Then
                        e = Len(msg)
                    Else
                        b = True
                    End If
                    n = Len(msg)
                Case ")"
                    t = Len(msg)
                    ReturnPositionInString.pNameStart = e
                    ReturnPositionInString.pStart = n - 1
                    ReturnPositionInString.pEnd = t - 1
                    Exit For
            End Select
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function ReturnPositionInString(ByVal lData As String) As ePositionInString")
        'End Try
    End Function

    Private Function ReplaceTextCommandHelper(ByVal lCommand As String, ByVal lData As String) As String
        'Try
        Select Case LCase(lCommand)
            Case "ucase"
                Return UCase(lData)
            Case "lcase"
                Return LCase(lData)
            Case "trim"
                Return Trim(lData)
            Case Else
                Return lData
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function ReplaceTextCommandHelper(ByVal lCommand As String, ByVal lData As String) As String")
        'Return Nothing
        'End Try
    End Function

    Private Function HasOutSideQuotes(ByVal lData As String) As Boolean
        'Try
        If Len(lData) <> 0 And Left(lData, 1) = Chr(34) And Right(lData, 1) = Chr(34) Then HasOutSideQuotes = True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function HasOutSideQuotes(ByVal lData As String) As Boolean")
        'End Try
    End Function

    Private Function ReplaceTextCommand(ByVal lSubIndex As Integer, ByVal lBackupText As String, ByVal lFullText As String, ByVal lPartialText As String, ByVal lCommand As String, ByVal lInside As String) As String
        'Try
        Dim i As Integer, msg As String
        If HasOutSideQuotes(lInside) = True Then
            msg = lInside
            lInside = ReplaceTextCommandHelper(lCommand, lInside)
            lInside = Replace(lInside, Chr(34), "")
            lPartialText = Replace(lPartialText, msg, lInside)
            lFullText = Replace(lFullText, lBackupText, lPartialText)
        Else
            If Right(lInside, 3) = "& " & Chr(34) Then lInside = Trim(Replace(lInside, "& " & Chr(34), ""))
            msg = lInside
            i = FindSubParamIndex(lSubIndex, lInside)
            If i <> 0 Then
                lInside = lSubs.sSub(lSubIndex).sParamValue(i)
                lInside = ReplaceTextCommandHelper(lCommand, lInside)
            Else
                i = FindVariableIndex(lSubIndex, lInside)
                If i <> 0 Then
                    lInside = lVariables.vVariable(i).vData
                    lInside = ReplaceTextCommandHelper(lCommand, lInside)
                Else
                    lInside = ReplaceTextCommandHelper(lCommand, lInside)
                End If
            End If
            lPartialText = Replace(lPartialText, msg, lInside)
            lPartialText = Replace(lPartialText, "Trim(", "")
            If Left(LCase(lPartialText), 6) = "lcase(" And Right(lPartialText, 1) = ")" Then
                lPartialText = Left(lPartialText, Len(lPartialText) - 1)
                lPartialText = Replace(LCase(lPartialText), "LCASE(", "")
            End If
            If Left(LCase(lPartialText), 6) = "ucase(" And Right(lPartialText, 1) = ")" Then
                lPartialText = Left(lPartialText, Len(lPartialText) - 1)
                lPartialText = Replace(UCase(lPartialText), "UCASE(", "")
            End If
            If Right(lPartialText, 1) = ")" Then lPartialText = Left(lPartialText, Len(lPartialText) - 1)
            If InStr(lFullText, Chr(34)) <> 0 And Not InStr(lBackupText, Chr(34)) <> 0 Then
                lFullText = Replace(lFullText, Chr(34), "")
                If lFullText = lBackupText Then
                    lFullText = lPartialText
                Else
                    lFullText = Replace(lFullText, lBackupText, lPartialText)
                End If
            Else
                lFullText = Replace(lFullText, lBackupText, lPartialText)
            End If
        End If
        Return lFullText
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function ReplaceTextCommand(ByVal lSubIndex As Integer, ByVal lBackupText As String, ByVal lFullText As String, ByVal lPartialText As String, ByVal lCommand As String, ByVal lInside As String) As String")
        'Return Nothing
        'End Try
    End Function

    Private Function RemoveParenthesis(ByVal lData As String) As String
        'Try
        If Len(lData) <> 0 Then
            lData = Replace(lData, "(", "")
            lData = Replace(lData, ")", "")
            Return lData
        Else
            Return ""
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function RemoveParenthesis(ByVal lData As String) As String")
        'Return Nothing
        'End Try
    End Function

    Private Function HasParenthesis(ByVal lData As String) As Boolean
        'Try
        If Len(lData) <> 0 And InStr(lData, "(") <> 0 And InStr(lData, ")") <> 0 Then Return True
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function HasParenthesis(ByVal lData As String) As Boolean")
        'End Try
    End Function

    Private Function ReplaceText(ByVal lSubIndex As Integer, ByVal lData As String) As String
        'Try
        Dim n As Integer, t As Integer, e As Integer, r As Integer, b As Boolean, msg As String, msg2 As String, msg3 As String, msg5 As String = "", msg6 As String, msg7 As String, pos As gPositionInString
        If Len(lData) <> 0 Then
            msg5 = lData
            If HasParenthesis(lData) = True Then
                msg = ""
                Do Until b = True
                    If Len(lData) <> 0 Then
                        e = e + 1
                        If Left(lData, 1) = "(" Then n = n + 1
                        If Left(lData, 1) = ")" Then t = t + 1
                        If Left(lData, 1) = Chr(34) Then
                            lData = Right(lData, Len(lData) - 1)
                        ElseIf Left(lData, 3) = " & " Then
                            lData = Right(lData, Len(lData) - 3)
                        Else
                            If Len(msg) = 0 Then
                                msg = Left(lData, 1)
                                lData = Right(lData, Len(lData) - 1)
                            Else
                                msg = msg & Left(lData, 1)
                                lData = Right(lData, Len(lData) - 1)
                            End If
                        End If
                        If n <> 0 And t <> 0 And n = t Then
                            n = 0
                            t = 0
                            If Len(msg) <> 0 Then
                                msg6 = msg
                                pos = ReturnPositionInString(msg)
                                msg2 = Mid(msg, pos.pNameStart, pos.pStart)
                                msg3 = Mid(msg, pos.pStart + 2, pos.pEnd)
                                msg2 = RemoveParenthesis(msg2)
                                msg3 = RemoveParenthesis(msg3)
                                msg7 = ""
                                If InStr(msg2, " ") <> 0 Then
                                    For r = 0 To Len(msg2)
                                        If Left(msg2, 1) = " " Then
                                            msg7 = ""
                                        ElseIf Left(msg2, 1) = "(" And Not InStr(msg2, " ") <> 0 Then
                                            msg2 = msg7
                                            Exit For
                                        Else
                                            If Len(msg7) <> 0 Then
                                                msg7 = msg7 & Left(msg2, 1)
                                            Else
                                                msg7 = Left(msg2, 1)
                                            End If
                                        End If
                                        If Len(msg2) <> 0 Then msg2 = Right(msg, Len(msg2) - 1)
                                    Next r
                                End If
                                msg5 = ReplaceTextCommand(lSubIndex, msg6, msg5, msg, msg2, msg3)
                                If Len(lData) = 0 Then
                                    b = True
                                End If
                            End If
                        End If
                    Else
                        b = True
                        Return msg5
                        Exit Do
                    End If
                Loop
            End If
        End If
        Return msg5
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub DoCodeLine(ByVal lSubIndex As Integer, ByVal lData As String)")
        'Return Nothing
        'End Try
    End Function

    Public Sub DoCodeHelper(ByVal lIndex As Integer, ByVal lCommand As eActions, ByVal lData As String)
        'Try
        Select Case lCommand
            Case eActions.aMsgBox
                MsgBox(lData)
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoCodeHelper(ByVal lIndex As Integer, ByVal lCommand As String, ByVal lData As String)")
        'End Try
    End Sub

    Public Function TrimEnds(ByVal lData As String) As String
        'Try
        If Len(lData) <> 0 Then
            lData = Left(lData, Len(lData) - 1)
            lData = Right(lData, Len(lData) - 1)
        End If
        Return lData
        'Catch ex As Exception
        'Return Nothing
        'ProcessError(ex.Message, "Public Function TrimEnds(ByVal lData As String) As String")
        'End Try
    End Function

    Public Function ReturnDataInsideParenthesis(ByVal lData As String) As String
        'Try
        Return lData
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function ReturnDataInsideParenthesis() As String")
        'Return Nothing
        'End Try
    End Function

    Public Function ReturnVariableValue(ByVal lVariableIndex As Integer) As String
        'Try
        Return lVariables.vVariable(lVariableIndex).vData
        'Catch ex As Exception
        'Return Nothing
        'ProcessError(ex.Message, "Public Function ReturnVariableValue(ByVal lSubIndex As Integer, ByVal lVariableIndex As Integer) As String")
        'End Try
    End Function

    Public Sub SetVariableValue(ByVal lIndex As Integer, ByVal lData As String)
        'Try
        If lIndex <> 0 And Len(lData) <> 0 Then
            With lVariables.vVariable(lIndex)
                .vData = lData
            End With
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetVariableValue(ByVal lIndex As Integer, ByVal lData As String)")
        'End Try
    End Sub

    Public Sub DoCode(ByVal lIndex As Integer)
        'Try
        Dim i As Integer, n As Integer, t As Integer, e2 As Integer, e As Integer, msg As String = "", msg2 As String, splt() As String, splt2() As String, splt3() As String, b As Boolean, o As Boolean, a As eActions, s As eStorageType, s2 As eStorageType, s3 As eStorageType, l As Boolean, m As eMathFunction
        splt = Split(lSubs.sSub(lIndex).sCode, vbCrLf)
        For i = 0 To UBound(splt)
            o = False
            splt(i) = Trim(splt(i))
            If Len(splt(i)) <> 0 Then
                If Not Left(splt(i), 1) = "'" Then
                    If InStr(LCase(splt(i)), "datetime.now.tostring") <> 0 Then splt(i) = Replace(LCase(splt(i)), "datetime.now.tostring", Chr(34) & DateTime.Now.ToString & Chr(34))
                    If Left(LCase(splt(i)), 23) = "lstatus.newstatuswindow" Then

                        If Right(splt(i), 2) = "()" Then
                            lStatus.Create(lIRC, lServers)
                        Else
                            msg = ParseData(splt(i), "(", ")")
                            splt2 = Split(msg, ", ")
                            MsgBox(UBound(splt2))
                            If UBound(splt2) = 1 Then

                            End If
                            MsgBox(msg)

                        End If
                    End If
                    If InStr(splt(i), " = ") <> 0 Then
                        splt2 = Split(splt(i), " = ")
                        If InStr(splt2(1), " + ") <> 0 Or InStr(splt2(1), " - ") <> 0 Or InStr(splt2(1), "*") <> 0 Then
                            If InStr(splt2(1), " + ") <> 0 Then
                                m = eMathFunction.mAdd
                                splt3 = Split(splt2(1), " + ")
                            ElseIf InStr(splt2(1), " - ") <> 0 Then
                                m = eMathFunction.mSubtract
                                splt3 = Split(splt2(1), " - ")
                            Else
                                splt3 = Nothing
                                m = eMathFunction.mNotFound
                            End If
                            n = FindSubParamIndex(lIndex, Trim(splt2(0)))
                            If n <> 0 Then
                                s = eStorageType.sSubParam
                            Else
                                n = FindVariableIndex(lIndex, splt2(0))
                                If n <> 0 Then
                                    s = eStorageType.sVariable
                                Else
                                    s = eStorageType.sNotFound
                                End If
                            End If
                            splt3(0) = Trim(splt3(0))
                            splt3(1) = Trim(splt3(1))
                            If IsNumeric(splt3(0)) = True And IsNumeric(splt3(1)) = True Then
                                t = CInt(splt3(0)) + CInt(splt3(1))
                                If s = eStorageType.sSubParam Then
                                    SetSubParamValue(lIndex, n, Trim(t.ToString))
                                ElseIf s = eStorageType.sVariable Then
                                    lVariables.vVariable(n).vData = Trim(t.ToString)
                                End If
                            ElseIf IsNumeric(splt3(0)) = True And IsNumeric(splt3(1)) = False Then
                                e = FindSubParamIndex(lIndex, splt3(1))
                                If e = 0 Then
                                    e = FindVariableIndex(lIndex, splt3(1))
                                    If e <> 0 Then
                                        s2 = eStorageType.sVariable
                                    Else
                                        s2 = eStorageType.sNotFound
                                    End If
                                Else
                                    s2 = eStorageType.sSubParam
                                End If
                                If s = eStorageType.sSubParam Then
                                    If s2 = eStorageType.sSubParam Then
                                        If m = eMathFunction.mAdd Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(ReturnSubParamValue(lIndex, e)) + CInt(Trim(splt3(0)))))
                                        ElseIf m = eMathFunction.mSubtract Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(ReturnSubParamValue(lIndex, e)) - CInt(Trim(splt3(0)))))
                                        ElseIf m = eMathFunction.mMultiply Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(ReturnSubParamValue(lIndex, e)) * CInt(Trim(splt3(0)))))
                                        End If
                                    ElseIf s2 = eStorageType.sVariable Then
                                        If m = eMathFunction.mAdd Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(lVariables.vVariable(e).vData) + CInt(Trim(splt3(0)))))
                                        ElseIf m = eMathFunction.mSubtract Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(lVariables.vVariable(e).vData) - CInt(Trim(splt3(0)))))
                                        ElseIf m = eMathFunction.mMultiply Then
                                            SetSubParamValue(lIndex, n, CStr(CInt(lVariables.vVariable(e).vData) * CInt(Trim(splt3(0)))))
                                        End If
                                    End If
                                ElseIf s = eStorageType.sVariable Then
                                    If s2 = eStorageType.sSubParam Then
                                        If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                        If m = eMathFunction.mAdd Then
                                            lVariables.vVariable(n).vData = CStr(CInt(ReturnSubParamValue(lIndex, e)) + CInt(Trim(splt3(0))))
                                        ElseIf m = eMathFunction.mSubtract Then
                                            lVariables.vVariable(n).vData = CStr(CInt(ReturnSubParamValue(lIndex, e)) - CInt(Trim(splt3(0))))
                                        ElseIf m = eMathFunction.mMultiply Then
                                            lVariables.vVariable(n).vData = CStr(CInt(ReturnSubParamValue(lIndex, e)) * CInt(Trim(splt3(0))))
                                        End If
                                    ElseIf s2 = eStorageType.sVariable Then
                                        If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                        If m = eMathFunction.mAdd Then
                                            lVariables.vVariable(n).vData = CStr(CInt(lVariables.vVariable(e).vData) + CInt(Trim(splt3(0))))
                                        ElseIf m = eMathFunction.mSubtract Then
                                            lVariables.vVariable(n).vData = CStr(CInt(lVariables.vVariable(e).vData) - CInt(Trim(splt3(0))))
                                        ElseIf m = eMathFunction.mMultiply Then
                                            lVariables.vVariable(n).vData = CStr(CInt(lVariables.vVariable(e).vData) * CInt(Trim(splt3(0))))
                                        End If
                                    End If
                                End If
                            ElseIf IsNumeric(splt3(0)) = False And IsNumeric(splt3(1)) = True Then
                                e = FindSubParamIndex(lIndex, splt3(0))
                                If e = 0 Then
                                    e = FindVariableIndex(lIndex, splt3(0))
                                    If e <> 0 Then
                                        s2 = eStorageType.sVariable
                                    Else
                                        s2 = eStorageType.sNotFound
                                    End If
                                Else
                                    s2 = eStorageType.sSubParam
                                End If
                                If s = eStorageType.sSubParam Then
                                    If s2 = eStorageType.sSubParam Then
                                        SetSubParamValue(lIndex, n, CStr(CInt(ReturnSubParamValue(lIndex, e)) + CInt(Trim(splt3(1)))))
                                    ElseIf s2 = eStorageType.sVariable Then
                                        SetSubParamValue(lIndex, n, CStr(CInt(lVariables.vVariable(e).vData) + CInt(Trim(splt3(1)))))
                                    End If
                                ElseIf s = eStorageType.sVariable Then
                                    If s2 = eStorageType.sSubParam Then
                                        If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                        lVariables.vVariable(n).vData = CStr(CInt(ReturnSubParamValue(lIndex, e)) + CInt(Trim(splt3(1))))
                                        l = True
                                    ElseIf s2 = eStorageType.sVariable Then
                                        If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                        lVariables.vVariable(n).vData = CStr(CInt(lVariables.vVariable(e).vData) + CInt(Trim(splt3(1))))
                                        l = True
                                        'MsgBox("lVariables.vVariable(n).vData: " & lVariables.vVariable(n).vData)
                                        'MsgBox("lVariables.vVariable(n).vName: " & lVariables.vVariable(n).vName)
                                    End If
                                End If
                            ElseIf IsNumeric(splt3(0)) = False And IsNumeric(splt3(1)) = False Then
                                e = FindSubParamIndex(lIndex, splt3(0))
                                If e <> 0 Then
                                    s2 = eStorageType.sSubParam
                                Else
                                    e = FindVariableIndex(lIndex, splt3(0))
                                    s2 = eStorageType.sVariable
                                End If
                                e2 = FindSubParamIndex(lIndex, splt3(1))
                                If e2 <> 0 Then
                                    s3 = eStorageType.sSubParam
                                Else
                                    e2 = FindVariableIndex(lIndex, splt3(1))
                                    If e2 <> 0 Then
                                        s3 = eStorageType.sVariable
                                    End If
                                End If
                                If s = eStorageType.sSubParam Then
                                    If s2 = eStorageType.sVariable Then
                                        If s3 = eStorageType.sVariable Then
                                            If m = eMathFunction.mAdd Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnVariableValue(e))) + CInt(Trim(ReturnVariableValue(e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnVariableValue(e))) - CInt(Trim(ReturnVariableValue(e2)))))
                                            End If
                                            l = True
                                        ElseIf s3 = eStorageType.sSubParam Then
                                            If m = eMathFunction.mAdd Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnVariableValue(e))) + CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnVariableValue(e))) - CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            End If
                                            l = True
                                        End If
                                    ElseIf s2 = eStorageType.sSubParam Then
                                        If s3 = eStorageType.sVariable Then
                                            If m = eMathFunction.mAdd Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) + CInt(Trim(ReturnVariableValue(e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) - CInt(Trim(ReturnVariableValue(e2)))))
                                            End If
                                            l = True
                                        ElseIf s3 = eStorageType.sSubParam Then
                                            If m = eMathFunction.mAdd Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) + CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetSubParamValue(lIndex, n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) - CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            End If
                                            l = True
                                        End If
                                    End If
                                ElseIf s = eStorageType.sVariable Then
                                    If s2 = eStorageType.sVariable Then
                                        If s3 = eStorageType.sVariable Then
                                            If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                            If m = eMathFunction.mAdd Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnVariableValue(e))) + CInt(Trim(ReturnVariableValue(e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnVariableValue(e))) - CInt(Trim(ReturnVariableValue(e2)))))
                                            End If
                                            l = True
                                        ElseIf s3 = eStorageType.sSubParam Then
                                            If Len(lVariables.vVariable(e).vData) = 0 Then lVariables.vVariable(e).vData = "0"
                                            If m = eMathFunction.mAdd Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnVariableValue(e))) + CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnVariableValue(e))) - CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            End If
                                            l = True
                                        End If
                                    ElseIf s2 = eStorageType.sSubParam Then
                                        If s3 = eStorageType.sVariable Then
                                            If m = eMathFunction.mAdd Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) + CInt(Trim(ReturnVariableValue(e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) - CInt(Trim(ReturnVariableValue(e2)))))
                                            End If

                                            l = True
                                        ElseIf s3 = eStorageType.sSubParam Then
                                            If m = eMathFunction.mAdd Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) + CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            ElseIf m = eMathFunction.mSubtract Then
                                                SetVariableValue(n, CStr(CInt(Trim(ReturnSubParamValue(lIndex, e))) - CInt(Trim(ReturnSubParamValue(lIndex, e2)))))
                                            End If
                                            l = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        If l = False Then
                            b = False
                            Do Until b = True
                                If Not InStr(splt2(1), "(") <> 0 And Not InStr(splt2(1), ")") <> 0 Then
                                    b = True
                                Else
                                    splt2(1) = ReplaceText(lIndex, splt2(1))
                                End If
                            Loop
                            b = False
                            n = FindSubParamIndex(lIndex, Trim(splt2(0)))
                            If n <> 0 Then
                                SetSubParamValue(lIndex, n, Trim(splt2(1)))
                                o = True
                            Else
                                n = FindVariableIndex(lIndex, Trim(splt2(0)))
                                If n <> 0 Then lVariables.vVariable(n).vData = Replace(Trim(splt2(1)), Chr(34), "")
                                o = True
                            End If
                        End If
                        l = False
                    End If
                    If Left(LCase(splt(i)), 4) = "dim " And InStr(LCase(splt(i)), " as ") <> 0 Then
                        splt2 = Split(Replace(splt(i), "Dim ", ""), " As ")
                        If LCase(Trim(splt2(1))) = "string" Then
                            AddVariable(splt2(0), eDataTypes.dString, "", lSubs.sSub(lIndex).sName)
                            o = True
                        ElseIf LCase(Trim(splt2(1))) = "integer" Then
                            AddVariable(splt2(0), eDataTypes.dInteger, "", lSubs.sSub(lIndex).sName)
                            o = True
                        End If
                    End If
                    If InStr(LCase(splt(i)), "msgbox(") <> 0 Then
                        a = eActions.aMsgBox
                        o = True
                        msg = Right(splt(i), Len(splt(i)) - 7)
                        msg = Left(msg, Len(msg) - 1)
                    End If
                    If InStr(splt(i), "activestatustext(") <> 0 Then
                        o = True
                        msg = Right(splt(i), Len(splt(i)) - 17)
                        msg = Left(msg, Len(msg) - 1)
                    End If
                    If o = True Then
                        If Left(msg, 1) = Chr(34) And Right(msg, 1) = Chr(34) And Not InStr(msg, " & ") <> 0 Then
                            msg = TrimEnds(msg)
                            DoCodeHelper(lIndex, a, msg)
                        Else
                            b = False
                            Do Until b = True
                                If Not InStr(msg, "(") <> 0 And Not InStr(msg, ")") <> 0 Then
                                    b = True
                                Else
                                    msg = ReplaceText(lIndex, msg)
                                End If
                            Loop
                            b = False
                            If Not InStr(msg, " & ") <> 0 And Not InStr(msg, Chr(34)) <> 0 Then
                                n = FindSubParamIndex(lIndex, msg)
                                If n <> 0 Then
                                    DoCodeHelper(lIndex, a, Replace(ReturnSubParamValue(lIndex, n), Chr(34), ""))
                                Else
                                    n = FindVariableIndex(lIndex, msg)
                                    If n <> 0 Then DoCodeHelper(lIndex, a, lVariables.vVariable(n).vData)
                                End If
                            Else
                                msg = ReturnCodedString(lIndex, msg)
                                DoCodeHelper(lIndex, a, msg)
                            End If
                        End If
                    Else
                        If InStr(splt(i), "(") <> 0 And InStr(splt(i), ")") <> 0 Then
                            msg = Trim(Left(splt(i), 1) & ParseData(splt(i), Left(splt(i), 1), "("))
                            t = FindSubIndex(msg)
                            If t <> 0 Then
                                msg2 = ParseData(splt(i), "(", ")")
                                If Not InStr(msg2, ", ") <> 0 Then
                                    If Left(msg2, 1) = Chr(34) And Right(msg2, 1) = Chr(34) Then
                                        lSubs.sSub(t).sParamValue(1) = msg2
                                    Else
                                        e = FindSubParamIndex(lIndex, msg2)
                                        If e <> 0 Then
                                            lSubs.sSub(t).sParamValue(1) = ReturnSubParamValue(lIndex, e)
                                        Else
                                            e = FindVariableIndex(lIndex, msg2)
                                            If e <> 0 Then
                                                lSubs.sSub(t).sParamValue(1) = lVariables.vVariable(e).vData
                                            End If
                                        End If
                                    End If
                                Else
                                    splt2 = Split(msg2, ", ")
                                    For e = 0 To UBound(splt2)
                                        lSubs.sSub(t).sParamValue(e + 1) = splt2(e)
                                    Next e
                                End If
                                Dim lDoCode As New IntegerDelegate(AddressOf DoCode)
                                mdiMain.Invoke(lDoCode, t)
                            End If
                        End If
                    End If
                End If
            End If
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoCode(ByVal lCode As String)")
        'End Try
    End Sub

    Public Sub DoCodeByName(ByVal lName As String)
        'Try
        DoCode(FindSubIndex(lName))
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoCodeByName(ByVal lName As String)")
        'End Try
    End Sub

    Private Function ReturnCodedString(ByVal lSubIndex As Integer, ByVal lData As String) As String
        'Try
        Dim splt() As String, i As Integer, n As Integer
        If Len(lData) <> 0 Then
            If InStr(lData, " & ") <> 0 Then
                splt = Split(lData, " & ")
                For i = 0 To UBound(splt)
                    n = FindVariableIndex(lSubIndex, splt(i))
                    If n <> 0 Then
                        lData = Replace(lData, splt(i), lVariables.vVariable(n).vData)
                    Else
                        n = FindSubParamIndex(lSubIndex, splt(i))
                        If n <> 0 Then
                            lData = Replace(lData, splt(i), Replace(lSubs.sSub(lSubIndex).sParamValue(n), Chr(34), ""))
                        Else
                            If InStr(splt(i), Chr(34)) <> 0 Then
                                splt(i) = Replace(splt(i), Chr(34), "")
                                lData = Replace(lData, Chr(34) & splt(i) & Chr(34), splt(i))
                            End If
                        End If
                    End If
                Next i
                lData = Replace(lData, " & ", "")
            Else
                If InStr(lData, Chr(34)) <> 0 Then
                    lData = Replace(lData, Chr(34), "")
                Else
                End If
            End If
            Return lData
        Else
            Return ""
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function ReturnCodedString(ByVal lData As String) As String")
        'Return Nothing
        'End Try
    End Function

    Public Sub New()
        'Try
        ReDim lSubs.sSub(lArraySizes.aSub)
        ReDim lVariables.vVariable(lArraySizes.aSub)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub New()")
        'End Try
    End Sub
End Class