using CloudNDevOps.TerraformAgentDbor.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudNDevOps.TerraformAgentDbor.Core
{
    /// <summary>
    /// Defines a contract for Table Manager
    /// </summary>
    public interface ITablesManager
    {
        /// <summary>
        /// Gets list of tables
        /// </summary>
        /// <param name="instanceName">Database Instance Name</param>
        /// <param name="owner">Name of Table Owner</param>
        /// <param name="limit">Number of tables to return on each page, defaults to 10</param>
        /// <param name="offset">Page Number, defaults to 1</param>
        /// <returns>List of tables</returns>
        Task<IEnumerable<TableDefinition>> GetAsync(string instanceName, string owner, int limit = 10, int offset = 0);

        /// <summary>
        /// Gets list of tables
        /// </summary>
        /// <param name="instanceName">Database Instance Name</param>
        /// <param name="owner">Name of Table Owner</param>
        /// <param name="tableName">Name of table</param>
        /// <returns>Instance of <see cref="TableDefinition"/></returns>
        Task<TableDefinition> GetAsync(string instanceName, string owner, string tableName);

        /// <summary>
        /// Creates new table in database
        /// </summary>
        /// <param name="schemanName">Schema of the table</param>
        /// <param name="table"></param>
        /// <returns></returns>
        Task Create(string schemanName, TableDefinition table);
    }
}
