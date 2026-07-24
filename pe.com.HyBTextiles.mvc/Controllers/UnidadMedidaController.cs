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
    public class UnidadMedidaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: UnidadMedida
        public ActionResult Index()
        {
            return View(db.unidadmedida.ToList());
        }



        // GET: UnidadMedida/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: UnidadMedida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var unidadmedida = db.unidadmedida.Find(id);


            if (unidadmedida == null)
            {
                return HttpNotFound();
            }


            return View(unidadmedida);
        }



        // GET: UnidadMedida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var unidadmedida = db.unidadmedida.Find(id);


            if (unidadmedida == null)
            {
                return HttpNotFound();
            }


            return View(unidadmedida);
        }



        // GET: UnidadMedida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var unidadmedida = db.unidadmedida.Find(id);


            if (unidadmedida == null)
            {
                return HttpNotFound();
            }


            return View(unidadmedida);
        }



        // GET: UnidadMedida/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var unidadmedida = db.unidadmedida.Find(id);


            if (unidadmedida == null)
            {
                return HttpNotFound();
            }


            return View(unidadmedida);
        }





        // POST: UnidadMedida/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomund,abrund,estund")] UnidadMedida obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.unidadmedida.Add(obj);
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





        // POST: UnidadMedida/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codund,nomund,abrund,estund")] UnidadMedida obj)
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





        // POST: UnidadMedida/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var unidadmedida = db.unidadmedida.Find(id);


                if (unidadmedida != null)
                {
                    unidadmedida.estund = false;
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





        // POST: UnidadMedida/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var unidadmedida = db.unidadmedida.Find(id);


                if (unidadmedida != null)
                {
                    unidadmedida.estund = true;
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