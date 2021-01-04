namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents instance of Number Column of database table
    /// </summary>
    public class NumberColumnDefinition : ColumnDefinition
    {
        /// <summary>
        /// Gets/Sets Scale of Number Column
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Gets/Sets Precision of Number Column
        /// </summary>
        public int Precision { get; set; }
    }
}
