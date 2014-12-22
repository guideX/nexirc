'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On

Public Class ListViewSorter
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        Try
            col = 0
            order = SortOrder.Ascending
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(column As Integer, order As SortOrder)
        Try
            col = column
            Me.order = order
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function Compare(x As Object, y As Object) As Integer Implements System.Collections.IComparer.Compare
        Try
            Dim returnVal As Integer = -1
            returnVal = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            If (order = SortOrder.Descending) Then returnVal *= -1
            Return returnVal
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function
End Class