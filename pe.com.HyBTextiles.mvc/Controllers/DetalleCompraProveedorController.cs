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
    public class DetalleCompraProveedorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: DetalleCompraProveedor
        public ActionResult Index()
        {
            var lista = db.detallecompraproveedor
                .Include(d => d.CompraProveedor)
                .Include(d => d.TipoHilo)
                .Include(d => d.UnidadMedida)
                .ToList();


            return View(lista);
        }





        // GET: DetalleCompraProveedor/Create
        public ActionResult Create()
        {
            CargarCombos();

            return View();
        }





        // GET: DetalleCompraProveedor/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var detalle = db.detallecompraproveedor.Find(id);



            if (detalle == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                detalle.codcom,
                detalle.codthi,
                detalle.codund
            );


            return View(detalle);

        }





        // GET: DetalleCompraProveedor/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var detalle = db.detallecompraproveedor
                .Include(d => d.CompraProveedor)
                .Include(d => d.TipoHilo)
                .Include(d => d.UnidadMedida)
                .FirstOrDefault(d => d.coddco == id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // GET: DetalleCompraProveedor/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var detalle = db.detallecompraproveedor
                .Include(d => d.CompraProveedor)
                .Include(d => d.TipoHilo)
                .Include(d => d.UnidadMedida)
                .FirstOrDefault(d => d.coddco == id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // GET: DetalleCompraProveedor/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var detalle = db.detallecompraproveedor.Find(id);



            if (detalle == null)
            {
                return HttpNotFound();
            }


            return View(detalle);

        }





        // POST: DetalleCompraProveedor/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codcom,codthi,codund,candco,preciodco,estdco")] DetalleCompraProveedor obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.detallecompraproveedor.Add(obj);

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





        // POST: DetalleCompraProveedor/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "coddco,codcom,codthi,codund,candco,preciodco,estdco")] DetalleCompraProveedor obj)
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
                    obj.codcom,
                    obj.codthi,
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





        // POST: DetalleCompraProveedor/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var detalle = db.detallecompraproveedor.Find(id);



                if (detalle != null)
                {

                    detalle.estdco = false;

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





        // POST: DetalleCompraProveedor/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var detalle = db.detallecompraproveedor.Find(id);



                if (detalle != null)
                {

                    detalle.estdco = true;

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
            object compra = null,
            object hilo = null,
            object unidad = null)
        {


            ViewBag.codcom = new SelectList(
                db.comprasproveedor,
                "codcom",
                "codcom",
                compra
            );



            ViewBag.codthi = new SelectList(
                db.tipohilo,
                "codthi",
                "nomthi",
                hilo
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