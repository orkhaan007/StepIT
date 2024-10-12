namespace Menus
{
    public class AboutMenu
    {
        public static void showAboutMenu()
        {
            Console.CursorVisible = false;
            int selectedOption = 0;
            string[] options = { "AZ", "EN", "TR", "Back" };

            while (true)
            {
                Console.Clear();
                Logos.Logos.Logo.AboutLogo();

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
                        if(selectedOption == 0)
                        {
                            Console.Clear();
                            ExtraFunc.ExtraFuncs.ReadAndPrintFileSymbolBySymbolAZ("AboutAZ.txt");
                            Console.ReadKey();
                        }
                        else if(selectedOption == 1)
                        {
                            Console.Clear();
                            ExtraFunc.ExtraFuncs.ReadAndPrintFileSymbolBySymbolEN("AboutEN.txt");
                            Console.ReadKey();
                        }
                        else if(selectedOption == 2)
                        {
                            Console.Clear();
                            ExtraFunc.ExtraFuncs.ReadAndPrintFileSymbolBySymbolTR("AboutTR.txt");
                            Console.ReadKey();
                        }
                        else if(selectedOption == 3)
                            return;
                        break;
                }
            }
        }
    }
}
