using System.Data.Common;
using System.Data.Entity;
using System.Threading.Tasks;
using Abp.DynamicEntityProperties;
using Abp.Zero.EntityFramework;
using aspnetboilerplate.Authorization.Roles;
using aspnetboilerplate.Authorization.Users;
using aspnetboilerplate.MultiTenancy;
using aspnetboilerplate.People;

namespace aspnetboilerplate.EntityFramework
{
    public class aspnetboilerplateDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Tasks.Task> Tasks { get; set; }

        public virtual IDbSet<Person> People { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public aspnetboilerplateDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in aspnetboilerplateDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of aspnetboilerplateDbContext since ABP automatically handles it.
         */
        public aspnetboilerplateDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public aspnetboilerplateDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public aspnetboilerplateDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DynamicProperty>().Property(p => p.PropertyName).HasMaxLength(250);
            modelBuilder.Entity<DynamicEntityProperty>().Property(p => p.EntityFullName).HasMaxLength(250);
        }
    }
}
