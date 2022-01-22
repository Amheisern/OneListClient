using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            // Make a `GET` request to the API and get back a *stream* of data.
            var responseAsStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=sdg-handbook");
            // Supply that *stream of data* to a Deserialize that will interpret it as a List of Item objects.
            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);
            // For each item in our deserialized List of Item
            foreach (var item in items)
            {
                // Output some details on that item
                Console.WriteLine($"The task {item.text} was created on {item.created_at} is {item.CompleteStatus}");

            }
        }
    }
}

