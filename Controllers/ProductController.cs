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
                    Category = productInput.Category,
                    DateAdded = DateTime.Now
                };

                // Add the new product to the database/service layer
                _productService.AddNewProduct(product);
                
                // Map the created product to an OutputDTO to return a response to the client
                var createdProduct = new OutputDTO
                {
                    PName = product.PName,
                    Price = product.Price,
                    Category = product.Category,
                    DateAdded = product.DateAdded
                };
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while adding the product. {ex.Message} ");
            }
        }

        [HttpGet]
        public IActionResult GetAllProducts(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var products = _productService.GetAllProducts(pageNumber,pageSize);
                if (products == null || !products.Any())
                {
                    return NotFound("No products found.");
                }
                var outputProduct = new List<OutputDTO>();
                foreach(var product in products)
                {
                    outputProduct.Add(new OutputDTO
                    {
                        PName= product.PName,
                        Price = product.Price,
                        Category = product.Category,
                        DateAdded = product.DateAdded
                    });
                }
                return Ok(outputProduct);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while retrieving products. {(ex.Message)}");

            }
        }

        [HttpGet("GetProductByID/{ProductId}")]
        public IActionResult GetProductById(int ProductId)
        {
            try
            {
                var product = _productService.GetProductById(ProductId);
                if(product == null)
                    return NotFound("No product found.");

                var outputProduct = new OutputDTO
                {
                    PName = product.PName,
                    Price = product.Price,
                    Category = product.Category,
                    DateAdded = product.DateAdded
                };

                return Ok(outputProduct);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while retrieving product. {(ex.Message)}");

            }
        }

        [HttpPut("UpdateProduct/{productId}")]
        public IActionResult UpdateProduct(int productId, InputDOT inputProduct )
        {
            
            try
            {
                if (inputProduct == null)
                    return BadRequest("Product data is required.");

                var product = _productService.GetProductById(productId);
                if(product == null)
                    return NotFound($"Product with ID {productId} not found.");

                product.PName = inputProduct.Name;
                product.Price = inputProduct.Price;
                product.Category = inputProduct.Category;
                product.DateAdded = DateTime.Now;
                _productService.UpdateProduct(product);

                var updatedProduct = new OutputDTO
                {
                    PName = product.PName,
                    Price = product.Price,
                    Category = product.Category,
                    DateAdded = product.DateAdded
                };
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while updte product. {(ex.Message)}");

            }
        }

        [HttpDelete("DeleteProduct/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {

            try
            {
             
                var product = _productService.GetProductById(productId);
                if (product == null)
                    return NotFound($"Product with ID {productId} not found.");

                _productService.DeleteProduct(productId);

                
                return Ok($"Prduct whith productId {productId} Deleted ");
            }
            catch (Exception ex)
            {
                // Return a generic error response
                return StatusCode(500, $"An error occurred while updte product. {(ex.Message)}");

            }
        }

    }
}
