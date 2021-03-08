using Abp.Application.Services;
using aspnetboilerplate.Taks.DTOs;

namespace aspnetboilerplate.Taks
{
    public interface ITaskAppService : IApplicationService
    {
        GetTasksOutput GetTasks(GetTasksInput input);
        void UpdateTask(UpdateTaskInput input);
        void CreateTask(CreateTaskInput input);
    }
}
