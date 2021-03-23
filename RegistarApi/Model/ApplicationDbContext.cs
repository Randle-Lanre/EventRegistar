using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace RegistarApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        //removed DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
            
        }
        
        public DbSet<EventRegistar> EventRegistars { get; set; }
    }
}

 // might need to add seed data