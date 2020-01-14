using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BeepBeep_ChatBot
{
    public class WeatherApiClass
    {
        /// <summary>
        /// Method to fetch the weather data from the weather api
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetWheatherInfo(string location)
        {
            string wheatherinfo = "";
            var description = "";
            try
            {
                //  APPID = e9b433f7ed306860db69ea25723a5f48 

                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&APPID=e9b433f7ed306860db69ea25723a5f48", location);

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);
                    var data = JObject.Parse(json);

                    var lon = Convert.ToString(data["coord"]["lon"]);
                    var lat = Convert.ToString(data["coord"]["lat"]);

                    var weather = data["weather"];
                    foreach (var w in weather)
                    {
                        description = Convert.ToString(w["description"]);
                    }

                    var maintemp = Convert.ToString(data["main"]["temp"]);
                    var humidity = Convert.ToString(data["main"]["humidity"]);
                    //string newLine = Environment.NewLine;
                    // wheatherinfo = "Weather:  " + description + newLine+"  Temprature: " + maintemp + newLine+"  Humidity:  " + humidity;
                    StringBuilder str = new StringBuilder();
                    str.AppendLine();
                    str.AppendLine("Weather:  " + description);
                    str.AppendLine();
                    str.AppendLine("Temprature: " + maintemp);
                    str.AppendLine();
                    str.AppendLine("Humidity:  " + humidity);
                    str.AppendLine();
                    wheatherinfo = str.ToString();

                    // WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                }
            }
            catch (Exception ex)
            {
                wheatherinfo = "Sorry, weather info not found.Please enter valid location.";
            }
            return wheatherinfo;
        }
    }
}
