namespace FigureMvcWebApi.Model.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createsp_Intersect_StoredProcedure : DbMigration
    {
        public override void Up()
        {
            SqlFile("Sql\\StoredProcedures\\sp_Intersect_Procedure.sql", true);
        }
        
        public override void Down()
        {
            SqlFile("Sql\\StoredProcedures\\drop_sp_Intersect_Procedure.sql", true);
        }
    }
}
