#define UseNewsApiSample  // Remove or undefine to use your own code to read live data

using News.Models;
using News.ModelsSampleData;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace News.Services
{
    public class NewsService
    {
        readonly string apiKey = "1c303ad1bdf24633a8ffb88d612aa4e2";

//#if UseNewsApiSample
        //
        //USING LIVE NEWS DATA
        //

        public async Task<NewsGroup> GetNewsAsync(NewsCategory category)
        {
            // Your code here to get live data
            //https://newsapi.org/docs/endpoints/top-headlines
            var uri = $"https://newsapi.org/v2/top-headlines?country=se&category={category}&apiKey={apiKey}";

            DateTime dt = DateTime.Now;
            NewsCacheKey key = new(category, dt);
            NewsGroup news = new NewsGroup();

            if (!key.CacheExist)
            {
                news = await ReadWebApiAsync(uri, category);
                NewsGroup.Serialize(news, key.FileName);
                // NewsAvailable?.Invoke(news, $"news in category is available: {category}");
            }

            else
            {
                news = NewsGroup.Deserialize(key.FileName);
                // NewsAvailable?.Invoke(key, $"XML CACHED news in category is available: {category}");
            }

            return news;
        }
        private async Task<NewsGroup> ReadWebApiAsync(string uri, NewsCategory category)
        {

            var webclient = new WebClient();
            var json = await webclient.DownloadStringTaskAsync(uri);


            NewsApiData nd = Newtonsoft.Json.JsonConvert.DeserializeObject<NewsApiData>(json);

            DateTime dt = DateTime.Now;
            NewsCacheKey key = new(category, dt);

            NewsGroup news = new NewsGroup()
            {
                Category = category

            };

            news.Articles = nd.Articles.Select(x => new NewsItem
            {
                Title = x.Title,
                Description = x.Description,
                Url = x.Url,
                UrlToImage = x.UrlToImage,
                DateTime = x.PublishedAt,
            }).ToList();

            return news;
        }

//#else

//
//USING SAMPLE DATA HERE
//
        public async Task<NewsGroup> GetNewsAPISampleAsync(NewsCategory category)
        {
            DateTime dt = DateTime.Now;
            NewsCacheKey key = new(category, dt);
            NewsGroup news;

            
            if (!key.CacheExist)
            {
                NewsApiData newsdata = await NewsApiSampleData.GetNewsApiSampleAsync(category);

                news = new NewsGroup() { Category = category };
                news.Articles = newsdata.Articles.Select(x => new NewsItem
                {
                    Title = x.Title,
                    Description = x.Description,
                    Url = x.Url,
                    UrlToImage = x.UrlToImage,
                    DateTime = x.PublishedAt,
                }).ToList();

                NewsGroup.Serialize(news, key.FileName);
            }
            else
            {
                news = NewsGroup.Deserialize(key.FileName);
            }
            return news;

        }
                   

//#endif

    }
}
