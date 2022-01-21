using BlockBuster.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<MembershipType> MembershipType { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}