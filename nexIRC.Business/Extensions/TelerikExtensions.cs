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