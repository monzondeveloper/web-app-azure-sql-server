using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSqlServer.Models;
using WebAppSqlServer.Services;

namespace WebAppSqlServer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;

        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            products = _productService.GetProducts();
        }
    }
}
