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
    public class CobranzaPedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: CobranzaPedido
        public ActionResult Index()
        {

            var lista = db.cobranzapedido
                .Include(c => c.Pedido)
                .Include(c => c.Moneda)
                .ToList();


            return View(lista);

        }





        // GET: CobranzaPedido/Create
        public ActionResult Create()
        {

            CargarCombos();

            return View();

        }





        // GET: CobranzaPedido/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var cobranza = db.cobranzapedido.Find(id);



            if (cobranza == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                cobranza.codped,
                cobranza.codmon
            );


            return View(cobranza);

        }





        // GET: CobranzaPedido/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var cobranza = db.cobranzapedido
                .Include(c => c.Pedido)
                .Include(c => c.Moneda)
                .FirstOrDefault(c => c.codcob == id);



            if (cobranza == null)
            {
                return HttpNotFound();
            }


            return View(cobranza);

        }





        // GET: CobranzaPedido/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var cobranza = db.cobranzapedido
                .Include(c => c.Pedido)
                .Include(c => c.Moneda)
                .FirstOrDefault(c => c.codcob == id);



            if (cobranza == null)
            {
                return HttpNotFound();
            }


            return View(cobranza);

        }





        // GET: CobranzaPedido/Enable
        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var cobranza = db.cobranzapedido.Find(id);



            if (cobranza == null)
            {
                return HttpNotFound();
            }


            return View(cobranza);

        }





        // POST: CobranzaPedido/Create
        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codped,codmon,montocob,estcob")] CobranzaPedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.cobranzapedido.Add(obj);

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





        // POST: CobranzaPedido/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codcob,feccob,codped,codmon,montocob,estcob")] CobranzaPedido obj)
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





        // POST: CobranzaPedido/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var cobranza = db.cobranzapedido.Find(id);



                if (cobranza != null)
                {

                    cobranza.estcob = false;

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





        // POST: CobranzaPedido/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var cobranza = db.cobranzapedido.Find(id);



                if (cobranza != null)
                {

                    cobranza.estcob = true;

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
            object moneda = null)
        {


            ViewBag.codped = new SelectList(
                db.pedido,
                "codped",
                "codped",
                pedido
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