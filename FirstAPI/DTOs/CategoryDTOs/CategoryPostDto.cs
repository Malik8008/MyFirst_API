using FluentValidation;

namespace FirstAPI.DTOs.CategoryDTOs
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }

    public class CategoryPostDtoValidstor : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidstor()
        {
            RuleFor(c => c.Name).NotNull().WithMessage("Category adi bos gonderile bilmez").MaximumLength(30).WithMessage("Uzunluq 30-dan yuxari ola bilmez");
        }
    }
}
