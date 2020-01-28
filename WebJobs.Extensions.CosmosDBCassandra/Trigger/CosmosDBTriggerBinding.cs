﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Cassandra;
//using Microsoft.Azure.Documents.ChangeFeedProcessor;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.CosmosDBCassandra
{
    internal class CosmosDBCassandraTriggerBinding : ITriggerBinding
    {
        private readonly ParameterInfo _parameter;
        private readonly string _keyspace;
        private readonly string _table;
        private readonly ICosmosDBCassandraService _cosmosDBCassandraService;
        private readonly ILogger _logger;
        private readonly IReadOnlyDictionary<string, Type> _emptyBindingContract = new Dictionary<string, Type>();
        private readonly IReadOnlyDictionary<string, object> _emptyBindingData = new Dictionary<string, object>();


        public CosmosDBCassandraTriggerBinding(ParameterInfo parameter,
            string keyspace,
            string table,
            ICosmosDBCassandraService cosmosDBCassandraService,
            ILogger logger)
        {
            _keyspace = keyspace;
            _table = table;
            _cosmosDBCassandraService = cosmosDBCassandraService;
            _parameter = parameter;
            _logger = logger;
        }

        /// <summary>
        /// Gets the type of the value the Trigger receives from the Executor.
        /// </summary>
        public Type TriggerValueType => typeof(IReadOnlyList<Row>);

        public IReadOnlyDictionary<string, Type> BindingDataContract
        {
            get { return _emptyBindingContract; }
        }

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            // ValueProvider is via binding rules. 
            return Task.FromResult<ITriggerData>(new TriggerData(null, _emptyBindingData));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Missing listener context");
            }

            return Task.FromResult<IListener>(new CosmosDBTriggerListener(
                context.Executor,
                context.Descriptor.Id,
                this._keyspace,
                this._table,
                this._cosmosDBCassandraService,
                this._logger));
        }

        /// <summary>
        /// Shows display information on the dashboard.
        /// </summary>
        /// <returns></returns>
        public ParameterDescriptor ToParameterDescriptor()
        {
            return new CosmosDBCassandraTriggerParameterDescriptor
            {
                Name = _parameter.Name,
                Type = CosmosDBCassandraTriggerConstants.TriggerName,
                KeyspaceName = this._keyspace,
                TableName = this._table
            };
        }

        internal static bool TryAndConvertToDocumentList(object value, out IReadOnlyList<Row> documents)
        {
            documents = null;

            try
            {
                if (value is IReadOnlyList<Row> docs)
                {
                    documents = docs;
                }
                else if (value is string stringVal)
                {
                    documents = JsonConvert.DeserializeObject<IReadOnlyList<Row>>(stringVal);
                }

                return documents != null;
            }
            catch
            {
                return false;
            }
        }
    }
}