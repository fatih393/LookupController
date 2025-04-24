using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Shared.Extensions
{
    public class ClaimExtension
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public ClaimExtension(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string Id => _contextAccessor?.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).FirstOrDefault() ?? "";

    }
}
