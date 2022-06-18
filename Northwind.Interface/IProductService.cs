using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IProductService : IGenericService<Product, DtoProduct>
    {
        IQueryable<DtoProduct> GetTotalReport();
    }
}
