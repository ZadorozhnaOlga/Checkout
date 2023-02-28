using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Db
{
    public class DesignTimeCheckoutDbContextFactory : IDesignTimeDbContextFactory<CheckoutDbContext>
    {
        CheckoutDbContext IDesignTimeDbContextFactory<CheckoutDbContext>.CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CheckoutDbContext>();
            builder.UseSqlServer("Server=LAPTOP-MNNVHMJQ\\SQLEXPRESS;Database=Checkout;Trusted_Connection=True;TrustServerCertificate=True");

            return new CheckoutDbContext(builder.Options);
        }
    }
}

