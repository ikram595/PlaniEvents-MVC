using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaniEvents123.Models;

namespace PlaniEvents123.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //table Events
        public DbSet<Event> Events { get; set; }
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
    }
}