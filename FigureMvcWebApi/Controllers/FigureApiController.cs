using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests;
using FigureMvcWebApi.Model.Controllers.Services;
using FigureMvcWebApi.Model.Database.HeadLog;
using log4net;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace FigureMvcWebApi.Controllers
{
    /// <summary>
    /// Figure api controller
    /// </summary>
    public class FigureApiController : ApiController
    {
        private IRectangleService _rectangleService = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FigureMvcWebApi.Controllers.FigureApiController"/> class.
        /// </summary>
        /// <param name="rectangleService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FigureApiController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService ?? throw new ArgumentNullException(nameof(rectangleService));
        }

        /// <summary>
        /// Get rectangle list wich interset segment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [Route("api/rectangles")]
        [HttpGet]
        public async Task<IHttpActionResult> GetListAsync([FromUri]SegmentRequest request)
        {
            if (request == null)
            { throw new ArgumentNullException(nameof(request)); }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _rectangleService.GetRectangleByIntersectSegment(request);
            return Ok(result);
        }
    }
}
