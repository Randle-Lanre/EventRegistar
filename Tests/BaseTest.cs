using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RegistarApi.Model;

namespace Tests
{
    public abstract class BaseTest
    {
        private bool _useSqlite;

        public async Task<ApplicationDbContext> GetDbContext()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            if (_useSqlite)
            {
                builder.UseSqlite("DataSource=:memory:", x =>
                {
                });

            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).ConfigureWarnings(w =>
                {
                    w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                });
            }

            var dbContext = new ApplicationDbContext(builder.Options);
            if (_useSqlite)
            {
                await dbContext.Database.OpenConnectionAsync();
            }

            await dbContext.Database.EnsureCreatedAsync();
            return dbContext;


        }

        public void UseSqlite()
        {
            _useSqlite = true;
        }

    }

    
}
