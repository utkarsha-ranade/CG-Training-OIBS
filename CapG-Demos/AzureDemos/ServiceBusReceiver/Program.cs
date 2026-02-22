using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace ServiceBusReceiver
{
    internal class Program
    {
        const string connString = "Endpoint=sb://mtbs47.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=at0D9bjQQXON7Vni3nFM5LNBm9nwYTs1iVSGb8WXxxk=";
        const string queueName = "demoque";
        static ServiceBusClient client;
        static ServiceBusProcessor processor;
        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(connString);
            processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StopProcessingAsync();
                Console.WriteLine("Wait for a minute and press a key");
                Console.Read();
                Console.WriteLine("\n Stopping the receiver.");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages.");
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
        }

        private static Task ErrorHandler(ProcessErrorEventArgs arg)
        {
            Console.WriteLine(arg.Exception.ToString());
            return Task.CompletedTask;
        }

        private static async Task MessageHandler(ProcessMessageEventArgs arg)
        {
            string body = arg.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");
            await arg.CompleteMessageAsync(arg.Message);
        }
    }
}
