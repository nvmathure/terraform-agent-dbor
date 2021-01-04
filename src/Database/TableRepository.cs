using Dapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.Database.Oracle;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Exceptions;

namespace CloudNDevOps.TerraformAgentDbor.Database
{
    /// <inheritdoc />
    public class TableRepository : ITablesRepository
    {
        private const string getTablesQuery =
            @"
            select   at.owner      as Owner
                   , at.table_name as Name
            from all_tables at
            where at.owner = upper(:owner)
            order by   at.owner
                     , at.table_name
            offset :offset rows fetch next :limit rows only
            ";

        private const string getTableQuery =
            @"
            select   at.owner      as Owner
                   , at.table_name as Name
            from all_tables at
            where at.owner = upper(:owner)
              and at.table_name = upper(:tableName)
            ";

        private const string getColumnQuery =
            @"
            select   atc.column_name    as Name
                   , atc.data_type      as DataType
                   , atc.data_length    as Length
                   , atc.data_precision as Precision
                   , atc.data_scale     as Scale
                   , atc.nullable       as Nullable
                   , atc.char_length    as CharLength
            from all_tab_columns atc
            where owner = upper(:owner)
              and table_name = upper(:tableName)
            order by atc.column_id
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
        public async Task<TableDto> GetTableAsync(DbInstanceInfo dbInstanceInfo, string owner, string tableName, CancellationToken cancellationToken = default)
        {
            if (dbInstanceInfo == null) throw new ArgumentNullException(nameof(dbInstanceInfo));

            using var connection = await _databaseHelper.CreateConnectionAsync(dbInstanceInfo, cancellationToken);

            TableDto response;
            response = await connection.QuerySingleOrDefaultAsync<TableDto>(
            getTableQuery,
            new
            {
                owner,
                tableName
            });

            if (response == null)
                throw new TableNotFoundException(dbInstanceInfo.Alias, owner, tableName);

            response.Columns = (
                await connection.QueryAsync<ColumnDto>(
                    getColumnQuery,
                    new
                    {
                        owner,
                        tableName
                    }))
                .ToList();

            return response;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TableDto>> GetTablesAsync(DbInstanceInfo dbInstanceInfo, string owner, int limit, int offset, CancellationToken cancellationToken = default)
        {
            if (dbInstanceInfo == null) throw new ArgumentNullException(nameof(dbInstanceInfo));

            using var connection = await _databaseHelper.CreateConnectionAsync(dbInstanceInfo, cancellationToken);

            var response = await connection.QueryAsync<TableDto>(
                getTablesQuery,
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
