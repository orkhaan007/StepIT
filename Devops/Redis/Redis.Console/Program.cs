using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Redis.UI.Services.Abstract;

namespace Redis.Console
{
    public class Program
    {
        private readonly IQueueService _queueService;

        public Program(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Console.WriteLine("Write a movie name: ");
                var movieName = Console.ReadLine();
                await WriteMovieNameToQueue(movieName);
            }
        }

        private async Task WriteMovieNameToQueue(string? movieName)
        {
            if (string.IsNullOrEmpty(movieName) || string.IsNullOrWhiteSpace(movieName))
            {
                Console.WriteLine("Do not enter empty data!");
            }
            else if (!IsValidUTF8(movieName))
            {
                Console.WriteLine("Contains invalid UTF-8 characters!");
            }
            else
            {
                await _queueService.SendMessageAsync(movieName);
            }
        }

        private bool IsValidUTF8(string text)
        {
            try
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                var decodedText = System.Text.Encoding.UTF8.GetString(bytes);
                return text == decodedText;
            }
            catch
            {
                return false;
            }
        }

        public static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddScoped<IQueueService>(qs => new QueueService("your_connection_string"));
                    services.AddScoped<Program>();
                })
                .Build();

            var program = host.Services.GetRequiredService<Program>();
            await program.RunAsync();
        }
    }
}
