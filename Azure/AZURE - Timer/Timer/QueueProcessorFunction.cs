using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Timer
{
    public static class QueueProcessorFunction
    {
        [FunctionName("ProcessQueueAndDelete")]
        public static async Task Run(
            [TimerTrigger("*/7 * * * * *")] TimerInfo timer,
            [Queue("queue-items", Connection = "QueueStorageConnectionString")] CloudQueue queue,
            ILogger log)
        {
            var message = await queue.GetMessageAsync();

            if (message != null)
            {
                log.LogInformation($"Processing GUID: {message.AsString}");

                await queue.DeleteMessageAsync(message);
                log.LogInformation($"Deleted GUID from queue: {message.AsString}");
            }
            else
            {
                log.LogInformation("No message in the queue to process.");
            }
        }
    }
}
