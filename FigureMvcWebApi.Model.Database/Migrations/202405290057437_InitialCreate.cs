namespace FigureMvcWebApi.Model.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        X = c.Int(nullable: false),
                        Y = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.X, t.Y }, unique: true);
            
            CreateTable(
                "dbo.Rectangles",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PointAId = c.Guid(nullable: false),
                        PointBId = c.Guid(nullable: false),
                        PointCId = c.Guid(nullable: false),
                        PointDId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Points", t => t.PointAId)
                .ForeignKey("dbo.Points", t => t.PointBId)
                .ForeignKey("dbo.Points", t => t.PointCId)
                .ForeignKey("dbo.Points", t => t.PointDId)
                .Index(t => t.PointAId)
                .Index(t => t.PointBId)
                .Index(t => t.PointCId)
                .Index(t => t.PointDId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rectangles", "PointDId", "dbo.Points");
            DropForeignKey("dbo.Rectangles", "PointCId", "dbo.Points");
            DropForeignKey("dbo.Rectangles", "PointBId", "dbo.Points");
            DropForeignKey("dbo.Rectangles", "PointAId", "dbo.Points");
            DropIndex("dbo.Rectangles", new[] { "PointDId" });
            DropIndex("dbo.Rectangles", new[] { "PointCId" });
            DropIndex("dbo.Rectangles", new[] { "PointBId" });
            DropIndex("dbo.Rectangles", new[] { "PointAId" });
            DropIndex("dbo.Points", new[] { "X", "Y" });
            DropTable("dbo.Rectangles");
            DropTable("dbo.Points");
        }
    }
}
