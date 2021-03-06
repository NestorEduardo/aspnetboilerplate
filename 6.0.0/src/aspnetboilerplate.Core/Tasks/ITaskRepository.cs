using Abp.Domain.Repositories;
using System.Collections.Generic;

namespace aspnetboilerplate.Tasks
{
    public interface ITaskRepository : IRepository<Task, long>
    {
        List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
