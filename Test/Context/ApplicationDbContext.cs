using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        } 
        public DbSet<Address> Addresses { get; set; }   
    }
}
