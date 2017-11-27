using MyBackupCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackup
{
    public interface IDBHandler
    {
        byte[] Perform(Candidate candidate, byte[] target);
    }
}
