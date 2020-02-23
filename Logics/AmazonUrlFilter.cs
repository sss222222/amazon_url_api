using System;
using System.Text.RegularExpressions;

namespace amazon.Logics
{
    public class AmazonUrlFilter : IAmazonUrlFilter
    {
        private static readonly string AmazonUrlPrefix = "https://www.amazon.co.jp/";
        private readonly IHistoryRepository _history;
        public AmazonUrlFilter(IHistoryRepository history)
        {
            _history = history;
        }
        public string Apply(string url)
        {
            if (!url.Contains(AmazonUrlPrefix))
            {
                throw new Exception("Non Amazon url");
            }
            string historyUrl = _history.Search(url);
            if (historyUrl != null)
            {
                return "Old:" + historyUrl;
            }
            Match productId = Regex.Match(url, "/(dp/.+)" + Regex.Escape("?"));
            string shortUrl = AmazonUrlPrefix + productId.Groups[1];
            _history.Save(url, shortUrl);
            return shortUrl;
        }
    }
}