
using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Models
{
    public class InputDOT
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range (1, int.MaxValue)]
        public decimal Price { get; set; }

        public string Category { get; set; } = "general";
    }
}
