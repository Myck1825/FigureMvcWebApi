using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Model.Controllers.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FigureMvcWebApi.Controllers
{
    /// <summary>
    /// Figure controller
    /// </summary>
    public class FigureController : Controller
    {
        private IRectangleService _rectangleService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FigureMvcWebApi.Controllers.FigureController"/> class.
        /// </summary>
        /// <param name="rectangleService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FigureController(IRectangleService rectangleService) 
        {
            _rectangleService = rectangleService ?? throw new ArgumentNullException(nameof(rectangleService));
        }

        /// <summary>
        /// Rectange view
        /// </summary>
        /// <returns></returns>
        public ActionResult Rectangles()
        {
            ViewBag.Title = "Rectangles";

            return View();
        }

        /// <summary>
        /// Get rectangles wich input segment intersect
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Route("mvc/rectangles")]
        public async Task<JsonResult> GetRectanglesAsync(SegmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            if (request == null)
            { throw new ArgumentNullException(nameof(request));}
            
            var result = await _rectangleService.GetRectangleByIntersectSegment(request); 
            return Json(result.Result, JsonRequestBehavior.AllowGet);
        }
    }
}