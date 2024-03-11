using Microsoft.EntityFrameworkCore;

namespace Day06.Models
{
    public class ITIDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
       
        //public ITIDBContext()
        //{

        //}
        public ITIDBContext(DbContextOptions options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Day06DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //    base.OnConfiguring(optionsBuilder);

        //}

    }
}
