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
            string firstTweet = @"{ 'source': 'Twitter for iPhone', 'id_str': '815271067749060609', 'text': 'RT @realDonaldTrump: Happy Birthday @DonaldJTrumpJr!\nhttps://t.co/uRxyCD3hBz', 'created_at': 'Sat Dec 31 18:59:04 +0000 2016', 'retweet_count': 9529, 'in_reply_to_user_id_str': null, 'favorite_count': 0, 'is_retweet': true}";
            Tweet deserializedTweet = JsonConvert.DeserializeObject<Tweet>(firstTweet);

            System.Diagnostics.Debug.WriteLine("**************\n**************\n**************\n");
            
            System.Diagnostics.Debug.WriteLine(deserializedTweet.source.ToString());


        }
    }


}
