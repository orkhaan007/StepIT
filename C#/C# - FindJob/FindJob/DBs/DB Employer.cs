using User;
using System.Text.Json;
namespace Database
{
    public class EmployerDatabase
    {
        public static List<Employer> employers = new List<Employer>();

        public static void AddEmployer(Employer employer)
        {
            employers.Add(employer);
        }

        public static Employer GetEmployerById(Guid id)
        {
            return employers.FirstOrDefault(employer => employer.id == id);
        }

        public static Employer GetEmployerByEmail(string email)
        {
            return employers.FirstOrDefault(employer => employer.email == email);
        }
        
        public static void DeleteEmployer(Employer employer)
        {
            employers.Remove(employer);
        }
        
        public static void SaveEmployersToJson()
        {
            string json = JsonSerializer.Serialize(employers, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("employees.json", json);
        }

        public static void LoadEmployersFromJson()
        {
            if (File.Exists("employers.json"))
            {
                string json = File.ReadAllText("employers.json");
                if (!string.IsNullOrWhiteSpace(json))
                    employers = JsonSerializer.Deserialize<List<Employer>>(json);
            }
            else
                employers = new List<Employer>();
        }
    }
}