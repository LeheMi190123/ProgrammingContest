using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace ConsoleApp4{
    class actions{
        //variables
        JObject Jstats, Jmove, Jhit, Jdash, Jspecial, Jteleport, Jradar, Jscan; 
        string Key;
        int hitDir;
        WebClient Client;
        Random myObject;
        int moveDir;
        //Konstruktor für key und client
        public actions(string key, WebClient client){
            this.Key = key;
            this.Client = client;
            this.myObject = new Random();
            this.moveDir = myObject.Next(0,3);
        }

        //Stats Method
       
        public void stats()
        { 
        Jstats = JObject.Parse(Client.DownloadString("https://game-dd.countit.at/api/player/" + Key + "/stats"));
        Console.ReadKey();
        }
        
        //move method
       
        public void move()
        {
        Jmove = JObject.Parse(Client.UploadString("https://game-dd.countit.at/api/player/" + Key + "/move/"+ moveDir, ""));

        if(Jmove["move"] != null && (bool)Jmove["executed"] == true)
            {
                if((bool)Jmove["move"] == true)
                {
                    Console.WriteLine("The Player moved");
                }
                else
                {
                    Console.WriteLine("You cant move across the border!");
                }
            }
            else
            {
                if((bool)Jmove["executed"] == false)
                {
                    Console.WriteLine("You need to rest, before you move again");
                }
            }
        }
        
        //scan method
        
        public void scan()
        {
            Jscan = JObject.Parse(Client.DownloadString("https://game-dd.countit.at/api/player/" + Key + "/scan/"));
            if(Jscan["hit"] != null && (bool)Jhit["executed"] == true)
            {
                Console.Write(Jscan);
            }
        }

        //hit method
       
        public void hit()
        {
        Jhit = JObject.Parse(Client.UploadString("https://game-dd.countit.at/api/player/" + Key + "/hit/" + hitDir + "", ""));

        if(Jhit["hit"] != null && (bool)Jhit["executed"] == true)
            {
                if((bool)Jhit["hit"] == true)
                {
                    //The avatar hits
                }
               
            }
            else
            {
                if((bool)Jhit["executed"] == false)
                {
                    //You can't hit now because of the cooldown
                }
            }
        }

        
    }
}