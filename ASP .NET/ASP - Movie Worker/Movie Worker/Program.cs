using Microsoft.EntityFrameworkCore;
using Movie_Worker.Contexts;
using Movie_Worker.Repository.Abstract;
using Movie_Worker.Repository.Concrete;
using Movie_Worker.Services;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<Requst>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.Configure<BackgroundWorker>(
    builder.Configuration.GetSection("BackgroundWorker"));

builder.Services.AddHostedService<BackgroundServices>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MovieDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();