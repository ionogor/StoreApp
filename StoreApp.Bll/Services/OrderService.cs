using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos;
using StoreApp.Data.Context;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Services
{
    public class OrderService : IOrder
    {
        private readonly GlobalContext _context;
        private readonly IMapper _mapper;

        public OrderService(GlobalContext context,IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }
        public void AddOrder(IEnumerable< DtoOrder> dtoOrder)
        {

            var order = _mapper.Map<IEnumerable< Order>>(dtoOrder);
            _context.Orders.AddRange(order);
            _context.SaveChanges();
              
        }

        public Task<DtoOrder> GetOrder()
        {
            throw new NotImplementedException();
        }
    }
}
