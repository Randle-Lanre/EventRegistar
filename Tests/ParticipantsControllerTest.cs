using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistarApi.Controllers;
using RegistarApi.Model;

namespace Tests
{
    [TestClass]
    public class ParticipantsControllerTest : BaseTest
    {
        [TestMethod]
        public async Task GetAllParticipantsInDb() 
        {
            
            //Arrange
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);

            context.EventRegistars.Add(new EventRegistar()
                {FirstName = "Tommy", LastName = "Micheal", ParticipantComment = "The show was very good"});
            context.SaveChanges();


            var context2 = BuildContext(databaseName);


            //Act 
            var controller = new RegistarController(context2);
            var response = await controller.GetAllParticipants();


            //Assert
            int id = 1;

            var participants =  response.Value.Id;
            
            
            Assert.AreEqual(id, participants);

            
        }
    }
}
