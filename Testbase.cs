using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnitWithSqlDockerImage.Data;
using System.Threading.Tasks;

namespace NUnitWithSqlDockerImage
{
    public abstract class TestBase
    {
        protected readonly TestDbContext Database = GlobalSetupTeardown.TestDbContext;
        
        [SetUp]
        public async Task Setup()
        {
            await GlobalSetupTeardown.Checkpoint.Reset(Database.Database.GetConnectionString());
        }
    }
}
