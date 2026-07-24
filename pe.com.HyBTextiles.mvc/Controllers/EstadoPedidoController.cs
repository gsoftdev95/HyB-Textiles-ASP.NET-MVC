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
    public class EstadoPedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: EstadoPedido
        public ActionResult Index()
        {
            return View(db.estadopedido.ToList());
        }



        // GET: EstadoPedido/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: EstadoPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var estadopedido = db.estadopedido.Find(id);


            if (estadopedido == null)
            {
                return HttpNotFound();
            }


            return View(estadopedido);
        }



        // GET: EstadoPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var estadopedido = db.estadopedido.Find(id);


            if (estadopedido == null)
            {
                return HttpNotFound();
            }


            return View(estadopedido);
        }



        // GET: EstadoPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var estadopedido = db.estadopedido.Find(id);


            if (estadopedido == null)
            {
                return HttpNotFound();
            }


            return View(estadopedido);
        }



        // GET: EstadoPedido/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var estadopedido = db.estadopedido.Find(id);


            if (estadopedido == null)
            {
                return HttpNotFound();
            }


            return View(estadopedido);
        }





        // POST: EstadoPedido/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include = "nomest,estest")] EstadoPedido obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.estadopedido.Add(obj);
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





        // POST: EstadoPedido/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "codest,nomest,estest")] EstadoPedido obj)
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





        // POST: EstadoPedido/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var estadopedido = db.estadopedido.Find(id);


                if (estadopedido != null)
                {
                    estadopedido.estest = false;
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





        // POST: EstadoPedido/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var estadopedido = db.estadopedido.Find(id);


                if (estadopedido != null)
                {
                    estadopedido.estest = true;
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