using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Should be less than 20 caracters")]
        [MinLength(3, ErrorMessage = "Not less than 3!!")]
        [DisplayName("Name of the Order")]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [DisplayName("Meals")]
        [Range(1, int.MaxValue, ErrorMessage = "Incorrect!")]
        public int FoodId { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "You cant order more than 10 or less than 0 items of food!")]
        [DisplayName("Quantity of items")]
        public int Quantity { get; set; }

        public decimal Total { get; set; }

    }
}
