
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Models
{
    public class InputDOT
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range (1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; } 

        public string Category { get; set; } = "general";
    }
}
