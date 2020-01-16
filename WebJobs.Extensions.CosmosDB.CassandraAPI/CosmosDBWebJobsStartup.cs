﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Extensions.CosmosDB.CassandraAPI;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(CosmosDBWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.CosmosDB.CassandraAPI
{
    public class CosmosDBWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            
            builder.AddCosmosDB();

        }
    }
}
