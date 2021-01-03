using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudNDevOps.TerraformAgentDbor.Contracts;
using CloudNDevOps.TerraformAgentDbor.Core;
using Microsoft.AspNetCore.Mvc;

namespace TerraformAgentDbor.WebApp.Controllers
{
    /// <summary>
    /// Provides CRUD Operation APIs for Database Tables
    /// </summary>
    [ApiController]
    public class TablesController : Controller
    {
        private readonly ITablesManager _tablesManager;

        /// <summary>
        /// Creates new instance of <see cref="TablesController"/>
        /// </summary>
        /// <param name="tablesManager">Instance of <see cref="ITablesManager"/></param>
        public TablesController(ITablesManager tablesManager)
        {
            _tablesManager = tablesManager ?? throw new ArgumentNullException(nameof(tablesManager));
        }

        /// <summary>
        /// Gets list of tables
        /// </summary>
        /// <returns>Enumerable with list of table</returns>
        [Route("{instanceName}/{owner}/[controller]")]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TableDefinition>>> Read(string instanceName, string owner, int limit = 10, int offset = 0)
        {
            var result = await _tablesManager.GetAsync(instanceName, owner, limit, offset);
            return Ok(result);
        }

        /// <summary>
        /// Creates new Table
        /// </summary>
        /// <returns><see cref="OkResult"/> if table was created successfully. <see cref="BadRequestObjectResult"/> or <see cref="StatusCodeResult"/> depending on error</returns>
        [Route("{schema}/[controller]/{tableName}")]
        [HttpPost()]
        public Task<ActionResult<IEnumerable<TableDefinition>>> Create(string schema, string tableName, TableDefinition table)
        {
            throw new NotImplementedException();
        }
    }
}
