using System.Text.Json;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Redis.UI.Dtos;
using StackExchange.Redis;

namespace Redis.Trigger
{
    public class QueueTrigger
    {

        [Function("QueueTrigger")]
        public async Task Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")] QueueMessage message)
        {
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            response = await httpClient.GetAsync($"https://www.omdbapi.com/?apikey=ec7da663&s={message.MessageText}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RepsonseDTO>(content);

            var movie = result.Search[0];
            Console.WriteLine(movie.Year + " / " + movie.Title + " / " + movie.Poster);

            var muxer = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { { "your_endpoint", 15253 } },
                    User = "default",
                    Password = "your_pass"
                }
            );
            var db = muxer.GetDatabase();
            db.ListRightPush("OMDBMovies", movie.Poster);
        }
    }
}
