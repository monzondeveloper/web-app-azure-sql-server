using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSqlServer.Models;
using WebAppSqlServer.Services;

namespace WebAppSqlServer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
        public bool IsBeta;

        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            IsBeta = _productService.IsBeta().Result;
            products = _productService.GetProducts();
        }
    }
}
