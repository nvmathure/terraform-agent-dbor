namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Enumerates Character Length Units
    /// </summary>
    public enum LenghtUnits
    {
        /// <summary>
        /// Unit is not specified, use default
        /// </summary>
        None,

        /// <summary>
        /// Length is specified as number of Bytes
        /// </summary>
        Byte,

        /// <summary>
        /// Length is specified as number of Characters
        /// </summary>
        Char
    }
}
