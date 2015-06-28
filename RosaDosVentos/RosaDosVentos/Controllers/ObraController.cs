using Consultas;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosaDosVentos.Controllers
{
    public class ObraController : Controller
    {
        //
        // GET: /Obra/

        public ActionResult Index()
        {
            var consultaDeObra = new ConsultaDeObras();

            var obraModel = consultaDeObra.ObterPorID(1);

            return View("Obra", obraModel);
        }

    }
}
