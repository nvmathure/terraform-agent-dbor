namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents Character Column
    /// </summary>
    public class VariableCharacterColumnDefinition : ColumnDefinition
    {
        /// <summary>
        /// Gets/Sets Maximum Length of Character Column
        /// </summary>
        public int MaximumLength { get; set; }

        /// <summary>
        /// Gets/Sets Maximum Length Unit of Character Column
        /// </summary>
        public LenghtUnits MaximumLengthUnit { get; set; }
    }
}
