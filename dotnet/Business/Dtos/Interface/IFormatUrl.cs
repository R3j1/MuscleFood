namespace Business.Dtos.Interface
{
    public interface IFormatUrl
    {
        string AppendHTTPSAndWWWHeader(string Url);
        string AppendDotCom(string Url);
        string AppendDotCoDotUK(string Url);
    }
}
