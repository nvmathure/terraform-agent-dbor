using System.Threading.Tasks;

namespace CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Ddl
{
    /// <summary>
    /// Represents repository to perform DDL Operations on Table
    /// </summary>
    public interface IDdlRepository
    {
        /// <summary>
        /// Executes DDL against the database
        /// </summary>
        /// <param name="ddlStatement">DDL Statement to be executed</param>
        /// <returns>Success Task when completed successfully</returns>
        Task Execute(string ddlStatement);
    }
}
