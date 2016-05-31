public static class MemberExtensions {
    /// <summary>
    /// To Int
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static int ToInt(this double d) {
        int n;
        if (int.TryParse(d.ToString(), out n)) {
            return n;
        } else {
            return 0;
        }
    }
    /// <summary>
    /// To Int
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int ToInt(this string s) {
        int n;
        if (int.TryParse(s, out n)) {
            return n;
        } else {
            return 0;
        }
    }
    /// <summary>
    /// To Long
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static long ToLong(this string s) {
        long l;
        if (long.TryParse(s, out l)) {
            return l;
        } else {
            return 0;
        }
    }
}