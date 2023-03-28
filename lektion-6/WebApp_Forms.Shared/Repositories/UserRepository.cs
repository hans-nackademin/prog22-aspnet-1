using WebApp_Forms.Shared.Contexts;
using WebApp_Forms.Shared.Models.Entities;

namespace WebApp_Forms.Shared.Repositories;

public class UserRepository : GenericRepository<UserEntity>
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}
