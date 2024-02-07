using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Employee_With_JWT.Identity
{
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserStore(ApplicationDbContext context):base(context)
        {
        }
    }
}
