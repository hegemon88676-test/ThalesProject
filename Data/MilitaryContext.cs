using Microsoft.EntityFrameworkCore;
using SoldierMovementTracking.Models;

namespace SoldierMovementTracking.Data
{
    public class MilitaryContext : DbContext
    {
        public DbSet<Soldier> Soldiers { get; set; }
        public DbSet<Position> Positions { get; set; }

        public MilitaryContext(DbContextOptions<MilitaryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soldier>()
                .HasMany(s => s.Positions)
                .WithOne(p => p.Soldier)
                .HasForeignKey(p => p.SoldierID);
        }
    }
}
