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
    public class TipoHiloController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: TipoHilo
        public ActionResult Index()
        {
            return View(db.tipohilo.ToList());
        }



        // GET: TipoHilo/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: TipoHilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipohilo = db.tipohilo.Find(id);


            if (tipohilo == null)
            {
                return HttpNotFound();
            }


            return View(tipohilo);
        }



        // GET: TipoHilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipohilo = db.tipohilo.Find(id);


            if (tipohilo == null)
            {
                return HttpNotFound();
            }


            return View(tipohilo);
        }



        // GET: TipoHilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipohilo = db.tipohilo.Find(id);


            if (tipohilo == null)
            {
                return HttpNotFound();
            }


            return View(tipohilo);
        }



        // GET: TipoHilo/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipohilo = db.tipohilo.Find(id);


            if (tipohilo == null)
            {
                return HttpNotFound();
            }


            return View(tipohilo);
        }





        // POST: TipoHilo/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomthi,descthi,estthi")] TipoHilo obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tipohilo.Add(obj);
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





        // POST: TipoHilo/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codthi,nomthi,descthi,estthi")] TipoHilo obj)
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





        // POST: TipoHilo/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipohilo = db.tipohilo.Find(id);


                if (tipohilo != null)
                {
                    tipohilo.estthi = false;
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





        // POST: TipoHilo/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var tipohilo = db.tipohilo.Find(id);


                if (tipohilo != null)
                {
                    tipohilo.estthi = true;
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