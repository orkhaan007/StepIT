using LogService.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogController : ControllerBase
{
    private readonly ILogInformationService _logService;

    public LogController(ILogInformationService logService)
    {
        _logService = logService;
    }

    [HttpGet("{logMessage}")]
    public IActionResult Log(string logMessage)
    {
        _logService.LogInfo(logMessage);
        return Ok(logMessage);
    }
}
