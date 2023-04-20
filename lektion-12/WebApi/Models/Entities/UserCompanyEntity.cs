using Microsoft.EntityFrameworkCore;
using WebApi.Models.Identity;

namespace WebApi.Models.Entities
{

    [PrimaryKey(nameof(UserId), nameof(CompanyId))]
    public class UserCompanyEntity
    {
        public string UserId { get; set; } = null!;
        public CustomIdentityUser User { get; set; } = null!;

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;

    }
}
