namespace Vacancy
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UpdateDate { get; set; }
        public string ExpireDate { get; set; }
        public string Category { get; set; }
        public float Salary { get; set; }

        public bool IsActive { get; set; }
        public int ViewCount { get; set; }
        public List<User.Employee> Applicants { get; set; }

        public Vacancy(string title, string category, float salary,string decription)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Description = decription;
            this.UpdateDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            this.ExpireDate = (DateTime.Parse(UpdateDate).AddMonths(3)).ToString();
            this.Category = category;
            this.Salary = salary;
            this.IsActive = true;
            this.ViewCount = 0;
            this.Applicants = new List<User.Employee>(); 
        }
    }
}

