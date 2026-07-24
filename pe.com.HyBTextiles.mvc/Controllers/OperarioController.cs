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
    public class OperarioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Operario
        public ActionResult Index()
        {
            return View(db.operario.ToList());
        }



        // GET: Operario/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Operario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var operario = db.operario.Find(id);


            if (operario == null)
            {
                return HttpNotFound();
            }


            return View(operario);
        }



        // GET: Operario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var operario = db.operario.Find(id);


            if (operario == null)
            {
                return HttpNotFound();
            }


            return View(operario);
        }



        // GET: Operario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var operario = db.operario.Find(id);


            if (operario == null)
            {
                return HttpNotFound();
            }


            return View(operario);
        }



        // GET: Operario/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var operario = db.operario.Find(id);


            if (operario == null)
            {
                return HttpNotFound();
            }


            return View(operario);
        }





        // POST: Operario/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomope,docope,telope,estope")] Operario obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.operario.Add(obj);
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





        // POST: Operario/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codope,nomope,docope,telope,estope")] Operario obj)
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





        // POST: Operario/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var operario = db.operario.Find(id);


                if (operario != null)
                {
                    operario.estope = false;
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





        // POST: Operario/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var operario = db.operario.Find(id);


                if (operario != null)
                {
                    operario.estope = true;
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