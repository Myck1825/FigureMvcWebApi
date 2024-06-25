using FigureMvcWebApi.Model.Database.Entities;
using System.Data.Entity;

namespace FigureMvcWebApi.Model.Database
{
    public interface IFigureDbContext
    {
        DbSet<Point> Points { get; set; }

        DbSet<Rectangle> Rectangles { get; set; }
    }
}
