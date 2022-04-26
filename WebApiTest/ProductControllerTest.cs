using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StoreApp.Bll.Interfaces;
using StoreApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTest
{
    [TestClass]
    public  class ProductControllerTest
    {
        private readonly ProductController _productController;
        public ProductControllerTest()
        {
            var mockProductService = new Mock<IProductService>();
        }

        [Fact]

    }
}
