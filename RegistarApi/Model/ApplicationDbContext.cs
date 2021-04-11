// using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RegistarApi.Entities;

namespace RegistarApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        //removed DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
            
        }
        
        public DbSet<EventRegistar> EventRegistars { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

 // might need to add seed data