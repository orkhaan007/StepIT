using Database;

namespace Menus
{
    public class EmployerRegistrationMenu
    {
        public static void showEmployerRegistrationMenu()
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Sign In", "Sign Up", "Back" };

            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.RegistrationLogo();

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
                            Console.WriteLine("Enter Email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter Password: ");
                            string password = Console.ReadLine();
                            User.Employer employer = User.Employer.SignInEmployer(email, password);
                            if (employer == null)
                                throw new Exception("Invalid Information");
                            else
                            {
                                Console.WriteLine($@"Success, Welcome Back {employer.name}");
                                Thread.Sleep(1000);
                                Menus.EmployerMenu.showEmployerMenu(employer);
                            }
                            Menus.EmployerMenu.showEmployerMenu(employer);
                            Console.ReadKey();
                        }

                        if (selectedOption == 1)
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

                            string verificationCode = ExtraFunc.ExtraFuncs.SendVerificationCodeByEmail(email);

                            if (!string.IsNullOrEmpty(verificationCode))
                            {
                                Console.WriteLine(
                                    "A verification code has been sent to your email. Please enter the code to complete registration:");
                                string userEnteredCode = Console.ReadLine();

                                if (ExtraFunc.ExtraFuncs.VerifyVerificationCode(verificationCode, userEnteredCode))
                                {
                                    User.Employer.SignUpEmployer(name, surname, age, passwordd, city, phone, email);
                                    Console.WriteLine("Registration successful!");
                                    Database.EmployerDatabase.SaveEmployersToJson();
                                    Thread.Sleep(1000);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid verification code. Registration failed.");
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error sending verification code. Registration failed.");
                                Thread.Sleep(1000);
                            }
                        }

                        if (selectedOption == 2)
                            return;
                        break;
                }
            }
        }
    }
}