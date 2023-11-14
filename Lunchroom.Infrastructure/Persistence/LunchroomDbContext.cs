using Lunchroom.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lunchroom.Infrastructure.Persistence;

public class LunchroomDbContext : IdentityDbContext
{
    public LunchroomDbContext(DbContextOptions<LunchroomDbContext> options) : base(options)
    {
    }

    public required DbSet<Meal> Lunchrooms { get; set; }
    public required DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Meal>()
            .OwnsOne(l => l.ContactDetails);

        modelBuilder.Entity<Meal>()
            .HasMany(x => x.Student)
            .WithOne(x => x.Lunchroom)
            .HasForeignKey(x => x.LunchroomId);
    }
}