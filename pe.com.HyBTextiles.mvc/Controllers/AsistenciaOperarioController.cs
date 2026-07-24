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
    public class AsistenciaOperarioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: AsistenciaOperario
        public ActionResult Index()
        {
            var lista = db.asistenciaoperario
                .Include(a => a.Operario)
                .Include(a => a.Turno)
                .ToList();

            return View(lista);
        }



        // GET: AsistenciaOperario/Create
        public ActionResult Create()
        {
            CargarCombos();

            return View();
        }



        // GET: AsistenciaOperario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var asistencia = db.asistenciaoperario.Find(id);


            if (asistencia == null)
            {
                return HttpNotFound();
            }


            CargarCombos(
                asistencia.codope,
                asistencia.codtur
            );


            return View(asistencia);
        }



        // GET: AsistenciaOperario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var asistencia = db.asistenciaoperario
                .Include(a => a.Operario)
                .Include(a => a.Turno)
                .FirstOrDefault(a => a.codasi == id);


            if (asistencia == null)
            {
                return HttpNotFound();
            }


            return View(asistencia);
        }



        // GET: AsistenciaOperario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var asistencia = db.asistenciaoperario
                .Include(a => a.Operario)
                .Include(a => a.Turno)
                .FirstOrDefault(a => a.codasi == id);


            if (asistencia == null)
            {
                return HttpNotFound();
            }


            return View(asistencia);
        }



        // GET: AsistenciaOperario/Enable
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var asistencia = db.asistenciaoperario.Find(id);


            if (asistencia == null)
            {
                return HttpNotFound();
            }


            return View(asistencia);
        }





        // POST: AsistenciaOperario/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include =
            "codope,codtur,fecasi,horaingasi,horasaliasi,estasi")]
            AsistenciaOperario obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.asistenciaoperario.Add(obj);

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





        // POST: AsistenciaOperario/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include =
            "codasi,codope,codtur,fecasi,horaingasi,horasaliasi,estasi")]
            AsistenciaOperario obj)
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
                    obj.codope,
                    obj.codtur
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                return View(obj);

            }

        }





        // POST: AsistenciaOperario/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {

            try
            {

                var asistencia = db.asistenciaoperario.Find(id);


                if (asistencia != null)
                {

                    asistencia.estasi = false;

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





        // POST: AsistenciaOperario/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {

            try
            {

                var asistencia = db.asistenciaoperario.Find(id);


                if (asistencia != null)
                {

                    asistencia.estasi = true;

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
            object operario = null,
            object turno = null)
        {


            ViewBag.codope = new SelectList(
                db.operario,
                "codope",
                "nomope",
                operario
            );



            ViewBag.codtur = new SelectList(
                db.turno,
                "codtur",
                "nomtur",
                turno
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