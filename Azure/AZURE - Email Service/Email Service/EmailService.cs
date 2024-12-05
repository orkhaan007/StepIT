using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Email_Service
{
    public static class EmailService
    {
        [FunctionName("EmailHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "EmailHttpTrigger/{email}")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HTTP trigger function processed a request.");

            string email = req.Query["mail"];

            if (string.IsNullOrEmpty(email))
            {
                return new BadRequestObjectResult("Please pass a valid 'mail' query parameter.");
            }

            string message = $"Hello {email}, this message is from Azure Function!";

            return new OkObjectResult(message);
        }
    }
}
