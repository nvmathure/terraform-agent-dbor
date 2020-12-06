using System;
using System.Threading.Tasks;
using TerraformAgentDbor.DatabaseInterface.Tables;

namespace Database
{
    /// <inheritdoc />
    public class TableRepository : ITablesRepository
    {
        /// <inheritdoc />
        public Task<IEquatable<TableDto>> GetTablesAsync(string schemaName, int? pageSize = 10, int? pageNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}
