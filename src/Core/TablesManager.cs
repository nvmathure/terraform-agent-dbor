using AutoMapper;
using CloudNDevOps.TerraformAgentDbor.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;

namespace CloudNDevOps.TerraformAgentDbor.Core
{
    /// <summary>
    /// Executes Create, Read, Update and Delete (CRUD) operations on database tables
    /// </summary>
    public class TablesManager : ITablesManager
    {
        private readonly IInstanceManager _instanceManager;
        private readonly ITablesRepository _tablesRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates new instance of <see cref="TablesManager"/>
        /// </summary>
        /// <param name="instanceManager">Instance of <see cref="InstanceManager"/></param>
        /// <param name="tablesRepository">Instance of <see cref="ITablesRepository"/></param>
        /// <param name="mapper">Instance of <see cref="IMapper"/></param>
        public TablesManager(
            IInstanceManager instanceManager, 
            ITablesRepository tablesRepository,
            IMapper mapper)
        {
            _instanceManager = instanceManager ?? throw new ArgumentNullException(nameof(instanceManager));
            _tablesRepository = tablesRepository ?? throw new ArgumentNullException(nameof(tablesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            return _mapper.Map<TableDefinition[]>(tables);
        }
    }
}
