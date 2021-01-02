using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TerraformAgentDbor.Database.Oracle;
using TerraformAgentDbor.DatabaseInterface;
using TerraformAgentDbor.DatabaseInterface.Tables;

namespace Database
{
    /// <inheritdoc />
    public class TableRepository : ITablesRepository
    {
        private const string readQuery =
            @"
            select   at.owner
                   , at.table_name
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

            using var reader = await _databaseHelper.ExecuteReaderAsync(
                dbInstanceInfo,
                readQuery,
                new OracleParameter[]
                {
                    new OracleParameter("owner", OracleDbType.Varchar2) { Value = owner },
                    new OracleParameter("limit", OracleDbType.Int16) { Value = limit },
                    new OracleParameter("offset", OracleDbType.Int16) { Value = offset },
                },
                cancellationToken);

            return null;
        }
    }
}
