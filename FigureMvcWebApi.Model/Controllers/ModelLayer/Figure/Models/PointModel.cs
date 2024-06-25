using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models
{
    /// <summary>
    /// Coordinate for point
    /// </summary>
    public class PointModel
    {
        [Required]
        public int X { get; set; }

        [Required]
        public int Y { get; set; }
    }
}
