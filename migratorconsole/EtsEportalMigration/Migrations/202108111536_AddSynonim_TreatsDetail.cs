using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202108111536)]
    public class AddSynonim_TreatsDetail : Migration
    {
        public override void Down()
        {
            Execute.Sql("DROP SYNONYM TreatsDetails");
        }

        public override void Up()
        {
            Execute.Sql("CREATE SYNONYM TreatsDetails FOR BZTreatment.dbo.TreatsDetails");
        }
    }
}