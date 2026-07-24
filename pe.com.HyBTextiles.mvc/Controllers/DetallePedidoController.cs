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
    public class DetallePedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: DetallePedido
        public ActionResult Index()
        {

            var lista = db.detallepedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoTejido)
                .Include(d => d.UnidadMedida)
                .ToList();


            return View(lista);

        }





        // GET: DetallePedido/Create
        public ActionResult Create()
        {

            CargarCombos();


            return View();

        }





        // GET: DetallePedido/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var detalle = db.detallepedido.Find(id);



            if (detalle == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                detalle.codped,
                detalle.codtte,
                detalle.codund
            );


            return View(detalle);

        }





        // GET: DetallePedido/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var detalle = db.detallepedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoTejido)
                .Include(d => d.UnidadMedida)
                .FirstOrDefault(d => d.coddet == id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // GET: DetallePedido/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var detalle = db.detallepedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoTejido)
                .Include(d => d.UnidadMedida)
                .FirstOrDefault(d => d.coddet == id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // GET: DetallePedido/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var detalle = db.detallepedido.Find(id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // POST: DetallePedido/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codped,codtte,codund,candet,preciodet,estdet")] DetallePedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.detallepedido.Add(obj);

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





        // POST: DetallePedido/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "coddet,codped,codtte,codund,candet,preciodet,estdet")] DetallePedido obj)
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
                    obj.codtte,
                    obj.codund
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: DetallePedido/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var detalle = db.detallepedido.Find(id);



                if (detalle != null)
                {

                    detalle.estdet = false;

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





        // POST: DetallePedido/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var detalle = db.detallepedido.Find(id);



                if (detalle != null)
                {

                    detalle.estdet = true;

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
            object tejido = null,
            object unidad = null)
        {


            ViewBag.codped = new SelectList(
                db.pedido,
                "codped",
                "codped",
                pedido
            );



            ViewBag.codtte = new SelectList(
                db.tipotejido,
                "codtte",
                "nomtte",
                tejido
            );



            ViewBag.codund = new SelectList(
                db.unidadmedida,
                "codund",
                "nomund",
                unidad
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