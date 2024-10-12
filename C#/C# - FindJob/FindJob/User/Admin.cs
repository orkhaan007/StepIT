using Database;

namespace User
{
    public class Admin : Person
    {
        public Admin() { }

        public Admin(string name, string surname, string email, string password)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
        }

        public static bool SignInAdmin(string email, string password)
        {
            Admin admin = AdminDatabase.GetAdminByEmail(email);
            if (admin == null || admin.password != password)
                throw new ArgumentException();
            return true;
        }
        
        public void AddEmployee(Employee newEmployee)
        {
            EmployeeDatabase.AddEmployee(newEmployee);
            Console.WriteLine("Successfully Added Employee!");
        }
        
        public static void AddEmployer(Employer newEmployer)
        {
            EmployerDatabase.AddEmployer(newEmployer);
            Console.WriteLine("Successfully Added Employer!");
        }
        
        public void DeleteEmployee(Guid employeeId)
        {
            Employee employeeToDelete = EmployeeDatabase.GetEmployeeById(employeeId);
            if (employeeToDelete != null)
            {
                EmployeeDatabase.DeleteEmployee(employeeToDelete);
                Console.WriteLine("Successfully Deleted Employee!");
            }
            else
                throw new IndexOutOfRangeException("Employee Not Found");
        }
        
        public void DeleteEmployer(Guid employerId)
        {
            Employer employerToDelete = EmployerDatabase.GetEmployerById(employerId);
            if (employerToDelete != null)
            {
                EmployerDatabase.DeleteEmployer(employerToDelete);
                Console.WriteLine("Successfully Deleted Employer!");
            }
            else
                throw new IndexOutOfRangeException("Employer Not Found");
        }
    }
}