using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.DBContexts
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
