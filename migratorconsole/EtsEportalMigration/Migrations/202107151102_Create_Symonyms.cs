using FluentMigrator;

namespace EtsEportalMigration.Migrations
{
    [Migration(202107151102)]
    public class Create_Symonyms : Migration
    {
        public override void Down()
        {
            Execute.Sql(@"
                DROP SYNONYM webAccessPoint_HousingChangeField;
                DROP SYNONYM webAccessPoint_HousingQueueStatus;
            ");
        }

        public override void Up()
        {
            Execute.Sql(@"
                CREATE SYNONYM webAccessPoint_HousingChangeField  
                FOR webAccessPoint.dbo.HousingChangeField;
                CREATE SYNONYM webAccessPoint_HousingQueueStatus  
                FOR webAccessPoint.dbo.HousingQueueStatus;
            ");
        }
    }
}
