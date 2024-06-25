using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Controllers.ModelLayer.Figure.Database
{
    public class RectangleResultModel
    {
        public int CountRow { get; set; }

        public Guid Id { get; set; }

        public Guid PointAId { get; set; }

        public int PointA_X { get; set; }

        public int PointA_Y { get; set; }

        public Guid PointBId { get; set; }

        public int PointB_X { get; set; }

        public int PointB_Y { get; set; }

        public Guid PointDId { get; set; }

        public int PointD_X { get; set; }

        public int PointD_Y { get; set; }

        public Guid PointCId { get; set; }

        public int PointC_X { get; set; }

        public int PointC_Y { get; set; }
    }
}
