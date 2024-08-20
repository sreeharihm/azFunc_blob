using System;
using TaskApp.Services.ApiModel;
namespace TaskApp.Services.Interface
{
    public interface IBlobService
    {
        Task<string> Insert(string blobId, HttpResponseMessage responseMessage);
        Task<BlobDetails> Get(string blobId);
    }
}
