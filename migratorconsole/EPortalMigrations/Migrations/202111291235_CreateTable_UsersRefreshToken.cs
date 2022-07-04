using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202111291234)]
    public class CreateTable_UsersRefreshToken : Migration
    {
        public override void Down()
        {
            Delete.Table("UsersRefreshToken");
        }

        public override void Up()
        {
            Execute.Sql(@"CREATE TABLE [dbo].[UsersRefreshToken](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[RefreshToken] [nvarchar](max) NOT NULL,
	[ExpirationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UsersRefreshToken] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]");
        }
    }
}
