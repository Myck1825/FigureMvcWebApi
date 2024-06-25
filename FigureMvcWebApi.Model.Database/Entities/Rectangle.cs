using FigureMvcWebApi.Model.Database.Repository;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureMvcWebApi.Model.Database.Entities
{
    public class Rectangle : BaseEntity, IEntity
    {
        public Guid PointAId { get; set; }

        [ForeignKey(nameof(PointAId))]
        public virtual Point PointA { get; set; }

        public Guid PointBId { get; set; }

        [ForeignKey(nameof(PointBId))]
        public virtual Point PointB { get; set; }

        public Guid PointCId { get; set; }

        [ForeignKey(nameof(PointCId))]
        public virtual Point PointC { get; set; }

        public Guid PointDId { get; set; }

        [ForeignKey(nameof(PointDId))]
        public virtual Point PointD { get; set; }
    }
}
