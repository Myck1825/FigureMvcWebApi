using System;

namespace FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models
{
    public class RectangleModel
    {
        public Guid Id { get; set; }

        public PointModel PointA { get; set; }

        public PointModel PointB { get; set; }

        public PointModel PointC { get; set; }

        public PointModel PointD { get; set; }
    }
}
