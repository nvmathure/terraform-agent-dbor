using System;
using System.Threading.Tasks;
using TerraformAgentDbor.Database.Oracle;
using TerraformAgentDbor.DatabaseInterface.Ddl;

namespace TerraformAgentDbor.Database
{
    /// <inheritdoc />
    public sealed class DdlRepository : IDdlRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        /// <summary>
        /// Creates new instance of <see cref="DdlRepository"/>
        /// </summary>
        /// <param name="databaseHelper">Instance of <see cref="IDatabaseHelper"/></param>
        public DdlRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper ?? throw new ArgumentNullException(nameof(databaseHelper));
        }

        /// <inheritdoc />
        public Task Execute(string ddlStatement)
        {
            throw new NotImplementedException();
        }
    }
}
