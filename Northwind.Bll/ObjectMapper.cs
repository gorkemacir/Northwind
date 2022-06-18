using AutoMapper;
using Northwind.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    internal class ObjectMapper
    {
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfileCustomer>();
            });
            return config.CreateMapper();
        }
        );
        public static IMapper Mapper => lazy.Value;
    }
}
