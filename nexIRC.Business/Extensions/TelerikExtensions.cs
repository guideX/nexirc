using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using Telerik.WinControls.UI;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.RichTextBox.Model;
using nexIRC.Models.String;
/// <summary>
/// Telerik Extensions
/// </summary>
public static class TelerikExtensions {
    /// <summary>
    /// Set Selected Rad ComboBox Item
    /// </summary>
    /// <param name="rddl"></param>
    /// <param name="text"></param>
    public static void SetSelectedRadComboBoxItem(this RadDropDownList rddl, string text) {
        int i = 0;
        if (!string.IsNullOrEmpty(text)) {
            for (i = 1; i <= rddl.Items.Count - 1; i++) {
                if (text.ToLower().Trim() == rddl.Items[i].ToString().ToLower().Trim()) {
                    rddl.SelectedIndex = i;
                    break;
                }
            }
        }
    }
    /// <summary>
    /// Find Rad List View Index
    /// </summary>
    /// <param name="lListView"></param>
    /// <param name="lText"></param>
    /// <returns></returns>
    public static int FindRadListViewIndex(this RadListView lv, string text) {
        int result = 0;
        if (!string.IsNullOrEmpty(text)) {
            for (var i = 0; i <= lv.Items.Count - 1; i++) {
                if (lv.Items[i].Text.ToLower().Trim() == text.ToLower().Trim()) {
                    result = i;
                    break;
                }
            }
        }
        return result;
    }
    /// <summary>
    /// Return Rad List Box Index
    /// </summary>
    /// <param name="lb"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static int ReturnRadListBoxIndex(this RadListControl lb, string data) {
        int result = 0;
        for (var i = 0; i <= lb.Items.Count; i++) {
            if (data.ToLower().ToLower().Trim() == lb.Items[i].ToString().ToLower().Trim()) {
                result = i;
                break;
            }
        }
        return result;
    }
    /// <summary>
    /// Does Item Exist in RadDropDown
    /// </summary>
    /// <param name="rddl"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool DoesItemExistInRadDropDown(this RadDropDownList rddl, string text) {
        foreach (RadListDataItem item in rddl.Items) {
            if (item.Text.Trim().ToLower() == text.Trim().ToLower()) {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// Find Rad Combo Index
    /// </summary>
    /// <param name="rddl"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static int FindRadComboIndex(this RadDropDownList rddl, string text) {
        int result = 0;
        if (!string.IsNullOrEmpty(text)) {
            if (rddl.DoesItemExistInRadDropDown(text)) {
                for (var i = 0; i <= rddl.Items.Count; i++) {
                    if (rddl.Items[i].ToString().Trim().ToLower() == text.Trim().ToLower()) {
                        result = i;
                        break;
                    }
                }
            }
        }
        return result;
    }
    /*



    public int ReturnListBoxIndex(ListBox lListBox, string lData) {
        int i = 0;
        int result = 0;
        try {
            for (i = 0; i <= lListBox.Items.Count; i++) {
                if (Strings.LCase(Strings.Trim(lData)) == Strings.LCase(Strings.Trim(lListBox.Items(i).ToString))) {
                    result = i;
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return result;
        } catch (Exception ex) {
            throw;
            return null;
        }
    }

    public int FindListViewIndex(ListView lListView, string lText) {
        int result = 0;
        int i = 0;
        try {
            if (Strings.Len(lText) != 0) {
                for (i = 0; i <= lListView.Items.Count - 1; i++) {
                    var _with3 = lListView.Items(i);
                    if (Strings.LCase(Strings.Trim(_with3.Text)) == Strings.LCase(Strings.Trim(lText))) {
                        result = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            return result;
        } catch (Exception ex) {
            throw;
            return null;
        }
    }




    public int FindComboIndex(ComboBox comboBox, string text) {
        int i = 0;
        int result = 0;
        try {
            if ((!string.IsNullOrEmpty(text))) {
                var _with6 = comboBox;
                for (i = 0; i <= comboBox.Items.Count; i++) {
                    if ((_with6.Items(i).ToString().Trim().ToLower() == text.Trim().ToLower())) {
                        result = i;
                        break; // TODO: might not be correct. Was : Exit For
                    }
                }
            }
            return result;
        } catch (Exception ex) {
            throw;
            return null;
        }
    }*/
    /// <summary>
    /// Populate With Irc Strings
    /// </summary>
    /// <param name="rlv"></param>
    /// <param name="strings"></param>
    public static void PopulateWithIrcStrings(this RadListView rlv, List<FixedStringModel> strings) {
        rlv.Items.Clear();
        foreach (var item in strings) {
            if (!string.IsNullOrEmpty(item.Description)) {
                var obj = new Telerik.WinControls.UI.ListViewDataItem();
                obj.Text = item.Description;
                obj.SubItems.Add(item.Description);
                obj.SubItems.Add(item.Support);
                obj.SubItems.Add(item.Syntax);
                obj.SubItems.Add(item.Type.ToString().Trim());
                obj.SubItems.Add(item.Data);
                rlv.Items.Add(obj);
            }
        }
        rlv.SelectedIndex = 0;
    }
    /// <summary>
    /// Print
    /// </summary>
    /// <param name="richTextBox"></param>
    /// <param name="data"></param>
    /// <param name="bufferSize"></param>
    public static void Print(this RadRichTextBox richTextBox, string data, int bufferSize = 2000) {
        int n;
        int n2;
        int foreColor = 0;
        int backColor = 0;
        var foreColorSet = false;
        var backColorSet = false;
        var lastWasIrcChar = false;
        var text = "";
        var ircChar = "\u0003";
        Span s;
        if (!string.IsNullOrEmpty(data)) { // If data has something in it
            richTextBox.Document.CaretPosition.MoveToLastPositionInDocument();
            if (richTextBox.RichTextBoxElement.Tag != null && richTextBox.RichTextBoxElement.Tag.ToString() == "1") {
                richTextBox.InsertLineBreak();
            } else {
                richTextBox.RichTextBoxElement.Tag = "1";
            }
            if (!data.Contains(ircChar)) {
                s = new Span(data);
                s.Text = data;
                s.ForeColor = Color.White;
                richTextBox.InsertInline(s);
            } else {
                for (var i = 0; i <= data.Length - 1; i++) {
                    var msg = data[i].ToString();
                    if (msg == ircChar) {
                        lastWasIrcChar = true;
                        if (!string.IsNullOrEmpty(text)) { // Check that the previous collection of text made it to the screen
                            s = new Span(text);
                            if (foreColorSet) { // Check to see if Fore Color is Set
                                s.ForeColor = foreColor.ConvertIntToSystemColor(true); // Convert to System Color
                            } else {
                                s.ForeColor = Color.White; // Set to White
                            }
                            if (backColorSet) { // Check to see if Back Color is Set
                                s.HighlightColor = backColor.ConvertIntToSystemColor(true); // Set BackColor
                            } else {
                                s.HighlightColor = Color.Black; // Set to Black
                            }
                            s.Text = text; // Set Text
                            richTextBox.InsertInline(s); // Insert Line
                            text = ""; // Empty Text Variable
                            backColorSet = false;
                            foreColorSet = false;
                        }
                    } else {
                        if (lastWasIrcChar) {
                            lastWasIrcChar = false;
                            if (!foreColorSet) {
                                if (int.TryParse(msg, out n)) {
                                    foreColor = n;
                                    foreColorSet = true;
                                } else {
                                    text = text + msg;
                                }
                            } else {
                                if (int.TryParse(msg, out n)) {
                                    backColor = n;
                                    backColorSet = true;
                                } else {
                                    text = text + msg;
                                }
                            }
                        } else {
                            text = text + msg;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(text)) { // Check that the previous collection of text made it to the screen
                    s = new Span(text);
                    if (foreColorSet) { // Check to see if Fore Color is Set
                        s.ForeColor = foreColor.ConvertIntToSystemColor(true); // Convert to System Color
                    } else {
                        s.ForeColor = Color.White; // Set to White
                    }
                    if (backColorSet) { // Check to see if Back Color is Set
                        s.HighlightColor = backColor.ConvertIntToSystemColor(true); // Set BackColor
                    } else {
                        s.HighlightColor = Color.Black; // Set to Black
                    }
                    s.Text = text; // Set Text
                    richTextBox.InsertInline(s); // Insert Line
                    text = ""; // Empty Text Variable
                    backColorSet = false;
                    foreColorSet = false;
                }
                var documentElements = new List<Telerik.WinControls.RichTextBox.Model.DocumentElement>();
                foreach (var documentElement in richTextBox.Document.Sections.FirstOrDefault().Children.FirstOrDefault().Children) {
                    documentElements.Add(documentElement);
                }
                documentElements.Reverse();
                var i2 = 0;
                foreach (var element in documentElements) {
                    i2++;
                    if (i2 > bufferSize) {
                        richTextBox.Document.Sections.FirstOrDefault().Children.FirstOrDefault().Children.Remove(element);
                    }
                }
            }
            richTextBox.Document.CaretPosition.MoveToLastPositionInDocument();
        }
    }
}