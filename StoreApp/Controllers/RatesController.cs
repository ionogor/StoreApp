using Microsoft.AspNetCore.Mvc;
using StoreApp.Bll.Interfaces;
using StoreApp.Bll.Services;
using StoreApp.Common.Dtos;
using StoreApp.Domain.Entity;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly IConversionRate _conversionRate;


        public RatesController(IConversionRate rate)
        {
            _conversionRate = rate;
        }
        [HttpGet]
        public IEnumerable Get()
        {
          return _conversionRate.Get();
        }

        
        [HttpPost]
        public void Post([FromBody] DtoRate rate)
        {
            _conversionRate.Add(rate);
        }

       
    }
}
