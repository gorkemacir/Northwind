using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
    public class DtoCustomerDemographic : DtoBase
    {
        public DtoCustomerDemographic()
        {
            
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }
    }
}
