using Microsoft.EntityFrameworkCore;
using WebApi.Models.Identity;

namespace WebApi.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AddressId))]
public class UserAddressEntity
{
    public string UserId { get; set; }
    public int AddressId { get; set; }

    public AppUser User { get; set; }
    public AddressEntity Address { get; set; }
}
