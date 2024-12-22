using System;

namespace Helpers
{
    public static class StringSplitter
    {
        public static string ExtractString(string stringToExtractFrom, string[] seperator)
        {
            string extratedString = stringToExtractFrom.Split(seperator, StringSplitOptions.None)[1];
            return extratedString;
        }
    }
}
