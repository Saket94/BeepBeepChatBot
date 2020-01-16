using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BeepBeep_ChatBot
{
    public class Program
    {
        /// <summary>
        /// Global declaration of userDataList
        /// </summary>
        public static List<UserClass> userDataList = new List<UserClass>();

        /// <summary>
        /// Getting the TelegramBotClient details with respect to its telegram access token.
        /// </summary>
        public static readonly TelegramBotClient chatBot = new TelegramBotClient("1052682215:AAEmpdZTGXhW6zCW2MwjZtzXuOlWVy2nbz0");

        /// <summary>
        /// Main method declarations
        /// </summary>
        public static void Main()
        {
            chatBot.OnMessage += BotOnMessage;
            chatBot.StartReceiving();
            Console.ReadLine();
            chatBot.StopReceiving();
        }

        /// <summary>
        /// Chat bot method which returns the output when message is send from the telegram.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static async void BotOnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            try
            {
                if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                {
                    if (userDataList.Count() == 0)
                    {
                        if (userDataList.Count() == 0)
                        {
                            userDataList = new List<UserClass>();
                            userDataList.Add(new UserClass() { userId = Convert.ToString(e.Message.Chat.Id), userName = null, isName = false, location = null });
                        }

                        if (((e.Message.Text.ToLower() == "hi") || (e.Message.Text.ToLower() == "hello") || (e.Message.Text.ToLower() == "hey")) && (e.Message.Text.ToLower() != "/start"))
                        {
                            await chatBot.SendTextMessageAsync(e.Message.Chat.Id, "What is your name ?");
                            return;
                        }
                    }
                    else
                    {
                        var chkUser = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                        if (chkUser == null)
                        {
                            userDataList.Add(new UserClass() { userId = Convert.ToString(e.Message.Chat.Id), userName = null, isName = false, location = null });
                        }

                        if (((e.Message.Text.ToLower() == "hi") || (e.Message.Text.ToLower() == "hello") || (e.Message.Text.ToLower() == "hey")) && (e.Message.Text.ToLower() != "/start"))
                        {

                            //again update user datalist for same user for next time... 
                            userDataList.Where(w => w.userId == Convert.ToString(e.Message.Chat.Id)).Select(w => { w.userName = null; w.isName = false; w.location = null; return w; }).ToList();
                            await chatBot.SendTextMessageAsync(e.Message.Chat.Id, "What is your name ?");
                            return;
                        }

                        var checkUserName = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                        bool isChk = checkUserName.isName;
                        if ((isChk == false) && (e.Message.Text.ToLower() != "/start"))
                        {
                            userDataList.Where(w => w.userId == Convert.ToString(e.Message.Chat.Id)).Select(w => { w.userName = Convert.ToString(e.Message.Text); w.isName = true; return w; }).ToList();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                            string username = userdata.userName;
                            await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + ",What is your location ?");
                            return;
                        }
                        else if (((e.Message.Text.ToLower() != "hi") || (e.Message.Text.ToLower() != "hello") || (e.Message.Text.ToLower() != "hey")) && (e.Message.Text.ToLower() != "news") && (e.Message.Text.ToLower() != "weather") && (e.Message.Text.ToLower() != "/start"))
                        {
                            userDataList.Where(w => w.userId == Convert.ToString(e.Message.Chat.Id)).Select(w => { w.location = Convert.ToString(e.Message.Text); return w; }).ToList();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + Environment.NewLine + "What would you like to know news or weather of your loaction : " + userlocation + " ?");
                            return;
                        }
                        else if ((e.Message.Text.ToLower() == "news") && (e.Message.Text.ToLower() != "/start"))
                        {
                            NewsApiClass objNews = new NewsApiClass();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            var chkNews = objNews.GetTopNews(userlocation.ToLower());
                            if(!string.IsNullOrEmpty(Convert.ToString(chkNews)))
                            {
                                await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + Environment.NewLine + "Your location : " + userlocation + "  news is :" + Environment.NewLine + chkNews);
                            }
                            else
                            {
                                await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + Environment.NewLine + "No news found," + Environment.NewLine + "For your " + userlocation + " location.");
                            }
                            return;
                        }
                        else if ((e.Message.Text.ToLower() == "weather") && (e.Message.Text.ToLower() != "/start"))
                        {
                            WeatherApiClass objWeather = new WeatherApiClass();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(e.Message.Chat.Id)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            var chkWeather = objWeather.GetWheatherInfo(userlocation.ToLower());
                            if (!string.IsNullOrEmpty(Convert.ToString(chkWeather)))
                            {
                                await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + Environment.NewLine + "Your location : " + userlocation + "  weather is :" + Environment.NewLine + chkWeather);
                            }
                            else
                            {
                                await chatBot.SendTextMessageAsync(e.Message.Chat.Id, username + Environment.NewLine + "No weather found," + Environment.NewLine + "For your " + userlocation + " location.");
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Mock method which is the copy of the BotOnMessage method.
        /// This method is used to provide the same output as like the BotOnMessage method.
        /// </summary>
        /// <param name="ChatId"></param>
        /// <param name="MessageType"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public string MockBotMessage(string ChatId, string MessageType, string Message)
        {
            string result = "";
            try
            {
                if (MessageType == "Message")
                {
                    if (userDataList.Count() == 0)
                    {
                        if (userDataList.Count() == 0)
                        {
                            userDataList = new List<UserClass>();
                            userDataList.Add(new UserClass() { userId = Convert.ToString(ChatId), userName = null, isName = false, location = null });
                        }

                        if (((Message.ToLower() == "hi") || (Message.ToLower() == "hello") || (Message.ToLower() == "hey")) && (Message.ToLower() != "/start"))
                        {
                            result = "What is your name ?";
                        }
                    }
                    else
                    {
                        var chkUser = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                        if (chkUser == null)
                        {
                            userDataList.Add(new UserClass() { userId = Convert.ToString(ChatId), userName = null, isName = false, location = null });
                        }

                        if (((Message.ToLower() == "hi") || (Message.ToLower() == "hello") || (Message.ToLower() == "hey")) && (Message.ToLower() != "/start"))
                        {
                            //again update user datalist for same user for next time... 
                            userDataList.Where(w => w.userId == Convert.ToString(ChatId)).Select(w => { w.userName = null; w.isName = false; w.location = null; return w; }).ToList();
                            result = "What is your name ?";
                        }

                        var checkUserName = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                        bool isChk = checkUserName.isName;

                        if ((isChk == false) && (Message.ToLower() != "/start"))
                        {
                            userDataList.Where(w => w.userId == Convert.ToString(ChatId)).Select(w => { w.userName = Convert.ToString(Message); w.isName = true; return w; }).ToList();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                            string username = userdata.userName;
                            result = username + ",What is your location ?";
                        }
                        else if (((Message.ToLower() != "hi") || (Message.ToLower() != "hello") || (Message.ToLower() != "hey")) && (Message.ToLower() != "news") && (Message.ToLower() != "weather") && (Message.ToLower() != "/start"))
                        {
                            userDataList.Where(w => w.userId == Convert.ToString(ChatId)).Select(w => { w.location = Convert.ToString(Message); return w; }).ToList();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            result = username + Environment.NewLine + "What would you like to know news or weather of your loaction : " + userlocation + " ?";
                        }
                        else if ((Message.ToLower() == "news") && (Message.ToLower() != "/start"))
                        {
                            NewsApiClass objNews = new NewsApiClass();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            var chkNews = objNews.GetTopNews(userlocation.ToLower());
                            if (!string.IsNullOrEmpty(Convert.ToString(chkNews)))
                            {
                                result = username + Environment.NewLine + "Your location : " + userlocation + "  news is :" + Environment.NewLine + chkNews;
                            }
                            else
                            {
                                result = username + Environment.NewLine + "No news found," + Environment.NewLine + "For your " + userlocation + " location.";
                            }
                        }
                        else if ((Message.ToLower() == "weather") && (Message.ToLower() != "/start"))
                        {
                            WeatherApiClass objWeather = new WeatherApiClass();
                            var userdata = userDataList.Where(x => x.userId == Convert.ToString(ChatId)).FirstOrDefault();
                            string username = userdata.userName;
                            string userlocation = userdata.location;
                            var chkWeather = objWeather.GetWheatherInfo(userlocation.ToLower());
                            if (!string.IsNullOrEmpty(Convert.ToString(chkWeather)))
                            {
                                result = username + Environment.NewLine + "Your location : " + userlocation + "  weather is :" + Environment.NewLine + chkWeather;
                            }
                            else
                            {
                                result = username + Environment.NewLine + "No weather found," + Environment.NewLine + "For your " + userlocation + " location.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;
        }
    }
}
