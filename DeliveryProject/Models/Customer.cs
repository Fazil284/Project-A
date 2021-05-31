using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Models
{
    public class Customer
    {
        [Key]

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter your Name!!")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a username!!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Age cannot be empty!!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter your phone number!!")]
        [MaxLength(10, ErrorMessage = "Invalid Phone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Should be a number!!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address cannot be empty!!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City cannot be empty!!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Your Pincode!!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Code!!")]
        [MaxLength(6, ErrorMessage = "Invalid Pin")]
        public string  Pincode { get; set; }
        public string IsVerified { get; set; }
    }
}
