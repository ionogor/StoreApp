using StoreApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
   public interface IOrder
    {
        void AddOrder(IEnumerable< DtoOrder> dtoOrder);
        Task<DtoOrder> GetOrder();
    }
}
