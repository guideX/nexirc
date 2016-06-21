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
}