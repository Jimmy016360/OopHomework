using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBackupCandidate;

namespace MyBackup
{
    public class DBAdapterHandler : AbstractHandler
    {
        IDBHandler backupHandler = new DBBackupHandler();
        IDBHandler logHandler = new DBLogHandler();

        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            target = base.Perform(candidate, target);

            SaveBackupToDb(candidate, target);
            SaveLogToDb(candidate, target);

            return target;
        }

        private void SaveBackupToDb(Candidate candidate, byte[] target)
        {
            backupHandler.Perform(candidate, target);
        }

        private void SaveLogToDb(Candidate candidate, byte[] target)
        {
            logHandler.Perform(candidate, target);
        }
    }
}
