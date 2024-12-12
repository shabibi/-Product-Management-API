using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        [Key]
        public int PID { get; set; }

        public string PName {  get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
