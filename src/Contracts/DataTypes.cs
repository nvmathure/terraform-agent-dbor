
namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Enumerates list of datatypes supported by Agent
    /// <see href="https://docs.oracle.com/en/database/oracle/oracle-database/19/sqlrf/Data-Types.html">Data-Types</see>
    /// </summary>
    public enum DataTypes
    {
        /// <summary>
        /// Default None Value
        /// </summary>
        None,

        /// <summary>
        /// Variable Length Character
        /// </summary>
        VarChar2,

        /// <summary>
        /// Variable Length Unicode Character
        /// </summary>
        NVarChar2,

        /// <summary>
        /// Number with Precision and Scale
        /// </summary>
        Number,

        /// <summary>
        /// Date value
        /// </summary>
        Date,

        /// <summary>
        /// Raw Binary Data
        /// </summary>
        Raw,

        /// <summary>
        /// Fixed Length Character
        /// </summary>
        Char,

        /// <summary>
        /// Fixed Length Unicode Charater 
        /// </summary>
        NChar,

        /// <summary>
        /// Character Large Object
        /// </summary>
        Clob,

        /// <summary>
        /// Unicode Character Large Object
        /// </summary>
        NClob,
    }
}
