using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace aspnetboilerplate.EntityFramework.Repositories
{
    public abstract class aspnetboilerplateRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<aspnetboilerplateDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected aspnetboilerplateRepositoryBase(IDbContextProvider<aspnetboilerplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class aspnetboilerplateRepositoryBase<TEntity> : aspnetboilerplateRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected aspnetboilerplateRepositoryBase(IDbContextProvider<aspnetboilerplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
