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
    public class IngresoHiloController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: IngresoHilo
        public ActionResult Index()
        {

            var lista = db.ingresohilo
                .Include(i => i.TipoHilo)
                .Include(i => i.Almacen)
                .Include(i => i.UnidadMedida)
                .Include(i => i.CompraProveedor)
                .ToList();


            return View(lista);

        }





        // GET: IngresoHilo/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: IngresoHilo/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var ingreso = db.ingresohilo.Find(id);



            if (ingreso == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                ingreso.codthi,
                ingreso.codalm,
                ingreso.codund,
                ingreso.codcom
            );


            return View(ingreso);

        }





        // GET: IngresoHilo/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var ingreso = db.ingresohilo
                .Include(i => i.TipoHilo)
                .Include(i => i.Almacen)
                .Include(i => i.UnidadMedida)
                .Include(i => i.CompraProveedor)
                .FirstOrDefault(i => i.coding == id);



            if (ingreso == null)
            {
                return HttpNotFound();
            }


            return View(ingreso);

        }





        // GET: IngresoHilo/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var ingreso = db.ingresohilo
                .Include(i => i.TipoHilo)
                .Include(i => i.Almacen)
                .Include(i => i.UnidadMedida)
                .Include(i => i.CompraProveedor)
                .FirstOrDefault(i => i.coding == id);



            if (ingreso == null)
            {
                return HttpNotFound();
            }


            return View(ingreso);

        }





        // GET: IngresoHilo/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var ingreso = db.ingresohilo.Find(id);



            if (ingreso == null)
            {
                return HttpNotFound();
            }


            return View(ingreso);

        }





        // POST: IngresoHilo/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codthi,codalm,codund,codcom,caning,esting")] IngresoHilo obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.ingresohilo.Add(obj);

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





        // POST: IngresoHilo/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "coding,fecing,codthi,codalm,codund,codcom,caning,esting")] IngresoHilo obj)
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
                    obj.codthi,
                    obj.codalm,
                    obj.codund,
                    obj.codcom
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: IngresoHilo/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var ingreso = db.ingresohilo.Find(id);



                if (ingreso != null)
                {

                    ingreso.esting = false;

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





        // POST: IngresoHilo/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var ingreso = db.ingresohilo.Find(id);



                if (ingreso != null)
                {

                    ingreso.esting = true;

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
            object hilo = null,
            object almacen = null,
            object unidad = null,
            object compra = null)
        {


            ViewBag.codthi = new SelectList(
                db.tipohilo,
                "codthi",
                "nomthi",
                hilo
            );



            ViewBag.codalm = new SelectList(
                db.almacen,
                "codalm",
                "nomalm",
                almacen
            );



            ViewBag.codund = new SelectList(
                db.unidadmedida,
                "codund",
                "nomund",
                unidad
            );



            ViewBag.codcom = new SelectList(
                db.comprasproveedor,
                "codcom",
                "codcom",
                compra
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