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
    public class CompraProveedorController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: CompraProveedor
        public ActionResult Index()
        {
            var lista = db.comprasproveedor
                .Include(c => c.Proveedor)
                .Include(c => c.Moneda)
                .Include(c => c.Usuario)
                .ToList();


            return View(lista);
        }





        // GET: CompraProveedor/Create
        public ActionResult Create()
        {
            CargarCombos();

            return View();
        }





        // GET: CompraProveedor/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var compra = db.comprasproveedor.Find(id);



            if (compra == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                compra.codprv,
                compra.codmon,
                compra.codusu
            );


            return View(compra);

        }





        // GET: CompraProveedor/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var compra = db.comprasproveedor
                .Include(c => c.Proveedor)
                .Include(c => c.Moneda)
                .Include(c => c.Usuario)
                .FirstOrDefault(c => c.codcom == id);



            if (compra == null)
            {
                return HttpNotFound();
            }


            return View(compra);

        }





        // GET: CompraProveedor/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var compra = db.comprasproveedor
                .Include(c => c.Proveedor)
                .Include(c => c.Moneda)
                .Include(c => c.Usuario)
                .FirstOrDefault(c => c.codcom == id);



            if (compra == null)
            {
                return HttpNotFound();
            }


            return View(compra);

        }





        // GET: CompraProveedor/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var compra = db.comprasproveedor.Find(id);



            if (compra == null)
            {
                return HttpNotFound();
            }


            return View(compra);

        }





        // POST: CompraProveedor/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codprv,codmon,codusu,totcom,estcom")] CompraProveedor obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.comprasproveedor.Add(obj);

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





        // POST: CompraProveedor/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codcom,feccom,codprv,codmon,codusu,totcom,estcom")] CompraProveedor obj)
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
                    obj.codprv,
                    obj.codmon,
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





        // POST: CompraProveedor/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var compra = db.comprasproveedor.Find(id);



                if (compra != null)
                {

                    compra.estcom = false;

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





        // POST: CompraProveedor/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var compra = db.comprasproveedor.Find(id);



                if (compra != null)
                {

                    compra.estcom = true;

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
            object proveedor = null,
            object moneda = null,
            object usuario = null)
        {


            ViewBag.codprv = new SelectList(
                db.proveedor,
                "codprv",
                "razonsocialprv",
                proveedor
            );



            ViewBag.codmon = new SelectList(
                db.moneda,
                "codmon",
                "nommon",
                moneda
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