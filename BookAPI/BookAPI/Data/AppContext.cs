using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Model
{
    public class AppContext : DbContext
    {
       
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasOne(p => p.Author)
            .WithMany(b => b.Books);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        
    }
}
