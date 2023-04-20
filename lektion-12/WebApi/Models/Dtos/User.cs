using WebApi.Models.Interfaces;

namespace WebApi.Models.Dtos
{
    public class User : IUser
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfileImage { get; set; } 
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public IAddress Address { get; set; } = null!;
    }
}
