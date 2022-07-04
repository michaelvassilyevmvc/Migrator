using FluentMigrator;

namespace GisMigrations.Migrations
{
    [Migration(202108171230)]
    public class Update_Icons_ObjectId : Migration
    {
        public override void Down()
        {
            Update.Table("Icons").Set(new { ObjectId = 0 }).AllRows();
        }

        public override void Up()
        {
            Execute.Sql(@"UPDATE i SET
                ObjectID = ISNULL((SELECT TOP 1 ID FROM Objects o WHERE o.NameRus = i.NameRus), 0)
                FROM Icons i WHERE CityID IN (SELECT ID FROM Cities WITH (ROWLOCK) WHERE EMapVisible = 1)  and i.NameRus  <> ''");
        }
    }
}
