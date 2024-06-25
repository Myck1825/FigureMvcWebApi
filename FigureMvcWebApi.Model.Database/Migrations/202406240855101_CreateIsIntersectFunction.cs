namespace FigureMvcWebApi.Model.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIsIntersectFunction : DbMigration
    {
        public override void Up()
        {
            SqlFile("Sql\\Function\\f_Intersect_Function.sql", true);
        }
        
        public override void Down()
        {
            SqlFile("Sql\\Function\\drop_f_Intersect_Function", true);
        }
    }
}
