/// <summary>
/// Irc Extensions
/// </summary>
public static class IrcExtensions {
    /// <summary>
    /// Strip Color Codes
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string StripColorCodes(this string data) {
        for (var i = 1; i <= 15; i++) {
            for (var n = 1; n <= 15; n++) {
                var msg2 = "" + i.ToString() + "," + n.ToString();
                if (data.Contains(msg2)) data = data.Replace(msg2, "");
            }
            var msg = "" + i.ToString();
            if (data.Contains(msg)) data = data.Replace(msg, "");
        }
        return data;
    }
}