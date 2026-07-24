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
    public class ProduccionController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Produccion
        public ActionResult Index()
        {

            var lista = db.produccion
                .Include(p => p.Maquina)
                .Include(p => p.Operario)
                .Include(p => p.TipoTejido)
                .Include(p => p.Pedido)
                .ToList();


            return View(lista);

        }





        // GET: Produccion/Create

        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: Produccion/Edit/5

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var produccion = db.produccion.Find(id);



            if (produccion == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                produccion.codmaq,
                produccion.codope,
                produccion.codtte,
                produccion.codped
            );


            return View(produccion);

        }





        // GET: Produccion/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var produccion = db.produccion
                .Include(p => p.Maquina)
                .Include(p => p.Operario)
                .Include(p => p.TipoTejido)
                .Include(p => p.Pedido)
                .FirstOrDefault(p => p.codpro == id);



            if (produccion == null)
            {
                return HttpNotFound();
            }


            return View(produccion);

        }





        // GET: Produccion/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var produccion = db.produccion
                .Include(p => p.Maquina)
                .Include(p => p.Operario)
                .Include(p => p.TipoTejido)
                .Include(p => p.Pedido)
                .FirstOrDefault(p => p.codpro == id);



            if (produccion == null)
            {
                return HttpNotFound();
            }


            return View(produccion);

        }





        // GET: Produccion/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var produccion = db.produccion.Find(id);



            if (produccion == null)
            {
                return HttpNotFound();
            }


            return View(produccion);

        }





        // POST: Produccion/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codmaq,codope,codtte,codped,canpro,estpro")] Produccion obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.produccion.Add(obj);

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





        // POST: Produccion/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codpro,fecpro,codmaq,codope,codtte,codped,canpro,estpro")] Produccion obj)
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
                    obj.codmaq,
                    obj.codope,
                    obj.codtte,
                    obj.codped
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: Produccion/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var produccion = db.produccion.Find(id);



                if (produccion != null)
                {

                    produccion.estpro = false;

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





        // POST: Produccion/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var produccion = db.produccion.Find(id);



                if (produccion != null)
                {

                    produccion.estpro = true;

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
            object maquina = null,
            object operario = null,
            object tejido = null,
            object pedido = null)
        {


            ViewBag.codmaq = new SelectList(
                db.maquina,
                "codmaq",
                "nommaq",
                maquina
            );



            ViewBag.codope = new SelectList(
                db.operario,
                "codope",
                "nomope",
                operario
            );



            ViewBag.codtte = new SelectList(
                db.tipotejido,
                "codtte",
                "nomtte",
                tejido
            );



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