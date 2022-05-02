using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Order:BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        // TODO: 
        // Add new entity OrderProduct
        // ProductId & OrderId
        public Product Products { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
