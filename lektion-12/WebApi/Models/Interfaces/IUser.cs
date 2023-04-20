using WebApi.Models.Dtos;

namespace WebApi.Models.Interfaces
{
    public interface IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public IAddress Address { get; set; }
    }
}
