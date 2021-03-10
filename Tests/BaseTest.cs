using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using RegistarApi.Model;

namespace Tests
{
    public class BaseTest
    {
        protected ApplicationDbContext BuildContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName).Options;

            var dbContext = new ApplicationDbContext( options);
            return dbContext;


        }
        
    }
}
