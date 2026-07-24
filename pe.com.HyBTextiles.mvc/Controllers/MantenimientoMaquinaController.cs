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
    public class MantenimientoMaquinaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();


        // GET: MantenimientoMaquina
        public ActionResult Index()
        {
            var lista = db.mantenimientomaquina
                .Include(m => m.Maquina)
                .ToList();

            return View(lista);
        }



        // GET: MantenimientoMaquina/Create
        public ActionResult Create()
        {
            CargarCombos();

            return View();
        }



        // GET: MantenimientoMaquina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var mantenimiento = db.mantenimientomaquina.Find(id);


            if (mantenimiento == null)
            {
                return HttpNotFound();
            }


            CargarCombos(mantenimiento.codmaq);


            return View(mantenimiento);
        }



        // GET: MantenimientoMaquina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var mantenimiento = db.mantenimientomaquina
                .Include(m => m.Maquina)
                .FirstOrDefault(m => m.codmnt == id);



            if (mantenimiento == null)
            {
                return HttpNotFound();
            }


            return View(mantenimiento);
        }



        // GET: MantenimientoMaquina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var mantenimiento = db.mantenimientomaquina
                .Include(m => m.Maquina)
                .FirstOrDefault(m => m.codmnt == id);



            if (mantenimiento == null)
            {
                return HttpNotFound();
            }


            return View(mantenimiento);
        }



        // GET: MantenimientoMaquina/Enable
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var mantenimiento = db.mantenimientomaquina.Find(id);


            if (mantenimiento == null)
            {
                return HttpNotFound();
            }


            return View(mantenimiento);
        }





        // POST Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include =
            "codmaq,descmnt,costmnt,estmnt")]
            MantenimientoMaquina obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.mantenimientomaquina.Add(obj);

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
            "codmnt,codmaq,fecmnt,descmnt,costmnt,estmnt")]
            MantenimientoMaquina obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }


                CargarCombos(obj.codmaq);

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

                var mantenimiento = db.mantenimientomaquina.Find(id);


                if (mantenimiento != null)
                {
                    mantenimiento.estmnt = false;

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

                var mantenimiento = db.mantenimientomaquina.Find(id);


                if (mantenimiento != null)
                {
                    mantenimiento.estmnt = true;

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





        private void CargarCombos(object maquina = null)
        {

            ViewBag.codmaq = new SelectList(
                db.maquina,
                "codmaq",
                "nommaq",
                maquina
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