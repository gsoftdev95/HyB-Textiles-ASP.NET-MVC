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
    public class TipoTejidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: TipoTejido
        public ActionResult Index()
        {
            return View(db.tipotejido.ToList());
        }



        // GET: TipoTejido/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: TipoTejido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipotejido = db.tipotejido.Find(id);


            if (tipotejido == null)
            {
                return HttpNotFound();
            }


            return View(tipotejido);
        }



        // GET: TipoTejido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipotejido = db.tipotejido.Find(id);


            if (tipotejido == null)
            {
                return HttpNotFound();
            }


            return View(tipotejido);
        }



        // GET: TipoTejido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipotejido = db.tipotejido.Find(id);


            if (tipotejido == null)
            {
                return HttpNotFound();
            }


            return View(tipotejido);
        }



        // GET: TipoTejido/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var tipotejido = db.tipotejido.Find(id);


            if (tipotejido == null)
            {
                return HttpNotFound();
            }


            return View(tipotejido);
        }





        // POST: TipoTejido/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomtte,desctte,esttte")] TipoTejido obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tipotejido.Add(obj);
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





        // POST: TipoTejido/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codtte,nomtte,desctte,esttte")] TipoTejido obj)
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





        // POST: TipoTejido/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var tipotejido = db.tipotejido.Find(id);


                if (tipotejido != null)
                {
                    tipotejido.esttte = false;
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





        // POST: TipoTejido/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var tipotejido = db.tipotejido.Find(id);


                if (tipotejido != null)
                {
                    tipotejido.esttte = true;
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