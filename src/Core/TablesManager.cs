using Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerraformAgentDbor.Core
{
    /// <summary>
    /// Executes Create, Read, Update and Delete (CRUD) operations on database tables
    /// </summary>
    public class TablesManager : ITablesManager
    {

        /// <inheritdoc/>
        public Task Create(string schemanName, TableDefinition table)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<TableDefinition>> GetAsync(string schemaName = null, int limit = 10, int offset = 0)
        {
            return Task.FromResult(
                (IEnumerable<TableDefinition>)new List<TableDefinition>()
                {
                    new TableDefinition() { Name = "Employees" },
                    new TableDefinition() { Name = "Departments" }
                });
        }
    }
}
