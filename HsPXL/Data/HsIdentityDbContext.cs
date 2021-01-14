using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HsPXL.Data
{
    public class HsIdentityDbContext : IdentityDbContext
    {
        public HsIdentityDbContext(DbContextOptions<HsIdentityDbContext> opts) : base(opts) {}
    }
}
