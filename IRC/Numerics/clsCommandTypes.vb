Option Explicit On
Option Strict On
Public Class clsCommandTypes
    Public Enum eCommandTypes
        cCUSTOM = 0
        '  NOT YET IMPLEMENTED.
        '  THIS SPOT IS RESERVED FOR SUPPORT FOR CUSTOM USER COMMAND TYPE TO BE 
        '  WRITTEN. DO NOT USE FOR SOMETHING ELSE
        cWHOWAS = 1
        '  If someone just left IRC or changed their nick, and you didn’t get their address, the server 
        '  keeps a buffer with the nicks that disappeared the last seconds. Count is how many nicks it 
        '  should return. Every matching nick if not supplied. No wildcards are allowed so the count 
        '  were only usefull in special cases
        '  SYNTAX:                      WHOWAS :<USER>
        cWHOIS = 2
        '  Basic information about a nick. A central command in IRC. Notice that the channels in the whois 
        '  reply are sorted with the channel the nick joined first as the rightmost. The full internet-address 
        '  for the user is shown in the whois. Some nets hide the first part of the address, as an attempt to 
        '  combat attacks which involve the users' address, e.g portscanning and pinging. Then only IRC-operators 
        '  may see the full address. (something like this is in the making on Undernet) Others will send an 
        '  Ident request to verify the username.
        '  SYNTAX:                      WHOIS :<NICK1>,<NICK2>, ...
        cWHO = 3
        '  WHO will let you count people away in your channel and how many servers away they are, with 
        '  a single command to the server. Searching and filtering are also more customizable than before, 
        '  but still keeping backward compatibility.
        '  SYNTAX:                      WHO :<MASK1> [<OPTIONS> [:<MASK2>]]
        cWALLOPS = 4
        '  The WALLOPS command is used to send a broadcast message to all operators across the 
        '  network. Wallops were originally publically visible and intended to be used 
        '  for disaster announcements and the like, but have been abused to the point 
        '  where now they are operator only.
        '  SYNTAX:                      WALLOPS :<MESSAGE TEXT>
        cVERSION = 5
        '  Returns the version of the serversoftware running. Use /version servername for remote 
        '  queries. It can include wildcards, but returns only first matching. Makes for a shorter 
        '  command. E.g /version london*.
        '  SYNTAX:                      VERSION :<SERVER NAME*>
        'cUSERS = 6 (NOT ENOUGH INFORMATION)
        cUSERHOST = 7
        '  Returns a nicks hostaddress or IP and if it's away or not.
        '  SYNTAX:                      USERHOST :<USER> <USER> ...
        'cUSER = 8
        'cUNKLINE = 9
        'cUMODE = 10
        'cTSDELTA = 11
        cTRACE = 12
        '  TRACE is used to look at the path between you and another nick.
        '  SYNTAX:                      TRACE :<NICK>
        cTOPIC = 13
        '  Returns the topic of a channel
        '  SYNTAX:                      TOPIC :<CHANNEL>
        cTIME = 14
        '  Shows the time, according to the servers' clock, and hours away from GMT
        '  SYNTAX:                      TIME :<SERVER NAME>
        'cTESTLINE = 15 (NOT ENOUGH INFORMATION)
        'cSVSLOGIN = 16 (NOT ENOUGH INFORMATION)
        'cSVINFO = 17 (NOT ENOUGH INFORMATION)
        'cSTOPIC = 18 (NOT ENOUGH INFORMATION)
        'cSTATSERV = 19 (NOT ENOUGH INFORMATION)
        cSTATS = 20
        '  The STATS command returns server information. These tend to vary by server version, and are 
        '  sometimes case sensitive. Here are a few that I know or use regularly
        '  or user.
        '  SYNTAX:                      STATS :<LETTER>
        '    ?  Server connection statistics
        '    b  B-lines
        '    c  C/N-lines
        '    d  D-lines
        '    e  E-lines
        '    h  H/L-lines
        '    i  I-lines
        '    k  K-lines
        '    l  Data transfer statistics by connection
        '    The numeric fields are as follows:
        '      sendQ (outgoing message queue)
        '      sendM (protocol messages sent)
        '      sendK (total kilobytes sent)
        '      receiveM (protocol messages received)
        '      receiveK (total kilobytes received)
        '      time in seconds since the connection was created
        '    L  Same as STATS l, except shows IP address instead of host
        '    m  Command statistics
        '    o  O/o-lines
        '    p  Current opers online
        '    t  General server statistics
        '    u  Server uptime
        '    v  Server link information
        '    y  Y-lines
        '    z  More server statistics
        '  If you are not currently an oper, I don't recommend going through and testing these all at once. 
        '  Multiple STATS requests are usually viewed as a threat to the server (some people have been known 
        '  to flood a server with STATS requests to fill up the server's sendq and cause network splits).
        'cSS = 21
        cSQUIT = 22
        '  Disconnect server (requires operator priveleges)
        '  SYNTAX:                      SQUIT :<SERVER> :<REASON>
        'cSPINGTIME = 23
        'cSNICK = 24
        'cSJOIN = 25
        'cSILENCE = 26
        '  Undernet has implemented the /silence command. When it is used, the network won't send you the unwanted data.
        '  SYNTAX:                      SILENCE :<+/-><NICK>!<NAME>@<HOST>
        '  ALTERNATE SYNTAX:            SILENCE :<+/-><NICK>
        'cSIGNON = 27
        'cSETNAME = 28
        'cSETIDENT = 29
        'cSETHOST = 30
        'cSET = 31
        'cStatusIndex = 32
        'cSEENSERV = 33
        'cSCAN = 34
        'cRESTART = 35
        'cRESP = 36
        'cREMOVE = 37
        'cREHASH = 38
        '  The REHASH command simply tells the server to reload its configuration file. This must be done for changes 
        '  to ircd.conf to take effect.
        '  SYNTAX:                      REHASH
        cQUIT = 39
        '  Have the server log you off with an optional quit message
        '  SYNTAX:                      QUIT :<MESSAGE>
        cPRIVMSG = 40
        '  Send a private message
        '  SYNTAX:                      PRIVMSG <CHAN1>,<CHAN2>,<NICKNAME>.. :<MESSAGE>
        'cPONG = 41
        'cPING = 42
        'cPASS = 43
        cPART = 44
        'cOS = 45
        'cOPERWALL = 46
        'cOPERSERV = 47
        'cOPER = 48
        'cNS = 49
        cNOTICE = 50
        '  The reason for NOTICE according to RCF1459, is to define a way to send messages that 
        '  should never generate an automatic reply. The object is to avoid loops of responses between scripts/bots
        '  SYNTAX:                      NOTICE <NICKNAME OR CHANNEL> :<MESSAGE>
        'cNICKSERV = 51
        cNICK = 52
        '  Change your nickname
        '  SYNTAX: NICK :<NICKNAME>
        cNAMES = 53
        '  Retrieve list of nicknames from a channel
        '  SYNTAX: NAMES :<CHANNEL>
        'cMS = 54
        cMOTD = 55
        '  Retrieve the MOTD
        '  SYNTAX: MOTD
        'cMODE = 56
        'cMEMOSERV = 57
        'cMAP = 58
        'cMAKEPASS = 59
        'cLUSERS = 60
        'cLS = 61
        cLIST = 62
        'cLINKS = 63
        'cKNOCK = 64
        'cKLINE = 65
        'cKILL = 66
        'cKICK = 67
        'cJOIN = 68
        'cISON = 69
        'cINVITE = 70
        'cIDLE = 71
        'cHTM = 72
        'cHS = 73
        'cHELPSERV = 74
        'cHELP = 75
        'cHASH = 76
        'cGN = 77
        'cGLOBALNOTICE = 78
        'cERROR = 78
        'cDUMP = 79
        'cDNS = 80
        'cDLINE = 81
        'cDIE = 82
        'cCS = 83
        'cCONNECT = 84
        'cCOLLIDE = 85
        'cCLOSE = 86
        'cCHANSERV = 87
        'cCHALL = 88
        'cCAPAB = 89
        'cBURST = 90
        'cAWAY = 91
        cADMIN = 92
        cACTION = 93
        cAWAY = 94
        '  Set as away
        '  SYNTAX:                      AWAY <MESSAGE>
        cBACK = 95
        '  Back from being away
        '  SYNTAX:                      AWAY
    End Enum
End Class