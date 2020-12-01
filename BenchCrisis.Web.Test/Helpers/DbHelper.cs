using BenchCrisis.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchCrisis.Web.Test.Helpers
{
    public static class DbHelper
    {
        public static DbContextOptions<AppDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "test" + Guid.NewGuid())
                .Options;
        }
    }
}
