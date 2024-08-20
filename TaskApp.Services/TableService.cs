using Azure.Data.Tables;
using TaskApp.Services.Interface;
using TaskApp.Services.ApiModel;
using Microsoft.Extensions.Configuration;

namespace TaskApp.Services
{
    public class TableService : ITableService
    {
        private readonly string _conncetionString;
        private readonly string _tableName;
        public TableService(IConfiguration configuration) 
        {
            _conncetionString =  Convert.ToString(configuration["AzureTableSettings:ConnectionString"]);
            _tableName = Convert.ToString(configuration["AzureTableSettings:TableName"]);
        }
        public async Task<List<Logs>> Get(DateTime fromDate, DateTime toDate)
        {
            var result = new List<Logs>();
            TableClient tableClient = new TableClient(_conncetionString, _tableName);
            var logs = tableClient.QueryAsync<ApiLogs>();

            await foreach (var log in logs)
            {               
                if (log.StartTime.Date >= fromDate.Date && log.EndTime.Date <= toDate.Date)
                {
                    var logData = new Logs
                    {
                        Name = log.Name,
                        StartTime = log.StartTime.ToString(),
                        EndTime = log.EndTime.ToString(),
                        BlobId = log.RowKey
                    };
                    result.Add(logData);
                }
            }
            return result;
        }

        public async Task Insert(ApiLogs apiLogs)
        {
            TableClient tableClient = new TableClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("TableName"));
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync<ApiLogs>(apiLogs);
        }
    }
}
