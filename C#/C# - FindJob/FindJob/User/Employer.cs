using Database;
using System;
using System.Collections.Generic;

namespace User
{
    public class Employer : Person
    {
        public List<Vacancy.Vacancy> PublishedVacancies { get; set; }
        public List<Employee> ApplicantsList { get; set; }
        public List<Notification.Notification> Notifications { get; set; }

        public Employer()
        {
            ApplicantsList = new List<Employee>();
            Notifications = new List<Notification.Notification>();
            PublishedVacancies = new List<Vacancy.Vacancy>();
        }

        public Employer(string name, string surname, int age, string password, string city, string phone, string email)
        {
            this.id = Guid.NewGuid();
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.password = password;
            this.city = city;
            this.phone = phone;
            this.email = email;
            ApplicantsList = new List<Employee>();
            Notifications = new List<Notification.Notification>();
            PublishedVacancies = new List<Vacancy.Vacancy>();
        }

        public static Employer SignInEmployer(string email, string password)
        {
            Employer employer = EmployerDatabase.GetEmployerByEmail(email);
            if (employer != null && employer.password == password)
                return employer;
            else
                throw new ArgumentException("Invalid Password & Invalid Email");
        }
        
        public static void SignUpEmployer(string name, string surname, int age, string password, string city,
            string phone, string email)
        {
            Employer newEmployer = new Employer(name, surname, age, password, city, phone, email);
            EmployerDatabase.AddEmployer(newEmployer);

            newEmployer.Notifications.Add(new Notification.Notification("Welcome! Your registration was successful."));
        }

        public void CreateVacancy(string title, string category, float salary, string description)
        {
            if (PublishedVacancies == null)
            {
                PublishedVacancies = new List<Vacancy.Vacancy>();
            }

            Vacancy.Vacancy newVacancy = new Vacancy.Vacancy(title, category, salary, description);
            PublishedVacancies.Add(newVacancy);
            Database.VacancyDatabase.AddVacancy(newVacancy);
        }

        public void AcceptApplication(Employee applicant, Vacancy.Vacancy vacancy)
        {
            if (ApplicantsList != null)
            {
                ApplicantsList.Remove(applicant);
            }

            if (vacancy != null && vacancy.Applicants != null)
            {
                vacancy.Applicants.Remove(applicant);
            }
        }

        public List<Vacancy.Vacancy> AllPublishedVacancies()
        {
            if (PublishedVacancies != null)
            {
                return PublishedVacancies;
            }
            else
            {
                return new List<Vacancy.Vacancy>();
            }
        }

        public void ShowPublishedVacancies()
        {
            Console.Clear();
            if (PublishedVacancies == null || PublishedVacancies.Count == 0)
            {
                Console.WriteLine("No published vacancies found.");
            }
            else
            {
                int vacancyIndex = 1;

                foreach (var vacancy in PublishedVacancies)
                {
                    Console.WriteLine($"{vacancyIndex}. Title: {vacancy.Title}");
                    vacancyIndex++;
                }

                Console.WriteLine("-------------------------------------------");
                Console.Write("Enter the ID of the vacancy to see applicants (0 to go back): ");

                if (int.TryParse(Console.ReadLine(), out int selectedVacancyIndex))
                {
                    if (selectedVacancyIndex >= 1 && selectedVacancyIndex <= PublishedVacancies.Count)
                    {
                        Vacancy.Vacancy selectedVacancy = PublishedVacancies[selectedVacancyIndex - 1];
                        ShowApplicants(selectedVacancy);
                        return;
                    }
                    else if (selectedVacancyIndex == 0)
                    {
                        return;
                    }
                }

                Console.WriteLine("Invalid input. Press any key to continue...");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowApplicants(Vacancy.Vacancy vacancy)
        {
            Console.Clear();
            Console.WriteLine("Applicants for Vacancy: " + vacancy.Title);

            if (vacancy != null && vacancy.Applicants != null && vacancy.Applicants.Count == 0)
            {
                Console.WriteLine("No applicants found for this vacancy.");
            }
            else
            {
                foreach (var applicant in vacancy.Applicants)
                {
                    Console.WriteLine("Name: " + applicant.name);
                    Console.WriteLine("Surname: " + applicant.surname);
                    Console.WriteLine("Age: " + applicant.age);
                    Console.WriteLine("City: " + applicant.city);
                    Console.WriteLine("Phone: " + applicant.phone);
                    Console.WriteLine("Email: " + applicant.email);
                    Console.WriteLine("CV: ");
                    applicant.showCv();
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowNotifications()
        {
            Console.Clear();
            if (Notifications == null || Notifications.Count == 0)
            {
                Console.WriteLine("No notifications found.");
            }
            else
            {
                Console.WriteLine("Notifications:");
                foreach (var notification in Notifications)
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

        public void ShowProfile()
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

        public void EditProfile(string newName, string newSurname, int newAge, string newCity, string newPhone, string newEmail)
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
    }
}