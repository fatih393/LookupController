using Lookupcontroller.Application.Repostories;
using Lookupcontroller.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Persistance.Services.BusinessRules
{
    public class OrderBusinessRulesService : BusinessRulesServiceBase<Order>
    {
        public OrderBusinessRulesService(IOrderReadRepository readRepo)
            : base(readRepo) { }

        public override Task ValidateAsync(Order entity)
        {
            // ne yapacagımı bilemedim boş kalsın belki ekleriz
            return Task.CompletedTask;
        }
    }
}
