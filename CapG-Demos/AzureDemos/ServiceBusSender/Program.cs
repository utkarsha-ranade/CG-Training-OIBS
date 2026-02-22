using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace ServiceBusSender
{
    internal class Program
    {
        const string connString = "Endpoint=sb://mtbs47.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=at0D9bjQQXON7Vni3nFM5LNBm9nwYTs1iVSGb8WXxxk=";
        const string queueName = "demoque";
        const int NoOfMessages = 4;
        static ServiceBusClient client;
        static Azure.Messaging.ServiceBus.ServiceBusSender sender;
        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(connString);
            sender = client.CreateSender(queueName);
            ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            for (int i = 1; i < NoOfMessages; i++)
            {
                if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
                {
                    throw new Exception($"Message {i} is too large to fit in the batch.");
                }
            }
            try
            {
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine($"Batch of {NoOfMessages} messages published to the queue.");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
            Console.Read();
        }
    }
}
