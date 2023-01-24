﻿namespace Warehouse.ProductService.API.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int LowStock { get; set; }
        public int OutOfStock { get; set; }
    }
}
