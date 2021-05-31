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
    public class DeliveryExecutiveController : Controller
    {
        public readonly ILogger<DeliveryExecutiveController> _logger;
        public readonly IRepo<DeliveryExecutive> _repo;
        public readonly IRepo<Booking> _repo1;
        public DeliveryExecutiveController(ILogger<DeliveryExecutiveController> logger, IRepo<DeliveryExecutive> repo,IRepo<Booking> repo1)
        {
            _logger = logger;
            _repo = repo;
            _repo1 = repo1;

        }
        [HttpGet]
        public IActionResult Index()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().ToList();
            return View(deliveryExecutives);
        }

        public IActionResult ExecutivesList()
        {
            List<DeliveryExecutive> deliveryExecutives = _repo.GetAll().Where(a => a.IsVerified == "Yes").ToList();
            return View(deliveryExecutives);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeliveryExecutive deliveryExecutive)
        {
            deliveryExecutive.IsVerified = "Null";
            _repo.Add(deliveryExecutive);
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(DeliveryExecutive d)
        {
            int id = _repo.Login(d);
            if(id!=0)
            {
                TempData["ExecutiveId"] = id;
               // HttpContext.Session.SetInt32("ExecutiveId", id);
                //HttpContext.Session.SetInt32("CustomerId", id);
                return RedirectToAction("ExecutiveHome");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult ExecutiveHome()
        {
            return View();
        }
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
            DeliveryExecutive delivery = _repo.Get(id);
            return View(delivery);
        }
        [HttpPost]
        public IActionResult Edit(int id, DeliveryExecutive delivery)
        {
            _repo.update(id, delivery);
            return RedirectToAction("ExecutivesList");
        }

        public IActionResult RequestsPending()
        {
            // int id = HttpContext.Session.GetInt32("ExecutiveId") == null ? 0 : HttpContext.Session.GetInt32("ExecutiveId").Value;
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));

            List<Booking> d = _repo1.GetAll().Where(a => a.ExecutiveId == id && a.status=="Requested.....").ToList();
            if (d.Count() != 0)
            {
                return View(d);
            }
            else if (d.Count() == 0)
            {
                return View("NoPending");
            }
            return View();

        }
        public IActionResult TotalWork()
        {
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> d = _repo1.GetAll().Where(a => a.ExecutiveId == id && a.status!="Requested.....").ToList();
            if (d.Count() != 0)
            {
                return View(d);
            }
            else if (d.Count() == 0)
            {
                return View("NoWork");
            }
            return View();
            
        }

        public IActionResult NoWork()
        {
            return View();
        }

        public IActionResult AcceptedList()
        {
            int id = Convert.ToInt32(TempData.Peek("ExecutiveId"));
            List<Booking> b = _repo1.GetAll().Where(a => a.ExecutiveId == id && a.status == "Accepted").ToList();
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

        public IActionResult NoPending()
        {
            return View();
        }
                                  
                                                                    //list<executive> b=_repo1.getall().tolist();
                                                          
            
            
                                                                 //list<executive> c=b.where(b.city==u.city && b.Isverified=='yes'.tolist();

        

    }
}

//list<executive> b=_repo1.getall().tolist();



//list<executive> c=b.where(b.city==u.city && b.Isverified=='yes'.tolist();


