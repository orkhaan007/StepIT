using System.Text.RegularExpressions;
using Database;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;


namespace ExtraFunc
{
    public static class ExtraFuncs
    {
        public static string GetMaskedInput()
        {
            string input = "";
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return input;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidAzerbaijanPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+994(?:10|51|70|77|99|50|55)[0-9]{7}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidName(string name)
        {
            string pattern = @"^[A-Z][a-z]{0,9}$";
            return Regex.IsMatch(name, pattern);
        }

        public static bool IsValidSurName(string surname)
        {
            string pattern = @"^[A-Z][a-z]{0,9}$";
            return Regex.IsMatch(surname, pattern);
        }

        public static bool IsValidAge(int age)
        {
            return age >= 0 && age <= 90;
        }

        public static bool IsValidCity(string city)
        {
            string pattern = @"^[A-Z][a-z]{0,9}$";
            return Regex.IsMatch(city, pattern);
        }

        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static void ReadAndPrintFileSymbolBySymbolAZ(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int symbol;
                    while ((symbol = reader.Read()) != -1)
                    {
                        char character = (char)symbol;
                        Console.Write(character);
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadAndPrintFileSymbolBySymbolTR(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int symbol;
                    while ((symbol = reader.Read()) != -1)
                    {
                        char character = (char)symbol;
                        Console.Write(character);
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadAndPrintFileSymbolBySymbolEN(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    int symbol;
                    while ((symbol = reader.Read()) != -1)
                    {
                        char character = (char)symbol;
                        Console.Write(character);
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public static string GenerateRandomVerificationCode()
        {
            Random random = new Random();
            int code = random.Next(1000, 9999);
            return code.ToString();
        }

        public static bool VerifyVerificationCode(string generatedCode, string userEnteredCode)
        {
            return generatedCode == userEnteredCode;
        }
        
        public static string SendVerificationCodeByEmail(string userEmail)
        {
            string verificationCode = GenerateRandomVerificationCode();
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("", ""),
                    EnableSsl = true,
                };
                MailMessage message = new MailMessage();
                message.From = new MailAddress("FindJobRegistration@findjob.com");
                message.Subject = "Verification Code";
                message.To.Add(new MailAddress(userEmail));
                message.Body = $"Your verification code is: {verificationCode}";
                smtpClient.Send(message);
                return verificationCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending verification email: {ex.Message}");
                return null;
            }
        }
        
        public static string HelpAndSupprt(string userEmail)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("YOUR_EMAIL", "YOUR_PASSWORD"),
                    EnableSsl = true,
                };
                MailMessage message = new MailMessage();
                message.From = new MailAddress("FindJobRegistration@findjob.com");
                message.Subject = "Help&Support";
                message.To.Add(new MailAddress(userEmail));
                message.Body = $"Thank you for your interest. There is no service available at the moment, but your message will be answered as soon as possible.";
                smtpClient.Send(message);
                return "Success!";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending verification email: {ex.Message}");
                return null;
            }
        }

    }
}
