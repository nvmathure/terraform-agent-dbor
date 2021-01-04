using System.Collections.Generic;

namespace CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables
{
    /// <summary>
    /// Represents Database Table Data Transformation Object (DTO)
    /// </summary>
    public class TableDto
    {
        /// <summary>
        /// Gets/Sets name of table
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/Sets owner of table
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets/Sets a List of Columns in the Table
        /// </summary>
        public List<ColumnDto> Columns { get; set; }
    }
}
