using FigureMvcWebApi.Model.Database.Entities;

namespace FigureMvcWebApi.Model.Database.Repository
{
    public class PointRepository : Repository<Point>
    {
        public PointRepository(FigureDbContext dbContext) : base(dbContext)
        {
        }
    }
}
