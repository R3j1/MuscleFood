namespace Business.Dtos.Interface
{
    public interface IUrlManager
    {
        string Encode(string Url);
        string Decode(string Url);
    }
}
