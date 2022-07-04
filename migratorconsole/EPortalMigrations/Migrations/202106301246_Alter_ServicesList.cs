using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202106301246)]
    public class Alter_ServicesList : Migration
    {
        public override void Down()
        {
            Delete.Column("AlterUrl").FromTable("ServiceList");
        }

        public override void Up()
        {
            Alter.Table("ServiceList").AddColumn("AlterUrl").AsString().Nullable();

        }
    }
}
