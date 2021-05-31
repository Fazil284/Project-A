using DeliveryProject.Models;
using DeliveryProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryProject.Controllers
{
    public class AdminController : Controller
    {

        public DeliveryContext context;
        public readonly ILogger<AdminController> _logger;
        public readonly IRepo<DeliveryExecutive> _repo;

        public AdminController(ILogger<AdminController> logger, IRepo<DeliveryExecutive> repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (admin.Username == "Admin" && admin.Password == "1234")
            {
                return RedirectToAction("AdminHome");
            }
            else
            {
                return View("Error");
            }
           
        }

        public IActionResult AdminHome()
        {
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ExecutivesList()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }
        public IActionResult Edit(int id)
        {
            DeliveryExecutive  d= _repo.Get(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(int id, DeliveryExecutive b)
        {
            _repo.update(id, b);
            return RedirectToAction("ExecutivesList","Admin");
        }
    }
}
