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
    public class DocumentoPedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: DocumentoPedido
        public ActionResult Index()
        {

            var lista = db.documentopedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoDocumento)
                .ToList();


            return View(lista);

        }





        // GET: DocumentoPedido/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: DocumentoPedido/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var documento = db.documentopedido.Find(id);



            if (documento == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                documento.codped,
                documento.codtdo
            );


            return View(documento);

        }





        // GET: DocumentoPedido/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var documento = db.documentopedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoDocumento)
                .FirstOrDefault(d => d.coddoc == id);



            if (documento == null)
            {
                return HttpNotFound();
            }


            return View(documento);

        }





        // GET: DocumentoPedido/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var documento = db.documentopedido
                .Include(d => d.Pedido)
                .Include(d => d.TipoDocumento)
                .FirstOrDefault(d => d.coddoc == id);



            if (documento == null)
            {
                return HttpNotFound();
            }


            return View(documento);

        }





        // GET: DocumentoPedido/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var documento = db.documentopedido.Find(id);



            if (documento == null)
            {
                return HttpNotFound();
            }


            return View(documento);

        }





        // POST: DocumentoPedido/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codped,codtdo,numdoc,estdoc")] DocumentoPedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.documentopedido.Add(obj);

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





        // POST: DocumentoPedido/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "coddoc,codped,codtdo,numdoc,fecdoc,estdoc")] DocumentoPedido obj)
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
                    obj.codtdo
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);


                return View(obj);

            }

        }





        // POST: DocumentoPedido/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var documento = db.documentopedido.Find(id);



                if (documento != null)
                {

                    documento.estdoc = false;

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





        // POST: DocumentoPedido/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var documento = db.documentopedido.Find(id);



                if (documento != null)
                {

                    documento.estdoc = true;

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
            object tipoDocumento = null)
        {


            ViewBag.codped = new SelectList(
                db.pedido,
                "codped",
                "codped",
                pedido
            );



            ViewBag.codtdo = new SelectList(
                db.tipodocumento,
                "codtdo",
                "nomtdo",
                tipoDocumento
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