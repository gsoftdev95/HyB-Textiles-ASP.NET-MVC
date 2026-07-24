using pe.com.HyBTextiles.mvc.Models;
using pe.com.HyBTextiles.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace pe.com.HyBTextiles.mvc.Controllers
{
    public class TurnoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Turno
        public ActionResult Index()
        {
            return View(db.turno.ToList());
        }



        // GET: Turno/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Turno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var turno = db.turno.Find(id);


            if (turno == null)
            {
                return HttpNotFound();
            }


            return View(turno);
        }



        // GET: Turno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var turno = db.turno.Find(id);


            if (turno == null)
            {
                return HttpNotFound();
            }


            return View(turno);
        }



        // GET: Turno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var turno = db.turno.Find(id);


            if (turno == null)
            {
                return HttpNotFound();
            }


            return View(turno);
        }



        // GET: Turno/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var turno = db.turno.Find(id);


            if (turno == null)
            {
                return HttpNotFound();
            }


            return View(turno);
        }





        // POST: Turno/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomtur,horainitur,horafintur,esttur")] Turno obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.turno.Add(obj);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View(obj);
            }
        }





        // POST: Turno/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codtur,nomtur,horainitur,horafintur,esttur")] Turno obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }


                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View(obj);
            }
        }





        // POST: Turno/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var turno = db.turno.Find(id);


                if (turno != null)
                {
                    turno.esttur = false;
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
        }





        // POST: Turno/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var turno = db.turno.Find(id);


                if (turno != null)
                {
                    turno.esttur = true;
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View();
            }
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