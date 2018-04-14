using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCreek.Authorization.Roles;
using MyCreek.Authorization.Users;
using MyCreek.MultiTenancy;
using MyCreek.Entities;

namespace MyCreek.EntityFrameworkCore
{
    public class MyCreekDbContext : AbpZeroDbContext<Tenant, Role, User, MyCreekDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Person> People { get; set; }

        public MyCreekDbContext(DbContextOptions<MyCreekDbContext> options)
            : base(options)
        {
        }
    }
}
