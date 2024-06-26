using Microsoft.EntityFrameworkCore;
using Persist.Entities;


namespace Persist
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               string connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=localhost;Port=8081;User=root;Password=;Database=testntier";
               optionsBuilder.UseMySql("Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8;",ServerVersion.AutoDetect("Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8;"));   
            }
        }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<EntryEntity> Entries {get;set;}
        public DbSet<SpotterEntity> Spotter {get;set;}
        public DbSet<EntrySpotterEntity> EntrySpotter {get;set;}
    }
}
