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
    public class ProveedorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Proveedor
        public ActionResult Index()
        {
            return View(db.proveedor.ToList());
        }



        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var proveedor = db.proveedor.Find(id);


            if (proveedor == null)
            {
                return HttpNotFound();
            }


            return View(proveedor);
        }



        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var proveedor = db.proveedor.Find(id);


            if (proveedor == null)
            {
                return HttpNotFound();
            }


            return View(proveedor);
        }



        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var proveedor = db.proveedor.Find(id);


            if (proveedor == null)
            {
                return HttpNotFound();
            }


            return View(proveedor);
        }



        // GET: Proveedor/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var proveedor = db.proveedor.Find(id);


            if (proveedor == null)
            {
                return HttpNotFound();
            }


            return View(proveedor);
        }





        // POST: Proveedor/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include =
            "rucprv,razonsocialprv,nomcontactoprv,telprv,emaprv,dirprv,estprv")] Proveedor obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.proveedor.Add(obj);
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





        // POST: Proveedor/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include =
            "codprv,rucprv,razonsocialprv,nomcontactoprv,telprv,emaprv,dirprv,estprv")] Proveedor obj)
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





        // POST: Proveedor/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var proveedor = db.proveedor.Find(id);


                if (proveedor != null)
                {
                    proveedor.estprv = false;
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





        // POST: Proveedor/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var proveedor = db.proveedor.Find(id);


                if (proveedor != null)
                {
                    proveedor.estprv = true;
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