using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistarApi.Controllers;
using RegistarApi.Model;

namespace Tests
{
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        [TestMethod]
        public async Task TestMethod1() 
        {
            
            //Arrange
            var database = Guid.NewGuid().ToString();
            var context = BuildContext(database);

            context.EventRegistars.Add(new EventRegistar()
                {FirstName = "Tommy", LastName = "Micheal", ParticipantComment = "The sho was very good"});
            context.SaveChanges();


            var context2 = BuildContext(database);


            //Act 
            var controller = new RegistarController(context2);
            var response = await controller.GetAllParticipants();


            //Assert
            var Id = 1;

            var participants =  response.Value;
            
            
            Assert.AreEqual(Id, participants.Id);

            
        }
    }
}
