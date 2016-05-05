'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            Try
                'If (e.IsNetworkAvailable And Not lIRC.iSettings.sNetworkAvailability) Then
                'Do the things you couldn't do when the network was unavailable
                'End If
                lSettings.lIRC.iSettings.sNetworkAvailability = e.IsNetworkAvailable
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown
            'Do the shutdown things
        End Sub

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            'Do the startup things
        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Try
                e.BringToForeground = True
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Try
                'Dim mbox As MsgBoxResult
                'If (lSettings.lIRC.iSettings.sPrompts) Then
                'mbox = MsgBox("nexIRC encountered an unhandled exception." & Environment.NewLine & "Description: " & e.Exception.Message & Environment.NewLine & e.Exception.InnerException.ToString() & "Would you like to shutdown nexIRC?", MsgBoxStyle.YesNo)
                'If mbox = MsgBoxResult.Yes Then
                'e.ExitApplication = True
                'Else
                'e.ExitApplication = False
                'End If
                'Else
                'e.ExitApplication = False
                'End If
            Catch ex As Exception
                Throw
            End Try
        End Sub
    End Class
End Namespace