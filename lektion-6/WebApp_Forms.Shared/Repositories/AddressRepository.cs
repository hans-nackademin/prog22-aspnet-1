using WebApp_Forms.Shared.Contexts;
using WebApp_Forms.Shared.Models.Entities;

namespace WebApp_Forms.Shared.Repositories;

public class AddressRepository : GenericRepository<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
