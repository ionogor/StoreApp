using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class ConversionRate:BaseEntity
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime DateUpdate { get; set; }

    }
}
