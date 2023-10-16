using FirstProductsAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace FirstProductsAPI.Controllers
{


    //localhost:4500//api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {




        private readonly ProductsContext _context;


        public ProductsController()
        {
           

        }

        

        //localhost:4500//api/products => GET
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);

        }

        //localhost:4500//api/product/1 => GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();  //404
            }

            var p = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);

            if(p == null) {
            
                return NotFound();   //404

            }   

            return Ok(p); //200

        }

    }
}
