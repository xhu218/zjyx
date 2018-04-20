using Abp.Dapper;
using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using MyCreek.EntityFrameworkCore.Seed;
using System.Collections.Generic;
using System.Reflection;

namespace MyCreek.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyCreekCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule), typeof(AbpDapperModule))]
    public class MyCreekEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<MyCreekDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        MyCreekDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        MyCreekDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCreekEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
