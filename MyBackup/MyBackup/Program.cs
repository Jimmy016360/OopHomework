using System;
using System.Text;

namespace MyBackup
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            MyBackupService backupService = new MyBackupService();
            backupService.ProcessJsonConfigs();

            Console.ReadKey();
        }
    }
}