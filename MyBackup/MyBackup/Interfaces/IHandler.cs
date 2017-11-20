using System;
using MyBackupCandidate;

namespace MyBackup
{
    public interface IHandler
    {
        byte[] Perform(Candidate candidate, byte[] target);
    }
}
