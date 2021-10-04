using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace ConsoleApp4{
    class actions{
        JObject Jobj; 
        string Key;
        WebClient Client;
        public actions(string key, WebClient client){
            this.Key = key;
            this.Client = client;
        }


        public void stats(){ 

        Jobj = JObject.Parse(Client.DownloadString("https://game-dd.countit.at/api/game/" + Key + "/stats"));
        
        Console.Write(Jobj);
        Console.ReadKey();
        }
    }
}