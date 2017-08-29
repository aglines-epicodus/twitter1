using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrumpTweets.Models
{
    public class Tweet
    {
        public string source { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public string createdAt { get; set; }
        public string retweetCount { get; set; }
        public string inReplyToUser { get; set; }
        public string favoriteCount { get; set; }
        public Boolean isRetweet { get; set; }
    }
    
}
