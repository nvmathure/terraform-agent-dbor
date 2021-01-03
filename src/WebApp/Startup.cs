using AutoMapper;
using CloudNDevOps.TerraformAgentDbor.Contracts;
using CloudNDevOps.TerraformAgentDbor.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CloudNDevOps.TerraformAgentDbor.Database.Oracle;
using CloudNDevOps.TerraformAgentDbor.DatabaseInterface.Tables;
using CloudNDevOps.TerraformAgentDbor.Database;

namespace CloudNDevOps.TerraformAgentDbor.WebApi
{
    /// <summary>
    /// Startup Class for Terraform Agent for Oracle
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates new instance of startup
        /// </summary>
        /// <param name="configuration">Instance of <see cref="IConfiguration"/></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets/Sets configurations
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Instance of <see cref="IServiceCollection"/> for adding services to container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseHelper = new DatabaseHelper();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TableDto, TableDefinition>());
            var mapper = config.CreateMapper();

            services.AddControllers();
            services.AddSingleton<ITablesManager>(new TablesManager(InstanceManager.Current, new TableRepository(databaseHelper), mapper));

            

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Instance of <see cref="IApplicationBuilder"/> to be configured</param>
        /// <param name="env">Instance of <see cref="IWebHostEnvironment"/> which allows this function to get environment information</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
