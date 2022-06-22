using FirstAPI.DTOs.ProductDTOs;
using FluentValidation;

namespace FirstAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool? DisplayStatus { get; set; }
    }

    public class ProductPostDtoValidator : AbstractValidator<ProductPostDTO>
    {
        public ProductPostDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Bu hisse bos qala bilmez!").MaximumLength(30).WithMessage("Uzunluq 30-dan yuxari ola bilmez");
            RuleFor(p => p.Price).GreaterThanOrEqualTo(0).WithMessage("0 ve ya ondan boyuk eded daxil edin");
        }
    }
}
