using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace amazon.Infrastructures
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }
        public DbSet<History> Histories { get; set; }
    }
}