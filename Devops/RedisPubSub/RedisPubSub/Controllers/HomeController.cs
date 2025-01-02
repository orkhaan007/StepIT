using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RedisPubSub.Models;
using StackExchange.Redis;

namespace RedisPubSub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-15194.c266.us-east-1-3.ec2.redns.redis-cloud.com:15194,password=91xOD96LMRn0AS1IXnZwiGzRXLrvh94S");


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult CreateChannelOnRedis([FromForm] string channelName)
    {
        if (string.IsNullOrWhiteSpace(channelName))
        {
            return BadRequest("Channel name cannot be empty.");
        }

        var db = redis.GetDatabase();
        var sub = redis.GetSubscriber();

        var messages = new List<string>();

        string serializedList = JsonSerializer.Serialize(messages);

        db.HashSet("Channels", channelName, serializedList);

        TempData["SuccessMessage"] = "Channel created successfully.";

        RedisChannel channel = new RedisChannel(channelName, RedisChannel.PatternMode.Auto);

        sub.Publish(channel, "Channel created from MVC App .");

        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        var model = new IndexViewModel
        {
            Channels = GetChannelsFromRedis()
        };
        ViewBag.SuccessMessage = TempData["SuccessMessage"];
        return View(model);
    }


    private List<Dictionary<string, List<string>>> GetChannelsFromRedis()
    {
        var db = redis.GetDatabase();
        var channels = db.HashGetAll("Channels");
        var dictList = new List<Dictionary<string, List<string>>>();
        foreach (var channel in channels)
        {
            var channelName = channel.Name.ToString();
            var messages = JsonSerializer.Deserialize<List<string>>(channel.Value);
            var channelDict = new Dictionary<string, List<string>>
        {
            {channelName, messages},
        };
            dictList.Add(channelDict);
        }
        return dictList;
    }

    [HttpGet]
    public List<string> GetSelectedChannelMessages(string channelName)
    {
        var db = redis.GetDatabase();
        var selectedChannelMessages = db.HashGet("Channels", channelName).ToString();
        var messages = JsonSerializer.Deserialize<List<string>>(selectedChannelMessages);
        return messages;
    }

    [HttpPost]
    public IActionResult SendMessage(string channelName, string message)
    {
        if (string.IsNullOrWhiteSpace(channelName) || string.IsNullOrWhiteSpace(message))
        {
            return BadRequest("Invalid channel or message.");
        }

        var db = redis.GetDatabase();
        var subscriber = redis.GetSubscriber();

        var selectedChannelMessages = db.HashGet("Channels", channelName).ToString();
        var messages = JsonSerializer.Deserialize<List<string>>(selectedChannelMessages) ?? new List<string>();

        messages.Add(message);

        string updatedMessages = JsonSerializer.Serialize(messages);

        db.HashSet("Channels", channelName, updatedMessages);

        subscriber.Publish(channelName, message);

        return Ok();
    }
}
