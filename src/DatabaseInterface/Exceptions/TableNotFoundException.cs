using System;

namespace CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Exceptions
{
    /// <summary>
    /// Represents errors that occur when table is not found in the database
    /// </summary>
    [Serializable]
    public class TableNotFoundException : Exception
    {
        /// <summary>
        /// Creates new instance of <see cref="TableNotFoundException"/> and initializes the properties
        /// </summary>
        /// <param name="instanceName">Name of DB Instance</param>
        /// <param name="owner">Owner of the Table</param>
        /// <param name="tableName">Name of the Table</param>
        public TableNotFoundException(string instanceName, string owner, string tableName) : 
            this($"Table {owner}.{tableName} not found in instance {instanceName}")
        {
            InstanceName = instanceName;
            Owner = owner;
            TableName = tableName;
        }

        /// <inheritdoc/>
        public TableNotFoundException() { }

        /// <inheritdoc/>
        public TableNotFoundException(string message) : base(message) { }

        /// <inheritdoc/>
        public TableNotFoundException(string message, Exception inner) : base(message, inner) { }

        /// <inheritdoc/>
        protected TableNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Gets/Sets Name of the Table
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// Gets/Sets Name of the Instance
        /// </summary>
        public string InstanceName { get; private set; }

        /// <summary>
        /// Gets/Sets Name of Table Owner
        /// </summary>
        public string Owner { get; private set; }
    }
}
