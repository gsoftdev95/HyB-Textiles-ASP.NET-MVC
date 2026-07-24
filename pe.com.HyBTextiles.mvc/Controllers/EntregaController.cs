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
    public class EntregaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Entrega
        public ActionResult Index()
        {

            var lista = db.entrega
                .Include(e => e.Pedido)
                .ToList();


            return View(lista);

        }





        // GET: Entrega/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: Entrega/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var entrega = db.entrega.Find(id);



            if (entrega == null)
            {
                return HttpNotFound();
            }



            CargarCombos(entrega.codped);


            return View(entrega);

        }





        // GET: Entrega/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var entrega = db.entrega
                .Include(e => e.Pedido)
                .FirstOrDefault(e => e.codent == id);



            if (entrega == null)
            {
                return HttpNotFound();
            }


            return View(entrega);

        }





        // GET: Entrega/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var entrega = db.entrega
                .Include(e => e.Pedido)
                .FirstOrDefault(e => e.codent == id);



            if (entrega == null)
            {
                return HttpNotFound();
            }


            return View(entrega);

        }





        // GET: Entrega/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var entrega = db.entrega.Find(id);



            if (entrega == null)
            {
                return HttpNotFound();
            }


            return View(entrega);

        }





        // POST: Entrega/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codped,respent,estent")] Entrega obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.entrega.Add(obj);

                    db.SaveChanges();


                    return RedirectToAction("Index");

                }



                CargarCombos();


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                CargarCombos();


                return View(obj);

            }

        }





        // POST: Entrega/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codent,fecent,codped,respent,estent")] Entrega obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.Entry(obj).State = EntityState.Modified;

                    db.SaveChanges();


                    return RedirectToAction("Index");

                }



                CargarCombos(obj.codped);


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: Entrega/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var entrega = db.entrega.Find(id);



                if (entrega != null)
                {

                    entrega.estent = false;

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





        // POST: Entrega/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var entrega = db.entrega.Find(id);



                if (entrega != null)
                {

                    entrega.estent = true;

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





        private void CargarCombos(object pedido = null)
        {


            ViewBag.codped = new SelectList(
                db.pedido,
                "codped",
                "codped",
                pedido
            );

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