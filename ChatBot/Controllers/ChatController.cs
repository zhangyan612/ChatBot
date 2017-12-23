using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ChatBot.Models;

namespace ChatBot.Controllers
{
    [Produces("application/json")]
    [Route("api/Chat")]
    public class ChatController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ChatController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        /// <summary>
        /// Get bot message reply
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get(string msg, string user)
        {
            string RootPath = _hostingEnvironment.ContentRootPath;
            string languageFile = Path.Combine(RootPath, @"App_Data\english.simlpk");

            var response = ChatService.GetResponse(msg, user, languageFile);
            return Json(response);
        }
    }
}