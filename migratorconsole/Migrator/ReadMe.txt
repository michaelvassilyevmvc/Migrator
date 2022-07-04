Мигратор позволяет вносить изменения в архитектуру базы, в данные базы и тд. Или откатить изменения если есть уже выполненные миграции.
Это позволяет избавиться от ручного изменения базы, а так же быть уверенным что изменения попали и в тестовую и продуктивную версии базы
Шаги:
1) Добавить подключение в appsetting.json
    Пример структуры
    "SimpleDataBase":{
        "dev": "Data Source = ....; Catalog = SimpleDataBase_dev; ...",
        "test": "Data Source = ....; Catalog = SimpleDataBase_test; ...",
        "prod": "Data Source = ....; Catalog = SimpleDataBase; ..."
    }

2) Добавить к решенеию новый проект, назвать его {DataBaseName}Migrations (для примера выше SimpleDataBaseMigrations)
2.2) Добавить ссылку на проект Base, а в проекте Migrator добавить ссылку на ваш проект
3) В проекте создать папку Migrations
4) Добавить новый класс с названием {DataBaseName}Migration (для примера выше SimpleDataBaseMigration)
5) Затем добавить в Enums -> DataBases название базы данных (для примера выше SimpleDataBase) и добавить атрибут 
    [Description("{ProjectName}.{Namespace}.{ClassName}, {ProjectName}")] 
    (для примера выше 
    [Description("SimpleDataBaseMigrations.Migrations.SimpleDataBaseMigration, SimpleDataBaseMigrations")] )
6) Добавить миграцию. Название файла должно быть строго: {yyyyMMddhhmm}_{OperationName}_{TableName}
    Имена можно давать какие угодно, но придерживаясь шаблона. Год,месяц,день,час,минуты _ Название метода которй будете выполнять или 
    синоним (или что то описывающее ваше действие) _ Название таблицы с которой работали (или процедуры или что то описывающее объекты)
   Далее, в классе подключите using FluidMigrator;
   Далее выполните наслодования от класса Migration (:Migration)
   Далее, добавить атрибут [Migration({версия})] к классу. Версия - это цифры в имени файла. Вырежете их у названия класса! и вставте
   в атрибутю
   _ оставшееся после версии, в названии класса уберите

P.S если ваша IDE вы вывела вам ошибку что нужно реализовать методы Up и Down
    public override void Down()
    {
        
    }

    public override void Up()
    {

    }