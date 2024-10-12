using User;
using System.Text.Json;
namespace Database
{
    public class EmployeeDatabase
    {
        public static List<Employee> employees = new List<Employee>();

        public static void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public static Employee GetEmployeeById(Guid id)
        {
            return employees.FirstOrDefault(employee => employee.id == id);
        }

        public static Employee GetEmployeeByEmail(string email)
        {
            return employees.FirstOrDefault(employee => employee.email == email);
        }
        
        
        
        public static void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }
        
        public static void SaveEmployeesToJson()
        {
            string json = JsonSerializer.Serialize(employees, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("employees.json", json);
        }

        public static void LoadEmployeesFromJson()
        {
            if (File.Exists("employees.json"))
            {
                string json = File.ReadAllText("employees.json");
                if (!string.IsNullOrWhiteSpace(json))
                    employees = JsonSerializer.Deserialize<List<Employee>>(json);
            }
            else
                employees = new List<Employee>();
        }
        
    }
}