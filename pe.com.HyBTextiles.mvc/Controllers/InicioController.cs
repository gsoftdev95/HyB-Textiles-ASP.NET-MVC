using pe.com.HyBTextiles.mvc.Models;
using pe.com.HyBTextiles.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pe.com.HyBTextiles.mvc.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        //POST: Inicio
        [HttpPost]
        public ActionResult Index(String txtUsu, String txtCla)
        {
            try
            {
                //realizamos la validacion del usuario y clave
                Usuario usuario = db.usuario.FirstOrDefault(

                    e => e.userusu == txtUsu && e.claveusu == txtCla && e.estusu == true
                    );
                if (usuario != null)
                {
                    Session["codusu"] = usuario.codusu;
                    Session["usuario"] = usuario.userusu;
                    Session["nombre"] = usuario.nomusu;
                    Session["rol"] = usuario.codrol;

                    return RedirectToAction("Index", "Menu");
                }
                ViewBag.mensaje = "Usuario o Clave incorrecta";
                return View();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return View();

            }

        }


        // GET: CerrarSesion
        public ActionResult CerrarSesion()
        {
            //elimina todas las variables almacenadas en la sesion actual
            Session.Clear();
            //destruye completamente a sesion actual
            Session.Abandon();
            return RedirectToAction("Index", "Inicio");
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