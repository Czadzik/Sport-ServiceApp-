using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
namespace SportNewsService
{
    static class  ContentDownloader
    {
        public static string  DownloadContent(string html)
        {
            string Description = "nic";
            var url = html;
            var web = new HtmlWeb();
            var doc = web.Load(url);
            string Output;
            try
            {
                doc.DocumentNode.Descendants()
                .Where(n => n.Name == "script" || n.Name == "style")
                .ToList()
                .ForEach(n => n.Remove());
                HtmlNodeCollection divContainer = doc.DocumentNode.SelectNodes("//div[@class='news__description']");
                var div = doc.DocumentNode.SelectSingleNode("//div[@class='teaser-content']/div");
                
                if (divContainer != null)
                {
                    foreach (var node in divContainer)
                    {

                        Description  = node.InnerText;
                        return Description;
                    }
                }
                else
                {
                    string error = "could not find text";
                    return error;
                }
                Console.WriteLine(Description);
            }
            catch (Exception)
            {
                return "Błąd pobierania";
            }

            return "Bład";

        }
    }

}