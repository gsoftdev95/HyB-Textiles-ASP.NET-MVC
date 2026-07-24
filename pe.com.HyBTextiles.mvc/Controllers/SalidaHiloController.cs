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
    public class SalidaHiloController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalidaHilo
        public ActionResult Index()
        {

            var lista = db.salidahilo
                .Include(s => s.Produccion)
                .Include(s => s.TipoHilo)
                .Include(s => s.UnidadMedida)
                .ToList();


            return View(lista);

        }





        // GET: SalidaHilo/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: SalidaHilo/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var salida = db.salidahilo.Find(id);



            if (salida == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                salida.codpro,
                salida.codthi,
                salida.codund
            );


            return View(salida);

        }





        // GET: SalidaHilo/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var salida = db.salidahilo
                .Include(s => s.Produccion)
                .Include(s => s.TipoHilo)
                .Include(s => s.UnidadMedida)
                .FirstOrDefault(s => s.codsal == id);



            if (salida == null)
            {
                return HttpNotFound();
            }


            return View(salida);

        }





        // GET: SalidaHilo/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var salida = db.salidahilo
                .Include(s => s.Produccion)
                .Include(s => s.TipoHilo)
                .Include(s => s.UnidadMedida)
                .FirstOrDefault(s => s.codsal == id);



            if (salida == null)
            {
                return HttpNotFound();
            }


            return View(salida);

        }





        // GET: SalidaHilo/Enable
        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var salida = db.salidahilo.Find(id);



            if (salida == null)
            {
                return HttpNotFound();
            }


            return View(salida);

        }





        // POST Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include =
            "codpro,codthi,codund,cansal,estsal")]
            SalidaHilo obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.salidahilo.Add(obj);

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





        // POST Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include =
            "codsal,fecsal,codpro,codthi,codund,cansal,estsal")]
            SalidaHilo obj)
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
                    obj.codpro,
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





        // POST Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {

                var salida = db.salidahilo.Find(id);



                if (salida != null)
                {

                    salida.estsal = false;

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

                var salida = db.salidahilo.Find(id);



                if (salida != null)
                {

                    salida.estsal = true;

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
            object produccion = null,
            object tipohilo = null,
            object unidad = null)
        {


            ViewBag.codpro = new SelectList(
                db.produccion,
                "codpro",
                "codpro",
                produccion
            );



            ViewBag.codthi = new SelectList(
                db.tipohilo,
                "codthi",
                "nomthi",
                tipohilo
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