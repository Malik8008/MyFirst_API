using System.Collections.Generic;

namespace FirstAPI.DTOs.CategoryDTOs
{
    public class CategoryGetAllDto
    {
        public List<CategoryListItemDto> CategoryListItemDtos { get; set; }
        public int TotalCount { get; set; }

        public CategoryGetAllDto()
        {
            CategoryListItemDtos = new();
        }
    }
}
