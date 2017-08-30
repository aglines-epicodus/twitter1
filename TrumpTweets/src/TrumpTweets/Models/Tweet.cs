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
        public string created_at { get; set; }
        public string retweet_count { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public string favorite_count { get; set; }
        public Boolean is_retweet { get; set; }
    }
    
}
