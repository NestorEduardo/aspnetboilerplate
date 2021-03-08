using Abp.Application.Services;
using Abp.Domain.Repositories;
using aspnetboilerplate.People;
using aspnetboilerplate.Taks.DTOs;
using aspnetboilerplate.Tasks;
using AutoMapper;
using System.Collections.Generic;

namespace aspnetboilerplate.Taks
{
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        //These members set in constructor using constructor injection.

        private readonly ITaskRepository _taskRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IMapper _mapper;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public TaskAppService(ITaskRepository taskRepository, IRepository<Person> personRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }


        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            //Called specific GetAllWithPeople method of task repository.
            var tasks = _taskRepository.GetAllWithPeople(input.AssignedPersonId, input.State);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
            {
                Tasks = _mapper.Map<List<TaskDto>>(tasks)
            };
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.TaskId);

            //Updating changed properties of the retrieved task entity.

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }

        public void CreateTask(CreateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new Tasks.Task { Description = input.Description };

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPersonId = input.AssignedPersonId.Value;
            }

            //Saving entity with standard Insert method of repositories.
            _taskRepository.Insert(task);
        }
    }
}
