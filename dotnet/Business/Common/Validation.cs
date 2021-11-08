using System;

namespace Business.Common
{
    public static class Validation
    {
        public static bool IsValidUrl(string Url)
        {
            return !string.IsNullOrEmpty(Url) && Uri.IsWellFormedUriString(Url, UriKind.Absolute);
        }

        public static bool IsValidEncodedUrl(String Url)
        {
            return IsValidUrl(Url.Replace("+", string.Empty));
        }
    }
}
