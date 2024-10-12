namespace User
{
    public abstract class Person
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int viewCount { get; set; }
    }
}

