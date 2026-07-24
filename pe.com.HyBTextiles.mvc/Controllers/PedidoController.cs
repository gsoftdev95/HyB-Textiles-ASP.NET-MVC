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
    public class PedidoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Pedido
        public ActionResult Index()
        {

            var lista = db.pedido
                .Include(p => p.Cliente)
                .Include(p => p.EstadoPedido)
                .Include(p => p.Usuario)
                .Include(p => p.Moneda)
                .ToList();


            return View(lista);
        }





        // GET: Pedido/Create
        public ActionResult Create()
        {

            CargarCombos();


            return View();
        }





        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pedido = db.pedido.Find(id);



            if (pedido == null)
            {
                return HttpNotFound();
            }



            CargarCombos(
                pedido.codcli,
                pedido.codest,
                pedido.codusu,
                pedido.codmon
            );



            return View(pedido);

        }





        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pedido = db.pedido
                .Include(p => p.Cliente)
                .Include(p => p.EstadoPedido)
                .Include(p => p.Usuario)
                .Include(p => p.Moneda)
                .FirstOrDefault(p => p.codped == id);



            if (pedido == null)
            {
                return HttpNotFound();
            }


            return View(pedido);

        }





        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pedido = db.pedido
                .Include(p => p.Cliente)
                .Include(p => p.EstadoPedido)
                .Include(p => p.Usuario)
                .Include(p => p.Moneda)
                .FirstOrDefault(p => p.codped == id);



            if (pedido == null)
            {
                return HttpNotFound();
            }


            return View(pedido);

        }





        // GET: Pedido/Enable

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var pedido = db.pedido.Find(id);



            if (pedido == null)
            {
                return HttpNotFound();
            }



            return View(pedido);

        }





        // POST: Pedido/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codcli,codest,codusu,codmon,totped,estped")] Pedido obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.pedido.Add(obj);

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





        // POST: Pedido/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codped,fecped,codcli,codest,codusu,codmon,totped,estped")] Pedido obj)
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
                    obj.codcli,
                    obj.codest,
                    obj.codusu,
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





        // POST: Pedido/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var pedido = db.pedido.Find(id);



                if (pedido != null)
                {

                    pedido.estped = false;

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





        // POST: Pedido/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var pedido = db.pedido.Find(id);



                if (pedido != null)
                {

                    pedido.estped = true;

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
            object cliente = null,
            object estado = null,
            object usuario = null,
            object moneda = null)
        {

            ViewBag.codcli = new SelectList(
                db.cliente,
                "codcli",
                "razonsocialcli",
                cliente
            );


            ViewBag.codest = new SelectList(
                db.estadopedido,
                "codest",
                "nomest",
                estado
            );


            ViewBag.codusu = new SelectList(
                db.usuario,
                "codusu",
                "nomusu",
                usuario
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