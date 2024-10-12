using LogService.Services.Abstract;

namespace LogService.Services.Concrete;

public class LogInformationService : ILogInformationService
{
    public void LogInfo(string message)
    {
        File.WriteAllText("Log.txt", message);
    }
}
