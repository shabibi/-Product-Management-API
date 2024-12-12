using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult AddNewProduct(InputDOT productInput)
        {
            try
            {
                // Check if input data is null
                if (productInput == null)
                    return BadRequest("Product data is required");

                //create new product
                var product = new Product
                {
                    PName = productInput.Name,
                    Price = productInput.Price,
                    Category = productInput.Category
                };

                // Add the new product to the database/service layer
                _productService.AddNewProduct(product);

                // Map the created product to an OutputDTO to return a response to the client
                var createdProduct = new OutputDTO
                {
                    PName = product.PName,
                    Price = product.Price,
                    Category = product.Category,
                    DateAdded = DateTime.UtcNow
                };
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while adding the product. {ex.Message} ");
            }
        }
    }
}
