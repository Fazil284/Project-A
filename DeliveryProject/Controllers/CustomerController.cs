using DeliveryProject.Models;
using DeliveryProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace DeliveryProject.Controllers
{
    public class CustomerController : Controller
    {

        public DeliveryContext context;
        public readonly ILogger<CustomerController> _logger;
        public readonly IRepo<Customer> _repo;
        public readonly IRepo<Booking> _repo2;
        public CustomerController(ILogger<CustomerController> logger, IRepo<Customer> repo,IRepo<Booking> repo2)
        {
            _logger = logger;
            _repo = repo;
            _repo2 = repo2;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> cust = _repo.GetAll().ToList();
            return View(cust);
        }

        public IActionResult CustomerList()
        {
            List<Customer> c = _repo.GetAll().ToList();
            return View(c);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            c.IsVerified = "Null";
            _repo.Add(c);
            return RedirectToAction("Login");
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(Customer c)
        {
            int id = _repo.Login(c);
            if (id != 0)
            {
                TempData["CustomerId"] = id;   
                //HttpContext.Session.SetInt32("CustomerId", id);
                return RedirectToAction("CustomerHome");
            }
            else
            {
                return View("Error");
            }
        }
        

        public IActionResult AcceptedList()
        {
            int cid = Convert.ToInt32(TempData.Peek("CustomerId"));
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> b = _repo2.GetAll().Where(a =>a.CustomerId==cid && a.status=="Accepted").ToList();
            if(b.Count()!=0)
            {
                return View(b);
            }
            else if(b.Count()==0)
            {
                return View("Empty");
            }
            return View();
               
        }

        public IActionResult RejectedList()
        {
            int cid = Convert.ToInt32(TempData.Peek("CustomerId"));
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> b = _repo2.GetAll().Where(a=>a.CustomerId==cid && a.status == "Rejected").ToList();
            if (b.Count() != 0)
            {
                return View(b);
            }
            else if (b.Count() == 0)
            {
                return View("Empty");
            }
            return View();

        }
        public IActionResult Empty()
        {
            return View();
        }

        //public ActionResult CustomerRequests()
        //{
        //    List<Customer> a = _repo.GetAll().ToList();
        //    List<Customer> b= 
        //}


        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var obj = await context.customers.FindAsync(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Name,Username,Password,Age,Phone,Address,City,IsVerified")] Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            context.Update(customer);
        //            await context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.CustomerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}

      


            

        //public ActionResult Find([Bind("CustomerId")] Customer prodcut)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userid = int.Parse(User.Identity.Name.Split('\\').Last());
        //        prodcut.CustomerId = userid;


        //        _context.customers.Add(prodcut);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // [HttpGet]

        //public IActionResult CustomerLogin(Customer customer)
        //{
        //    var obj = _repo.Login();
        //    List<Customer> customers = _repo.GetAll().ToList();
        //    if(customers.Count()!=0)
        //    {
        //        var rec = customers.Where(a => a.Username == user.Username && a.Password == user.Password).Select(b => b.CustomerId);
        //        if(rec!=null)
        //        {
        //            TempData["UserId"] = rec;
        //            return RedirectToAction("Home");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Login", "User");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "User");
        //    }
        //}
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Customer c = _repo.Get(id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int id, Customer b)
        {
            _repo.update(id, b);
            return RedirectToAction("CustomerList");
        }
        public IActionResult CustomerHome()
        {
            return View();
        }

    }
}

