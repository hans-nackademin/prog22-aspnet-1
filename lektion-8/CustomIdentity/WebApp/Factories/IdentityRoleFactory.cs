using Microsoft.AspNetCore.Identity;

namespace WebApp.Factories
{
    public class IdentityRoleFactory
    {
        public static IdentityRole Create(string roleName)
        {
            return new IdentityRole(roleName);
        }
    }
}
