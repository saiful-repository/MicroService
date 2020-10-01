using ProductMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.ViewModel
{
    public class ProductViewModel
    {
        public int TotalResult { get; set; }
        public IEnumerable<Product> Data { get; set; }
    }
}
