using DeliveryProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Services
{
    public class DeliveryExecutiveManager : IRepo<DeliveryExecutive>
    {
        public DeliveryContext _context;
        public ILogger<DeliveryExecutiveManager> _logger;
        public DeliveryExecutiveManager(DeliveryContext context, ILogger<DeliveryExecutiveManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(DeliveryExecutive t)
        {
            try
            {
                _context.deliveryexecutives.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public IEnumerable<DeliveryExecutive> GetAll()
        {
            try
            {
                if ((_context.deliveryexecutives) == null)
                    return null;
                return _context.deliveryexecutives.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;

        }

        public int Login(DeliveryExecutive t)
        {
            DeliveryExecutive obj = _context.deliveryexecutives.Where(i => i.Username.Equals(t.Username) 
                                              && i.Password.Equals(t.Password)&& i.IsVerified.Equals("yes")).SingleOrDefault();
            try
            {
                if (obj != null)
                {
                    return obj.ExecutiveId;
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return 0;
        }

        //public DeliveryExecutive GetById(int id)
        //{
        //    try
        //    {
        //        DeliveryExecutive a = _context.deliveryexecutives.FirstOrDefault(a => a.ExecutiveId == id);
        //        return a;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogDebug(e.Message);
        //    }
        //    return null;

        //}
        public DeliveryExecutive Get(int id)
        {
            try
            {
                DeliveryExecutive delivery = _context.deliveryexecutives.FirstOrDefault(a => a.ExecutiveId == id);
                return delivery;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }



        public void update(int id, DeliveryExecutive t)
        {
            DeliveryExecutive delivery = Get(id);
            if (delivery != null)
            {
                delivery.IsVerified = t.IsVerified;
            }
            _context.SaveChanges();
        }
    }
}
