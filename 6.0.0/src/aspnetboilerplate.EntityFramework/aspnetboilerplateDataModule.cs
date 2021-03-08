using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using aspnetboilerplate.EntityFramework;

namespace aspnetboilerplate
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(aspnetboilerplateCoreModule))]
    public class aspnetboilerplateDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<aspnetboilerplateDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
