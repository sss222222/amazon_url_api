using System;

namespace amazon.Logics
{
    public interface IAmazonUrlFilter
    {
        string Apply(string url);
    }
}