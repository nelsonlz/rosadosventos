using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosaDosVentos.Controllers
{
    public class LaudosController : Controller
    {
        //
        // GET: /Laudos/

        public ActionResult Index()
        {
            return View("Laudos");
        }

    }
}
