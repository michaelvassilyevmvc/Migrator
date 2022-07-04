using FluentMigrator;

namespace EPortalMigrations.Migrations
{
    [Migration(202111291212)]
    public class CreateTable_UsersAccessToken : Migration
    {
        public override void Down()
        {
            Delete.Table("UsersAccessToken");
        }

        public override void Up()
        {
            Execute.Sql(@"CREATE TABLE [dbo].[UsersAccessToken](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NOT NULL,
	[AccessToken] [nvarchar](max) NOT NULL,
	[ExpirationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UsersAccessToken] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]");
        }
    }
}
