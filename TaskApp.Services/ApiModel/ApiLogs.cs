﻿using Azure;
using Azure.Data.Tables;

namespace TaskApp.Services.ApiModel
{
    public record ApiLogs : ITableEntity
    {
        public string RowKey { get; set; } = default!;

        public string PartitionKey { get; set; } = default!;

        public string Name { get; set; } = default!;

        public DateTime StartTime { get; init; }

        public DateTime EndTime { get; init; }

        public string ResponseData { get; init; }

        public DateTimeOffset? Timestamp { get; set; } = default!;
        public ETag ETag { get; set; }
    }
}
