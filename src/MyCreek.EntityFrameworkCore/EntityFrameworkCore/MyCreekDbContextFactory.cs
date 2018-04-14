using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCreek.Configuration;
using MyCreek.Web;

namespace MyCreek.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyCreekDbContextFactory : IDesignTimeDbContextFactory<MyCreekDbContext>
    {
        public MyCreekDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyCreekDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyCreekDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyCreekConsts.ConnectionStringName));

            return new MyCreekDbContext(builder.Options);
        }
    }
}
