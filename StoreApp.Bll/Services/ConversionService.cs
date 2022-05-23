using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos;
using StoreApp.Data.Context;
using StoreApp.Data.Interfaces;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Services
{
    public class ConversionService : IConversionRate
    {
       private readonly IRepository<ConversionRate> _repository;

        private readonly IMapper _mapper;

        public ConversionService(IRepository<ConversionRate> repository,IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
               
        }

        public void Add(DtoRate rate)
        {
           var newRate= _mapper.Map<ConversionRate>(rate);
            _repository.Add(newRate);
            _repository.SaveChangeAsync();

        }

        public IEnumerable<DtoRate> Get()
        {
            if (_repository==null)
            {
                throw new Exception("Context is null");
            }
            var resultRate = _repository.Read();

            var mapper = _mapper.Map<IEnumerable<DtoRate>>(resultRate);

            return mapper;
        }
    }
}
