using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.DAL
{
    public class TaboDbContex : DbContext
    {
        
        public TaboDbContex(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x=>x.Code);
                b.HasIndex(x=>x.Name).IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x=> x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(124);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
