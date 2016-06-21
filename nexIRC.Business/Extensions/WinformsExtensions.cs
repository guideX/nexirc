using System;
using System.Windows.Forms;
/// <summary>
/// Winforms Extensions
/// </summary>
public static class WinformsExtensions {
    /// <summary>
    /// Do Text
    /// </summary>
    /// <param name="tb"></param>
    /// <param name="text"></param>
    public static void AppendText(this TextBox tb, string text) {
        tb.Text = text + Environment.NewLine + tb.Text;
    }
    /// <summary>
    /// Does List View Item Exist
    /// </summary>
    /// <param name="lv"></param>
    /// <param name="lData"></param>
    /// <returns></returns>
    public static bool DoesListViewItemExist(this ListView lv, string data) {
        var i = 0;
        var result = false;
        for (i = 0; i <= lv.Items.Count - 1; i++) {
            if (lv.Items[i].Text.ToLower().Trim() == data.ToLower().Trim()) {
                result = true;
                break;
            }
        }
        return result;
    }
}