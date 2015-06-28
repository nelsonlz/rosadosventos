using RosaDosVentos.Models;
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
            var obraModel = new ObraModel();

            for (int i = 0; i < 15; i++)
			{
                obraModel.Eventos.Add(new EventosModel { Descricao = string.Format("Teste {0}", i), Titulo = string.Format("Evento {0}", i), DataDoOcorrido = DateTime.Now.AddDays(i) });
			}


            return View("Obra", obraModel);
        }

    }
}
