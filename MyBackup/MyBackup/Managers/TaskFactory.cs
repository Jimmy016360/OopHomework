using System;
namespace MyBackup
{
    public static class TaskFactory
    {
        public static ITask Create(string task)
        {
            switch (task)
            {
                case "simple":
                    return new SimpleTask();
                case "scheduled":
                    return new ScheduledTask();
                default:
                    return null;
            }
        }
    }
}
