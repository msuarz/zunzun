using System.Collections.Generic;
using Dimebrain.TweetSharp.Extensions;
using Dimebrain.TweetSharp.Model;

namespace Zunzun.Domain.Helpers {

    public static class TweetConverters {
        
        public static List<Tweet> ToTweets(this string Response) {
            var Results = new List<Tweet>();

            // TODO: deal with errors
            var Statuses = Response.AsStatuses();
            if (Statuses == null) return Results;
            
            foreach (var Status in Statuses)
                Results.Add(Status.ToTweet());

            return Results;
        }
        
        public static Tweet ToTweet(this TwitterStatus Status) { 
            return ObjectFactory.NewTweet(Status);
        }
    }
}