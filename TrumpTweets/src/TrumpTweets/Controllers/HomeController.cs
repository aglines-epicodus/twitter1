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
            //using actual file - but it needs a relative path, won't work on other computers?
            string file = @"C:\Users\Andrew Glines\Source\Repos\twitter1\TrumpTweets\src\TrumpTweets\realDonaldTrump2016tweets.json";
            string tweets = System.IO.File.ReadAllText(file);
            List<Tweet> list = JsonConvert.DeserializeObject<List<Tweet>>(tweets);

            //process data
            foreach (Tweet item in list)
            {
                // Splitting comes at a processing cost;  
                // I don't need the text split for any other reason 


                public static void Main()
        {
            string pattern = @"\b\w+es\b";
            string sentence = "Who writes these notes?";

            foreach (Match match in Regex.Matches(sentence, pattern))
                Console.WriteLine("Found '{0}' at position {1}",
                                  match.Value, match.Index);
        }



        System.Diagnostics.Debug.WriteLine("**************\n**************\n**************  " + item.created_at);
                // store item.text into a data structure... 
                // text: string split to be countable...

                string textToProcess = item.text;
                string[] words = textToProcess.Split(' ');
                foreach (string word in words)
                {
                    // compile this into array?  but it'll only compiel for ONE twee.
                }


            }

            System.Diagnostics.Debug.WriteLine(list.Count);
            
        }

    }


}
