using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TerraformAgentDbor.DatabaseInterface.Tables
{
    /// <summary>
    /// Represents repository to perform Read Operations on Table
    /// </summary>
    public interface ITablesRepository
    {
        /// <summary>
        /// Gets list of tables for given schema
        /// </summary>
        /// <param name="dbInstanceInfo">Instance of <see cref="DbInstanceInfo"/></param>
        /// <param name="owner">Owner/Schema Name</param>
        /// <param name="limit">Number of objects to return in response</param>
        /// <param name="offset">Number of objects to skip</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Enurable of <see cref="TableDto"/> containing table information</returns>
        Task<IEnumerable<TableDto>> GetTablesAsync(DbInstanceInfo dbInstanceInfo, string owner, int limit, int offset, CancellationToken cancellationToken = default);

    }
}
