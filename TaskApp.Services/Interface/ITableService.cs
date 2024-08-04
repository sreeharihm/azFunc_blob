using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Services.ApiModel;

namespace TaskApp.Services.Interface
{
    internal interface ITableService
    {
        Task Insert(ApiLogs apiLogs);

        Task<List<ApiLogs>> Get(DateTime fromDate, DateTime toDate);
    }
}
