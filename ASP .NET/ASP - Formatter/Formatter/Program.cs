using Formatter.Data;
using Formatter.Formatters;
using Formatter.Repository.Abstract;
using Formatter.Repository.Concrete;
using Formatter.Services.Abstract;
using Formatter.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Formatter.Data;
using Formatter.Formatters;
using Formatter.Repository.Abstract;
using Formatter.Repository.Concrete;
using Formatter.Services.Abstract;
using Formatter.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(0, new VCardOutputFormatter());
});
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, new VCardInputFormatter());
});
builder.Services.AddControllers(options =>
{
    options.OutputFormatters.Insert(1, new TextCsvOutputFormatter());
});
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(1, new TextCsvInputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();


var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StudentDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();