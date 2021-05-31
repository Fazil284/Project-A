using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryProject.Models;
using Microsoft.AspNetCore.Http;
using DeliveryProject.Services;
using Microsoft.Extensions.Logging;

namespace DeliveryProject.Controllers
{
    public class BookingsController : Controller
    {
        public readonly DeliveryContext _context;
        public readonly ILogger<BookingsController> _logger;
        public readonly IRepo<Booking> _repo;
        //public BookingsController(ILogger<BookingsController> logger, IRepo<Booking> repo)
        //{
        //    _logger = logger;
        //    _repo = repo;
        //}
        public BookingsController(DeliveryContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.bookings.ToListAsync());
        }

        public async Task<IActionResult> BookingRequests()
        {
            return View(await _context.bookings.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            Booking b = new Booking();
           
            List<Booking> a = _repo.GetAll().ToList();
            return View(a);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
                                                                     //int id = HttpContext.Session.GetInt32("CustomerId") == null?0: HttpContext.Session.GetInt32("CustomerId").Value;
            int id = Convert.ToInt32(TempData.Peek("CustomerId"));
            Booking b = new Booking();
            b.CustomerId = id;
            return View(b);
        }                                                 //for executive===//int id = Convert.ToInt32(TempData.Peek("CustomerId"));
                                                       //var u=_repo.getbyid(id);
                                                     //list<executive> b=_repo1.getall().tolist();
                                                      //list<executive> c=b.where(b.city==u.city && b.Isverified=='yes'.tolist();

        

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,ExecutiveId,DateTimeOfPickUp,WeightOfPackage,Address,City,PinCode,Phone,Price")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.status = "Requested.....";
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction("CustomerHome","Customer");
            }
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,CustomerId,ExecutiveId,DateTimeOfPickUp,WeightOfPackage,Address,City,PinCode,Phone,status,Price")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("RequestsPending","DeliveryExecutive");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.bookings.FindAsync(id);
            _context.bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.bookings.Any(e => e.BookingId == id);
        }
        
    }
}
