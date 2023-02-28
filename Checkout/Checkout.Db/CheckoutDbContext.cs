using Checkout.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Db
{
    public class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CardDetails> CardDetails { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Currency>().ToTable("Currency");
            builder.Entity<Transaction>().ToTable("Transactions");
            builder.Entity<CardDetails>().ToTable("CardDetails");

        }
    }
}
