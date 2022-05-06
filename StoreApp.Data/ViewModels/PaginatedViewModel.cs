using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.ViewModels
{
    public class PaginatedViewModel
    {
        public int Count { get; set; } = 12;
        public int Page { get; set; } = 1;
    }

}
