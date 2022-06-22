using System.Collections.Generic;

namespace FirstAPI.DTOs.ProductDTOs
{
    public class ProductGetAllDto
    {
        public List<ProductListItem> ProductList { get; set; }
        public int TotalCount { get; set; }

        public ProductGetAllDto()
        {
            ProductList = new();
        }
    }
}
