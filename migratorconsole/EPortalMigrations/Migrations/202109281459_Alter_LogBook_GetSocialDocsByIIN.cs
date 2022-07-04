using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202109281459)]
    public class Alter_LogBook_GetSocialDocsByIIN : Migration
    {
        public override void Down()
        {
            Execute.Sql(@"
ALTER FUNCTION [dbo].[LogBook_GetSocialDocsByIIN](@ClientID INT, @Year INT, @IIN NVARCHAR(12))
RETURNS @MyTable TABLE (
	CommingID nvarchar(50), 
	DateComming datetime, 
	ContentRus nvarchar(4000), 
	ContentKaz nvarchar(4000)
)
AS
BEGIN
	INSERT INTO @MyTable

	SELECT esd.CommingID, esd.DateComming, esd.ContentRus, esd.ContentKaz
		FROM [LogBook].[dbo].[EnterringSocialDocs] esd WITH(NOLOCK) WHERE esd.ClientID = @ClientID AND YEAR(esd.DateOutgoing) = @Year AND esd.CorresponderBIN = @IIN

	RETURN
END;");
        }

        public override void Up()
        {
            Execute.Sql(@"
ALTER FUNCTION [dbo].[LogBook_GetSocialDocsByIIN](@ClientID INT, @Year INT, @IIN NVARCHAR(12))
RETURNS @MyTable TABLE (ID BIGINT,
	CommingID nvarchar(50), 
	DateComming datetime, 
	ContentRus nvarchar(4000), 
	ContentKaz nvarchar(4000)
)
AS
BEGIN
	INSERT INTO @MyTable

	SELECT ESD.ID,esd.CommingID, esd.DateComming, esd.ContentRus, esd.ContentKaz
		FROM [LogBook].[dbo].[EnterringSocialDocs] esd WITH(NOLOCK) WHERE esd.ClientID = @ClientID AND YEAR(esd.DateOutgoing) = @Year AND esd.CorresponderBIN = @IIN

	RETURN
END;");
        }

    }
}
