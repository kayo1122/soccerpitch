using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoccerPitch.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<SoccerPitch.Models.User> Users { get; set; } = default;

        public DbSet<SoccerPitch.Models.Team> Teams { get; set; } = default;

        public DbSet<SoccerPitch.Models.Player> Players { get; set; } = default;
    }
}