using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name must be 50 characters or less")]
        public string Name { get; set; }

        [Required]
        [Range(0, 110, ErrorMessage = "Age must be between 0 and 110")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Post code must contain numbers and letters")]
        public string PostCode { get; set; }

        [Required]
        [Range(0, 2.50, ErrorMessage = "Height must be between 0 and 2.50 meters")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Height must have up to 2 decimal places")]
        public double Height { get; set; }
    }
}