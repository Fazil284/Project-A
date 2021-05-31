using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Models
{
    public class DeliveryContext:DbContext
    {
        public DeliveryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<DeliveryExecutive> deliveryexecutives { get; set; }
        public DbSet<Booking> bookings { get; set; }
    }
}
