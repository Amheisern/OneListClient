using System;
using System.Text.Json.Serialization;

namespace OneListClient
{
    public class Item
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        // public int id { get; set; }
        // public string text { get; set; }
        // public bool complete { get; set; }
        // public DateTime created_at { get; set; }
        // public DateTime updated_at { get; set; }

        public string CompletedStatus
        {
            get
            {
                return Complete ? "Completed" : "Not Complete";
                // if (complete)
                // {
                //     return "Complete";
                // }
                // else
                // {
                //     return "Not Complete";
                // }
            }
        }
    }
}