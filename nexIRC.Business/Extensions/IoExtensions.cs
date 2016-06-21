using System.IO;
/// <summary>
/// IO Extensions
/// </summary>
public static class IoExtensions {
    /// <summary>
    /// File Title
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static string FileTitle(this string file) {
        var fi = new FileInfo(file);
        return fi.Name;
    }
}