using WebApi.Contexts;
using WebApi.Helpers.Repositories.Base;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
    public class CompanyRepository : Repository<CompanyEntity>
    {
        public CompanyRepository(DataContext context) : base(context)
        {
        }
    }
}
