using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OdontoVision.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OdontoVisionDbContext>
    {
        public OdontoVisionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OdontoVisionDbContext>();

            var connectionString = "User Id=rm554199;Password=160103;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)))";

            optionsBuilder.UseOracle(connectionString, opts =>
                opts.MigrationsAssembly(typeof(OdontoVisionDbContext).Assembly.FullName));

            return new OdontoVisionDbContext(optionsBuilder.Options);
        }
    }
}
