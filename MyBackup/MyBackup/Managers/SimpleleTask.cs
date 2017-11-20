using System;
using MyBackupCandidate;

namespace MyBackup
{
    public class SimpleTask : AbstractTask
    {
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);
            foreach (Candidate candidate in this.fileFinder)
                this.BroadcastToHandlers(candidate);
        }
    }
}
