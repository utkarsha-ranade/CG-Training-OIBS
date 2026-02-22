using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class BlobFunc
    {
        [FunctionName("BlobFunc")]
        public void Run([BlobTrigger("demo/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=mtbsstorr;AccountKey=tZ02IbZRyws1RSYTHPxslmvVfZbThGFmFK0D1M1OtdWk34u9f9a8kp83dIvHOKnnikvh4u/ufUOgefAm8CRDAQ==;EndpointSuffix=core.windows.net")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
