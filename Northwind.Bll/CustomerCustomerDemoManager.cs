using Northwind.Entity.Dto;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerCustomerDemoManager<T, TDto> : GenericManager<CustomerCustomerDemo, DtoCustomerCustomerDemo>, ICustomerCustomerDemoService
    {
        public CustomerCustomerDemoManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable<DtoCustomerCustomerDemo> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
