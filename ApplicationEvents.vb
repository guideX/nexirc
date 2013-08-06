'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            'Try
            If (e.IsNetworkAvailable And Not lIRC.iSettings.sNetworkAvailability) Then
                'Do the things you couldn't do when the network was unavailable
            End If
            lIRC.iSettings.sNetworkAvailability = e.IsNetworkAvailable
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged")
            'End Try
        End Sub
        Private Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown
            'Do the shutdown things
        End Sub
        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'Do the startup things
        End Sub
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            'Try
            e.BringToForeground = True
            'Catch ex As Exception
            'ProcessError(ex.Message, "Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance")
            'End Try
        End Sub
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            'Try
            Dim mbox As MsgBoxResult
            If (lIRC.iSettings.sPrompts) Then
                mbox = MsgBox("nexIRC encountered an unhandled exception." & vbCrLf & "Description: " & e.Exception.Message & vbCrLf & e.Exception.InnerException.ToString() & "Would you like to shutdown nexIRC?", MsgBoxStyle.YesNo)
                If mbox = MsgBoxResult.Yes Then
                    e.ExitApplication = True
                Else
                    e.ExitApplication = False
                End If
            End If
            'Catch ex As Exception
            'End Try
        End Sub
    End Class
End Namespace