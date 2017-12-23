using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Syn.Bot.Siml;
using System.Web;
using Microsoft.AspNetCore.Hosting;

namespace ChatBot.Models
{
    public class ChatService
    {
        public static string GetResponse(string msg, string user, string languageFile)
        {
            var simlBot = new SimlBot();
            simlBot.PackageManager.LoadFromString(File.ReadAllText(languageFile));
            var result = simlBot.Chat(msg);

            // save it to database
            //db.InsertChat(msg, result.BotMessage, user);
            return result.BotMessage;
        }

    }
}
