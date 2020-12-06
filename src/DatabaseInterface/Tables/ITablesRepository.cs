using System;
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
        /// <param name="schemaName">Name of database schema to search for tables, when left blank current user's schema is used.</param>
        /// <param name="pageSize">Number of objects to return in response. Default is 10</param>
        /// <param name="pageNumber">Page number to be returned. Default is 1</param>
        /// <returns>Enurable of <see cref="TableDto"/> containing table information</returns>
        Task<IEquatable<TableDto>> GetTablesAsync(string schemaName, int? pageSize = 10, int? pageNumber = 1);
    }
}
