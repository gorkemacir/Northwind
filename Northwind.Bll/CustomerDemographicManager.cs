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
    public class CustomerDemographicManager<T, TDto> : GenericManager<CustomerDemographic, DtoCustomerDemographic>, ICustomerDemographicService
    {
        public CustomerDemographicManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable<DtoCustomerDemographic> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
