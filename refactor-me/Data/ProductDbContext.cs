using ProductsApi.Attributes;
using ProductsApi.Enums;
using ProductsApi.Models;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductsApi.Data
{
    [Component(Scope = ScopeEnum.Request, RegisterAsImplementedInterface = false)]
    public class ProductDbContext : DbContext
    {
        public ProductDbContext() : base("name=ProductDbContext")
        {
        }
 
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //turn off database initializer to work with existing database
            Database.SetInitializer<ProductDbContext>(null);
            //table names are singular
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}