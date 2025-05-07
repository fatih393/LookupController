using FluentValidation;
using Lookupcontroller.Application.Shared.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Validators.Order
{
    public class CreateOrderValidator: AbstractValidator<OrderRequestDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(p => p.ProductId)
               .NotEmpty()
               .NotNull()
               .WithMessage("Lütfen Id bilgisini boş bırakmayın")
               .Must(s => s >= 0)
                .WithMessage("Id bilgisi negatif olamaz");
        }
    }
}
