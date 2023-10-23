using System.Data;
using System.Linq;
using System.Net;
using Billing.DAL;
using Billing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Billing.Web.Controllers
{
    //[Authorize]
    public class AirportCodesController : Controller
    {
        private readonly ApplicationDbContext db;
        public AirportCodesController(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        // GET: AirportCodes
        public ActionResult Index()
        {
            return View(db.AirportCodes.OrderBy(x => x.Name).ToList());
        }

        // GET: AirportCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AirportCode airportCode = db.AirportCodes.Find(id);
            if (airportCode == null)
            {
                return NotFound();
            }

            return View(airportCode);
        }

        // GET: AirportCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AirportCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AirportCode airportCode)
        {
            if (ModelState.IsValid)
            {
                db.AirportCodes.Add(airportCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airportCode);
        }

        // GET: AirportCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AirportCode airportCode = db.AirportCodes.Find(id);
            if (airportCode == null)
            {
                return NotFound();
            }

            return View(airportCode);
        }

        // POST: AirportCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(new string[] { "Id", "Name","Country","Code" })] AirportCode airportCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airportCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airportCode);
        }

        // GET: AirportCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AirportCode airportCode = db.AirportCodes.Find(id);
            db.AirportCodes.Remove(airportCode);
            db.SaveChanges();
            return RedirectToAction("Index", "AirportCodes");
        }

        // POST: AirportCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirportCode airportCode = db.AirportCodes.Find(id);
            db.AirportCodes.Remove(airportCode);
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