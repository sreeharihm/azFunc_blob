using TaskApp.Data;
using TaskApp.Services.ApiModel;

namespace TaskApp.Api.Interface
{
    public interface ITaskService
    {
        Task<List<Logs>> Task1(DateTime fromDate, DateTime toDate);
        Task<List<WeatherDto>> Task2(DateTime dateTime);

        Task<BlobDetails> Task1(string guid);
    }
}
