namespace FigureMvcWebApi.Model.Database.Migrations
{
    using FigureMvcWebApi.Model.Database.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FigureMvcWebApi.Model.Database.FigureDbContext>
    {
        private readonly int minValue = -10000;
        private readonly int maxValue = 10000;
        private readonly Random random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //  This method will be called after migrating to the latest version.
        protected override void Seed(FigureMvcWebApi.Model.Database.FigureDbContext dbContext)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!dbContext.Points.Any() && !dbContext.Rectangles.Any())
                    {

                        List<Point> pointList = new List<Point>();
                        List<Rectangle> rectangleList = new List<Rectangle>();
                        while (rectangleList.Count != 10000)
                        {

                            var pointA = new Point
                            {
                                Id = Guid.NewGuid(),
                                X = random.Next(minValue, maxValue),
                                Y = random.Next(minValue, maxValue)
                            };
                            pointA = AddIfNotExistPointToList(pointA, pointList);

                            var pointB = new Point
                            {
                                Id = Guid.NewGuid(),
                                X = random.Next(minValue, maxValue),
                                Y = random.Next(minValue, maxValue)
                            };
                            pointB = AddIfNotExistPointToList(pointB, pointList);

                            var pointC = new Point
                            {
                                Id = Guid.NewGuid(),
                                X = random.Next(minValue, maxValue),
                                Y = random.Next(minValue, maxValue)
                            };
                            pointC = AddIfNotExistPointToList(pointC, pointList);

                            var pointD = new Point
                            {
                                Id = Guid.NewGuid(),
                                X = random.Next(minValue, maxValue),
                                Y = random.Next(minValue, maxValue)
                            };
                            pointD = AddIfNotExistPointToList(pointD, pointList);

                            var rectangle = new Rectangle
                            {
                                PointA = pointA,
                                PointB = pointB,
                                PointC = pointC,
                                PointD = pointD
                            };
                            rectangleList.Add(rectangle);
                        }
                        dbContext.Points.AddRange(pointList);
                        dbContext.Rectangles.AddRange(rectangleList);
                    }

                    dbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        #region -- Private helpers --

        private Point AddIfNotExistPointToList(Point point, List<Point> pointList)
        {
            var existPoint = pointList.FirstOrDefault(x => x.X == point.X && x.Y == point.Y);
            if (existPoint != null)
            {
                return existPoint;
            }
            else
            {
                pointList.Add(point);
                return point;
            }
        }

        #endregion
    }
}
