﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

//using Microsoft.Azure.Documents.Client;
//using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.CosmosDBCassandra.Bindings
{
    //internal class CosmosDBClientBuilder : IConverter<CosmosDBAttribute, DocumentClient>
    //{
    //    private readonly CosmosDBExtensionConfigProvider _configProvider;

    //    public CosmosDBClientBuilder(CosmosDBExtensionConfigProvider configProvider)
    //    {
    //        _configProvider = configProvider;
    //    }

    //    public DocumentClient Convert(CosmosDBAttribute attribute)
    //    {
    //        if (attribute == null)
    //        {
    //            throw new ArgumentNullException(nameof(attribute));
    //        }

    //        string resolvedConnectionString = _configProvider.ResolveConnectionString(attribute.ConnectionStringSetting);
    //        ICosmosDBService service = _configProvider.GetService(resolvedConnectionString, attribute.PreferredLocations, attribute.UseMultipleWriteLocations, attribute.UseDefaultJsonSerialization);

    //        return service.GetClient();
    //    }
    //}
}
