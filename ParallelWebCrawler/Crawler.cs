using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ParallelWebCrawler
{
    public class Crawler
    {
        /// <summary>
        /// Concurrent dictionary that contains URLs that have already been processed
        /// </summary>
        private ConcurrentDictionary<string, string> _visitedUrls = 
            new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Queue of URLs that need to be processed
        /// </summary>
        private BufferBlock<string> workQueue = 
            new BufferBlock<string>(new DataflowBlockOptions { BoundedCapacity = 100 });

        public IEnumerable<string> VisitedUrls => _visitedUrls.Keys;

        public void SetInitialUrl(string url)
        {
            workQueue.Post(url);
        }


        public async Task Crawl(CancellationToken cancellationToken
            = default(CancellationToken))
        {
            if (cancellationToken.IsCancellationRequested == true)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            while (true)
            {
                string url;

                url = await workQueue.ReceiveAsync(cancellationToken);

                await ProcessUrl(url, cancellationToken);
            }
        }

        private async Task ProcessUrl(string url, CancellationToken cancellationToken
            = default(CancellationToken))
        {
            if (url == null) throw new ArgumentNullException(url);

            if (cancellationToken.IsCancellationRequested == true)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }

            _visitedUrls.TryAdd(url, null);

            string[] links = await GetLinksEmulator.GetLinks(url, cancellationToken);

            if (links == null) return;

            foreach (var link in links)
            {
                if (_visitedUrls.TryAdd(link, null))
                {
                    //the URL is not yet in the dictionary
                    await workQueue.SendAsync(link, cancellationToken);
                }
            }
        }
    }
}
