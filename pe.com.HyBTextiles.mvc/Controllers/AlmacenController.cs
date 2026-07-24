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
    public class AlmacenController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.almacen.ToList());
        }
        //GET: Almacen/Create
        public ActionResult Create()
        {
            return View();
        }

        //GET: Almacen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(almacen);
            }
        }

        //GET: Almacen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(almacen);
            }
        }

        //GET: Almacen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(almacen);
            }
        }

        //GET: Almacen/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var almacen = db.almacen.Find(id);
            if (almacen == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(almacen);
            }
        }


        //acciones -> Post
        //POST Almacen/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "nomalm,diralm,estalm")] Almacen obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.almacen.Add(obj);
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

        //POST Almacen/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, [Bind(Include = "codalm,nomalm,diralm,estalm")] Almacen obj)
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var almacen = db.almacen.Find(id);

                if (almacen != null)
                {
                    almacen.estalm = false;
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

        //POST: Almacen/Enable/5
        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var almacen = db.almacen.Find(id);
                if (almacen != null)
                {
                    almacen.estalm = true;
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

        //limpiamos los objeto de memoria
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