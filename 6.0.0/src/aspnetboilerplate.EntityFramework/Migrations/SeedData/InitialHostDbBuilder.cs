using aspnetboilerplate.EntityFramework;
using EntityFramework.DynamicFilters;

namespace aspnetboilerplate.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly aspnetboilerplateDbContext _context;

        public InitialHostDbBuilder(aspnetboilerplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
