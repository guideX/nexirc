'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class clsListViewSorter
    Private lListView As ListView
    Private lInitialColumn As Integer
    Private lSortOrder As SortOrder
    Private lColumnSorter As ColumnSorter
    Private lImageList As ImageList

#Region "Header Sort Icon"
    Private Const HDI_WIDTH As Object = &H1
    Private Const HDI_HEIGHT As Object = HDI_WIDTH
    Private Const HDI_TEXT As Object = &H2
    Private Const HDI_FORMAT As Object = &H4
    Private Const HDI_LPARAM As Object = &H8
    Private Const HDI_BITMAP As Object = &H10
    Private Const HDI_IMAGE As Object = &H20
    Private Const HDI_DI_SETITEM As Object = &H40
    Private Const HDI_ORDER As Object = &H80
    Private Const HDI_FILTER As Object = &H100
    Private Const HDF_LEFT As Object = &H0
    Private Const HDF_RIGHT As Object = &H1
    Private Const HDF_CENTER As Object = &H2
    Private Const HDF_JUSTIFYMASK As Object = &H3
    Private Const HDF_RTLREADING As Object = &H4
    Private Const HDF_OWNERDRAW As Object = &H8000
    Private Const HDF_STRING As Object = &H4000
    Private Const HDF_BITMAP As Object = &H2000
    Private Const HDF_BITMAP_ON_RIGHT As Object = &H1000
    Private Const HDF_IMAGE As Object = &H800
    Private Const HDF_SORTUP As Object = &H400
    Private Const HDF_SORTDOWN As Object = &H200
    Private Const LVM_FIRST As Object = &H1000
    Private Const LVM_GETHEADER As Object = LVM_FIRST + 31
    Private Const HDM_FIRST As Object = &H1200
    Private Const HDM_SETIMAGELIST As Object = HDM_FIRST
    Private Const HDM_GETIMAGELIST As Object = HDM_FIRST
    Private Const HDM_GETITEM As Object = HDM_FIRST
    Private Const HDM_SETITEM As Object = HDM_FIRST
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As IntPtr, ByRef lParam As HDITEM) As Integer
    Private Declare Function SendMessageLong Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    Private Enum ArrowType
        Ascending
        Descending
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure HDITEM
        Public mask As Int32
        Public cxy As Int32
        <MarshalAs(UnmanagedType.LPStr)> Public pszText As String
        Public hbm As IntPtr
        Public cchTextMax As Int32
        Public fmt As Int32
        Public lParam As Int32
        Public iImage As Int32
        Public iOrder As Int32
    End Structure

    Public Property ListViewRef() As ListView
        Get
            Return lListView
        End Get
        Set(ByVal Value As ListView)
            lListView = Value
        End Set
    End Property

    Public Property Column() As Integer
        Get
            Return lInitialColumn
        End Get
        Set(ByVal Value As Integer)
        End Set
    End Property

    Public Property SortOrder() As SortOrder
        Get
            Return lSortOrder
        End Get
        Set(ByVal Value As SortOrder)
        End Set
    End Property

    Private Sub SetHeaderImageList(ByVal l As ListView, ByVal lImageList As ImageList)
        On Error Resume Next
        Dim hHeader As IntPtr = SendMessageLong(l.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero)
        SendMessageLong(hHeader, HDM_SETIMAGELIST, IntPtr.Zero, lImageList.Handle)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SetHeaderImageList(ByVal l As ListView, ByVal lImageList As ImageList)")
    End Sub

    Private Sub ShowHeaderIcon(ByVal Col As Integer, ByVal Order As SortOrder)
        On Error Resume Next
        Dim hHeader As IntPtr = SendMessageLong(lListView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero), colHdr As ColumnHeader = lListView.Columns(Col), hd As HDITEM = New HDITEM()
        hd.mask = HDI_IMAGE Or HDI_FORMAT
        Dim align As HorizontalAlignment = colHdr.TextAlign
        hd.fmt = HDF_RIGHT Or HDF_STRING
        If Order <> SortOrder.None Then hd.fmt = hd.fmt Or HDF_IMAGE
        hd.iImage = 0
        SendMessage(hHeader, HDM_SETITEM, New IntPtr(Col), hd)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub ShowHeaderIcon(ByVal Col As Integer, ByVal Order As SortOrder)")
    End Sub
