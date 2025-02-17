using Microsoft.EntityFrameworkCore;
using Onlinevotingsystem.Models;
using Onlinevotingsystem.Models;
namespace Onlinevotingsystem.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }

}

