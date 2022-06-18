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
    public class MappingProfileEmployee : Profile
    {
        public MappingProfileEmployee()
        {
            CreateMap<Employee, DtoEmployee>().ReverseMap();

        }
    }
}
