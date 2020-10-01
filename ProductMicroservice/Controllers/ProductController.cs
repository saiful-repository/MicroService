using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Model;
using ProductMicroservice.Repository;
using ProductMicroservice.ViewModel;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get([FromQuery] int currentPage, int itemsPerPage)
        {
            var result= _productRepository.GetProducts();
            ProductViewModel model = new ProductViewModel();
            model.TotalResult = result.Count();
            model.Data = result.Skip(currentPage*itemsPerPage-itemsPerPage).Take(itemsPerPage);
            return StatusCode(StatusCodes.Status200OK, model);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _productRepository.GetProductByID(id);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product != null)
            {
                var addedProuct = _productRepository.InsertProduct(product);
                return StatusCode(200, addedProuct);
            }
            else
            {
                return StatusCode(404, "Sending data is not valid");
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
