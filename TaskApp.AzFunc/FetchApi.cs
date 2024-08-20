using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Azure.Storage.Blobs;
using FetchApiData.Model;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System.IO;

namespace FetchApiData
{
    public class FetchApi
    {
        [FunctionName("FetchApi")]
        public async Task Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
        {
            var StartTime = DateTime.Now;
            var url = Environment.GetEnvironmentVariable("Endpoint");
            log.LogInformation($"C# Timer trigger function executed at: {StartTime}");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    Guid currentId = Guid.NewGuid();
                    var blobUrl = await InsertIntoBlob(currentId.ToString(),response);

                    var apiLogs = new ApiLogs
                    {
                        Name="Api-Call",
                        RowKey = currentId.ToString(),
                        PartitionKey = "api-call",
                        StartTime = DateTime.SpecifyKind(StartTime, DateTimeKind.Utc),
                        EndTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                        ResponseData = blobUrl
                    };
                    await InsertIntoTable(apiLogs);
                    log.LogInformation(blobUrl);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<string> InsertIntoBlob(string blobId, HttpResponseMessage responseMessage)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("ContainerName"));
            await blobContainerClient.CreateIfNotExistsAsync();
            var data = responseMessage.Content.ReadAsStringAsync();
            var responsed = await blobContainerClient.UploadBlobAsync(blobId, responseMessage.Content.ReadAsStream());
            return blobContainerClient.GetBlobClient(blobId).Uri.ToString();
        }

        private async Task InsertIntoTable(ApiLogs apiLogs)
        {
            TableClient tableClient = new TableClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("TableName"));
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync<ApiLogs>(apiLogs);
        }
    }
}
