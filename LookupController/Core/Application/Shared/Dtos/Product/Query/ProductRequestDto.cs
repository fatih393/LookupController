using Lookupcontroller.Application.Shared.Dtos.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Shared.Dtos.Product.Query
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }
}
