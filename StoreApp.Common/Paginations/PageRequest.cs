using StoreApp.Common.Dtos.Products;

namespace StoreApp.Common.Paginations
{
    public class PageRequest
    {
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public List<ProductListDto> ProductListDtos { get; set; }
    }
}
