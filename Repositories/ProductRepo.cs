using ProductManagementAPI.Models;

namespace ProductManagementAPI.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        //add new product
        public void AddNewProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }

        }

        //Get all products
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _context.Products.ToList();

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Get a product by ID
        public Product GetProductById(int ProductID)
        {
            try
            {
                return _context.Products.FirstOrDefault(p => p.PID == ProductID);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Update a product
        public void UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }

        //Delete a product
        public void DeleteProduct(int ProductID)
        {
            try
            {
                var product = GetProductById(ProductID);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Database error: {ex.Message}");
            }
        }
    }
}
