�������� ��������� ������� ��������� � ����������� ����, � ������ ���� � ��. ��� �������� ��������� ���� ���� ��� ����������� ��������.
��� ��������� ���������� �� ������� ��������� ����, � ��� �� ���� ��������� ��� ��������� ������ � � �������� � ������������ ������ ����
����:
1) �������� ����������� � appsetting.json
    ������ ���������
    "SimpleDataBase":{
        "dev": "Data Source = ....; Catalog = SimpleDataBase_dev; ...",
        "test": "Data Source = ....; Catalog = SimpleDataBase_test; ...",
        "prod": "Data Source = ....; Catalog = SimpleDataBase; ..."
    }

2) �������� � �������� ����� ������, ������� ��� {DataBaseName}Migrations (��� ������� ���� SimpleDataBaseMigrations)
2.2) �������� ������ �� ������ Base, � � ������� Migrator �������� ������ �� ��� ������
3) � ������� ������� ����� Migrations
4) �������� ����� ����� � ��������� {DataBaseName}Migration (��� ������� ���� SimpleDataBaseMigration)
5) ����� �������� � Enums -> DataBases �������� ���� ������ (��� ������� ���� SimpleDataBase) � �������� ������� 
    [Description("{ProjectName}.{Namespace}.{ClassName}, {ProjectName}")] 
    (��� ������� ���� 
    [Description("SimpleDataBaseMigrations.Migrations.SimpleDataBaseMigration, SimpleDataBaseMigrations")] )
6) �������� ��������. �������� ����� ������ ���� ������: {yyyyMMddhhmm}_{OperationName}_{TableName}
    ����� ����� ������ ����� ������, �� ������������� �������. ���,�����,����,���,������ _ �������� ������ ������ ������ ��������� ��� 
    ������� (��� ��� �� ����������� ���� ��������) _ �������� ������� � ������� �������� (��� ��������� ��� ��� �� ����������� �������)
   �����, � ������ ���������� using FluidMigrator;
   ����� ��������� ������������ �� ������ Migration (:Migration)
   �����, �������� ������� [Migration({������})] � ������. ������ - ��� ����� � ����� �����. �������� �� � �������� ������! � �������
   � ��������
   _ ���������� ����� ������, � �������� ������ �������

P.S ���� ���� IDE �� ������ ��� ������ ��� ����� ����������� ������ Up � Down
    public override void Down()
    {
        
    }

    public override void Up()
    {

    }