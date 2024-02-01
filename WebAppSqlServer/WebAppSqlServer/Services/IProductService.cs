
using WebAppSqlServer.Models;

namespace WebAppSqlServer.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Task<bool> IsBeta();
    }
}