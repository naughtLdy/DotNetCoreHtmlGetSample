using System;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreHtmlGetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            tweetList().Wait();
        }

        private static async Task tweetList()
        {
            var tweetRanking = new TweetRanking();
            var tweetList = await tweetRanking.getTweetRanking();

            foreach (var tweet in tweetList)
            {
                Console.WriteLine("{0}", tweet);
            }
        }
    }
}