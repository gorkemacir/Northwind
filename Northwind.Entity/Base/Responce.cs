using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Base
{
    public class Responce:IResponce
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

    }
    public class Responce<T> : IResponce<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

    }
}
