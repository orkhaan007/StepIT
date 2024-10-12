using Database;
using User;

namespace Menus
{
    public class EmployerMenu
    {
        public static void showEmployerMenu(Employer employer)
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Vacancy", "Profile", "Help & Support", "Notifications", "Exit" };
            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.EmployersLogo();

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
                            Menus.EmployerVacancyMenu.showEmployerVacancyMenu(employer);
                        }
                        if (selectedOption == 1)
                            Menus.EmployerProfileMenu.showEmployerProfileMenu(employer);
                        if (selectedOption == 2)
                        {
                            Console.Clear();
                            string message;
                            Console.WriteLine("Enter Problem: ");
                            message = Console.ReadLine();
                            ExtraFunc.ExtraFuncs.HelpAndSupprt(employer.email);
                            Console.WriteLine("Sucesssfully, Sented Your Message To FindJob Admins");
                            Thread.Sleep(1000);
                            Menus.EmployerMenu.showEmployerMenu(employer);
                        }
                        if (selectedOption == 3)
                            employer.ShowNotifications();
                        if (selectedOption == 4)
                            return;
                        break;
                }
            }
        }
    }
}