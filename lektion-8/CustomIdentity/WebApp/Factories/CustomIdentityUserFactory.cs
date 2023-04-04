using WebApp.Models.Identity;

namespace WebApp.Factories
{
    public class CustomIdentityUserFactory
    {
        public static CustomIdentityUser Create(string email)
        {
            return new CustomIdentityUser()
            {
                UserName = email,
                Email = email
            };
        }
    }
}
