using Abp.EntityFramework;
using aspnetboilerplate.EntityFramework;
using aspnetboilerplate.EntityFramework.Repositories;
using aspnetboilerplate.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetboilerplate.Taks
{
    public class TaskRepository : aspnetboilerplateRepositoryBase<Tasks.Task, long>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<aspnetboilerplateDbContext> dbContextProvider)
                : base(dbContextProvider)
        {
        }

        public List<Tasks.Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            //In repository methods, we do not deal with create/dispose DB connections, DbContexes and transactions. ABP handles it.

            var query = GetAll(); //GetAll() returns IQueryable<T>, so we can query over it.
                                  //var query = Context.Tasks.AsQueryable(); //Alternatively, we can directly use EF's DbContext object.
                                  //var query = Table.AsQueryable(); //Another alternative: We can directly use 'Table' property instead of 'Context.Tasks', they are identical.

            //Add some Where conditions...

            if (assignedPersonId.HasValue)
            {
                query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
            }

            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }

            return query
                .OrderByDescending(task => task.CreationTime)
                .Include(task => task.AssignedPerson) //Include assigned person in a single query
                .ToList();
        }
    }
}
