namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Represents Character Column
    /// </summary>
    public class FixedCharacterColumnDefinition : ColumnDefinition
    {
        /// <summary>
        /// Gets/Sets Length of Character Column
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets/Sets Length Unit of Character Column
        /// </summary>
        public LenghtUnits MaximumLengthUnit { get; set; }
    }
}
