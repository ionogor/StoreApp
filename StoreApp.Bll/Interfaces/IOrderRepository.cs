using StoreApp.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface IOrderRepository
    {
        Task<DtoOrder> GetById(int id);
     //   Task<IEnumerable<DtoOrder>> GetAll();
        void AddOrder(DtoOrder order);
    }
}
