using System;
using System.Collections.Generic;
using System.Text;

namespace BeepBeep_ChatBotUnitTest.Models
{
    public class TelegramChatModelList
    {
        public TelegramChatModel[] TelegramChatModel { get; set; }
    }
    public class TelegramChatModel
    {
        public string ChatId { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
    }

}
