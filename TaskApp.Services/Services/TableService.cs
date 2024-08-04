using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.Interface;
using TaskApp.Services.ApiModel;

namespace TaskApp.Services.Services
{
    internal class TableService : ITableService
    {
        public async Task<List<ApiLogs>> Get(DateTime fromDate, DateTime toDate)
        {
            var result = new List<ApiLogs>();
            TableClient tableClient = new TableClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), Environment.GetEnvironmentVariable("TableName"));
            var  logs= tableClient.QueryAsync<ApiLogs>(x=>x.StartTime>=fromDate && x.EndTime <=toDate);
            await foreach (var log in logs)
            {
                result.Add(log);
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
