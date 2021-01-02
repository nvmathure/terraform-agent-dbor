using CloudNDevOps.TerraformAgentDbor.Contracts;
using CloudNDevOps.TerraformAgentDbor.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerraformAgentDbor.DatabaseInterface.Tables;

namespace TerraformAgentDbor.Core
{
    /// <summary>
    /// Executes Create, Read, Update and Delete (CRUD) operations on database tables
    /// </summary>
    public class TablesManager : ITablesManager
    {
        private readonly IInstanceManager _instanceManager;
        private readonly ITablesRepository _tablesRepository;

        /// <summary>
        /// Creates new instance of <see cref="TablesManager"/>
        /// </summary>
        /// <param name="instanceManager">Instance of <see cref="InstanceManager"/></param>
        /// <param name="tablesRepository">Instance of <see cref="ITablesRepository"/></param>
        public TablesManager(IInstanceManager instanceManager, ITablesRepository tablesRepository)
        {
            _instanceManager = instanceManager ?? throw new ArgumentNullException(nameof(instanceManager));
            _tablesRepository = tablesRepository ?? throw new ArgumentNullException(nameof(tablesRepository));
        }

        /// <inheritdoc/>
        public Task Create(string instanceName, TableDefinition table)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TableDefinition>> GetAsync(string instanceName, string owner, int limit = 10, int offset = 0)
        {
            var instance = _instanceManager[instanceName];
            var tables = await _tablesRepository.GetTablesAsync(instance, owner, limit, offset);

            return 
                (IEnumerable<TableDefinition>)new List<TableDefinition>()
                {
                    new TableDefinition() { Name = "Employees" },
                    new TableDefinition() { Name = "Departments" }
                };
        }
    }
}
