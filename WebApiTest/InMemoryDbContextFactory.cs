using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi;

namespace WebApiTest
{
    public class InMemoryDbContextFactory
    {
        public WebApiContext GetArticleDbContext()
        {
            var options = new DbContextOptionsBuilder<WebApiContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                            .Options;
            var dbContext = new WebApiContext(options);

            return dbContext;
        }
    }
}
