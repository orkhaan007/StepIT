using Database;

namespace Menus
{
    public class BaseMenu
    {
        public static void showBaseMenu()
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Admin", "Employer", "Employee", "About", "Exit" };

            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.FindJobLogo();

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
                            Menus.AdminRegistrationMenu.showAdminRegistrationMenu();
                        else if (selectedOption == 1)
                            Menus.EmployerRegistrationMenu.showEmployerRegistrationMenu();
                        else if (selectedOption == 2)
                            Menus.EmployeeRegistrationMenu.showEmployeeRegistrationMenu();
                        else if (selectedOption == 3)
                            Menus.AboutMenu.showAboutMenu();
                        if (selectedOption == 4)
                        {
                            Console.Clear();
                            Console.WriteLine("Exiting...");
                            return;
                        }
                        break;
                }
            }
        }
    }
}