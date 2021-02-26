using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnitWithSqlDockerImage.Data;
using Respawn;
using System.Threading.Tasks;

namespace NUnitWithSqlDockerImage
{
    [SetUpFixture]
    public class GlobalSetupTeardown
    {
        private string _dockerContainerId;
        private string _dockerSqlPort;
        private static string DatabaseName = "TEST_DATABASE";
        
        public static TestDbContext TestDbContext;
        public static readonly Checkpoint Checkpoint = new();

        /// <summary>
        /// Runs once before all other tests
        /// - Setup docker container with Sql server
        /// - Create the database
        /// </summary>
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            (_dockerContainerId, _dockerSqlPort) = await DockerSqlDatabaseUtilities.EnsureDockerStartedAndGetContainerIdAndPortAsync();
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            optionsBuilder.UseSqlServer(GetSqlConnectionString());
            TestDbContext = new TestDbContext(optionsBuilder.Options);
            await TestDbContext.Database.EnsureCreatedAsync();
            // TODO - seed the database here
        }

        
        /// <summary>
        /// Runs once after all other tests
        /// - Delete container image
        /// </summary>
        /// <returns></returns>
        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            await DockerSqlDatabaseUtilities.EnsureDockerStoppedAndRemovedAsync(_dockerContainerId);
        }

        public string GetSqlConnectionString()
        {
            return $"Data Source=localhost,{_dockerSqlPort};" +
                   $"Initial Catalog={DatabaseName};" +
                   "Integrated Security=False;" +
                   "User ID=SA;" +
                   $"Password={DockerSqlDatabaseUtilities.SQLSERVER_SA_PASSWORD}";
        }
    }
}
