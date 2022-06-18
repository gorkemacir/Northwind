
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using Northwind.Entity.Dto;
using Northwind.Entity.IBase;
using Northwind.Entity.Models;
using Northwind.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bll
{
    public class CustomerManager : GenericManager<Customer, DtoCustomer>, ICustomerService
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerManager(IServiceProvider service) : base(service)
        {
            customerRepository = service.GetService<ICustomerRepository>();
        }

        public IResponce<IQueryable<DtoCustomer>> GetTotalReport()
        {
            try
            {
                var list = customerRepository.GetTotalReport();
                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoCustomer>(x));
                return new Responce<IQueryable<DtoCustomer>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Responce<IQueryable<DtoCustomer>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}