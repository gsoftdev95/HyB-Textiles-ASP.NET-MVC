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
    public class PagoProveedorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: PagoProveedor
        public ActionResult Index()
        {

            var lista = db.pagoproveedor
                .Include(p => p.CompraProveedor)
                .Include(p => p.Moneda)
                .ToList();


            return View(lista);

        }





        // GET: PagoProveedor/Create

        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: PagoProveedor/Edit/5

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pago = db.pagoproveedor.Find(id);



            if (pago == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                pago.codcom,
                pago.codmon
            );


            return View(pago);

        }





        // GET: PagoProveedor/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pago = db.pagoproveedor
                .Include(p => p.CompraProveedor)
                .Include(p => p.Moneda)
                .FirstOrDefault(p => p.codpgp == id);



            if (pago == null)
            {
                return HttpNotFound();
            }


            return View(pago);

        }





        // GET: PagoProveedor/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pago = db.pagoproveedor
                .Include(p => p.CompraProveedor)
                .Include(p => p.Moneda)
                .FirstOrDefault(p => p.codpgp == id);



            if (pago == null)
            {
                return HttpNotFound();
            }


            return View(pago);

        }





        // GET: PagoProveedor/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pago = db.pagoproveedor.Find(id);



            if (pago == null)
            {
                return HttpNotFound();
            }


            return View(pago);

        }





        // POST: PagoProveedor/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codcom,codmon,montopgp,estpgp")] PagoProveedor obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.pagoproveedor.Add(obj);

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





        // POST: PagoProveedor/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codpgp,fecpgp,codcom,codmon,montopgp,estpgp")] PagoProveedor obj)
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
                    obj.codmon
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: PagoProveedor/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var pago = db.pagoproveedor.Find(id);



                if (pago != null)
                {

                    pago.estpgp = false;

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





        // POST: PagoProveedor/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var pago = db.pagoproveedor.Find(id);



                if (pago != null)
                {

                    pago.estpgp = true;

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
            object moneda = null)
        {


            ViewBag.codcom = new SelectList(
                db.comprasproveedor,
                "codcom",
                "codcom",
                compra
            );



            ViewBag.codmon = new SelectList(
                db.moneda,
                "codmon",
                "nommon",
                moneda
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