using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //replaces token in url sdg handbook
            //var token = args[0];
            var token = "";
            if (args.Length == 0)
            {
                Console.Write("What list would you like? ");
                token = Console.ReadLine();
            }
            else
            {
                token = args[0];
            }


            var client = new HttpClient();
            // Make a `GET` request to the API and get back a *stream* of data.
            var responseAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items?access_token={token}");
            // Supply that *stream of data* to a Deserialize that will interpret it as a List of Item objects.
            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            var table = new ConsoleTable("Description", "Created At", "Completed");

            // For each item in our deserialized List of Item
            foreach (var item in items)
            {
                // Output some details on that item
                //Console.WriteLine($"The task {item.Text} was created on {item.CreatedAt} is {item.CompleteStatus}");
                // Add one row to our table
                table.AddRow(item.Text, item.CreatedAt, item.CompletedStatus);

            }
            table.Write();
        }
    }
}

