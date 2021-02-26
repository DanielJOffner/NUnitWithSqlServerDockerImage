using Microsoft.EntityFrameworkCore;

namespace NUnitWithSqlDockerImage.Data
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}
