using System;
using System.Net.Http;

namespace OneListClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsString = client.GetStringAsync("https://one-list-api.herokuapp.com/items?access_token=sdg-handbook");

            Console.WriteLine(responseAsString);
            //this code will happen at the same time as our network request
        }
    }
}
