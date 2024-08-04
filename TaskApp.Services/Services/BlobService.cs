using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Interface;

namespace TaskApp.Services.Services
{
    internal class BlobService : IBlobService
    {
        public async Task<string> Insert(string blobId, HttpResponseMessage responseMessage)
        {
            BlobContainerClient blobContainerClient = new BlobContainerClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("ContainerName"));
            await blobContainerClient.CreateIfNotExistsAsync();
            var responsed = await blobContainerClient.UploadBlobAsync(blobId, responseMessage.Content.ReadAsStream());
            return blobContainerClient.GetBlobClient(blobId).Uri.ToString();
        }
    }
}
