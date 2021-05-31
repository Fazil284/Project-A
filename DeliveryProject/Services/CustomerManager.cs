using DeliveryProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Services
{
    public class CustomerManager:IRepo<Customer>
    {
        public DeliveryContext _context;
        public ILogger<CustomerManager> _logger;
        public CustomerManager(DeliveryContext context, ILogger<CustomerManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Customer t)
        {
            try
            {
                _context.customers.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Customer Get(int id)
        {
            try
            {
                Customer c = _context.customers.FirstOrDefault(a => a.CustomerId == id);
                return c;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Customer> GetAll()
        {
            try
            {
                if ((_context.customers) == null)
                    return null;
                return _context.customers.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        




        public int Login(Customer t)
        {
            Customer obj= _context.customers.Where(i => i.Username.Equals(t.Username) && i.Password.Equals(t.Password)&& i.IsVerified.Equals("yes")).SingleOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.CustomerId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        

        public void update(int id, Customer t)
        {
            Customer a = Get(id);
            if (a != null)
            {
                a.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();
        }

        //public DeliveryExecutive Get(int id)
        //{
        //    try
        //    {
        //        DeliveryExecutive delivery = _context.deliveryExecutives.FirstOrDefault(a => a.executiveID == id);
        //        return delivery;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogDebug(e.Message);
        //    }
        //    return null;
        //}



        //public int Login(User user)
        //{
        //    var obj = _context.customers.Where(i => i.Username.Equals(user.Username) && i.Password.Equals(user.Password)).Select CustomerId;
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            return 1;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogDebug(e.Message);
        //    }
        //    return 0;
        //}


        //public DeliveryExecutive Get(int id)
        //{
        //    try
        //    {
        //        DeliveryExecutive delivery = _context.deliveryexecutives.FirstOrDefault(a => a.ExecutiveId == id);
        //        return delivery;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogDebug(e.Message);
        //    }
        //    return null;
        //}

        //public void Update(int id, DeliveryExecutive t)
        //{
        //    DeliveryExecutive delivery = Get(id);
        //    if (delivery != null)
        //    {
        //        delivery.IsVerified = t.IsVerified;
        //    }
        //    _context.SaveChanges();

        //}
    }
}