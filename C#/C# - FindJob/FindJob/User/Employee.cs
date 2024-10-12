using Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace User
{
    public class Employee : Person
    {
        public List<CV.CV> cvs;
        public List<Vacancy.Vacancy> AppliedVacancies;
        public List<Notification.Notification> notifications;

        public Employee()
        {
            cvs = new List<CV.CV>();
            AppliedVacancies = new List<Vacancy.Vacancy>();
            notifications = new List<Notification.Notification>();
        }

        public Employee(string name, string surname, int age, string password, string city, string phone, string email)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.password = password;
            this.city = city;
            this.phone = phone;
            this.email = email;
            this.cvs = new List<CV.CV>();
            this.notifications = new List<Notification.Notification>();
        }

        public static Employee SignInEmployee(string email, string password)
        {
            Employee employee = EmployeeDatabase.GetEmployeeByEmail(email);
            if (employee != null && employee.password == password)
                return employee;
            else
                throw new ArgumentException("Invalid Password & Invalid Email");
        }
        
        public static void SignUpEmployee(string name, string surname, int age, string password, string city,
            string phone, string email)
        {
            Employee newEmployee = new Employee(name, surname, age, password, city, phone, email);
            EmployeeDatabase.AddEmployee(newEmployee);

            newEmployee.notifications.Add(new Notification.Notification("Welcome! Your registration was successful."));
        }

        public List<Vacancy.Vacancy> GetAppliedVacancies()
        {
            return AppliedVacancies;
        }

        public void ApplyToVacancy(Vacancy.Vacancy vacancy)
        {
            if (AppliedVacancies == null)
                AppliedVacancies = new List<Vacancy.Vacancy>();

            AppliedVacancies.Add(vacancy);

            if (vacancy.Applicants == null)
                vacancy.Applicants = new List<Employee>();

            vacancy.Applicants.Add(this);
        }

        public void showProfile()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Name: " + this.name);
            Console.WriteLine("Surname: " + this.surname);
            Console.WriteLine("Age: " + this.age);
            Console.WriteLine("City: " + this.city);
            Console.WriteLine("Phone: " + this.phone);
            Console.WriteLine("Email: " + this.email);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void showCv()
        {
            Console.Clear();
            if (cvs.Count == 0)
            {
                Console.WriteLine("No CVs found.");
            }
            else
            {
                foreach (var cv in cvs)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("CV Id: " + cv.Id);
                    Console.WriteLine("Title: " + cv.Name);
                    Console.WriteLine("Surname: " + cv.Surname);
                    Console.WriteLine("Experience: " + cv.Experience);
                    Console.WriteLine("Profession: " + cv.Profession);
                    Console.Write("Skills: ");

                    foreach (var skill in cv.Skills)
                    {
                        Console.Write(skill + ", ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("View Count: " + cv.ViewCount++);
                    Console.WriteLine("=======================================");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void EditProfile(string newName, string newSurname, int newAge, string newCity, string newPhone,
            string newEmail)
        {
            Console.Clear();
            this.name = newName;
            this.surname = newSurname;
            this.age = newAge;
            this.city = newCity;
            this.phone = newPhone;
            this.email = newEmail;

            Console.WriteLine("Profile updated successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        public void ShowNotifications()
        {
            Console.Clear();
            if (notifications.Count == 0)
                Console.WriteLine("No notifications found.");
            else
            {
                Console.WriteLine("Notifications:");
                foreach (var notification in notifications)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("ID: " + notification.id);
                    Console.WriteLine("Message: " + notification.message);
                    Console.WriteLine("Date and Time: " + notification.dateTime);
                    Console.WriteLine("=======================================");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowAppliedVacancies()
{
    Console.Clear();
    List<Vacancy.Vacancy> appliedVacancies = GetAppliedVacancies();
    
    if (appliedVacancies == null)
    {
        Console.WriteLine("Error retrieving applied vacancies. Please try again later.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return;
    }

    if (appliedVacancies.Count == 0)
    {
        Console.WriteLine("No vacancies found.");
    }
    else
    {
        Console.WriteLine("All Applied Vacancies:");
        foreach (var vacancy in appliedVacancies)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("Vacancy Id: " + vacancy.Id);
            Console.WriteLine("Vacancy Title: " + vacancy.Title);
            Console.WriteLine("Category: " + vacancy.Category);
            Console.WriteLine("Description: " + vacancy.Description);
            Console.WriteLine("Salary: " + vacancy.Salary);
            Console.WriteLine("=======================================");
        }

        Console.Write("Enter the Id of the vacancy you want to view: ");
        string choice = Console.ReadLine();
        if (Guid.TryParse(choice, out Guid selectedVacancyId))
        {
            var selectedVacancy = appliedVacancies.FirstOrDefault(v => v.Id == selectedVacancyId);
            if (selectedVacancy != null)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("Vacancy Id: " + selectedVacancy.Id);
                Console.WriteLine("Vacancy Title: " + selectedVacancy.Title);
                Console.WriteLine("Description: " + selectedVacancy.Description);
                Console.WriteLine("Uptaded Date: " + selectedVacancy.UpdateDate);
                Console.WriteLine("Expire Date: " + selectedVacancy.ExpireDate);
                Console.WriteLine("Category: " + selectedVacancy.Category);
                Console.WriteLine("Active: " + selectedVacancy.IsActive);
                Console.WriteLine("View Count: " + selectedVacancy.ViewCount++);
                Console.WriteLine("Salary: " + selectedVacancy.Salary);
                Console.WriteLine("=======================================");
            }
            else
            {
                Console.WriteLine("Vacancy with the specified Id not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Vacancy Id.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

        public static void ShowVacanciesByCategory(string category)
        {
            Console.Clear();
            List<Vacancy.Vacancy> categoryVacancies = Database.VacancyDatabase.GetVacanciesByCategory(category);
            if (categoryVacancies.Count == 0)
                Console.WriteLine("No vacancies found in the selected category.");
            else
            {
                Console.WriteLine("Vacancies in Category '" + category + "':");
                foreach (var vacancy in categoryVacancies)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("Vacancy Id: " + vacancy.Id);
                    Console.WriteLine("Vacancy Title: " + vacancy.Title);
                    Console.WriteLine("Category: " + vacancy.Category);
                    Console.WriteLine("Description: " + vacancy.Description);
                    Console.WriteLine("Salary: " + vacancy.Salary);
                    Console.WriteLine("=======================================");
                }

                Console.Write("Enter the Id of the vacancy you want to view: ");
                string choice = Console.ReadLine();
                if (Guid.TryParse(choice, out Guid selectedVacancyId))
                {
                    var selectedVacancy = categoryVacancies.FirstOrDefault(v => v.Id == selectedVacancyId);
                    if (selectedVacancy != null)
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Vacancy Id: " + selectedVacancy.Id);
                        Console.WriteLine("Vacancy Title: " + selectedVacancy.Title);
                        Console.WriteLine("Description: " + selectedVacancy.Description);
                        Console.WriteLine("Uptaded Date: " + selectedVacancy.UpdateDate);
                        Console.WriteLine("Expire Date: " + selectedVacancy.ExpireDate);
                        Console.WriteLine("Category: " + selectedVacancy.Category);
                        Console.WriteLine("Active: " + selectedVacancy.IsActive);
                        Console.WriteLine("View Count: " + selectedVacancy.ViewCount++);
                        Console.WriteLine("Salary: " + selectedVacancy.Salary);
                        Console.WriteLine("=======================================");
                    }
                    else
                    {
                        Console.WriteLine("Vacancy with the specified Id not found.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Vacancy Id.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        public static void ShowAllVacancies()
        {
            Console.Clear();
            List<Vacancy.Vacancy> allVacancies = Database.VacancyDatabase.GetAllVacancies();
            if (allVacancies.Count == 0)
                Console.WriteLine("No vacancies found.");
            else
            {
                Console.WriteLine("All Vacancies:");
                foreach (var vacancy in allVacancies)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("Vacancy Id: " + vacancy.Id);
                    Console.WriteLine("Vacancy Title: " + vacancy.Title);
                    Console.WriteLine("Category: " + vacancy.Category);
                    Console.WriteLine("Description: " + vacancy.Description);
                    Console.WriteLine("Salary: " + vacancy.Salary);
                    Console.WriteLine("=======================================");
                }

                Console.Write("Enter the Id of the vacancy you want to view: ");
                string choice = Console.ReadLine();
                if (Guid.TryParse(choice, out Guid selectedVacancyId))
                {
                    var selectedVacancy = allVacancies.FirstOrDefault(v => v.Id == selectedVacancyId);
                    if (selectedVacancy != null)
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Vacancy Id: " + selectedVacancy.Id);
                        Console.WriteLine("Vacancy Title: " + selectedVacancy.Title);
                        Console.WriteLine("Description: " + selectedVacancy.Description);
                        Console.WriteLine("Uptaded Date: " + selectedVacancy.UpdateDate);
                        Console.WriteLine("Expire Date: " + selectedVacancy.ExpireDate);
                        Console.WriteLine("Category: " + selectedVacancy.Category);
                        Console.WriteLine("Active: " + selectedVacancy.IsActive);
                        Console.WriteLine("View Count: " + selectedVacancy.ViewCount++);
                        Console.WriteLine("Salary: " + selectedVacancy.Salary);
                        Console.WriteLine("=======================================");
                    }
                    else
                    {
                        Console.WriteLine("Vacancy with the specified Id not found.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Vacancy Id.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        public void ShowApplyVacancies()
        {
            Console.Clear();
            List<Vacancy.Vacancy> allVacancies = Database.VacancyDatabase.GetAllVacancies();
            if (allVacancies.Count == 0)
            {
                Console.WriteLine("No vacancies found.");
            }
            else
            {
                Console.WriteLine("All Vacancies:");
                foreach (var vacancy in allVacancies)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine("Vacancy Id: " + vacancy.Id);
                    Console.WriteLine("Vacancy Title: " + vacancy.Title);
                    Console.WriteLine("Category: " + vacancy.Category);
                    Console.WriteLine("Description: " + vacancy.Description);
                    Console.WriteLine("Salary: " + vacancy.Salary);
                    Console.WriteLine("=======================================");
                }

                Console.Write("Enter the Id of the vacancy you want to view: ");
                string choice = Console.ReadLine();
                if (Guid.TryParse(choice, out Guid selectedVacancyId))
                {
                    var selectedVacancy = allVacancies.FirstOrDefault(v => v.Id == selectedVacancyId);
                    if (selectedVacancy != null)
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Vacancy Id: " + selectedVacancy.Id);
                        Console.WriteLine("Vacancy Title: " + selectedVacancy.Title);
                        Console.WriteLine("Description: " + selectedVacancy.Description);
                        Console.WriteLine("Uptaded Date: " + selectedVacancy.UpdateDate);
                        Console.WriteLine("Expire Date: " + selectedVacancy.ExpireDate);
                        Console.WriteLine("Category: " + selectedVacancy.Category);
                        Console.WriteLine("Active: " + selectedVacancy.IsActive);
                        Console.WriteLine("View Count: " + selectedVacancy.ViewCount++);
                        Console.WriteLine("Salary: " + selectedVacancy.Salary);
                        Console.WriteLine("=======================================");
                        
                        Console.Write("Do you want to apply for this vacancy? (y/n): ");
                        string applyChoice = Console.ReadLine().ToLower();
                        if (applyChoice == "y")
                        {
                            ApplyToVacancy(selectedVacancy);
                            Console.WriteLine("You have applied for this vacancy.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vacancy with the specified Id not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Vacancy Id.");
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void CreateCV()
        {
            Console.Clear();

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter Profession: ");
            string profession = Console.ReadLine();

            Console.WriteLine("Enter Experience: ");
            string experience = Console.ReadLine();

            Console.WriteLine("Enter Skills (comma-separated): ");
            string skillsInput = Console.ReadLine();
            List<string> skills = skillsInput.Split(',').Select(skill => skill.Trim()).ToList();

            CV.CV newCV = new CV.CV(profession, experience, skills, name, surname);

            Console.WriteLine("CV created successfully.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            cvs.Add(newCV);
        }
    }
}