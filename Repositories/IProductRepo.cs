using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepo
    {
        void AddNewProduct(Product product);
        void DeleteProduct(int ProductID);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int ProductID);
        void UpdateProduct(Product product);
    }
}