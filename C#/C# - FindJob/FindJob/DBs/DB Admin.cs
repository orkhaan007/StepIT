using User;
using System.Text.Json;
namespace Database
{
    public class AdminDatabase
    {
        public static List<Admin> admins = new List<Admin>();
        
        public static void AddAdmin(Admin admin)
        {
            admins.Add(admin);
        }
        
        public static Admin GetAdminById(Guid id)
        {
            return admins.FirstOrDefault(admin => admin.id == id);
        }

        public static Admin GetAdminByEmail(string email)
        {
            return admins.FirstOrDefault(admin => admin.email == email);
        }
        
        public static void SaveAdminsToJson()
        {
            string json = JsonSerializer.Serialize(admins, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("admins.json", json);
        }

        public static void LoadAdminsFromJson()
        {
            if (File.Exists("admins.json"))
            {
                string json = File.ReadAllText("admins.json");
                if (!string.IsNullOrWhiteSpace(json))
                    admins = JsonSerializer.Deserialize<List<Admin>>(json);
            }
            else
                admins = new List<Admin>();
        }
    }
}