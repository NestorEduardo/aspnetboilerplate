using Abp.Authorization;
using aspnetboilerplate.Authorization.Roles;
using aspnetboilerplate.Authorization.Users;

namespace aspnetboilerplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
