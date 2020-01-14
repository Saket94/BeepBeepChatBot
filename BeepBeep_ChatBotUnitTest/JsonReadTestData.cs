
using BeepBeep_ChatBotUnitTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BeepBeep_ChatBotUnitTest
{
    public class JsonReadTestData
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private string _filepath;

        /// <summary>
        /// JsonReadTestData constructor declaration
        /// </summary>
        /// <param name="filepath"></param>
        public JsonReadTestData(string filepath)
        {
            _filepath = filepath;
        }
       
        /// <summary>
        /// Method which is used to read the data from the json file
        /// </summary>
        /// <returns></returns>
        public TelegramChatModelList ParseJson2Model()
        {
            string jsonDataList;
            TelegramChatModelList testDataDM = new TelegramChatModelList();
            try
            {
                //Json Data read
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    jsonDataList = reader.ReadToEnd();
                }
                testDataDM = JsonConvert.DeserializeObject<TelegramChatModelList>(jsonDataList);
            }
            catch (System.Exception exe)
            {
                //To Handle & log exception
            }
            return testDataDM;
        }
    }
}