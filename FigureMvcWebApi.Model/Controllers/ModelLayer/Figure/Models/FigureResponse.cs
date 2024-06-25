using System.Collections.Generic;

namespace FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Models
{
    public class FigureResponse
    {
        public int TotalCount { get; set; } = default;

        public IEnumerable<RectangleModel> RectangleList { get; set; } = new List<RectangleModel>();
    }
}
