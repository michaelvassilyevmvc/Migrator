using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202111291150)]
    public class Alter_Delete_To_UsersData : Migration
    {
        public override void Down()
        {
			Execute.Sql(@"ALTER TRIGGER [dbo].[Delete_To_UsersData] ON [dbo].[UsersData]
FOR DELETE
AS

DECLARE	@ID bigint,
		@UUID varchar(36)

DECLARE DelCurs CURSOR LOCAL STATIC FOR
	SELECT ID, UUID FROM DELETED

OPEN DelCurs

FETCH FIRST FROM DelCurs INTO @ID, @UUID

WHILE @@FETCH_STATUS = 0
	BEGIN
	
	DELETE FROM dbo.UsersTasks WHERE UserDataID = @ID
	DELETE FROM dbo.Notifications WHERE UserID = @ID
	DELETE FROM dbo.NotificationStatus WHERE UserID = @ID
	DELETE FROM dbo.BlogMessages WHERE UsersDataID = @ID
	DELETE FROM dbo.AuthenticationLog WHERE UserID = @ID
	DELETE FROM dbo.ActivityLog WHERE UserID = @ID

	DELETE FROM BZTreatment.dbo.UsersData WHERE UUID = @UUID

	FETCH NEXT FROM DelCurs INTO @ID, @UUID
END

CLOSE DelCurs
DEALLOCATE DelCurs");
        }

        public override void Up()
        {
            Execute.Sql(@"ALTER TRIGGER [dbo].[Delete_To_UsersData] ON [dbo].[UsersData]
FOR DELETE
AS

DECLARE	@ID bigint,
		@UUID varchar(36)

DECLARE DelCurs CURSOR LOCAL STATIC FOR
	SELECT ID, UUID FROM DELETED

OPEN DelCurs

FETCH FIRST FROM DelCurs INTO @ID, @UUID

WHILE @@FETCH_STATUS = 0
	BEGIN
	
	DELETE FROM dbo.UsersTasks WHERE UserDataID = @ID
	DELETE FROM dbo.Notifications WHERE UserID = @ID
	DELETE FROM dbo.NotificationStatus WHERE UserID = @ID
	DELETE FROM dbo.BlogMessages WHERE UsersDataID = @ID
	DELETE FROM dbo.AuthenticationLog WHERE UserID = @ID
	DELETE FROM dbo.ActivityLog WHERE UserID = @ID
	DELETE FROM dbo.UsersAccessToken WHERE UserID = @ID
	DELETE FROM dbo.UsersRefreshToken WHERE UserID = @ID

	DELETE FROM BZTreatment.dbo.UsersData WHERE UUID = @UUID

	FETCH NEXT FROM DelCurs INTO @ID, @UUID
END

CLOSE DelCurs
DEALLOCATE DelCurs");
        }
    }
}
