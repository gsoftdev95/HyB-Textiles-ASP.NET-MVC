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
    public class HistorialEstadoPedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: HistorialEstadoPedido
        public ActionResult Index()
        {

            var lista = db.historialestadopedido
                .Include(h => h.Pedido)
                .Include(h => h.EstadoPedido)
                .Include(h => h.Usuario)
                .ToList();


            return View(lista);

        }





        // GET: HistorialEstadoPedido/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: HistorialEstadoPedido/Edit/5

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var historial = db.historialestadopedido.Find(id);



            if (historial == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                historial.codped,
                historial.codest,
                historial.codusu
            );


            return View(historial);

        }





        // GET: HistorialEstadoPedido/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var historial = db.historialestadopedido
                .Include(h => h.Pedido)
                .Include(h => h.EstadoPedido)
                .Include(h => h.Usuario)
                .FirstOrDefault(h => h.codhis == id);



            if (historial == null)
            {
                return HttpNotFound();
            }


            return View(historial);

        }





        // GET: HistorialEstadoPedido/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var historial = db.historialestadopedido
                .Include(h => h.Pedido)
                .Include(h => h.EstadoPedido)
                .Include(h => h.Usuario)
                .FirstOrDefault(h => h.codhis == id);



            if (historial == null)
            {
                return HttpNotFound();
            }


            return View(historial);

        }





        // GET: HistorialEstadoPedido/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var historial = db.historialestadopedido.Find(id);



            if (historial == null)
            {
                return HttpNotFound();
            }


            return View(historial);

        }





        // POST: HistorialEstadoPedido/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codped,codest,codusu,esthis")] HistorialEstadoPedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.historialestadopedido.Add(obj);

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





        // POST: HistorialEstadoPedido/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codhis,codped,codest,codusu,fechis,esthis")] HistorialEstadoPedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.Entry(obj).State = EntityState.Modified;

                    db.SaveChanges();


                    return RedirectToAction("Index");

                }



                CargarCombos(
                    obj.codped,
                    obj.codest,
                    obj.codusu
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: HistorialEstadoPedido/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var historial = db.historialestadopedido.Find(id);



                if (historial != null)
                {

                    historial.esthis = false;

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





        // POST: HistorialEstadoPedido/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var historial = db.historialestadopedido.Find(id);



                if (historial != null)
                {

                    historial.esthis = true;

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





        private void CargarCombos(
            object pedido = null,
            object estado = null,
            object usuario = null)
        {


            ViewBag.codped = new SelectList(
                db.pedido,
                "codped",
                "codped",
                pedido
            );



            ViewBag.codest = new SelectList(
                db.estadopedido,
                "codest",
                "nomest",
                estado
            );



            ViewBag.codusu = new SelectList(
                db.usuario,
                "codusu",
                "nomusu",
                usuario
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