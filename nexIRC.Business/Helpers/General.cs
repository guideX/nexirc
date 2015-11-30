using System.Windows.Forms;
using Telerik.WinControls.UI;
namespace nexIRC.Business.Helpers {
    /// <summary>
    /// General
    /// </summary>
    public static class General {
        /// <summary>
        /// Set Selected Rad Combo Box Item
        /// </summary>
        /// <param name="dropDown"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool SetSelectedRadComboBoxItem(RadDropDownList dd, string text) {
            var i = 0;
            if ((!string.IsNullOrEmpty(text))) {
                for (i = 1; i <= dd.Items.Count - 1; i++) {
                    if ((text.ToLower().Trim() == dd.Items[i].Text.ToString().ToLower().Trim())) {
                        dd.SelectedIndex = i;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Return First Selected List View Item
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public static ListViewItem ReturnFirstSelectedListViewItem(ListView lv) {
            for (var i = 1; i <= lv.Items.Count - 1; i++) {
                if (lv.Items[i].Selected == true) {
                    return lv.Items[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Does List View Item Exist
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool DoesListViewItemExist(ListView lv, string text) {
            for (var i = 0; i <= lv.Items.Count - 1; i++) {
                if (lv.Items[i].Text.ToLower().Trim() == text.ToLower().Trim()) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Return Rad ListBox Index
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int ReturnRadListBoxIndex(RadListControl lb, string data) {
            for (var i = 0; i <= lb.Items.Count; i++) {
                if (data.ToLower().Trim() == lb.Items[i].Text.ToLower().Trim()) {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// Return List Box Index
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int ReturnListBoxIndex(ListBox lb, string data) {
            for (var i = 0; i <= lb.Items.Count; i++) {
                if (data.ToLower().Trim() == lb.Items[i].ToString().ToLower().Trim()) {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// Find List View Index
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int FindListViewIndex(ListView lv, string text) {
            if (text.Length != 0) {
                for (var i = 0; i <= lv.Items.Count - 1; i++) {
                    if (lv.Items[i].Text.ToLower().Trim() == text.ToLower().Trim()) {
                        return i;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Find RadListView Index
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int FindRadListViewIndex(RadListView lv, string text) {
            if (!string.IsNullOrEmpty(text)) {
                for (var i = 0; i <= lv.Items.Count - 1; i++) {
                    if (lv.Items[i].Text.ToLower().Trim() == text.ToLower().Trim()) {
                        return i;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Does Item Exist in Rad Drop Down
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool DoesItemExistInRadDropDown(RadDropDownList ddl, string text) {
            foreach (var item in ddl.Items) {
                if ((item.Text.Trim().ToLower() == text.Trim().ToLower())) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Find Rad Combo Index
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int FindRadComboIndex(RadDropDownList ddl, string text) {
            if ((!string.IsNullOrEmpty(text))) {
                if ((DoesItemExistInRadDropDown(ddl, text)) == true) {
                    for (var i = 0; i <= ddl.Items.Count; i++) {
                        if ((ddl.Items[i].ToString().Trim().ToLower() == text.Trim().ToLower())) {
                            return i;
                        }
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// Find Combo Index
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int FindComboIndex(ComboBox cb, string text) {
            if ((!string.IsNullOrEmpty(text))) {
                for (var i = 0; i <= cb.Items.Count; i++) {
                    if ((cb.Items[i].ToString().Trim().ToLower() == text.Trim().ToLower())) {
                        return i;
                    }
                }
            }
            return 0;
        }
    }
}