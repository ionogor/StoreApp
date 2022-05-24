using AutoMapper;
using StoreApp.Common.Dtos;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, DtoOrder>().ReverseMap();
           

          
        }
    }
}
