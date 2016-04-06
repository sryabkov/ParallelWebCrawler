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
        private TaskQueue _taskQueue = new TaskQueue(2);

        public IEnumerable<string> VisitedUrls
        {
            get
            {
                foreach (var url in _visitedUrls)
                {
                    yield return url;
                }
            }
        }

        public void StartCrawling(string url)
        {
            _taskQueue.Enqueue(() => this.Crawl(url));
        }

        public void Crawl(string url)
        {
            lock (_lock)
            {
                if (!_visitedUrls.Contains(url))
                {
                    _visitedUrls.Add(url);
                }
            }

            foreach (var link in GetLinksEmulator.GetLinks(url))
            {
                lock (_lock)
                {
                    if( !_visitedUrls.Contains(link) )
                    {
                        _visitedUrls.Add(link);
                        _taskQueue.Enqueue(() => this.Crawl(link));
                    }
                }
            }
        }
    }
}
