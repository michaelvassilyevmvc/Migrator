using System.ComponentModel;

namespace Migrator
{
    /// <summary>
    /// Выбор операции
    /// Up - миграция вверх. Добавить в базу изменения которые описаны в файлах миграции
    /// Down - миграция ввниз. Выполняет откат до определенной версии миграции. Выполняет инструкции для Down
    /// </summary>

    public enum MigratorDirection
    {
        [Description("Обновление базы до последней версии")]
        Up,
        [Description("Регрессия базы до определенной версии")]
        Down
    }

    
    /// <summary>
    /// Перечесление баз данных. Название должно быть точно таким же, как и указано в appsettings
    /// </summary>
    public enum DataBases
    {
        [Description("EPortalMigrations.Migrations.EportalMigration, EPortalMigrations")]
        Eportal,
        [Description("EtsEportalMigration.Migrations.EtsEportalMigration, EtsEportalMigration")]
        EtsEportal,
        [Description("MFKSMigrations.Migrations.MfksMigration, MFKSMigrations")]
        Mfks,
        [Description("GisMigrations.Migrations.GisMigration, GisMigrations")]
        Gis
    }
}
