﻿namespace RedisPubSub.Models;

public class IndexViewModel
{
    public List<Dictionary<string, List<string>>>? Channels { get; set; }
}