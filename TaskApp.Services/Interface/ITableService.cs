using TaskApp.Services.ApiModel;

namespace TaskApp.Services.Interface
{
    public interface ITableService
    {
        Task Insert(ApiLogs apiLogs);

        Task<List<Logs>> Get(DateTime fromDate, DateTime toDate);
    }
}
