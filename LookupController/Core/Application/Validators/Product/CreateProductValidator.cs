using FluentValidation;
using FluentValidation.Validators;
using Lookupcontroller.Application.Shared.Dtos.Product.Query;
using Lookupcontroller.Domain.Entities;


namespace Lookupcontroller.Application.Validators
{
    public class CreateProductValidator: AbstractValidator<ProductRequestDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş bırakmayın")
                .MaximumLength(150)
                .MinimumLength(2)
                .WithMessage("Lütfen ürün adını 2 ile 150 karakter arasında girin");

            RuleFor(p => p.Stock)
                 .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok adını boş bırakmayın")
                .Must(s => s >= 0)
                .WithMessage("Stok bilgisi negatif olamaz");
        }
    }
}
