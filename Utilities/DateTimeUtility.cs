namespace MiSAT.Utilities
{
    internal static class DateTimeUtility
    {
        internal static string ToXmlString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        internal static string ToXmlStringUtc(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }
    }
}
