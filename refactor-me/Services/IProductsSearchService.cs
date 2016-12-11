using ProductsApi.Models;

namespace ProductsApi.Services
{
    public interface IProductsSearchService
    {
        Products GetAll();
    }
}