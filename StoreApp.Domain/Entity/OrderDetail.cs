﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    // rename to user order
    public class OrderDetail:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
