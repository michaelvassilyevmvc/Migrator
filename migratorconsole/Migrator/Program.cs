using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.ComponentModel;

namespace Migrator
{
    class Program
    {
        private static readonly IConfigurationRoot _builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false).Build();
        static void Main(string[] args)
        {
            var isWorked = true;
            while (isWorked)
            {
                IServiceProvider serviceProvider = null;
                DataBases? dataBase = null;
                while (dataBase == null)
                {
                    Console.WriteLine(string.Format("Выберете подключение:\n{0}", string.Join("\n", Enum.GetNames(typeof(DataBases)))));
                    if (!Enum.TryParse<DataBases>(Console.ReadLine().Trim(), true, out DataBases parsedValue))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не верно написано подключение");
                        Console.ResetColor();
                    }                        
                    else
                        dataBase = parsedValue;
                }

                string serverType = null;
                while (string.IsNullOrEmpty(serverType))
                {
                    Console.WriteLine(string.Format("Выберете тип сервера:\n{0}", string.Join("\n", _builder.GetSection(dataBase.ToString()).GetChildren().Select(s => s.Key))));
                    
                    var strType = Console.ReadLine().Trim();
                    if (_builder.GetSection(dataBase.ToString()).GetChildren().Any(s => s.Key == strType))
                        serverType = strType;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не верно написано тип сервера");
                        Console.ResetColor();
                    }
                }

                MigratorDirection? migratorDirection = null;
                while (migratorDirection == null)
                {
                    Console.WriteLine(string.Format("Выберете тип миграции:\n{0}", string.Join("\n", Enum.GetNames(typeof(MigratorDirection)))));
                    if (!Enum.TryParse<MigratorDirection>(Console.ReadLine().Trim(), true, out MigratorDirection parsedValue))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Не верно написано направление миграции");
                        Console.ResetColor();
                    }
                    else
                        migratorDirection = parsedValue;
                }

                long? version = null;
                if (migratorDirection.Value == MigratorDirection.Down)
                {
                    while (version == null)
                    {
                        Console.WriteLine("Напишите номер версии (0 для сброса до начального состояния)");
                        var versiongStr = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(versiongStr) || !System.Text.RegularExpressions.Regex.IsMatch(versiongStr, "^[0-9]{12}$|^[0]$"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Не корректная версия. Должно быть либо 0 либо 12 чисел");
                            Console.ResetColor();
                        }
                        else
                            version = long.Parse(versiongStr);
                    }
                }

                serviceProvider = CreateServices(dataBase.Value, serverType);
                using (var scope = serviceProvider.CreateScope())
                {
                    try
                    {
                        UpdateDatabase(scope.ServiceProvider, migratorDirection.Value, version);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Что-бы выйти, нажмите q или нажмите любую другую клавишу для продолжения работы с мигратором");
                        Console.ResetColor();
                        isWorked = Console.ReadKey().Key != ConsoleKey.Q;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Устраните ошибку и попробуйте запустить мигратор еще раз");
                        Console.ResetColor();
                        isWorked = false;
                    }
                }
            }
        }

        private static IServiceProvider CreateServices(DataBases dataBase, string type)
        {
            var connection = _builder.GetSection(dataBase.ToString()).GetChildren().FirstOrDefault(s => s.Key == type).Value;
            var desc = ((DescriptionAttribute[])typeof(DataBases).GetField(dataBase.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
            var migrationType = Type.GetType(desc, true, true);
            if (migrationType == null)
                throw new Exception("Не найдена область миграций");

             return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connection)
                    .ScanIn(migrationType.Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider, MigratorDirection direction, long? version = null )
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            switch (direction)
            {
                case MigratorDirection.Up:
                    runner.MigrateUp();
                    break;
                case MigratorDirection.Down:
                    if (version == null)
                        throw new Exception("Не указана версия или версия не корректна");
                    runner.MigrateDown(version.Value);
                    break;
                default:
                    break;
            }
        }
    }
}
