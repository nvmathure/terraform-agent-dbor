using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface;

namespace CloudNDevOps.TerraformAgentDbor.Core
{
    /// <summary>
    /// Manages Instance configured for current service
    /// </summary>
    public interface IInstanceManager
    {
        /// <summary>
        /// Gets instance details based on Alias Name
        /// </summary>
        /// <param name="alias">Alias of instance</param>
        /// <returns>Instance of <see cref="DbInstanceInfo"/> when found</returns>
        /// <exception cref="InvalidOperationException">When alias is not found</exception>
        DbInstanceInfo GetInstance(string alias);

        /// <summary>
        /// Gets instance details based on Alias Name
        /// </summary>
        /// <param name="alias">Alias of instance</param>
        /// <returns>Instance of <see cref="DbInstanceInfo"/> when found</returns>
        /// <exception cref="InvalidOperationException">When alias is not found</exception>
        DbInstanceInfo this[string alias]
        {
            get;
        }
    }

    /// <summary>
    /// Providers access to <see cref="DbInstanceInfo"/>
    /// </summary>
    public sealed class InstanceManager : IInstanceManager
    {
        /// <summary>
        /// Gets Singleton Instance of <see cref="InstanceManager"/>
        /// </summary>
        public static readonly InstanceManager Current = new InstanceManager();

        private InstanceManager()
        {

        }

        private static SecureString ToSecureString(string input)
        {
            var password = new SecureString();
            foreach (var c in input) password.AppendChar(c);
            password.MakeReadOnly();
            return password;
        }

        private static IEnumerable<DbInstanceInfo> instances = new List<DbInstanceInfo>()
        {
            new DbInstanceInfo
            {
                Alias = "MyDbor",
                Host = "adb.us-ashburn-1.oraclecloud.com",
                Port = 1522,
                ServiceName = "tw0mm9tyia3ylfn_terraform_high.adb.oraclecloud.com",
                SslServerCertDn = "CN=adwc.uscom-east-1.oraclecloud.com,OU=Oracle BMCS US,O=Oracle Corporation,L=Redwood City,ST=California,C=US",
                UserName = "admin",
                Password = ToSecureString("XyxxyspoonRy1023")
            }
        };

        /// <inheritdoc/>
        public DbInstanceInfo this[string alias]
        {
            get
            {
                return GetInstance(alias);
            }
        }

        /// <inheritdoc/>
        public DbInstanceInfo GetInstance(string alias)
        {
            var instance = instances.FirstOrDefault(i => i.Alias.Equals(alias, StringComparison.InvariantCultureIgnoreCase));
            if (instance == null)
                throw new InvalidOperationException($"Instance {alias} not found");
            return instance;
        }
    }
}
