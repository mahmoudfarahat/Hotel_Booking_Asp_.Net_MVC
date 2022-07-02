using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;
using Microsoft.AspNet.Identity;

namespace HotelBooking.Controllers
{
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.AdminRole))
            {
                var reservations = db.Reservations.Include(r => r.Room).Include(u => u.ApplicationUser);
                return View(reservations.ToList());
            }
            if (User.IsInRole(RoleName.CustomerRole))
            {
                string userId = User.Identity.GetUserId();

                var reservations = db.Reservations.Include(r => r.Room).Include(u => u.ApplicationUser)
                    .Where(c => c.ApplicationUser.Id == userId).ToList(); ;
                return View(reservations.ToList());
            }

            return View();
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
      
        [Authorize(Roles =  "CustomerRole , AdminRole" )]
        public ActionResult Create(int id)
        {
            string userId = User.Identity.GetUserId();

            ViewBag.UserId = userId;
            ViewBag.RoomId = id;
            
            return View();
        }
        [HttpGet]
        public ActionResult GetRoomReservationDate(int roomId)
        {
            var firstReservation = db.Reservations.FirstOrDefault(a => a.RoomId == roomId);
            var lastreserivation = db.Reservations.Where(a => a.RoomId == roomId).ToList().LastOrDefault();
           
            return Json(new { start = firstReservation.StartDate ,end = firstReservation.EndDate  },JsonRequestBehavior.AllowGet);
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult Create(Reservation reservation, int id)
        {
        

            if (ModelState.IsValid)
            {
                 var room = db.Rooms.SingleOrDefault(c => c.Id == reservation.RoomId);
                
                room.IsReserved = 1;
                reservation.ApplicationUserId = User.Identity.GetUserId();
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(reservation);
        }


        // GET: Reservations/Edit/5
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,Phone,Email,StartDate,EndDate,NightNumbers,RoomId,ApplicationUserID")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Id", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CustomerRole , AdminRole")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Reservation reservation = db.Reservations.Find(id);

            var room = db.Rooms.SingleOrDefault(c => c.Id == reservation.RoomId);

            room.IsReserved = 0;

            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
 
}
