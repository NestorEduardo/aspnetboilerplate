using Abp.Domain.Entities;

namespace aspnetboilerplate.People
{
    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}
