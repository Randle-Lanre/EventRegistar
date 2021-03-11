using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RegistarApi.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using RegistarApi.Controllers;
using Xunit;

namespace Tests
{
    public class SqliteRegistarControllerTest :ParticipantsControllerTest , IDisposable
    {
        private readonly DbConnection _connection;

        public SqliteRegistarControllerTest(): base(
        new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseSqlite(CreateInMemoryDatabase())
            .Options)
        {
           // _connection = RelationshipOptions.Extract(ApplicationDbContext).Connection;
           //_connection = RelationshipOptionsExtension.Extract(ApplicationDbContext).Connection;
           _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
        }
        

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
            
            
        }

        public void Dispose() => _connection.Dispose();
        
        
        [Fact]
        public void would_fetch_events()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var controller = new RegistarController(context);
                var getAnEvent = controller.GetAllParticipants().Result;
                
                Assert.NotNull(getAnEvent);

            }
            
            
        }


    }
}
