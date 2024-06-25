using FigureMvcWebApi.Model.Database.Repository;
using System.Collections.Generic;

namespace FigureMvcWebApi.Model.Database.Entities
{
    public class Point : BaseEntity, IEntity
    {
        public int X { get; set; }

        public int Y { get; set; }

        public virtual ICollection<Rectangle> RectanglesForPointA { get; set; } = new List<Rectangle>();
        public virtual ICollection<Rectangle> RectanglesForPointB { get; set; } = new List<Rectangle>();
        public virtual ICollection<Rectangle> RectanglesForPointC { get; set; } = new List<Rectangle>();
        public virtual ICollection<Rectangle> RectanglesForPointD { get; set; } = new List<Rectangle>();

    }
}
