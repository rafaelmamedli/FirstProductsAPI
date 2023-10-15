using Microsoft.EntityFrameworkCore;

namespace FirstProductsAPI.Model
{
    public class ProductsContext : DbContext
    {

        public ProductsContext(DbContextOptions<ProductsContext> options) : base (options) { }
        public ProductsContext MyProperty { get; set; }

    }
}
