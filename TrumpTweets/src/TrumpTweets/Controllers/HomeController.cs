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
        //PRE-Processing tweet data:

        //Uncomment the next 2 lines to use actual file - but it needs a relative path, won't work on other computers?
        static string file = @"C:\Users\Andrew Glines\Source\Repos\twitter1\TrumpTweets\src\TrumpTweets\realDonaldTrump2016tweets.json";
        static string tweets = System.IO.File.ReadAllText(file);

        // use test data while coding isntead
        //static string tweets = @"[{'source': 'Twitter for iPhone', 'id_str': '815271067749060609', 'text': 'RT RT @realDonaldTrump: Happy Happy Birthday @DonaldJTrumpJr!\nhttps://t.co/uRxyCD3hBz', 'created_at': 'Sat Dec 31 18:59:04 +0000 2016', 'retweet_count': 9529, 'in_reply_to_user_id_str': null, 'favorite_count': 0, 'is_retweet': true},{'source': 'Twitter for Android', 'id_str': '814920722208296960', 'text': 'Happy Join @AmerIcan32, founded by Hall of Fame legend legend @JimBrownNFL32 onsin Washington, D.C.\u2026 https://t.co/9WJZ8iTCQV', 'created_at': 'Fri Dec 30 19:46:55 +0000 2016', 'retweet_count': 7366, 'in_reply_to_user_id_str': null, 'favorite_count': 25336, 'is_retweet': false}]";
        // now we will try limiting data input (cause it's huge)
        static List<Tweet> list = JsonConvert.DeserializeObject<List<Tweet>>(tweets);
        
        string log = "";

        public IActionResult Index()
        {
            WordCounts();
            //AvgLengthOfTweetBySource();
            // method store text data from each tweet
            // render this data in View for a small number of those tweets
            ViewBag.log = log;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public string WordCounts()
        {
            // we will need a dictionary wordCounts
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            //process data
            foreach (Tweet item in list)
            {
                string textToProcess = item.text;
                string[] source = textToProcess.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
                //source is now an array
                //so for each item in array, write into the Dictionary wordCounts
                foreach (string word in source)
                {
                    if (!wordCounts.ContainsKey(word))
                    {
                        wordCounts.Add(word, 1);
                        //System.Diagnostics.Debug.WriteLine("11111111111 new word " + word);
                    }
                    else
                    {
                        wordCounts[word] = wordCounts[word] + 1;
                        //System.Diagnostics.Debug.WriteLine("2222222222 repeated word " + word + " count is now " + wordCounts[word]);
                    }
                    //log += word + " count: " + wordCounts[word] + "\n";
                }
            }

            var q = wordCounts.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key);
            foreach (var word in q)
            {
                log += word.Key + " " + word.Value + "\n";
            }

            // We won't need to return log anymore; but I want to 'fake' json 
            //log = @"[{'text':'study','size':40},{'text':'motion','size':15},{'text':'forces','size':10},{'text':'electricity','size':15}]";


            var wordsForCloud = new List<CloudWord>();
            foreach (var thing in wordCounts)
            {
                wordsForCloud.Add(new CloudWord() { text = thing.Key, size = thing.Value*10 });
            }

            string json = JsonConvert.SerializeObject(wordsForCloud);

            log = json;

            return log;

        }
        //System.Diagnostics.Debug.WriteLine(list.Count);


        public string AvgLengthOfTweetBySource()
            {
                List<int> tweetLengthsIphone = new List<int>();
                List<int> tweetLengthsAndroid = new List<int>();
                foreach (Tweet item in list)
                {
                 if (item.source == "Twitter for iPhone")
                    {
                        tweetLengthsIphone.Add(item.text.Length);
                    }
                if (item.source == "Twitter for Android")
                    {
                        tweetLengthsAndroid.Add(item.text.Length);
                    }
                }

            double avgLengthOfTweetIphone = tweetLengthsIphone.Average();
            double avgLengthOfTweetAndroid = tweetLengthsAndroid.Average();

            log += "iphone average is now  " + avgLengthOfTweetIphone + "\n";
            log += "android average is now  " + avgLengthOfTweetAndroid + "\n";

            return log;

        }



    }
}

