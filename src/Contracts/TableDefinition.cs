namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents instance of database table
    /// </summary>
    public class TableDefinition
    {
        /// <summary>
        /// Gets/Sets name of table
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/Sets Owner of table
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets/Sets list of columns
        /// </summary>
        public ColumnDefinition[] Columns { get; set; }
    }
}
