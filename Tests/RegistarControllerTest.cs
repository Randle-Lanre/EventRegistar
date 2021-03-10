using System;
using System.Threading.Tasks;
using RegistarApi.Controllers;
using RegistarApi.Model;
using Xunit;

namespace Tests
{
    public class RegistarControllerTest :BaseTest
    {
        [Fact]
        public async Task GetAllParticipantsInDb()
        {


            //Arrange
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);


            context.EventRegistars.Add(new EventRegistar()
            { FirstName = "Tommy", LastName = "Micheal", ParticipantComment = "The show was very good" });
            context.SaveChanges();


            var context2 = BuildContext(databaseName);


            //Act 
            var controller = new RegistarController(context2);


            var response = await controller.GetAllParticipants();


            //Assert
            var id = 1;


            var participants = response.Value;
            Assert.NotNull(context);
            Assert.IsAssignableFrom<ApplicationDbContext>(context);

           


        }

    }
}
