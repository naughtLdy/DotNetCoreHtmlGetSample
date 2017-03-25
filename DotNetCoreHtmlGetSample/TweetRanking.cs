using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetCoreHtmlGetSample
{
    class TweetRanking
    {
        private static string url = "http://searchranking.yahoo.co.jp/realtime_buzz/";

        public async Task<List<string>> getTweetRanking()
        {
            var doc = new HtmlAgilityPack.HtmlDocument();

            using (var client = new HttpClient())
            using (var stream = await client.GetStreamAsync(url))
            {
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.Load(stream);
                var wordList = htmlDoc.DocumentNode.SelectNodes("//ul[@class=\"patf\"]/li/h3/a")
                    .Where(a => a.InnerText != "")
                    .Select(a => a.InnerText)
                    .ToList<string>();

                return wordList;
            }
        }
    }
}
