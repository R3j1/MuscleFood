using Business.Dtos.Interface;
using System.Text.RegularExpressions;

namespace Business.Dtos
{
    public class FormatUrl : IFormat, IFormatUrl
    {
        public string AppendDotCoDotUK(string Url)
        {
            return $"{Url}.co.uk";
        }

        public string AppendDotCom(string Url)
        {
            return $"{Url}.com";
        }

        public string AppendHTTPSAndWWWHeader(string Url)
        {
            return $"https://www.{Url}";
        }

        public string RemoveHTTPAndWWWFromUrl(string Url)
        {
            return Url.Replace("https://www.", string.Empty);
        }

        public string RemoveDotComFromUrl(string Url)
        {
            return Url.Replace(".com", string.Empty);
        }

        public string RemoveSecialChars(string Url)
        {
            return Regex.Replace(Url, @"[^0-9a-zA-Z\._]", string.Empty);
        }

        public string RelaceDotWithPlusChar(string Url)
        {
            return Url.Replace(".", "+");
        }

        public bool IsEncryptedUrl(string Url)
        {
            return Url.Contains("&Encrypted=True");
        }

        public string AppendEncryptedTag(string Url)
        {
            return $"{Url}&Encrypted=True";
        }

        public string RemoveEncryptedTagFromUrl(string Url)
        {
            return Url.Replace("&Encrypted=True", string.Empty);
        }
    }
}
