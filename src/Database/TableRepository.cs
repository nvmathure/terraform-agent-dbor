using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.Database.Oracle;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;

namespace CloudNDevOps.TerraformAgentDbor.Database
{
    /// <inheritdoc />
    public class TableRepository : ITablesRepository
    {
        private const string readQuery =
            @"
            select   at.owner      as Owner
                   , at.table_name as Name
            from all_tables at
            where at.owner = :owner
            order by   at.owner
                     , at.table_name
            offset :offset rows fetch next :limit rows only
            ";

        private readonly IDatabaseHelper _databaseHelper;

        /// <summary>
        /// Creates new instance of <see cref="TableRepository"/>
        /// </summary>
        /// <param name="databaseHelper">Instance of <see cref="IDatabaseHelper"/></param>
        public TableRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper ?? throw new ArgumentNullException(nameof(databaseHelper));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TableDto>> GetTablesAsync(DbInstanceInfo dbInstanceInfo, string owner, int limit, int offset, CancellationToken cancellationToken = default)
        {
            if (dbInstanceInfo == null) throw new ArgumentNullException(nameof(dbInstanceInfo));

            using var connection = await _databaseHelper.CreateConnectionAsync(dbInstanceInfo, cancellationToken);

            var response = await connection.QueryAsync<TableDto>(
                readQuery,
                new
                {
                    owner,
                    offset,
                    limit
                    
                });

            return response;
        }
    }
}
