using System.Collections.Generic;
using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 我的備份服務
    /// </summary>
    public class MyBackupService
    {
        /// <summary>
        /// Json 設定檔管理器集合
        /// </summary>
        private List<JsonManager> managers = new List<JsonManager>();

        /// <summary>
        /// The task dispatcher.
        /// </summary>
        private TaskDispatcher taskDispatcher;

        /// <summary>
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            managers.Add(new ConfigManager());
            managers.Add(new ScheduleManager());

            this.taskDispatcher = new TaskDispatcher();
            this.Init();
        }

        /// <summary>
        /// Init this instance.
        /// </summary>
        private void Init()
        {
            this.ProcessJsonConfigs();
        }

        /// <summary>
        /// 處理 Json 設定檔
        /// </summary>
        private void ProcessJsonConfigs()
        {
            managers.ForEach(x => x.ProcessJsonConfig());
        }

        /// <summary>
        /// Simples the backup.
        /// </summary>
        public void SimpleBackup()
        {
            this.taskDispatcher.SimpleTask(managers);
        }

        /// <summary>
        /// Scheduleds the backup.
        /// </summary>
        public void ScheduledBackup()
{
            this.taskDispatcher.ScheduledTask(managers);
        }
    }
}