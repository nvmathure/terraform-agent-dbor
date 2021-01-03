using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface;

namespace CloudNDevOps.TerraformAgentDbor.Database.Oracle
{
    /// <summary>
    /// Provides abstraction from ADO and connection management by giving helper function for database operations
    /// </summary>
    public sealed class DatabaseHelper : IDatabaseHelper
    {
        /// <summary>
        /// Creates new instance of <see cref="DdlRepository"/>
        /// </summary>
        public DatabaseHelper()
        {
        }

        private static OracleCredential GetCredential(DbInstanceInfo dbInstanceInfo)
        {
            return new OracleCredential(dbInstanceInfo.UserName, dbInstanceInfo.Password);
        }

        private static string GetConnectionString(DbInstanceInfo dbInstanceInfo)
        {
            var connectionStringBuilder = new OracleConnectionStringBuilder();
            connectionStringBuilder.DataSource = $"(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port={dbInstanceInfo.Port})(host={dbInstanceInfo.Host}))(connect_data=(service_name={dbInstanceInfo.ServiceName}))(security=(my_wallet_directory=\"{Path.Combine(@"C:\Users\Nandan\source\repos\terraform-agent-dbor\src\WebApp", "Oracle")}\")(ssl_server_cert_dn=\"{dbInstanceInfo.SslServerCertDn}\")))";
            return connectionStringBuilder.ConnectionString;
        }

        /// <inheritdoc/>
        public Task<OracleConnection> CreateConnectionAsync(DbInstanceInfo dbInstanceInfo, CancellationToken cancellationToken = default)
        {
            if (dbInstanceInfo == null) throw new ArgumentNullException(nameof(dbInstanceInfo));
            var connection = new OracleConnection(GetConnectionString(dbInstanceInfo), GetCredential(dbInstanceInfo));
            return OpenConnectionAsync(connection, cancellationToken);
        }

        private async Task<OracleConnection> OpenConnectionAsync(OracleConnection connection, CancellationToken cancellationToken = default)
        {
            await connection.OpenAsync(cancellationToken);
            return connection;
        }

        /// <inheritdoc/>
        public Task<OracleDataReader> ExecuteReaderAsync(OracleConnection oracleConnection, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken = default)
        {
            if (oracleConnection == null) throw new ArgumentNullException(nameof(oracleConnection));
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentNullException(nameof(sql));

            return ExecuteReaderAsyncInternal(oracleConnection, sql, oracleParameters, cancellationToken);
        }

        private Task<OracleDataReader> ExecuteReaderAsyncInternal(OracleConnection oracleConnection, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken)
        {
            using var command = new OracleCommand
            {
                CommandText = sql,
                CommandType = CommandType.Text,
                BindByName = true,
                Connection = oracleConnection
            };
            if (oracleParameters?.Length > 0)
            {
                command.Parameters.AddRange(oracleParameters);
            }

            return ExecuteReaderAsyncInternal(command, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<OracleDataReader> ExecuteReaderAsync(OracleCommand oracleCommand, CancellationToken cancellationToken = default)
        {
            if (oracleCommand == null) throw new ArgumentNullException(nameof(oracleCommand));
            return ExecuteReaderAsyncInternal(oracleCommand, cancellationToken);
        }

        private async Task<OracleDataReader> ExecuteReaderAsyncInternal(OracleCommand oracleCommand, CancellationToken cancellationToken = default)
        {
            return (OracleDataReader)(await oracleCommand.ExecuteReaderAsync(cancellationToken));
        }

        /// <inheritdoc/>
        public Task<OracleDataReader> ExecuteReaderAsync(DbInstanceInfo dbInstanceInfo, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken = default)
        {
            if (dbInstanceInfo == null) throw new ArgumentNullException(nameof(dbInstanceInfo));
            if (string.IsNullOrWhiteSpace(sql)) throw new ArgumentNullException(nameof(sql));

            return ExecuteReaderAsyncInternal(dbInstanceInfo, sql, oracleParameters, cancellationToken);
        }

        private async Task<OracleDataReader> ExecuteReaderAsyncInternal(DbInstanceInfo dbInstanceInfo, string sql, OracleParameter[] oracleParameters, CancellationToken cancellationToken = default)
        {
            using var connection = await CreateConnectionAsync(dbInstanceInfo, cancellationToken);
            return await ExecuteReaderAsyncInternal(connection, sql, oracleParameters, cancellationToken);
        }
    }
}
