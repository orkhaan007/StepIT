# Find Job Project

Welcome to the FindJob Explorer Project!

Explore the world of job opportunities with our C#-based console application. Discover, customize, and stay updated on job listings that match your preferences.

## Features

- **Job Exploration:** Browse through diverse job listings with detailed information.
- **Customization:** Tailor your job search by filtering listings based on your skills and preferences.
- **Interactive Pages:** Engage with our Contact and Subscribe pages for feedback and updates.
- **User Accounts:** Securely create and manage your profile to save personalized job preferences.
- **Database Integration:** Utilizes a database to store user information and job preferences.
- **Email Notifications:** Stay informed with email updates using the SMTP protocol.

## Getting Started

### Prerequisites

- [Visual Studio](https://visualstudio.microsoft.com/) installed
- [NuGet Package Manager](https://www.nuget.org/) for package dependencies

### Installation

1. Clone the repository: `git clone https://github.com/orkhaan007/FindJob.git`
2. Open the project in Visual Studio.
3. Update App Settings:
   - Navigate to the `ExtraFuncs.cs` file in the project's `Functions` folder.
   - Modify the values in the section according to your SMTP configuration.
  
     Example `ExtraFuncs.cs`:
     ```csharp
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
     ```
4. Build and run the application in Visual Studio.

## Contributing

We welcome contributions! If you'd like to contribute, please fork the repository and create a pull request. Feel free to open issues for feature requests or bug reports.

## Contact

Have questions or feedback? Feel free to reach out to us via email at [your.email@example.com](mailto:orkhanm07@gmail.com).

## License

This project is licensed under the [MIT License](LICENSE).

---

Happy job hunting! 🌐
