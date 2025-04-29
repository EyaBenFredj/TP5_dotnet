using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestoManager_YourName.Models.RestosModel
{
    public class RestosDbContextFactory : IDesignTimeDbContextFactory<RestosDbContext>
    {
        public RestosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestosDbContext>();

            // Load connection string from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("RestosConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new RestosDbContext(optionsBuilder.Options);
        }
    }
}