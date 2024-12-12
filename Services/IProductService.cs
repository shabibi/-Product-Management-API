using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}