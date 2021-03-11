using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RegistarApi.Controllers;
using RegistarApi.Model;
using Xunit;

namespace Tests
{
    public class ParticipantsControllerTest  
    {

        protected ParticipantsControllerTest(DbContextOptions<ApplicationDbContext> contextOptions )
        {
            contextOptions = contextOptions;
            
            Seed();

        }
        
        protected  DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var singleEvent = new EventRegistar( );
                singleEvent.Id = 1;
                singleEvent.FirstName = "Cat";
                singleEvent.LastName = "Will";
                singleEvent.ParticipantComment = "not too bad";



                var secondEvent = new EventRegistar();
                secondEvent.Id = 2;
                secondEvent.FirstName = "canna";
                secondEvent.LastName = "Cane";
                secondEvent.ParticipantComment = "lool";
                
                
                context.AddRange(singleEvent, secondEvent);
                context.SaveChanges();





            }
            
        }
      
        
        

    }
}
