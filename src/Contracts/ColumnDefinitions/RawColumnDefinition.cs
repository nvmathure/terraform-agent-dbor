namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents instance of Raw Column of database table
    /// </summary>
    public class RawColumnDefinition : ColumnDefinition
    {
        /// <summary>
        /// Gets/Sets Maximum Length of Raw Column in Bytes
        /// </summary>
        public int MaximumLength { get; set; }
    }
}
