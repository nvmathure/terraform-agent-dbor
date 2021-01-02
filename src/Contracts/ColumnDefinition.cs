namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents instance of column of database table
    /// </summary>
    public class ColumnDefinition
    {
        /// <summary>
        /// Gets/Sets name of database columns
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/Sets data type of column
        /// </summary>
        public DataTypes DataType { get; set; }
    }
}
