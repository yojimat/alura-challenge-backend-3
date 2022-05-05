using Alura_Challenge_Backend_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura_Challenge_Backend_3.Contexts
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction>? Transactions { get; set; }

        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>()
                .Property(b => b.ImportedDateTime)
                .HasDefaultValueSql("getdate()");
        }
    }
}
