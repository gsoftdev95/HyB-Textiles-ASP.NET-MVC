using pe.com.HyBTextiles.mvc.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pe.com.HyBTextiles.mvc.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtUsu, string txtCla)
        {
            var usuario = db.usuario
                .FirstOrDefault(u => u.userusu == txtUsu
                                  && u.claveusu == txtCla
                                  && u.estusu);
            if (usuario != null)
            {
                Session["usuario"] = usuario.nomusu;
                Session["codusu"] = usuario.codusu;
                Session["codrol"] = usuario.codrol;
                return RedirectToAction("Index", "Menu");
            }
            ViewBag.error = "Usuario o clave incorrectos";
            return View();
        }
    }
}