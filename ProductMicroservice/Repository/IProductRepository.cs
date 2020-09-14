using ProductMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int ProductID);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void Save();
    }
}
