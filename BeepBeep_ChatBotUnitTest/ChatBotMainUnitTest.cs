using BeepBeep_ChatBot;
using BeepBeep_ChatBotUnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;

namespace BeepBeep_ChatBotUnitTest
{
    [TestClass]
    public class ChatBotMainUnitTest
    {
        /// <summary>
        /// Declaration of the file path which is used to fetch data from json file.
        /// </summary>
        static string _testCasesChatBotFilePath = @".\TestCases\ChatBotMessages.json";

        /// <summary>
        /// GetJsonData method is used to fetch the records from the ChatBotMessages.json file.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetJsonData()
        {
            var dataList = new JsonReadTestData(_testCasesChatBotFilePath).ParseJson2Model().TelegramChatModel;
           
            foreach (var chkData in dataList)
            {
                yield return new object[] {
                       chkData
                };
            }
        }

        /// <summary>
        /// BotOnMessageTestMethod method is used to test all the cases from the ChatBotMessages.json file.
        /// </summary>
        /// <param name="telegramChatModel"></param>
        [TestMethod]
        [DynamicData(nameof(GetJsonData), DynamicDataSourceType.Method)]
        public void BotOnMessageTestMethod(TelegramChatModel telegramChatModel)
        {
            Program chatBotMain = new Program();
            string result = chatBotMain.MockBotMessage(telegramChatModel.ChatId, telegramChatModel.MessageType, telegramChatModel.Message);
            Assert.IsNotNull(result);
        }
    }
}
