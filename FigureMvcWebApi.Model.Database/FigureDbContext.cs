using FigureMvcWebApi.Model.Database.Entities;
using System.Data.Entity;

namespace FigureMvcWebApi.Model.Database
{
    public class FigureDbContext : DbContext, IFigureDbContext
    {
        public FigureDbContext() : base()
        {

        }
        public DbSet<Point> Points { get; set; }

        public DbSet<Rectangle> Rectangles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Point>()
                .ToTable("Points")
                .HasIndex(p => new { p.X, p.Y })
                .IsUnique();

            modelBuilder.Entity<Rectangle>().ToTable("Rectangles");

            modelBuilder.Entity<Rectangle>()
                .HasRequired(x => x.PointA)
                .WithMany(x => x.RectanglesForPointA)
                .HasForeignKey(x => x.PointAId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rectangle>()
                .HasRequired(x => x.PointB)
                .WithMany(x => x.RectanglesForPointB)
                .HasForeignKey(x => x.PointBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rectangle>()
                .HasRequired(x => x.PointC)
                .WithMany(x => x.RectanglesForPointC)
                .HasForeignKey(x => x.PointCId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rectangle>()
                .HasRequired(x => x.PointD)
                .WithMany(x => x.RectanglesForPointD)
                .HasForeignKey(x => x.PointDId)
                .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove();
            base.OnModelCreating(modelBuilder);
        }
    }
}
