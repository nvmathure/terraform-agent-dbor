using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface;

namespace CloudNDevOps.TerraformAgentDbor.Database.Oracle
{
    /// <summary>
    /// Defines an interface for accessing Oracle Helper services
    /// </summary>
    public interface IDatabaseHelper
    {
        /// <summary>
        /// Creates new Connection, Sets Connection String and Opens Connection
        /// </summary>
        /// <param name="dbInstanceInfo">Instance of <see cref="DbInstanceInfo"/></param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Instance of <see cref="IDbConnection"/></returns>
        Task<OracleConnection> CreateConnectionAsync(DbInstanceInfo dbInstanceInfo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes SQL passed into parameters and returns a <see cref="OracleDataReader"/> containing result
        /// </summary>
        /// <param name="dbInstanceInfo">Instance of <see cref="DbInstanceInfo"/></param>
        /// <param name="sql">SQL Statement to be Executed</param>
        /// <param name="oracleParameters">Parameters used in SQL Statement</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns><see cref="OracleDataReader"/> containing the results of SQL Statement</returns>
        Task<OracleDataReader> ExecuteReaderAsync(DbInstanceInfo dbInstanceInfo, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes SQL passed into parameters and returns a <see cref="OracleDataReader"/> containing result
        /// </summary>
        /// <param name="oracleConnection">Instance of <see cref="OracleConnection"/></param>
        /// <param name="sql">SQL Statement to be Executed</param>
        /// <param name="oracleParameters">Parameters used in SQL Statement</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns><see cref="OracleDataReader"/> containing the results of SQL Statement</returns>
        Task<OracleDataReader> ExecuteReaderAsync(OracleConnection oracleConnection, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Executes SQL passed into parameters and returns a <see cref="OracleDataReader"/> containing result
        /// </summary>
        /// <param name="oracleCommand">Instance of <see cref="OracleCommand"/></param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns><see cref="OracleDataReader"/> containing the results of SQL Statement</returns>
        Task<OracleDataReader> ExecuteReaderAsync(OracleCommand oracleCommand, CancellationToken cancellationToken = default);

    }
}
