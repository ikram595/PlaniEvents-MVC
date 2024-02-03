using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaniEvents123.Models;

namespace PlaniEvents123.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //table Events
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
            .HasMany(e => e.Tags)
            .WithOne()
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}