using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelWebCrawler
{
    public class Crawler
    {
        private readonly object _lock = new object();
        private HashSet<string> _visitedUrls = new HashSet<string>();
        //private TaskQueue _taskQueue = new TaskQueue(2);

        public IEnumerable<string> VisitedUrls => _visitedUrls;

        public void Crawl(string url)
        {

            if (!_visitedUrls.Contains(url))
            {
                _visitedUrls.Add(url);
            }

            string[] links = GetLinksEmulator.GetLinks(url);

            if (links != null)
            {
                foreach (var link in links)
                {

                    if (!_visitedUrls.Contains(link))
                    {
                        _visitedUrls.Add(link);
                        this.Crawl(link);
                    }
                }
            }
        }
    }
}
