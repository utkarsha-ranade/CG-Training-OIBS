using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Web.Http;

namespace AddOrderToDb
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var orderDto = JsonConvert.DeserializeObject<OrderDto>(requestBody);

            try
            {
                string connString = Environment.GetEnvironmentVariable("SqlConnString");
                //ADO.NET connected arch
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    string cmdText = $"insert into Orders(OrderDate, CustomerId, IsCanceled)" +
                            $" output inserted.Id" +
                            $" values('{orderDto.Order.OrderDate}', {orderDto.Order.CustomerId}, {0})";
                    using(SqlCommand command = new SqlCommand(cmdText, connection))
                    {
                        connection.Open();
                        int orderId = (int)await command.ExecuteScalarAsync();
                        int recordsAffected = 0;
                        foreach (var item in orderDto.Items)
                        {
                            command.CommandText = $"insert into OrderItems(Quantity, Price, OrderId, ProductId)" +
                                                    $"values({item.Quantity}, {item.Product.Price},{orderId}, {item.Product.Id})";
                            recordsAffected = await command.ExecuteNonQueryAsync();
                        }
                        log.LogInformation("Order added to database.");
                    }
                }
            }
            catch (SqlException ex)
            {
                log.LogError(ex.Message);
                return new UnprocessableEntityObjectResult("Failed to add Order.");
            }
            return new CreatedResult("order", orderDto);
        }
    }
}
