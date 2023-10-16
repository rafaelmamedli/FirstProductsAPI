﻿using System.ComponentModel.DataAnnotations;

namespace FirstProductsAPI.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal Price { get; set; } 
        public bool isActive { get; set; }
    }
}
