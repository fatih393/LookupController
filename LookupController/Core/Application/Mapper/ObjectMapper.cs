using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lookupcontroller.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoMapper());
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => _lazy.Value;
    }
}
