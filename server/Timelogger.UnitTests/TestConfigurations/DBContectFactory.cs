using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelogger.DAL.Base;

namespace Timelogger.UnitTests.TestConfigurations
{
    public static class DbContextFactory
    {
        public static TimeloggerContext Create()
        {
            var options = new DbContextOptionsBuilder<TimeloggerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new TimeloggerContext(options);

            TimeloggerContextSeeder.Seed(context);

            return context;
        }

        public static void RemoveContext(TimeloggerContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
