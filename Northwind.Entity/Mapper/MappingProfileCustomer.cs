using AutoMapper;
using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Mapper
{
   public class MappingProfileCustomer : Profile
    {
        public MappingProfileCustomer()
        {
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            
        }
    }
}
