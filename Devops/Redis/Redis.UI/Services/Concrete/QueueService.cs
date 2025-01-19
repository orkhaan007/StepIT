using Azure.Storage.Queues.Models;
using Azure.Storage.Queues;
using Redis.UI.Services.Abstract;

namespace Redis.UI.Services.Concrete
{
    public class QueueService : IQueueService
    {
        private readonly QueueClient queueClient;

        public QueueService(string connectionString, string queueName)
        {
            queueClient = new QueueClient(connectionString, queueName);
            queueClient.CreateIfNotExists();
        }
        public async Task DeleteMessageAsync(string messageId, string popReceipt)
        {
            await queueClient.DeleteMessageAsync(messageId, popReceipt);
        }
        public async Task<QueueMessage> ReceiveMessageAsync()
        {
            var messageResponse = await queueClient.ReceiveMessageAsync(TimeSpan.FromSeconds(2));
            if (messageResponse.Value != null)
            {
                var message = messageResponse.Value;
                return message;
            }
            return null;
        }

        public async Task SendMessageAsync(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                try
                {
                    var utf8Message = System.Text.Encoding.UTF8.GetBytes(message);
                    await queueClient.SendMessageAsync(Convert.ToBase64String(utf8Message), visibilityTimeout: TimeSpan.Zero);

                    Console.WriteLine("Successfully Sent!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending message: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Message is empty or whitespace.");
            }
        }
    }
}
