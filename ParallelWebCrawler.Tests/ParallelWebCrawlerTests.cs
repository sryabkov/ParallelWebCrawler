﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics;

namespace ParallelWebCrawler.Tests
{
    [TestFixture]
    public class ParallelWebCrawlerTests
    {
        [Test]
        public void CrawlerWorksCorrectly()
        {

            var expectedResult = new string[] {
                "/index.html",
                "/section1/index.html",
                "/section1/subsection1/index.html",
                "/section1/subsection1/page1.html",
                "/section1/subsection1/page2.html",
                "/section1/subsection2/index.html",
                "/section1/subsection2/page1.html",
                "/section1/subsection2/page2.html",
                "/section1/subsection3/index.html",
                "/section1/subsection3/page1.html",
                "/section1/subsection3/page2.html",
                "/section1/subsection4/index.html",
                "/section1/subsection4/page1.html",
                "/section1/subsection4/page2.html",
                "/section2/index.html",
                "/section2/page1.html",
                "/section2/page2.html",
                "/section3/index.html",
                "/section3/page1.html",
                "/section3/page2.html",
                "/section4/index.html",
                "/section4/page1.html",
                "/section4/page2.html",
                };

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var crawler = new Crawler();

            //set the initial URL
            crawler.SetInitialUrl("/index.html");

            //start a couple of worker tasks
            var task1 = Task.Factory.StartNew(() => crawler.Crawl(cancellationToken), 
                cancellationToken);
            var task2 = Task.Factory.StartNew(() => crawler.Crawl(cancellationToken), 
                cancellationToken);

            var taskCancel = Task.Run(async () =>
            {
                //wait 15 seconds and send the cancel signal to the worker tasks,
                //which will otherwise never end
                await Task.Delay(TimeSpan.FromSeconds(15));
                cancellationTokenSource.Cancel();
            });

            try
            {
                Task.WaitAll(task1, task2, taskCancel);
                foreach (var url in crawler.VisitedUrls.OrderBy(n => n))
                {
                    Trace.WriteLine(url);
                }
            }
            catch (AggregateException e)
            {
                foreach (var v in e.InnerExceptions)
                    Trace.WriteLine(e.Message + " " + v.Message);
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

            Assert.That(crawler.VisitedUrls.OrderBy(n => n), Is.EquivalentTo(expectedResult));

        }

    }
}
