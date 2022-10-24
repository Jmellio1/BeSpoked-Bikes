using BeSpoked_Bikes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BeSpoked_Bikes.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BeSpoked_Bikes.Models.Product> Product { get; set; }
        public DbSet<BeSpoked_Bikes.Models.Customer> Customer { get; set; }
        public DbSet<BeSpoked_Bikes.Models.SalesPerson> SalesPerson { get; set; }
        public DbSet<BeSpoked_Bikes.Models.Sales> Sales { get; set; }

    }
}