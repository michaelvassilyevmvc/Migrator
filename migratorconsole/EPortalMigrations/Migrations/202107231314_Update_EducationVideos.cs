using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202107231314)]
    public class Update_EducationVideos : Migration
    {
        public override void Down()
        {
            Execute.Sql("UPDATE dbo.EducationVideo SET Patch = Replace(Patch, 'mp4', 'flv') WHERE Patch LIKE '%.mp4%'");
        }

        public override void Up()
        {
            Execute.Sql("UPDATE dbo.EducationVideo SET Patch = Replace(Patch, 'flv', 'mp4') WHERE Patch LIKE '%.flv%'");
        }

    }
}
