using Microsoft.EntityFrameworkCore;

namespace BreadmakerReport.Models
{
    public class BreadMakerContext : DbContext
    {
        public DbSet<Breadmaker> Breadmakers { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }

    public class BreadMakerSqliteContext : BreadMakerContext
    {
        string filename { get; }
        public BreadMakerSqliteContext(string filename)
        {
            this.filename = filename;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={filename}");
    }
}
