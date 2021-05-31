using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "ExecutiveId cannot be empty!!")]
        public int ExecutiveId { get; set; }
        [Required(ErrorMessage = "Select Date and Time.It should not be empty!!")]
        public DateTime DateTimeOfPickUp { get; set; }
        [Required(ErrorMessage = "Enter the Weight of Package!!!")]
        public string WeightOfPackage { get; set; }
        [Required(ErrorMessage = "Address cannot be empty!!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City cannot be empty!!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Your Pincode!!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Pin")]
        //[MaxLength(6, ErrorMessage = "Invalid Pin")]
        public int PinCode { get; set; }
        [Required(ErrorMessage = "Enter your phone number!!")]
        //[MaxLength(10, ErrorMessage = "Invalid Phone")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Should be a number!!")]
        public string Phone { get; set; }
        public int Price { get; set; } = 250;
        public string status { get; set; }

    }
}
