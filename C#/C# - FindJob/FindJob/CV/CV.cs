namespace CV
{
    public class CV
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; } 
        public string Experience { get; set; }
        public List<string> Skills { get; set; }
        public int ViewCount { get; set; }
    
        public CV(string profession, string experience,List<string> skills, string name, string surname)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Surname = surname;
            this.Profession = profession;
            this.Experience = experience;
            this.Skills = skills;
            this.ViewCount = 0;
        }
        
        public void EditCV(string newName, string newSurname, string newProfession, string newExperience, List<string> newSkills)
        {
            Console.Clear();
            this.Name = newName;
            this.Surname = newSurname;
            this.Profession = newProfession;
            this.Experience = newExperience;
            this.Skills = newSkills;
            
            Console.WriteLine("CV updated successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}