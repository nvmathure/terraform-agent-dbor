using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace TerraformAgentDbor.Database.Oracle
{
    /// <summary>
    /// Provides abstraction from ADO and connection management by giving helper function for database operations
    /// </summary>
    public sealed class DatabaseHelper : IDatabaseHelper
    {
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly Func<IDbConnection, Task<IDbConnection>> _openConnectionFunc;

        /// <summary>
        /// Creates new instance of <see cref="DdlRepository"/>
        /// </summary>
        /// <param name="dbProviderFactory">Instance of DB Provider Factory used to create ADO objects like Command, Connection, Reader, etc.</param>
        /// <param name="openConnectionFunc">Function which accepts Connection, returns configured and opened connection</param>
        public DatabaseHelper(DbProviderFactory dbProviderFactory, Func<IDbConnection, Task<IDbConnection>> openConnectionFunc)
        {
            _dbProviderFactory = dbProviderFactory ?? throw new ArgumentNullException(nameof(dbProviderFactory));
            _openConnectionFunc = openConnectionFunc ?? throw new ArgumentNullException(nameof(openConnectionFunc));
        }
    }
}
