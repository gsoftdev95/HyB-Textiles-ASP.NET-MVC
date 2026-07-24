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
    public class ClienteController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();



        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }



        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var cliente = db.cliente.Find(id);


            if (cliente == null)
            {
                return HttpNotFound();
            }


            return View(cliente);
        }



        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var cliente = db.cliente.Find(id);


            if (cliente == null)
            {
                return HttpNotFound();
            }


            return View(cliente);
        }



        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var cliente = db.cliente.Find(id);


            if (cliente == null)
            {
                return HttpNotFound();
            }


            return View(cliente);
        }



        // GET: Cliente/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var cliente = db.cliente.Find(id);


            if (cliente == null)
            {
                return HttpNotFound();
            }


            return View(cliente);
        }





        // POST: Cliente/Create

        [HttpPost]
        public ActionResult Create(
            [Bind(Include =
            "ruccli,razonsocialcli,nomcontactocli,telcli,emacli,dircli,estcli")] Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.cliente.Add(obj);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View(obj);
            }
        }





        // POST: Cliente/Edit

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include =
            "codcli,ruccli,razonsocialcli,nomcontactocli,telcli,emacli,dircli,estcli")] Cliente obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }


                return View(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View(obj);
            }
        }





        // POST: Cliente/Delete

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var cliente = db.cliente.Find(id);


                if (cliente != null)
                {
                    cliente.estcli = false;
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





        // POST: Cliente/Enable

        [HttpPost]
        public ActionResult Enable(int id)
        {
            try
            {
                var cliente = db.cliente.Find(id);


                if (cliente != null)
                {
                    cliente.estcli = true;
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





        // Limpieza de memoria

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