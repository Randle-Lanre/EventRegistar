// using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RegistarApi.Entities;

namespace RegistarApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        //remove this to use a non generic form so prevent test from failing DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
            
        }
        
        public DbSet<EventRegistar> EventRegistars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

 // might need to add seed data