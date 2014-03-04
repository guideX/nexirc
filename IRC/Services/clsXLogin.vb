'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class clsXLoginUI
    Private lStatusIndex As Integer
    Public lForm As New Form
    Public lUsernameTextBox As TextBox
    Public lPasswordTextBox As TextBox
    Public lEnableCheckBox As CheckBox
    Public lLoginOnConnect As CheckBox
    Public lShowOnConnect As CheckBox
    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        lStatusIndex = lIndex
    End Sub
    Public Sub frmXLogin_Load()
        Try
            lForm.Icon = mdiMain.Icon
            lUsernameTextBox.Text = lSettings_Services.lX.xLoginNickName
            lPasswordTextBox.Text = lSettings_Services.lX.xLoginPassword
            lEnableCheckBox.Checked = lSettings_Services.lX.xEnable
            lLoginOnConnect.Checked = lSettings_Services.lX.xLoginOnConnect
            lShowOnConnect.Checked = lSettings_Services.lX.xShowOnConnect
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub frmXLogin_Load()")
        End Try
    End Sub
    Public Sub cmdLogin_Click()
        Try
            lSettings_Services.lX.xEnable = Convert.ToBoolean(lEnableCheckBox.Checked)
            lSettings_Services.lX.xLoginNickName = lUsernameTextBox.Text
            lSettings_Services.lX.xLoginPassword = lPasswordTextBox.Text
            lSettings_Services.lX.xShowOnConnect = Convert.ToBoolean(lShowOnConnect.Checked)
            lSettings_Services.lX.xLoginOnConnect = Convert.ToBoolean(lLoginOnConnect.Checked)
            lSettings_Services.SaveServices()
            lStatus.PrivateMessage_User(lStatusIndex, lSettings_Services.lX.xLongName, "LOGIN " & lSettings_Services.lX.xLoginNickName & " " & lSettings_Services.lX.xLoginPassword)
            lForm.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Public Sub lblCreateAnAccount_Click()
    '(lSettings_Services.lX.xCreateAnAccountURL)
    'End Sub
    Public Sub cmdCancel_Click()
        Try
            lForm.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
