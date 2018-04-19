using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCreek.Authorization.Roles;
using MyCreek.Authorization.Users;
using MyCreek.MultiTenancy;
using MyCreek.Entities;
using MyCreek.Entities.Events;

namespace MyCreek.EntityFrameworkCore
{
    public class MyCreekDbContext : AbpZeroDbContext<Tenant, Role, User, MyCreekDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Person> People { get; set; }

        public virtual DbSet<CreekEvent> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public MyCreekDbContext(DbContextOptions<MyCreekDbContext> options)
            : base(options)
        {
        }
    }
}