#End Region

    Public Sub New(ByVal lLV As ListView)
        'Try
        lInitialColumn = 0
        lSortOrder = SortOrder.None
        lListView = lLV
        AddHandler lListView.ColumnClick, AddressOf lListView_ColumnClick
        lColumnSorter = New ColumnSorter(Me)
        lImageList = New ImageList()
        With lImageList
            .ImageSize = New Size(8, 8)
            .TransparentColor = System.Drawing.Color.Magenta
        End With
        SetHeaderImageList(lListView, lImageList)
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub New(ByVal lLV As ListView)")
        'End Try
    End Sub

    Private Sub lListView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        'Try
        Dim lSortOrder As SortOrder
        If e.Column = lInitialColumn Then
            If lSortOrder = SortOrder.None OrElse lSortOrder = SortOrder.Descending Then
                lSortOrder = SortOrder.Ascending
            Else
                lSortOrder = SortOrder.Descending
            End If
        Else
            lSortOrder = SortOrder.Ascending
        End If
        lInitialColumn = e.Column
        lSortOrder = lSortOrder
        If lListView.ListViewItemSorter Is Nothing Then
            lListView.ListViewItemSorter = lColumnSorter
        End If
        lColumnSorter.SetColumnType()
        lListView.Sort()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub lListView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)")
        'End Try
    End Sub

    Public Sub ReInitSorter()
        'Try
        lInitialColumn = 0
        lSortOrder = SortOrder.None
        lListView.ListViewItemSorter = Nothing
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub ReInitSorter()")
        'End Try
    End Sub
End Class

Friend Class ColumnSorter
    Implements IComparer

    Private Enum ColumnType
        Text = 1
        Numeric
        DateTime
    End Enum

    Private eColType As ColumnType
    Private olvs As clsListViewSorter

    Public Sub New(ByVal lvs As clsListViewSorter)
        'Try
        olvs = lvs
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub New(ByVal lvs As clsListViewSorter)")
        'End Try
    End Sub

    Public Sub SetColumnType()
        'Try
        eColType = DetectColumnType()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Sub SetColumnType()")
        'End Try
    End Sub

    Private Function DetectColumnType() As ColumnType
        Dim i As Integer, n As Integer, t As Integer, d As Double, lDate As Date, lItem As ListViewItem, msg As String
        t = olvs.Column
        'Try
        For Each lItem In olvs.ListViewRef.Items
            msg = lItem.SubItems(t).Text
            If msg.Length > 0 Then
                If i > 0 Then
                    Try
                        d = Double.Parse(msg)
                    Catch
                        Return ColumnType.Text
                    End Try
                ElseIf n > 0 Then
                    Try
                        lDate = Date.Parse(msg)
                    Catch
                        Return ColumnType.Text
                    End Try
                Else
                    Try
                        d = Double.Parse(msg)
                        i += 1
                    Catch
                        Try
                            lDate = Date.Parse(msg)
                            n += 1
                    Catch
                            Return ColumnType.Text
                        End Try
                    End Try
                End If
            End If
        Next
        If n > 0 Then Return ColumnType.DateTime
        If i > 0 Then Return ColumnType.Numeric
        Return ColumnType.Text
        'Catch ex As Exception
        'ProcessError(ex.Message, "DetectColumnType")
        'End Try
    End Function

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        'Try
        Dim lItem1 As ListViewItem, lItem2 As ListViewItem, msg As String, msg2 As String, i As Integer
        lItem1 = CType(x, ListViewItem)
        lItem2 = CType(y, ListViewItem)
        msg = lItem1.SubItems(olvs.Column).Text
        msg2 = lItem2.SubItems(olvs.Column).Text
        Select Case eColType
            Case ColumnType.Text
                i = String.Compare(msg, msg2)
            Case ColumnType.Numeric
                i = 0
                If Double.Parse(msg) > Double.Parse(msg2) Then i = 1
                If Double.Parse(msg) < Double.Parse(msg2) Then i = -1
            Case ColumnType.DateTime
                i = Date.Compare(CType(msg, Date), CType(msg2, Date))
        End Select
        If olvs.SortOrder = SortOrder.Descending Then
            i *= -1
        End If
        Return i
        'Catch ex As Exception
        'ProcessError(ex.Message, "Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare")
        'End Try
    End Function
End Class