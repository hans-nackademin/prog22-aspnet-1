using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Services
{
    public class NewsletterService
    {
        private readonly DataContext _context;

        public NewsletterService(DataContext context)
        {
            _context = context;
        }

        public async Task SubscribeAsync(string email)
        {
            var newsletterEntity = new NewsletterEntity
            {
                Email = email
            };

            _context.Add(newsletterEntity);
            await _context.SaveChangesAsync();
        }
    }
}
