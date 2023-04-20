using Microsoft.EntityFrameworkCore;
using WebApi.Models.Identity;

namespace WebApi.Models.Entities
{

    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        public string UserId { get; set; } = null!;
        public CustomIdentityUser User { get; set; } = null!;

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
    }
}
