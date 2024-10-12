using Database;
using ExtraFunc;
using System;
using User;

namespace Menus
{
    public class AdminMenu
    {
        public static void showAdminMenu()
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Add Employer", "Add Employee", "Delete Employer", "Delete Employee", "Back" };

            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.AdminLogo();

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("                                                          " + options[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("                                                          " + options[i]);
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (selectedOption > 0)
                            selectedOption--;
                        else
                            selectedOption = options.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (selectedOption < options.Length - 1)
                            selectedOption++;
                        else
                            selectedOption = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (selectedOption == 0)
                        {
                            Console.Clear();
                            string name, surname, passwordd, ageString, city, phone, email;
                            int age;
                            do
                            {
                                Console.WriteLine("Enter Name: ");
                                name = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidName(name))
                                    Console.WriteLine("Invalid input for Name. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidName(name));
                            do
                            {
                                Console.WriteLine("Enter SurName: ");
                                surname = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidSurName(surname))
                                    Console.WriteLine("Invalid input for Surname. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidSurName(surname));
                            do
                            {
                                Console.WriteLine("Enter Age: ");
                                ageString = Console.ReadLine();
                                if (!int.TryParse(ageString, out age))
                                    Console.WriteLine("Invalid input for Age. Please enter a valid integer.");
                                else if (!ExtraFunc.ExtraFuncs.IsValidAge(age))
                                    Console.WriteLine("Age is not valid. Please try again.");
                            } while (!int.TryParse(ageString, out age) || !ExtraFunc.ExtraFuncs.IsValidAge(age));

                            do
                            {
                                Console.WriteLine("Enter Password: ");
                                passwordd = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidPassword(passwordd))
                                {
                                    Console.WriteLine("Invalid input for Password. Please try again.");
                                }
                            } while (!ExtraFunc.ExtraFuncs.IsValidPassword(passwordd));
                            do
                            {
                                Console.WriteLine("Enter City: ");
                                city = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidCity(city))
                                    Console.WriteLine("Invalid input for City. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidCity(city));
                            do
                            {
                                Console.WriteLine("Enter Phone: ");
                                phone = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidAzerbaijanPhoneNumber(phone))
                                    Console.WriteLine("Invalid input for Phone. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidAzerbaijanPhoneNumber(phone));
                            do
                            {
                                Console.WriteLine("Enter Email: ");
                                email = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidEmail(email))
                                    Console.WriteLine("Invalid input for Email. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidEmail(email));

                            Employer newEmployer = new Employer(name, surname, age, passwordd, city, phone, email);
                            EmployerDatabase.AddEmployer(newEmployer);
                            Database.EmployerDatabase.SaveEmployersToJson();
                            Console.WriteLine("Successfully Added New Employer");
                            Thread.Sleep(1000);
                        }
                        else if (selectedOption == 1)
                        {
                            Console.Clear();
                            string name, surname, passwordd, ageString, city, phone, email;
                            int age;
                            do
                            {
                                Console.WriteLine("Enter Name: ");
                                name = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidName(name))
                                    Console.WriteLine("Invalid input for Name. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidName(name));
                            do
                            {
                                Console.WriteLine("Enter SurName: ");
                                surname = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidSurName(surname))
                                    Console.WriteLine("Invalid input for Surname. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidSurName(surname));
                            do
                            {
                                Console.WriteLine("Enter Age: ");
                                ageString = Console.ReadLine();
                                if (!int.TryParse(ageString, out age))
                                    Console.WriteLine("Invalid input for Age. Please enter a valid integer.");
                                else if (!ExtraFunc.ExtraFuncs.IsValidAge(age))
                                    Console.WriteLine("Age is not valid. Please try again.");
                            } while (!int.TryParse(ageString, out age) || !ExtraFunc.ExtraFuncs.IsValidAge(age));

                            do
                            {
                                Console.WriteLine("Enter Password: ");
                                passwordd = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidPassword(passwordd))
                                {
                                    Console.WriteLine("Invalid input for Password. Please try again.");
                                }
                            } while (!ExtraFunc.ExtraFuncs.IsValidPassword(passwordd));
                            do
                            {
                                Console.WriteLine("Enter City: ");
                                city = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidCity(city))
                                    Console.WriteLine("Invalid input for City. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidCity(city));
                            do
                            {
                                Console.WriteLine("Enter Phone: ");
                                phone = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidAzerbaijanPhoneNumber(phone))
                                    Console.WriteLine("Invalid input for Phone. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidAzerbaijanPhoneNumber(phone));
                            do
                            {
                                Console.WriteLine("Enter Email: ");
                                email = Console.ReadLine();
                                if (!ExtraFunc.ExtraFuncs.IsValidEmail(email))
                                    Console.WriteLine("Invalid input for Email. Please try again.");
                            } while (!ExtraFunc.ExtraFuncs.IsValidEmail(email));

                            Employee newEmployee = new Employee(name, surname, age, passwordd, city, phone, email);
                            EmployeeDatabase.AddEmployee(newEmployee);
                            // Database.EmployeeDatabase.SaveEmployeesToJson();
                            Console.WriteLine($@"Successfully Added New Employee {newEmployee.name}");
                            Thread.Sleep(1000);
                            showAdminMenu();
                        }
                        else if (selectedOption == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Email For Delete Employer");
                            string email = Console.ReadLine();
                            Employer currentEmployer = Database.EmployerDatabase.GetEmployerByEmail(email);
                            Database.EmployerDatabase.DeleteEmployer(currentEmployer);
                            Console.WriteLine($@"Successfully Deleted Employer {currentEmployer.name}");
                            // Database.EmployerDatabase.SaveEmployersToJson();
                            Thread.Sleep(1000);
                            showAdminMenu();
                        }
                        else if (selectedOption == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Email For Delete Employee");
                            string email = Console.ReadLine();
                            Employee currentEmployee = Database.EmployeeDatabase.GetEmployeeByEmail(email);
                            Database.EmployeeDatabase.DeleteEmployee(currentEmployee);
                            Console.WriteLine($@"Successfully Deleted Employee {currentEmployee.name}");
                            // Database.EmployeeDatabase.SaveEmployeesToJson();
                            Thread.Sleep(1000);
                            showAdminMenu();
                        }
                        if (selectedOption == 4)
                            return;
                        break;
                }
            }
        }
    }
}