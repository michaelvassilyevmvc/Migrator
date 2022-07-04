using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202108110923)]
    public class AddSynonim_Treats : Migration
    {
        public override void Down()
        {
            Execute.Sql("DROP SYNONYM Treats");
        }

        public override void Up()
        {
            Execute.Sql("CREATE SYNONYM Treats FOR BZTreatment.dbo.Treats");
        }
    }

}