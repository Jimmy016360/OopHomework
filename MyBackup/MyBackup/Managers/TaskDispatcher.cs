using System;
using System.Linq;
using System.Collections.Generic;

namespace MyBackup
{
    public class TaskDispatcher
    {
        private ITask task;
        public void SimpleTask(List<JsonManager> managers) 
        {
            this.task = TaskFactory.Create("simple");

            ConfigManager configManager = managers[0] as ConfigManager;
            foreach (var config in configManager.configs) 
            {
                this.task.Execute(config, null);                
            }

        }

        public void ScheduledTask(List<JsonManager> managers)
        {
            this.task = TaskFactory.Create("scheduled");
            ConfigManager configManager = managers[0] as ConfigManager;
            ScheduleManager scheduleManager = managers[1] as ScheduleManager;

            foreach (var config in configManager.configs)
            {
                var schedule = scheduleManager.schedules.FirstOrDefault(x => x.Ext == config.Ext);
                if (schedule != null)
                {
                    this.task.Execute(config, schedule);
                }
            }
        }

    }
}
