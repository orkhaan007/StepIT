using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movie_Worker.Contexts;
using Movie_Worker.Entities;
#nullable disable

namespace Movie_Worker.Services
{
    public class BackgroundServices : BackgroundService
    {
        private readonly Requst _omdbApiService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly float _delayMinutes;

        public BackgroundServices(
            Requst omdbApiService,
            IServiceScopeFactory scopeFactory,
            IOptions<BackgroundWorker> settings)
        {
            _omdbApiService = omdbApiService;
            _scopeFactory = scopeFactory;
            _delayMinutes = settings.Value.Minutes;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var random = new Random();

            while (!stoppingToken.IsCancellationRequested)
            {
                char randomLetter = (char)random.Next('A', 'Z' + 1);
                Console.WriteLine($"Fetching films starting with: {randomLetter}");

                var response = await _omdbApiService.SearchFilmsAsync(randomLetter.ToString());

                if (response["Response"].ToString() == "True")
                {
                    var films = response["Search"].Select(f => f["Title"].ToString()).ToList();

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();

                        foreach (var filmTitle in films)
                        {
                            var existingFilm = await dbContext.Movies
                                .Where(f => f.Title == filmTitle)
                                .FirstOrDefaultAsync(stoppingToken);

                            if (existingFilm == null)
                            {
                                var newFilm = new Movie
                                {
                                    Title = filmTitle,
                                    Genre = randomLetter.ToString()
                                };
                                dbContext.Movies.Add(newFilm);
                                await dbContext.SaveChangesAsync(stoppingToken);
                                Console.WriteLine($"Added new film: {filmTitle}");
                                break;
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("No films found for the letter.");

                await Task.Delay(TimeSpan.FromMinutes(_delayMinutes), stoppingToken);
                Console.WriteLine($"Delay set to: {_delayMinutes} minutes.");
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Task is stopping...");
            return base.StopAsync(cancellationToken);
        }
    }
}