using aspnetboilerplate.Tasks;

namespace aspnetboilerplate.Taks.DTOs
{
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
