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
    public class RolPermisoController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: RolPermiso
        public ActionResult Index()
        {

            var lista = db.rolpermiso
                .Include(r => r.Rol)
                .Include(r => r.Permiso)
                .ToList();


            return View(lista);
        }





        // GET: RolPermiso/Create
        public ActionResult Create()
        {

            ViewBag.codrol = new SelectList(
                db.rol,
                "codrol",
                "nomrol"
            );


            ViewBag.codper = new SelectList(
                db.permiso,
                "codper",
                "nomper"
            );


            return View();
        }





        // GET: RolPermiso/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var rolpermiso = db.rolpermiso.Find(id);


            if (rolpermiso == null)
            {
                return HttpNotFound();
            }



            ViewBag.codrol = new SelectList(
                db.rol,
                "codrol",
                "nomrol",
                rolpermiso.codrol
            );


            ViewBag.codper = new SelectList(
                db.permiso,
                "codper",
                "nomper",
                rolpermiso.codper
            );


            return View(rolpermiso);
        }





        // GET: RolPermiso/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var rolpermiso = db.rolpermiso
                .Include(r => r.Rol)
                .Include(r => r.Permiso)
                .FirstOrDefault(r => r.codrolper == id);



            if (rolpermiso == null)
            {
                return HttpNotFound();
            }


            return View(rolpermiso);

        }





        // GET: RolPermiso/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }



            var rolpermiso = db.rolpermiso
                .Include(r => r.Rol)
                .Include(r => r.Permiso)
                .FirstOrDefault(r => r.codrolper == id);



            if (rolpermiso == null)
            {
                return HttpNotFound();
            }


            return View(rolpermiso);

        }





        // GET: RolPermiso/Enable/5

        public ActionResult Enable(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var rolpermiso = db.rolpermiso.Find(id);


            if (rolpermiso == null)
            {
                return HttpNotFound();
            }


            return View(rolpermiso);

        }





        // POST: RolPermiso/Create

        [HttpPost]

        public ActionResult Create(
            [Bind(Include =
            "codrol,codper,estrolper")] RolPermiso obj)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    db.rolpermiso.Add(obj);

                    db.SaveChanges();


                    return RedirectToAction("Index");

                }


                ViewBag.codrol = new SelectList(
                    db.rol,
                    "codrol",
                    "nomrol",
                    obj.codrol
                );


                ViewBag.codper = new SelectList(
                    db.permiso,
                    "codper",
                    "nomper",
                    obj.codper
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                return View(obj);

            }

        }





        // POST: RolPermiso/Edit

        [HttpPost]

        public ActionResult Edit(
            [Bind(Include =
            "codrolper,codrol,codper,estrolper")] RolPermiso obj)
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


                ViewBag.codper = new SelectList(
                    db.permiso,
                    "codper",
                    "nomper",
                    obj.codper
                );


                return View(obj);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                return View(obj);

            }

        }





        // POST: RolPermiso/Delete

        [HttpPost]

        public ActionResult Delete(int id)
        {

            try
            {

                var rolpermiso = db.rolpermiso.Find(id);


                if (rolpermiso != null)
                {

                    rolpermiso.estrolper = false;

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





        // POST: RolPermiso/Enable

        [HttpPost]

        public ActionResult Enable(int id)
        {

            try
            {

                var rolpermiso = db.rolpermiso.Find(id);



                if (rolpermiso != null)
                {

                    rolpermiso.estrolper = true;

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