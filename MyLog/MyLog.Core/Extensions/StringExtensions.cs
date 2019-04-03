namespace MyLog.Core.Extensions
{
    public static class StringExtensions
    {
        public static void GetParts(this string s, string separator, out string firstPart, out string secondPart)
        {
            var firstPartEnd = s.IndexOf(separator);
            firstPart = s.Substring(0, firstPartEnd);
            secondPart = s.Substring(firstPartEnd + separator.Length);
        }
    }
}
