using System;
namespace MyBackup
{
    public interface ITask
    {
        void Execute(Config config, Schedule schedule);
    }
}
