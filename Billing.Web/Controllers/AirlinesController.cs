using Billing.DAL;
using Billing.Entities;
using Billing.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Billing.Web.Controllers
{
    //[Authorize]
    public class AirlinesController : Controller
    {
        private readonly ApplicationDbContext db;
        public AirlinesController(ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }
        // GET: Airlines
        public ActionResult Index()
        {
            List<AirlinesListViewModel> lstObj = new UserDA().getAirlinesList();
            return View(lstObj);
        }

        // GET: Airlines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airlines airlines = db.Airliness.Find(id);
            if (airlines == null)
            {
                return NotFound();
            }

            return View(airlines);
        }

        // GET: Airlines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(new string[] { "Id","Name","Code" })] Airlines airlines)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Airliness.Add(airlines);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Create", "Airlines");
                }
            }

            return View(airlines);
        }

        // GET: Airlines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airlines airlines = db.Airliness.Find(id);
            if (airlines == null)
            {
                return NotFound();
            }

            return View(airlines);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(new string[] {"Id", "Name", "Code" })] Airlines airlines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airlines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airlines);
        }

        // GET: Airlines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airlines airlines = db.Airliness.Find(id);
            if (airlines == null)
            {
                return NotFound();
            }

            return View(airlines);
        }

        // POST: Airlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airlines airlines = db.Airliness.Find(id);
            db.Airliness.Remove(airlines);
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