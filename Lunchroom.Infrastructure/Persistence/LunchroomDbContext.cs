using Lunchroom.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Infrastructure.Persistence
{
    public class LunchroomDbContext : IdentityDbContext
    {
        public DbSet<Domain.Entities.Lunchroom> Lunchrooms { get; set; }
        public DbSet<Student> Students { get; set; }

        public LunchroomDbContext(DbContextOptions<LunchroomDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Lunchroom>()
                .OwnsOne(l => l.ContactDetails);

            modelBuilder.Entity<Domain.Entities.Lunchroom>()
                .HasMany(x => x.Student)
                .WithOne(x => x.Lunchroom)
                .HasForeignKey(x => x.LunchroomId);
        }
    }
}
