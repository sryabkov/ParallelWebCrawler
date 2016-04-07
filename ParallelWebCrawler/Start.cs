using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelWebCrawler
{
    public class Start
    {
        public static void Main()
        {
            var crawler = new Crawler();

            crawler.Crawl("/index.html");

            foreach (var url in crawler.VisitedUrls.OrderBy(n => n))
            {
                Console.WriteLine(url);
            }

        }
    }
}
