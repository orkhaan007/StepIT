using System.Data.Common;
using Database;
using User;

namespace FindJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.AdminDatabase.LoadAdminsFromJson();
            Database.EmployerDatabase.LoadEmployersFromJson();
            Database.EmployeeDatabase.LoadEmployeesFromJson();
            Database.VacancyDatabase.LoadVacancysFromJson();
            Admin admin1 = new Admin("Orkhan", "Mammadli", "ork", "ork1");
            Employer employer1 = new Employer("Salam", "Sagol", 18, "salam123", "Baku", "+994555555555", "salam@gmail.com");
            Employee employee2 = new Employee("Sagol", "Salam", 21, "sagol123", "Dubai", "+994666666666", "sagol@gmail.com");
            Vacancy.Vacancy vacancy1 = new Vacancy.Vacancy("Title 1", "Car", 1200, "1 About");
            Vacancy.Vacancy vacancy2 = new Vacancy.Vacancy("Title 2", "Car", 3200, "2 About");
            Vacancy.Vacancy vacancy3 = new Vacancy.Vacancy("Title 3", "Girl", 2200, "3 About");
            Vacancy.Vacancy vacancy4 = new Vacancy.Vacancy("Title 4", "Boy", 132200, "4 About");
            Database.AdminDatabase.AddAdmin(admin1);
            Database.EmployerDatabase.AddEmployer(employer1);
            Database.EmployeeDatabase.AddEmployee(employee2);
            Database.VacancyDatabase.AddVacancy(vacancy1);
            Database.VacancyDatabase.AddVacancy(vacancy2);
            Database.VacancyDatabase.AddVacancy(vacancy3);
            Database.VacancyDatabase.AddVacancy(vacancy4);
            employee2.ApplyToVacancy(vacancy1);
            Menus.BaseMenu.showBaseMenu();
        }
    }
}