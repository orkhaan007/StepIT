using Database;
using User;

namespace Menus
{
    public class VacancyMenu
    {
        public static void showVacancyMenu(Employee employee)
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "Vacancies", "Vacancies By Category", "Apply To Vacancy", "Applied Vacancies", "Back" };

            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.VacanciesLogo();

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
                            User.Employee.ShowAllVacancies();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        if (selectedOption == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter a category: ");
                            string category = Console.ReadLine();
                            User.Employee.ShowVacanciesByCategory(category);
                            Console.ReadKey();
                        }
                        if (selectedOption == 2)
                            employee.ShowApplyVacancies();
                        if (selectedOption == 3)
                        {
                            Console.Clear();
                            employee.ShowAppliedVacancies();
                            Console.ReadKey();
                        }
                        if (selectedOption == 4)
                            return;
                        break;
                }
            }
        }
    }
}