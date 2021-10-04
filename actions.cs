using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace ConsoleApp4{
    class actions{
        //variables
        JObject Jobj; 
        string Key;
        int hitDir;
        WebClient Client;
        //Konstruktor für key und client
        public actions(string key, WebClient client){
            this.Key = key;
            this.Client = client;
        }

        //Stats Method
       
        public void stats(){ 

        Jobj = JObject.Parse(Client.DownloadString("https://game-dd.countit.at/api/player/" + Key + "/stats"));
        
        Console.Write(Jobj);
        Console.ReadKey();
        }

        //First move method
       
        public void move()
        {
        Jobj = JObject.Parse(Client.UploadString("https://game-dd.countit.at/api/player/" + Key + "/move/", ""));

        if(Jobj["move"] != null && (bool)Jobj["executed"] == true)
            {
                if((bool)Jobj["move"] == true)
                {
                    //The avatar moved
                }
                else
                {
                    //You can't move in this direction because of the map's border
                }
            }
            else
            {
                if((bool)Jobj["executed"] == false)
                {
                    //You can't move now because of the cooldown
                }
            }
        Console.Write(Jobj);
        Console.ReadKey();
        }
        
        //First hit method
       
        public void hit()
        {
        Jobj = JObject.Parse(Client.UploadString("https://game-dd.countit.at/api/player/" + Key + "/hit/" + hitDir + "", ""));

        if(Jobj["hit"] != null && (bool)Jobj["executed"] == true)
            {
                if((bool)Jobj["hit"] == true)
                {
                    //The avatar hits
                }
               
            }
            else
            {
                if((bool)Jobj["executed"] == false)
                {
                    //You can't hit now because of the cooldown
                }
            }
        }

        //First scan method
    }
}