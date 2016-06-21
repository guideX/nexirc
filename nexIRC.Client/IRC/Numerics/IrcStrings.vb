'05-30-2016 - guideX
Option Explicit On
'Option Strict On
Imports nexIRC.Modules
Imports nexIRC.Enum

Public Class IrcStrings
    Private Const lColorChar As String = ""
    Private lBackgroundColor As Integer

    Public Sub ProcessReplaceCommand(ByVal lStatusIndex As Integer, ByVal lType As CommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "")
        Dim commandData = lCommandController.ReadReplacedCommand(lType, p1, p2, p3, p4)
        If commandData.SocketData.Length <> 0 And commandData.DoColorData.Length <> 0 Then
            lStatus.SendSocket(lStatusIndex, commandData.SocketData) ' FUCK
            lStatus.AddText(commandData.DoColorData, lStatusIndex) ' FUCK
        End If
    End Sub

    Public Sub ProcessReplaceString(ByVal statusIndex As Integer, ByVal type As IrcNumeric, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "")
        Dim msg As String
        If lSettings.lIRC.iSettings.sNoIRCMessages = True Then Exit Sub
        msg = lStringsController.ReadReplacedString(type, r1, r2, r3, r4, r5, r6, r7, r8)
        Dim fs = lStringsController.Find(type)
        If (lCompatibilityController.IsCompatible(type, fs)) Then
            If (Not String.IsNullOrEmpty(msg)) Then
                lStatus.AddText(msg, statusIndex) ' FUCK
            End If
        Else
            lStatus.AddToUnsupported(statusIndex, msg) ' FUCK
        End If
    End Sub

    Public Function DecodeLongIPAddr(ByVal ipAddr As String) As String
        Dim n As Integer, n2 As Integer
        Dim n3 As Integer, n4 As Integer, n5 As Integer, i As Integer, n6 As String
        n = Convert.ToInt32(ipAddr / 65536)
        n2 = ipAddr - n * 65536
        n3 = Convert.ToInt32(n / 256)
        n4 = n - n3 * 256
        n5 = Convert.ToInt32(n2 / 256)
        i = n2 - n5 * 256
        n6 = n3.ToString() & "."
        n6 = n6 & n4.ToString() & "."
        n6 = n6 & n5.ToString() & "."
        n6 = n6 & i.ToString()
        Return n6
    End Function

    Public Function EncodeIPAddr(ByVal data As String) As String
        Dim msg As String, msg2 As String, msg3 As String, msg4 As Integer, msg5 As String, i As Integer, msg6 As String
        msg4 = 1
        msg = ""
        Do
            msg2 = InStr(msg4, data & ".", ".")
            msg3 = Hex(Val(Mid$(data & ".", msg4, msg2 - msg4)))
            msg = msg & IIf(Len(msg3) = 1, "0" & msg3, msg3)
            msg4 = msg2 + 1
        Loop Until msg4 >= Len(data & ".")
        msg5 = Val("&H" & Mid(msg, 1, 2)) * 256.0! + Val("&H" & Mid(msg, 3, 2))
        i = Val("&H" & Mid(msg, 5, 2)) * 256.0! + Val("&H" & Mid(msg, 7, 2))
        msg6 = Str(msg5 * 65536 + i)
        Return Trim$(msg6)
    End Function

    Public Function GetRnd(ByVal _start As Integer, ByVal _end As Integer) As Long
        Dim i As Long
        Randomize()
        i = _start + Convert.ToInt32(Rnd() * (_end - _start))
        Return i
    End Function

    Public Function DoRight(ByVal lData As String, ByVal lLength As Integer) As String
        DoRight = Right(lData, lLength).ToString
    End Function

    Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer) As String
        DoLeft = Left(lData, lLength).ToString
    End Function

    Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String
        If Len(lString) <> 0 Then
            LeftRight = lString.Substring(lLeft, lDistance)
        Else
            LeftRight = ""
        End If
    End Function

    Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String) As String
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
    End Function
End Class