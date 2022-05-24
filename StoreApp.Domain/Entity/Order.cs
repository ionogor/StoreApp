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
        public int ProductsId { get; set; }
        public Product Products { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        //  public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
