Option Explicit On
Option Strict On
Public Class IrcPermissions
    Private _v As Boolean 'Enables use of the voice/devoice commands.
    Private _vUpper As Boolean 'Enables automatic voice.
    Private _o As Boolean 'Enables use of the op/deop commands.
    Private _oUpper As Boolean 'Enables automatic op.
    Private _s As Boolean 'Enables use of the set command.
    Private _i As Boolean 'Enables use of the invite and getkey commands.
    Private _r As Boolean 'Enables use of the kick, ban, and kickban commands.
    Private _f As Boolean 'Enables modification of channel access lists.
    Private _t As Boolean 'Enables use of the topic and topicappend commands.
    Private _aUpper As Boolean 'Enables viewing of channel access lists.
    Private _fUpper As Boolean 'Grants full founder access.
    Private _b As Boolean 'Enables automatic kickban.
    Private _star As Boolean 'The special permission +* adds all permissions except +b and +F.
    Private _starMinus As Boolean 'The special permission -* removes all permissions including +b and +F.
    '/msg ChanServ FLAGS #foo 
    '/msg ChanServ FLAGS #foo foo!*@bar.com VOP 
    '/msg ChanServ FLAGS #foo foo!*@bar.com -V+oO 
    '/msg ChanServ FLAGS #foo foo!*@bar.com -* 
    '/msg ChanServ FLAGS #foo foo +oOtsi 
    '/msg ChanServ FLAGS #foo TroubleUser!*@*.troubleisp.net +b 
End Class