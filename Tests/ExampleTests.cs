using System.Threading.Tasks;
using NUnit.Framework;
using NUnitWithSqlDockerImage.Data;

namespace NUnitWithSqlDockerImage.Tests
{
    public class ExampleTests : TestBase
    {

        [TestCase]
        public async Task Test1()
        {
            Database.Users.Add(new User()
            {
                Name = "Alex"
            });
            await Database.SaveChangesAsync();
        }

        [Test]
        public async Task Test2()
        {
            Database.Users.Add(new User()
            {
                Name = "Daniel"
            });
            await Database.SaveChangesAsync();
        }
    }
}