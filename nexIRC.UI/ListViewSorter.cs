using System;
using System.Windows.Forms;
using System.Collections;
public class ListViewSorter : IComparer
{
    private int col;

    private SortOrder order;
    public ListViewSorter()
    {
        try
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public ListViewSorter(int column, SortOrder order)
    {
        try
        {
            col = column;
            this.order = order;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Compare(object x, object y)
    {
        try
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            if ((order == SortOrder.Descending))
                returnVal *= -1;
            return returnVal;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}