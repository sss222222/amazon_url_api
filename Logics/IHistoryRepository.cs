namespace amazon.Logics
{
    public interface IHistoryRepository
    {
        string Save(string url, string shortUrl);
        string Search(string url);
    }
}