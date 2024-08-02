using Invoice_Inventory_mgmt.Model;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Inventory_mgmt.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<StateMaster> StateMasters { get; set; }
        public DbSet<CityMaster> CityMasters {get; set;}
        public DbSet<BusinessRegistration> BusinessRegistrations { get; set; }
        public DbSet<ProductCategoryMaster> ProductCategoryMasters { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

    }
}
