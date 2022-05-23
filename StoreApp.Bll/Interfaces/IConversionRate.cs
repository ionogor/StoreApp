using StoreApp.Common.Dtos;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface IConversionRate
    {
        IEnumerable<DtoRate> Get();
        void Add(DtoRate rate);
    }
}
