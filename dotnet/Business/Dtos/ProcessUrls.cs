using Business.Dtos;
using Business.Dtos.Interface;

namespace Business
{
    public class ProcessUrls
    {
        private readonly IUrlManager _urlManager;
        private readonly FormatUrl formatter;
        public ProcessUrls(IUrlManager IUrlManager)
        {
            _urlManager = IUrlManager;
            formatter = new FormatUrl();
        }

        public string EncodeUrl(string Url)
        {
            return _urlManager.Encode(Url);
        }

        public string DecodeUrl(string Url)
        {
            return _urlManager.Decode(Url);
        }

        public string EncodProcessor(string Url)
        {
            if (!formatter.IsEncryptedUrl(Url))
            {
                string retVal = EncodeUrl(Url);
                retVal = formatter.AppendHTTPSAndWWWHeader(retVal);
                retVal = formatter.AppendEncryptedTag(retVal);
                retVal = formatter.AppendDotCom(retVal);
                return retVal;
            }
            return Url;
        }

        public string DecodeProcessor(string Url)
        {
            string retVal = formatter.RemoveHTTPAndWWWFromUrl(Url);
            retVal = formatter.RemoveEncryptedTagFromUrl(retVal);
            retVal = formatter.RemoveDotComFromUrl(retVal);
            return DecodeUrl(retVal);
        }
    }
}
