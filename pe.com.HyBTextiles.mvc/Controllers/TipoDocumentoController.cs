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
    public class TipoDocumentoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View(db.tipodocumento.ToList());
        }



        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipodocumento = db.tipodocumento.Find(id);


            if (tipodocumento == null)
            {
                return HttpNotFound();
            }


            return View(tipodocumento);
        }



        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipodocumento = db.tipodocumento.Find(id);


            if (tipodocumento == null)
            {
                return HttpNotFound();
            }


            return View(tipodocumento);
        }



        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipodocumento = db.tipodocumento.Find(id);


            if (tipodocumento == null)
            {
                return HttpNotFound();
            }


            return View(tipodocumento);
        }



        // GET: TipoDocumento/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipodocumento = db.tipodocumento.Find(id);


            if (tipodocumento == null)
            {
                return HttpNotFound();
            }


            return View(tipodocumento);
        }





        // POST: TipoDocumento/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomtdo,esttdo")] TipoDocumento obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tipodocumento.Add(obj);
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





        // POST: TipoDocumento/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codtdo,nomtdo,esttdo")] TipoDocumento obj)
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





        // POST: TipoDocumento/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipodocumento = db.tipodocumento.Find(id);


                if (tipodocumento != null)
                {
                    tipodocumento.esttdo = false;
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





        // POST: TipoDocumento/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var tipodocumento = db.tipodocumento.Find(id);


                if (tipodocumento != null)
                {
                    tipodocumento.esttdo = true;
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