using System;

namespace MyBackup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.ProcessConfigs();

            for (int i = 0; i < configManager.Count; i++)
            {
                Config config = configManager[i];
                Console.WriteLine(config.Ext);
            }

            ScheduleManager scheduleManager = new ScheduleManager();
            scheduleManager.ProcessSchedules();

            for (int i = 0; i < scheduleManager.Count; i++)
            {
                Schedule schedule = scheduleManager[i];
                Console.WriteLine(schedule.Ext);
            }

            Console.ReadKey();
        }
    }
}