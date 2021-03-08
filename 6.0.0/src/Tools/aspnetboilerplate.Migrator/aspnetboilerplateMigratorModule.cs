using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using aspnetboilerplate.EntityFramework;

namespace aspnetboilerplate.Migrator
{
    [DependsOn(typeof(aspnetboilerplateDataModule))]
    public class aspnetboilerplateMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<aspnetboilerplateDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}