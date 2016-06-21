using System.Drawing;
/// <summary>
/// Drawing Extensions
/// </summary>
public static class DrawingExtensions {
    /// <summary>
    /// Convert Into to System Color
    /// </summary>
    /// <param name="lColor"></param>
    /// <param name="lBlackSetting"></param>
    /// <returns></returns>
    public static System.Drawing.Color ConvertIntToSystemColor(this int lColor, bool lBlackSetting = false) {
        var functionReturnValue = default(System.Drawing.Color);
        switch (lColor) {
            case 0:
                if (lBlackSetting == true) {
                    functionReturnValue = Color.White;
                } else {
                    functionReturnValue = Color.Black;
                }
                break;
            case 1:
                if (lBlackSetting == true) {
                    functionReturnValue = Color.White;
                } else {
                    functionReturnValue = Color.Black;
                }
                break;
            case 2:
                functionReturnValue = Color.DarkBlue;
                break;
            case 3:
                functionReturnValue = Color.Coral;
                break;
            case 4:
                functionReturnValue = Color.Red;
                break;
            case 5:
                functionReturnValue = Color.DarkRed;
                break;
            case 6:
                functionReturnValue = Color.Purple;
                break;
            case 7:
                functionReturnValue = Color.Orange;
                break;
            case 8:
                functionReturnValue = Color.Yellow;
                break;
            case 9:
                functionReturnValue = Color.LightGreen;
                break;
            case 10:
                functionReturnValue = Color.Turquoise;
                break;
            case 11:
                functionReturnValue = Color.Aquamarine;
                break;
            case 12:
                functionReturnValue = Color.Blue;
                break;
            case 13:
                functionReturnValue = Color.Pink;
                break;
            case 14:
                functionReturnValue = Color.Cyan;
                break;
            case 15:
                functionReturnValue = Color.Gray;
                break;
            case 16:
                if (lBlackSetting == true) {
                    functionReturnValue = Color.Black;
                } else {
                    functionReturnValue = Color.White;
                }
                break;
        }
        return functionReturnValue;
    }
}