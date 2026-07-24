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
    public class UsuarioController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Usuario
        public ActionResult Index()
        {
            var lista = db.usuario
                .Include(u => u.Rol)
                .ToList();

            return View(lista);
        }



        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol");

            return View();
        }





        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var usuario = db.usuario.Find(id);


            if (usuario == null)
            {
                return HttpNotFound();
            }


            ViewBag.codrol = new SelectList(
                db.rol,
                "codrol",
                "nomrol",
                usuario.codrol
            );


            return View(usuario);
        }





        // GET: Usuario/Delete/5

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var usuario = db.usuario
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.codusu == id);


            if (usuario == null)
            {
                return HttpNotFound();
            }


            return View(usuario);
        }





        // GET: Usuario/Details/5

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var usuario = db.usuario
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.codusu == id);


            if (usuario == null)
            {
                return HttpNotFound();
            }


            return View(usuario);
        }





        // GET: Usuario/Enable/5

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var usuario = db.usuario.Find(id);


            if (usuario == null)
            {
                return HttpNotFound();
            }


            return View(usuario);
        }





        // POST: Usuario/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "nomusu,userusu,claveusu,codrol,estusu")] Usuario obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.usuario.Add(obj);

                    db.SaveChanges();

                    return RedirectToAction("Index");

                }


                ViewBag.codrol = new SelectList(
                    db.rol,
                    "codrol",
                    "nomrol",
                    obj.codrol
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                return View(obj);

            }

        }





        // POST: Usuario/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codusu,nomusu,userusu,claveusu,codrol,estusu")] Usuario obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.Entry(obj).State = EntityState.Modified;

                    db.SaveChanges();


                    return RedirectToAction("Index");

                }


                ViewBag.codrol = new SelectList(
                    db.rol,
                    "codrol",
                    "nomrol",
                    obj.codrol
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                return View(obj);

            }

        }





        // POST: Usuario/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var usuario = db.usuario.Find(id);


                if (usuario != null)
                {

                    usuario.estusu = false;

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





        // POST: Usuario/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var usuario = db.usuario.Find(id);


                if (usuario != null)
                {

                    usuario.estusu = true;

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