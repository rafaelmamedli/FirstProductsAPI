using FirstProductsAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstProductsAPI.Controllers
{


    //localhost:4500//api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private static List<Product>?  _products;


        public ProductsController()
        {
            _products = new List<Product> {

           new() { ProductId = 1,MyPProductName = "Iphone 14",Price = 2200,isActive = true},
           new() { ProductId = 2, MyPProductName = "Iphone 14", Price = 2100, isActive = true },
           new() { ProductId = 3, MyPProductName = "Iphone 14", Price = 2000, isActive = true },
           new() { ProductId = 4, MyPProductName = "Iphone 14", Price = 1800, isActive = true }

            };

        }

        

        //localhost:4500//api/products => GET
        [HttpGet]
        public IActionResult GetProducts()
        {


            if (_products == null)
            {
                return NotFound();
            }

            return Ok(_products);

        }

        //localhost:4500//api/product/1 => GET
        [HttpGet("{id}")]
        public IActionResult? GetProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();  //404
            }

            var p = _products?.FirstOrDefault(i => i.ProductId == id);

            if(p == null) {
            
                return NotFound();   //404

            }   

            return Ok(p); //200

        }

    }
}
