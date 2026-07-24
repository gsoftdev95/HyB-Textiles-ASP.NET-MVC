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
    public class PermisoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Permiso
        public ActionResult Index()
        {
            return View(db.permiso.ToList());
        }



        // GET: Permiso/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Permiso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var permiso = db.permiso.Find(id);


            if (permiso == null)
            {
                return HttpNotFound();
            }


            return View(permiso);
        }



        // GET: Permiso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var permiso = db.permiso.Find(id);


            if (permiso == null)
            {
                return HttpNotFound();
            }


            return View(permiso);
        }



        // GET: Permiso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var permiso = db.permiso.Find(id);


            if (permiso == null)
            {
                return HttpNotFound();
            }


            return View(permiso);
        }



        // GET: Permiso/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var permiso = db.permiso.Find(id);


            if (permiso == null)
            {
                return HttpNotFound();
            }


            return View(permiso);
        }





        // POST: Permiso/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomper,descper,estper")] Permiso obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.permiso.Add(obj);
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





        // POST: Permiso/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codper,nomper,descper,estper")] Permiso obj)
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





        // POST: Permiso/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var permiso = db.permiso.Find(id);


                if (permiso != null)
                {
                    permiso.estper = false;
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





        // POST: Permiso/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var permiso = db.permiso.Find(id);


                if (permiso != null)
                {
                    permiso.estper = true;
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