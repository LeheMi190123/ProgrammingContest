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
            actions move = new actions(key, client);
            actions hit = new actions(key, client);
            actions scan = new actions(key, client);

            JObject jobj;

             jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/close", ""));
             jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/create", ""));

            //Calling the stats method
            stats.stats();
            Console.ReadKey();
            //Calling the move method
            move.move();
            Console.ReadKey();
            //Calling the hit method
            hit.hit();
            Console.ReadKey();
            //Calling the scan method
            scan.scan();
            Console.ReadKey();
            //At the end the game is being closed
            jobj = JObject.Parse(client.UploadString("https://game-dd.countit.at/api/game/" + key + "/close", ""));
        }
    }
}