using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using TrumpTweets.Models;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrumpTweets.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ConvertTweets();
            
            // method store text data from each tweet
            // render this data in View for a small number of those tweets
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public void ConvertTweets()
        {
            //Uncomment the next 3 lines to use actual file - but it needs a relative path, won't work on other computers?
            //string file = @"C:\Users\Andrew Glines\Source\Repos\twitter1\TrumpTweets\src\TrumpTweets\realDonaldTrump2016tweets.json";
            //string tweets = System.IO.File.ReadAllText(file);

            // use test data while coding isntead
            string tweets = @"{'source': 'Twitter for iPhone', 'id_str': '815271067749060609', 'text': 'RT @realDonaldTrump: Happy Birthday @DonaldJTrumpJr!\nhttps://t.co/uRxyCD3hBz', 'created_at': 'Sat Dec 31 18:59:04 +0000 2016', 'retweet_count': 9529, 'in_reply_to_user_id_str': null, 'favorite_count': 0, 'is_retweet': true}, {'source': 'Twitter for iPhone', 'id_str': '814920722208296960', 'text': 'Join @AmerIcan32, founded by Hall of Fame legend @JimBrownNFL32 on 1/19/2017 in Washington, D.C.\u2026 https://t.co/9WJZ8iTCQV', 'created_at': 'Fri Dec 30 19:46:55 +0000 2016', 'retweet_count': 7366, 'in_reply_to_user_id_str': null, 'favorite_count': 25336, 'is_retweet': false}";


            List<Tweet> list = JsonConvert.DeserializeObject<List<Tweet>>(tweets);

            //process data
            foreach (Tweet item in list)
            {
                // Splitting comes at a processing cost;  
                // but I do need it split in order to count words across iterations
                string textToProcess = item.text;
                string[] source = textToProcess.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);

                var matchQuery = from word in source
                                    select word;
                int wordCount = matchQuery.Count();

                System.Diagnostics.Debug.WriteLine("********************** wordCount = " + wordCount + " word is " + matchQuery);

            }

            //System.Diagnostics.Debug.WriteLine(list.Count);
            
        }

    }


}
