using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Timer
{
    public class TimerTriggerFunction
    {
        [FunctionName("GenerateGuidAndSendToQueue")]
        public static async Task Run(
        [Microsoft.Azure.Functions.Worker.TimerTrigger("*/5 * * * * *")] Microsoft.Azure.Functions.Worker.TimerInfo timer,
        [Queue("queue-items", Connection = "QueueStorageConnectionString")] IAsyncCollector<string> productQueue,
        ILogger log)
        {
            var newGuid = Guid.NewGuid().ToString();
            log.LogInformation($"Generated GUID: {newGuid}");

            await productQueue.AddAsync(newGuid);
            log.LogInformation($"Added GUID to queue: {newGuid}");
        }
    }
}
