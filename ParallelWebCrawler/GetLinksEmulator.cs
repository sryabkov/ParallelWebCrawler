using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelWebCrawler
{
    public static class GetLinksEmulator
    {
        public async static Task<string[]> GetLinks(string Url)
        {
            string[] result = null;

            switch (Url)
            {
                case "/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section1/subsection1/index.html",
                        "/section1/subsection2/index.html",
                        "/section1/subsection3/index.html",
                        "/section1/subsection4/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/section1/subsection3/index.html", //local repeat
                        "/index.html" //circular reference
                    };
                    break;

                case "/section1/subsection1/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000); result = new string[] {
                        "/section1/subsection1/page1.html",
                        "/section1/subsection1/page2.html",
                        "/section1/subsection1/index.html", //circular reference
                        "/section1/subsection2/index.html",
                        "/section1/subsection3/index.html",
                        "/section1/subsection4/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section1/subsection2/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section1/subsection2/page1.html",
                        "/section1/subsection2/page2.html",
                        "/section1/subsection2/index.html", //circular reference
                        "/section1/subsection1/index.html",
                        "/section1/subsection3/index.html",
                        "/section1/subsection4/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section1/subsection3/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section1/subsection3/page1.html",
                        "/section1/subsection3/page2.html",
                        "/section1/subsection3/index.html", //circular reference
                        "/section1/subsection1/index.html",
                        "/section1/subsection2/index.html",
                        "/section1/subsection4/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section1/subsection4/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section1/subsection4/page1.html",
                        "/section1/subsection4/page2.html",
                        "/section1/subsection4/index.html", //circular reference
                        "/section1/subsection1/index.html",
                        "/section1/subsection2/index.html",
                        "/section1/subsection3/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section2/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section2/page1.html",
                        "/section2/page2.html",
                        "/section2/index.html", //circular reference
                        "/section1/index.html",
                        "/section3/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section3/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section3/page1.html",
                        "/section3/page2.html",
                        "/section3/index.html", //circular reference
                        "/section1/index.html",
                        "/section2/index.html",
                        "/section4/index.html",
                        "/index.html" //circular reference
                    };
                    break;

                case "/section4/index.html":
                    //emulate delay while reading a page
                    await Task.Delay(1000);
                    result = new string[] {
                        "/section4/page1.html",
                        "/section4/page2.html",
                        "/section4/index.html", //circular reference
                        "/section1/index.html",
                        "/section2/index.html",
                        "/section3/index.html",
                        "/index.html" //circular reference
                    };
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
