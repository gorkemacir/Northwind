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
    public class OrderDetailManager<T, TDto> : GenericManager<OrderDetail, DtoOrderDetail>, IOrderDetailService
    {
        public OrderDetailManager(IServiceProvider service) : base(service)
        {

        }

        public IQueryable<DtoOrderDetail> GetTotalReport()
        {
            throw new NotImplementedException();
        }
    }
}
