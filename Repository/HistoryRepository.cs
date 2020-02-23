using System;
using amazon.Logics;
using System.Collections.Generic;

namespace amazon.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private Dictionary<string, string> history;

        public HistoryRepository()
        {
            history = new Dictionary<string, string>();
        }

        public string Save(string url, string shortUrl)
        {
            history.Add(url, shortUrl);
            return shortUrl;
        }

        public string Search(string url)
        {
            if (!history.ContainsKey(url))
            {
                return null;
            }
            return history[url];
        }
    }
}