using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public void AddNewProduct(Product product)
        {
            _productRepo.AddNewProduct(product);
        }

        public IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize)
        {
            return _productRepo.GetAllProducts()
                .OrderByDescending(p => p.DateAdded)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        public void UpdateProduct(Product product)
        {
            _productRepo.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
        }
    }
}
