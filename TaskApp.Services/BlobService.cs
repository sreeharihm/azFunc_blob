using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using System.Web;
using TaskApp.Services.ApiModel;
using TaskApp.Services.Interface;

namespace TaskApp.Services
{
    internal class BlobService : IBlobService
    {
        private readonly IConfiguration _configuration; 
        public BlobService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public async Task<string> Insert(string blobId, HttpResponseMessage responseMessage)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("ContainerName"));
            await blobContainerClient.CreateIfNotExistsAsync();
            var data =await responseMessage.Content.ReadAsStringAsync();
            var responsed = await blobContainerClient.UploadBlobAsync(blobId, responseMessage.Content.ReadAsStream());
            return blobContainerClient.GetBlobClient(blobId).Uri.ToString();
        }

        public async Task<BlobDetails> Get(string blobId)
        {
            var result = new BlobDetails();
            result.BlobId = blobId;
            BlobContainerClient blobContainerClient = new BlobContainerClient(_configuration["AzureTableSettings:ConnectionString"], _configuration["AzureTableSettings:ContainerName"]);
            var data = await blobContainerClient.GetBlobClient(blobId).DownloadContentAsync();
            // Download the blob's content to a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await blobContainerClient.GetBlobClient(blobId).DownloadToAsync(memoryStream);
                memoryStream.Position = 0;

                // Convert the content to a string
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    result.BlobData = await reader.ReadToEndAsync();
                    result.BlobData =  HttpUtility.HtmlEncode(result.BlobData);
                }
            }
            return result;
        }
    }
}
