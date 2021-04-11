using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistarApi.Entities;
using RegistarApi.Model;
using Xunit;

namespace Tests
{
    public class SqliteTests :BaseTest
    {
        public SqliteTests()
        {
            UseSqlite();
        }

        [Fact]
        public async Task Should_Be_Able_To_Add_An_Entity()
        {
            //prep
            using var context = await GetDbContext();

            int id = 1;
            context.EventRegistars.Add(new EventRegistar
            {
                Id = 1,
                FirstName = "Tom",
                LastName = "Hanks",
                ParticipantComment = "a really interesting event"
            });

            await context.SaveChangesAsync();
            
            //act
            var data = await context.EventRegistars.ToListAsync();
            
            //assert
            Assert.Single(data);
            Assert.Contains(data, d => d.Id == id);
            Assert.Contains(data, d => d.FirstName == "Tom");
            Assert.Contains(data, d => d.LastName == "Hanks");
            Assert.Contains(data, d => d.ParticipantComment == "a really interesting event");

        }
        
        [Fact]
        // [Trait("DbDependat", "")]
        public async Task Should_Be_Able_To_ExeuteSql()
        {
            // Prepare
            using var context = await GetDbContext();

            int id = 2;
            context.EventRegistars.Add(new EventRegistar
            {
                Id = id,
                FirstName = "kehinde",
                LastName = "Randle",
                ParticipantComment = "awesome"
               
            });

            await context.SaveChangesAsync();

            // Execute
            var result = await context.EventRegistars
                .FromSqlRaw("select * from EventRegistars")
                .ToListAsync();

            // It should get first line and convert byte[] into GUID.
            Assert.Equal(id, result.First().Id);
        }

        
        
        
        
        
        
        
        
        
        
        
    }
}
