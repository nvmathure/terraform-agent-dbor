using Newtonsoft.Json;

namespace CloudNDevOps.TerraformAgentDbor.Contracts
{
    /// <summary>
    /// Provides Deserialization Helper Methods for Root Level Definition Objects
    /// </summary>
    public static class DeserializationHelper
    {
        /// <summary>
        /// Serializes JSON String to <see cref="TableDefinition"/> Class
        /// </summary>
        /// <param name="input">JSON String representing <see cref="TableDefinition"/></param>
        /// <returns>Instance of <see cref="TableDefinition"/></returns>
        public static TableDefinition ToTable(this string input)
        {
            return JsonConvert.DeserializeObject<TableDefinition>(
                input,
                new JsonSerializerSettings
                {
                    Converters = { ConverterFactory.CreateColumnDefinitionConverter() } 
                });
        }
    }
}
