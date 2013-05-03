'nexIRC 3.0.23
'02-27-2013 - guideX

Option Explicit On
Option Strict On

Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
    'Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
        'Try
        'lStatus.lIRCMisc.SetNetworkAvailable(e.IsNetworkAvailable)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged")
        'End Try
        'End Sub

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
            mbox = MsgBox("nexIRC encountered an unhandled exception." & vbCrLf & "Description: " & e.Exception.Message & vbCrLf & "Would you like to shutdown nexIRC?", MsgBoxStyle.YesNo)
            If mbox = MsgBoxResult.Yes Then
                e.ExitApplication = True
            Else
                e.ExitApplication = False
            End If
            'Catch ex As Exception
            'End Try
        End Sub
    End Class
End Namespace