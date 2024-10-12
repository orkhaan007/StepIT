using Database;

namespace Menus
{
    public class AdminRegistrationMenu
    {
        public static void showAdminRegistrationMenu()
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Sign In", "Back" };

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
                            if (User.Admin.SignInAdmin(email, password))
                            {
                                User.Admin currentAdminName = AdminDatabase.GetAdminByEmail(email);
                                Console.WriteLine($@"Success, Welcome Back {currentAdminName.name}");
                                Thread.Sleep(150);
                            }
                            Menus.AdminMenu.showAdminMenu();
                            Console.ReadKey();
                        }
                        if (selectedOption == 1)
                            return;
                        break;
                }
            }
        }
    }
}