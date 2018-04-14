using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCreek.EntityFrameworkCore
{
    public static class MyCreekDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyCreekDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyCreekDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
