using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize);
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}