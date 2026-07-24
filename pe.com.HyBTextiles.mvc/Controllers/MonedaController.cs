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
    public class MonedaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        // GET: Moneda
        public ActionResult Index()
        {
            return View(db.moneda.ToList());
        }



        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Moneda/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var moneda = db.moneda.Find(id);


            if (moneda == null)
            {
                return HttpNotFound();
            }


            return View(moneda);
        }



        // GET: Moneda/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var moneda = db.moneda.Find(id);


            if (moneda == null)
            {
                return HttpNotFound();
            }


            return View(moneda);
        }



        // GET: Moneda/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var moneda = db.moneda.Find(id);


            if (moneda == null)
            {
                return HttpNotFound();
            }


            return View(moneda);
        }



        // GET: Moneda/Enable
        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var moneda = db.moneda.Find(id);


            if (moneda == null)
            {
                return HttpNotFound();
            }


            return View(moneda);
        }





        // POST Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include="nommon,simbmon,estmon")]
            Moneda obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.moneda.Add(obj);

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





        // POST Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include="codmon,nommon,simbmon,estmon")]
            Moneda obj)
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





        // POST Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {

                var moneda = db.moneda.Find(id);


                if (moneda != null)
                {

                    moneda.estmon = false;

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





        // POST Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {

            try
            {

                var moneda = db.moneda.Find(id);


                if (moneda != null)
                {

                    moneda.estmon = true;

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