using FluentMigrator;

namespace EPortalMigrations.Migrations
{
	[Migration(202109030926)]
	public class Create_Table_ElectaRegionInfo : Migration
	{
		public override void Down()
		{
			Delete.Table("ElectaRegionInfo");
		}

		public override void Up()
		{
			Create.Table("ElectaRegionInfo")
				.WithColumn("ID").AsInt64().PrimaryKey().NotNullable().Indexed().Identity()
				.WithColumn("NameRus").AsString().NotNullable()
				.WithColumn("NameKaz").AsString().NotNullable()
				.WithColumn("Phones").AsString();
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Район Казыбек Би", NameKaz = "Қазыбек би ауданы", Phones = "8-7212-300697" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Октябрьский район", NameKaz = "Октябрь ауданы", Phones = "8-7212-459770" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Балхаш", NameKaz = "Балқаш қаласы", Phones = "8-71036-47112" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Жезказган", NameKaz = "Жезқазған қаласы", Phones = "8-7102-736608" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Каражал", NameKaz = "Қаражал қаласы", Phones = "8-71032-26619" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Приозерск", NameKaz = "Приозерск қаласы", Phones = "8-71039-53288,8-71039-53006" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Сарань", NameKaz = "Саран қаласы", Phones = "8-72137-74007" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Сатпаев", NameKaz = "Сәтбаев қаласы", Phones = "8-71063-37986" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Темиртау", NameKaz = "Теміртау қаласы", Phones = "8-7213-923257" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "г. Шахтинск", NameKaz = "Шахтинск қаласы", Phones = "8-72156-53252" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Абайский район", NameKaz = "Абай ауданы", Phones = "8-72131-41978" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Актогайский район", NameKaz = "Ақтоғай ауданы", Phones = "8-71037-21247" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Бухар-Жырауский район", NameKaz = "Бұқар-Жырау ауданы", Phones = "8-72154-21030" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Жанааркинский район", NameKaz = "Жаңа-Арқа ауданы", Phones = "8-71030-28798" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Каркаралинский район", NameKaz = "Қарқаралы ауданы", Phones = "8-72146-32666" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Нуринский район", NameKaz = "Нұра ауданы", Phones = "8-72144-21632" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Осакаровский район", NameKaz = "Осақаров ауданы", Phones = "8-72149-41267" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Улытауский район", NameKaz = "Ұлытау ауданы", Phones = "8-71035-21240" });
			Insert.IntoTable("ElectaRegionInfo").Row(new { NameRus = "Шетский район", NameKaz = "Шет ауданы", Phones = "8-71031-21496,8-71031-21166" });
		}
	}
}
