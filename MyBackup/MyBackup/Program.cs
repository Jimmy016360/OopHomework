using System;
using System.Text;

namespace MyBackup
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            MyBackupService backupService = new MyBackupService();

            backupService.SimpleBackup();
            backupService.ScheduledBackup();

            Console.ReadKey();
        }
    }
}