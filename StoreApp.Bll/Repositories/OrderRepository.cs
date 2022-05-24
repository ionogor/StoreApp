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

namespace StoreApp.Bll.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly GlobalContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(GlobalContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }
        public void AddOrder(DtoOrder orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

       

        public Task<DtoOrder> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
