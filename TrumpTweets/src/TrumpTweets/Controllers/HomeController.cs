using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using TrumpTweets.Models;

namespace TrumpTweets.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ConvertTweets();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public void ConvertTweets()
        {
            //this is test data, will need to use actual file
            string tweets = @"[{'source': 'Twitter for iPhone', 'id_str': '815271067749060609', 'text': 'RT @realDonaldTrump: Happy Birthday @DonaldJTrumpJr!\nhttps://t.co/uRxyCD3hBz', 'created_at': 'Sat Dec 31 18:59:04 +0000 2016', 'retweet_count': 9529, 'in_reply_to_user_id_str': null, 'favorite_count': 0, 'is_retweet': true},{'source': 'Twitter for iPhone', 'id_str': '814920722208296960', 'text': 'Join @AmerIcan32, founded by Hall of Fame legend @JimBrownNFL32 on 1/19/2017 in Washington, D.C.\u2026 https://t.co/9WJZ8iTCQV', 'created_at': 'Fri Dec 30 19:46:55 +0000 2016', 'retweet_count': 7366, 'in_reply_to_user_id_str': null, 'favorite_count': 25336, 'is_retweet': false}]";

            List<Tweet> list = JsonConvert.DeserializeObject<List<Tweet>>(tweets);

            //process data
            foreach (Tweet item in list)
            {
                System.Diagnostics.Debug.WriteLine("**************\n**************\n**************  " + item.created_at);
            }

            System.Diagnostics.Debug.WriteLine(list.Count);
            
        }
    }


}
