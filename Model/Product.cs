namespace FirstProductsAPI.Model
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string MyPProductName { get; set; } = null!;
        public decimal Price { get; set; } 
        public bool isActive { get; set; }
    }
}
