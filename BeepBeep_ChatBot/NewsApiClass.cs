using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BeepBeep_ChatBot
{
    public class NewsApiClass
    {       
        /// <summary>
        /// Method which fetches the data from the News api
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetTopNews(string location)
        {
            string newsinfo = "";
            string Title = ""; int count = 0;
            try
            {
                string url = string.Format("https://newsapi.org/v2/everything?q={0}&from=2020-01-01&sortBy=publishedAt&apiKey=825be354b66d4ca8ac41f9ed7c1b446c", location);
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    var data = JObject.Parse(json);
                    var articles = data["articles"];
                    foreach (var art in articles)
                    {

                        count++;
                        var cnt = Convert.ToString(count);
                        Title += " " + cnt + ". " + art["title"];
                        if (count == 3)
                        {
                            break;
                        }
                    }
                    newsinfo = Title;
                }


            }
            catch (Exception ex) 
            {
                newsinfo = "Sorry, something is wrong.Please enter valid location";
            }
            return newsinfo;
        }
    }
}
