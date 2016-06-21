//nexIRC 3.0.31
//05-30-2016 - guideX
using System;
using System.Collections;
using System.Windows.Forms;
namespace nexIRC.Business.UI.ListView {
    /// <summary>
    /// List View Sorter
    /// </summary>
    public class ListViewSorter : IComparer {
        /// <summary>
        /// Col
        /// </summary>
        private int _col;
        /// <summary>
        /// Order
        /// </summary>
        private SortOrder _order;
        /// <summary>
        /// Entry Point
        /// </summary>
        public ListViewSorter() {
            _col = 0;
            _order = SortOrder.Ascending;
        }
        /// <summary>
        /// List View Sorter
        /// </summary>
        /// <param name="column"></param>
        /// <param name="order"></param>
        public ListViewSorter(int column, SortOrder order) {
            _col = column;
            _order = order;
        }
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y) {
            var returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[_col].Text, ((ListViewItem)y).SubItems[_col].Text);
            if ((_order == SortOrder.Descending)) {
                returnVal *= -1;
            }
            return returnVal;
        }
    }
}