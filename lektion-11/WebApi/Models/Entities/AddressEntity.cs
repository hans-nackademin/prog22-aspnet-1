using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Entities;

public class AddressEntity : IAddress
{
    public int Id { get; set; }

    [Required]
    public string StreetName { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string City { get; set; }

    public string Country { get; set; }

    public ICollection<UserAddressEntity> Users { get; set; } = new HashSet<UserAddressEntity>();

    public static implicit operator Address(AddressEntity entity)
    {
        return new Address
        {
            Id = entity.Id,
            StreetName = entity.StreetName,
            PostalCode = entity.PostalCode,
            City = entity.City,
            Country = entity.Country
        };
    }
}
