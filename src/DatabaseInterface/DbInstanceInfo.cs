using System.Security;

namespace CloudNDevOps.TerraformAgentDbor.DatabaseInterface
{
    /// <summary>
    /// Represents Oracle Instance
    /// </summary>
    public sealed class DbInstanceInfo
    {
        /// <summary>
        /// Gets/Sets Instance Alias used in URL
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets/Sets User Name to login to Oracle
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets/Sets Password to login to Oracle
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Gets/Sets Oracle Port
        /// </summary>
        public int Port { get; set; } = 1522;

        /// <summary>
        /// Gets/Sets Oracle Host Name
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets/Sets Oracle Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets/Sets Oracle Service Name
        /// </summary>
        public string SslServerCertDn { get; set; }
    }
}
