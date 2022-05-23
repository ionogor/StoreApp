using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos
{
    public class DtoRate
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime DateUpdate { get; set; }
        public int ProductId { get; set; }

    }
}
