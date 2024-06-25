using System.ComponentModel.DataAnnotations;
using FigureMvcWebApi.Model.Attributes;
using FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models;


namespace FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Requests
{
    public class SegmentRequest : BaseModelForListRequest
    {
        /// <summary>
        /// First segment's point coordinate
        /// </summary>
        [Required]
        [ValidateObject]
        public PointModel A { get; set; }

        /// <summary>
        /// Second segment's point coordinate
        /// </summary>
        [Required]
        [ValidateObject]
        public PointModel B { get; set; }
    }
}