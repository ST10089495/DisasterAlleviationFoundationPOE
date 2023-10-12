using DisasterAlleviationFoundationPOE.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundationPOE.Model
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions<DisasterContext> options) : base(options)
        {
        }
    }
}
