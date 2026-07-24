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
    public class MaquinaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Maquina
        public ActionResult Index()
        {
            return View(db.maquina.ToList());
        }



        // GET: Maquina/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Maquina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var maquina = db.maquina.Find(id);


            if (maquina == null)
            {
                return HttpNotFound();
            }


            return View(maquina);
        }



        // GET: Maquina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var maquina = db.maquina.Find(id);


            if (maquina == null)
            {
                return HttpNotFound();
            }


            return View(maquina);
        }



        // GET: Maquina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var maquina = db.maquina.Find(id);


            if (maquina == null)
            {
                return HttpNotFound();
            }


            return View(maquina);
        }



        // GET: Maquina/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var maquina = db.maquina.Find(id);


            if (maquina == null)
            {
                return HttpNotFound();
            }


            return View(maquina);
        }





        // POST: Maquina/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nommaq,capmaq,estmaq")] Maquina obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.maquina.Add(obj);
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





        // POST: Maquina/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codmaq,nommaq,capmaq,estmaq")] Maquina obj)
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





        // POST: Maquina/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var maquina = db.maquina.Find(id);


                if (maquina != null)
                {
                    maquina.estmaq = false;
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





        // POST: Maquina/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var maquina = db.maquina.Find(id);


                if (maquina != null)
                {
                    maquina.estmaq = true;
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