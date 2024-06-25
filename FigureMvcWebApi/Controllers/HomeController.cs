using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FigureMvcWebApi.Controllers
{
    /// <summary>
    /// Empty controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Empty page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
