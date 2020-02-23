using System;
using amazon.Logics;
using System.Collections.Generic;
using amazon.Infrastructures;
using System.Linq;

namespace amazon.Repositories
{
    public class HistoryDbRepository : IHistoryRepository
    {
        private HistoryContext _context;

        public HistoryDbRepository(HistoryContext context)
        {
            _context = context;
        }

        public string Save(string url, string shortUrl)
        {
            var history = new History { Url = url, ShortUrl = shortUrl };
            _context.Histories.Add(history);
            _context.SaveChanges();
            return shortUrl;
        }

        public string Search(string url)
        {
            var history = _context.Histories.FirstOrDefault(h => h.Url == url);
            if (history == null)
            {
                return null;
            }
            return history.ShortUrl;
        }
    }
}