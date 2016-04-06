using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelWebCrawler
{
    public static class GetLinksEmulator
    {
        public static IEnumerable<string> GetLinks(string Url)
        {
            switch (Url)
            {
                case "/index.html":
                    Task.Delay(1000);
                    yield return "/section1/subsection1/index.html";
                    yield return "/section1/subsection2/index.html";
                    yield return "/section1/subsection3/index.html";
                    yield return "/section1/subsection4/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/section1/subsection3/index.html"; //local repeat
                    yield return "/index.html"; //circular reference
                    break;
                case "/section1/subsection1/index.html":
                    Task.Delay(1000);
                    yield return "/section1/subsection1/page1.html";
                    yield return "/section1/subsection1/page2.html";
                    yield return "/section1/subsection1/index.html"; //circular reference
                    yield return "/section1/subsection2/index.html";
                    yield return "/section1/subsection3/index.html";
                    yield return "/section1/subsection4/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section1/subsection2/index.html":
                    Task.Delay(1000);
                    yield return "/section1/subsection2/page1.html";
                    yield return "/section1/subsection2/page2.html";
                    yield return "/section1/subsection2/index.html"; //circular reference
                    yield return "/section1/subsection1/index.html";
                    yield return "/section1/subsection3/index.html";
                    yield return "/section1/subsection4/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section1/subsection3/index.html":
                    Task.Delay(1000);
                    yield return "/section1/subsection3/page1.html";
                    yield return "/section1/subsection3/page2.html";
                    yield return "/section1/subsection3/index.html"; //circular reference
                    yield return "/section1/subsection1/index.html";
                    yield return "/section1/subsection2/index.html";
                    yield return "/section1/subsection4/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section1/subsection4/index.html":
                    Task.Delay(1000);
                    yield return "/section1/subsection4/page1.html";
                    yield return "/section1/subsection4/page2.html";
                    yield return "/section1/subsection4/index.html"; //circular reference
                    yield return "/section1/subsection1/index.html";
                    yield return "/section1/subsection2/index.html";
                    yield return "/section1/subsection3/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section2/index.html":
                    Task.Delay(1000);
                    yield return "/section2/page1.html";
                    yield return "/section2/page2.html";
                    yield return "/section2/index.html"; //circular reference
                    yield return "/section1/index.html";
                    yield return "/section3/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section3/index.html":
                    Task.Delay(1000);
                    yield return "/section3/page1.html";
                    yield return "/section3/page2.html";
                    yield return "/section3/index.html"; //circular reference
                    yield return "/section1/index.html";
                    yield return "/section2/index.html";
                    yield return "/section4/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                case "/section4/index.html":
                    Task.Delay(1000);
                    yield return "/section4/page1.html";
                    yield return "/section4/page2.html";
                    yield return "/section4/index.html"; //circular reference
                    yield return "/section1/index.html";
                    yield return "/section2/index.html";
                    yield return "/section3/index.html";
                    yield return "/index.html"; //circular reference
                    break;
                default:
                    break;
            }
        }
    }
}
