namespace CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables
{
    /// <summary>
    /// Represents Database Column Data Transformation Object (DTO)
    /// </summary>
    public struct ColumnDto
    {
        /// <summary>
        /// Gets/Sets Name of the Database Column
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gers/Sets Data Type of the Database Column
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// Gets/Sets Length of the Database Column in Bytes
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets/Sets Length of the Database Column in Characters
        /// </summary>
        public int? CharLength { get; set; }

        /// <summary>
        /// Gets/Sets Precision of the Number Column
        /// </summary>
        public int? Precision { get; set; }

        /// <summary>
        /// Gets/Sets Scale of the Number Column
        /// </summary>
        public int? Scale { get; set; }

        /// <summary>
        /// Gets/Sets whether the Column allows Null values
        /// </summary>
        public string Nullable { get; set; }
    }
}
