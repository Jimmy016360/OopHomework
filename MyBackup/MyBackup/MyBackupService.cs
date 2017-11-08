using System.Collections.Generic;

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

        public void DoBackup()
        {
            ConfigManager configManager = (managers[0] as ConfigManager);
            foreach (var config in configManager.configs)
            {
                IFileFinder fileFinder = FileFinderFactory.Create("file", config);
                foreach (Candidate candidate in fileFinder)
                {
                    this.BroadcastToHandlers(candidate);
                }
            }
        }

        private void BroadcastToHandlers(Candidate candidate)
        {
            List<IHandler> handlers = this.FindHandlers(candidate);
            byte[] target = null;
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>
            {
                HandlerFactory.Create("file")
            };

            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            return handlers;
        }
    }
}