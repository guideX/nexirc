'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On

Imports System.Runtime.InteropServices

'Option Strict On

Module mdlStrings
    Enum eCommandTypes
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

    Enum eStringTypes
        'sDUMMY = -100
        sCHANNEL_LIST_WAIT = -43
        ' TELL YOU TO WAIT DURING A CHANNEL LIST
        sNICKSERV_LOGIN = -42
        ' WHEN YOU SUCCESSFULLY LOGIN TO NICKSERV
        sSENDING_LOGON_INFORMATION = -41
        ' WHEN THE IRC CLIENT SENDS LOGON INFORMATION
        sSENDING_NICKNAME = -40
        ' WHEN THE IRC CLIENT SENDS THE NICKNAME
        sSETTING_MODES = -39
        ' WHEN THE IRC CLIENT SETS MODES
        sNETWORK_UNAVAILABLE = -38
        ' WHEN THE INTERNET BECOMES UNAVAILABLE
        sNETWORK_AVAILABLE = -37
        ' WHEN THE INTERNET BECOMES AVAILABLE
        sDCC_DENIED = -36
        ' WHEN A DCC NEGOTIATION IS DENIED
        sCHANNEL_ACTION = -35
        ' WHEN A USER DOES A /ME <DATA>
        sNICK_CHANGE = -34
        ' WHEN SOMEONE CHANGES THEIR NICK
        sUSER_QUIT = -33
        '  WHEN ANOTHER USER QUITS
        sYOUR_QUIT_MESSAGE = -32
        '  THE MESSAGE SENT TO THE SERVER WHEN YOU QUIT
        sIDENT_ERROR = -31
        '  WHEN AN IDENT ERROR OCCURS
        sIDENT_DISCONNECTED = -30
        '  WHEN IDENT IS DISCONNECTED
        sIDENT_CONNECTED = -29
        '  WHEN IDENT IS CONNECTED
        sINTERNAL_ERROR = -28
        '  WHEN AN INTERNAL ERROR HAPPENS
        sATTEMPTING_CONNECTION = -27
        '  WHEN A USER TRYS TO CONNECT
        '  EXTENDED MESSAGES ONLY
        sNOT_SENDING_PASSWORD = -26
        '  WHEN A PASSWORD IS NOT SENT
        '  EXTENDED MESSAGES ONLY
        sSENDING_PASSWORD = -25
        '  WHEN A PASSWORD IS SENT
        '  EXTENDED MESSAGES ONLY
        sCONNECTION_ESTABLISHED = -24
        '  WHEN THE CONNECTION IS ESTABLISHED WITH THE SERVER
        '  EXTENDED MESSAGES ONLY
        sCONNECTION_DENIED = -23
        '  WHEN THE CONNECTION IS DENIED
        '  EXTENDED MESSAGES ONLY
        sCONNECTION_CLOSED = -22
        '  WHEN THE CONNECTION IS CLOSED THIS MESSAGE WILL BE DISPLAYED
        sTOO_SOON = -21
        '  WHEN ANTI CONNECT HAMMER IS ENABLED THIS MESSAGE WILL BE DISPLAYED
        '  EXTENDED MESSAGES ONLY
        sNAMES_DATA = -20
        '  ON JOIN CHANNEL SENDS NAME LIST
        sVERSION_REPLY = -19
        '  VERSION DATA TO BE SENT UPON A VERSION_REQUEST
        sVERSION_REQUEST = -18
        '  SERVER REQUESTS YOUR VERSION
        '  EXAMPLE:                  VERSION
        '  RESPONCE:                 VERSION <CLIENT NAME AND VERSION> <OPERATING SYSTEM AND VERSION> <AUTHOR NAME AND E-MAIL>
        sSOCKET_ERROR = -17
        '  THERE WAS A SOCKET ERROR
        sYOUPART = -16
        '  YOU PARTED A CHANNEL
        '  EXAMPLE:                  :guide_X!guidex@spoof-E1B203A6.static.mtpk.ca.charter.com PART :#test
        sUSER_PARTED = -15
        '  USER PARTED A CHANNEL
        '  EXAMPLE:                  :guide_X!guidex@spoof-E1B203A6.static.mtpk.ca.charter.com PART :#test
        sUSER_JOINED = -14
        '  USER JOINED A CHANNEL
        '  EXAMPLE:                  :guide_X!guidex@spoof-E1B203A6.static.mtpk.ca.charter.com JOIN :#test
        sNOTIFY_LIST_END = -13
        '  END OF A NOTIFY LIST
        sNOTIFY_LIST_BEGIN = -12
        '  BEGINNING OF NOTIFY LIST
        sCHANNEL_PART = -11
        '  YOU LEFT A CHANNEL
        '  IRC:                      
        sCHANNEL_TOPIC = -10
        '  YOU RECIEVE CHANNEL TOPIC
        '  EXAMPLE:                  :ChanServ!services@newnet.net TOPIC #test : (ChanServ)
        sUSER_MODE = -9
        '  YOU  RECIEVE USER MODE
        '  EXAMPLE:                  :ChanServ!services@newnet.net MODE #test -o guide_X
        sWHOIS_WAIT = -8
        '  WHOIS WAIT MESSAGE
        sWHOIS_END = -7
        '  WHOIS  COMMAND ENDS
        sWHOIS_START = -6
        '  WHOIS COMMAND BEGINS
        sLUSERS_END = -5
        '  LUSERS COMMAND ENDS
        sLUSERS_BEGIN = -4
        '  LUSERS COMMAND BEGINS
        sYOUJOIN = -3
        '  YOU JOIN A CHANNEL
        sNOTICE = -2
        '  YOU RECIEVED A NOTICE
        sPRIVMSG = -1
        '  YOU RECIEVED PRIVATE MESSAGE
        '  EXAMPLE:                  :<server> PRIVMSG <yournick> :<message>
        sCUSTOM = 0
        '  CUSTOM STRING
        '  NEXIRC SPECIFIC
        sRPL_WELCOME = 1
        '  The first message sent after client  . The text used varies widely
        '  The server sends Replies 001 to 004 to a user upon successful registration.
        '  RFC2812:                  :Welcome to the Internet Relay Network <nick>!<user>@<host>
        '  BAHAMUT:                  :%s 001 %s :Welcome to the DALnet IRC Network %s!%s@%s
        '  HYBRID:                   :%s 001 %s :Welcome to the Internet Relay Network %s
        '  UNREAL:                   :%s 001 %s :Welcome to the %s IRC Network %s!%s@%s
        '  IRC2:                     :Welcome to the Internet Relay Network %s
        '  IRCU:                     :Welcome to the Internet Relay Network%s%s, %s
        sRPL_YOURHOST = 2
        '  Part of the post-registration greeting. Text varies widely
        '  The server sends Replies 001 to 004 to a user upon successful registration.
        '  RFC2812:                  :Your host is <servername>, running version <version>
        '  BAHAMUT/HYBRID/UNREAL:    :%s 002 %s :Your host is %s, running version %s
        '  IRC2/IRCU:                :Your host is %s, running version %s
        sRPL_CREATED = 3
        '  Part of the post-registration greeting. Text varies widely
        '  The server sends Replies 001 to 004 to a user upon successful registration.
        '  RFC2812:                  :This server was created <date>
        '  BAHAMUT/HYBRID/UNREAL:    :%s 003 %s :This server was created %s
        '  IRC2/IRCU                 :This server was created %s
        sRPL_MYINFO = 4
        '  Part of the post-registration greeting
        '  RFC2812:                  <server_name> <version> <user_modes> <chan_modes>
        '  KINEIRCD:                 <server_name> <version> <user_modes> <chan_modes> <channel_modes_with_params> <user_modes_with_params> <server_modes> <server_modes_with_params>
        '  BAHAMUT:                  :%s 004 %s %s %s oOiwscrkKnfydaAbgheFxXj biklLmMnoprRstvc
        '  HYBRID:                   :%s 004 %s %s %s oOiwszcrkfydnxb biklmnopstve
        '  IRC2:                     %s %s aoOirw abeiIklmnoOpqrstv
        '  IRCU:                     %s %s dioswkgx biklmnopstvr bklov
        '  UNREAL:                   :%s 004 %s %s %s %s %s
        'sRPL_BOUNCE = 5 '(DEPRECIATED)
        '  Sent by the server to a user to suggest an alternative server, sometimes used when the connection is refused because the server is already full. Also known as RPL_SLINE (AUSTHEX), and RPL_REDIR Also see #010.
        '  RFC2812:                  :try server <server_name>, port <port_number>
        sRPL_ISUPPORT = 5 '(CONFLICTING)
        'IRCNET, BAHAMUT, IRCU:      :irc.example.org 005 nick PREFIX=(ov)@+ CHANTYPES=#& :are supported by this server
        '  PREFIX: A list of channel modes a person can get and the respective prefix a channel or nickname will get in case the person has it. The order of the modes goes from most powerful to least powerful. Those prefixes are shown in the output of the WHOIS, WHO and NAMES command.
        '    PREFIX=(ov)@+ (IRCNET, BAHAMUT, IRCU)
        '    PREFIX=(ohv)@%+ (HYBRID)
        '  CHANTYPES: The supported channel prefixes.
        '    CHANTYPES=#& (IRCU)
        '    CHANTYPES=#&!+ (IRCNET)
        '    CHANTYPES=# (BAHAMUT)
        '    CHANTYPES=#& (HYBRID)
        '  CHANMODES: This is a list of channel modes according to 4 types.
        '    A = Mode that adds or removes a nick or address to a list. Always has a parameter.
        '    B = Mode that changes a setting and always has a parameter.
        '    C = Mode that changes a setting and only has a parameter when set.
        '    D = Mode that changes a setting and never has a parameter.
        '    Note: Modes of type A return the list when there is no parameter present.
        '    Note: Some clients assumes that any mode not listed is of type D.
        '    Note: Modes in PREFIX are not listed but could be considered type B.
        '    CHANMODES=b,k,l,imnpstr (IRCU)
        '    CHANMODES=b,k,l,ciLmMnOprRst (BAHAMUT)
        '    CHANMODES=beI,k,l,imnpstaqr (IRCNET)
        '    CHANMODES=beI,k,l,imnpsta (HYBRID)
        '  MODES: Maximum number of channel modes with parameter allowed per MODE command.
        '    MODES=3 (IRCNET)
        '    MODES=4 (HYBRID)
        '    MODES=6 (IRCU, BAHAMUT)
        '  MAXCHANNELS: Maximum number of channels allowed to join. This has been replaced by CHANLIMIT.
        '    MAXCHANNELS=10 (IRCNET, HYBRID, BAHAMUT)
        '    MAXCHANNELS=20 (IRCU)
        '  CHANLIMIT: Maximum number of channels allowed to join by channel prefix.
        '    CHANLIMIT=#&!+:10 (IRCNET)
        '  NICKLEN: Maximum nickname length.
        '    NICKLEN=9 (IRCNET, IRCU, HYBRID)
        '    NICKLEN=30 (BAHAMUT)
        '  MAXBANS: Maximum number of bans per channel. Note: This has been replaced by MAXLIST. 
        '    MAXBANS=30 (IRCNET)
        '    MAXBANS=25 (HYBRID)
        '    MAXBANS=45 (IRCU)
        '    MAXBANS=100 (BAHAMUT)
        '  MAXLIST: Maximum number entries in the list per mode.
        '    MAXLIST=beI:30 (IRCNET)
        '  NETWORK: The IRC network name.
        '    NETWORK=EFnet (HYBRID)
        '    NETWORK=IRCNET (IRCNET)
        '    NETWORK=UnderNet (IRCU)
        '    NETWORK=DALnet (BAHAMUT)
        '  EXCEPTS: The server support ban exceptions (e mode).
        '    EXCEPTS=e
        '  INVEX: The server support invite exceptions (+I mode).
        '    INVEX=I
        '  WALLCHOPS: The server supports messaging channel operators (NOTICE @#channel)
        '    Note: This has been replaced by STATUSMSG.
        '    IRCU also supports a WALLCHOPS command?
        '    Note: IRCU didn't support voiced persons because it conflicted with +channels. They removed the +channels.
        '    Note: HYBRID supports everything in PREFIX
        '    Note: HYBRID 6 and IRCU don't support it with PRIVMSG, HYBRID 7 does. 
        '    WALLCHOPS
        '  WALLVOICES: Notice to +#channel goes to all voiced persons.
        '    WALLVOICES
        '  STATUSMSG: The server supports messaging channel member who have a certain status or higher. The status is one of the letters from PREFIX.
        '    STATUSMSG=+@
        '  CASEMAPPING: 
        '    Case mapping used for nick- and channel name comparing. Current possible values:
        '    ascii: The chars [a-z] are lowercase of [A-Z].
        '    rfc1459: ascii with additional {}|~ the lowercase of []\^.
        '    strict-rfc1459: ascii with additional {}| the lowercase of []\.
        '    Note: RFC1459 forgot to mention the ~ and ^ although in all known implementations those are considered equivalent too. 
        '    CASEMAPPING=rfc1459 (IRCU, HYBRID, IRCNET)
        '    CASEMAPPING=ascii (BAHAMUT)
        '  ELIST: The server supports extentions for the LIST command. The tokens specify which extention are supported.
        '    M = mask search,
        '    N = !mask search
        '    U = usercount search (< >)
        '    C = creation time search (C< C>)
        '    T = topic search (T< T>)
        '  TOPICLEN: Maximum topic length.
        '    TOPICLEN=80 (IRCNET)
        '    TOPICLEN=120 (HYBRID)
        '    TOPICLEN=160 (IRCU)
        '    TOPICLEN=307 (BAHAMUT)
        '  KICKLEN: Maximum kick comment length.
        '    KICKLEN=80 (IRCNET)
        '    KICKLEN=120 (HYBRID)
        '    KICKLEN=160 (IRCU)
        '    KICKLEN=307 (BAHAMUT)
        '  CHANNELLEN: Maximum channel name length.
        '    CHANNELLEN=50 (IRCNET)
        '  CHIDLEN: Channel ID length for !channels (5 by default). See  RFC 2811 for more information.
        '    Note: This has been replaced by IDCHAN 
        '    CHIDLEN=5
        '  IDCHAN: The ID length for channels with an ID. The prefix says for which channel type it is, and the number how long it is.
        '    IDCHAN=!:5
        '  STD: The standard which the implementation is using.
        '    STD=i-d(03)
        '  SILENCE: The server support the SILENCE command. The number is the maximum number of allowed entries in the list.
        '    SILENCE=15 (IRCU)
        '    SILENCE=10 (BAHAMUT)
        '  RFC2812: Server supports  RFC 2812 features.
        '    RFC2812 
        '  PENALTY: Server gives extra penalty to some commands instead of the normal 2 seconds per message and 1 second for every 120 bytes in a message.
        '    PENALTY
        '  FNC: Forced nick changes: The server may change the nickname without the client sending a NICK message.
        '    FNC
        '  SAFELIST: The LIST is sent in multiple iterations so send queue won't fill and kill the client connection.
        '    SAFELIST
        '  AWAYLEN: AWAYLEN=160 (IRCU)
        '    AWAYLEN
        '  NOQUIT: Isn't this server to server feature, nothing to do with clients?
        '    NOQUIT 
        '  USERIP: The USERIP command exists.
        '    USERIP
        '  CPRIVMSG: The CPRIVMSG command exists, used for mass messaging people in specified channel (CPRIVMSG channel nick,nick2,... :text)
        '    CPRIVMSG channel nick,nick2,... :text
        '  CNOTICE: The CNOTICE command exists, just like CPRIVMSG
        '    CNOTICE
        '  MAXNICKLEN: Maximum length of nicks the server will send to the client?
        '    MAXNICKLEN
        '  MAXTARGETS: Maximum targets allowed for PRIVMSG and NOTICE commands
        '    MAXTARGETS=4 (HYBRID)
        '  KNOCK: The KNOCK command exists.
        '    KNOCK
        '  VCHANS: Server supports virtual channels. See  vchans.txt for more information.
        '    VCHANS
        '  WATCH: Maximum number of WATCHes allowed.
        '    WATCH=128 (BAHAMUT)
        '  WHOX: The WHO command uses WHOX protocol.
        '    WHOX
        '  CALLERID: The server supports server side ignores via the +g user mode. See  modeg.txt for more information.
        '    CALLERID
        '  ACCEPT: [Deprecated] The same as CALLERID.
        '    ACCEPT
        '  LANGUAGE: [Experimental] The server supports the LANGUAGE command. See the language document for more information.
        '    LANGUAGE=2,en,i-klingon
        sRPL_MAP = 6 '(DEPRECIATED)
        '  UNREAL:                   :%s 006 %s :%s%-*s(%d) %s
        sRPL_MAPEND = 7 'UNREAL (DEPRECIATED)
        '  :%s 007 %s :End of /MAP
        sRPL_SNOMASK = 8 'IRCU, UNREAL
        '  Server notice mask (hex)
        '  IRCU:                     %d :: Server notice mask (%#x)
        '  UNREAL:                   :%s 008 %s :Server notice mask (%s)
        sRPL_STATMEMTOT = 9 'IRCU
        sRPL_BOUNCE_2 = 10
        '  Sent to the client to redirect it to another server. Also known as RPL_REDIR
        '  RFC2812:                  <hostname> <port> :<info>
        '  UNREAL:                   :%s 010 %s %s %d :Please use this Server/Port instead
        'sRPL_YOURCOOKIE = 14
        '  HYBRID
        'sRPL_MAP2 = 15 '(DEPRECIATED)
        '  IRCU
        'sRPL_MAPMORE = 16 '(DEPRECIATED)
        '  IRCU
        'sRPL_MAPEND = 17 '(DEPRECIATED)
        '  IRCU 
        sRPL_PLEASEWAIT = 20 '(SEEN ON IRCNET)
        '  IRCNET:                   :Please wait while we establish a connection
        'sRPL_YOURID = 42
        '  IRCNET
        'sRPL_SAVENICK = 43
        '  Sent to the client when their nickname was forced to change due to a collision
        '  IRCNET:                   :<info>
        'sRPL_ATTEMPTINGJUNC = 50
        '  AIRCD
        'sRPL_ATTEMPTINGREROUTE = 51 'AIRCD
        'sRPL_REMOTEPROTOCTL = 105
        '  UNREAL:                   :%s 105 %s
        sRPL_TRACELINK = 200
        '  RFC1459:                  Link <version & debug level> <destination> \ <next server>
        '  EXAMPLE:                  Link <version>[.<debug_level>] <destination> <next_server> [V<protocol_version> <link_uptime_in_seconds> <backstream_sendq> <upstream_sendq>]
        sRPL_TRACECONNECTING = 201
        '  The RPL_TRACE* are all returned by the server in response to the TRACE message. How many are returned is dependent on the TRACE message and whether it was sent by an operator or not. There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the 'server handshake'.
        '  RFC1459:                  Try. <class> <server>
        sRPL_TRACEHANDSHAKE = 202
        '  RFC1459:                  H.S. <class> <server>
        sRPL_TRACEUNKNOWN = 203
        '  RFC1459:                  ???? <class> [<connection_address>]
        sRPL_TRACEOPERATOR = 204
        '  RFC1459:                  Oper <class> <nick>
        sRPL_TRACEUSER = 205
        '  RFC1459:                  User <class> <nick>
        sRPL_TRACESERVER = 206
        '  RFC1459:                  Serv <class> <int>S <int>C <server> <nick!user|*!*>@<host|server> [V<protocol_version>]
        sRPL_TRACESERVICE = 207
        '  RFC2812:                  Service <class> <name> <type> <active_type>
        sRPL_TRACENEWTYPE = 208
        '  RFC1459:                  <newtype> 0 <client_name>
        sRPL_TRACECLASS = 209
        '  RFC2812:                  Class <class> <count>
        sRPL_TRACERECONNECT = 210 '(DEPRECIATED)
        '  RFC2812
        'sRPL_STATS = 210
        '  Used instead of having multiple stats numerics
        '  AIRCD
        sRPL_STATSLINKINFO = 211
        '  Reply to STATS
        '  RFC1459:                  <linkname> <sendq> <sent_msgs> <sent_bytes> <recvd_msgs> <rcvd_bytes> <time_open>
        sRPL_STATSCOMMANDS = 212
        '  Reply to STATS
        '  RFC1459:                  <command> <count> [<byte_count> <remote_count>]
        sRPL_STATSCLINE = 213 'RFC1459
        '  Reply to STATS
        '  RFC1459:                  C <host> * <name> <port> <class>
        sRPL_STATSNLINE = 214 '(DEPRECIATED)
        '  Reply to STATS, Also known as RPL_STATSOLDNLINE (IRCU, UNREAL)
        '  RFC1459:                  N <host> * <name> <port> <class>
        sRPL_STATSILINE = 215
        '  Reply to STATS
        '  RFC1459:                  I <host> * <host> <port> <class>
        sRPL_STATSKLINE = 216
        '  Reply to STATS
        '  RFC1459:                  K <host> * <username> <port> <class>
        'sRPL_STATSQLINE = 217 '(CONFLICTING)
        '  RFC1459
        'sRPL_STATSPLINE = 217 '(CONFLICTING)
        '  IRCU
        sRPL_STATSYLINE = 218
        '  End of RPL_STATS* list.
        '  RFC1459:                  <query> :<info>
        sRPL_ENDOFSTATS = 219
        '  End of RPL_STATS* list.
        '  RFC1459:                  <query> :<info>
        'sRPL_STATSPLINE = 220 '(CONFLICTING)
        '  HYBRID 
        'sRPL_STATSBLINE = 220 '(CONFLICTING)
        '  BAHAMUT, UNREAL
        sRPL_UMODEIS = 221
        '  Information about a user's own modes. Some daemons have extended the mode command and certain modes take parameters (like channel modes).
        '  RFC1459:                  <user_modes> [<user_mode_params>]
        'sRPL_MODLIST = 222 (CONFLICTING)
        'sRPL_SQLINE_NICK = 222 '(CONFLICTING)
        '  UNREAL
        'sRPL_STATSBLINE = 222 '(CONFLICTING)
        '  BAHAMUT
        'sRPL_STATSELINE = 223 '(CONFLICTING)
        '  BAHAMUT 
        'sRPL_STATSGLINE = 223 '(CONFLICTING)
        '  UNREAL
        'sRPL_STATSFLINE = 224 '(CONFLICTING)
        '  HYBRID, BAHAMUT
        'sRPL_STATSTLINE = 224 '(CONFLICTING)
        '  UNREAL 
        'sRPL_STATSDLINE = 225 '(CONFLICTING)
        '  HYBRID 
        'sRPL_STATSZLINE = 225 '(CONFLICTING)
        '  BAHAMUT 
        'sRPL_STATSELINE = 225 '(CONFLICTING)
        '  UNREAL 
        'sRPL_STATSCOUNT = 226 '(CONFLICTING)
        '  BAHAMUT 
        'sRPL_STATSNLINE = 226 '(CONFLICTING)
        '  UNREAL
        'sRPL_STATSGLINE = 227 '(CONFLICTING)
        '  BAHAMUT 
        'sRPL_STATSVLINE = 227 '(CONFLICTING)
        '  UNREAL
        'sRPL_STATSQLINE = 228 '(CONFLICTING)
        '  IRCU 
        'sRPL_SERVICEINFO = 231 '(DEPRECIATED)
        '  RFC1459 
        'sRPL_ENDOFSERVICES = 232 '(DEPRECIATED)
        '  RFC1459 
        'sRPL_RULES = 232 '(CONFLICTING)
        '  UNREAL
        'sRPL_SERVICE = 233 '(DEPRECIATED)
        '  RFC1459
        sRPL_SERVLIST = 234
        '  A service entry in the service list
        '  RFC2812:                  <name> <server> <mask> <type> <hopcount> <info>
        sRPL_SERVLISTEND = 235
        '  Termination of an RPL_SERVLIST list
        '  RFC2812:                  <mask> <type> :<info>
        'sRPL_STATSVERBOSE = 236
        '  Verbose server list?
        '  IRCU
        'sRPL_STATSENGINE = 237
        '  Engine name?
        '  IRCU
        'sRPL_STATSFLINE = 238 '(DEPRECIATED)
        '  Feature lines?
        '  IRCU  
        'sRPL_STATSIAUTH = 239
        '  IRCNET
        'sRPL_STATSVLINE = 240 '(CONFLICTING)
        '  RFC2812 
        'sRPL_STATSXLINE = 240 '(CONFLICTING)
        '  AUSTHEX 
        sRPL_STATSLLINE = 241
        '  Reply to STATS
        '  RFC1459:                  L <hostmask> * <servername> <maxdepth>
        sRPL_STATSUPTIME = 242
        '  Reply to STATS
        '  RFC1459:                  :Server Up <days> days <hours>:<minutes>:<seconds>
        sRPL_STATSOLINE = 243
        '  Reply to STATS. The info field is an extension found in some IRC daemons, which returns info such as an e-mail address or the name/job of an operator
        '  RFC1459:                  O <hostmask> * <nick> [:<info>]
        sRPL_STATSHLINE = 244
        '  Reply to STATS
        '  RFC1459:                  H <hostmask> * <servername>
        'sRPL_STATSSLINE = 245
        '  BAHAMUT, IRCNET, HYBRID
        'sRPL_STATSPING = 246 '(CONFLICTING)
        '  RFC2812 
        'sRPL_STATSULINE = 246 '(CONFLICTING)
        '  HYBRID 
        'sRPL_STATSBLINE = 247 '(CONFLICTING)
        '  RFC2812 
        'sRPL_STATSXLINE = 247 '(CONFLICTING)
        '  HYBRID, PTlink, UNREAL 
        'sRPL_STATSGLINE = 247 '(CONFLICTING)
        '  IRCU 
        'sRPL_STATSULINE = 248 '(CONFLICTING)
        '  IRCU
        'sRPL_STATSDEFINE = 248 '(CONFLICTING)
        '  IRCNET 
        'sRPL_STATSULINE = 249 (CONFLICTING)
        '  Extension to RFC1459?
        'sRPL_STATSDEBUG = 249 (CONFLICTING)
        'sRPL_STATSDLINE = 250 '(CONFLICTING)
        '  RFC2812 
        'sRPL_STATSCONN = 250 '(CONFLICTING)
        '  IRCU, UNREAL 
        sRPL_STATSCONN = 250
        '  250 :Highest connection count: <total> (<num> clients)
        '  ircu, Unreal
        sRPL_LUSERCLIENT = 251
        '  Reply to LUSERS command, other versions exist (eg. RFC2812); Text may vary.
        '  RFC1459:                  :There are <int> users and <int> invisible on <int> servers
        sRPL_LUSEROP = 252
        '  Reply to LUSERS command - Number of IRC operators online
        '  RFC1459:                  <int> :<info>
        sRPL_LUSERUNKNOWN = 253
        '  Reply to LUSERS command - Number of unknown/unregistered connections
        '  RFC1459:                  <int> :<info>
        sRPL_LUSERCHANNELS = 254
        '  Reply to LUSERS command - Number of channels formed
        '  RFC1459:                  <int> :<info>
        sRPL_LUSERME = 255
        '  Reply to LUSERS command - Information about local connections; Text may vary.
        '  RFC1459:                  :I have <int> clients and <int> servers
        sRPL_ADMINME = 256
        '  Start of an RPL_ADMIN* reply. In practise, the server parameter is often never given, and instead the info field contains the text 'Administrative info about <server>'. Newer daemons seem to follow the RFC and output the server's hostname in the 'server' parameter, but also output the server name in the text as per traditional daemons.
        '  RFC1459:                  <server> :<info>
        sRPL_ADMINLOC1 = 257
        '  Reply to ADMIN command (Location, first line)
        '  RFC1459:                  :<admin_location>
        sRPL_ADMINLOC2 = 258
        '  Reply to ADMIN command (Location, second line)
        '  RFC1459:                  :<admin_location>
        sRPL_ADMINEMAIL = 259
        '  When replying to an ADMIN message, a server is expected to use replies RPL_ADMINME through to RPL_ADMINEMAIL and provide a text message with each. For RPL_ADMINLOC1 a description of what city, state and country the server is in is expected, followed by details of the institution (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is REQUIRED) in RPL_ADMINEMAIL.
        '  RFC2812:                  :<admin info>
        sRPL_TRACELOG = 261
        '  RFC1459:                  File <logfile> <debug_level>
        sRPL_TRACEEND = 262
        '  Used to terminate a list of RPL_TRACE* replies
        '  RFC2812:                  <server_name> <version>[.<debug_level>] :<info>
        sRPL_TRYAGAIN = 263
        '  When a server drops a command without processing it, it MUST use this reply. Also known as RPL_LOAD_THROTTLED and RPL_LOAD2HI, I'm presuming they do the same thing.
        '  RFC2812:                  <command> :<info>
        sRPL_LOCALUSERS = 265
        '  UNREAL, BAHAMUT, HYBRID:  :%s 265 %s :Current local users: %d Max: %d
        sRPL_GLOBALUSERS = 266
        '  BAHAMUT, HYBRID, UNREAL:  :%s 266 %s :Current global users: %d Max: %d
        'sRPL_PRIVS = 270 
        '  IRCU:                     %s :
        'sRPL_SILELIST = 271
        '  BAHAMUT/UNREAL:           :%s 271 %s %s %s
        '  IRCU:                     %s %s
        'sRPL_ENDOFSILELIST = 272
        '  BAHAMUT:                  :%s 272 %s :End of /SILENCE list.
        '  IRCU:                     %s :End of Silence List
        '  UNREAL:                   :%s 272 %s :End of Silence List
        'sRPL_STATSDLINE = 275
        '  IRCU:                     %c %s %s
        '  UNREAL:                   :%s 275 %s %c %s %s
        'sRPL_GLIST = 280
        '  IRCU:                     %s%s%s %Tu %s %c :%s
        'sRPL_ENDOFGLIST = 281
        '  IRCU:                     :End of G-line List
        'sRPL_JUPELIST = 282
        '  IRCU:                     %s %Tu %s %c :%s
        'sRPL_ENDOFJUPELIST = 283
        '  IRCU:                     :End of Jupe List
        'sRPL_FEATURE = 284
        '  IRCU
        sRPL_HELP = 292 'SAW ON NEWNET
        '  Reply to /help. Returns a list of IRC commands
        '  UNKNOWN:                  :irc.internetrelaychat.org 292 guideX : Server Commands Help.
        'sRPL_HELPFWD = 294
        '  UNREAL:                   :%s 294 %s :Your help-request has been forwarded to Help Operators
        'sRPL_HELPIGN = 295
        '  UNREAL:                   :%s 295 %s :Your address has been ignored from forwarding
        sRPL_NONE = 300
        '  Dummy reply, supposedly only used for debugging/testing new features, however has appeared in production daemons.
        '  'RFC1459, HYBRID, IRC2, IRCU
        sRPL_AWAY = 301
        '  These replies are used with the AWAY command (if allowed). RPL_AWAY is sent to any client sending a PRIVMSG to a client which is away. RPL_AWAY is only sent by the server to which the client is connected.
        '  Used in reply to a command directed at a user who is marked as away
        '  RFC1459, RFC2812:         <nick> :<message>
        sRPL_USERHOST = 302
        '  Reply used by USERHOST
        '  RFC1459:                  :*1<reply> *( ' ' <reply> )
        sRPL_ISON = 303
        '  Reply to the ISON command
        '  RFC1459:                  :*1<nick> *( ' ' <nick> )
        sRPL_UNAWAY = 305
        '  Reply from AWAY when no longer marked as away
        '  RFC1459:                  :<info>
        sRPL_NOWAWAY = 306
        '  Reply from AWAY when marked away
        '  RFC1459:                  :<info>
        'sRPL_WHOISREGNICK = 307
        '  BAHAMUT, UNREAL:          :%s 307 %s %s :is a registered nick
        'sRPL_WHOISADMIN = 308 '(CONFLICTING)
        '  BAHAMUT:                  :%s 308 %s %s :is an IRC Server Administrator
        'sRPL_RULESSTART = 308 '(CONFLICTING)
        '  UNREAL:                   :%s 308 %s :- %s Server Rules -
        'sRPL_WHOISSADMIN = 309 '(CONFLICTING)
        '  BAHAMUT:                  :%s 309 %s %s :is a Services Administrator
        'sRPL_ENDOFRULES = 309 '(CONFLICTING)
        '  UNREAL:                   :%s 309 %s :End of RULES command.
        'sRPL_WHOISSVCMSG = 310 '(CONFLICTING)
        '  BAHAMUT:                  :%s 310 %s %s
        'sRPL_WHOISHELPOP = 310 '(CONFLICTING)
        '  UNREAL:                   :%s 310 %s %s :is available for help.
        sRPL_WHOISUSER = 311
        '  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message. The * in RPL_WHOISUSER is there as the literal character and not as a wild card.
        '  Reply to WHOIS - Information about the user
        '  RFC1459, RFC2812:         <nick> <user> <host> * :<real_name>
        sRPL_WHOISSERVER = 312
        '  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        '  Reply to WHOIS - What server they're on
        '  'RFC1459, RFC2812:        <nick> <server> :<server_info>
        sRPL_WHOISOPERATOR = 313
        '  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        '  Reply to WHOIS - User has IRC Operator privileges
        '  RFC1459, RFC2812:        <nick> :<privileges>
        sRPL_WHOWASUSER = 314
        '  When replying to a WHOWAS message, a server MUST use the replies RPL_WHOWASUSER, RPL_WHOISSERVER or ERR_WASNOSUCHNICK for each nickname in the presented list. At the end of all reply batches, there MUST be RPL_ENDOFWHOWAS (even if there was only one reply and it was an error).
        '  Reply to WHOWAS - Information about the user
        '  RFC1459, RFC2812:         <nick> <user> <host> * :<real_name>
        sRPL_ENDOFWHO = 315
        '  The RPL_WHOREPLY and RPL_ENDOFWHO pair are used to answer a WHO message. The RPL_WHOREPLY is only sent if there is an appropriate match to the WHO query. If there is a list of parameters supplied with a WHO message, a RPL_ENDOFWHO MUST be sent after processing each list item with <name> being the item
        '  Used to terminate a list of RPL_WHOREPLY replies
        '  RFC1459, RFC2812:         <name> :<info>
        sRPL_WHOISCHANOP = 316 '(RESERVED)
        '  RFC1459, RFC2812 
        sRPL_WHOISIDLE = 317
        '  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.
        '  Reply to WHOIS - Idle information
        '  RFC1459, RFC2812:         <nick> <seconds> :seconds idle
        '  BAHAMUT:                  :%s 317 %s %s %ld %ld :seconds idle, signon time
        '  UNREAL:                   :%s 317 %s %s %ld %ld :seconds idle, signon time
        '  HYBRID:                   :%s 317 %s %s %d %d :seconds idle, signon time
        '  IRC2:                     %s %ld :seconds idle
        '  IRCU:                     %s %ld %ld :seconds idle, signon time  
        sRPL_ENDOFWHOIS = 318
        '  Reply to WHOIS - End of list 
        '  RFC1459, RFC2812:         <nick> :<info>
        '  BAHAMUT/HYBRID/UNREAL:    :%s 318 %s %s :End of /WHOIS list.
        '  IRC2:                     %s :End of WHOIS list.
        '  IRCU:                     %s :End of /WHOIS list.
        sRPL_WHOISCHANNELS = 319
        '  Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message. For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The @ and + characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.
        '  Reply to WHOIS - Channel list for user
        '  RFC1459:                  <nick> :*( ( '@' / '+' ) <channel> ' ' )
        '  RFC2812:                  <nick> :*( ( @|+ ) <channel> <space> )
        '  BAHAMUT, HYBRID, UNREAL:  :%s 319 %s %s :%s
        '  IRC2, IRCU:               %s :%s
        'sRPL_WHOISVIRT = 319 (CONFLICTING)
        '  AUSTHEX
        'sRPL_WHOIS_HIDDEN = 320 '(CONFLICTING)
        '  Anothernet 
        'sRPL_WHOISSPECIAL = 320 '(CONFLICTING)
        '  UNREAL                    :%s 320 %s %s :%s
        sRPL_LISTSTART = 321
        '  Obsolete. Not used. Channel list - Header
        '  RFC1459/IRC2/IRCU:        Channel :Users Name
        '  BAHAMUT/HYBRID/UNREAL:    :%s 321 %s Channel :Users Name
        'sRPL_LIST = 322 '(NO TEXT STRING NESCISARY)
        '  Channel list - A channel
        '  RFC1459:                  <channel> <#_visible> :<topic>
        sRPL_LISTEND = 323
        '  Channel list - End of list
        '  RFC1459:                  :<info>
        sRPL_CHANNELMODEIS = 324
        '  RFC1459:                  <channel> <mode> <mode_params>
        'sRPL_UNIQOPIS = 325 '(CONFLICTING)
        '  RFC8212:                  <channel> <nickname>
        'sRPL_CHANNELPASSIS = 325 '(CONFLICTING)
        'sRPL_NOCHANPASS = 326
        'sRPL_CHPASSUNKNOWN = 327
        sRPL_CHANNEL_URL = 328 'BAHAMUT, AUSTHEX
        '  This is sent to you by ChanServ when you join a registered channel.
        '  HYPERION:                 :<server> 328 <nickname> <channel> :<url>
        'sRPL_CREATIONTIME = 329 
        '  BAHAMUT, HYBRID, UNREAL   :%s 329 %s %s %lu
        '  IRCU:                     %s %Tu
        'sRPL_WHOWAS_TIME = 330 '(CONFLICTING)
        'sRPL_WHOISACCOUNT = 330 '(CONFLICTING)
        '  IRCU:                 <nick> <authname> :<info>
        sRPL_NOTOPIC = 331 'RFC1459, RFC2812
        '  When sending a TOPIC message to determine the channel topic, one of two replies is sent. If the topic is set, RPL_TOPIC is sent back else RPL_NOTOPIC.
        '  <channel> :<info>
        sRPL_TOPIC = 332 'RFC1459, RFC2812
        '  When sending a TOPIC message to determine the channel topic, one of two replies is sent. If the topic is set, RPL_TOPIC is sent back else RPL_NOTOPIC.
        '  Response to TOPIC with the set topic
        '  <channel> :<topic>
        'sRPL_TOPIC = 332 'BAHAMUT, HYBRID, IRC2, IRCU, UNREAL (CONFLICTING)
        '  BAHAMUT, HYBRID, UNREAL:   :%s 332 %s %s :%s
        '  IRC2, IRCU:               %s :%s
        sRPL_TOPICWHOTIME = 333 'IRCU
        '  This is returned for a TOPIC request or when you JOIN, if the channel has a topic.
        '  IRCU:                     :<server> 333 <channel> <nickname> <time>
        'sRPL_LISTUSAGE = 334 'IRCU (CONFLICTING)
        'sRPL_COMMANDSYNTAX = 334 'BAHAMUT (CONFLICTING)
        'sRPL_LISTSYNTAX = 334 'UNREAL (CONFLICTING)
        'sRPL_WHOISBOT = 335 'UNREAL
        'sRPL_CHANPASSOK = 338 (CONFLICTING)
        sRPL_WHOISACTUALLY = 338 'IRCU, BAHAMUT (CONFLICTING)
        '  bahumut:                  :%s 338 %s :%s is actually %s@%s [%s]
        '  IRCU:                     %s %s@%s %s :Actual user@host, Actual IP
        'sRPL_BADCHANPASS = 339
        'sRPL_USERIP = 340 
        '  IRCU
        sRPL_INVITING = 341
        '  Returned by the server to indicate that the attempted INVITE message was successful and is being passed onto the end client. Note that RFC1459 documents the parameters in the reverse order. The format given here is the format used on production servers, and should be considered the standard reply above that given by RFC1459.
        '  RFC1459:                  <nick> <channel>
        sRPL_SUMMONING = 342
        '  Returned by a server answering a SUMMON message to indicate that it is summoning that user
        '  RFC1459:                  <user> :<info>
        'sRPL_INVITED = 345
        '  Sent to users on a channel when an INVITE command has been issued
        '  GameSurge:                <channel> <user being invited> <user issuing invite> :<user being invited> has been invited by <user issuing invite>
        sRPL_INVITELIST = 346
        '  An invite mask for the invite mask list
        '  RFC2812:                  <channel> <invitemask>
        sRPL_ENDOFINVITELIST = 347
        '  Termination of an RPL_INVITELIST list
        '  RFC2812:                  <channel> :<info>
        sRPL_EXCEPTLIST = 348
        '  An exception mask for the exception mask list. Also known as RPL_EXLIST (UNREAL, Ultimate)
        '  RFC2812:                  <channel> <exceptionmask>
        sRPL_ENDOFEXCEPTLIST = 349
        '  Termination of an RPL_EXCEPTLIST list. Also known as RPL_ENDOFEXLIST (UNREAL, Ultimate)
        '  RFC2812:                  <channel> :<info>
        sRPL_VERSION = 351
        '  Reply by the server showing its version details, however this format is not often adhered to
        '  RFC1459:                  <version>[.<debuglevel>] <server> :<comments>
        sRPL_WHOREPLY = 352
        '  Reply to vanilla WHO (See RFC). This format can be very different if the 'WHOX' version of the command is used (see IRCU).
        '  RFC1459:                  <channel> <user> <host> <server> <nick> <H|G>[*][@|+] :<hopcount> <real_name>
        sRPL_NAMREPLY = 353
        '  Reply to NAMES
        '  RFC1459:                  ( '=' / '*' / '@' ) <channel> ' ' : [ '@' / '+' ] <nick> *( ' ' [ '@' / '+' ] <nick> )
        '  EXAMPLE:                  :irc.ircsoulz.org 353 guide_X = #test :@guide_X 
        'sRPL_WHOSPCRPL = 354
        '  Reply to WHO, however it is a 'special' reply because it is returned using a non-standard (non-RFC1459) format. The format is dictated by the command given by the user, and can vary widely. When this is used, the WHO command was invoked in its 'extended' form, as announced by the 'WHOX' ISUPPORT tag.
        '  IRCU
        'sRPL_NAMREPLY_ = 355
        '  Reply to the "NAMES -d" command - used to show invisible users (when the channel is set +D, QuakeNet relative). The proper define name for this numeric is unknown at this time Also see #353.
        '  QuakeNet
        'sRPL_MAP = 357 'AUSTHEX (DEPRECIATED)
        'sRPL_MAPMORE = 358 'AUSTHEX (DEPRECIATED)
        'sRPL_MAPEND = 359 'AUSTHEX (DEPRECIATED)
        'sRPL_KILLDONE = 361 'RFC1459 (DEPRECIATED)
        'sRPL_CLOSING = 362 'RFC1459 (DEPRECIATED)
        'sRPL_CLOSEEND = 363 'RFC1459 (DEPRECIATED)
        sRPL_LINKS = 364
        '  Reply to the LINKS command
        '  RFC1459:                  <mask> <server> :<hopcount> <server_info>
        sRPL_ENDOFLINKS = 365
        '  Termination of an RPL_LINKS list
        '  RFC1459:                  <mask> :<info>
        sRPL_ENDOFNAMES = 366
        '  Termination of an RPL_NAMREPLY list
        '  RFC1459:                  <channel> :<info>
        '  EXAMPLE:                  :irc.ircsoulz.org 366 guide_X #test :End of /NAMES list.
        sRPL_BANLIST = 367
        '  A ban-list item (See RFC); <time left> and <reason> are additions used by KineIRCd
        '  RFC1459:                  <channel> <banid> [<time_left> :<reason>]
        sRPL_ENDOFBANLIST = 368
        '  Termination of an RPL_BANLIST list
        '  RFC1459:                  <channel> :<info>
        sRPL_ENDOFWHOWAS = 369
        '  Reply to WHOWAS - End of list
        '  RFC1459:                  <nick> :<info>
        sRPL_INFO = 371
        '  A server responding to an INFO message is required to send all its 'info' in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
        '  RFC2812:                  :<string>
        sRPL_MOTD = 372
        '  Reply To /MOTD
        '  RFC1459:                  :- <string>
        'sRPL_INFOSTART = 373 '(RESERVED)
        '  RFC2812
        sRPL_ENDOFINFO = 374
        '  A server responding to an INFO message is required to send all its 'info' in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
        '  RFC2812:                  :End of INFO list
        sRPL_MOTDSTART = 375
        '  When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies. These MUST be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
        '  RFC2812:                  :- <server> Message of the day -
        sRPL_ENDOFMOTD = 376
        '  When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies. These MUST be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
        '  RFC2812:                  :End of MOTD command
        'sRPL_SPAM = 377 '(DEPRECIATED)
        '  Used during the connection (after MOTD) to announce the network policy on spam and privacy. Supposedly now obsoleted in favour of using NOTICE.
        '  AUSTHEX:                  :<text>
        'sRPL_KICKEXPIRED = 377 '(CONFLICTING)
        '  AIRCD
        'sRPL_BANEXPIRED = 378
        '  AIRCD
        sRPL_WHOISHOST = 378
        '  UNREAL
        'sRPL_FORCEMOTD = 378 (CONFLICTING)
        '  Used by AUSTHEX to 'force' the display of the MOTD, however is considered obsolete due to client/script awareness & ability to Also see #372.
        '  AUSTHEX
        'sRPL_KICKLINKED = 379
        '  AIRCD
        sRPL_WHOISMODES = 379
        '  UNREAL 
        'sRPL_BANLINKED = 380 
        '  AIRCD
        'sRPL_YOURHELPER = 380 
        '  AUSTHEX
        sRPL_YOUREOPER = 381
        '  RPL_YOUREOPER is sent back to a client which has just successfully issued an OPER message and gained operator status.
        '  RFC2812:                  :You are now an IRC operator
        sRPL_REHASHING = 382
        '  If the REHASH option is used and an operator sends a REHASH message, an RPL_REHASHING is sent back to the operator.
        '  RFC14:                  <config file> :Rehashing
        sRPL_YOURESERVICE = 383
        '  Sent upon successful registration of a service
        '  RFC2812:                 :You are service <service_name>
        'sRPL_MYPORTIS = 384 (RESERVED)
        '  RFC1459
        'sRPL_NOTOPERANYMORE = 385
        '  AUSTHEX, HYBRID, UNREAL
        'sRPL_QLIST = 386
        '  UNREAL
        'sRPL_IRCOPS = 386
        '  ULTIMATE
        'sRPL_ENDOFQLIST = 387
        'sRPL_ALIST = 388
        '  UNREAL
        'sRPL_ENDOFALIST = 389
        '  UNREAL
        sRPL_TIME = 391
        '  Response to the TIME command. The string format may vary greatly. Also see #679.
        '  RFC1459:                  <server> :<time string>
        '  IRCU:                     <server> <timestamp> <offset> :<time string>
        sRPL_USERSSTART = 392
        '  Start of an RPL_USERS list
        '  RFC1459:                  :UserID Terminal Host
        sRPL_USERS = 393
        '  Response to the USERS command (See RFC)
        '  RFC1459:                  :<username> <ttyline> <hostname>
        sRPL_ENDOFUSERS = 394
        '  Termination of an RPL_USERS list
        '  RFC1459:                  :<info>
        sRPL_NOUSERS = 395
        '  Reply to USERS when nobody is logged in
        '  RFC1459:                  :<info>
        sRPL_HOSTHIDDEN = 396
        '  UNDERNET
        '  Reply to a user when user mode +x (host masking) was set successfully
        sERR_UNKNOWNERROR = 400
        '  Sent when an error occured executing a command, but it is not specifically known why the command could not be executed.
        '  UNKNOWN:                  <command> [<?>] :<info>
        sERR_NOSUCHNICK = 401
        '  Used to indicate the nickname parameter supplied to a command is currently unused
        '  RFC1459:                  <nick> :<reason>
        sERR_NOSUCHSERVER = 402
        '  Used to indicate the server name given currently doesn't exist
        '  RFC1459:                  <server> :<reason>
        sERR_NOSUCHCHANNEL = 403
        '  Used to indicate the given channel name is invalid, or does not exist
        '  RFC1459:                  <channel> :<reason>
        sERR_CANNOTSENDTOCHAN = 404
        '  Sent to a user who does not have the rights to send a message to a channel
        '  RFC1459:                  <channel> :<reason>
        sERR_TOOMANYCHANNELS = 405
        '  Sent to a user when they have joined the maximum number of allowed channels and they tried to join another channel
        '  RFC1459:                  <channel> :<reason>
        sERR_WASNOSUCHNICK = 406
        '  Returned by WHOWAS to indicate there was no history information for a given nickname
        '  RFC1459:                  <nick> :<reason>
        sERR_TOOMANYTARGETS = 407
        '  The given target(s) for a command are ambiguous in that they relate to too many targets
        '  RFC1459:                  <target> :<reason>
        sERR_NOSUCHSERVICE = 408
        '  Returned to a client which is attempting to send an SQUERY (or other message) to a service which does not exist
        '  RFC1459:                  <service_name> :<reason>
        'sERR_NOCOLORSONCHAN = 408 (DEPRECIATED)
        '  BAHAMUT
        sERR_NOORIGIN = 409
        '  PING or PONG message missing the originator parameter which is required since these commands must work without valid prefixes
        '  RFC1459:                  :<reason>
        sERR_NORECIPIENT = 411
        '  Returned when no recipient is given with a command
        '  RFC1459:                  :<reason>
        sERR_NOTEXTTOSEND = 412
        '  Returned when NOTICE/PRIVMSG is used with no message given
        '  RFC1459:                  :<reason>
        sERR_NOTOPLEVEL = 413
        '  Used when a message is being sent to a mask without being limited to a top-level domain (i.e. * instead of *.au)
        '  RFC1459:                  <mask> :<reason>
        sERR_WILDTOPLEVEL = 414
        '  Used when a message is being sent to a mask with a wild-card for a top level domain (i.e. *.*)
        '  RFC1459:                  <mask> :<reason>
        sERR_BADMASK = 415
        '  Used when a message is being sent to a mask with an invalid syntax
        '  RFC1459:                  <mask> :<reason>
        'sERR_TOOMANYMATCHES = 416 (CONFLICTING)
        '  Returned when too many matches have been found for a command and the output has been truncated. An example would be the WHO command, where by the mask '*' would match everyone on the network! Ouch!
        '  IRCNET:                   <command> [<mask>] :<info>
        'sERR_QUERYTOOLONG = 416 (CONFLICTING)
        '  IRCU:                     Same as ERR_TOOMANYMATCHES
        'sERR_LENGTHTRUNCATED = 419
        '  AIRCD
        sERR_UNKNOWNCOMMAND = 421
        '  Returned when the given command is unknown to the server (or hidden because of lack of access rights)
        '  RFC1459:                  <command> :<reason>
        sERR_NOMOTD = 422
        '  Sent when there is no MOTD to send the client
        '  RFC1459:                  :<reason>
        sERR_NOADMININFO = 423
        '  Returned by a server in response to an ADMIN request when no information is available. RFC1459 mentions this in the list of numerics. While it's not listed as a valid reply in section 4.3.7 ('Admin command'), it's confirmed to exist in the real world.
        '  RFC1459:                  <server> :<reason>
        sERR_FILEERROR = 424
        '  Generic error message used to report a failed file operation during the processing of a command
        '  RFC1459:                  :<reason>
        'sERR_NOOPERMOTD = 425
        '  UNREAL 
        'sERR_TOOMANYAWAY = 429
        '  BAHAMUT
        'sERR_EVENTNICKCHANGE = 430
        '  Returned by NICK when the user is not allowed to change their nickname due to a channel event (channel mode +E)
        '  AUSTHEX
        sERR_NONICKNAMEGIVEN = 431
        '  Returned when a nickname parameter expected for a command isn't found
        '  RFC1459:                  :<reason>
        sERR_ERRONEUSNICKNAME = 432
        '  Returned after receiving a NICK message which contains a nickname which is considered invalid, such as it's reserved ('anonymous') or contains characters considered invalid for nicknames. This numeric is misspelt, but remains with this name for historical reasons :)
        '  RFC1459:                  <nick> :<reason>
        sERR_NICKNAMEINUSE = 433
        '  Returned by the NICK command when the given nickname is already in use
        '  RFC1459:                  <nick> :<reason>
        'sERR_SERVICENAMEINUSE = 434 (CONFLICTING)
        '  AUSTHEX
        'sERR_NORULES = 434 (CONFLICTING)
        '  UNREAL, Ultimate
        'sERR_SERVICECONFUSED = 435 (CONFLICTING)
        '  UNREAL
        'sERR_BANONCHAN = 435 (CONFLICTING)
        '  BAHAMUT
        sERR_NICKCOLLISION = 436
        '  Returned by a server to a client when it detects a nickname collision
        '  RFC1459:                  <nick> :<reason>
        sERR_UNAVAILRESOURCE = 437
        '  Return when the target is unable to be reached temporarily, eg. a delay mechanism in play, or a service being offline
        '  RFC2812:                  <nick/channel/service> :<reason>
        'sERR_BANNICKCHANGE = 437
        '  IRCU
        'sERR_NICKTOOFAST = 438
        '  IRCU
        'sERR_DEAD = 438
        '  IRCNET
        sERR_TARGETTOOFAST = 439
        '  IRCU:                     Also known as many other things, RPL_INVTOOFAST, RPL_MSGTOOFAST etc
        'sERR_SERVICESDOWN = 440
        '  BAHAMUT, UNREAL
        sERR_USERNOTINCHANNEL = 441
        '  Returned by the server to indicate that the target user of the command is not on the given channel
        '  RFC1459:                  <nick> <channel> :<reason>
        sERR_NOTONCHANNEL = 442
        '  Returned by the server whenever a client tries to perform a channel effecting command for which the client is not a member
        '  RFC1459:                  <channel> :<reason>
        sERR_USERONCHANNEL = 443
        '  Returned when a client tries to invite a user to a channel they're already on
        '  RFC1459:                  <nick> <channel> [:<reason>]
        sERR_NOLOGIN = 444
        '  Returned by the SUMMON command if a given user was not logged in and could not be summoned
        '  RFC1459:                  <user> :<reason>
        sERR_SUMMONDISABLED = 445
        '  Returned by SUMMON when it has been disabled or not implemented
        '  RFC1459:                  :<reason>
        sERR_USERSDISABLED = 446
        '  Returned by USERS when it has been disabled or not implemented
        '  RFC1459:                  :<reason>
        'sERR_NONICKCHANGE = 447
        '  UNREAL
        'sERR_NOTIMPLEMENTED = 449
        '  Returned when a requested feature is not implemented (and cannot be completed)
        '  Undernet:                 Unspecified 
        sERR_NOTREGISTERED = 451
        '  Returned by the server to indicate that the client must be registered before the server will allow it to be parsed in detail
        '  RFC1459:                  :<reason>
        'sERR_IDCOLLISION = 452
        'sERR_NICKLOST = 453
        'sERR_HOSTILENAME = 455
        '  UNREAL
        'sERR_ACCEPTFULL = 456
        'sERR_ACCEPTEXIST = 457
        'sERR_ACCEPTNOT = 458
        'sERR_NOHIDING = 459
        '  Not allowed to become an invisible operator?
        '  UNREAL 
        'sERR_NOTFORHALFOPS = 460
        '  UNREAL
        sERR_NEEDMOREPARAMS = 461
        '  Returned by the server by any command which requires more parameters than the number of parameters given
        '  RFC1459:                  <command> :<reason>
        sERR_ALREADYREGISTERED = 462
        '  Returned by the server to any link which attempts to register again
        '  RFC1459:                  :<reason>
        sERR_NOPERMFORHOST = 463
        '  Returned to a client which attempts to register with a server which has been configured to refuse connections from the client's host
        '  RFC1459:                  :<reason>
        sERR_PASSWDMISMATCH = 464
        '  Returned by the PASS command to indicate the given password was required and was either not given or was incorrect
        '  RFC1459:                  :<reason>
        sERR_YOUREBANNEDCREEP = 465
        '  Returned to a client after an attempt to register on a server configured to ban connections from that client
        '  RFC1459:                  :<reason>
        'sERR_YOUWILLBEBANNED = 466 '(DEPRECIATED)
        '  Sent by a server to a user to inform that access to the server will soon be denied
        '  UNKNOWN
        sERR_KEYSET = 467
        '  Returned when the channel key for a channel has already been set
        '  RFC1459:                  <channel> :<reason>
        sERR_INVALIDUSERNAME = 468 '(CONFLICTING)
        '  IRCU
        'sERR_ONLYSERVERSCANCHANGE = 468 '(CONFLICTING)
        '  BAHAMUT, UNREAL
        'sERR_LINKSET = 469
        '  UNREAL
        sERR_LINKCHANNEL = 470
        '  This mode allows operators to forward non-excepted users to a secondary channel. Presumably this is intended behavior by the channel operators, although you could attempt to rejoin the primary channel - you would have to contact the channel operators with any channel-specific policy questions.
        '  UNREAL
        '  :holmes.freenode.net 470 guideX #c ##c-unregistered :Forwarding to another channel
        'sERR_KICKEDFROMCHAN = 470
        '  AIRCD
        sERR_CHANNELISFULL = 471
        '  Returned when attempting to join a channel which is set +l and is already full
        '  RFC1459:                  <channel> :<reason>
        sERR_UNKNOWNMODE = 472
        '  Returned when a given mode is unknown
        '  RFC1459:                  <char> :<reason>
        sERR_INVITEONLYCHAN = 473
        '  Returned when attempting to join a channel which is invite only without an invitation
        '  RFC1459:                  <channel> :<reason>
        '  BAHAMUT/HYBRID/UNREAL:    :%s 473 %s %s :Cannot join channel (+i)
        '  IRCU/IRC2:                %s :Cannot join channel (+i)
        sERR_BANNEDFROMCHAN = 474
        '  Returned when attempting to join a channel a user is banned from
        '  RFC1459:                  <channel> :<reason>
        '  BAHAMUT/HYBRID/UNREAL:    :%s 474 %s %s :Cannot join channel (+b)
        '  IRC2/IRCU:                %s :Cannot join channel (+b)
        sERR_BADCHANNELKEY = 475
        '  Returned when attempting to join a key-locked channel either without a key or with the wrong key
        '  RFC1459:                  <channel> :<reason>
        sERR_BADCHANMASK = 476
        '  The given channel mask was invalid
        '  RFC2812:                  <channel> :<reason>
        sERR_NOCHANMODES = 477
        '  Returned when attempting to set a mode on a channel which does not support channel modes, or channel mode changes. Also known as ERR_MODELESS
        '  RFC2812:                  <channel> :<reason>
        'sERR_NEEDREGGEDNICK = 477 '(CONFLICTING)
        '  BAHAMUT, IRCU, UNREAL
        ':niven.freenode.net 477 nirc #testerama :[freenode-info] if you need to send private messages, please register: http://freenode.net/faq.shtml#privmsg
        sERR_BANLISTFULL = 478
        '  Returned when a channel access list (i.e. ban list etc) is full and cannot be added to
        '  RFC2812:                  <channel> <char> :<reason>
        sERR_BADCHANNAME = 479
        '  HYBRID 
        '  EXAMPLE:                  :card.freenode.net 479 nirc m JOIN :#ubuntu :Illegal channel name
        'sERR_LINKFAIL = 479
        '  UNREAL
        'sERR_NOULINE = 480 '(CONFLICTING)
        '  AUSTHEX
        'sERR_CANNOTKNOCK = 480 '(CONFLICTING)
        '  UNREAL
        sERR_NOPRIVILEGES = 481
        '  Returned by any command requiring special privileges (eg. IRC operator) to indicate the operation was unsuccessful
        '  RFC1459:                  :<reason>
        sERR_CHANOPRIVSNEEDED = 482
        '  Returned by any command requiring special channel privileges (eg. channel operator) to indicate the operation was unsuccessful
        '  RFC1459:                  <channel> :<reason>
        sERR_CANTKILLSERVER = 483
        '  Returned by KILL to anyone who tries to kill a server
        '  RFC1459:                  :<reason>
        sERR_RESTRICTED = 484
        '  Sent by the server to a user upon connection to indicate the restricted nature of the connection (i.e. usermode +r)
        '  RFC2812:                  :<reason>
        'sERR_ISCHANSERVICE = 484
        '  Undernet 
        'sERR_DESYNC = 484
        '  BAHAMUT, HYBRID, PTlink
        'sERR_ATTACKDENY = 484
        '  UNREAL
        sERR_UNIQOPRIVSNEEDED = 485
        '  Any mode requiring 'channel creator' privileges returns this error if the client is attempting to use it while not a channel creator on the given channel
        '  RFC2812:                  :<reason>
        'sERR_KILLDENY = 485 (CONFLICTING)
        '  UNREAL
        'sERR_CANTKICKADMIN = 485 (CONFLICTING)
        '  PTlink
        'sERR_ISREALSERVICE = 485 (CONFLICTING)
        '  QuakeNet
        'sERR_NONONREG = 486 (CONFLICTING)
        'sERR_HTMDISABLED = 486 (CONFLICTING)
        '  UNREAL 
        'sERR_ACCOUNTONLY = 486 (CONFLICTING)
        '  QuakeNet
        'sERR_CHANTOORECENT = 487 (CONFLICTING)
        '  IRCNET
        'sERR_MSGSERVICES = 487 (CONFLICTING)
        '  BAHAMUT
        'sERR_TSLESSCHAN = 488 
        '  IRCNET
        'sERR_VOICENEEDED = 489
        '  Undernet
        'sERR_SECUREONLYCHAN = 489
        '  UNREAL
        sERR_NOOPERHOST = 491
        '  RFC1459:                  :<reason>
        'sERR_NOSERVICEHOST = 492 (DEPRECIATED)
        '  RFC1459
        'sERR_NOFEATURE = 493
        '  IRCU
        'sERR_BADFEATURE = 494
        '  IRCU
        'sERR_BADLOGTYPE = 495
        '  IRCU
        'sERR_BADLOGSYS = 496
        '  IRCU
        'sERR_BADLOGVALUE = 497
        '  IRCU
        'sERR_ISOPERLCHAN = 498
        '  IRCU
        'sERR_CHANOWNPRIVNEEDED = 499
        '  Works just like ERR_CHANOPRIVSNEEDED except it indicates that owner status (+q) is needed. Also see #482.
        '  UNREAL
        sERR_UMODEUNKNOWNFLAG = 501
        '  Returned by the server to indicate that a MODE message was sent with a nickname parameter and that the mode flag sent was not recognised
        '  RFC1459:                  :<reason>
        sERR_USERSDONTMATCH = 502
        '  Error sent to any user trying to view or change the user mode for a user other than themselves
        '  RFC1459:                  :<reason>
        'sERR_GHOSTEDCLIENT = 503
        '  HYBRID
        'sERR_VWORLDWARN = 503
        '  Warning about Virtual-World being turned off. Obsoleted in favour for RPL_MODECHANGEWARN Also see #662.
        '  :<warning_text>
        'sERR_USERNOTONSERV = 504
        'sERR_SILELISTFULL = 511
        '  IRCU
        'sERR_TOOMANYWATCH = 512
        '  Also known as ERR_NOTIFYFULL (AIRCD), I presume they are the same
        '  BAHAMUT 
        'sERR_BADPING = 513
        '  Also known as ERR_NEEDPONG (UNREAL/Ultimate) for use during registration, however it's not used in UNREAL (and might not be used in Ultimate either).
        'sERR_INVALID_ERROR = 514 '(CONFLICTING)
        '  IRCU
        'sERR_TOOMANYDCC = 513 '(CONFLICTING)
        '  BAHAMUT
        'sERR_BADEXPIRE = 515
        '  IRCU
        'sERR_DONTCHEAT = 516
        '  IRCU
        'sERR_DISABLED = 517
        '  IRCU
        'sERR_NOINVITE = 518 '(CONFLICTING)
        '  UNREAL
        'sERR_LONGMASK = 518 '(CONFLICTING)
        '  IRCU
        'sERR_ADMONLY = 519 '(CONFLICTING)
        '  UNREAL
        'sERR_TOOMANYUSERS = 519 '(CONFLICTING)
        '  IRCU
        'sERR_OPERONLY = 520 '(CONFLICTING)
        '  UNREAL
        'sERR_MASKTOOWIDE = 520 '(CONFLICTING)
        '  IRCU
        'sERR_WHOTRUNC = 520 '(CONFLICTING)
        '  This is considered obsolete in favour of ERR_TOOMANYMATCHES, and should no longer be used. Also see #416.
        '  AUSTHEX
        'sERR_LISTSYNTAX = 521 '(DEPRECIATED)
        '  BAHAMUT
        'sERR_WHOSYNTAX = 522
        '  BAHAMUT
        'sERR_WHOLIMEXCEED = 523
        '  BAHAMUT
        'sERR_QUARANTINED = 524 '(CONFLICTING)
        '  IRCU 
        'sERR_OPERSPVERIFY = 524 '(CONFLICTING)
        '  UNREAL
        'sERR_REMOTEPFX = 525 '(PROPOSED)
        '  CAPAB USERCMDPFX:         <nickname> :<reason>
        'sERR_PFXUNROUTABLE = 526 '(PROPOSED)
        '  CAPAB USERCMDPFX:         <nickname> :<reason>
        'sERR_BADHOSTMASK = 550
        '  QuakeNet
        'sERR_HOSTUNAVAIL = 551
        '  QuakeNet
        'sERR_USINGSLINE = 552
        '  QuakeNet
        'sERR_STATSSLINE = 553 '(DEPRECIATED)
        '  QuakeNet
        'sRPL_LOGON = 600
        '  BAHAMUT, UNREAL:          :%s 600 %s %s %s %s %d :logged online
        'sRPL_LOGOFF = 601
        '  BAHAMUT, UNREAL:          :%s 600 %s %s %s %s %d :logged online
        'sRPL_WATCHOFF = 602
        '  BAHAMUT, UNREAL:          :%s 602 %s %s %s %s %d :stopped watching
        'sRPL_WATCHSTAT = 603
        '  BAHAMUT, UNREAL:          :%s 603 %s :You have %d and are on %d WATCH entries
        sRPL_NOWON = 604
        '  BAHAMUT, UNREAL:          :%s 604 %s %s %s %s %d :is online
        sRPL_NOWOFF = 605
        '  BAHAMUT, UNREAL:          :%s 605 %s %s %s %s %d :is offline
        sRPL_WATCHLIST = 606
        '  BAHAMUT, UNREAL:          :%s 606 %s :%s
        sRPL_ENDOFWATCHLIST = 607
        '  BAHAMUT, UNREAL:          :%s 607 %s :End of WATCH %c
        'sRPL_WATCHCLEAR = 608
        '  Ultimate
        sRPL_MAPMORE = 610 '(CONFLICTING)
        '  UNREAL:                   :%s 610 %s :%s%-*s --> *more*
        'sRPL_ISOPER = 610 '(CONFLICTING)
        '  Ultimate
        'sRPL_ISLOCOP = 611
        '  Ultimate 
        'sRPL_ISNOTOPER = 612
        '  Ultimate
        'sRPL_ENDOFISOPER = 613
        '  Ultimate
        'sRPL_MAPMORE = 615 '(DEPRECIATED)
        '  PTlink
        sRPL_WHOISMODES2 = 615
        '  Ultimate
        sRPL_WHOISHOST2 = 616
        '  Ultimate
        'sRPL_DCCSTATUS = 617
        '  BAHAMUT:                  :%s 617 %s :%s has been %s your DCC allow list
        'sRPL_DCCLIST = 618
        '  BAHAMUT:                  :%s 618 %s :%s
        'sRPL_ENDOFDCCLIST = 619 '(CONFLICTING)
        '  BAHAMUT:                  :%s 619 %s :End of DCCALLOW %s
        'sRPL_DCCINFO = 620 '(CONFLICTING)
        '  BAHAMUT:                  :%s 620 %s :%s
        'sRPL_RULESSTART = 620 '(CONFLICTING)
        '  ULTIMATE
        'sRPL_RULES = 621 '(DEPRECIATED)
        '  ULTIMATE
        'sRPL_ENDOFRULES = 622 '(DEPRECIATED)
        '  ULTIMATE
        'sRPL_MAPMORE = 623 '(DEPRECIATED)
        '  ULTIMATE
        'sRPL_OMOTDSTART = 624
        '  ULTIMATE
        'sRPL_OMOTD = 625
        '  ULTIMATE
        'sRPL_ENDOFO = 626
        '  ULTIMATE
        'sRPL_SETTINGS = 630
        '  ULTIMATE
        'sRPL_ENDOFSETTINGS = 631
        '  ULTIMATE
        'sRPL_DUMPING '(DEPRECIATED)
        '  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        'sRPL_DUMPRPL = 641 '(DEPRECIATED)
        '  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        'sRPL_EODUMP = 642 '(DEPRECIATED)
        '  Never actually used by Unreal - was defined however the feature that would have used this numeric was never created.
        'sRPL_TRACEROUTE_HOP = 660
        '  Returned from the TRACEROUTE IRC-Op command when tracerouting a host
        '  KINEIRCD:                 <target> <hop#> [<address> [<hostname> | '*'] <usec_ping>]
        'sRPL_TRACEROUTE_START = 661
        '  Start of an RPL_TRACEROUTE_HOP list
        '  <target> <target_FQDN> <target_address> <max_hops>
        'sRPL_MODECHANGEWARN = 662
        '  Plain text warning to the user about turning on or off a user mode. If no '+' or '-' prefix is used for the mode char, '+' is presumed.
        '                                   ['+' | '-']<mode_char> :<warning>
        'sRPL_CHANREDIR = 663
        '  Used to notify the client upon JOIN that they are joining a different channel than expected because the IRC Daemon has been set up to map the channel they attempted to join to the channel they eventually will join.
        '                                   <old_chan> <new_chan> :<info>
        'sRPL_SERVMODEIS = 664
        '  Reply to MODE <servername>. KineIRCd supports server modes to simplify configuration of servers; Similar to RPL_CHANNELMODEIS
        '                                   <server> <modes> <parameters>..
        'sRPL_OTHERUMODEIS = 665
        '  Reply to MODE <nickname> to return the user-modes of another user to help troubleshoot connections, etc. Similar to RPL_UMODEIS, however including the target
        '                                   <nickname> <modes>
        'sRPL_ENDOF_GENERIC = 666
        '  Generic response for new lists to save numerics.
        '                                   <command> [<parameter> ...] :<info>
        'sRPL_WHOWASDETAILS = 670
        '  Returned by WHOWAS to return extended information (if available). The type field is a number indication what kind of information.
        '  KineIRCd:                 <nick> <type> :<information>
        'sRPL_WHOISSECURE = 671
        '  Reply to WHOIS command - Returned if the target is connected securely, eg. type may be TLSv1, or SSLv2 etc. If the type is unknown, a '*' may be used.
        '  KineIRCd:                 <nick> <type> [:<info>]
        'sRPL_UNKNOWNMODES = 672
        '  Returns a full list of modes that are unknown when a client issues a MODE command (rather than one numeric per mode)
        '  Ithildin:                     <modes> :<info>
        'sRPL_CANNOTSETMODES = 673
        '  Returns a full list of modes that cannot be set when a client issues a MODE command
        '  Ithildin:                     <modes> :<info>
        'sRPL_LUSERSTAFF = 678
        '  Reply to LUSERS command - Number of network staff (or 'helpers') online (differs from Local/Global operators). Similar format to RPL_LUSEROP
        '  KINEIRCD:                 <staff_online_count> :<info>
        'sRPL_TIMEONSERVERIS = 679
        '  Optionally sent upon connection, and/or sent as a reply to the TIME command. This returns the time on the server in a uniform manner. The seconds (and optionally nanoseconds) is the time since the UNIX Epoch, and is used since many existing timestamps in the IRC-2 protocol are done this way (i.e. ban lists). The timezone is hours and minutes each of Greenwich ('[+/-]HHMM'). Since all timestamps sent from the server are in a similar format, this numeric is designed to give clients the ability to provide accurate timestamps to their users.
        '  KINEIRCD:                 <seconds> [<nanoseconds> | '0'] <timezone> <flags> :<info>
        'sRPL_NETWORKS = 682
        '  A reply to the NETWORKS command when requesting a list of known networks (within the IIRC domain).
        '  KINEIRCD:                 <name> <through_name> <hops> :<info>
        'sRPL_YOURLANGUAGEIS = 687
        '  Reply to the LANGUAGE command, informing the client of the language(s) it has set
        '  KINEIRCD:                 <code(s)> :<info>
        'sRPL_LANGUAGE = 688
        '  A language reply to LANGUAGE when requesting a list of known languages
        '  KINEIRCD:                 <code> <revision> <maintainer> <flags> * :<info>
        'sRPL_WHOISSTAFF = 689
        '  The user is a staff member. The information may explain the user's job role, or simply state that they are a part of the network staff. Staff members are not IRC operators, but rather people who have special access in association with network services. KineIRCd uses this numeric instead of the existing numerics due to the overwhelming number of conflicts.
        '  KINEIRCD:                 :<info>
        'sRPL_WHOISLANGUAGE = 690
        '  Reply to WHOIS command - A list of languages someone can speak. The language codes are comma delimitered.
        '  KINEIRCD:                 <nick> <language codes>
        'sRPL_MODLIST = 702
        '  Output from the MODLIST command
        '  RATBOX:                   <?> 0x<?> <?> <?>
        'sRPL_ENDOFMODLIST = 703
        '  Terminates MODLIST output
        '  RATBOX:                   RATBOX:                   :<text>
        'sRPL_HELPSTART = 704
        '  Start of HELP command output
        '  RATBOX:                   <command> :<text>
        'sRPL_HELPTXT = 705
        '  Output from HELP command
        '  RATBOX:                   <command> :<text>
        'sRPL_ENDOFHELP = 706
        '  End of HELP command output
        '  RATBOX:                   <command> :<text>
        'sRPL_ETRACEFULL = 708
        '  Output from 'extended' trace
        '  RATBOX:                   <?> <?> <?> <?> <?> <?> <?> :<?>
        'sRPL_ETRACE = 709
        '  Output from 'extended' trace
        '  RATBOX:                   <?> <?> <?> <?> <?> <?> :<?>
        'sRPL_KNOCK = 710
        '  Message delivered using KNOCK command
        '  RATBOX:                   <channel> <nick>!<user>@<host> :<text>  
        'sRPL_KNOCKDLVR = 711
        '  Message returned from using KNOCK command
        '  RATBOX:                   <channel> :<text>
        'sERR_TOOMANYKNOCK = 712
        '  Message returned when too many KNOCKs for a channel have been sent by a user
        '  RATBOX:                   <channel> :<text>
        'sERR_CHANOPEN = 713
        '  Message returned from KNOCK when the channel can be freely joined by the user
        '  RATBOX:                   <channel> :<text>
        'sERR_KNOCKONCHAN = 714
        '  Message returned from KNOCK when the user has used KNOCK on a channel they have already joined
        '  RATBOX:                   <channel> :<text>
        'sERR_KNOCKDISABLED = 715
        '  Returned from KNOCK when the command has been disabled
        '  RATBOX:                   :<text>
        'sRPL_TARGUMODEG = 716
        '  Sent to indicate the given target is set +g (server-side ignore)
        '  RATBOX:                   <nick> :<info>
        'sRPL_TARGNOTIFY = 717
        '  Sent following a PRIVMSG/NOTICE to indicate the target has been notified of an attempt to talk to them while they are set +g
        '  RATBOX:                   <nick> :<info>
        'sRPL_UMODEGMSG = 718
        '  Sent to a user who is +g to inform them that someone has attempted to talk to them (via PRIVMSG/NOTICE), and that they will need to be accepted (via the ACCEPT command) before being able to talk to them
        '  RATBOX:                   <nick> <user>@<host> :<info>
        'sRPL_OMOTDSTART = 720
        '  IRC Operator MOTD header, sent upon OPER command
        '  RATBOX:                   :<text>
        'sRPL_OMOTD = 721
        '  IRC Operator MOTD text (repeated, usually)
        '  RATBOX:                   :<text>
        'sRPL_ENDOFOMOTD = 722
        '  IRC operator MOTD footer
        '  RATBOX:                   :<text>
        'sERR_NOPRIVS = 723
        '  Returned from an oper command when the IRC operator does not have the relevant operator privileges.
        '  RATBOX:                   <command> :<text>
        'sRPL_TESTMARK = 724
        '  Reply from an oper command reporting how many users match a given user@host mask
        '  RATBOX:                   <nick>!<user>@<host> <?> <?> :<text>
        'sRPL_TESTLINE = 725
        '  Reply from an oper command reporting relevant I/K lines that will match a given user@host
        '  RATBOX:                   <?> <?> <?> :<?>
        'sRPL_NOTESTLINE = 726
        '  Reply from oper command reporting no I/K lines match the given user@host
        '  RATBOX:                   <?> :<text>
        'sRPL_XINFO = 771
        '  Used to send 'eXtended info' to the client, a replacement for the STATS command to send a large variety of data and minimise numeric pollution.
        '  ITHILDIN
        'sRPL_XINFOSTART = 773
        '  Start of an RPL_XINFO list
        '  ITHILDIN
        'sRPL_XINFOEND = 774
        '  Termination of an RPL_XINFO list
        '  ITHILDIN
        'sERR_CANNOTDOCOMMAND = 972
        '  Works similarly to all of KineIRCd's CANNOT* numerics. This one indicates that a command could not be performed for an arbitrary reason. For example, a halfop trying to kick an op.
        '  UNREAL
        'sERR_CANNOTCHANGEUMODE = 973
        '  Reply to MODE when a user cannot change a user mode
        '  KINEIRCD:                 <mode_char> :<reason>
        'sERR_CANNOTCHANGECHANMODE = 974
        '  Reply to MODE when a user cannot change a channel mode
        '  KINEIRCD:                 <mode_char> :<reason>
        'sERR_CANNOTCHANGESERVERMODE = 975
        '  Reply to MODE when a user cannot change a server mode
        '  KINEIRCD:                 <mode_char> :<reason>
        'sERR_CANNOTSENDTONICK = 976
        '  Returned from NOTICE, PRIVMSG or other commands to notify the user that they cannot send a message to a particular client. Similar to ERR_CANNOTSENDTOCHAN. KineIRCd uses this in conjunction with user-mode +R to allow users to block people who are not identified to services (spam avoidance)
        '  KINEIRCD:                 <nick> :<reason>
        'sERR_UNKNOWNSERVERMODE = 977
        '  Returned by MODE to inform the client they used an unknown server mode character.
        '  KINEIRCD:                 <modechar> :<info>
        'sERR_SERVERMODELOCK = 979
        '  Returned by MODE to inform the client the server has been set mode +L by an administrator to stop server modes being changed
        '  KINEIRCD:                 <target> :<info>
        'sERR_BADCHARENCODING = 980
        '  Returned by any command which may have had the given data modified because one or more glyphs were incorrectly encoded in the current charset (given). Such a use would be where an invalid UTF-8 sequence was given which may be considered insecure, or defines a character which is invalid within that context. For safety reasons, the invalid character is not returned to the client.
        '  KINEIRCD:                 <command> <charset> :<info>
        'sERR_TOOMANYLANGUAGES = 981
        '  Returned by the LANGUAGE command to tell the client they cannot set as many languages as they have requested. To assist the client, the maximum languages which can be set at one time is given, and the language settings are not changed.
        '  KINEIRCD:                 <max_langs> :<info>
        'sERR_NOLANGUAGE = 982
        '  Returned by the LANGUAGE command to tell the client it has specified an unknown language code.
        '  KINEIRCD:                 <language_code> :<info>
        'sERR_TEXTTOOSHORT = 983
        '  Returned by any command requiring text (such as a message or a reason), which was not long enough to be considered valid. This was created initially to combat '/wallops foo' abuse, but is also used by DIE and RESTART commands to attempt to encourage meaningful reasons.
        '  KINEIRCD:                 <command> :<info>
        sERR_NUMERIC_ERR = 999
        '  BAHAMUT:                  :%s 999 %s Numeric error! yikes!
        'sERR_NUMERICERR = 999 (CONFLICTING)
        '  UNREAL
    End Enum

    <DllImport("user32.dll")> _
    Public Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
    End Function

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
        On Error Resume Next
        Dim lCommandData As gCommandReturnData
        lCommandData = ReturnReplacedCommand(lType, p1, p2, p3, p4)
        If Len(lCommandData.cSocketData) <> 0 And Len(lCommandData.cDoColorData) <> 0 Then
            lStatus.SendSocket(lStatusIndex, lCommandData.cSocketData)
            lStatus.AddText(lCommandData.cDoColorData, lStatusIndex)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub ProcessReplaceCommand(lType As eStringTypes, lTextBox As ctlTBox, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String)")
    End Sub

    Private Function FindCommandIndex(ByVal lType As eCommandTypes) As Integer
        On Error Resume Next
        Dim i As Integer
        For i = 1 To lCommands.cCount
            If lType = lCommands.cCommad(i).cCommandType Then
                FindCommandIndex = i
                Exit Function
            End If
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Function FindStringIndex(lType As eStringTypes) As Integer")
    End Function

    Public Function ReturnReplacedCommand(ByVal lType As eCommandTypes, Optional ByVal p1 As String = "", Optional ByVal p2 As String = "", Optional ByVal p3 As String = "", Optional ByVal p4 As String = "") As gCommandReturnData
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnReplacedString(lType As eStringTypes, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String) As String")
    End Function

    Public Function DoesColorExist(ByVal lData As String) As Boolean
        On Error Resume Next
        If Len(lData) <> 0 And InStr(lData, lColorChar) <> 0 Then
            DoesColorExist = True
        Else
            DoesColorExist = False
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function DoesColorExist(ByVal lData As String) As Boolean")
    End Function

    Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        'Try
        Dim i As Integer
        If Len(lStringParameterName) <> 0 Then
            For i = 1 To 100
                If Trim(LCase(ReadINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), ""))) = lStringParameterName Then
                    WriteINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")
                    Exit For
                End If
            Next i
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub RemoveTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)")
        'End Try
    End Sub

    Public Sub AddTextStringParameter(ByVal lTextStringIndex As Integer, ByVal lStringParameterName As String)
        'Try
        Dim i As Integer, n As Integer
        If Len(lStringParameterName) <> 0 Then
            For i = 1 To 100
                If Len(ReadINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(i.ToString), "")) = 0 Then
                    n = i
                    Exit For
                End If
            Next i
            WriteINI(lINI.iText, Trim(lTextStringIndex.ToString), "Find" & Trim(n.ToString), lStringParameterName)
            lStrings.sFixedString(lTextStringIndex).sFind(n) = lStringParameterName
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub AddTextStringParameter(ByVal lStringParameterName As String)")
        'End Try
    End Sub

    Public Sub tDoColor(ByVal lData As String, ByVal lColorTextBox As RichTextBox)
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub DoColor(ByVal lData As String)")
    End Sub

    Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)
        On Error Resume Next
        lColorTextBox.ScrollToCaret()
        lColorTextBox.SelectionStart = 0
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetSelectionStart(ByVal lColorTextBox As RichTextBox)")
    End Sub

    Public Function ConvertIntToSystemColor(ByVal lColor As Integer, Optional lBlackSetting As Boolean = False) As System.Drawing.Color
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ConvertIntToSystemColor(ByVal lColor As Integer) As System.Drawing.Color")
    End Function

    Public Function ReturnRightColorNumeric(ByVal lData As String) As Integer
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnRightNumeric(ByVal lData As String) As Integer")
    End Function

    Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)
        On Error Resume Next
        If Len(lData) <> 0 And lIndex <> 0 Then
            lStrings.sFixedString(lIndex).sData = lData
            WriteINI(lINI.iText, Trim(CStr(lIndex)), "Data", lData)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStringData(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lData As String)
        On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sDescription = lData
            WriteINI(lINI.iText, Trim(CStr(lIndex)), "Description", lData)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStringDescription(ByVal lIndex As Integer, ByVal lDescription As String)")
    End Sub

    Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)
        On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sSyntax = lData
            WriteINI(lINI.iText, Trim(CStr(lIndex)), "Syntax", lData)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStringSyntax(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)
        On Error Resume Next
        If lIndex <> 0 And Len(lData) <> 0 Then
            lStrings.sFixedString(lIndex).sSupport = lData
            WriteINI(lINI.iText, Trim(CStr(lIndex)), "Support", lData)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStringSupport(ByVal lIndex As Integer, ByVal lData As String)")
    End Sub

    Public Sub ResetStrings()
        On Error Resume Next
        lStatus.lIRCMisc.ResetMessages()
        ClearStrings()
        LoadStrings()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub ResetStrings()")
    End Sub

    Public Function FindStringIndexByDescription(ByVal lDescription As String) As Integer
        On Error Resume Next
        Dim i As Integer
        If Len(lDescription) <> 0 Then
            For i = 1 To lStrings.sFixedStringCount
                If LCase(lDescription) = LCase(lStrings.sFixedString(i).sDescription) Then
                    FindStringIndexByDescription = i
                    Exit For
                End If
            Next i
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function FindStringIndexByDescription(lDescription As String) As Integer")
    End Function

    Public Function ReturnStringTypeByDescription(ByVal lDescription As String) As eStringTypes
        On Error Resume Next
        Dim i As Integer
        If Len(lDescription) <> 0 Then
            For i = 1 To 200
                If LCase(lDescription) = LCase(lStrings.sFixedString(i).sDescription) Then
                    ReturnStringTypeByDescription = lStrings.sFixedString(i).sType
                    Exit For
                End If
            Next i
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnStringTypeByDescription(lDescription As String) As eStringTypes")
    End Function

    Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer
        'Try
        Dim i As Integer
        For i = 1 To lStrings.sFixedStringCount
            If lType = lStrings.sFixedString(i).sType Then
                FindStringIndex = i
                Exit Function
            End If
        Next i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Function FindStringIndex(ByVal lType As eStringTypes) As Integer")
        'End Try
    End Function

    Public Sub ProcessReplaceString(ByVal lStatusIndex As Integer, ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "")
        'Try
        Dim msg As String
        If lIRC.iSettings.sNoIRCMessages = True Then Exit Sub
        msg = ReturnReplacedString(lType, r1, r2, r3, r4, r5, r6, r7, r8)
        If ReturnStringCompatibile(lType) = True Then
            If Len(msg) <> 0 Then lStatus.AddText(msg, lStatusIndex)
        Else
            lStatus.AddToUnsupported(lStatusIndex, msg)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ProcessReplaceString()")
        'End Try
    End Sub

    Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean
        On Error Resume Next
        Dim c As Integer = FindStringIndex(lType), i As Integer
        With lStrings.sFixedString(c)
            For i = 1 To lCompatibility.cCount
                If InStr(LCase(Trim(lCompatibility.cCompatibility(i).cDescription)), LCase(Trim(.sSupport))) <> 0 And lCompatibility.cCompatibility(i).cEnabled = True Then
                    ReturnStringCompatibile = True
                    Exit For
                End If
            Next i
        End With
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnStringCompatibile(ByVal lType As eStringTypes) As Boolean")
    End Function

    Public Function ReturnReplacedString(ByVal lType As eStringTypes, Optional ByVal r1 As String = "", Optional ByVal r2 As String = "", Optional ByVal r3 As String = "", Optional ByVal r4 As String = "", Optional ByVal r5 As String = "", Optional ByVal r6 As String = "", Optional ByVal r7 As String = "", Optional ByVal r8 As String = "") As String
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnReplacedString(lType As eStringTypes, Optional r1 As String, Optional r2 As String, Optional r3 As String, Optional r4 As String, Optional r5 As String) As String")
    End Function

    Public Sub SaveTextStrings()
        On Error Resume Next
        Dim i As Integer
        For i = 1 To 200
            If Len(lStrings.sFixedString(i).sData) <> 0 Then
                WriteINI(ReturnTextINI, Trim(Str(i)), "Type", Trim(Str(lStrings.sFixedString(i).sType)))
                WriteINI(ReturnTextINI, Trim(Str(i)), "Data", Trim(lStrings.sFixedString(i).sData))
                If Len(lStrings.sFixedString(i).sFind(1)) <> 0 Then WriteINI(ReturnTextINI, Trim(Str(i)), "Find1", lStrings.sFixedString(i).sFind(1))
                If Len(lStrings.sFixedString(i).sFind(2)) <> 0 Then WriteINI(ReturnTextINI, Trim(Str(i)), "Find2", lStrings.sFixedString(i).sFind(2))
                If Len(lStrings.sFixedString(i).sFind(3)) <> 0 Then WriteINI(ReturnTextINI, Trim(Str(i)), "Find3", lStrings.sFixedString(i).sFind(3))
                If Len(lStrings.sFixedString(i).sFind(4)) <> 0 Then WriteINI(ReturnTextINI, Trim(Str(i)), "Find4", lStrings.sFixedString(i).sFind(4))
                If Len(lStrings.sFixedString(i).sFind(5)) <> 0 Then WriteINI(ReturnTextINI, Trim(Str(i)), "Find5", lStrings.sFixedString(i).sFind(5))
            End If
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SaveTextStrings()")
    End Sub

    Public Function ReturnStringDataByType(ByVal lType As eStringTypes) As String
        On Error Resume Next
        Dim i As Integer
        For i = 1 To 200
            If lStrings.sFixedString(i).sType = lType Then
                ReturnStringDataByType = lStrings.sFixedString(i).sData
                Exit Function
            End If
        Next i
        ReturnStringDataByType = ""
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ReturnStringData(lIndex As Integer) As String")
    End Function

    Public Sub SetStringData(ByVal lType As eStringTypes, ByVal lData As String)
        On Error Resume Next
        Dim i As Integer
        i = FindStringIndex(lType)
        If i <> 0 Then
            lStrings.sFixedString(i).sData = lData
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStringData(lType As eStringTypes)")
    End Sub

    Public Sub ClearStrings()
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub ClearStrings()")
    End Sub

    Public Sub LoadCommands()
        On Error Resume Next
        Dim i As Integer
        ReDim lCommands.cCommad(100)
        lCommands.cCount = CInt(ReadINI(ReturnCommandsINI, "Settings", "Count", "0"))
        For i = 1 To lCommands.cCount
            With lCommands.cCommad(i)
                .cData = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Command", "")
                If Len(.cData) <> 0 Then
                    .cCommandType = CType(ReadINI(ReturnCommandsINI, Trim(Str(i)), "Type", ""), eCommandTypes)
                    .cDisplay = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Display", "")
                    .cParam1 = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param1", "")
                    If Len(.cParam1) <> 0 Then .cParam2 = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param2", "")
                    If Len(.cParam2) <> 0 Then .cParam3 = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param3", "")
                    If Len(.cParam3) <> 0 Then .cParam4 = ReadINI(ReturnCommandsINI, Trim(Str(i)), "Param4", "")
                End If
            End With
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub LoadCommand()")
    End Sub

    Public Sub LoadStrings()
        On Error Resume Next
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

    Public Sub PopulateListViewWithStrings(ByVal lListView As ListView)
        On Error Resume Next
        Dim i As Integer, lItem As ListViewItem, msg As String
        For i = 0 To lStrings.sFixedStringCount
            With lStrings.sFixedString(i)
                msg = .sDescription
                If Len(msg) <> 0 Then
                    lItem = lListView.Items.Add(msg)
                    lItem.SubItems.Add(.sSupport)
                    lItem.SubItems.Add(.sSyntax)
                    lItem.SubItems.Add(Trim(CStr(.sType)))
                    lItem.SubItems.Add(.sData)
                End If
            End With
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub PopulateListViewWithStrings(ByVal lListView As ListView)")
    End Sub

    Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)
        On Error Resume Next
        LockWindowUpdate(lTextBox.Handle)
        lTextBox.Text = lData & vbCrLf & lTextBox.Text
        LockWindowUpdate(IntPtr.Zero)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub DoText(ByVal lData As String, ByVal lTextBox As TextBox)")
    End Sub

    Public Function GetFileTitle(ByVal lFileName As String) As String
        On Error Resume Next
        Dim msg() As String
        msg = Split(lFileName, "\")
        GetFileTitle = msg(UBound(msg))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function GetFileTitle(ByVal lFileName As String) As String")
    End Function

    Public Function StripColorCodes(ByVal lData As String) As String
        'Try
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
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function StripColorCodes(ByVal lData As String) As String")
        'Return Nothing
        'End Try
    End Function

    Public Sub DoColor(lData As String, lTextBox As RichTextBox, Optional _Black As Boolean = False)
        'Try
        Dim i As Integer, msg As String, lBackColor As Integer = 16, lForeColor As Integer, _ScrollToBottom As New clsScrollToBottom
        LockWindowUpdate(lTextBox.Handle)
        If Len(lData.Trim) = 0 Then Exit Sub
        If lQuerySettings.qEnableSpamFilter = True Then
            For i = 1 To lQuerySettings.qSpamPhraseCount
                If InStr(LCase(lData), LCase(lQuerySettings.qSpamPhrases(i).ToString)) <> 0 Then Exit Sub
            Next i
        End If
        lTextBox.SelectionStart = Len(lTextBox.Text)
        lTextBox.SelectionLength = Len(lTextBox.Text)
        lTextBox.SelectedText = vbCrLf
        If InStr(lData, "") <> 0 Then
            For i = 0 To Len(lData)
                If Len(lData) = 0 Then
                    'lTextBox.SelectionStart = lTextBox.Text.Length
                    'lTextBox.SelectionLength = lTextBox.Text.Length
                    'lTextBox.ScrollToCaret()
                    _ScrollToBottom.ScrollToBottom(lTextBox)
                    LockWindowUpdate(IntPtr.Zero)
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
                        lTextBox.SelectedText = msg
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
        _ScrollToBottom.ScrollToBottom(lTextBox)
        LockWindowUpdate(IntPtr.Zero)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub DoColor(lData As String, lTextBox As RichTextBox)")
        'End Try
    End Sub

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function DecodeLongIPAddr(ByVal LongIPAddr As String) As String
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Function DecodeLongIPAddr(ByVal LongIPAddr As String) As String")
    End Function

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function EncodeIPAddr(ByVal lData As String) As String
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Function EncodeIPAddr(ByVal IPAddr As String) As String")
    End Function

    'FIGURE OUT HOW TO FIX THIS SHIT!
    Public Function GetRnd(ByVal lStart As Integer, ByVal lEnd As Integer) As Long
        On Error Resume Next
        Dim i As Long
        Randomize()
        i = lStart + (Rnd() * (lEnd - lStart))
        Return i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Function GetRnd(ByVal lStart As Integer, ByVal lEnd As Integer) As Long")
    End Function

    Public Function DoRight(ByVal lData As String, ByVal lLength As Integer) As String
        On Error Resume Next
        DoRight = Right(lData, lLength).ToString
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function DoRight(ByVal lData As String, ByVal lLength As Integer)")
    End Function

    Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer) As String
        On Error Resume Next
        DoLeft = Left(lData, lLength).ToString
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function DoLeft(ByVal lData As String, ByVal lLength As Integer)")
    End Function

    Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String
        On Error Resume Next
        If Len(lString) <> 0 Then
            LeftRight = lString.Substring(lLeft, lDistance)
        Else
            LeftRight = ""
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function LeftRight(ByVal lString As String, ByVal lLeft As Integer, ByVal lDistance As Integer) As String")
    End Function

    Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String) As String
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Function ParseData(ByVal lWhole As String, ByVal lStart As String, ByVal lEnd As String)")
    End Function
End Module