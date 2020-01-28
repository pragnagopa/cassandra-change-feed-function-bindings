﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//using Microsoft.Azure.Documents.ChangeFeedProcessor.Monitoring;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.CosmosDBCassandra
{
    //internal class CosmosDBTriggerHealthMonitor : IHealthMonitor
    internal class CosmosDBTriggerHealthMonitor
    {
        private readonly ILogger _logger;

        public CosmosDBTriggerHealthMonitor(ILogger logger)
        {
            this._logger = logger;
        }

        //public Task InspectAsync(HealthMonitoringRecord record)
        //{
        //    switch (record.Severity)
        //    {
        //        case HealthSeverity.Critical:
        //            this._logger.LogCritical(record.Exception, $"Unhealthiness detected in the operation {record.Operation} for {record.Lease}.");
        //            break;
        //        case HealthSeverity.Error:
        //            this._logger.LogError(record.Exception, $"Unhealthiness detected in the operation {record.Operation} for {record.Lease}.");
        //            break;
        //        default:
        //            this._logger.LogTrace($"{record.Operation} on lease {record.Lease?.Id}, partition {record.Lease?.PartitionId} for owner {record.Lease?.Owner}");
        //            break;
        //    }

        //    return Task.CompletedTask;
        //}
    }
}
