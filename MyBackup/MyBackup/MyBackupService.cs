using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            managers.Add(new ConfigManager());
            managers.Add(new ScheduleManager());
        }

        /// <summary>
        /// 處理 Json 設定檔
        /// </summary>
        public void ProcessJsonConfigs()
        {
            managers.ForEach(x => x.ProcessJsonConfig());
        }
    }
}
