using FigureMvcWebApi.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Database
{
    public interface IFigureDbContext
    {
        DbSet<Point> Points { get; set; }

        DbSet<Rectangle> Rectangles { get; set; }
    }
}
