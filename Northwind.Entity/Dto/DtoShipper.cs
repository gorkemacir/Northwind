using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
   public class DtoShipper : DtoBase
    {
        public DtoShipper()
        {
            
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
    }
}
