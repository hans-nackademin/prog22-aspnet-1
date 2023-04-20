using WebApi.Contexts;
using WebApi.Helpers.Repositories.Base;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class UserCompanyRepository : Repository<UserCompanyEntity>
    {
        public UserCompanyRepository(DataContext context) : base(context)
        {
        }
    }
}
