using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace ConsoleApp4

{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            string key = "8df9507a-ed60-4d96-bab4-0510cebdfd7a";
            actions stats = new actions(key, client);

            JObject jobj;

             jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/close", ""));
             jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/create", ""));

            stats.stats();

            if(jobj["running"] != null && (bool)jobj["running"] == true)
            {
                Console.WriteLine("There is already a running game, close it or continue playing.");
            }

            //Direction = 1 (West)
            jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/player/" + key + "/move/1", ""));


            //At the end the game is being closed
            jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/close", ""));
        }
    }
}