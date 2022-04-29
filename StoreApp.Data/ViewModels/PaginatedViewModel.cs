using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.ViewModels
{
    public class PaginatedViewModel
    {
        public int Count { get; set; } = 10;
        public int Page { get; set; } = 1;
    }

}
